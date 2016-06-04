

namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;

    public class AssetSpareInfo
    {
        public int assetTypeId
        {
            get;
            set;
        }
         public int assetSpareId
        {
            get;
            set;
        }
         public int assetPartId
         {
             get;
             set;
         }
        public String sparePartName
        {
            get;
            set;
        }
        public String sparePartSerialNo
        {
            get;
            set;
        }

        public String sparePartModelNo
        {
            get;
            set;
        }
    }
}
