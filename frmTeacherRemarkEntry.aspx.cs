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

public partial class frmTeacherRemarkEntry : DBUtility
{
    int leaveval;
    int str;
    int Leavegrid;
    int Leavegrid1;
 

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Teacher's Remark";
          

                if (!IsPostBack)
                {
                    row2.Visible = false;
                    row3.Visible = false;
                    row4.Visible = false;
                    row5.Visible = false;
                 
                    filldata();
                }
           
           
        }
        catch
        {
            throw;
        
        }
    }
 
       protected void filldata()
    {
        try
        {

            string query1 = "Execute dbo.usp_Profile @command='ReTeStandard',@intSchool_id='" + Session["School_id"] + "'";
            if (Convert.ToString(Session["UserType_id"]) != "5")
            {
                query1 = query1 + ",@intUser_id='" + Session["User_id"] + "' ";
            }
            bool st = sBindDropDownList(DropDownList1, query1,"vchStandard_name", "intStandard_id");
        }
        catch 
        {
        
        }
    }
  

    protected void DropDownDropcalender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int stat = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            row2.Visible = true;
            string query2 = "Execute dbo.usp_Profile @command='ReTeDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "',@intUser_id='" + Session["User_id"] + "' ";
            bool st2 = sBindDropDownList(DropDownList2, query2, "vchDivisionName", "intDivision_id");
        }
        catch
        {
        
        }
        }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int stat1 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            int Div1 = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            row3.Visible = true;
            string query3 = "Execute dbo.usp_Profile @command='RemarkRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "' ";

            bool st3 = sBindDropDownList(DropDownList3, query3, "Name", "intStudent_id");
        }
        catch 
        {
        
        }
    }


    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        row5.Visible = true;
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int stat3 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            row4.Visible = true;
            string query4 = "Execute dbo.usp_Profile @command='RemarkSubject',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + stat3 + "' ";
            bool st4 = sBindDropDownList(DropDownList4, query4, "vchSubjectName", "intSubject_id");
        }
        catch 
        {
        
        }
        }
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {

            int stat3 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            int Div1 = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            int Roll1 = Convert.ToInt32(DropDownList3.SelectedItem.Value);
            int Sub1 = Convert.ToInt32(DropDownList4.SelectedItem.Value);
            string rem1 = TextArea1.Value;

            long insertby = Convert.ToInt64(Session["User_id"]);

            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            string ipval = GetSystemIP();



            string instremaquery1 = "Execute dbo.usp_Profile @command='InsertTeachRemark',@intStudent_id='" + Roll1 + "',@intStandard_id='" + stat3 + "',@intDivision_id='" + Div1 + "',@intTeacher_id='" + insertby + "',@intSubject_id='" + Sub1 + "',@vchTeacherRemark1='" + rem1 + "',@intInsert_By='" + insertby + "',@dtInsertedDate='" + insertdt + "',@fltinsertIP='" + ipval + "',@intschool_id='" + Session["School_id"] + "'";

            int result1 = sExecuteQuery(instremaquery1);


            if (result1 != -1)
            {
                string display = "Teacher Remark Submit!";
                MessageBox(display);
                Clear();

            }
            else
            {
                MessageBox("ooopppsss!Teacher Remark Failed");
                Response.Redirect("http://localhost:5515/InnerMaster/frmIndex.aspx");
            }


        }
        catch 
        {
        
        }
    }
    public void Clear()
    {
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList3.Items.Clear();
        DropDownList4.Items.Clear();
    TextArea1.Value="";
    row2.Visible = false;
    row3.Visible = false;
    row4.Visible = false;
    row5.Visible = false;

    filldata();
    
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

}
