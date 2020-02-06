using System;

namespace Kalinkin.MyTog.Mobile
{
    public interface IMenuItem
    {
        string Title { get; }

        Type TargetType { get; }
    }
}