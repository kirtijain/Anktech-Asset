

namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;

    public class EmployeeAllotmentInfo
    {
        public int EmployeeAllotmentId
        {
            get;
            set;
        }
        public int AssetTypeId
        {
            get;
            set;
        }
        public int Id
        {
            get;
            set;
        }
        public String allotedModelNo
        {
            get;
            set;
        }
       
        public String allotedSerialNo
        {
            get;
            set;
        }
        public int allotedItemId
        {
            get;
            set;
        }
        //public int itemQuantity
        //{
        //    get;
        //    set;
        //}
    
        public DateTime createdDate
        {
            get;
            set;
        }
    }
}