using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.Utils
{
    public class ApiAppSettings
    {
        public int ClientOutstandingOrderLimit { get; set; }
        public int ExistingOrderQuantityLimit { get; set; }
    }
}
