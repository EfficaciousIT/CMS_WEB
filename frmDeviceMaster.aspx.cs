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

public partial class frmDeviceMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView3.DataSource = createDataTable();
        GridView3.DataBind();
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Devicenumber");
        dt.Columns.Add("IP");
        dt.Columns.Add("Port");
        dt.Columns.Add("SimNumber");
        dt.Columns.Add("APNProvider");
        dt.Columns.Add("APNName");        

        DataRow dr = dt.NewRow();
        dr["Devicenumber"] = "B120";
        dr["IP"] = "203.125.138.125";
        dr["Port"] = "3020";
        dr["SimNumber"] = "4524025125";
        dr["APNProvider"] = "Airtel";
        dr["APNName"] = "inernet";      

        dt.Rows.Add(dr);
        return dt;
    }
}
