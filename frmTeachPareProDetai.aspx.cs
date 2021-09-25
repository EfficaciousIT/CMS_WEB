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

public partial class frmTeachPareProDetai :DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {

            if (!IsPostBack)
            {
                checksession();
                geturl();
        
            
            }
            //id1h1.Visible = true;

            //txtvchmake5.Visible = false;

            //   txtvchmake13.Visible = false;
            //  txtvchmake9.Visible = false;
            //  txtvchmake10.Visible = false;
            txtvchmake0.Visible = false;
            txtvchno.Visible = false;
            txtvchmake.Visible = false;
            txtvchmake1.Visible = false;
            txtvchmake2.Visible = false;
            txtvchmake3.Visible = false;
            txtvchmake4.Visible = false;
            txtvchmake7.Visible = false;
            txtvchmake6.Visible = false;
            TextBox11.Visible = false;


            TextBox1.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
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
            TextBox18.Visible = false;
            //TextBoxJ19.Visible = false;
            //TextBox19.Visible = false;
            //TextBox20.Visible = false;
            //TextBox21.Visible = false;
            //TextBox22.Visible = false;
            //TextBox23.Visible = false;
            //TextBox24.Visible = false;
            //TextBox25.Visible = false;
            //TextBox26.Visible = false;
            //TextBox27.Visible = false;
            //TextBox28.Visible = false;
            //TextBox29.Visible = false;
        }
        catch 
        {

        
        }
           
    }
 

}