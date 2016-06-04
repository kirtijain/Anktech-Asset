

namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;

    public class AssetMaintainanceInfo
    {
        public int assetMaintainanceId
        {
            get;
            set;
        }
        public int assetPartId
        {
            get;
            set;
        }
        public String partModelNo
        {
            get;
            set;
        }
        public String  partSerialNo
        {
            get;
            set;
        }
        public int assetTypeId
        {
            get;
            set;
        }
        public int assetVendorId
        {
            get;
            set;
        }
        public int lookupCallStatusId
        {
            get;
            set;
        }
        public DateTime callDate
        {
            get;
            set;
        }
        public DateTime serviceDate
        {
            get;
            set;
        }
        public String issueDescription
        {
            get;
            set;
        }
        
        public DateTime createdDate
        {
            get;
            set;
        }
        public Decimal maintainanceCost
        {
            get;
            set;
        }
        
          }
}
