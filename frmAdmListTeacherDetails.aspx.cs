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

public partial class frmAdmListTeacherDetails : DBUtility
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Staff Detail";

            if (!IsPostBack)
            {
                checksession();
                geturl();

                string query1 = "Execute dbo.usp_Profile @command='SeleDepart',@intSchool_id='" + Session["School_id"] + "' ";
                bool st = sBindDropDownList(DropDownList1, query1, "vchDepartment_name", "intDepartment");

                string query2 = "Execute dbo.usp_Profile @command='SeleTeachId',@intSchool_id='" + Session["School_id"] + "' ";
                bool st2 = sBindDropDownList(DropDownList2, query2, "Name", "intTeacher_id");

                if (Convert.ToString(Session["UserType_id"]) == "2")
                {
                    GridViewlistTeach.Columns[0].Visible = false;
                    GridViewlistTeach.Columns[1].Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
        
        
        }
    }
    protected void GridViewlistTeach_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridViewlistTeach.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = GridViewlistTeach.DataKeys[e.RowIndex].Value;
            string DeleteIP = GetSystemIP();
            string strQry11 = "Execute dbo.usp_Profile @command='DeleteTeachPro',@intTeacher_id='" + id + "',@intschool_id='" + Session["School_id"] + "',@vchDeleted_IP='" + DeleteIP + "',@intDeleted_id='" + Session["user_id"] + "'";
            if (sExecuteQuery(strQry11) != -1)
            {
                MessageBox("Record Deleted Successfully");
                //filldata();

            }

        }
        catch
        {


        }
    }
    protected void Dropliststud_SelectedIndexChanged(object sender, EventArgs e)
    {

        string val1 = ((DropDownList)sender).SelectedValue;
       
    }
    protected void GridViewlistTeach_RowEditing(object sender, GridViewEditEventArgs e)
    {
      

    }
    protected void GridViewlistTeach_DataBound(object sender, EventArgs e)
    {

    }
    protected void GridViewlistTeach_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int intforumid = Convert.ToInt32(GridViewlistTeach.DataKeys[e.Row.RowIndex].Value);
            Image img = (Image)e.Row.FindControl("btnDetails");
            img.Attributes.Add("onclick", "window.open('FrmAdmLiTeacherProfile.aspx?successMessage=" + intforumid + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=500,top=150,left=500');return false");

            int intforumid1 = Convert.ToInt32(GridViewlistTeach.DataKeys[e.Row.RowIndex].Value);
            Image img1 = (Image)e.Row.FindControl("btnEdit");
            img1.Attributes.Add("onclick", "window.open('FrmAdmLiTeacherProfile.aspx?successMessage1=" + intforumid1 + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=500,top=150,left=500');return false");
            
        
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selDepar=DropDownList1.SelectedItem.Value;
        string query2 = "Execute dbo.usp_Profile @command='SeleTeachIdDepa',@intSchool_id='" + Session["School_id"] + "',@intsubject_id='" + selDepar + "' ";
        bool st2 = sBindDropDownListAll(DropDownList2, query2, "Name", "intTeacher_id");
        DropDownList2.SelectedValue = "A";
        string depar = Convert.ToString(DropDownList1.SelectedItem.Value);
        //string TeaId = DropDownList2.SelectedItem.Value;
        String Disquery = "Execute dbo.usp_Profile @command='ListTeacherProfileA',@intschool_id='" + Session["School_id"] + "',@intsubject_id='" + depar + "'";
        int Leavegrid = sBindGrid(GridViewlistTeach, Disquery);
        listTeachgrid.Visible = true;
        listTeacggrid1.Visible = true;
        
        if (Convert.ToString(Session["UserType_id"]) == "2")
        {
            GridViewlistTeach.Columns[0].Visible = false;
            GridViewlistTeach.Columns[1].Visible = false;
        }



    }
 
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        string teachid = Convert.ToString(DropDownList2.SelectedItem.Value);
        string depar = Convert.ToString(DropDownList1.SelectedItem.Value);

        String Disquery = "Execute dbo.usp_Profile @command='ListTeacherProfile',@intschool_id='" + Session["School_id"] + "',@intsubject_id='" + depar + "',@intTeacher_id='"+ teachid +"'";
        int Leavegrid = sBindGrid(GridViewlistTeach, Disquery);
        listTeachgrid.Visible = true;
        listTeacggrid1.Visible = true;

        if (Convert.ToString(Session["UserType_id"]) == "2")
        {
            GridViewlistTeach.Columns[0].Visible = false;
            GridViewlistTeach.Columns[1].Visible = false;
        }


    }
}


