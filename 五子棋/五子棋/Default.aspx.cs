using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace 五子棋
{
    public partial class _Default : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {
            ptob.boolBoard =new  int[15, 15];
            ptob.boardImport = new int[15, 15, 4, 2];
            ptob.boolImportdAll = new int[15, 15, 2];
        }
    }
}
