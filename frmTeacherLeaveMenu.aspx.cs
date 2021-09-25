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

public partial class frmTeacherLeaveMenu : DBUtility
{
    int leaveval;
    int str;
    int Leavegrid;
    int Leavegrid1, Leavegrid2;
    string strQry = "";
    DataSet dsObj;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Label lblTitle = new Label();
            //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            //lblTitle.Visible = true;
            //lblTitle.Text = "Leave Application";
            if (!IsPostBack)
            {
                checksession();
                geturl();

            }

            //CompareValidator1.ValueToCompare = DateTime.Today.ToShortDateString();

           

                TabContainer1.Visible = true;

                //TabPanel5.Visible = false;
                if (!IsPostBack)
                {
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
        try
        {
            string query1 = "Execute dbo.usp_Leave @command='LeaveType',@intSchool_id='" + Session["School_id"] + "',@intRole_Id='" + Session["UserType_id"] + "'";
            bool st = sBindDropDownList(drop1, query1, "leavenm", "intLeaveType_id");

            string Disquery = "Execute dbo.usp_Leave @command='gridfillPendingTeach',@intTeacher_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
            Leavegrid = sBindGrid(GridView5, Disquery);

            string DisRepoquery = "Execute dbo.usp_Leave @command='gridfillTeach',@intTeacher_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
            Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);

            string DisRepoquery1 = "Execute dbo.usp_Leave @command='PendingLeave',@intTeacher_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
            Leavegrid2 = sBindGrid(GridView1, DisRepoquery1);
        
        
        }
        catch 
        {
        }

        
    }
   

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        gridfill();
       
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
                Label2.Text = "Total Leave Days not be less then zero";
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
                int leavety = Convert.ToInt32(drop1.SelectedItem.Value);
                string dtfromdate = Convert.ToDateTime(txtfromdate.Text).ToString("MM/dd/yyyy");
                string dttodate = Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");
                string textareaval = Convert.ToString(content.Value);
                string insertdt = DateTime.Now.ToString("MM/dd/yyyy");
                DateTime _date = DateTime.Now;
                int intAcademicYear_id=_date.Year;
                string Totalval = txtNoofDays.Text;
                string ipval = GetSystemIP();
                string instrquery1 = "Execute dbo.usp_Leave @command='insertTeach' ,@intUser_id='" + Session["User_id"] + "',@intType_id='" + Convert.ToString(leaveval).Trim() + "',@intTeacher_id='" + Session["User_id"] + "',@dtFrom_date='" + dtfromdate + "',@dtTo_Date='" + dttodate + "',@vchReason='" + Convert.ToString(textareaval).Trim() + "',@intTotalDays='" + Convert.ToString(Totalval).Trim() + "',@dtInsertDate='" + insertdt + "',@insertIP='" + ipval + "',@intInsertedBy='" + Session["User_id"] + "',@dtApplication_date='" + insertdt + "',@bitAdminApproval=0,@intSchool_id='" + Session["School_id"] + "',@intAcademicYear_id='" + intAcademicYear_id + "',@intLeaveType_id='" + leavety + "',@intStudent_id=0,@intUserType_id='" + Session["UserType_id"] + "'";

                str = sExecuteQuery(instrquery1);
                if (str != -1)
                {
                    string display = "Leave Application Submit!";
                    MessageBox(display);
                   // Button1.Enabled = false;
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
        content.InnerText = "";

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
                Response.Write("value not be less then zero");
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
    protected void drop1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        gridfill();
    }
    protected void GridView5_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intLeaveApplocation_id"] = Convert.ToString(GridView5.DataKeys[e.NewEditIndex].Value);

            string value = (GridView5.Rows[0].FindControl("rdbAction") as RadioButtonList).SelectedValue;
            if ((GridView5.Rows[0].FindControl("rdbAction") as RadioButtonList).SelectedValue == "")
            {
                MessageBox("Please Select Status!");
                return;
            }
            strQry = "";
            strQry = "exec usp_Leave @command='ApprovalStatus',@intLeaveApplocation_id='" + Convert.ToString(Session["intLeaveApplocation_id"]) + "',@bitAdminApproval='" + value + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application Submit Successfully!');window.location ='frmTeacherLeaveMenu.aspx';", true);
               // MessageBox("Application Submit Successfully!");
            }
        }
        catch
        {

        }
    }
}
