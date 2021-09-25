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

public partial class frmIndex : DBUtility
{
    string strUserType = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Redirect("index.aspx", false);
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
            if(Convert.ToString( Session["UserType_id"] )=="1" || Convert.ToString( Session["UserType_id"] )=="2")
            {
                 Response.Redirect("frmStudentDashboard.aspx", false);

            }
            else if(Convert.ToString( Session["UserType_id"] )=="3")
            {
                Response.Redirect("frmStaffDashboard.aspx", false);
            }
            else if(Convert.ToString( Session["UserType_id"] )=="5")
            {
                Response.Redirect("frmAdminDashboard.aspx", false);
            }
          //  Response.Redirect("frmAttendance.aspx", false);

        }
        else
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            MessageBox("Invalid Authentication !!!!!");
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
}
