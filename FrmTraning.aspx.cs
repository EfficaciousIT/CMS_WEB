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

public partial class FrmTraning : DBUtility
{
    DataSet dsObj = new DataSet();
    string strQry = "";
    int i = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["userstatus"].ToString() == "student" || Session["userstatus"].ToString() == "parent")
        {
            
        }
     
        if (Session["userstatus"].ToString() == "teacher")
        {
            
        }
        if (Session["userstatus"].ToString() == "Staff")
        {
   
            

        }
        if (Session["userstatus"].ToString() == "admin")
        {
            Tran1.Visible = true;
            Tran2.Visible = true;
            Tran3.Visible = true;
            Tran4.Visible = true;

            Traningentry.Visible = Convert.ToBoolean("true");
        }

        if (!IsPostBack)
        {
            //GridView2.DataSource = createDataTable();
            //GridView2.DataBind();
            //Gridlistlostdetails.DataSource = createDataTable1();
            //Gridlistlostdetails.DataBind();
            //GridViewTempDis.DataSource = createDataTable2();
            //GridViewTempDis.DataBind();
            //Gridlistpendingtem.DataSource = createDataTable3();
            //Gridlistpendingtem.DataBind();


        }

    }


    protected void DropDownTran1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    
    protected void DropDownTran2_SelectedIndexChanged(object sender, EventArgs e)
     {

        string val1 = ((DropDownList)sender).SelectedValue;
        
        if (val1 == "student" || val1 == "Parents")
        {
            Tran5.Visible = true;

            Tran6.Visible = false;
        }
        else
        {
            Tran5.Visible = false;
            Tran6.Visible = true;
        }
        }

    protected void DropDownTran4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

     protected void DropDownTran5_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

     protected void DropDownTran6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

     protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }


     protected void DropDownt_SelectedIndexChanged(object sender, EventArgs e)
     {
         string val1 = ((DropDownList)sender).SelectedValue;

         if (val1 == "student" || val1 == "Parents")
         {
             Tran5.Visible = true;

         }
         else
         {
             Tran6.Visible = true;
         }
     }
}