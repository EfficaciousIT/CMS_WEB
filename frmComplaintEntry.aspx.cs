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

public partial class frmComplaintEntry :DBUtility
{

    DataSet dsObj=new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                checksession();
                geturl();
                gridfill1();
            }
        }
        catch 
        { 
        }
    }
    protected void gridfill1()
    {
        string Disquery1 = "Execute dbo.usp_Complaint @command='View_Complaint',@intSchool_id='" + Session["School_id"] + "'";
        int grvDetail2 = sBindGrid(GridView1, Disquery1);

        string Disquery = "Execute dbo.usp_Complaint @command='View_ComplaintRepo',@intSchool_id='" + Session["School_id"] + "'";
        int grvDetail1 = sBindGrid(CompDetail, Disquery);
        

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = GridView1.DataKeys[e.RowIndex].Value;


            //long insertby = Convert.ToInt64(Session["User_id"]);

            string ipval = GetSystemIP();
    

            string strQry = "Execute dbo.usp_Complaint @command='Check_Complaint',@intcomplaint_id='" + id + "',@intschool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);


            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Deleted");
            }
            else
            {

                string strQry1 = "Execute dbo.usp_Complaint @command='Delete_Complaint',@intcomplaint_id='" + id + "',@intschool_id='" + Session["School_id"] + "'";  //@intDeleted_By='" + insertby + "',
                if (sExecuteQuery(strQry1) != -1)
                {
                    MessageBox("Record Deleted Successfully");
                    gridfill1();
                    
                }
                else
                {


                }
            }
        }
        catch (Exception)
        {


        }
    }
    protected void CompDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void CompDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void CompDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            Session["id"] = GridView1.DataKeys[e.NewEditIndex].Value;
            DataSet dsObj1 = new DataSet();
            TextBox3.Text = Convert.ToString(Session["id"]);
            string strQry4 = "exec dbo.usp_Complaint @command='Edit_Complaint',@intcomplaint_id='" + id + "',@intschool_id='" + Session["School_id"] + "'";
            dsObj1 = sGetDataset(strQry4);
            if (dsObj1.Tables[0].Rows.Count > 0)
            {

                TextBox1.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["vchComplaint_Title"]);
                TextBox2.Text  = Convert.ToString(dsObj1.Tables[0].Rows[0]["vchComplaint_Discr"]);
                ddldrop.SelectedValue   = Convert.ToString(dsObj1.Tables[0].Rows[0]["vchRole"]);
                Button2.Visible = false;
                Button1.Visible = true;

                TabContainer1.ActiveTabIndex = 0;
                Button1.Text = "Update";
            }
            else
            {
                string display = "Complaint Editing Not Allowed!";
                MessageBox(display);

            }

        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void CompDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Button1.Text == "Submit")
        {
            try
            {
                string comptitle = Convert.ToString(TextBox1.Text);
                string compDescip = Convert.ToString(TextBox2.Text);
                string role = Convert.ToString(ddldrop.SelectedItem.Value);
                long insertby = 0;
                if (Convert.ToString(Session["strUserType"]) == "1")
                {
                    insertby = Convert.ToInt32(Session["school_id"]);
                }
                //else
                //{
                //    insertby = Convert.ToInt32(Session["User_id"]);
                //}

                string ipval = GetSystemIP();

                string instremaquery1 = "Execute dbo.usp_Complaint @command='Insert_Complaint',@vchComplaint_Discr='" + compDescip + "',@vchComplaint_Title='" + comptitle + "',@vchRole='" + role + "',@intInsert_By='" + insertby + "',@vchInsertedIP='" + ipval + "',@intSchool_id='" + Session["School_id"] + "'";

                int result1 = sExecuteQuery(instremaquery1);
                if (result1 != -1)
                {
                    string display = "Complaint Save Successfully!";
                    MessageBox(display);
                    gridfill1();
                    Clear();
                }
                else
                {
                    MessageBox("ooopppsss!Unable To Save a Complaint");
                }

            }
            catch
            {

            }
        }
        else
        { 
            int idval = Convert.ToInt32(TextBox3.Text);
            string comptitle = Convert.ToString(TextBox1.Text);
            string compDescip = Convert.ToString(TextBox2.Text);
            string role = Convert.ToString(ddldrop.SelectedItem.Value);
            //long intUpdate_By = Convert.ToInt64(Session["User_id"]);
            string ipval = GetSystemIP();
            string instremaquery1 = "Execute dbo.usp_Complaint @command='Update_Complaint',@vchComplaint_Discr='" + compDescip + "',@vchComplaint_Title='" + comptitle + "',@vchRole='" + role + "',@intcomplaint_id='" + idval + "',@intSchool_id='" + Session["School_id"] + "'"; // @intUpdate_By='" + intUpdate_By + "',

            int result1 = sExecuteQuery(instremaquery1);
            if (result1 != -1)
            {
                string display = "Complaint Updated Successfully!";
                MessageBox(display);
                gridfill1();
                Button1.Text = "Submit";
                Clear();
            }
            else
            {
                MessageBox("ooopppsss!Unable To Update your Complaint");

            }
        
        }
        
        }

    
    

    public void Clear()
    { 
        TextBox1.Text = "";
        TextBox2.Text = "";
        ddldrop.SelectedValue = null;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            int idval = Convert.ToInt32(TextBox3.Text);
            string comptitle = Convert.ToString(TextBox1.Text);
            string compDescip = Convert.ToString(TextBox2.Text);
            string role = Convert.ToString(ddldrop.SelectedItem.Value);
            //long intUpdate_By = Convert.ToInt64(Session["User_id"]);
            string ipval = GetSystemIP();
            string instremaquery1 = "Execute dbo.usp_Complaint @command='Update_Complaint',@vchComplaint_Discr='" + compDescip + "',@vchComplaint_Title='" + comptitle + "',@vchRole='" + role + "',@intcomplaint_id='" + idval + "',@intSchool_id='" + Session["School_id"] + "'"; // @intUpdate_By='" + intUpdate_By + "',

            int result1 = sExecuteQuery(instremaquery1);
            if (result1 != -1)
            {
                string display = "Complaint Updated Successfully!";
                MessageBox(display);
                gridfill1();
                Button2.Text = "Submit";
                Clear();
            }
            else
            {
                MessageBox("ooopppsss!Unable To Update your Complaint");

            }
        }
        catch 
        {
        
        
        }
    }
}