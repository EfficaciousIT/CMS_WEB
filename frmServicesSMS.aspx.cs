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

public partial class frmServiceSMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = createDataTable();
        GridView1.DataBind();
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("servicename");
        dt.Columns.Add("count");
        dt.Columns.Add("period");

        DataRow dr = dt.NewRow();
        dr["servicename"] = "Premium";
        dr["count"] = "500";
        dr["period"] = "1 Year";
        dt.Rows.Add(dr);
        return dt;
    }
}
