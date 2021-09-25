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

using System.Collections.Generic;

public partial class frmChanegePassword: DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //--- You can increase or decrease numbers 
            //--- to increase or decrease captcha strings.
            CreateRandomString(6);

        }
    }
    public void CreateRandomString(int length)
    {

        string guidResult = System.Guid.NewGuid().ToString();
        guidResult = guidResult.Replace("-", string.Empty);
        guidResult = guidResult.Substring(0, length);

        imgCaptcha.ImageUrl = "~/CaptchaHandler.ashx?txt=" + guidResult;
        Session["RandomImgText"] = guidResult;

    }

    //--- Method to check whether entered captcha is correct or not.
    protected bool ValidateForm()
    {

        bool IsValid = true;
        if (txtImg.Text != Session["RandomImgText"].ToString())
        {
            IsValid = false;
        }
        return IsValid;

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
    public void Clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
    
    }
   
    protected void change_pass(object sender, EventArgs e)
    {
        try
        {
             bool status = ValidateForm();
             if (status == true)
             {
                 //string usernm = Convert.ToString(TextBox1.Text);
                 string oldpass = Convert.ToString(TextBox2.Text);
                 //string newpass = Convert.ToString(TextBox3.Text);
                 string confpass = Convert.ToString(TextBox4.Text);

                 //DataSet dsObj = new DataSet();

                 //string strQry = "exec usp_log @command='ChangePassCheck',@vchUser_name='" + usernm + "',@vchOldPassword='" + oldpass + "'";
                 //dsObj = sGetDataset(strQry);
                 //if (dsObj.Tables[0].Rows.Count > 0)
                 //{
                 //    string intid = Convert.ToString(dsObj.Tables[0].Rows[0]["intID"]);

                 //    string strQry1 = "Execute dbo.usp_log @command='ChangePass',@intid='" + intid + "',@vchNewPassword='" + confpass + "'";
                 //    if (sExecuteQuery(strQry1) != -1)
                 //    {
                 //        MessageBox("Password Changed Successfully ");
                 //        Clear();
                 //    }
                 //}
                 //else
                 //{
                 //    MessageBox("Username or Password does not Exit ");
                 //    Clear();
                 //}


                 if (Convert.ToString(Session["strUserType"]) == "1")
                 {
                    // strQry = "Execute dbo.usp_log @command='ChangePassStudent',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     strQry = "Execute dbo.usp_log @command='ChangePassStudent',@intStudent_id='" + Convert.ToString(Session["vchapplication_no"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     if (sExecuteQuery(strQry) > 0)
                     {
                         MessageBox("Password Changed Successfully ");
                         Clear();
                     }
                 }
                 else if (Convert.ToString(Session["strUserType"]) == "2")
                 {
                     strQry = "Execute dbo.usp_log @command='ChangePassParent',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     if (sExecuteQuery(strQry) != -1)
                     {
                         MessageBox("Password Changed Successfully ");
                         Clear();
                     }
                 }
                 else if (Convert.ToString(Session["strUserType"]) == "3")
                 {
                     strQry = "Execute dbo.usp_log @command='ChangePassTeacher',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     if (sExecuteQuery(strQry) != -1)
                     {
                         MessageBox("Password Changed Successfully ");
                         Clear();
                     }
                 }
                 else if (Convert.ToString(Session["strUserType"]) == "4")
                 {
                     strQry = "Execute dbo.usp_log @command='ChangePassStaff',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     if (sExecuteQuery(strQry) != -1)
                     {
                         MessageBox("Password Changed Successfully ");
                         Clear();
                     }
                 }
                 else if (Convert.ToString(Session["strUserType"]) == "5")
                 {
                     strQry = "Execute dbo.usp_log @command='ChangePassAdmin',@intUser_id='" + Convert.ToString(Session["User_id"]) + "',@vchOldPassword='" + oldpass + "',@vchNewPassword='" + confpass + "',@intChangePass_by='" + Convert.ToString(Session["User_id"]) + "',@ChangePass_IP='" + GetSystemIP() + "'";
                     //if (sExecuteQuery(strQry) != -1)
                     //{
                     int x = sExecuteQuery(strQry);
                     if (x != 0)
                     {
                         MessageBox("Password Changed Successfully ");
                         Clear();
                     }
                     else
                     {
                         MessageBox("Please Enter Correct Password!");
                     }
                 }
             }
             else
             {
                 lblCaptchaResult.Text = "Entered Text is incorrect";
             }
             CreateRandomString(6);
        }
        catch
        {

        }
    }
    //protected void btnclr_Click(object sender, EventArgs e)
    //{
    //    Clear();
    //}
}
