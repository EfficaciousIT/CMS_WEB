using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmReAdmissionForm : DBUtility
{
    string strQry = "";
    DataSet dsObj;

    string strStudentId = string.Empty;
    string strStandardId = string.Empty;
    string strSchoolId = string.Empty;
    string strAcademicId = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {

        strStudentId = Request.QueryString["strStudentId"].ToString();
        strStandardId = Request.QueryString["strStandardId"].ToString();
        strSchoolId = Request.QueryString["strSchoolId"].ToString();
        strAcademicId = Request.QueryString["strAcademicId"].ToString();

        if (!IsPostBack)
        {
            if (strAcademicId == "5")
            {
                _FillStudDetails(strStudentId, strSchoolId, strAcademicId, strStandardId);
            }
            else
            {
                Response.Redirect("DataNotFound.aspx");
            }
        }
    }
    protected void _FillStudDetails(string strStudentId, string strSchoolId, string strAcademicId, string strStandardId)
    {
        try
        {
            string student_id = strStudentId;
            string academicid = strAcademicId;
            strQry = "exec usp_GetStudDetails @intStudent_id='" + student_id + "',@intSchool_id='" + strSchoolId + "'";
            dsObj = sGetDataset(strQry);

            int intstandard_id = Convert.ToInt32(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
            int intdivision_id = Convert.ToInt32(dsObj.Tables[0].Rows[0]["intdivision_id"]);

            txtsystemID.Text = Convert.ToString(student_id);
            txtStudnm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
            txtstudentID.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudentID_Number"]);
            txtStad.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStandard_name"]);
            txtDiv.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
            txtParennm.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
            TextBox2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpresentAddress"]);

            FillFee(intstandard_id);
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {   
        if(txtemailID.Text == "")
        {
            MessageBox("Please Enter Email ID");
        }
        else if( txtbanknm.Text == "")
        {
            MessageBox("Please Enter Bank Name");
        }
        else if (txtpayamt.Text == "")
        {
            MessageBox("Please Enter Paid Amount");
        }
        else if (txtpayrefno.Text == "" )
        {
            MessageBox("Please Enter Payment Reference Number ");
        }
        else if (txtRemark.Text == "")
        {
            MessageBox("Please Enter Remark ");
        }
        else
        {
            if (Page.IsValid)
            {
                try
                {
                    strQry = "exec usp_GetStudDetails @intStudent_id='" + strStudentId + "',@intSchool_id='" + strSchoolId + "'";
                    dsObj = sGetDataset(strQry);

                    strQry = "exec usp_studFees @command='insertFeeRecord',@intStudent_id='" + txtsystemID.Text + "',@intstandard_id='" + Convert.ToInt32(dsObj.Tables[0].Rows[0]["intstanderd_id"]) + "',@intdivision_id='" + Convert.ToInt32(dsObj.Tables[0].Rows[0]["intdivision_id"]) + "',@EmailID='" + txtemailID.Text + "',@vchBank_name='" + txtbanknm.Text + "',@PaidAmt='" + txtpayamt.Text + "',@PaymentRefNo='" + txtpayrefno.Text + "',@Remarks='" + txtRemark.Text + "',@intSchool_id='" + strSchoolId + "',@intAcademic_id='" + strAcademicId + "',@intstandardFee_id='" + Session["intstandardFee_id"] + "'";
                    int Record = sExecuteQuery(strQry);
                    if (Record > 0)
                    {
                        MessageBox("Record inserted successfully...." +
                            "Please send a copy of the Payment ref no. on centralmodel2020@gmail.com ");
                    }
                    else
                    {
                        MessageBox("Record not inserted...... ");
                    }

                    txtpayamt.Text = "";
                    txtRemark.Text = "";
                    txtpayrefno.Text = "";
                    txtemailID.Text = "";
                    txtbanknm.Text = "";

                }
                catch (Exception ex)
                {
                }
            }
        }
    }

    public void FillFee(int standardid)
    {
        try
        {
            strQry = "exec [usp_StandardMasterFee_master] @command='selectWiseFee',@intstandard_id='" + standardid + "',@intSchool_id='" + strSchoolId + "',@intAcademic_id='" + strAcademicId + "'";
            dsObj = sGetDataset(strQry);

            TextBox1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["FeeAmount"]);
            Session["intstandardFee_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandardFee_id"]);
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtpayamt.Text = "";
            txtRemark.Text = "";
            txtpayrefno.Text = "";
            txtemailID.Text = "";
            txtbanknm.Text = "";
        }
        catch (Exception ex)
        {
        }
    }
}