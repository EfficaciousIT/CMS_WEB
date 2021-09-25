using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmEquiry_Form : DBUtility
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Enquiry Detail";
            if (!IsPostBack)
            {

                checksession();
                geturl();
            }
            geturl();
           
            checksession();
        }
        catch(Exception)
        {
        }
    }
   

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string schoolnm, contacnm, address, city, state, country, tele, email;
            schoolnm = Convert.ToString(TextBox1.Text);
            contacnm = Convert.ToString(TextBox2.Text);
            address = Convert.ToString(TextBox3.Text);
            city = Convert.ToString(TextBox4.Text);
            state = Convert.ToString(TextBox5.Text);
            country = Convert.ToString(TextBox6.Text);
            tele = Convert.ToString(TextBox7.Text);
            email = Convert.ToString(TextBox8.Text);

            long insertby = Convert.ToInt64(Session["User_id"]);

            string ipval = GetSystemIP();

            
            string instremaquery1 = "Execute dbo.usp_Enquiry @command='Insert_Enquiry',@vchSchool_Name='" + schoolnm + "',@vchContact_Name='" + contacnm + "',@vchAddress='" + address + "',@intSchool_id='" + Session["School_id"] + "',@vchCity='" + city + "',@vchState='" + state + "',@vchCountry='" + country + "',@vchTelephone='" + tele + "',@vchEmail='"+ email +"',@vchInsertedIP='"+ ipval+"'";

            int result1 = sExecuteQuery(instremaquery1);
            if (result1 != -1)
            {
                string display = "Enquiry Save Successfully!";
                MessageBox(display);
                
                Clear();
                Button1.Enabled = false;
                
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
    public void Clear()
        {

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
    
    
    }
}