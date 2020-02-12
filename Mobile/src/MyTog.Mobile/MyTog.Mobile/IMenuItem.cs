using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    public interface IMenuItem
    {
        string Title { get; }

        Page CreateTarget();
    }
}