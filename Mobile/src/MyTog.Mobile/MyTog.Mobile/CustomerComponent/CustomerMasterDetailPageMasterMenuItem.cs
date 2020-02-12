using System;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    public class CustomerMasterDetailPageMasterMenuItem
    {
        public CustomerMasterDetailPageMasterMenuItem()
        {
            TargetType = typeof(CustomerMasterDetailPageMasterMenuItem);
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}