using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class HostelFeeCollection : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strMonth = string.Empty;
    string strHead_id = string.Empty;
    int k = 0;
    string strLateStatus = string.Empty;
    string strMaxID = string.Empty;
    string strAmount = string.Empty;
    string strLateAmount = string.Empty;
    string strFeeType = string.Empty;
    bool boolFlag = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSTD();
            txtDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
            txtChequeDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
            drpPayMode.SelectedValue = "1";
        }
    }
    public void FillSTD()
    {
        try
        {
            //if (Convert.ToString(Session["UserType_Id"]) == "3")
            //{
            //strQry = "exec [usp_getAttendance] @type='FillStd',@TeacherId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
            strQry = "exec [usp_HostelFeeCollection] @type='FillStd',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intstandard_id");
            //  FillDIV();
            //}
            //else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            //{
            //    strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
            //    sBindDropDownList(drpSatndard, strQry, "vchStandard_name", "intstandard_id");
            //    FillDIV();
            //}

        }
        catch
        {

        }
    }
    public void FillDIV()
    {
        try
        {
            strQry = "exec usp_HostelFeeCollection @type='FillDiv',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(drpDivision, strQry, "vchDivisionName", "intDivision_id");
            // FillStudent();
        }
        catch
        {

        }
    }
    public void FillStudent()
    {
        try
        {
            strQry = "exec usp_HostelFeeCollection @type='GetStudents',@intDivision_id='" + Convert.ToString(drpDivision.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(drpStudent, strQry, "Name", "intStudent_id");

            //if (drpStudent.Items.Count > 1)
            //    drpStudent.Items.Add(new ListItem("All", "-1"));
            //else
            //    drpStudent.DataSource = null;
        }
        catch
        {

        }
    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();
    }
    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStudent();
    }
    protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (drpType.SelectedValue == "1")
         {
             //strQry = "usp_HostelFeeCollection @type='GetFeeAmount',@TotalMonth='12',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intstudent_id='" + Convert.ToString(drpStudent.SelectedValue) + "'";
             strQry = "usp_HostelFeeCollection @type='GetFeeAmount',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();

                ViewState["dt"] = dsObj;
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                ViewState["dt"] = dsObj;
            }

            ////strQry = "usp_HostelFeeCollection @command='TotalSumAnnulay',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "'";
            //strQry = "usp_HostelFeeCollection @type='TotalSumAnnulay',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            ViewState["dt"] = dsObj;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtTotalDues.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["FeeAmt"]);
              //  txtpaidAmount.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["FeeAmt"]);

            }
            strQry = "usp_HostelFeeCollection @type='TotalPaidAmount',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstudent_id='" + Convert.ToString(drpStudent.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                // txtTotalDues.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["FeeAmt"]);
                txtpaidAmount.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numPaidAmount"]);
            }
         }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (drpType.SelectedValue == "1")
        {
            if (txtLateAmount.Text != "")
            {
                strLateStatus = "1";
                strLateAmount = txtLateAmount.Text;
            }
            else
            {
                strLateStatus = "0";
                strLateAmount = "0";
            }

            string str = string.Empty;
            string strname = string.Empty;

          //  strQry = "usp_feeCollectionNew @command='InsertFeeMst',@intAmount=" + txtpaidAmount.Text.Trim() + ",@intMonth='0',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@PayMode='" + drpPayMode.SelectedValue.Trim() + "',@ChequeNo='" + txtChequeNo.Text.Trim() + "',@chequeDate='" + Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy") + "',@BankName='" + txtBankName.Text.Trim() + "',@LateStatus='" + strLateStatus.Trim() + "',@intLateAmount=" + strLateAmount.Trim() + ",@FullPayment='1',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            strQry = "usp_HostelFeeCollection @type='InsertFeeMst',@intAmount=" + txtpaidAmount.Text.Trim() + ",@intMonth='0',@intstudent_id='" + Convert.ToString(drpStudent.SelectedValue) + "',@intStandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@PayMode='" + drpPayMode.SelectedValue.Trim() + "',@ChequeNo='" + txtChequeNo.Text.Trim() + "',@chequeDate='" + Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy") + "',@BankName='" + txtBankName.Text.Trim() + "',@LateStatus='" + strLateStatus.Trim() + "',@intLateAmount=" + strLateAmount.Trim() + ",@FullPayment='1',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Convert.ToString(Session["User_Id"]) + "',@Inserted_IP='" + GetSystemIP() + "'";
             k = sExecuteQuery(strQry);
            if (k > 0)
            {
                //MessageBox("Fee Accepted");
                //return;
                ScriptManager.RegisterStartupScript(this, GetType(), "Success", "alert('Fee Accepted');window.location.reload(true);", true);
            }
        }       
    }
    protected void drpStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpType.ClearSelection();
        txtTotalDues.Text = "";
        txtpaidAmount.Text = "";
    }
    protected void drpPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpPayMode.SelectedValue == "2")
        {
            chequeTbl.Visible = true;
        }
        else
        {
            chequeTbl.Visible = false;
        }
    }
}