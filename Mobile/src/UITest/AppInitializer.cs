using Xamarin.UITest;

namespace Kalinkin.MyTog.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .ApkFile(
                        @"C:\Users\SK\AppData\Local\Xamarin\Mono for Android\Archives\2020-02-09\MyTog.Mobile.Android 2-09-20 12.16 PM.apkarchive\com.kalinkin.mytog.mobile.apk")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}