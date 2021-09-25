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

public partial class frmAdmStaffProDetai :DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Staff Profile Entry";
            if (!IsPostBack)
            {
                checksession();
                geturl();



            }


            txtvchmake0.Visible = false;

            txtvchmake.Visible = false;

            TextBox11.Visible = false;


            TextBox1.Visible = false;
            TextBox2.Visible = false;

            TextBox4.Visible = false;
            TextBox5.Visible = false;

            TextBox8.Visible = false;
            TextBox9.Visible = false;
            TextBox10.Visible = false;
            TextBox12.Visible = false;
            TextBox14.Visible = false;
            //    DropDownList1.Visible = false;
            TextBox13.Visible = false;
            TextBox15.Visible = false;
            TextBox16.Visible = false;
            TextBox17.Visible = false;
            DropDownList2.Visible = false;
            DropDownList3.Visible = false;
            DropDownList4.Visible = false;
            DropDownList5.Visible = false;

        }
        catch(Exception ex) 
        { 
        
        }
    }


    protected void TextBox15_TextChanged(object sender, EventArgs e)
    {

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
  
    }
}