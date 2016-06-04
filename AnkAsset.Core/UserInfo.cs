

namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;

    public class UserInfo
    {
        public int userId
        {
            get;
            set;
        }
        public Guid userGuid
        {
            get;
            set;
        }
        public String userName
        {
            get;
            set;
        }
        public String email
        {
            get;
            set;
        }
        public String password
        {
            get;
            set;
        }
        public String newPassword
        {
            get;
            set;
        }
        public DateTime createdDate
        {
            get;
            set;
        }
        public String userContact
        {
            get;
            set;
        }
        public String userAddress
        {
            get;
            set;
        }
        public String name
        {
            get;
            set;
        }
       
        public Boolean isActive
        {
            get;
            set;
        }





       
    }
}
