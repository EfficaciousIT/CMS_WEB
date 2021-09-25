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

public partial class frmBookIssue : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTitle = new Label();
        //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTitle.Visible = true;
        //lblTitle.Text = "Book Issue Detail";
        if (!IsPostBack)
        {
            FillBookDetails();
        }
        
    }

    protected void FillBookDetails()
    {
        //strQry = "usp_tblBookAssign  @command='selectStudent',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        strQry = "usp_BookDetails @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
        {
            grgBooks.DataSource = dsObj;
            grgBooks.DataBind();
        }

    }
}
