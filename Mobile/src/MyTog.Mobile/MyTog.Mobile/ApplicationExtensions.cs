using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    internal static class ApplicationExtensions
    {
        public static void InsureMainThread(this Application app, Action action)
        {
            if (MainThread.IsMainThread)
            {
                action();
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(action);
            }
        }
    }
}