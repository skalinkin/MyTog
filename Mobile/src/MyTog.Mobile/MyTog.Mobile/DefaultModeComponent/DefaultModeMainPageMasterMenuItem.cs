using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalinkin.MyTog.Mobile.DefaultModeComponent
{

    public class DefaultModeMainPageMasterMenuItem
    {
        public DefaultModeMainPageMasterMenuItem()
        {
            TargetType = typeof(DefaultModeMainPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}