using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmAdmChanPass :DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Change Password";
            if (!IsPostBack)
            {

                checksession();
                geturl();

            }
        }
        catch 
        {
        
        }
    }
    protected void ch1_ChangedPassword(object sender, EventArgs e)
    {
        int i = 0;

    }

    protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
    {
        string val=ChangePassword1.ConfirmNewPassword;
        string val1=ChangePassword1.CurrentPassword;
       // cmd = new SqlCommand("update  Admin set Password ='" + ChangePassword1.ConfirmNewPassword + "' where userid = '" + Session["userid"] + "' and Password ='" + ChangePassword1.CurrentPassword + "'", con);
       // cmd.Connection.Open();
       // cmd.ExecuteNonQuery();
       // con.Close();

    }
}