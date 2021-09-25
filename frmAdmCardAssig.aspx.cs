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

public partial class frmAdmCardAssig : DBUtility
{
    int leaveval, str, Leavegrid, Leavegrid1, cid, typeid, cno, stat3, Roll1,stat=0;
    int depid, staffid, result1, result2, statv1, stat1, Div1 = 0;
    bool st3 = true;


    public string selval = string.Empty;
    public string query2=string.Empty;
    public string queryp1=string.Empty;
    public string queryp2=string.Empty;
    public string queryc1=string.Empty;
    public string query1=string.Empty;
    public  bool stcardp,stcardp2,stcard,st,st2=true;
     public string Dofi=string.Empty;
     public string Dofe=string.Empty;
     public string DofA=string.Empty;
     public string yearb1=string.Empty;
     public string yearn1=string.Empty;
     public string yearv1=string.Empty;
     public string insertdt=string.Empty;
     public string ipval=string.Empty;
     public string instremaquery1=string.Empty;
     public string Updateque1 = string.Empty;
     public string display = string.Empty;
     public string query3 = string.Empty;
               



    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            TabContainer1.Visible = true;
            HiddenTodayDate.Text = DateTime.Today.ToShortDateString();
          
                    Label lblTitle = new Label();
                    lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                    lblTitle.Visible = true;
                    lblTitle.Text = "Card Assignment";

            if (!IsPostBack)
            {
                checksession();
                geturl();
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

        queryp1 = "Execute dbo.usp_idcard @command='selectTypeofuser',@intSchool_id='" + Session["School_id"] + "' ";
         stcardp = sBindDropDownList(DropDownList4, queryp1, "vchUser_name", "intUserType_id");


        queryp2 = "Execute dbo.usp_idcard @command='SelectDepartment',@intSchool_id='" + Session["School_id"] + "' ";
         stcardp2 = sBindDropDownList(DropDownList5, queryp2, "vchDepartment_name", "intDepartment");



         queryc1 = "Execute dbo.usp_idcard @command='CardAvailable',@intSchool_id='" + Session["School_id"] + "' ";
         stcard = sBindDropDownList(DropDownListcard, queryc1, "vchCardNo", "intCard_id");

        query1 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
        st = sBindDropDownList(DropDownList1, query1, "Standard_name", "intStandard_id");
    
    
    }
  

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {


    }
    protected void DropDownDropcalender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {



             cid = Convert.ToInt32(DropDownListcard.SelectedItem.Value);
             typeid = Convert.ToInt32(DropDownList4.SelectedItem.Value);
             cno = Convert.ToInt32(DropDownListcard.SelectedItem.Text);

             Dofi = Convert.ToDateTime(TextBox5.Text).ToString("MM/dd/yyyy");
             Dofe = Convert.ToDateTime(TextBox7.Text).ToString("MM/dd/yyyy");
             DofA = Convert.ToDateTime(TextBox12.Text).ToString("MM/dd/yyyy");
            
            

             yearb1 = DateTime.Now.AddYears(-1).Year.ToString();
           
             yearn1 = DateTime.Now.Year.ToString();
             yearv1 = yearb1 + '-' + yearn1;


            long insertby = Convert.ToInt64(Session["User_id"]);

            insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            ipval = GetSystemIP();

           
            if (typeid == 1 || typeid == 2)
            {
                 stat3 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                 Div1 = Convert.ToInt32(DropDownList2.SelectedItem.Value);
                 Roll1 = Convert.ToInt32(DropDownList3.SelectedItem.Value);
                instremaquery1 = "Execute dbo.usp_idcard @command='StudCardAssignment',@intUserType_id='" + typeid + "',@intUser_id='" + insertby + "',@intCard_id='" + cid + "',@vchCard_no='" + cno + "',@intAcademicYear_id='" + yearv1 + "',@intStandard_id='" + stat3 + "',@intDivision_id='" + Div1 + "',@intStudent_id='" + Roll1 + "',@dtCardIssueDate='" + Dofi + "',@dtCardExpireDate='" + Dofe + "',@dtActivationDate='" + DofA + "',@intActivationUser_id='" + insertby + "',@vchActive_status='Active',@intInsertedUser_id='" + insertby + "',@dtInsertedDate='" + insertdt + "',@fltIP='" + ipval + "',@intschool_id='" + Session["School_id"] + "'";
            }
            else
            {
                
                 depid = Convert.ToInt32(DropDownList5.SelectedItem.Value);
                 staffid = Convert.ToInt32(DropDownList6.SelectedItem.Value);
                instremaquery1 = "Execute dbo.usp_idcard @command='StudCardAssignment',@intUserType_id='" + typeid + "',@intUser_id='" + insertby + "',@intCard_id='" + cid + "',@vchCard_no='" + cno + "',@intAcademicYear_id='" + yearv1 + "',@intDepartment_id='" + depid + "',@intTeacher_id='" + staffid + "',@dtCardIssueDate='" + Dofi + "',@dtCardExpireDate='" + Dofe + "',@dtActivationDate='" + DofA + "',@intActivationUser_id='" + insertby + "',@vchActive_status='Active',@intInsertedUser_id='" + insertby + "',@dtInsertedDate='" + insertdt + "',@fltIP='" + ipval + "',@intschool_id='" + Session["School_id"] + "'";

            }
          

    
             result1 = sExecuteQuery(instremaquery1);

        

             Updateque1 = "Execute dbo.usp_idcard @command='UpdateCard',@intCard_id='" + cid + "',@vchCard_no='" + cno + "',@intschool_id='" + Session["School_id"] + "'";

             result2 = sExecuteQuery(Updateque1);


            if (result1 != -1)
            {
                display = "Card Assigned Successfully!";
                MessageBox(display);
                Clear();
            }
            else
            {
                MessageBox("ooopppsss!Card Assignment Failed");

            }

        }
        catch
        {
        
        }
    }
    protected void Clear()
    {

        try
        {
            DropDownListcard.Items.Clear();
           
            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            DropDownList4.Items.Clear();

            DropDownList5.Items.Clear();
            DropDownList6.Items.Clear();
            TextBox5.Text = string.Empty;
            TextBox7.Text = string.Empty;
            TextBox12.Text = string.Empty;
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
           


             stat = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            
             query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
             st2 = sBindDropDownList(DropDownList2, query2, "vchDivisionName", "intDivision_id");
     
        }
        catch
        {

        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
             statv1 = Convert.ToInt32(DropDownList1.SelectedItem.Value);


               stat1 = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                 Div1 = Convert.ToInt32(DropDownList2.SelectedItem.Value);

                query3 = "Execute dbo.usp_Profile @command='RemarkRollNo1',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat1 + "',@intDivision_id='" + Div1 + "' ";

                st3 = sBindDropDownList(DropDownList3, query3, "Name", "intStudent_id");
           
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
      selval=Convert.ToString(DropDownList4.SelectedItem.Value);
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

             typeid = Convert.ToInt32(DropDownList4.SelectedItem.Value);
             depid = Convert.ToInt32(DropDownList5.SelectedItem.Value);

           
             query2 = "Execute dbo.usp_idcard @command='SelectStaffId',@intSchool_id='" + Session["School_id"] + "',@intDepartment_id='" + depid + "',@intUserType_id='" + typeid + "' ";

             st3 = sBindDropDownList(DropDownList6, query2, "Name", "intTeacher_id");
           
        
        }
        catch
        { 
        
        }



    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

   
    

 

