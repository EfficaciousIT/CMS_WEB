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

public partial class frmTeacherRemark : DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Teacher's Remark";
            if (!IsPostBack)
            {
                checksession();
                geturl();
            
            }

            GridView1.DataSource = createDataTable();
            GridView1.DataBind();
        }
        catch 
        {
        
        }
        

    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("teachername");
        dt.Columns.Add("subject");
        dt.Columns.Add("remark");
        dt.Columns.Add("date");

        DataRow dr = dt.NewRow();
        DataRow dr1 = dt.NewRow();

        dr["teachername"] = "Anita singh";
        dr["subject"] = "Hindi";
        dr["remark"] = "Always grammer mistake";
        dr["date"] = "05-08-2014";

        dt.Rows.Add(dr);

        dr1["teachername"] = "Himansu pandey";
        dr1["subject"] = "Maths";
        dr1["remark"] = "Not concentrate on lecture";
        dr1["date"] = "26-08-2014";

        dt.Rows.Add(dr1);

        return dt;
    }
}
