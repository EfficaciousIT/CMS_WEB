using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmDownloadApp : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    string UploadedPath="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType_Id"] != null && Session["User_Id"] != null)
        {
            Label lblTile = new Label();
            lblTile = (Label)Page.Master.FindControl("lblPageTitle");
            lblTile.Visible = true;
            lblTile.Text = "Application Detail";
        if (!IsPostBack)
        {
            
               
                FillGrid();
                FillSelfDetails();
                geturl();
            }
           
        }
        else
        {
            Response.Redirect("~\\frmIndex.aspx", false);
        }
    }


    public void FillAllUsers()
    {
        try
        {
            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                TabContainer1.Tabs[2].Visible = true;

                grvTeacher.DataSource = CreateTeacherDetail();
                grvTeacher.DataBind();

                grvParent.DataSource = CreateParentDetail();
                grvParent.DataBind();

                grvStud.DataSource = CreateStudDetail();
                grvStud.DataBind();
            }
            else
            {
                TabContainer1.Tabs[2].Visible = false;
            }
        }
        catch 
        {
            
        }
    }
    

    public DataSet CreateTeacherDetail()
    {
        try
        {
            strQry = "exec usp_Download_Details @type='Teacher',@FromDate='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@ToDate='" + Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy") + "',@intSchool='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            return dsObj;
        }
        catch
        {

            return dsObj;
        }
    }

    public void FillSelfDetails()
    {
        try
        {
            strQry = "";
            if (Convert.ToString(Session["UserType_Id"]) == "1")
            {
                strQry = "exec usp_Download_Details  @type='Student',@intSchool='" + Session["School_id"] + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "'";
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "2")
            {
                strQry = "exec usp_Download_Details  @type='Parent',@intSchool='" + Session["School_id"] + "',@intUser_id='"+ Convert.ToString(Session["User_Id"]) +"'";
            }
            else if (Convert.ToString(Session["UserType_Id"]) == "3" || Convert.ToString(Session["UserType_Id"]) == "4")
            {
                strQry = "exec usp_Download_Details @type='Teacher',@intSchool='" + Session["School_id"] + "',@intUser_id='" + Convert.ToString(Session["User_Id"]) + "'";
            }

            if (strQry != "")
            {
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grvDownloadApp.DataSource = dsObj;
                    grvDownloadApp.DataBind();
                }
            }
            
        }
        catch 
        {
            
        }
    }

    public DataSet CreateStudDetail()
    {
        try
        {

            strQry = "exec usp_Download_Details  @type='Student',@FromDate='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@ToDate='" + Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy") + "',@intSchool='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            return dsObj;
        }
        catch
        {
            return dsObj;

        }
    }
    public DataSet CreateParentDetail()
    {
        try
        {

            strQry = "exec usp_Download_Details  @type='Parent',@FromDate='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@ToDate='" + Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy") + "',@intSchool='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            return dsObj;
        }
        catch
        {
            return dsObj;

        }
    }
    public void Clear()
    {
        txtAppNm.Text="";
        txtFrmDt.Text = "";
        txtPlatForm.Text = "";
        txtReleaseDt.Text = "";
        txtToDt.Text = "";
        txtVer.Text = "";
        btnSave.Text = "Submit";

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (Session["FileUpload"] == null)
            {
                MessageBox("Please Upload The App");
                return;
            }


           // string Filename = FileUploadApp.PostedFile.FileName;
            string FileSize="";
            if(FileUploadApp.HasFile)
                FileSize = Convert.ToString(FileUploadApp.PostedFile.ContentLength);

           // string UploadedPath = System.IO.Path.GetFullPath(FileUploadApp.PostedFile.FileName);
            if (btnSave.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_tblApplicationMst @type='CheckExist',@vchApplication_name='" + Convert.ToString(txtAppNm.Text).Trim() + "',@intSchool_id='" + Session["School_id"] + "'";
                dsObj = new DataSet();
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist!");
                    return;
                }

                strQry = "";
                strQry = "exec usp_tblApplicationMst @type='Insert',@vchApplication_name='" + Convert.ToString(txtAppNm.Text.Replace("'", "")) + "',@vchDownloadPath='" + Session["FileUpload"] + "',@vchVersion='" + Convert.ToString(txtVer.Text) + "',@vchPlatform='" + Convert.ToString(txtPlatForm.Text) + "',@dtReleaseDate='" + Convert.ToDateTime(txtReleaseDt.Text).ToString("MM/dd/yyyy") + "',@fltApplicationSize='" + Session["FileSize"] + "',@InsertedBy='" + Convert.ToString(Session["User_Id"]) + "',@InsertedIP='" + GetSystemIP() + "',@intSchool_id='" + Session["School_id"] + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    FillGrid();
                    Clear();
                    return;
                }
            }
            else if (btnSave.Text == "Update")
            {
                strQry = "";
                strQry = "exec usp_tblApplicationMst @type='CheckUpdateExist',@vchApplication_name='" + Convert.ToString(txtAppNm.Text).Trim() + "',@intApplication_id='" + ViewState["AppId"] + "',@intSchool_id='" + Session["School_id"] + "'";
                dsObj = new DataSet();
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist!");
                    return;
                }

                strQry = "";
                strQry = "exec usp_tblApplicationMst @type='Update',@vchApplication_name='" + Convert.ToString(txtAppNm.Text.Replace("'", "")) + "',@vchDownloadPath='" + Session["FileUpload"] + "',@vchVersion='" + Convert.ToString(txtVer.Text) + "',@vchPlatform='" + Convert.ToString(txtPlatForm.Text) + "',@dtReleaseDate='" + Convert.ToDateTime(txtReleaseDt.Text).ToString("MM/dd/yyyy") + "',@intUpdatedBy='" + Convert.ToString(Session["UserId"]) + "',@vchUpdatdIp='" + GetSystemIP() + "',@intApplication_id='" + ViewState["AppId"] + "',@fltApplicationSize='" + Session["FileSize"] + "',@intSchool_id='" + Session["School_id"] + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    FillGrid();
                    Clear();
                    return;
                }
            }
            Session["FileUpload"] = null;
            FillGrid();

        }
        catch 
        {
            
        }
    }

    public void FillGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_tblApplicationMst] @type='FillGrid',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDownloadDetails.DataSource = dsObj;
                grvDownloadDetails.DataBind();
            }

            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {
                TabContainer1.Tabs[0].Visible = true;
                TabContainer1.Tabs[1].Visible = true;
                TabContainer1.Tabs[2].Visible = true;
            }
            else
            {

                TabContainer1.Tabs[0].Visible = true;
                TabContainer1.Tabs[1].Visible = false;
                TabContainer1.Tabs[2].Visible = false;
                grvDownloadDetails.Columns[1].Visible = false;
                grvDownloadDetails.Columns[2].Visible = false;

            }
        }
        catch 
        {
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
    protected void grvDownloadDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int AppId = (int)grvDownloadDetails.DataKeys[e.NewEditIndex].Value;
            ViewState["AppId"] = AppId;
            strQry = "";
            strQry = "exec [usp_tblApplicationMst] @type='FillGrid',@intApplication_id='" + AppId + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtAppNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchApplication_name"]);
                txtVer.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchVersion"]);
                txtPlatForm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPlatform"]);
                txtReleaseDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtReleaseDate"]);
               // txt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtUploadDate"]);
                txtAppNm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchApplication_name"]);
                btnSave.Text = "Update";
                TabContainer1.ActiveTabIndex = 0; 
            }
        }
        catch
        {
            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void grvDownloadDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int AppId = (int)grvDownloadDetails.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec [usp_tblApplicationMst] @type='Delete',@intApplication_id='" + AppId + "',@intSchool_id='" + Session["School_id"] + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                FillGrid();
            }
        }
        catch 
        {
            
        }
    }
    protected void txtToDt_TextChanged(object sender, EventArgs e)
    {
        try
        {
            FillAllUsers();
        }
        catch 
        {
            
        }
    }
    protected void FileUploadApp_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        UploadedPath=System.IO.Path.GetFullPath(FileUploadApp.FileName);
        Session["FileUpload"] = System.IO.Path.GetFullPath(FileUploadApp.FileName);
        Session["FileSize"] = FileUploadApp.PostedFile.ContentLength;
    }
    protected void txtFrmDt_TextChanged(object sender, EventArgs e)
    {
        FillAllUsers();
    }
}