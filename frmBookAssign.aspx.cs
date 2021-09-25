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
                getStandard();
                //getBook();
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
            strQry = "[usp_tblBookAssign] @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
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

    protected void getStandard()
    {
        try
        {
            string str1 = "[usp_tblBookAssign] @command='getStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlStandard, str1, "vchStandard_name", "intstandard_id");
            sBindDropDownList(ddlSstandard, str1, "vchStandard_name", "intstandard_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            ex.Message.ToString();
        }

    }
    protected void getDivision()
    {
        string str1 = "[usp_tblBookAssign] @command='getDivision',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        try
        {
            sBindDropDownList(ddlDivisionId, str1, "vchDivisionName", "intDivision_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }
    protected void getSerchDivision()
    {
        string str1 = "[usp_tblBookAssign] @command='getDivision',@intstandard_id='" + ddlSstandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        try
        {
            sBindDropDownList(ddlDdivision, str1, "vchDivisionName", "intDivision_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    protected void getStudent()
    {
        string str1 = "[usp_tblBookAssign] @command='getStudent',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        try
        {
            sBindDropDownList(ddlStudentId, str1, "Student_name", "intStudent_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }


    protected void getBook(string mode)
    {
        string str1 = "[usp_tblBookAssign] @command='getBook',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@mode='" + mode.ToString() + "'";
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
            ddlStandard.ClearSelection();
            ddlStandard.Enabled = true;
            ddlDivisionId.ClearSelection();
            ddlDivisionId.Enabled = true;
            ddlStudentId.ClearSelection();
            ddlStudentId.Enabled = true;
            ddlBookId.ClearSelection();
            ddlBookId.Enabled = true;
            txtAccession.Text = "";
            ddlStatus.ClearSelection();
            getStatus("Add");
            ddlStatus.Enabled = true;
            txtExpectedReturnedDate.Enabled = true;
            txtAssignDate.Enabled = true;
            txtAssignDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
            string value = getConfigurationValueByKeyName("ReturnInDays");
            value = (value == "" || value == "0") ? "7" : value;
            txtExpectedReturnedDate.Text = Convert.ToString(DateTime.Today.AddDays(Convert.ToInt32(value)).ToString("dd/MM/yyyy")).Replace("-", "/");

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
        if (ddlStandard.SelectedValue == "0")
        {
            ShowErrorMessage("Please select Standard!");
            ddlStandard.Focus();
            return;
        }
        if (ddlDivisionId.SelectedValue == "0")
        {
            ShowErrorMessage("Please Select Book Division!");
            ddlDivisionId.Focus();
            return;
        }
        if (ddlStudentId.SelectedValue == "0")
        {
            ShowErrorMessage("Please Select Book Student!");
            ddlStudentId.Focus();
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
                strQry = "usp_tblBookAssign @command='checkExist',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + txtAccession.Text.Trim() + "',@dtAssigned_Date='" + assdt + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ShowErrorMessage("Book Already Exists");
                    return;
                }
                else
                {
                    //strQry = "exec [usp_tblBookAssign] @command='insert',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "',@dtAssigned_Date='" + assdt + "',@dtReturn_date='" + retdt + "',@vchStatus='" + Convert.ToString(ddlStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                    strQry = "exec [usp_tblBookAssign] @command='insert',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@vchAccessionNo='" + txtAccession.Text.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "',@dtAssigned_Date='" + assdt + "',@dtExpectedReturned_Date='" + expectedReturneddate + "',@vchStatus='" + Convert.ToString(ddlStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "',@vchRemark='" + txtRemarks.Text.ToString() + "'";
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
                strQry = "exec [usp_tblBookAssign] @command='update',@intBook_assign_id='" + Convert.ToString(Session["BookAssignID"]) + "',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intStudent_id='" + ddlStudentId.SelectedValue.Trim() + "',@vchAccessionNo='" + txtAccession.Text.Trim() + "',@intBookDetails_id='" + ddlBookId.SelectedValue.Trim() + "',@dtAssigned_Date='" + assdt + "',@dtReturn_date='" + Returned_date + "',@vchStatus='" + Convert.ToString(ddlStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "',@vchRemark='" + txtRemarks.Text.ToString() + "'";
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
    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDivision();
        getBook("Add");
    }
    protected void ddlDivisionId_SelectedIndexChanged(object sender, EventArgs e)
    {
        getStudent();
    }
    protected void ddlBookId_SelectedIndexChanged(object sender, EventArgs e)
    {
        getAccessionNoByBookId();
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
            strQry = "exec usp_tblBookAssign @command='edit',@intBook_assign_id='" + Convert.ToString(Session["BookAssignID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                ddlStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                ddlStandard.Enabled = false;
                getDivision();
                getBook("Edit");
                ddlDivisionId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                ddlDivisionId.Enabled = false;
                getStudent();
                ddlStudentId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
                ddlStudentId.Enabled = false;
                ddlBookId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intBookDetails_id"]);
                ddlBookId.Enabled = false;
                txtAccession.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAccessionNo"]);
                txtAssignDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtAssigned_Date"]);
                txtAssignDate.Text = Convert.ToDateTime(txtAssignDate.Text).ToString("dd/MM/yyyy").Replace("-", "/");
                txtAssignDate.Enabled = false;
                txtReturnDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtReturn_date"]);
                txtReturnDate.Text = txtReturnDate.Text != "" ? Convert.ToDateTime(txtReturnDate.Text).ToString("dd/MM/yyyy").Replace("-", "/") : "";
                getStatus("Edit");
                txtExpectedReturnedDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["ExpectedReturnedDate"]);
                txtExpectedReturnedDate.Text = txtExpectedReturnedDate.Text != "" ? Convert.ToDateTime(txtExpectedReturnedDate.Text).ToString("dd/MM/yyyy").Replace("-", "/") : "";
                txtExpectedReturnedDate.Enabled = false;
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
            strQry = "[usp_tblBookAssign] @command='fSearchGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@vchAccessionNo='" + Convert.ToString(txtSearchAccession.Text.Trim()) + "'";
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
            SqlCommand cmd = new SqlCommand("select * from tblBookAssign where vchAccessionNo like @Name+'%'", con);
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
    protected void ddlSstandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        getSerchDivision();

    }
    protected void ddlDdivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        fSearchDivisionrid(); 
    }
    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedValue != "4")
            txtReturnDate.Enabled = false;
        else
            txtReturnDate.Enabled = true;
    }
    protected void fSearchDivisionrid()
    {
        try
        {
            strQry = "[usp_tblBookAssign] @command='fSearchDivisionrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDivision_id='" + Convert.ToString(ddlDdivision.SelectedValue.Trim()) + "'";
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
            else if(e.Row.Cells[7].Text == "Issued")
            {
                if(DateTime.Now.Date > Convert.ToDateTime(e.Row.Cells[5].Text))
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