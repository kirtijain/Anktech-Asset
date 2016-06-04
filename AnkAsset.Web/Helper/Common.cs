using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AnkAsset.Web.Helper
{
    public class Common
    {
        public static void BindDropdowns(DropDownList ddl, string Text, string Value, DataTable dt, string Default)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = Text;
            ddl.DataValueField = Value; // the id of the items displayed
            ddl.DataBind();
            ddl.Items.Insert(0, Default);
        }
    }
}
