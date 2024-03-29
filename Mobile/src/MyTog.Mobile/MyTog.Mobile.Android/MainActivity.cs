﻿using System.Collections.Generic;
using System.Reflection;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Auth0.OidcClient;
using Kalinkin.MyTog.Mobile;
using Kalinkin.MyTog.Mobile.Autofac;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Application = Xamarin.Forms.Application;
using Platform = Xamarin.Essentials.Platform;

namespace MyTog.Mobile.Droid
{
    [Activity(Label = "My Tog", Icon = "@mipmap/cameraicon", Theme = "@style/MainTheme", MainLauncher = true,
        LaunchMode = LaunchMode.SingleTask,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(
        new[] {Intent.ActionView},
        Categories = new[] {Intent.CategoryDefault, Intent.CategoryBrowsable},
        DataScheme = "com.kalinkin.mytog.mobile",
        DataHost = "mytog.auth0.com",
        DataPathPrefix = "/android/com.kalinkin.mytog.mobile/callback")]
    public class MainActivity : FormsAppCompatActivity
    {
        private IEnumerable<IApplicationService> _services;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);


            var bootstrapper = new AutofacBootstrapper();
            bootstrapper.Initialize();
            bootstrapper.AddAssembly(Assembly.GetExecutingAssembly());
            bootstrapper.MakeContainer();

            _services = bootstrapper.Resolve<IEnumerable<IApplicationService>>();
            var application = bootstrapper.Resolve<Application>();
            LoadApplication(application);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            ActivityMediator.Instance.Send(intent.DataString);
        }
    }
}