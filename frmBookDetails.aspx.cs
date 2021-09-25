using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class BookDetails : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillStandard();
            fBookCategory();
            fBookEdition();
            fBookPublication();
            fBookAuthor();
            fGrid();
            BookSubject();
            getBookStatus("Add");
            getRemarks("Add");
            getBookStatusInSearch();
        }
    }


    protected void fGrid()
    {
        try
        {
            strQry = "usp_BookDetails @command='select',@intStandard_id='" + ddlDetStandard.SelectedValue.Trim() + "',@intBookLanguage_id='" + ddlDetSubject.SelectedValue.ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@StatusId='" + ddlSStatus.SelectedValue.ToString() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                // txtName.Text = "";
                Session["BookDetailsTable"] = dsObj;
                Session["BookDetailsTableDummy"] = dsObj;
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                // txtName.Text = "";
                Session["BookDetailsTable"] = dsObj;
                Session["BookDetailsTableDummy"] = dsObj;
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }
    protected void fillStandard()
    {
        try
        {
            strQry = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlStandard, strQry, "Standard_name", "intStandard_id");
            sBindDropDownList(ddlDetStandard, strQry, "Standard_name", "intStandard_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }
    protected void BookSubject()
    {
        try
        {
            strQry = "[usp_BookDetails] @command='BookSubject',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlSubject, strQry, "vchBookLanguage_name", "intBookLanguage_id");
            sBindDropDownList(ddlDetSubject, strQry, "vchBookLanguage_name", "intBookLanguage_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void fBookCategory()
    {
        try
        {
            strQry = "[usp_BookDetails] @command='BookCategory',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlBookCategory, strQry, "vchCategory_name", "intCategory_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }
    protected void fBookEdition()
    {
        try
        {
            strQry = "[usp_BookDetails] @command='BookEdition',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlBookEdition, strQry, "vchBookEdition_name", "intBookEdition_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }
    protected void fBookPublication()
    {
        try
        {
            strQry = "[usp_BookDetails] @command='BookPublication',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlBookPublication, strQry, "vchBook_publication_name", "intBook_publication_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void fBookAuthor()
    {
        try
        {
            strQry = "[usp_BookDetails] @command='BookAuthor',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlBookAuthor, strQry, "vchBook_Author_name", "intBook_Author_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void getBookStatus(string mode)
    {
        try
        {
            strQry = "[usp_BookDetails] @command='getBookStatus',@mode='" + mode.ToString() + "'";
            sBindDropDownList(ddlStatusId, strQry, "Status", "StatusId");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlStandard.SelectedValue == "0")
            {
                ShowErrorMessage("Please select Standard!");
                ddlStandard.Focus();
                return;
            }
            if (ddlBookCategory.SelectedValue == "0")
            {
                ShowErrorMessage("please Select Book Category!");
                ddlBookCategory.Focus();
                return;
            }
            if (ddlSubject.SelectedValue == "0")
            {
                ShowErrorMessage("Please Select Subject!");
                ddlSubject.Focus();
                return;
            }
            if (txtName.Text == "")
            {
                ShowErrorMessage("Please Insert Book Name!");
                txtName.Focus();
                return;
            }
            if (txtAccessionNo.Text == "")
            {
                ShowErrorMessage("Please Insert Accession No!");
                txtAccessionNo.Focus();
                return;
            }
            if (ddlStatusId.SelectedValue == "0")
            {
                ShowErrorMessage("Please select Status!");
                ddlStatusId.Focus();
                return;
            }
            if (ddlStatusId.SelectedValue == "1" && ddlRemark.SelectedValue == "0")
            {
                ShowErrorMessage("Please select Remark!");
                ddlRemark.Focus();
                return;
            }
            strQry = "";

            if (btnSubmit.Text == "Submit")
            {
                strQry = "usp_BookDetails @command='checkExistAccession',@vchAccessionNo='" + (txtAccessionNo.Text).ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ShowErrorMessage("Accession No. is Already Exists");
                    return;
                }
                else
                {
                    strQry = "exec [usp_BookDetails] @command='insert',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='"
                        + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.Trim()
                        + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.Trim() + "',@intBook_Author_id='"
                        + ddlBookAuthor.SelectedValue.Trim() + "',@intBookLanguage_id='" + ddlSubject.SelectedValue.ToString()
                        + "',@vchBookDetails_bookName='" + Convert.ToString(txtName.Text.Trim()) + "',@intBookPrice='" + (txtBookPrice.Text).ToString() + "',@vchAccessionNo='"
                        + (txtAccessionNo.Text).ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='"
                        + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"])
                        + "',@vchRackNo='" + txtRackNo.Text.ToString() + "',@vchRowNo='" + txtRowNo.Text.ToString() 
                        + "',@StatusId='" + ddlStatusId.SelectedValue.Trim() + "',@RemarkId='" + ddlRemark.SelectedValue.Trim() + "'";

                    if (sExecuteQuery(strQry) != -1)
                    {
                        fGrid();
                        ShowSuccessMessage("Record Inserted Successfully!");
                        clear();
                    }
                }
            }
            else
            {
                //strQry = "usp_BookDetails @command='checkExist',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.Trim() + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.ToString() + "',@intBook_Author_id='" + ddlBookAuthor.SelectedValue.ToString() + "',@intBookLanguage_id='" + ddlSubject.SelectedValue.ToString() + "',@vchBookDetails_bookName='" + Convert.ToString(txtName.Text.Trim()) + "',@intBookQuantity='" + Convert.ToString(txtBookQuantity.Text) + "',@intBookPrice='" + (txtBookPrice.Text).ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                //dsObj = sGetDataset(strQry);
                //if (dsObj.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox("Record Already Exists");
                //    return;
                //}
                //else
                //{
                strQry = "exec [usp_BookDetails] @command='update',@intBookDetails_id='" + Convert.ToString(Session["BookDetailsID"])
                    + "',@intStandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim()
                    + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.Trim() + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.Trim()
                    + "',@intBook_Author_id='" + ddlBookAuthor.SelectedValue.Trim() + "',@intBookLanguage_id='"
                    + ddlSubject.SelectedValue.ToString() + "',@vchBookDetails_bookName='" + Convert.ToString(txtName.Text.Trim()) + "',@intBookPrice='" + (txtBookPrice.Text).ToString() + "',@vchAccessionNo='"
                    + (txtAccessionNo.Text).ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='"
                    + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"])
                    + "',@vchRackNo='" + txtRackNo.Text.ToString() + "',@vchRowNo='" + txtRowNo.Text.ToString() + "',@StatusId='" + ddlStatusId.SelectedValue.Trim() + "',@RemarkId='" + ddlRemark.SelectedValue.Trim() + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    clear();
                    ShowSuccessMessage("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
                // }
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            ShowErrorMessage();
        }
    }
    public void clear()
    {
        try
        {
            ddlStandard.ClearSelection();
            ddlBookCategory.ClearSelection();
            ddlBookEdition.ClearSelection();
            ddlBookPublication.ClearSelection();
            ddlBookAuthor.ClearSelection();
            ddlSubject.ClearSelection();
            txtName.Text = "";
            txtAccessionNo.Text = "";
            txtBookPrice.Text = "";
            txtRackNo.Text = "";
            txtRowNo.Text = "";
            ddlStatusId.ClearSelection();
            ddlStatusId.Enabled = true;
            getRemarks("Add");
            ddlRemark.ClearSelection();
            ddlRemark.Enabled = false;
            btnSubmit.Text = "Submit";
        }
        catch(Exception ex)
        {
            LogException(ex);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    public void MessageBox(string msg)
    {
        try
        {
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["BookDetailsID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_BookDetails] @command='delete',@intBookDetails_id='" + Convert.ToString(Session["BookDetailsID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                ShowSuccessMessage("Record Deleted Successfully!");
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["BookDetailsID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
             strQry = "";
             strQry = "exec usp_BookDetails @command='edit',@intBookDetails_id='" + Convert.ToString(Session["BookDetailsID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                ddlSubject.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookLanguage_id"]);
                ddlBookCategory.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intCategory_id"]);
                ddlBookEdition.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookEdition_id"]);
                ddlBookPublication.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBook_publication_id"]);
                ddlBookAuthor.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBook_Author_id"]);
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchBookDetails_bookName"]);
                txtAccessionNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAccessionNo"]);
                txtBookPrice.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookPrice"]);
                txtRackNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["RackNo"]);
                txtRowNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["RowNo"]);
                getBookStatus("Edit");
                ddlStatusId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["StatusId"]);
                if (ddlStatusId.SelectedValue != "1" && ddlStatusId.SelectedValue != "2")
                    ddlStatusId.Enabled = false;
                else
                    ddlStatusId.Enabled = true;
                getRemarks("Edit");
                ddlRemark.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Remark"]);
                if (ddlStatusId.SelectedValue == "1")
                    ddlRemark.Enabled = true;
                else
                    ddlRemark.Enabled = false;
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }
    protected void ddlDetStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        fGridFilterData();
    }
    protected void fGridFilterData()
    {
        try
        {
            strQry = "usp_BookDetails @command='fGridFilterData',@intStandard_id='" + ddlDetStandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                //txtName.Text = "";
                Session["BookDetailsTable"] = dsObj;
                Session["BookDetailsTableDummy"] = dsObj;
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                //txtName.Text = "";
                Session["BookDetailsTable"] = dsObj;
                Session["BookDetailsTableDummy"] = dsObj;
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }
    protected void ddlDetSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            strQry = "usp_BookDetails @command='fGridFilterData',@intStandard_id='" + ddlDetStandard.SelectedValue.Trim() + "',@intBookLanguage_id='" + ddlDetSubject.SelectedValue.ToString() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                //txtName.Text = "";
                Session["BookDetailsTable"] = dsObj;
                Session["BookDetailsTableDummy"] = dsObj;
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                //txtName.Text = "";
                Session["BookDetailsTable"] = dsObj;
                Session["BookDetailsTableDummy"] = dsObj;
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }
    protected void grvDetail_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDetail.PageIndex = e.NewPageIndex;
        fGrid();

    }

    protected void txtSearchAccession_TextChanged(object sender, EventArgs e)
    {
        fGridFilterDataByAcnNo();
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetSearchAccession(string prefixText)
    {
        List<string> GetSearchAccession = new List<string>();
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["esmsCentralModel"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select intbookDetails_id,vchAccessionNo from tblBookDetails where vchAccessionNo like @Name+'%' and bitActiveflg=1 and intschool_id = @intSchool_id", con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            cmd.Parameters.AddWithValue("@intSchool_id", Convert.ToString(HttpContext.Current.Session["School_id"]));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GetSearchAccession.Add(dt.Rows[i][1].ToString());
            }
            return GetSearchAccession;
        }
        catch (Exception ex)
        {
            LogException(ex);
            return GetSearchAccession;
        }

    }

    protected void fGridFilterDataByAcnNo()
    {

        try
        {
            strQry = "usp_BookDetails @command='fGridFilterDataByAcnNo',@vchAccessionNo='" + Convert.ToString(txtSearchAccession.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                //txtName.Text = "";
                Session["BookDetailsTable"] = dsObj;
                Session["BookDetailsTableDummy"] = dsObj;
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                //txtName.Text = "";
                Session["BookDetailsTable"] = dsObj;
                Session["BookDetailsTableDummy"] = dsObj;
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    public static string convertDataTableToJson(DataTable dt)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;
        try
        {
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
        return serializer.Serialize(rows);
    }

    protected void getRemarks(string mode)
    {
        strQry = "[usp_BookDetails] @command='getRemakrs', @mode = '"+ mode + "'";
        sBindDropDownList(ddlRemark, strQry, "Remark", "RemarkId");
    }

    protected void ddlDetSStatusId_SelectedIndexChanged(object sender, EventArgs e)
    {
        fGridFilterDataByStatus();
    }

    protected void getBookStatusInSearch()
    {
        strQry = "[usp_BookDetails] @command='getBookStatusForSearch'";
        sBindDropDownList(ddlSStatus, strQry, "Status", "StatusId");
    }

    protected void fGridFilterDataByStatus()
    {
        try
        {
            strQry = "usp_BookDetails @command='fGridFilterDataByStatus',@StatusId='" + ddlSStatus.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                //txtName.Text = "";
                Session["BookDetailsTable"] = dsObj;
                Session["BookDetailsTableDummy"] = dsObj;
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                //txtName.Text = "";
                Session["BookDetailsTable"] = dsObj;
                Session["BookDetailsTableDummy"] = dsObj;
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void ExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Session["BookDetailsTable"] = Session["BookDetailsTableDummy"];
            if (grvDetail.Rows.Count > 0)
                Response.Redirect("frmExcel.aspx");
            else
                MessageBox("No Records found!");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void myGV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgButton = (ImageButton)e.Row.FindControl("ImgDelete");
            if (e.Row.Cells[9].Text == "Mark for Deletion")
                imgButton.Visible = true;
            else
                imgButton.Visible = false;
        }
    }

    protected void addBookEdition(object sender, EventArgs e)
    {
        string strQry = "";
        DataSet dsObj = new DataSet();
        try
        {
            strQry = "usp_BookEdition @command='checkExist',@vchBookEdition_name='" + Convert.ToString(txtEdition.Text) + "',@intSchool_id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ShowErrorMessage("Book Edition Already Exists!");
            }
            else
            {
                strQry = "exec [usp_BookEdition] @command='insert',@vchBookEdition_name='" + Convert.ToString(txtEdition.Text) + "',@intSchool_id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "',@intInsertedBy='" + HttpContext.Current.Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fBookEdition();
                    string text = Convert.ToString(txtEdition.Text);
                    var item = ddlBookEdition.Items.FindByText(text);
                    if (item != null)
                    {
                        ddlBookEdition.ClearSelection();
                        item.Selected = true;
                    }
                    ShowSuccessMessage("Book Edition Added Successfully!");
                }
                else
                {
                    ShowErrorMessage("Something went wrong while saving book edition!");
                    
                }
                txtEdition.Text = "";
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            ShowErrorMessage("Something went wrong!");
            return;
        }
    }

    protected void addBookPublication(object sender, EventArgs e)
    {
        string strQry = "";
        DataSet dsObj = new DataSet();
        try
        {
            strQry = "usp_tblBookPublication_master @command='checkExist',@vchBook_publication_name='" + Convert.ToString(txtPublicationName.Text.Trim()) + "',@vchAddress='"
                + Convert.ToString(txtPublicationAddress.Text.Trim()) + "',@vchEmail='" + Convert.ToString(txtPublicationEmail.Text.Trim()) + "',@vchContact='" + Convert.ToString(txtPublicationMobileNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ShowErrorMessage("Book Publication Already Exists!");
            }
            else
            {
                strQry = "exec [usp_tblBookPublication_master] @command='insert',@vchBook_publication_name='" + Convert.ToString(txtPublicationName.Text.Trim())
                    + "',@vchAddress='" + Convert.ToString(txtPublicationAddress.Text.Trim()) + "',@vchEmail='" + Convert.ToString(txtPublicationEmail.Text.Trim()) + "',@vchContact='" + Convert.ToString(txtPublicationMobileNo.Text.Trim())
                    + "',@intSchool_id='" + Convert.ToString(HttpContext.Current.Session["School_id"])
                    + "',@intInsertedBy='" + HttpContext.Current.Session["User_id"] + "',@insertIP='" + GetSystemIP()
                    + "',@intAcademic_id='" + Convert.ToString(HttpContext.Current.Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fBookPublication();
                    string text = Convert.ToString(txtPublicationName.Text);
                    var item = ddlBookPublication.Items.FindByText(text);
                    if (item != null)
                    {
                        ddlBookPublication.ClearSelection();
                        item.Selected = true;
                    }
                    ShowSuccessMessage("Book publication added successfully");
                }
                else
                {
                    ShowErrorMessage("Something went wrong while saving book publication!");
                }
                txtPublicationName.Text = "";
                txtPublicationAddress.Text = "";
                txtPublicationEmail.Text = "";
                txtPublicationMobileNo.Text = "";
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            ShowErrorMessage("Something went wrong while saving book publication!");
            return;
        }
    }

    protected void addBookAuthor(object sender, EventArgs e)
    {
        string strQry = "";
        DataSet dsObj = new DataSet();
        try
        {
            strQry = "usp_tblBookAuthor_master @command='checkExist',@vchBook_Author_name='" + Convert.ToString(txtAuthorName.Text.Trim())
                + "',@vchAddress='" + Convert.ToString(txtAuthorAddress.Text.Trim()) + "',@vchEmail='" + Convert.ToString(txtAuthorEmail.Text.Trim()) + "',@vchContact='" + Convert.ToString(txtAuthorMobileNo.Text.Trim())
                + "',@intSchool_id='" + Convert.ToString(HttpContext.Current.Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ShowErrorMessage("Book Author Already Exists!");
                return ;
            }
            else
            {
                strQry = "exec [usp_tblBookAuthor_master] @command='insert',@vchBook_Author_name='" + Convert.ToString(txtAuthorName.Text.Trim())
                    + "',@vchAddress='" + Convert.ToString(txtAuthorAddress.Text.Trim()) + "',@vchEmail='" + Convert.ToString(txtAuthorEmail.Text.Trim())
                    + "',@vchContact='" + Convert.ToString(txtAuthorMobileNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(HttpContext.Current.Session["School_id"])
                    + "',@intInsertedBy='" + HttpContext.Current.Session["User_id"] + "',@insertIP='" + GetSystemIP()
                    + "',@intAcademic_id='" + Convert.ToString(HttpContext.Current.Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fBookAuthor();
                    string text = Convert.ToString(txtAuthorName.Text);
                    var item = ddlBookAuthor.Items.FindByText(text);
                    if (item != null)
                    {
                        ddlBookAuthor.ClearSelection();
                        item.Selected = true;
                    }
                    ShowSuccessMessage("Book author added successfully");
                }
                else
                {
                    ShowErrorMessage("Something went wrong while saving book author!");
                }
                txtAuthorName.Text = "";
                txtAuthorAddress.Text = "";
                txtAuthorEmail.Text = "";
                txtAuthorMobileNo.Text = "";
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            ShowErrorMessage("Something went wrong while saving book author!");
            return ;
        }
    }
}