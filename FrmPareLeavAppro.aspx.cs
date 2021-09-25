
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

public partial class FrmPareLeavAppro : DBUtility
{
    int outval, teachappresul;
   
    string strQry, appresult;

    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTitle = new Label();
        //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTitle.Visible = true;
        //lblTitle.Text = "Leave Application Detail";
        if (!IsPostBack)
        {
            TabContainer1.ActiveTabIndex = 0;
            try
            {
                checksession();
                geturl();
                fillGrid();
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
    protected void fillGrid()
    {
        try
        {
            //string query1 = "Execute dbo.usp_Leave @command='LeaveApprorequest' ,@intUser_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "',@intUserType_id='" + Session["UserType_id"] + "'";
            string query1 = "Execute dbo.usp_Leave @command='LeaveApprorequest' ,@intUser_id='" + Session["Student_id"] + "',@intSchool_id='" + Session["School_id"] + "',@intUserType_id='" + Session["UserType_id"] + "'";

            outval = sBindGrid(GridView1, query1);
            string DisRepoquery = "Execute dbo.usp_Leave @command='gridfillparent',@intStudent_id='" + Session["Student_id"] + "',@intUser_id='" + Session["User_id"] + "'";
           int Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);

        }
        catch (Exception ex)
        {
        }
    }


    protected void OnRowSelected()
    {
    
    
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        TabContainer1.Focus();
        TabPanel1.Visible = true;
        TabContainer1.ActiveTabIndex = 1;


        try
        {
            int Applicationid = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            Session["Applicationid"] = GridView1.DataKeys[e.NewEditIndex].Value;
            LblApplication.Text = Convert.ToString(Session["Applicationid"]);
            dsObj = new DataSet();

            strQry = "exec [usp_Leave] @command='Approveapp',@intLeaveApplocation_id='" + Session["Applicationid"] + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                leaveType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TypeOfLeave"]);
                FromLbl.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["FromDate"]).ToString("dd/MM/yyyy");
                ToLbl.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["ToDate"]).ToString("dd/MM/yyyy");
                TotalLbl.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalLeaveDays"]);

            }

        }
        catch (Exception)
        {

            throw;
        }

    }

    protected void Submitval(object sender, EventArgs e)
    {
        try
        {
            int appval = Convert.ToInt32(RadioApproved.SelectedItem.Value);

            if (appval == 2)
            {
                appresult = "Rejected";
                teachappresul = 2;

            }
            else if (appval == 1)
            {
                appresult = "Approved";

            }
            string Appresonval = Resontxt.Text;
            string LblAppli = Convert.ToString(LblApplication.Text);
            string ipval = GetSystemIP();
            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");
            string instrquery1 = "Execute dbo.usp_Leave @command='Updateapproval',@vchParentsRemark='" + Convert.ToString(Appresonval).Trim() + "',@bitParentApproval='" + appval + "',@dtparentApproval='" + insertdt + "',@intLeaveApplocation_id='" + LblAppli + "',@bitTeacherApproval='" + teachappresul + "'";

            int str = sExecuteQuery(instrquery1);
            if (str != -1)
            {
                string display = "Leave Application " + appresult + "!";
                MessageBox(display);

                btnSubmin.Visible = false;
                btnClear.Visible = false;
                TabContainer1.ActiveTabIndex = 0;
                TabPanel1.Visible = false;
                TabContainer1.ActiveTabIndex = 0;
                fillGrid();
                Clear();
            }
            else
            {

                MessageBox("Leave Application Failed");
            }
        }

        catch (Exception Ex)
        {

            throw;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
        }
        catch
        {
            throw;
        }

    }
     public void Clear1()
    {
        Radioleave.ClearSelection();
        txtfromdate1.Text = "";
        txttodate.Text = "";
        txtNoofDays.Text = "";
        content.Text = "";
     }
     public void clear2()
     { 
     int leaveval=0;
     string dtfromdate="";
     string dttodate="";
     string textareaval="";
     string insertdt="";
     string Totalval="";
     string ipval="";
     string instrquery1 = "";
     
     }
    public void Clear()
    {
        RadioApproved.ClearSelection();
        Resontxt.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(txtNoofDays.Text) >= 0)
            {
                int leaveval = Convert.ToInt32(Radioleave.SelectedItem.Value);
                string dtfromdate = Convert.ToDateTime(txtfromdate1.Text).ToString("MM/dd/yyyy");
                string dttodate = Convert.ToDateTime(txttodate.Text).ToString("MM/dd/yyyy");
                string textareaval = Convert.ToString(content.Text);
                string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

                string Totalval = txtNoofDays.Text;
                string ipval = GetSystemIP();
                string instrquery1 = "Execute dbo.usp_Leave @command='insertParents' ,@intUserType_id='" + Session["UserType_id"] + "',@intType_id='" + Convert.ToString(leaveval).Trim() + "',@intUser_id='" + Session["User_id"] + "',@dtFrom_date='" + dtfromdate + "',@dtTo_Date='" + dttodate + "',@vchReason='" + Convert.ToString(textareaval).Trim() + "',@intTotalDays='" + Convert.ToString(Totalval).Trim() + "',@dtInsertDate='" + insertdt + "',@insertIP='" + ipval + "',@intInsertedBy='" + Session["User_id"] + "',@dtApplication_date='" + insertdt + "',@bitParentApproval=1,@bitTeacherApproval=0,@intSchool_id='" + Session["School_id"] + "',@intStudent_id='" + Session["Student_id"] + "'";

                int str = sExecuteQuery(instrquery1);
                if (str != -1)
                {
                    if (dtfromdate == "")
                    {
                        MessageBox("Select First");
                    }
                    else
                    {
                        string display = "Leave Application Submit!";
                        MessageBox(display);
                        clear2();
                        Clear1();
                    }
                    TabContainer1.ActiveTabIndex = 1;
                
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
        catch 
        {
        
        }
    }
    protected void check_val(object sender, EventArgs e)
    {
        //try
        //{
        //    int val = Convert.ToInt32(txtNoofDays.Text);
        //    if (val <= 0)
        //    {
        //        Response.Write("value not be less then zero");
        //    }
        //}
        //catch
        //{

        //    throw;

        //}
        try
        {
            if (txtfromdate1.Text != "" && txttodate.Text != "")
            {
                DateTime startdate = DateTime.ParseExact(txtfromdate1.Text.ToString().Trim(), "dd/MM/yyyy", null);
                DateTime enddate = DateTime.ParseExact(txttodate.Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                TimeSpan t = enddate.Subtract(startdate);

                int val = Convert.ToInt32(txtNoofDays.Text);
                if (val < 0)
                {
                    Label4.Text = "Total Leave Days not be less then zero";
                    txtNoofDays.Text = "";
                    txttodate.Text = "";
                }
                else
                {
                    Label4.Text = "";

                    txtNoofDays.Text = Convert.ToString(t.Days + 1);
                }
            }
        }
        catch
        {
            throw;
        }
    }
    protected void cleartodata(object sender, EventArgs e)
    {
        try
        {
            if (txttodate.Text != "")
            {
                DateTime startdate = DateTime.ParseExact(txtfromdate1.Text.ToString().Trim(), "dd/MM/yyyy", null);
                DateTime enddate = DateTime.ParseExact(txttodate.Text.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                TimeSpan t = enddate.Subtract(startdate);

                int val = Convert.ToInt32(t.Days);
                if (val < 0)
                {
                  
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
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtfromdate1.Text != "" && txttodate.Text != "")
            {
                DateTime startdate = DateTime.ParseExact(txtfromdate1.Text.ToString().Trim(), "dd/MM/yyyy", null);
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
