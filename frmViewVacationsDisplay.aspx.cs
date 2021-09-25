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

public partial class frmViewVacationsDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["userstatus"] = "student";
        
        if (Session["userstatus"].ToString() == "student" || Session["userstatus"].ToString() == "parent")
        {

            TabPanelholientry.Visible = false;
            vacatval0.Visible = false;
            vacatval1.Visible = false;
            GridVacation.Visible = true;

            Gridvacadetails.Columns[0].Visible = false;
            Gridvacadetails.Columns[1].Visible = true;
            Gridvacadetails.Columns[2].Visible = false;
            Gridvacadetails.Columns[3].Visible = false;
            Gridvacadetails.Columns[4].Visible = false;
            Gridvacadetails.Columns[5].Visible = false;
            //TabHoliDetai.Visible = Convert.ToBoolean("true");
            //TabPanelholientry.Visible = Convert.ToBoolean("false");

            //gridvalholi.Visible = true;
            //holival0.Visible = false;
            //holival1.Visible = false;
            //Gridholidetails.Visible = true;
            //Gridholidetails.Columns[0].Visible = false;
            //Gridholidetails.Columns[1].Visible = false;
            //Gridholidetails.Columns[2].Visible = false;
            //Gridholidetails.Columns[3].Visible = false;
            //Gridholidetails.Columns[4].Visible = false;
            //Gridholidetails.Columns[5].Visible = false;
        }
        if (Session["userstatus"].ToString() == "teacher")
        {

            TabPanelholientry.Visible = false;
            vacatval0.Visible = false;
            vacatval1.Visible = true;
            GridVacation.Visible = false;
            //TabPanelholientry.Visible = Convert.ToBoolean("false");
            //TabHoliDetai.Visible = Convert.ToBoolean("true");



            //holival0.Visible = false;
            //holival1.Visible = true;
            // Gridholidetails.Visible = false;

        }
        if (Session["userstatus"].ToString() == "Staff")
        {
            vacatval0.Visible = false;
            vacatval1.Visible = false;
            TabPanelholientry.Visible = false;
            GridVacation.Visible = true;
            Gridvacadetails.Columns[0].Visible = false;
            Gridvacadetails.Columns[1].Visible = false;
            Gridvacadetails.Columns[2].Visible = false;
            Gridvacadetails.Columns[3].Visible = false;
            Gridvacadetails.Columns[4].Visible = false;
            Gridvacadetails.Columns[5].Visible = false;
            //TabHoliDetai.Visible = Convert.ToBoolean("true");
            //TabHolientry.Visible = Convert.ToBoolean("false");
            //holival0.Visible = false;
            //holival1.Visible = false;
            //Gridholidetails.Visible = true;
            //Gridholidetails.Columns[0].Visible = false;
            //Gridholidetails.Columns[1].Visible = false;
            //Gridholidetails.Columns[2].Visible = false;
            //Gridholidetails.Columns[3].Visible = false;
            //Gridholidetails.Columns[4].Visible = false;
            //Gridholidetails.Columns[5].Visible = false;
        }
        if (Session["userstatus"].ToString() == "admin")
        {
            TabPanelholientry.Visible = true;
            vacatval0.Visible = true;
            vacatval1.Visible = false;
            GridVacation.Visible = false;
            //TabHoliDetai.Visible = Convert.ToBoolean("true");
            //TabPanelholientry.Visible = Convert.ToBoolean("true");
            //holival0.Visible = true;
            //holival1.Visible = false;
            //Gridholidetails.Visible = false;
        }


        if (!IsPostBack)
                {
                    Gridvacadetails.DataSource = createDataTable();
                    Gridvacadetails.DataBind();
                   
                }
    }
     private object createDataTable()
    {    
       
      
        DataTable dt = new DataTable();
        
        dt.Columns.Add("Student Id");
        dt.Columns.Add("Standard Id");
        dt.Columns.Add("Division Id");
        dt.Columns.Add("Department Id");
        dt.Columns.Add("Vacations Name");
        dt.Columns.Add("From Date");
        dt.Columns.Add("To Date");
        dt.Columns.Add("Total no days");
        dt.Columns.Add("Type of Vacations");
        

        DataRow dr = dt.NewRow();
         
        dr["Student Id"] = "7001";
         dr["Standard Id"] = "4 th";
         dr["Division Id"] = "A";
         dr["Department Id"] = "D102";
         dr["Vacations Name"] = "Ganpathi vacation";
        dr["From Date"] = "29-08-2014";
        dr["To Date"] = "02-09-2014";
        dr["Total no days"] = "10";
        dr["Type of Vacations"] = "Ganpathi vacation";
       
        dt.Rows.Add(dr);


        return dt;
    }


     protected void Dropvacatiadmin_SelectedIndexChanged(object sender, EventArgs e)
     {

         string val1 = ((DropDownList)sender).SelectedValue;
         if (val1 == "student")
         {
             GridVacation.Visible = true;


             Gridvacadetails.Columns[0].Visible = true;
             Gridvacadetails.Columns[1].Visible = true;
             Gridvacadetails.Columns[2].Visible = true;
             Gridvacadetails.Columns[3].Visible = true;
             Gridvacadetails.Columns[4].Visible = true;
             Gridvacadetails.Columns[5].Visible = false;
             
             


         }
         else
         {
             GridVacation.Visible = true;

             Gridvacadetails.Columns[0].Visible = true;
             Gridvacadetails.Columns[1].Visible = true;
             Gridvacadetails.Columns[2].Visible = false;
             Gridvacadetails.Columns[3].Visible = false;
             Gridvacadetails.Columns[4].Visible = false;
             Gridvacadetails.Columns[5].Visible = true;
            

         }

     }



     protected void Drophovacat_SelectedIndexChanged(object sender, EventArgs e)
     {

         string val1 = ((DropDownList)sender).SelectedValue;
         if (val1 == "student")
         {
             GridVacation.Visible = true;


             Gridvacadetails.Columns[0].Visible = false;
             Gridvacadetails.Columns[1].Visible = false;
             Gridvacadetails.Columns[2].Visible = false;
             Gridvacadetails.Columns[3].Visible = false;
             Gridvacadetails.Columns[4].Visible = false;
             Gridvacadetails.Columns[5].Visible = false;
             Gridvacadetails.Columns[6].Visible = false;
            


         }
         else
         {
             GridVacation.Visible = true;

             Gridvacadetails.Columns[0].Visible = false;
             Gridvacadetails.Columns[1].Visible = false;
             Gridvacadetails.Columns[2].Visible = false;
             Gridvacadetails.Columns[3].Visible = false;
             Gridvacadetails.Columns[4].Visible = false;
             Gridvacadetails.Columns[5].Visible = false;
             Gridvacadetails.Columns[6].Visible = true;
           

         }

     }
     protected void Gridvacadetails_PageIndexChanging(object sender, EventArgs e)
     {

     }
     protected void Gridvacadetails_RowCancelingEdit(object sender, EventArgs e)
     {

     }
     protected void Gridvacadetails_RowDeleting(object sender, EventArgs e)
     {

     }
     protected void Gridvacadetails_RowEditing(object sender, EventArgs e)
     {

     }
     protected void Gridvacadetails_SelectedIndexChanged(object sender, EventArgs e)
     {

     }

     protected void Gridvacadetails_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             LinkButton img = (LinkButton)e.Row.FindControl("lnkview");
             img.Attributes.Add("onclick", "window.open('http://en.wikipedia.org/wiki/Ganesh_Chaturthi','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=600,width=900,top=120,left=200');return false");
         }
     }
}
