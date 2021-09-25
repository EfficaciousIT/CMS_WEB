using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class frmFeeCol : DBUtility
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
            txtDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
            txtChequeDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
            drpPayMode.SelectedValue = "1";
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

            strQry = "usp_feeCollectionNew @command='InsertFeeMst',@intAmount=" + txtpaidAmount.Text.Trim() + ",@intMonth='0',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@PayMode='" + drpPayMode.SelectedValue.Trim() + "',@ChequeNo='" + txtChequeNo.Text.Trim() + "',@chequeDate='" + Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy") + "',@BankName='" + txtBankName.Text.Trim() + "',@LateStatus='" + strLateStatus.Trim() + "',@intLateAmount=" + strLateAmount.Trim() + ",@FullPayment='1',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";

            k = sExecuteQuery(strQry);
            if (k > 0)
            {
                strQry = "usp_feeCollectionNew @command='maxID'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    strMaxID = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                }
                for (int i = 1; i <= 12; i++)
                {
                    strMonth = Convert.ToString(i);                    

                    foreach (GridViewRow row in grvDetail.Rows)
                    {
                        strHead_id = ((Label)row.FindControl("lblId")).Text;
                        strFeeType = ((Label)row.FindControl("lblfeetype")).Text;

                        if (strMonth == "1")
                        {
                            if (strFeeType == "2")
                            {
                                strAmount = Convert.ToString(Convert.ToInt32(((Label)row.FindControl("lblAmount")).Text) / 12);
                                strQry = "usp_feeCollectionNew @command='InsertFee',@intFeeHeadID='" + strHead_id.Trim() + "',@intAmount='" + strAmount.Trim() + "',@intMonth='" + strMonth.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intStandard_id='" + Convert.ToString(Session["studentStandard"]) + "',@intMainlID='" + strMaxID.Trim() + "'";
                                k = sExecuteQuery(strQry);
                            }
                            else
                            {
                                strAmount = Convert.ToString(Convert.ToInt32(((Label)row.FindControl("lblAmount")).Text));
                                strQry = "usp_feeCollectionNew @command='InsertFee',@intFeeHeadID='" + strHead_id.Trim() + "',@intAmount='" + strAmount.Trim() + "',@intMonth='" + strMonth.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intStandard_id='" + Convert.ToString(Session["studentStandard"]) + "',@intMainlID='" + strMaxID.Trim() + "'";
                                k = sExecuteQuery(strQry);
                            }
                        }
                        else
                        {
                            if (strFeeType == "2")
                            {
                                strAmount = Convert.ToString(Convert.ToInt32(((Label)row.FindControl("lblAmount")).Text) / 12);
                                strQry = "usp_feeCollectionNew @command='InsertFee',@intFeeHeadID='" + strHead_id.Trim() + "',@intAmount='" + strAmount.Trim() + "',@intMonth='" + strMonth.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intStandard_id='" + Convert.ToString(Session["studentStandard"]) + "',@intMainlID='" + strMaxID.Trim() + "'";
                                k = sExecuteQuery(strQry);
                            }
                        }
                    }
                }                
            }

        }
        else if (drpType.SelectedValue == "3")
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

            strQry = "usp_feeCollectionNew @command='InsertFeeMst',@intAmount=" + txtpaidAmount.Text.Trim() + ",@intMonth='0',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@PayMode='" + drpPayMode.SelectedValue.Trim() + "',@ChequeNo='" + txtChequeNo.Text.Trim() + "',@chequeDate='" + Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy") + "',@BankName='" + txtBankName.Text.Trim() + "',@LateStatus='" + strLateStatus.Trim() + "',@intLateAmount=" + strLateAmount.Trim() + ",@FullPayment='1',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";

            k = sExecuteQuery(strQry);
            if (k > 0)
            {
                strQry = "usp_feeCollectionNew @command='maxID'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    strMaxID = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                }

                for (int i = Convert.ToInt32(drpFromMonth.SelectedValue); i <= Convert.ToInt32(drpToMonth.SelectedValue); i++)
                {
                    strMonth = Convert.ToString(i);                                        

                    foreach (GridViewRow rownew in grvDetail.Rows)
                    {
                        strHead_id = ((Label)rownew.FindControl("lblId")).Text;
                        strFeeType = ((Label)rownew.FindControl("lblfeetype")).Text;

                        if (strMonth == "1")
                        {
                            if (strFeeType == "2")
                            {
                                strAmount = Convert.ToString(Convert.ToInt32(((Label)rownew.FindControl("lblAmount")).Text) / Convert.ToInt32(ViewState["intMonth"]));
                                strQry = "usp_feeCollectionNew @command='InsertFee',@intFeeHeadID='" + strHead_id.Trim() + "',@intAmount='" + strAmount.Trim() + "',@intMonth='" + strMonth.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intStandard_id='" + Convert.ToString(Session["studentStandard"]) + "',@intMainlID='" + strMaxID.Trim() + "'";
                                k = sExecuteQuery(strQry);
                            }
                            else
                            {
                                strAmount = Convert.ToString(Convert.ToInt32(((Label)rownew.FindControl("lblAmount")).Text));
                                strQry = "usp_feeCollectionNew @command='InsertFee',@intFeeHeadID='" + strHead_id.Trim() + "',@intAmount='" + strAmount.Trim() + "',@intMonth='" + strMonth.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intStandard_id='" + Convert.ToString(Session["studentStandard"]) + "',@intMainlID='" + strMaxID.Trim() + "'";
                                k = sExecuteQuery(strQry);
                            }
                        }
                        else
                        {
                            if (strFeeType == "2")
                            {
                                strAmount = Convert.ToString(Convert.ToInt32(((Label)rownew.FindControl("lblAmount")).Text) / Convert.ToInt32(ViewState["intMonth"]));
                                strQry = "usp_feeCollectionNew @command='InsertFee',@intFeeHeadID='" + strHead_id.Trim() + "',@intAmount='" + strAmount.Trim() + "',@intMonth='" + strMonth.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intStandard_id='" + Convert.ToString(Session["studentStandard"]) + "',@intMainlID='" + strMaxID.Trim() + "'";
                                k = sExecuteQuery(strQry);
                            }
                        }
                    }
                }
                
            }
        }
        else
        {
            strMonth = Convert.ToString(drpFromMonth.SelectedValue);

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

            strQry = "usp_feeCollectionNew @command='InsertFeeMst',@intAmount=" + txtpaidAmount.Text.Trim() + ",@intMonth='0',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@PayMode='" + drpPayMode.SelectedValue.Trim() + "',@ChequeNo='" + txtChequeNo.Text.Trim() + "',@chequeDate='" + Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy") + "',@BankName='" + txtBankName.Text.Trim() + "',@LateStatus='" + strLateStatus.Trim() + "',@intLateAmount=" + strLateAmount.Trim() + ",@FullPayment='1',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";

            k = sExecuteQuery(strQry);
            if (k > 0)
            {
                strQry = "usp_feeCollectionNew @command='maxID'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    strMaxID = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                }               

                foreach (GridViewRow rownew in grvDetail.Rows)
                {
                    strHead_id = ((Label)rownew.FindControl("lblId")).Text;
                    strFeeType = ((Label)rownew.FindControl("lblfeetype")).Text;

                    if (strMonth == "1")
                    {
                        if (strFeeType == "2")
                        {
                            strAmount = Convert.ToString(Convert.ToInt32(((Label)rownew.FindControl("lblAmount")).Text) / Convert.ToInt32("1"));
                            strQry = "usp_feeCollectionNew @command='InsertFee',@intFeeHeadID='" + strHead_id.Trim() + "',@intAmount='" + strAmount.Trim() + "',@intMonth='" + strMonth.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intStandard_id='" + Convert.ToString(Session["studentStandard"]) + "',@intMainlID='" + strMaxID.Trim() + "'";
                            k = sExecuteQuery(strQry);
                        }
                        else
                        {
                            strAmount = Convert.ToString(Convert.ToInt32(((Label)rownew.FindControl("lblAmount")).Text));
                            strQry = "usp_feeCollectionNew @command='InsertFee',@intFeeHeadID='" + strHead_id.Trim() + "',@intAmount='" + strAmount.Trim() + "',@intMonth='" + strMonth.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intStandard_id='" + Convert.ToString(Session["studentStandard"]) + "',@intMainlID='" + strMaxID.Trim() + "'";
                            k = sExecuteQuery(strQry);
                        }
                    }
                    else
                    {
                        if (strFeeType == "2")
                        {
                            strAmount = Convert.ToString(Convert.ToInt32(((Label)rownew.FindControl("lblAmount")).Text) / Convert.ToInt32("1"));
                            strQry = "usp_feeCollectionNew @command='InsertFee',@intFeeHeadID='" + strHead_id.Trim() + "',@intAmount='" + strAmount.Trim() + "',@intMonth='" + strMonth.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "',@intStandard_id='" + Convert.ToString(Session["studentStandard"]) + "',@intMainlID='" + strMaxID.Trim() + "'";
                            k = sExecuteQuery(strQry);
                        }
                    }
                }

            }
        }
        if (k > 0)
        {
            MessageBox("Fee Accepted");
        }
        
               
        
    }
    protected void txtAdmission_TextChanged(object sender, EventArgs e)
    {
        strQry = "usp_feeCollectionNew @command='selectApplication',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAddmission_id='" + txtAdmission.Text.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            Session["studentPayId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intstudent_id"]);
            Session["studentStandard"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
            txtStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStandard_name"]);
            txtSearch.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchstudentfirst_name"]);

            //sBindDropDownList(drpFromMonth, strQry, "MonthName", "MonthNo");
        }
        else
        {
            txtStandard.Text = "";
            txtSearch.Text = "";
            MessageBox("Application does not exists");
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
    protected void drpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpType.SelectedValue == "3")
        {
            //MultiInstallment.Visible = true;
            lblTo.Visible = true;
            drpToMonth.Visible = true;

            strQry = "";
            strQry = "exec usp_feeCollectionNew @command='findMonth',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpFromMonth.DataTextField = "MonthName";
                drpFromMonth.DataValueField = "MonthNo";
                drpFromMonth.DataSource = dsObj;
                drpFromMonth.DataBind();
            }

            strQry = "";
            strQry = "exec usp_feeCollectionNew @command='findMonthBetween',@MonthNo='" + Convert.ToString(drpFromMonth.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpToMonth.DataTextField = "MonthName";
                drpToMonth.DataValueField = "MonthNo";
                drpToMonth.DataSource = dsObj;
                drpToMonth.DataBind();
                drpToMonth.Items.Insert(0, "---Select---");
            }

        }
        else if (drpType.SelectedValue == "1")
        {
            strQry = "usp_feeCollectionNew @command='GetFeeAmount',@TotalMonth='12',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }

            strQry = "usp_feeCollectionNew @command='TotalSumAnnulay',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtTotalDues.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);

            }
            
        }
        else
        {
            //MultiInstallment.Visible = false;
            lblTo.Visible = false;
            drpToMonth.Visible = false;

            strQry = "";
            strQry = "exec usp_feeCollectionNew @command='findMonth',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpFromMonth.DataTextField = "MonthName";
                drpFromMonth.DataValueField = "MonthNo";
                drpFromMonth.DataSource = dsObj;
                drpFromMonth.DataBind();
            }

            strQry = "usp_feeCollectionNew @command='GetFeeAmountNew',@TotalMonth='1',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }

            strQry = "usp_feeCollectionNew @command='TotalSumMonth',@TotalMonth='1',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtTotalDues.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);

            }
        }        
    }
    protected void drpToMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intMonth = Convert.ToInt32(drpToMonth.SelectedValue) - Convert.ToInt32(drpFromMonth.SelectedValue);

        ViewState["intMonth"] = intMonth + 1;

        strQry = "usp_feeCollectionNew @command='GetFeeAmountNew',@TotalMonth='" + Convert.ToString(intMonth + 1) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }

        strQry = "usp_feeCollectionNew @command='TotalSumMonth',@TotalMonth='" + Convert.ToString(intMonth + 1) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSTD_Id='" + Convert.ToString(Session["studentStandard"]) + "',@intstudent_id='" + Convert.ToString(Session["studentPayId"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtTotalDues.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
        }
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
    protected void txtLateAmount_TextChanged(object sender, EventArgs e)
    {
        txtTotalDues.Text = Convert.ToString(Convert.ToInt32(txtTotalDues.Text) + Convert.ToInt32(txtLateAmount.Text));
        txtpaidAmount.Focus();
    }
    protected void drpFromMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
