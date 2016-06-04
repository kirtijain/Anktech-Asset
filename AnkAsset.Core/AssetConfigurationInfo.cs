
namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;

    public class AssetConfigurationInfo
    {

        public int assetConfigurationId
        {
            get;
            set;
        }
       
        public int assetPartId
        {
            get;
            set;
        }
        public String RAMSize
        {
            get;
            set;
        }
        public String hardDiskSize
        {
            get;
            set;
        }
        public String OStype
        {
            get;
            set;
        }
        public String processor
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
