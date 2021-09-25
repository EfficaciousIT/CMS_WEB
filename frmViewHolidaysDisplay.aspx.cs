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

public partial class frmViewHolidaysDisplay : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["userstatus"] = "student";

        if (Session["userstatus"].ToString() == "student" || Session["userstatus"].ToString() == "parent")
        {
   
            TabHoliDetai.Visible = Convert.ToBoolean("true");
            TabPanelholientry.Visible = Convert.ToBoolean("false");

            gridvalholi.Visible = true;
            holival0.Visible = false;
            holival1.Visible = false;
            Gridholidetails.Visible = true;
            Gridholidetails.Columns[0].Visible = false;
            Gridholidetails.Columns[1].Visible = true;
            Gridholidetails.Columns[2].Visible = false;
            Gridholidetails.Columns[3].Visible = false;
            Gridholidetails.Columns[4].Visible = false;
            Gridholidetails.Columns[5].Visible = false;
        }
        if (Session["userstatus"].ToString() == "teacher")
        {
            TabPanelholientry.Visible = Convert.ToBoolean("false");
            TabHoliDetai.Visible = Convert.ToBoolean("true");
           
            
          
            holival0.Visible = false;
            holival1.Visible = true;
           // Gridholidetails.Visible = false;

        }
        if (Session["userstatus"].ToString() == "Staff")
        {
            gridvalholi.Visible = true;
            TabHoliDetai.Visible = Convert.ToBoolean("true");
            TabPanelholientry.Visible = Convert.ToBoolean("false");
            holival0.Visible = false;
            holival1.Visible = false;
            Gridholidetails.Visible = true;
            Gridholidetails.Columns[0].Visible = false;
            Gridholidetails.Columns[1].Visible = false;
            Gridholidetails.Columns[2].Visible = false;
            Gridholidetails.Columns[3].Visible = false;
            Gridholidetails.Columns[4].Visible = false;
            Gridholidetails.Columns[5].Visible = false;
        }
        if (Session["userstatus"].ToString() == "admin")
        {

            TabHoliDetai.Visible = Convert.ToBoolean("true");
            TabPanelholientry.Visible = Convert.ToBoolean("true");
            holival0.Visible = true;
            holival1.Visible = false;
           // Gridholidetails.Visible = false;
        }


        if (!IsPostBack)
        {
            Gridholidetails.DataSource = createDataTable();
            Gridholidetails.DataBind();

        }
    }
    
     private object createDataTable()
    {    
       
      
        DataTable dt = new DataTable();
        
        dt.Columns.Add("Student Id");
        dt.Columns.Add("Standard Id");
        dt.Columns.Add("Division Id");
        dt.Columns.Add("Department Id");
        dt.Columns.Add("Holiday Name");
        dt.Columns.Add("From Date");
        dt.Columns.Add("To Date");
        dt.Columns.Add("Total no days");
        dt.Columns.Add("Type of holiday");
        

        DataRow dr = dt.NewRow();
      
        dr["Student Id"] = "1001";
        dr["Standard Id"] = "2 nd";
        dr["Division Id"] = "B";
        dr["Department Id"] = "ST255";
        dr["Holiday Name"] = "Independence Day";
        dr["From Date"] = "15-08-2014";
        dr["To Date"] = "15-08-2014";
        dr["Total no days"] = "1";
        dr["Type of holiday"] = "Bank Holiday";
       
        dt.Rows.Add(dr);


        return dt;
    }
     protected void Gridholidetails_PageIndexChanging(object sender, EventArgs e)
     {

     }
     protected void Gridholidetails_RowCancelingEdit(object sender, EventArgs e)
     {

     }
     protected void Gridholidetails_RowDeleting(object sender, EventArgs e)
     {

     }
     protected void Gridholidetails_RowEditing(object sender, EventArgs e)
     {

     }
     protected void Gridholidetails_SelectedIndexChanged(object sender, EventArgs e)
     {

     }
   // Dropholiadmin_SelectedIndexChanged
     protected void Dropholiadmin_SelectedIndexChanged(object sender, EventArgs e)
     {

         string val1 = ((DropDownList)sender).SelectedValue;
         if (val1 == "student")
         {

             gridvalholi.Visible = true;

             Gridholidetails.Columns[0].Visible = true;
             Gridholidetails.Columns[1].Visible = true;
             Gridholidetails.Columns[2].Visible = true;
             Gridholidetails.Columns[3].Visible = true;
             Gridholidetails.Columns[4].Visible = true;
             Gridholidetails.Columns[5].Visible = false;
             
             


         }
         else
         {

             gridvalholi.Visible = true;
             Gridholidetails.Columns[0].Visible = true;
             Gridholidetails.Columns[1].Visible = true;
             Gridholidetails.Columns[2].Visible = false;
             Gridholidetails.Columns[3].Visible = false;
             Gridholidetails.Columns[4].Visible = false;
             Gridholidetails.Columns[5].Visible = true;
            

         }

     }



     protected void Dropholitech_SelectedIndexChanged(object sender, EventArgs e)
     {

         string val1 = ((DropDownList)sender).SelectedValue;
         if (val1 == "student")
         {

             gridvalholi.Visible = true;

             Gridholidetails.Columns[0].Visible = false;
             Gridholidetails.Columns[1].Visible = false;
             Gridholidetails.Columns[2].Visible = false;
             Gridholidetails.Columns[3].Visible = false;
             Gridholidetails.Columns[4].Visible = false;
             Gridholidetails.Columns[5].Visible = false;
             Gridholidetails.Columns[6].Visible = true;
            


         }
         else
         {

             gridvalholi.Visible = true;
             Gridholidetails.Columns[0].Visible = false;
             Gridholidetails.Columns[1].Visible = false;
             Gridholidetails.Columns[2].Visible = false;
             Gridholidetails.Columns[3].Visible = false;
             Gridholidetails.Columns[4].Visible = false;
             Gridholidetails.Columns[5].Visible = false;
             Gridholidetails.Columns[6].Visible = true;
           

         }

     }
     protected void Gridholidetails_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             LinkButton img = (LinkButton)e.Row.FindControl("lnkview");
             img.Attributes.Add("onclick", "window.open('http://en.wikipedia.org/wiki/Independence_Day_(India)','_blank',scrollbar=true,'toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=120,left=200');return false");
         }
     }
}
