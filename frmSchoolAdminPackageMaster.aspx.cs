using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSchoolAdminPackageMaster : DBUtility    
{
    string strQry = string.Empty;
    DataSet dsObj,ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTile = new Label();
        lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        lblTile.Visible = true;
        lblTile.Text = "Notification Package Master";
        if (!IsPostBack)
        {
            FillPackage();
            FillCurrency();
            FillGrid();
            chkActive_CheckedChanged(null, null);
        }
    }
    public void FillCurrency()
    {
        try
        {
            strQry = "";
            strQry = "exec [usp_FillDropDown] @type='Currency'";
            sBindDropDownList(ddlCurrency, strQry, "vchISO_CODE", "intCurrency_id");


        }
        catch (Exception)
        {

            throw;
        }
    }
    public void FillPackage()
    {
        try
        {
            strQry = "exec usp_SchoolPackageMaster @type='FillPackage',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlPackage, strQry, "vchPackage_name", "intPackageBuyId");
        }
        catch 
        {
            
        }
    }
    protected void ddlPackage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDetail();
        }
        catch 
        {
            
        }
    }
    public void FillDetail()
    {
        try
        {
            strQry = "exec usp_SchoolPackageMaster @type='FillPackageDetail',@intPackageid='" + Convert.ToString(ddlPackage.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtSms.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SMS"]);
                HSMS.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["SMS"]);
                txtNotification.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfNotification"]);
                HNotification.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfNotification"]);
                txtEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfEmails"]);
                HEmail.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["intNoOfEmails"]);
                txtSpace.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["fltDataSpace"]);
                Hdata.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["fltDataSpace"]);

               
            }
        }
        catch 
        {
            
        }
    }
    public void FillGrid()
    {
        try
        {
            strQry = "exec usp_SchoolPackageMaster  @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvPackage.DataSource = dsObj;
            grvPackage.DataBind();
        }
        catch 
        {
            
        }
    }
    public void clear()
    {
        txtAmt.Text = "";
        txtDesc.Text = "";
        txtEmail.Text = "0";
        txtFrmDate.Text = "";
        txtNotification.Text = "0";
        txtPackageNm.Text = "";
        txtSms.Text = "0";
        txtSpace.Text = "";
        txtToDate.Text = "";
        ddlCurrency.SelectedValue = "0";
        ddlPackage.SelectedValue = "0";
        ddlCurrency.Visible = false;
        txtAmt.Visible = false;
        chkActive.Checked = false;
        btnSubmit.Text = "Submit";
        lblCurrency.Visible = false;
        lblAmt.Visible = false;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (chkActive.Checked == true)
            {
                //if (ddlCurrency.SelectedValue == "0")
                //{
                //    MessageBox("Please Select Currency Name");
                //    return;
                //}
                if (txtAmt.Text == "")
                {
                    MessageBox("Please Enter The Amount");
                    return;
                }
            }


            if (btnSubmit.Text == "Submit")
            {
                strQry = string.Empty;
                strQry = "exec [usp_SchoolPackageMaster]  @type='CheckSaveExist',@vchPackage_name='" + Convert.ToString(txtPackageNm.Text).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Package Name Already Exist.");
                    return;
                }

                strQry = string.Empty;
                strQry = "exec usp_SchoolPackageMaster @type='Insert',@intPackageBuyId='" + Convert.ToString(ddlPackage.SelectedValue) + "',@vchPackage_name='" + Convert.ToString(txtPackageNm.Text) + "',@vchPackageDescription='" + Convert.ToString(txtDesc.Text) + "',@intNoOfSMS='" + Convert.ToString(txtSms.Text) + "',@intNoOfEmails='" + Convert.ToString(txtEmail.Text) + "',@intNoOfNotification='" + Convert.ToString(txtNotification.Text) + "',@fltDataSpace='" + Convert.ToString(txtSpace.Text) + "',@dtStartDate='" + Convert.ToDateTime(txtFrmDate.Text).ToString("MM-dd-yyyy") + "',@dtEndate='" + Convert.ToDateTime(txtToDate.Text).ToString("MM-dd-yyyy") + "',@vchActiveStatus='" + Convert.ToString(chkActive.Checked == true ? "Yes" : "No") + "',@intInsertedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";

                if (chkActive.Checked == true)
                {
                    strQry = strQry + ",@dtActivatedDate='" + (DateTime.Now.Date).ToString("MM/dd/yyyy") + "',@intCurrency_id='" + Convert.ToString(ddlCurrency.SelectedValue) + "',@flatAmount='" + Convert.ToString(txtAmt.Text) + "',@intActivatedBy='" + Convert.ToString(Session["User_Id"]) + "'";
                }
                else
                {
                    strQry = strQry + ",@intdeactivatedBy='" + Convert.ToString(Session["User_Id"]) + "'";
                }

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Succssefully");
                    clear();
                    FillGrid();
                }
                else
                {
                    MessageBox("Insertion Failed");
                }
            }
            else
            {
                strQry = string.Empty;
                strQry = "exec [usp_SchoolPackageMaster]  @type='CheckUpdateExist',@intSchoolPackage_id='" + ViewState["SchoolPackageId"].ToString() + "',@vchPackage_name='" + Convert.ToString(txtPackageNm.Text).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Package Name Already Exist.");
                    return;
                }

                strQry = string.Empty;
                strQry = "exec usp_SchoolPackageMaster @type='Update',@intSchoolPackage_id='" + ViewState["SchoolPackageId"].ToString() + "',@intPackageBuyId='" + Convert.ToString(ddlPackage.SelectedValue) + "',@vchPackage_name='" + Convert.ToString(txtPackageNm.Text) + "',@vchPackageDescription='" + Convert.ToString(txtDesc.Text) + "',@intNoOfSMS='" + Convert.ToString(txtSms.Text) + "',@intNoOfEmails='" + Convert.ToString(txtEmail.Text) + "',@intNoOfNotification='" + Convert.ToString(txtNotification.Text) + "',@fltDataSpace='" + Convert.ToString(txtSpace.Text) + "',@dtStartDate='" + Convert.ToDateTime(txtFrmDate.Text).ToString("MM-dd-yyyy") + "',@dtEndate='" + Convert.ToDateTime(txtToDate.Text).ToString("MM-dd-yyyy") + "',@vchActiveStatus='" + Convert.ToString(chkActive.Checked == true ? "Yes" : "No") + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";//,@intdeactivatedBy='""',@dtDiscontinueDate='""'";
                if (chkActive.Checked == false)
                {
                    strQry = strQry + ",@intdeactivatedBy='" + Convert.ToString(Session["User_Id"]) + "'";
                }
                else
                {
                    strQry = strQry + ",@flatAmount='" + Convert.ToString(txtAmt.Text) + "',@intActivatedBy='" + Convert.ToString(Session["UserId"]) + "',@dtActivatedDate='" + Convert.ToDateTime(DateTime.Now).ToString("MM-dd-yyyy HH:mm") + "'";
                }
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Succssefully");
                    btnSubmit.Text = "Submit";
                    FillGrid();
                    clear();

                }
            }
            // ActiveState();

        }
        catch
        {
            MessageBox("Insertion Failed");
        }
        finally
        {

            dsObj.Dispose();
        }
    }
    protected void txtSms_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void grvPackage_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            strQry = "exec usp_SchoolPackageMaster  @type='FillGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSchoolPackage_id='" + Convert.ToString((int)grvPackage.DataKeys[e.NewEditIndex].Value) + "'";

            ds = sGetDataset(strQry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPackage.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["intPackageBuyId"]);
                FillDetail();
                txtPackageNm.Text = Convert.ToString(ds.Tables[0].Rows[0]["vchPackage_name"]);
                txtDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["vchPackageDescription"]);
                txtSms.Text = Convert.ToString(ds.Tables[0].Rows[0]["intNoOfSMS"]);
                txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["intNoOfEmails"]);
                txtSpace.Text = Convert.ToString(ds.Tables[0].Rows[0]["fltDataSpace"]);
                txtNotification.Text = Convert.ToString(ds.Tables[0].Rows[0]["intNoOfNotification"]);
                txtAmt.Text = Convert.ToString(ds.Tables[0].Rows[0]["flatAmount"]);
                txtDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["vchPackageDescription"]);
                txtFrmDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dtStartDate"]).ToString("dd/MM/yyyy");
                txtToDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dtEndate"]).ToString("dd/MM/yyyy");
                chkActive.Checked = Convert.ToBoolean(Convert.ToString(ds.Tables[0].Rows[0]["vchActiveStatus"].ToString().Trim()=="Yes" ? true : false));
                ViewState["SchoolPackageId"] = Convert.ToString((int)grvPackage.DataKeys[e.NewEditIndex].Value);
                btnSubmit.Text = "Update";
                TabContainer1.ActiveTabIndex = 1;
            }
        }
        catch
        {
            MessageBox("Problem Found");
        }
    }
    protected void chkActive_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkActive.Checked == true)
            {
               // ddlCurrency.Visible = true;
                txtAmt.Visible = true;
               // lblCurrency.Visible = true;
                lblAmt.Visible = true;
            }
            else
            {
                ddlCurrency.Visible = false;
                txtAmt.Visible = false;
                lblCurrency.Visible = false;
                lblAmt.Visible = false;
            }
        }
        catch
        {

        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void grvPackage_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            strQry = "exec [usp_SchoolPackageMaster] @type='Delete',@intSchoolPackage_id='" + Convert.ToString((int)grvPackage.DataKeys[e.RowIndex].Value) + "',@intDeleteBy='" + Convert.ToString(Session["User_Id"]) + "',@vchDeletedIp='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Package Deleted Successfully!");
                FillGrid();
            }

        }
        catch
        {
            
        }
    }
}