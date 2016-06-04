

namespace AnkAsset.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AnkAsset.Data;

    public class EmployeeInfo
    {
        public int Id
        {
            get;
            set;
        }
        public int EmpId
        {
            get;
            set;
        }
       
        public String EmployeeName
        {
            get;
            set;
        }
       
        public String EmailId
        {
            get;
            set;
        }
        
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public String ContactNo
        {
            get;
            set;
        }
        public String Address
        {
            get;
            set;
        }
             
        public Boolean IsActive
        {
            get;
            set;
        }
    }
}
