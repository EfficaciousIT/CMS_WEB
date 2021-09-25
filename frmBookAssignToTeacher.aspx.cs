using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class frmBookAssign :DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                txtAssignDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
                string value = getConfigurationValueByKeyName("ReturnInDays");
                value = (value == "" || value == "0") ? "7" : value;
                txtExpectedReturnedDate.Text = Convert.ToString(DateTime.Today.AddDays(Convert.ToInt32(value)).ToString("dd/MM/yyyy")).Replace("-", "/");
                getDepartment();
                getCategory();
                getSubject();
                fGrid();
                getStatus("Add");
                txtReturnDate.Enabled = false;

            }
            catch (Exception ex)
            {
                LogException(ex);
            }
            //txtAssignDate.Text = Convert.ToDateTime(txtAssignDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            //txtReturnDate.Text = Convert.ToDateTime(txtReturnDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
            //txtAssignDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
            //txtReturnDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
        }
    }


    protected void fGrid()
    {
        try
        {
            strQry = "[usp_tblBookAssign] @command='SelectteacherSearchGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                clear();
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    protected void getDepartment()
    {
        try
        {
            string str1 = "[usp_tblBookAssign] @command='getDepartment',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlDepartment, str1, "vchDepartment_name", "intDepartment");
            sBindDropDownList(ddlSDeparment, str1, "vchDepartment_name", "intDepartment");
        }
        catch (Exception ex)
        {
            LogException(ex);
            ex.Message.ToString();
        }

    }
    protected void getDesignation()
    {
        string str1 = "[usp_tblBookAssign] @command='getDesignation',@intDepartment_id='" + ddlDepartment.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        try
        {
            sBindDropDownList(ddlDesignationId, str1, "vchDesignation", "intDesignation_Id");
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }
    protected void getSerchDesignation()
    {
        string str1 = "[usp_tblBookAssign] @command='getDesignation',@intDepartment_id='" + ddlSDeparment.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        try
        {
            sBindDropDownList(ddlSDesignation, str1, "vchDesignation", "intDesignation_Id");
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    protected void getSerchTeacher()
    {
        string str1 = "[usp_tblBookAssign] @command='getTeacher',@intDepartment_id='" + ddlSDeparment.SelectedValue.Trim() + "',@intDesignation_id='" + ddlSDesignation.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        try
        {
            sBindDropDownList(ddlSTeacher, str1, "Teacher_name", "intTeacher_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    protected void getTeacher()
    {
        string str1 = "[usp_tblBookAssign] @command='getTeacher',@intDepartment_id='" + ddlDepartment.SelectedValue.Trim() + "',@intDesignation_id='" + ddlDesignationId.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        try
        {
            sBindDropDownList(ddlTeacherId, str1, "Teacher_name", "intTeacher_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    protected void getCategory()
    {
        try
        {
            string str1 = "[usp_BookDetails] @command='BookCategory',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlCategory, str1, "vchCategory_name", "intCategory_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            ex.Message.ToString();
        }
    }

    protected void getSubject()
    {
        try
        {
            string str1 = "[usp_BookDetails] @command='BookSubject',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlSubject, str1, "vchBookLanguage_name", "intBookLanguage_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            ex.Message.ToString();
        }
    }

    protected void getBook(string mode)
    {
        string str1 = "[usp_tblBookAssign] @command='getBookBasedOnCategoeyAndSubject',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intCategory_Id='" + ddlCategory.SelectedValue.Trim() + "',@intSubject_Id='" + ddlSubject.SelectedValue.Trim() + "',@mode='" + mode.ToString() + "'";
        try
        {
            sBindDropDownList(ddlBookId, str1, "bookname", "intBookDetails_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    protected void getAccessionNoByBookId()
    {
        string str1 = "[usp_tblBookAssign] @command='getAccessionNoByBookId',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "'";
        try
        {
            dsObj = sGetDataset(str1);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtAccession.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["AccessionNo"]);
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    protected void getStatus(string mode)
    {
        try
        {
            string str1 = "[usp_tblBookAssign] @command='getStatus',@mode='" + mode.ToString() + "'";
            sBindDropDownList(ddlStatus, str1, "Status", "StatusId");
        }
        catch (Exception ex)
        {
            LogException(ex);
            ex.Message.ToString();
        }

    }


    public void clear()
    {
        try
        {
            btnSubmit.Text = "Submit";
            txtReturnDate.Text="";  
            ddlDepartment.ClearSelection();
            ddlDepartment.Enabled = true;
            ddlDesignationId.ClearSelection();
            ddlDesignationId.Enabled = true;
            ddlTeacherId.ClearSelection();
            ddlTeacherId.Enabled = true;
            ddlCategory.ClearSelection();
            ddlCategory.Enabled = true;
            ddlSubject.ClearSelection();
            ddlSubject.Enabled = true;
            ddlBookId.ClearSelection();
            ddlBookId.Enabled = true;
            txtAccession.Text = "";
            ddlStatus.ClearSelection();
            getStatus("Add");
            ddlStatus.Enabled = true;
            txtAssignDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
            string value = getConfigurationValueByKeyName("ReturnInDays");
            value = (value == "" || value == "0") ? "7" : value;
            txtExpectedReturnedDate.Text = Convert.ToString(DateTime.Today.AddDays(Convert.ToInt32(value)).ToString("dd/MM/yyyy")).Replace("-", "/");

            txtAssignDate.Enabled = true;
            txtExpectedReturnedDate.Enabled = true;

        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    //public void MessageBox(string msg)
    //{
    //    try
    //    {
    //        string script = "alert(\"" + msg + "\");";
    //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
    //    }
    //    catch (Exception)
    //    {
    //        // return msg;
    //    }
    //}
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlDepartment.SelectedValue == "0")
        {
            ShowErrorMessage("Please Select Department!");
            ddlDepartment.Focus();
            return;
        }
        if (ddlDesignationId.SelectedValue == "0")
        {
            ShowErrorMessage("Please Select Designation!");
            ddlDesignationId.Focus();
            return;
        }
        if (ddlTeacherId.SelectedValue == "0")
        {
            ShowErrorMessage("Please Select Teacher!");
            ddlTeacherId.Focus();
            return;
        }
        if (ddlCategory.SelectedValue == "0")
        {
            ShowErrorMessage("Please Select Category!");
            ddlCategory.Focus();
            return;
        }
        if (ddlSubject.SelectedValue == "0")
        {
            ShowErrorMessage("Please Select Subject!");
            ddlSubject.Focus();
            return;
        }
        if (ddlBookId.SelectedValue == "0")
        {
            ShowErrorMessage("Please select Book");
            ddlBookId.Focus();
            return;
        }

        if (ddlStatus.SelectedValue== "0")
        {
            ShowErrorMessage("Please Select Status!");
            ddlStatus.Focus();
            return;
        }

        if (txtAssignDate.Text == "")
        {
            ShowErrorMessage("Please Select Assign Date!");
            txtAssignDate.Focus();
            return;
        }

        if (txtExpectedReturnedDate.Text == "")
        {
            ShowErrorMessage("Please Select Expected Returned Date!");
            txtExpectedReturnedDate.Focus();
            return;
        }

        strQry = "";
        try
        {
            string assdt = Convert.ToDateTime(txtAssignDate.Text).ToString("MM/dd/yyyy"); // DateTime.ParseExact(txtFrmDt.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            string expectedReturneddate = Convert.ToDateTime(txtExpectedReturnedDate.Text).ToString("MM/dd/yyyy");
            if (btnSubmit.Text == "Submit")
            {
                //strQry = "usp_tblBookAssign @command='checkExist',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "',@dtAssigned_Date='" + assdt + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                strQry = "usp_tblBookAssign @command='checkExistForTeacher',@intTeacher_id='" + ddlTeacherId.SelectedValue.Trim() + "',@intBookDetails_id='" + txtAccession.Text.Trim() + "',@dtAssigned_Date='" + assdt + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ShowErrorMessage("Book Already Exists");
                    return;
                }
                else
                {
                    //strQry = "exec [usp_tblBookAssign] @command='insert',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "',@dtAssigned_Date='" + assdt + "',@dtReturn_date='" + retdt + "',@vchStatus='" + Convert.ToString(ddlStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                    strQry = "exec [usp_tblBookAssign] @command='insertTeacher',@intDepartment_id='" + ddlDepartment.SelectedValue.Trim() + "',@intDesignation_id='" + ddlDesignationId.SelectedValue.Trim() + "',@intTeacher_id='" + ddlTeacherId.SelectedValue.Trim() + "',@intCategory_Id='" + ddlCategory.SelectedValue.Trim() + "',@intSubject_Id='" + ddlSubject.SelectedValue.Trim() + "',@vchAccessionNo='" + txtAccession.Text.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "',@dtAssigned_Date='" + assdt + "',@dtExpectedReturned_Date='" + expectedReturneddate + "',@vchStatus='" + Convert.ToString(ddlStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "',@vchRemark='" + txtRemarks.Text.ToString() + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        fGrid();
                        ShowSuccessMessage("Book Assigned Successfully!");
                        clear();
                    }
                }
            }
            else
            {
                //strQry = "usp_tblBookAssign @command='checkExist',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "',@dtAssigned_Date='" + assdt + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                //dsObj = sGetDataset(strQry);
                //if (dsObj.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox("Record Already Exists");
                //    return;
                //}
                //else
                //{
                if (txtReturnDate.Text == "" && ddlStatus.SelectedValue == "4")
                {
                    ShowErrorMessage("Please Select Return Date!");
                    txtReturnDate.Focus();
                    return;
                }
                string Returned_date = ddlStatus.SelectedValue == "4" ? Convert.ToDateTime(txtReturnDate.Text).ToString("MM/dd/yyyy") : null;
                strQry = "exec [usp_tblBookAssign] @command='updateTeacher',@intTeacherBook_assign_id='" + Convert.ToString(Session["BookAssignID"]) 
                    + "',@intDepartment_id='" + ddlDepartment.SelectedValue.Trim() + "',@intDesignation_id='" 
                    + ddlDesignationId.SelectedValue.Trim() + "',@intTeacher_id='" + ddlTeacherId.SelectedValue.Trim() 
                    + "',@intCategory_Id='" + ddlCategory.SelectedValue.Trim() + "',@intSubject_Id='" + ddlSubject.SelectedValue.Trim() 
                    + "',@vchAccessionNo='" + txtAccession.Text.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() 
                    + "',@dtAssigned_Date='" + assdt + "',@dtReturn_date='" + Returned_date 
                    + "',@vchStatus='" + Convert.ToString(ddlStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) 
                    + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "',@vchRemark='" + txtRemarks.Text.ToString() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    clear();
                    ShowSuccessMessage("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
                //}
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
        
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDesignation();
    }
    protected void ddlDesignationId_SelectedIndexChanged(object sender, EventArgs e)
    {
        getTeacher();
    }
    protected void ddlBookId_SelectedIndexChanged(object sender, EventArgs e)
    {
        getAccessionNoByBookId();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        getBook("Add");
    }
    protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        getBook("Add");
    }


    protected void grvDetail_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["BookAssignID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblBookAssign] @command='delete',@intBook_assign_id='" + Convert.ToString(Session["BookAssignID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Record Deleted Successfully!");
            }
        }
        catch(Exception ex)
        {
            LogException(ex);
        }
    }
    protected void grvDetail_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["BookAssignID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblBookAssign @command='Teacheredit',@intTeacherBook_assign_id='" + Convert.ToString(Session["BookAssignID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                ddlDepartment.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartmentid"]);
                ddlDepartment.Enabled = false;
                getDesignation();
                ddlDesignationId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intDesignation_id"]);
                ddlDesignationId.Enabled = false;
                getTeacher();
                ddlTeacherId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intTeacher_id"]);
                ddlTeacherId.Enabled = false;
                ddlCategory.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["BookCategory"]);
                ddlCategory.Enabled = false;
                ddlSubject.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["BookSubject"]);
                ddlSubject.Enabled = false;
                getBook("Edit");
                ddlBookId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookDetails_id"]);
                ddlBookId.Enabled = false;
                txtAccession.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAccessionNo"]);
                txtAssignDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtAssigned_Date"]);
                txtAssignDate.Text = Convert.ToDateTime(txtAssignDate.Text).ToString("dd/MM/yyyy").Replace("-", "/");
                txtAssignDate.Enabled = false;
                txtReturnDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtReturn_date"]);
                txtReturnDate.Text = txtReturnDate.Text != "" ? Convert.ToDateTime(txtReturnDate.Text).ToString("dd/MM/yyyy").Replace("-", "/") : "";
                txtExpectedReturnedDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["ExpectedReturnedDate"]);
                txtExpectedReturnedDate.Text = txtExpectedReturnedDate.Text != "" ? Convert.ToDateTime(txtExpectedReturnedDate.Text).ToString("dd/MM/yyyy").Replace("-", "/") : "";
                txtExpectedReturnedDate.Enabled = false;
                getStatus("Edit");
                ddlStatus.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStatus"]);
                if (ddlStatus.SelectedValue == "4" || ddlStatus.SelectedValue == "5" || ddlStatus.SelectedValue == "6")
                    ddlStatus.Enabled = false;
                else
                    ddlStatus.Enabled = true;

                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch(Exception ex)
        {
            LogException(ex);
        }
    }

    protected void txtSearchAccession_TextChanged(object sender, EventArgs e)
    {
        fSearchGrid();
    }
    protected void fSearchGrid()
    {
        try
        {
            strQry = "[usp_tblBookAssign] @command='teacherSearchGridByAccessionNo',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@vchAccessionNo='" + Convert.ToString(txtSearchAccession.Text.Trim()) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                clear();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                clear();
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
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
            SqlCommand cmd = new SqlCommand("select * from tblTeacherBookAssign where vchAccessionNo like @Name+'%'", con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GetSearchAccession.Add(dt.Rows[i][4].ToString());
            }
            return GetSearchAccession;
        }
        catch (Exception ex)
        {
            LogException(ex);
            return GetSearchAccession;
        }

    }
    protected void ddlSDeparment_SelectedIndexChanged(object sender, EventArgs e)
    {
        getSerchDesignation();
        fSearchByDeptOrDesgnOrTeacher();
    }
    protected void ddlSDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        getSerchTeacher();
        fSearchByDeptOrDesgnOrTeacher();
    }
    protected void ddlSTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        fSearchByDeptOrDesgnOrTeacher();
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedValue != "4")
            txtReturnDate.Enabled = false;
        else
            txtReturnDate.Enabled = true;
    }
    protected void fSearchByDeptOrDesgnOrTeacher()
    {
        try
        {
            strQry = "[usp_tblBookAssign] @command='teacherSearchGridByDeptOrDesgOrTeacher',@intSchool_id='" + Convert.ToString(Session["School_id"]) 
                + "',@intDepartment_id='" + Convert.ToString(ddlSDeparment.SelectedValue.Trim()) 
                + "',@intDesignation_id='" + Convert.ToString(ddlSDesignation.SelectedValue.Trim())
                + "',@intTeacher_id='" + Convert.ToString(ddlSTeacher.SelectedValue.Trim())
                + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                clear();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                clear();
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
        }

    }

    protected void myGV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[7].Text == "Returned")
                e.Row.Cells[8].CssClass = "graydot";
            else if (e.Row.Cells[7].Text == "Issued")
            {
                if (DateTime.Now.Date > Convert.ToDateTime(e.Row.Cells[5].Text))
                    e.Row.Cells[8].CssClass = "reddot";
                else if (DateTime.Now.Date == Convert.ToDateTime(e.Row.Cells[5].Text))
                    e.Row.Cells[8].CssClass = "orangedot";
                else if (DateTime.Now.Date < Convert.ToDateTime(e.Row.Cells[5].Text))
                    e.Row.Cells[8].CssClass = "greendot";
            }
            else if (e.Row.Cells[7].Text == "Lost")
                e.Row.Cells[8].CssClass = "browndot";
            else
                e.Row.Cells[8].CssClass = "whitedot";
        }
    }


    protected string getConfigurationValueByKeyName(string key_Name)
    {
        try
        {
            string value = string.Empty;
            string str1 = "[usp_tblBookAssign] @command='getConfigurationValueByKeyName',@vchKey_Name='" + key_Name.ToString() + "'";
            dsObj = sGetDataset(str1);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                value = Convert.ToString(dsObj.Tables[0].Rows[0]["Value"]);
            }
            return value;
        }
        catch (Exception ex)
        {
            LogException(ex);
            return ex.Message.ToString();
        }
    }
}