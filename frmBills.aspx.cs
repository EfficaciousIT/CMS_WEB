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

public partial class frmBills : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = createDataTable();
        GridView1.DataBind();

        GridView2.DataSource = createDataTable();
        GridView2.DataBind();

        GridView3.DataSource = createDataTable();
        GridView3.DataBind();

        GridView4.DataSource = createDataTable();
        GridView4.DataBind();
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("schoolname");
        dt.Columns.Add("billtype");
        dt.Columns.Add("duedate");
        dt.Columns.Add("amount");

        DataRow dr = dt.NewRow();
        dr["Schoolname"] = "St.xavier";
        dr["billtype"] = "Monthy";
        dr["duedate"] = "01-09-2014";
        dr["amount"] = "5000.00";
        
        dt.Rows.Add(dr);
        return dt;
    }
}
