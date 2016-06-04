

namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;

    public class AssetInfo
    {
        public int assetId
        {
            get;
            set;
        }
        public int quantity
        {
            get;
            set;
        }
        public String assetName
        {
            get;
            set;
        }
        public String BillNo
        {
            get;
            set;
        }
        public String serialNo
        {
            get;
            set;
        }
        public int assetTypeId
        {
            get;
            set;
        }
     
        public String modelNo
        {
            get;
            set;
        }
        public String assetDescription
        {
            get;
            set;
        }
        public Decimal assetPrice
        {
            get;
            set;
        }
        public DateTime purchaseDate
        {
            get;
            set;
        }
        public DateTime createdDate
        {
            get;
            set;
        }
        public Boolean isWorking
        {
            get;
            set;
        }

        public int assetVendorId
        {
            get;
            set;
        }
    }
}
