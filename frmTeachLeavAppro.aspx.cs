using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmTeachLeavAppro :DBUtility
{
    int outval, appval,teachappresul;
    int resultval;
    string strQry = string.Empty;
    string appresult;

    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            try
            {

                checksession();
                geturl();

                TabContainer1.ActiveTabIndex = 0;
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
            filgrisapp();
         filgriTeachsapp();
        }
        catch (Exception ex)
        {
        }
    }

    protected void GridView1_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillGrid();
    
    
    }
    protected void GridViewRepo_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewRepo.PageIndex = e.NewPageIndex;
        fillGrid();
    
    
    }
        protected void  filgriTeachsapp()
            {
                string query1 = "Execute dbo.usp_Leave @command='TeachLeaveReport' ,@intUser_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";

            outval = sBindGrid(GridViewRepo, query1);
            GridViewRepo.Visible = true;
            }
      protected void  filgrisapp()
            {
                string query1 = "Execute dbo.usp_Leave @command='TeachLeaveApprorequest' ,@intUser_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";

            outval = sBindGrid(GridView1, query1);
            }

    protected void OnRowSelected()
    { }
    protected void Privioustval(object sender, EventArgs e)
    {
        try
        {
            TabPanel2.Visible = true;
            TabPanel1.Visible = false;
            filgrisapp();
         
        }
        catch( Exception ex)
        {
        
        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
      
        //TabContainer1.Focus();
        TabPanel2.Visible = false;
        TabPanel1.Visible = true;
     
        TabContainer1.ActiveTabIndex = 1;
        GridView1.Visible = false;
        GridViewRepo.Visible = true;
        //Button1.Visible = true;


        try

        {
            int Applicationid = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            Session["Applicationid"] = GridView1.DataKeys[e.NewEditIndex].Value;
            LblApplication.Text = Convert.ToString(Session["Applicationid"]);
            dsObj = new DataSet();

            strQry = "exec [usp_Leave] @command='TeachApproveapp',@intLeaveApplocation_id='" + Session["Applicationid"] + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Label6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
                leaveType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TypeOfLeave"]);
                FromLbl.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["FromDate"]).ToString("dd/MM/yyyy");
                ToLbl.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["ToDate"]).ToString("dd/MM/yyyy");
                TotalLbl.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalLeaveDays"]);
                ViewState["StudentId"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
            }

        }
        catch (Exception Ex)
        {

            throw;
        }
      
    }
    


    protected void Submitval(object sender, EventArgs e)
   
    {
        try
        {
                int appval =Convert.ToInt32(RadioApproved.SelectedItem.Value);

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


            string instrquery1 = "Execute dbo.usp_Leave @command='UpdateTeachapproval',@vchTeacherRemark='" + Convert.ToString(Appresonval).Trim() + "',@bitTeacherApproval='" + appval + "',@dtTeacherApproval='" + insertdt + "',@intLeaveApplocation_id='" + LblAppli + "',@UpdateIP='" + ipval + "',@dtUpdateDate='" + insertdt + "',@intUpdateBy='" + Session["User_id"] + "'";

           



            int str = sExecuteQuery(instrquery1);
            if (str != -1)
            {
                //Added By Tushar On 04/02/2015
                strQry = "exec usp_getAttendance @type='StudentLeaveEntry',@intStudent_id='" + Convert.ToString(ViewState["StudentId"]) + "',@FrmDt='" + Convert.ToDateTime(FromLbl.Text).ToString("MM/dd/yyyy") + "',@EndDt='" + Convert.ToDateTime(ToLbl.Text).ToString("MM/dd/yyyy") + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                if (sExecuteQuery(strQry) == -1)
                {
                    MessageBox("Problem Found");
                }
              
                //End


                string display = "Leave Application "+appresult+"!";
                MessageBox(display);
                GridViewRepo.Visible = true;
                btnSubmin.Visible = true;
                btnClear.Visible = false;
                TabContainer1.ActiveTabIndex = 0;
                TabPanel1.Visible = false;
                TabContainer1.ActiveTabIndex = 0;
                TabPanel2.Visible = true;
                TabPanel3.Visible = true;
                GridView1.Visible = true;
                Clear();
                fillGrid();
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
    public void Clear()
    {
        RadioApproved.ClearSelection();
        Resontxt.Text = "";
        
    }
   
}