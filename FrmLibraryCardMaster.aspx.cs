using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class FrmLibraryCardMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
            fillStandard();
        }
    }
    protected void fGrid()
    {
        strQry = "usp_tblLib_Card_Master @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtAccessionNo.Text = "";
            btnSubmit.Text = "Submit";
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtAccessionNo.Text = "";
            btnSubmit.Text = "Submit";
        }
    }
    
    protected void fillStandard()
    {
        strQry = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlStandard, strQry, "Standard_name", "intStandard_id");
        sBindDropDownList(ddlDetStandard, strQry, "Standard_name", "intStandard_id");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlStandard.SelectedValue == "0")
        {
            MessageBox("Please Select Standard!");
            ddlStandard.Focus();
            return;
        }
        if (ddlBookCategory.SelectedValue == "0")
        {
            MessageBox("Please Select Category!");
            ddlBookCategory.Focus();
            return;
        }
        if (ddlBookEdition.SelectedValue == "0")
        {
            MessageBox("Please Select Edition!");
            ddlBookEdition.Focus();
            return;
        }
        if (ddlBookPublication.SelectedValue == "0")
        {
            MessageBox("Please Select Publication!");
            ddlBookPublication.Focus();
            return;
        }
        if (ddlBookAuthor.SelectedValue == "0")
        {
            MessageBox("Please Select Author!");
            ddlBookAuthor.Focus();
            return;
        }
        if (ddlSubject.SelectedValue == "0")
        {
            MessageBox("Please Select Subject!");
            ddlSubject.Focus();
            return;
        }
        if (ddlBookName.SelectedValue == "0")
        {
            MessageBox("Please Select Book Name!");
            ddlBookName.Focus();
            return;
        }
        if (txtAccessionNo.Text == "")
        {
            MessageBox("Please Insert book Accession Number!");
            txtAccessionNo.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblLib_Card_Master @command='checkExist',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.Trim() + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.ToString() + "',@intBook_Author_id='" + ddlBookAuthor.SelectedValue.ToString() + "',@intBookLanguage_id='" + ddlSubject.SelectedValue.ToString() + "',@intBookDetails_id='" + ddlBookName.SelectedValue.ToString() + "',@intCard_no='" + Convert.ToString(txtAccessionNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Accession Number Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblLib_Card_Master] @command='insert',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.Trim() + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.ToString() + "',@intBook_Author_id='" + ddlBookAuthor.SelectedValue.ToString() + "',@intBookLanguage_id='" + ddlSubject.SelectedValue.ToString() + "',@intBookDetails_id='" + ddlBookName.SelectedValue.ToString() + "',@intCard_no='" + Convert.ToString(txtAccessionNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Inserted Successfully!");
                }
            }
        }
        else
        {
            strQry = "usp_tblLib_Card_Master @command='checkExist',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.Trim() + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.ToString() + "',@intBook_Author_id='" + ddlBookAuthor.SelectedValue.ToString() + "',@intBookLanguage_id='" + ddlSubject.SelectedValue.ToString() + "',@intBookDetails_id='" + ddlBookName.SelectedValue.ToString() + "',@intCard_no='" + Convert.ToString(txtAccessionNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Accession Number is Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblLib_Card_Master] @command='update',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.Trim() + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.ToString() + "',@intBook_Author_id='" + ddlBookAuthor.SelectedValue.ToString() + "',@intBookLanguage_id='" + ddlSubject.SelectedValue.ToString() + "',@intBookDetails_id='" + ddlBookName.SelectedValue.ToString() + "',@intCard_no='" + Convert.ToString(txtAccessionNo.Text.Trim()) + "',@intLib_card_id='" + Convert.ToString(Session["lLibCardID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlStandard.ClearSelection();
        ddlBookCategory.ClearSelection();
        ddlBookEdition.ClearSelection();
        ddlBookPublication.ClearSelection();
        ddlBookAuthor.ClearSelection();
        ddlSubject.ClearSelection();
        ddlBookName.ClearSelection();
        txtAccessionNo.Text = "";
        btnSubmit.Text = "Submit";
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




    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["lLibCardID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblLib_Card_Master] @command='delete',@intLib_card_id='" + Convert.ToString(Session["lLibCardID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Record Deleted Successfully!");
            }
        }
        catch
        {

        }
    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["lLibCardID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblLib_Card_Master @command='edit',@intLib_card_id='" + Convert.ToString(Session["lLibCardID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlStandard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                fBookCategory();
                ddlBookCategory.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intCategory_id"]);
                fBookEdition();
                ddlBookEdition.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookEdition_id"]);
                fBookPublication();
                ddlBookPublication.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intBook_publication_id"]);
                fBookAuthor();
                ddlBookAuthor.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intBook_Author_id"]);
                BookSubject();
                ddlSubject.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookLanguage_id"]);
              
                fBookName();
                ddlBookName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookDetails_id"]);
                txtAccessionNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intCard_no"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fBookCategory();
        fBookEdition();
        fBookPublication();
        fBookAuthor();
    }
    protected void fBookCategory()
    {
        strQry = "[usp_tblLib_Card_Master] @command='BookCategory',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlBookCategory, strQry, "vchCategory_name", "intCategory_id");
    }
    protected void fBookEdition()
    {
        strQry = "[usp_tblLib_Card_Master] @command='BookEdition',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlBookEdition, strQry, "vchBookEdition_name", "intBookEdition_id");
    }
    protected void fBookPublication()
    {
        strQry = "[usp_tblLib_Card_Master] @command='BookPublication',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlBookPublication, strQry, "vchBook_publication_name", "intBook_publication_id");
    }

    protected void fBookAuthor()
    {
        strQry = "[usp_tblLib_Card_Master] @command='BookAuthor',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlBookAuthor, strQry, "vchBook_Author_name", "intBook_Author_id");
    }
    protected void ddlBookAuthor_SelectedIndexChanged(object sender, EventArgs e)
    {
        BookSubject();        
    }
    protected void BookSubject()
    {
        strQry = "[usp_tblLib_Card_Master] @command='BookSubject',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.Trim() + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.ToString() + "',@intBook_Author_id='" + ddlBookAuthor.SelectedValue.ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlSubject, strQry, "vchBookLanguage_name", "intBookLanguage_id");
    }
  
    protected void fBookName()
    {
        strQry = "[usp_tblLib_Card_Master] @command='BookName',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.Trim() + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.ToString() + "',@intBook_Author_id='" + ddlBookAuthor.SelectedValue.ToString() + "',@intBookLanguage_id='" + ddlSubject.SelectedValue.ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlBookName, strQry, "vchBookDetails_bookName", "intBookDetails_id");
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        fBookName();
    }
    protected void DetBookSubject()
    {
        strQry = "[usp_tblLib_Card_Master] @command='DetBookSubject',@intStandard_id='" + ddlDetStandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlDetSubject, strQry, "vchBookLanguage_name", "intBookLanguage_id");
    }
    protected void DetBookName()
    {
        strQry = "[usp_tblLib_Card_Master] @command='DetBookName',@intStandard_id='" + ddlDetStandard.SelectedValue.Trim() + "',@intBookLanguage_id='" + ddlDetSubject.SelectedValue.ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlDetBookName, strQry, "vchBookDetails_bookName", "intBookDetails_id");
    }
    protected void ddlDetSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetBookName();
    }
    protected void ddlDetStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetBookSubject();
    }
    protected void ddlDetBookName_SelectedIndexChanged(object sender, EventArgs e)
    {
        fDetGrid();
    }
    protected void fDetGrid()
    {
        strQry = "usp_tblLib_Card_Master @command='fDetGrid',@intStandard_id='" + ddlDetStandard.SelectedValue.Trim() + "',@intBookLanguage_id='" + ddlDetSubject.SelectedValue.ToString() + "',@intBookDetails_id='" + ddlDetBookName.SelectedValue.ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtAccessionNo.Text = "";
            btnSubmit.Text = "Submit";
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtAccessionNo.Text = "";
            btnSubmit.Text = "Submit";
        }
    }
}