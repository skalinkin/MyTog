using Xamarin.UITest;

namespace UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .ApkFile(
                        @"C:\Users\SK\AppData\Local\Xamarin\Mono for Android\Archives\2020-02-07\MyTog.Mobile.Android 2-07-20 12.29 AM.apkarchive\com.kalinkin.mytog.mobile.apk")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}