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

public partial class frmRFDeviceManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = createDataTable();
        GridView1.DataBind();
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("devicenumer");
        dt.Columns.Add("ip");
        dt.Columns.Add("port");        

        DataRow dr = dt.NewRow();
        dr["devicenumer"] = "C-125";
        dr["ip"] = "201.125.124.125";
        dr["port"] = "3020";        
        dt.Rows.Add(dr);
        return dt;
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        txtDevicenumber.Text = "C-125";
        txtIP.Text = "215.235.251.253";
        txtPort.Text = "3020";       
        TabContainer1.Focus();
        TabContainer1.ActiveTabIndex = 1;
    }
}
