

namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;

    public class AssetPartInfo
    {
        public int assetTypeId
        {
            get;
            set;
        }
        public int assetId
        {
            get;
            set;
        }
        public int assetPartId
        {
            get;
            set;
        }
        public String partName
        {
            get;
            set;
        }
        public String partSerialNo
        {
            get;
            set;
        }

        public String company
        {
            get;
            set;
        }
        public String partModelNo
        {
            get;
            set;
        }
        public String ModelNo
        {
            get;
           set;
        }
        public String SerialNo
        {
            get;
            set;
        }
        public String partDescription
        {
            get;
            set;
        }
        public Decimal partPrice
        {
            get;
            set;
        }
        public DateTime partPurchaseDate
        {
            get;
            set;
        }
        public int warrantyMonths
        {
            get;
            set;
        }
        public DateTime warrantyDate
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
        public Boolean isOccupied
        {
            get;
            set;
        }
    }
}
