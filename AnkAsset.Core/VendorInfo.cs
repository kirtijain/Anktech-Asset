

namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;

    public class VendorInfo
    {
        public int assetVendorId
        {
            get;
            set;
        }
       
        public String vendorName
        {
            get;
            set;
        }
        public String personName
        {
            get;
            set;
        }
        public String contactNo
        {
            get;
            set;
        }
        public String alternateNumber
        {
            get;
            set;
        }

        public DateTime createdDate
        {
            get;
            set;
        }
        public String serviceCenterAddress
        {
            get;
            set;
        }
       



       
    }
}
