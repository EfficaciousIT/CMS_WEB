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
using System.Data.SqlClient;

public partial class frmBookStatus : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    SqlConnection sqlCon = new SqlConnection();
    bool boolStatus;
    string strCategory = string.Empty;
    string strBookReff, strTitle, strAuthor, strPublication, strCategoryText, strBook_id, strBookStatus;
    string strAssignDate, strReturnDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTitle = new Label();
        lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
        lblTitle.Visible = true;
        lblTitle.Text = "Book Assignment Detail";
        if (!IsPostBack)
        {
            FillCategory();
            TabContainer1.Tabs[1].Enabled = false;
        }
    }
    protected void FillBooks(string strCategory)
    {
        strQry = "usp_LiabraryMng  @command='select',@intcategory_id='" + strCategory.ToString().Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
        {
            grgBooks.DataSource = dsObj;
            grgBooks.DataBind();
        }
    }
    protected void FillCategory()
    {
        strQry = "usp_LiabraryMng  @command='category',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        boolStatus = sBindDropDownListAll(drpCategory, strQry, "vchcategory_name", "intcategory_id");

        TabContainer1.ActiveTabIndex = 0;
    }
    protected void drpCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        strCategory = Convert.ToString(drpCategory.SelectedValue);
        FillBooks(strCategory);
    }
    protected void txtLibrarycard_TextChanged(object sender, EventArgs e)
    {
        strQry = "usp_LiabraryMng  @command='CardHolder',@vchLibrarycard_no='" + txtLibrarycard.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
        {
            lblAssignTo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchname"]);
        }
    }
    protected void grgBooks_RowEditing(object sender, GridViewEditEventArgs e)
    {
        TabContainer1.Tabs[1].Enabled = true;
        Session["strBook_id"] = Convert.ToString(grgBooks.DataKeys[e.NewEditIndex].Values[0]);        
        lblBookReff.Text = Convert.ToString(grgBooks.DataKeys[e.NewEditIndex].Values[1]);
        lblTitle.Text = Convert.ToString(grgBooks.DataKeys[e.NewEditIndex].Values[2]);
        lblAuthor.Text = Convert.ToString(grgBooks.DataKeys[e.NewEditIndex].Values[3]);
        lblPublication.Text = Convert.ToString(grgBooks.DataKeys[e.NewEditIndex].Values[4]);
        lblCategoryText.Text = Convert.ToString(grgBooks.DataKeys[e.NewEditIndex].Values[5]);
        Session["strBookStatus"] = Convert.ToString(grgBooks.DataKeys[e.NewEditIndex].Values[6]);

        if (Convert.ToString(Session["strBookStatus"]) == "No")
        {
            strQry = "usp_LiabraryMng  @command='selectUserDet',@intBook_id='" + Convert.ToString(Session["strBook_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj != null & dsObj.Tables[0].Rows.Count > 0)
            {
                txtLibrarycard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intLibrary_id"]);
                lblAssignTo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchname"]);
                txtAssignDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtAssignDate"]);
                txtAssignDate.ReadOnly = true;
                txtReturnDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtReturnDate"]);
                Session["txtReturnDate"] = txtReturnDate.Text;
            }
        }

        TabContainer1.ActiveTabIndex = 1;
  
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        strAssignDate = Convert.ToDateTime(txtAssignDate.Text).ToString("MM/dd/yyyy");
        strReturnDate = Convert.ToDateTime(txtReturnDate.Text).ToString("MM/dd/yyyy");

        if (Convert.ToString(Session["strBookStatus"]) == "No")
        {
            Session["txtReturnDate"] = Convert.ToDateTime(Session["txtReturnDate"]).ToString("dd/MM/yyyy");

            if (Convert.ToString(Session["txtReturnDate"]) != strReturnDate & txtActReturnDate.Text=="")
            {
                strReturnDate = Convert.ToDateTime(txtReturnDate.Text).ToString("MM/dd/yyyy");
                strQry = "usp_LiabraryMng  @command='UpdateExtension',@dtReturnDate='" + strReturnDate.Trim() + "',@intBook_id='" + Convert.ToString(Session["strBook_id"]) + "'";
                int i = sExecuteQuery(strQry);
                if (i > 0)
                {
                    FillBooks("A");
                    TabContainer1.ActiveTabIndex = 0;
                    MessageBox("Book Retured date extended Successfully");
                }
            }
            else
            {
                strReturnDate = Convert.ToDateTime(txtActReturnDate.Text).ToString("MM/dd/yyyy");
                strQry = "usp_LiabraryMng  @command='UpdateRecStatus',@dtActualRetDate='" + strReturnDate.Trim() + "',@intBook_id='" + Convert.ToString(Session["strBook_id"]) + "'";
                int i = sExecuteQuery(strQry);
                if (i > 0)
                {
                    strQry = "usp_LiabraryMng  @command='Updatebookdetails',@intBook_id='" + Convert.ToString(Session["strBook_id"]) + "'";
                    i = sExecuteQuery(strQry);
                    FillBooks("A");
                    MessageBox("Book collected Successfully");
                    TabContainer1.ActiveTabIndex = 0;
                }
            }
            
        }
        else
        {
            strQry = "usp_LiabraryMng  @command='Insert',@intLibrary_id='" + txtLibrarycard.Text.Trim() + "',@intBook_id='" + Convert.ToString(Session["strBook_id"]) + "',@dtAssignDate='" + strAssignDate.Trim() + "',@dtReturnDate='" + strReturnDate.Trim() + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intAssignBy='" + Convert.ToString(Session["User_id"]) + "'";
            int i = sExecuteQuery(strQry);
            if (i > 0)
            {
                strQry = "usp_LiabraryMng  @command='UpdateStatus',@intBook_id='" + Convert.ToString(Session["strBook_id"]) + "'";
                i = sExecuteQuery(strQry);
                FillBooks("A");
                MessageBox("Book Assigned Successfully");
                TabContainer1.ActiveTabIndex = 0;
            }
        }        
        
    }
    public void MessageBox(string msg)
    {
        try
        {
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

        }
        catch (Exception)
        {
            // return msg;
        }
    }
}
