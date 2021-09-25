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


public partial class frmInquiry : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnSubmit.Attributes.Add("onclick", "return zoomIn()");
        //btnSubmit.Attributes.Add("onclick", "return zoomIn()");
        if (!IsPostBack)
        {
            FillInquiryNo();
            FillStandard();
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //strQry = "usp_Inquiry @command='Insert',@vchInquiry_no='" + txtInquiryNo.Text.Trim() + "',@vchName='" + txtCondidatename.Text.Trim() + "',@dtDOB='" + Convert.ToDateTime(txtDOB.Text).ToString("MM/dd/yyyy") + "',@vchGender='" + drpGender.SelectedItem.Text.Trim() +"',@vchFatherName='" + txtfatherName.Text.Trim() + "',@vchFatherMobile='" + txtFatherMobile.Text.Trim() + "',@vchFatherEmail='" + txtFatherEmail.Text.Trim() + "',@vchFatherOccupation='" + txtFatherOccupation.Text.Trim() + "',@vchMotherName='" + txtMotherName.Text.Trim() + "',@vchMotherMobile='" + txtMotherMobile.Text.Trim() + "',@vchMotherEmail='" + txtMotherEmail.Text.Trim() + "',@vchMotherOccupation='" + txtMotherOccupation.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchTelNo='" + txtTelNo.Text.Trim() + "',@vchStudentEmail='',@vchStudenMobile='',@vchSchoolName='',@intSchool_id='',@vchState='" + txtState.Text.Trim() + "',@vchCity='" + txtCity.Text.Trim() + "',@vchCountry='',@vchRemark='" + txtRemark.Text.Trim() + "',@vcPincode='" + txtPincode.Text.Trim() + "'";
        //int i = sExecuteQuery(strQry);
        //if (i > 0)
        //{
        //    MessageBox("Thank you for Inquiry. School Administrator will contact you soon.");
        //    BlankFields();
        //}
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
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='1'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
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
        txtRemark.Text = "";
        txtState.Text = "";
        txtTelNo.Text = "";
        txtAddress.Text = "";
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
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "return zoomIn();", true);
        //Capture(sender,"E:/asd.bmp");
        //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "return zoomOut();", true);

        //CalendarExtender1.Controls.Remove = true;

        //this.Items.Remove(CalendarExtender1);

        //this.Controls.Remove(CalendarExtender1);

        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=AJAY.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //pnlPerson.Page.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        ////htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();

        


        strQry = "usp_Inquiry @command='Insert',@vchInquiry_no='" + txtInquiryNo.Text.Trim() + "',@vchName='" + txtCondidatename.Text.Trim() + "',@dtDOB='" + Convert.ToDateTime(txtDOB.Text).ToString("MM/dd/yyyy") + "',@vchGender='" + drpGender.SelectedItem.Text.Trim() + "',@vchFatherName='" + txtfatherName.Text.Trim() + "',@vchFatherMobile='" + txtFatherMobile.Text.Trim() + "',@vchFatherEmail='" + txtFatherEmail.Text.Trim() + "',@vchFatherOccupation='" + txtFatherOccupation.Text.Trim() + "',@vchMotherName='" + txtMotherName.Text.Trim() + "',@vchMotherMobile='" + txtMotherMobile.Text.Trim() + "',@vchMotherEmail='" + txtMotherEmail.Text.Trim() + "',@vchMotherOccupation='" + txtMotherOccupation.Text.Trim() + "',@vchAddress='" + txtAddress.Text.Trim() + "',@vchTelNo='" + txtTelNo.Text.Trim() + "',@vchStudentEmail='',@vchStudenMobile='',@vchSchoolName='',@intSchool_id='',@vchState='" + txtState.Text.Trim() + "',@vchCity='" + txtCity.Text.Trim() + "',@vchCountry='',@vchRemark='" + txtRemark.Text.Trim() + "',@vcPincode='" + txtPincode.Text.Trim() + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "'";
        int i = sExecuteQuery(strQry);
        if (i > 0)
        {
            POST("http://103.231.41.62/HttpPush/SendMessage.aspx?user=effica&pwd=effica&sender=ESMART&mobile=91" + txtFatherMobile.Text.Trim() + "&msg=Thank you for enquiry for your child " + txtCondidatename.Text.Trim() + " for " + drpStandard.Text.Trim() + "th Std. Your enquiry no : " + txtInquiryNo.Text.Trim() + ".you may collect registration form from school&alert=1", "");
            MessageBox("Thank you for Inquiry. School Administrator will contact you soon.");
            BlankFields();
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
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    public static void Capture(object sender, string CapturedFilePath)
    {

        //ScreenCapture sc = new ScreenCapture();
        //// capture entire screen, and save it to a file
        //Image img = sc.CaptureScreen();
        //// display image in a Picture control named imageDisplay
        //this.imageDisplay.Image = img;
        //// capture this window, and save it
        //sc.CaptureWindowToFile(this.Handle, "C:\\temp2.gif", ImageFormat.Gif);

        //WebBrowser browser = sender as WebBrowser;

        //using (Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
        //{
        //    browser.DrawToBitmap(bitmap, new Rectangle(0, 0, 1024, 1024));
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        //        byte[] bytes = stream.ToArray();
        //        //imgScreenShot.Visible = true;
        //        //imgScreenShot.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(bytes);
        //    }
        //}
    }    
}
