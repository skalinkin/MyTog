using System;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    public interface IMenuItem
    {
        string Title { get; }

        Type TargetType { get; }
        Page CreateTarget();
    }
}