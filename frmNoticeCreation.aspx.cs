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

public partial class frmNoticeCreation : DBUtility
{
    int leaveval;
    int str;
    int Leavegrid;
    int Leavegrid1;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            TabContainer1.Visible = true;
            HiddenTodayDate.Text = DateTime.Today.ToShortDateString();
            //TabPanel5.Visible = false;
            if (!IsPostBack)
            {
                
                R1.Visible = false;
                R2.Visible = false;
                R3.Visible = false;
                R4.Visible = false;
                R5.Visible = false;
                   
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

        string queryp1 = "Execute dbo.usp_idcard @command='selectTypeofuser',@intSchool_id='" + Session["School_id"] + "' ";
        bool stcardp = sBindDropDownList(DropDownList4, queryp1, "vchUser_name", "intUserType_id");

        string queryp2 = "Execute dbo.usp_idcard @command='SelectDepartment',@intSchool_id='" + Session["School_id"] + "' ";
        bool stcardp2 = sBindDropDownList(DropDownList5, queryp2, "vchDepartment_name", "intDepartment");

      

        string query1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
        bool st = sBindDropDownList(DropDownList1, query1, "Standard_name", "intStandard_id");    
    
    }
  

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {


    }
    protected void DropDownDropcalender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        //{
            
        //    int typeid = Convert.ToInt32(DropDownList4.SelectedItem.Value);
            

        //    string Dofi = Convert.ToDateTime(TextBox5.Text).ToString("MM/dd/yyyy");
        //    string Dofe = Convert.ToDateTime(TextBox7.Text).ToString("MM/dd/yyyy");
        //    string DofA = Convert.ToDateTime(TextBox12.Text).ToString("MM/dd/yyyy");
            
            

        //    string yearb1 = DateTime.Now.AddYears(-1).Year.ToString();
           
        //    string yearn1 = DateTime.Now.Year.ToString();
        //    string yearv1 = yearb1 + '-' + yearn1;


        //    long insertby = Convert.ToInt64(Session["User_id"]);

        //    string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

        //    string ipval = GetSystemIP();

        //    string instremaquery1 = null;
        //    if (typeid == 1 || typeid == 2)
        //    {
        //        int stat3 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
        //        int Div1 = Convert.ToInt32(DropDownList2.SelectedItem.Value);
        //        int Roll1 = Convert.ToInt32(DropDownList3.SelectedItem.Value);
        //        instremaquery1 = "Execute dbo.usp_idcard @command='StudCardAssignment',@intUserType_id='" + typeid + "',@intUser_id='" + insertby + "',@intCard_id='" + cid + "',@vchCard_no='" + cno + "',@intAcademicYear_id='" + yearv1 + "',@intStandard_id='" + stat3 + "',@intDivision_id='" + Div1 + "',@intStudent_id='" + Roll1 + "',@dtCardIssueDate='" + Dofi + "',@dtCardExpireDate='" + Dofe + "',@dtActivationDate='" + DofA + "',@intActivationUser_id='" + insertby + "',@vchActive_status='Active',@intInsertedUser_id='" + insertby + "',@dtInsertedDate='" + insertdt + "',@fltIP='" + ipval + "',@intschool_id='" + Session["School_id"] + "'";
        //    }
        //    else
        //    {
        //        int depid = Convert.ToInt32(DropDownList5.SelectedItem.Value);
        //        int staffid = Convert.ToInt32(DropDownList6.SelectedItem.Value);
        //        instremaquery1 = "Execute dbo.usp_idcard @command='StudCardAssignment',@intUserType_id='" + typeid + "',@intUser_id='" + insertby + "',@intCard_id='" + cid + "',@vchCard_no='" + cno + "',@intAcademicYear_id='" + yearv1 + "',@intDepartment_id='" + depid + "',@intTeacher_id='" + staffid + "',@dtCardIssueDate='" + Dofi + "',@dtCardExpireDate='" + Dofe + "',@dtActivationDate='" + DofA + "',@intActivationUser_id='" + insertby + "',@vchActive_status='Active',@intInsertedUser_id='" + insertby + "',@dtInsertedDate='" + insertdt + "',@fltIP='" + ipval + "',@intschool_id='" + Session["School_id"] + "'";

        //    }

        //    int result1 = sExecuteQuery(instremaquery1);

        //    ///update tblCard_master set btAssign='1' where intCard_id=@intCard_id and vchCardNo=@vchCard_no and intschool_id=@intschool_id

        //    string Updateque1 = "Execute dbo.usp_idcard @command='UpdateCard',@intCard_id='" + cid + "',@vchCard_no='" + cno + "',@intschool_id='" + Session["School_id"] + "'";

        //    int result2 = sExecuteQuery(Updateque1);


        //    if (result1 != -1)
        //    {
        //        string display = "Card Assigned Successfully!";
        //        MessageBox(display);
        //        Clear();
        //    }
        //    else
        //    {
        //        MessageBox("ooopppsss!Card Assignment Failed");

        //    }

        //}
        //catch
        //{
        
        //}
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
            // return msg;
        }
    }
    protected void Clear()
    {

        try
        {
            
           
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            DropDownList4.Items.Clear();

            DropDownList5.Items.Clear();
            DropDownList6.Items.Clear();
            TextBox5.Text = "";
            TextBox7.Text = "";
            TextBox12.Text = "";
            gridfill();
        }
        catch
        {
        
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            

            int stat = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            
            string query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
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
            int statv1 = Convert.ToInt32(DropDownList1.SelectedItem.Value);


              int stat1 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                int Div1 = Convert.ToInt32(DropDownList2.SelectedItem.Value);

                string query3 = "Execute dbo.usp_Profile @command='RemarkRollNo1',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "' ";

                bool st3 = sBindDropDownList(DropDownList3, query3, "Name", "intStudent_id");
           
            }
        catch
        {

        }



    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
     string selval=Convert.ToString(DropDownList4.SelectedItem.Value);
     if (selval == "1" || selval == "2")
        {
            R1.Visible = true;
            R2.Visible = true;
            R3.Visible = true;
            R4.Visible = false;
            R5.Visible = false;
        
        }
        else
        {
            R1.Visible = false;
            R2.Visible = false;
            R3.Visible = false;
            R4.Visible = true;
            R5.Visible = true;

        }

    }
    protected void DropDownListcard_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            int typeid = Convert.ToInt32(DropDownList4.SelectedItem.Value);

            int depid = Convert.ToInt32(DropDownList5.SelectedItem.Value);

            string query2 = "Execute dbo.usp_idcard @command='SelectStaffId',@intSchool_id='" + Session["School_id"] + "',@intDepartment_id='" + depid + "',@intUserType_id='" + typeid + "' ";

            bool st3 = sBindDropDownList(DropDownList6, query2, "Name", "intTeacher_id");
           
        
        }
        catch
        { 
        
        }



    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

   
    

 

