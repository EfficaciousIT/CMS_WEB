using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;

public partial class login_contact : DBUtility
{
    string strUserType = "";
    DataSet dsObj = new DataSet();
    SqlDataAdapter daObj = new SqlDataAdapter();
    string strCOn = System.Configuration.ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
    SqlConnection sqlcon;
    SqlCommand sqlcom = new SqlCommand();
    DataSet dsObj1 = new DataSet();
    SqlDataAdapter daObj1 = new SqlDataAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["School_id"] = "";
            Session["UserType_id"] = "";
            Session["User_id"] = "";
            Session["Student_id"] = "";
            Session["Standard_id"] = "";
            Session["Division_id"] = "";
            fillSchool();
        }
    }
    protected void drpSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillRole();
    }
    protected void fillSchool()
    {
        string strQry1 = "";
        strQry1 = "exec [usp_usermaster] @command='fillSchool',@intSchool_id='1'";
        daObj1 = new SqlDataAdapter(strQry1, strCOn);
        daObj1.Fill(dsObj1);
        if (dsObj1.Tables[0].Rows.Count > 0)
        {
            drpSchool.DataTextField = "vchSchool_name";
            drpSchool.DataValueField = "intSchool_id";
            drpSchool.DataSource = dsObj1;
            drpSchool.DataBind();
            drpSchool.Items.Insert(0, "---Select School----");
        }
        else
        {
            drpSchool.DataSource = dsObj1;
            drpSchool.DataBind();
            drpSchool.Items.Insert(0, "---Select School----");
        }

    }
    protected void fillRole()
    {
        string strQry = "";
        strQry = "exec [usp_usermaster] @command='fillRole',@intSchool_id='" + Convert.ToString(drpSchool.SelectedValue.Trim()) + "'";
        daObj = new SqlDataAdapter(strQry, strCOn);
        daObj.Fill(dsObj);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            drpUserType.DataTextField = "vchRole";
            drpUserType.DataValueField = "intRole_Id";
            drpUserType.DataSource = dsObj;
            drpUserType.DataBind();
            drpUserType.Items.Insert(0, "---Select Role----");
        }
        else
        {
            drpUserType.DataSource = dsObj;
            drpUserType.DataBind();
            drpUserType.Items.Insert(0, "---Select Role----");
        }

    }
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string strQry = "";

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
        else if (Convert.ToString(drpUserType.Text.Trim()) == "Staff")
        {
            strUserType = "4";
            HttpContext.Current.Session["strUserType"] = "4";
        }
        else if (Convert.ToString(drpUserType.Text.Trim()) == "Admin")
        {
            strUserType = "5";
            HttpContext.Current.Session["strUserType"] = "5";
        }

        strQry = "exec [usp_usermaster] @command='select',@username='" + Convert.ToString(txtUserName.Text.Trim()) + "',@password='" + Convert.ToString(txtPassword.Text.Trim()) + "' , @intSchool_id='" + Convert.ToString(drpSchool.SelectedValue.Trim()) + "',@usertype='" + Convert.ToString(drpUserType.SelectedValue.Trim()) + "'";
        daObj = new SqlDataAdapter(strQry, strCOn);
        daObj.Fill(dsObj);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            Session["School_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intSchool_id"]);
            Session["UserType_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
            Session["User_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intUser_id"]);
            Session["Student_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
            Session["Standard_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
            Session["Division_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
            Session["AcademicID"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intAcademic_id"]);

            string url = "http://checkip.dyndns.org";
            System.Net.WebRequest req = System.Net.WebRequest.Create(url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            string response = sr.ReadToEnd().Trim();
            string[] a = response.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];

            Session["IP"] = a4;
            sqlcon = new SqlConnection(strCOn);

            sqlcom.CommandType = CommandType.StoredProcedure;
            sqlcom.CommandText = "usp_loginlogs";
            sqlcom.Parameters.Add("@command", SqlDbType.VarChar).Value = Convert.ToString("Insert");
            sqlcom.Parameters.Add("@intUserType_id", SqlDbType.VarChar).Value = Convert.ToString(Session["UserType_id"]);
            sqlcom.Parameters.Add("@intUser_id", SqlDbType.VarChar).Value = Convert.ToString(Session["User_id"]);
            sqlcom.Parameters.Add("@intStandard_id", SqlDbType.VarChar).Value = Convert.ToString(Session["Standard_id"]);
            sqlcom.Parameters.Add("@intDivision_id", SqlDbType.VarChar).Value = Convert.ToString(Session["Division_id"]);
            sqlcom.Parameters.Add("@intAcademicYear_id", SqlDbType.VarChar).Value = Convert.ToString(Session["AcademicID"]);
            sqlcom.Parameters.Add("@vchIPaddress", SqlDbType.VarChar).Value = Convert.ToString(Session["IP"]);
            sqlcom.Parameters.Add("@intSchool_id", SqlDbType.VarChar).Value = Convert.ToString(Session["School_id"]);
            sqlcom.Parameters.Add("@intStudent_id", SqlDbType.VarChar).Value = Convert.ToString(Session["Student_id"]);
            sqlcom.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            sqlcom.Connection = sqlcon;
            try
            {
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                Session["session_id"] = sqlcom.Parameters["@id"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (Convert.ToString(Session["Student_id"]) == "374")
            {
                Response.Redirect("frmBusTracking.aspx", false);
            }
            else
            {
                if (Convert.ToString(Session["UserType_id"]) == "5")
                {


                    if (txtUserName.Text == "pulak")
                    {
                        Response.Redirect("frmRegistrationSearch.aspx", false);
                    }
                    else
                    {
                        Response.Redirect("AdminDB.aspx", false);
                    }
                }
                else if (Convert.ToString(Session["UserType_id"]) == "3")
                {
                    Response.Redirect("TeacherDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "4")
                {
                    Response.Redirect("StaffDB.aspx", false);
                }
                else if (Convert.ToString(Session["UserType_id"]) == "1" || Convert.ToString(Session["UserType_id"]) == "2")
                {
                    Response.Redirect("studentDB.aspx", false);
                }

                else
                {
                    Response.Redirect("frmAttendance.aspx", false);
                }
            }

        }
        else
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            string msg = "Invalid Authentication";
            string script = "alert(\"" + msg + "\");";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
    }
    protected void btnSumitEnquiry_Click1(object sender, EventArgs e)
    {
        try
        {

            string schoolnm, contacnm, address, city, state, country, tele, email, Remark;
            schoolnm = Convert.ToString(txtSchoolname.Text);
            contacnm = Convert.ToString(txtcontactPerson.Text);
            address = Convert.ToString(txtAddress.Text);
            city = Convert.ToString(txtState.Text);
            state = Convert.ToString(txtCity.Text);
            tele = Convert.ToString(txtPhone.Text);
            email = Convert.ToString(txtEmail.Text);
            Remark = Convert.ToString(txtRemark.Text);
            //long insertby = Convert.ToInt64(Session["User_id"]);
            string ipval = GetSystemIP();
            string instremaquery1 = "Execute dbo.usp_Enquiry @command='Insert_Enquiry',@vchSchool_Name='" + schoolnm + "',@vchContact_Name='" + contacnm + "',@vchAddress='" + address + "',@intSchool_id='" + Session["School_id"] + "',@vchCity='" + city + "',@vchState='" + state + "',@vchTelephone='" + tele + "',@vchEmail='" + email + "',@vchInsertedIP='" + ipval + "'";
            int result1 = sExecuteQuery(instremaquery1);
            if (result1 != -1)
            {
                MailAddress mailfrom = new MailAddress(email);
                MailAddress mailto = new MailAddress("info@efficacious.co.in");
                MailMessage newmsg = new MailMessage(mailfrom, mailto);

                newmsg.Subject = "New Enquiry";
                newmsg.Body = "Site Name:-" + "E-Smarts" + " " + "School Name:-" + schoolnm + " " + "Contact Name:-" + contacnm + " " + "Address:-" + address + " " + "City:-" + city + " " + "State:-" + state + " " + "TelePhone No:-" + tele + " " + "Email Id:-" + email + " " + "Remark:-" + Remark;

                SmtpClient smtps = new SmtpClient("mail.efficacious.co.in", 25);
                smtps.UseDefaultCredentials = false;
                smtps.Credentials = new NetworkCredential("info@efficacious.co.in", "info@2017");
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
                smtps.EnableSsl = false;
                smtps.Send(newmsg);
                ReplyMail();
                MessageBox("Thanks for Inquiry. Our representative will contact you soon. ");


                txtSchoolname.Text = "";
                txtcontactPerson.Text = "";
                txtAddress.Text = "";
                txtState.Text = "";
                txtCity.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtRemark.Text = "";

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
    protected void ReplyMail()
    {
        string Reemail = Convert.ToString(txtEmail.Text);
        MailMessage mailmsg = new MailMessage();
        mailmsg.From = new MailAddress("info@efficacious.co.in");
        MailAddress mailto = new MailAddress(Reemail);
        MailAddress mailfrom = new MailAddress("info@efficacious.co.in");
        MailMessage newmsg = new MailMessage(mailfrom, mailto);

        newmsg.Subject = "Enquiry";
        newmsg.Body = "Dear Sir/ Mam," + "                                                                                                                                                                                " +

"About Efficacious" + "                                                                                                                                                                                          " +
"Efficacious is the synonym to Efficient. Efficacious India Limited (EIL) an ISO 9001:2008 was incorporated in 2012 with a very clear vision of finding IT enabled solution to eradicate the problems being faced by the Common Man. The whole concept was conceptualized, a hard core financial professional having entrepreneurial vision to provide enterprise solutions to niche markets. EIL was born out of the ambition to tap the needs in niche segments in the IT sector and create opportunities no one has crafted before in these avenues." +

"We thank you for showing interest in our product. As per your request our representative will contact you soon. " + "                               " +

"Hoping in response to continue a long term relationship ahead." + "                                                                                               " +



"Thanks & Regards" + "                                                                                                                                                                 " +

"Efficacious India Limited" + "                                                                                                                                                                   " +
"L: +91 – 22 – 27816136/37,   www.efficacious.co.in  1402, G Square Business Centre, Plot 25 & 26, Sector 30, Opp. Sanpada Station, Vashi, Navi Mumbai – 400703";

        SmtpClient smtps = new SmtpClient("mail.efficacious.co.in", 25);
        smtps.UseDefaultCredentials = false;
        smtps.Credentials = new NetworkCredential("info@efficacious.co.in", "info@2017");
        System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };
        smtps.EnableSsl = false;
        smtps.Send(newmsg);


    }
}