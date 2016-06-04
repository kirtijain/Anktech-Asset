

namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;

    public class AssetAllotmentInfo
    {
        public int assetAllotmentId
        {
            get;
            set;
        }
        public int assetPartId
        {
            get;
            set;
        }
        public int Id
        {
            get;
            set;
        }
        public String allotedItemModelNo
        {
            get;
            set;
        }
        public String allotToModelNo
        {
            get;
            set;
        }
        public String allotToSerialNo
        {
            get;
            set;
        }
        public int allotedItemId
        {
            get;
            set;
        }
        public String allotedItemSerialNo
        {
            get;
            set;
        }
        //public int itemQuantity
        //{
        //    get;
        //    set;
        //}
        public DateTime allotmentDate
        {
            get;
            set;
        }
        public DateTime createdDate
        {
            get;
            set;
        }
    }
}