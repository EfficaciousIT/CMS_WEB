using System;
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
using System.Net.Mail;

public partial class _Default : DBUtility
{
    string strUserType = "";
    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            Form.DefaultButton = btnSubmit.UniqueID;
        }
    }

 protected void btnSubSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            
            string schoolnm, contacnm, address, city, state, country, tele, email,Remark;
            schoolnm = Convert.ToString(txtSchoolname.Text);
            contacnm = Convert.ToString(txtcontactPerson.Text);
            address = Convert.ToString(txtAddress.Text);
            city = Convert.ToString(txtState.Text);
            state = Convert.ToString(txtCity.Text);
            country = Convert.ToString(txtCountry.Text);
            tele = Convert.ToString(txtPhone.Text);
            email = Convert.ToString(txtEmail.Text);
	    Remark = Convert.ToString(txtRemark.Text);
            long insertby = Convert.ToInt64(Session["User_id"]);
            string ipval = GetSystemIP();
            string instremaquery1 = "Execute dbo.usp_Enquiry @command='Insert_Enquiry',@vchSchool_Name='" + schoolnm + "',@vchContact_Name='" + contacnm + "',@vchAddress='" + address + "',@intSchool_id='" + Session["School_id"] + "',@vchCity='" + city + "',@vchState='" + state + "',@vchCountry='" + country + "',@vchTelephone='" + tele + "',@vchEmail='" + email + "',@vchInsertedIP='" + ipval + "'";
            int result1 = sExecuteQuery(instremaquery1);
            if (result1 != -1)
            {
                string display = "Enquiry Save Successfully!";
                MessageBox(display);            
                ButSub1.Enabled = false;
 		MailMessage mailmsg = new MailMessage();
                mailmsg.From = new MailAddress(email);
                mailmsg.To.Add(new MailAddress("Er.snehabhosale03@gmail.com"));
                mailmsg.Subject = "New Enquiry";
                //ajayp@efficacious.co.in
                mailmsg.Body = "School Name:-" + schoolnm + "<br>" + "Contact Name:-" + contacnm + "<br>" + "Address:-" + address + "<br>" + "City:-" + city + "<br>" + "State:-" + state + "<br>" + "Country:-" + country + "<br>" + "TelePhone No:-" + tele +"<br>"+ "Email Id:-" + email + "<br>" + "Remark:-" + Remark;
                mailmsg.IsBodyHtml = true;


                SmtpClient Smtpclient = new SmtpClient();
                Smtpclient.Host = "smtp.gmail.com";
                Smtpclient.Credentials = new System.Net.NetworkCredential("sandhyasweet777@gmail.com", "8976829912");

                Smtpclient.EnableSsl = true;

                Smtpclient.Send(mailmsg);
                MessageBox("mail Send");


            }
            else
            {
                MessageBox("ooopppsss!Unable To Save a Enquiry");
            }
        }
        catch
        {

        }  
    }
       protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string strQry = "";
        DataSet dsObj = new DataSet();

        if (Convert.ToString(drpUserType.Text.Trim()) == "Student")
        {
            strUserType = "1";
            HttpContext.Current.Session["strUserType"] = "1";
        }
        else if (Convert.ToString(drpUserType.Text.Trim()) == "Parent")
        {
            strUserType = "2";
            HttpContext.Current.Session["strUserType"] = "2";
        }
        else if (Convert.ToString(drpUserType.Text.Trim()) == "Teacher")
        {
            strUserType = "3";
            HttpContext.Current.Session["strUserType"] = "3";
        }
        else if (Convert.ToString(drpUserType.Text.Trim()) == "Administrator")
        {
            strUserType = "5";
            HttpContext.Current.Session["strUserType"] = "5";
        }

        strQry = "exec [usp_usermaster] @command='select',@username='" + Convert.ToString(txtUserName.Text.Trim()) + "',@password='" + Convert.ToString(txtPassword.Text.Trim()) + "' , @intSchool_id='1',@usertype='" + Convert.ToString(HttpContext.Current.Session["strUserType"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            Session["School_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intSchool_id"]);
            Session["UserType_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
            Session["User_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUser_id"]);
            Session["Student_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
            Session["Standard_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
            Session["Division_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
            Session["Division_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
            Response.Redirect("frmAttendance.aspx", false);
            //Server.Transfer("frmAttendance.aspx");
        }
        else
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            MessageBox("Invalid Authentication !!!!!");
        }
    }

}
