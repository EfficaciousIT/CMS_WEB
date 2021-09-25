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
using System.Drawing;
using System.Drawing.Imaging;
//using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;
using System.Net;

public partial class frmNewInquiry : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string dob;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
            FillInquiryNo();
            FillStandard();
            fillAcademicYear();
        }
    }

    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_Inquiry @command='fillYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlAcademicYear, strQry, "AcademicYear", "intAcademic_id");
            ddlAcademicYear.SelectedValue = "1";
            
        }
        catch
        {

        }
    }

    protected void fGrid()
    {
        strQry = "usp_Inquiry @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
    }
    protected void BlankFields()
    {
        txtInquiryNo.Text = "";
        ddlAcademicYear.ClearSelection();
        drpStandard.ClearSelection();
        drpGender.ClearSelection();
        txtCondidatename.Text = "";
        //txtMiddleName.Text = "";
        txtLastName.Text = "";
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
        txtRemark.Text = "";
        txtState.Text = "";
        txtTelNo.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        txtAmount.Text = "";
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //string dob = Convert.ToDateTime(txtDOB.Text).ToString("MM/dd/yyyy");
         //dob = Convert.ToDateTime(txtDOB.Text).ToString("MM/dd/yyyy").Replace("-","/");
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_Inquiry @command='Insert',@vchInquiry_no='" + txtInquiryNo.Text.Trim() + "',@intAcademic_id='" + ddlAcademicYear.SelectedValue + "',@vchName='" + txtCondidatename.Text.Trim() + "',@vchLastName='" + txtLastName.Text.Trim() + "',@dtDOB='" + Convert.ToDateTime(txtDOB.Text).ToString("MM/dd/yyyy") + "',@vchGender='" + drpGender.SelectedItem.Text.Trim() + "',@vchFatherName='" + txtfatherName.Text.Trim() + "',@vchFatherMobile='" + txtFatherMobile.Text.Trim() + "',@vchFatherEmail='" + txtFatherEmail.Text.Trim() + "',@vchFatherOccupation='" + txtFatherOccupation.Text.Trim() + "',@vchMotherName='" + txtMotherName.Text.Trim() + "',@vchMotherMobile='" + txtMotherMobile.Text.Trim() + "',@vchMotherEmail='" + txtMotherEmail.Text.Trim() + "',@vchMotherOccupation='" + txtMotherOccupation.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchTelNo='" + txtTelNo.Text.Trim() + "',@vchStudentEmail='',@vchStudenMobile='',@vchSchoolName='',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@vchState='" + txtState.Text.Trim() + "',@vchCity='" + txtCity.Text.Trim() + "',@vchCountry='',@vchRemark='" + txtRemark.Text.Trim() + "',@vcPincode='" + txtPincode.Text.Trim() + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intAmount='" + txtAmount.Text.Trim() + "',@insertBY='" + Session["User_Id"] + "',@insertIP='" + GetSystemIP() + "'";
            int i = sExecuteQuery(strQry);
            if (i > 0)
            {

                //POST("http://alerts.justnsms.com/api/v3/?method=sms&api_key=Ad68553890184f28bf0a8c8951f3a665f&to=" + txtFatherMobile.Text + "&sender=EFFICA&message=Thank you for enquiry of your child " + txtCondidatename.Text.Trim() + " " + txtLastName.Text.Trim() + " for " + drpStandard.SelectedItem.Text + " Standard. Your enquiry no : " + txtInquiryNo.Text.Trim() + ". You may collect registration form from School&alert=1&format=json&custom=1,2&flash=0", "");
                ////MessageBox("Thank you for Inquiry. School Administrator will contact you soon.");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Thank you for Inquiry. School Administrator will contact you soon.');window.location ='frmNewInquiry.aspx';", true);
                MessageBox("Registration done Successfully.");
                BlankFields();
                fGrid();
            }
           
        }
        else
        {
            strQry = "usp_Inquiry @command='update',@intInquiry_id='" + Convert.ToString(Session["intInquiry_id"]) + "',@vchInquiry_no='" + txtInquiryNo.Text.Trim() + "',@intAcademic_id='" + ddlAcademicYear.SelectedValue + "',@vchName='" + txtCondidatename.Text.Trim() + "',@vchLastName='" + txtLastName.Text.Trim() + "',@dtDOB='" + Convert.ToDateTime(txtDOB.Text).ToString("MM/dd/yyyy") + "',@vchGender='" + drpGender.SelectedItem.Text.Trim() + "',@vchFatherName='" + txtfatherName.Text.Trim() + "',@vchFatherMobile='" + txtFatherMobile.Text.Trim() + "',@vchFatherEmail='" + txtFatherEmail.Text.Trim() + "',@vchFatherOccupation='" + txtFatherOccupation.Text.Trim() + "',@vchMotherName='" + txtMotherName.Text.Trim() + "',@vchMotherMobile='" + txtMotherMobile.Text.Trim() + "',@vchMotherEmail='" + txtMotherEmail.Text.Trim() + "',@vchMotherOccupation='" + txtMotherOccupation.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchTelNo='" + txtTelNo.Text.Trim() + "',@vchStudentEmail='',@vchStudenMobile='',@vchSchoolName='',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@vchState='" + txtState.Text.Trim() + "',@vchCity='" + txtCity.Text.Trim() + "',@vchCountry='',@vchRemark='" + txtRemark.Text.Trim() + "',@vcPincode='" + txtPincode.Text.Trim() + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intAmount='" + txtAmount.Text.Trim() + "',@updateBY='" + Session["User_Id"] + "',@updateIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Record Updated Successfully!");
                TabContainer1.ActiveTabIndex = 0;
                btnSubmit.Text = "Submit";
            }
        }
    }
    private void POST(string url, string data)
    {
        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
        req.Method = "POST";
        req.Headers.Add(HttpRequestHeader.AcceptLanguage, "de-DE,de;q=0.8,en-US;q=0.7,en;q=0.3");

        req.Timeout = req.ReadWriteTimeout = 15000;

        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] dataBytes = encoding.GetBytes(data);
        req.ContentLength = dataBytes.Length;
        Stream stream = req.GetRequestStream();
        stream.Write(dataBytes, 0, dataBytes.Length);
        stream.Close();

        req.GetResponse();
    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intInquiry_id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_Inquiry @command='EditInquiry',@intInquiry_id='" + Convert.ToString(Session["intInquiry_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtInquiryNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchInquiry_no"]);
                ddlAcademicYear.SelectedValue= Convert.ToString(dsObj.Tables[0].Rows[0]["intAcademic_id"]);
                drpStandard.SelectedValue= Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
                txtCondidatename.Text =Convert.ToString(dsObj.Tables[0].Rows[0]["vchName"]);
                //txtMiddleName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMiddleName"]);
                txtLastName.Text =Convert.ToString(dsObj.Tables[0].Rows[0]["vchLastName"]);
                txtDOB.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                drpGender.SelectedItem.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]);
                txtfatherName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                txtFatherEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherEmail"]);
                txtFatherMobile.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherMobile"]);
                txtFatherOccupation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherOccupation"]);
                txtMotherEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherEmail"]);
                txtMotherMobile.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherMobile"]);
                txtMotherName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                txtMotherOccupation.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherOccupation"]);
                txtPincode.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vcPincode"]);
                txtRemark.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchRemark"]);
                txtState.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchState"]);
                txtCity.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchCity"]);
                txtTelNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTelNo"]);
                txtAddress.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                txtAmount.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAmount"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["intInquiry_id"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            //strQry = "exec [usp_Inquiry] @command='deleteInquiry',@intInquiry_id='" + Convert.ToString(Session["intInquiry_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@deleteBY='" + Session["User_Id"] + "',@deleteIP='" + GetSystemIP() + "'";
            //if (sExecuteQuery(strQry) != -1)
            //{
            strQry = "exec usp_Inquiry @command='UpdateInquiryID',@intInquiry_id='" + Convert.ToString(Session["intInquiry_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@updateBY='" + Session["User_Id"] + "',@updateIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Record Selected Successfully!");
            }
        }
        catch
        {

        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        BlankFields();
        btnSubmit.Text = "Submit";
    }
}