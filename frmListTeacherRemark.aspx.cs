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

public partial class frmListTeacherRemark : DBUtility
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
            GridViewremark.DataSource = createDataTable();
            GridViewremark.DataBind();
            GridViewremark.Columns[0].Visible = false;
            GridViewremark.Columns[1].Visible = false;

        }
        catch 
        {
        
        
        }
    }
    private object createDataTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("dtRoll");
        dt.Columns.Add("dtName");
        dt.Columns.Add("teachername");
        dt.Columns.Add("subject");
        dt.Columns.Add("remark");
        dt.Columns.Add("date");

        DataRow dr = dt.NewRow();


        dr["dtRoll"] = "2";
        dr["dtName"] = "Mahesh";
        dr["teachername"] = "Anita singh";
        dr["subject"] = "Hindi";
        dr["remark"] = "Always grammer mistake";
        dr["date"] = "05-08-2014";

        dt.Rows.Add(dr);

        DataRow dr1 = dt.NewRow();
        dr1["dtRoll"] = "3";
        dr1["dtName"] = "Janavi";
        dr1["teachername"] = "Himansu pandey";
        dr1["subject"] = "Maths";
        dr1["remark"] = "Not concentrate on lecture";
        dr1["date"] = "26-08-2014";

        dt.Rows.Add(dr1);

        return dt;
    }
}
