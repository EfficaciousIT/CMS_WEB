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

public partial class frmRegistrationSlip : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTile = new Label();
        //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTile.Visible = true;
        //lblTile.Text = "Registration From";

        //btnSubmit.Attributes.Add("OnClick", "print();");
        //btnSubmit.Attributes.Add("OnClientClick", "javaScript: print();");
        if (!IsPostBack)
        {
            FillStandard();
            fillAcademicYear();
            if (Request.QueryString["EnquiryID"] != null)
            {
                if (Convert.ToString(Request.QueryString["EnquiryID"]) == "0")
                {
                    rdbNo.Checked = true;
                    FillInquiryNo();
                }
                else
                {
                    rdbYes.Checked = true;
                    FillDetails(Convert.ToString(Request.QueryString["EnquiryID"])); 
                }
                
                               
            }
            
            
        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_Inquiry @command='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlAcademicYear, strQry, "AcademicYear", "intAcademic_id");
            ddlAcademicYear.SelectedValue = "1";
            ddlAcademicYear.Enabled = false;
        }
        catch
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string str = string.Empty;

        string strRegistrationNo = txtRegistrationNo.Text.Trim();

        strRegistrationNo = strRegistrationNo.Insert(2, "/").Insert(5, "/").Insert(10, "/");

        txtRegistrationNo.Text = strRegistrationNo;

        strQry = "select top 1 * from tblRegistration where vchRF_no='" + strRegistrationNo.Trim() + "'";
        dsObj = sGetDataset(strQry);

        if (dsObj.Tables[0].Rows.Count > 0)
        {
            MessageBox("Registration Form Number Already Exist");
        }
        else
        {
            if (rdbYes.Checked)
            {
                string strTxtInquiryValue = txtInquiryNo.Text.Trim().Replace("/", "");

                strTxtInquiryValue = strTxtInquiryValue.Insert(1, "/").Insert(4, "/").Insert(9, "/");

                txtInquiryNo.Text = strTxtInquiryValue;

                strQry = "usp_Inquiry @command='InsertRegistration',@intAcademic_id='" + ddlAcademicYear.SelectedValue + "',@vchRF_no='" + strRegistrationNo.Trim() + "',@vchInquiry_no='" + strTxtInquiryValue.Trim() + "',@vchName='" + txtCondidatename.Text.Trim() + "',@vchMiddleName='" + txtMiddleName.Text.Trim() + "',@vchLastName='" + txtLastName.Text.Trim() + "',@dtDOB='" + Convert.ToDateTime(txtDOB.Text).ToString("MM/dd/yyyy") + "',@vchGender='" + drpGender.SelectedItem.Text.Trim() + "',@vchFatherName='" + txtfatherName.Text.Trim() + "',@vchFatherMobile='" + txtFatherMobile.Text.Trim() + "',@vchFatherEmail='" + txtFatherEmail.Text.Trim() + "',@vchFatherOccupation='" + txtFatherOccupation.Text.Trim() + "',@vchMotherName='" + txtMotherName.Text.Trim() + "',@vchMotherMobile='" + txtMotherMobile.Text.Trim() + "',@vchMotherEmail='" + txtMotherEmail.Text.Trim() + "',@vchMotherOccupation='" + txtMotherOccupation.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchTelNo='" + txtTelNo.Text.Trim() + "',@vchStudentEmail='',@vchStudenMobile='',@vchSchoolName='',@intSchool_id='',@vchState='" + txtState.Text.Trim() + "',@vchCity='" + txtCity.Text.Trim() + "',@vchCountry='',@vcPincode='" + txtPincode.Text.Trim() + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@amount='" + txtAmount.Text.Trim() + "'";
                int i = sExecuteQuery(strQry);
                strQry = "usp_Inquiry @command='UpdateInquiryID',@vchInquiry_no='" + strTxtInquiryValue.Trim() + "'";
                int k = sExecuteQuery(strQry);
                if (i > 0)
                {
                    MessageBox("Registration addedd successfully");
                }
            }
            else if (rdbNo.Checked)
            {

                //string strRegistrationNo = txtRegistrationNo.Text.Trim();

                //txtRegistrationNo.Text = "";

                //strRegistrationNo = strRegistrationNo.Insert(2, "/").Insert(5, "/").Insert(10, "/");

                txtRegistrationNo.Text = strRegistrationNo;

                string strTxtInquiryValue = txtInquiryNo.Text.Trim().Replace("/", "");
                txtInquiryNo.Text = "";

                strTxtInquiryValue = strTxtInquiryValue.Insert(1, "/").Insert(4, "/").Insert(9, "/");

                txtInquiryNo.Text = strTxtInquiryValue;

                strQry = "usp_Inquiry @command='Insert',@vchInquiry_no='" + strTxtInquiryValue.Trim() + "',@intAcademic_id='" + ddlAcademicYear.SelectedValue + "',@vchName='" + txtCondidatename.Text.Trim() + "',@vchMiddleName='" + txtMiddleName.Text.Trim() + "',@vchLastName='" + txtLastName.Text.Trim() + "',@dtDOB='" + Convert.ToDateTime(txtDOB.Text).ToString("MM/dd/yyyy") + "',@vchGender='" + drpGender.SelectedItem.Text.Trim() + "',@vchFatherName='" + txtfatherName.Text.Trim() + "',@vchFatherMobile='" + txtFatherMobile.Text.Trim() + "',@vchFatherEmail='" + txtFatherEmail.Text.Trim() + "',@vchFatherOccupation='" + txtFatherOccupation.Text.Trim() + "',@vchMotherName='" + txtMotherName.Text.Trim() + "',@vchMotherMobile='" + txtMotherMobile.Text.Trim() + "',@vchMotherEmail='" + txtMotherEmail.Text.Trim() + "',@vchMotherOccupation='" + txtMotherOccupation.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchTelNo='" + txtTelNo.Text.Trim() + "',@vchStudentEmail='',@vchStudenMobile='',@vchSchoolName='',@intSchool_id='',@vchState='" + txtState.Text.Trim() + "',@vchCity='" + txtCity.Text.Trim() + "',@vchCountry='',@vcPincode='" + txtPincode.Text.Trim() + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "'";
                int i = sExecuteQuery(strQry);
                if (i > 0)
                {
                    MessageBox("Thank you for Inquiry. School Administrator will contact you soon.");
                    BlankFields();
                }

                //----------

                strQry = "usp_Inquiry @command='InsertRegistration',@intAcademic_id='" + ddlAcademicYear.SelectedValue + "',@vchRF_no='" + strRegistrationNo.Trim() + "',@vchInquiry_no='" + strTxtInquiryValue.Trim() + "',@vchName='" + txtCondidatename.Text.Trim() + "',@vchMiddleName='" + txtMiddleName.Text.Trim() + "',@vchLastName='" + txtLastName.Text.Trim() + "',@dtDOB='" + Convert.ToDateTime(txtDOB.Text).ToString("MM/dd/yyyy") + "',@vchGender='" + drpGender.SelectedItem.Text.Trim() + "',@vchFatherName='" + txtfatherName.Text.Trim() + "',@vchFatherMobile='" + txtFatherMobile.Text.Trim() + "',@vchFatherEmail='" + txtFatherEmail.Text.Trim() + "',@vchFatherOccupation='" + txtFatherOccupation.Text.Trim() + "',@vchMotherName='" + txtMotherName.Text.Trim() + "',@vchMotherMobile='" + txtMotherMobile.Text.Trim() + "',@vchMotherEmail='" + txtMotherEmail.Text.Trim() + "',@vchMotherOccupation='" + txtMotherOccupation.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchTelNo='" + txtTelNo.Text.Trim() + "',@vchStudentEmail='',@vchStudenMobile='',@vchSchoolName='',@intSchool_id='',@vchState='" + txtState.Text.Trim() + "',@vchCity='" + txtCity.Text.Trim() + "',@vchCountry='',@vcPincode='" + txtPincode.Text.Trim() + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@amount='" + txtAmount.Text.Trim() + "'";
                i = sExecuteQuery(strQry);
                if (i > 0)
                {
                    MessageBox("Registration addedd successfully");
                }
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "print()", true);
        }


        
        //BlankFields();
        //MessageBox("Registration addedd successfully");
    }
    protected void BlankFields()
    {
        txtInquiryNo.Text = "";
        txtCondidatename.Text = "";
        txtDOB.Text = "";
        txtfatherName.Text = "";
        txtFatherEmail.Text = "";
        txtFatherMobile.Text = "";
        txtFatherOccupation.Text = "";
        txtMotherEmail.Text = "";
        txtMotherMobile.Text = "";
        txtMotherName.Text = "";
        txtMotherOccupation.Text = "";
        txtPincode.Text = "";
        
        txtState.Text = "";
        txtTelNo.Text = "";
        txtAddress.Text = "";
        drpGender.SelectedIndex = 0;
        drpStandard.SelectedIndex = 0;
        txtCity.Text = "";
    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='1'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if (this.DesignMode == true)
        {
            this.EnsureChildControls();
        }
        this.Page.RegisterRequiresControlState(this);
    } 
    protected void txtInquiryNo_TextChanged(object sender, EventArgs e)
    {
        if (txtInquiryNo.Text != "")
        {
            string strTxtInquiryValue = txtInquiryNo.Text.Trim();

            strTxtInquiryValue = strTxtInquiryValue.Insert(1, "/").Insert(4, "/").Insert(9, "/");

            txtInquiryNo.Text = strTxtInquiryValue;

            strQry = "usp_Inquiry @command='SelectRegistration',@vchInquiry_no='" + txtInquiryNo.Text.Trim() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //txtInquiryNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                txtInquiryNo.Enabled = false;

                txtCondidatename.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchName"]);
                txtMiddleName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMiddleName"]);
                txtLastName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchLastName"]);
                txtDOB.Text = Convert.ToString(Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("dd/MM/yyyy"));


                if (Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]) == "Male")
                {
                    drpGender.Text = "1";
                }
                else
                {
                    drpGender.Text = "2";
                }

                txtTelNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTelNo"]);
                ddlAcademicYear.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAcademic_id"]);
                drpStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);

                txtfatherName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                txtFatherMobile.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherMobile"]);
                txtFatherEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherEmail"]);
                txtFatherOccupation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherOccupation"]);

                txtMotherName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                txtMotherMobile.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherMobile"]);
                txtMotherEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherEmail"]);
                txtMotherOccupation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherOccupation"]);

                txtAddress.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                txtPincode.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vcPincode"]);
                txtState.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchState"]);
                txtCity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCity"]);
            }
        }
        
    }
    protected void FillDetails(string strInquiryNo)
    {
        strQry = "usp_Inquiry @command='SelectRegistration',@vchInquiry_no='" + strInquiryNo.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtInquiryNo.Text = Convert.ToString(strInquiryNo.Trim());
            txtInquiryNo.Enabled = false;

            txtCondidatename.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchName"]);
            txtMiddleName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMiddleName"]);
            txtLastName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchLastName"]);
            txtDOB.Text = Convert.ToString(Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("dd/MM/yyyy"));


            if (Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]) == "Male")
            {
                drpGender.Text = "1";
            }
            else
            {
                drpGender.Text = "2";
            }

            txtTelNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTelNo"]);
            ddlAcademicYear.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAcademic_id"]);

            drpStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);

            txtfatherName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
            txtFatherMobile.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherMobile"]);
            txtFatherEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherEmail"]);
            txtFatherOccupation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherOccupation"]);

            txtMotherName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
            txtMotherMobile.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherMobile"]);
            txtMotherEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherEmail"]);
            txtMotherOccupation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherOccupation"]);

            txtAddress.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
            txtPincode.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vcPincode"]);
            txtState.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchState"]);
            txtCity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCity"]);
        }
    }
    protected void rdbNo_CheckedChanged(object sender, EventArgs e)
    {
        BlankFields();
        FillInquiryNo();
    }
    protected void FillInquiryNo()
    {
        strQry = "usp_Inquiry @command='GetNewID'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtInquiryNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
            txtInquiryNo.Enabled = false;
        }
    }
    protected void rdbYes_CheckedChanged(object sender, EventArgs e)
    {
        txtInquiryNo.Enabled = true;
        txtInquiryNo.Text = "";
    }
}
