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
using System.Data.SqlClient;
using System.Globalization;

public partial class frmStudentLeaveMenu : DBUtility
{
    int leaveval;
    int str;
    int Leavegrid;
    int Leavegrid1;
 

    protected void Page_Load(object sender, EventArgs e)
    {
      
        try
        {
            //Label lblTitle = new Label();
            //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            //lblTitle.Visible = true;
            //lblTitle.Text = "Leave Application Detail";
            if (!IsPostBack)
            {
               
                checksession();
                geturl();
                DropDownList5.SelectedValue = DateTime.Now.Month.ToString();



                TabContainer1.Visible = true;


                gridfill();

            }
        }
        catch
        {
            throw;
        
        }
    }
    protected void gridfill()
    {
        string Disquery = "Execute dbo.usp_Leave @command='gridfillPending',@intStudent_id='" + Session["Student_id"] + "'";
        Leavegrid = sBindGrid(GridView5, Disquery);

        string DisRepoquery = "Execute dbo.usp_Leave @command='gridfill',@intStudent_id='" + Session["Student_id"] + "'";
        Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);


        string query1 = "Execute dbo.usp_Leave @command='Leave_Type',@intSchool_id='" + Session["School_id"] + "',@intRole_Id='" + Session["UserType_id"] + "'";
        bool st = sBindDropDownList(droptype, query1, "vchLeaveType_name", "intLeaveType_id");
        //droptype
        
    }
    

  


    protected void GridView1_PageIndexChanging(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowCancelingEdit(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowDeleting(object sender, EventArgs e)
    {

    }
    protected void GridView2_RowEditing(object sender, EventArgs e)
    {

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtfromdate.Text !="" && txttodate.Text!="" )
            {
            DateTime startdate = DateTime.ParseExact(txtfromdate.Text.ToString().Trim(), "dd/MM/yyyy", null);
            DateTime enddate = DateTime.ParseExact(txttodate.Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            TimeSpan t = enddate.Subtract(startdate);

            int val = Convert.ToInt32(t.Days);
            if (val < 0)
            {
                Label2.Text = "Total Leave Days Not Be Less Than Zero";
                txtNoofDays.Text = "";
                txttodate.Text = "";
            }
            else
            {
                Label2.Text = "";

                txtNoofDays.Text = Convert.ToString(t.Days+1);
            }
            }
        }
        catch
        {
            throw;
        }
    }
    protected void DropDownDropcalender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(txtNoofDays.Text) >= 0)
            {
                leaveval = Convert.ToInt32(Radioleave.SelectedItem.Value);

                string dtfromdate = Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy");
                string dttodate = Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");
                string textareaval = Convert.ToString(content.Text);
                string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

                string Totalval = txtNoofDays.Text;
                string ipval = GetSystemIP();

                string droptypevl = droptype.SelectedItem.Value;

                string instrquery1 = "Execute dbo.usp_Leave @command='insert' ,@intUser_id='0',@intUserType_id='" + Session["strUserType"] + "',@intType_id='" + Convert.ToString(leaveval).Trim() + "',@intStudent_id='" + Session["Student_id"] + "',@dtFrom_date='" + dtfromdate + "',@dtTo_Date='" + dttodate + "',@vchReason='" + Convert.ToString(textareaval).Trim() + "',@intTotalDays='" + Convert.ToString(Totalval).Trim() + "',@dtInsertDate='" + insertdt + "',@insertIP='" + ipval + "',@intInsertedBy='" + Session["User_id"] + "',@dtApplication_date='" + insertdt + "',@bitParentApproval=0,@bitTeacherApproval=0,@intSchool_id='" + Session["School_id"] + "',@intLeaveType_id='" + droptypevl + "'";

                str = sExecuteQuery(instrquery1);
                if (str != -1)
                {
                    string display = "Leave Application Submit!";
                    MessageBox(display);
                   
                    TabContainer1.ActiveTabIndex = 1;
                    Clear();
                    gridfill();

                }
                else
                {
                    MessageBox("ooopppsss!Leave Application Failed");

                }
            }
            else 
            {

                txtNoofDays.Text = "";
                txttodate.Text = "";
            }
        }

        catch (Exception Ex)
        {


        }

    }
    public void Clear()
    {
        Radioleave.ClearSelection();
        txtfromdate.Text = "";
        txttodate.Text = "";
        txtNoofDays.Text = "";
        content.Text = "";
        Label2.Text = "";
        droptype.SelectedValue = "0";
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
            throw;
            // return msg;
        }
    }
     
    protected void check_val(object sender, EventArgs e)
    {
        try
        {
            int val = Convert.ToInt32(txtNoofDays.Text);
            if (val <= 0)
            {
                Response.Write("Value Not Be Less Than Zero");
            }
        }
        catch 
        {

            throw;
        
        }
    }

    protected void clod(object sender, EventArgs e)
    {
         }
    protected void cleartodata(object sender, EventArgs e)
    {
        //txttodate.Text = "";

        try
        {
            if (txttodate.Text != "")
            {
                DateTime startdate = DateTime.ParseExact(txtfromdate.Text.ToString().Trim(), "dd/MM/yyyy", null);
                DateTime enddate = DateTime.ParseExact(txttodate.Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                TimeSpan t = enddate.Subtract(startdate);

                int val = Convert.ToInt32(t.Days);
                if (val < 0)
                {
                    //Label2.Text = "Value not be less then zero";
                    txtNoofDays.Text = "";
                    txttodate.Text = "";
                }
                else
                {
                    Label2.Text = "";

                    txtNoofDays.Text = Convert.ToString(t.Days+1);
                }
            }
        }
        catch
        {
            throw;
        }

    
    }
    protected void Radioleave_SelectedIndexChanged(object sender, EventArgs e)
    {
        string  Radiol=Radioleave.SelectedItem.Value;
        if (Radiol == "0")
        {
            radio1.Visible = true;

        }
        else 
        {
            radio1.Visible = false;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        int monid = Convert.ToInt32(DropDownList5.SelectedItem.Value);

        string DisRepoquery = "Execute dbo.usp_Leave @command='gridfillMon',@intStudent_id='" + Session["Student_id"] + "',@month_id='" + monid + "'";
        Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);
    }
}
