using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class FrmAdminLeavAppro :DBUtility
{
    public int outval, appval, teachappresul, resultval,str,Leavegrid1, monthval, Applicationid = 0;
    public string strQry=string.Empty;
    public string appresult=string.Empty;
    public string FillDrop = string.Empty;
    public bool dropnm = true;
    public string query1 = string.Empty;
    public string DisRepoquery = string.Empty;
    public string monthvals = string.Empty;
    public string Appresonval=string.Empty;
    public string LblAppli=string.Empty;
    public string ipval=string.Empty;
    public string insertdt=string.Empty;
    public string instrquery1=string.Empty;
    public string display = string.Empty;

    public string selectNm = string.Empty;
    

    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            try
            {
               Label lblTitle = new Label();
                    lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                    lblTitle.Visible = true;
                    lblTitle.Text = "Leave Application Detail";
                droMonth.SelectedValue = DateTime.Now.Month.ToString();

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
            try
            {
                monthval = Convert.ToInt32(droMonth.SelectedValue);
            }
            catch (Exception)
            {
                monthval = DateTime.Now.Month;
                
            }
            
                 FillDrop="Execute dbo.usp_Leave @command='GrTeaLeaveRepNmAll',@intSchool_id='" + Session["School_id"] + "',@monthval='" + monthval + "'";
                 dropnm = sBindDropDownListAll(DropName, FillDrop, "TeachName", "intUser_id");
                DropName.SelectedValue = "A";


             query1 = "Execute dbo.usp_Leave @command='AdminLeaveApprorequest',@intSchool_id='" + Session["School_id"] + "' ";

            outval = sBindGrid(GridView1, query1);



            
             DisRepoquery = "Execute dbo.usp_Leave @command='GrTeaLeaveRepoMo',@intSchool_id='" + Session["School_id"] + "',@monthval='" + monthval + "'";
             Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);
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
      
        TabContainer1.Focus();
        TabPanel1.Visible = true;
        TabContainer1.ActiveTabIndex = 1;
        TabPanel2.Enabled = false;

        try
        {
            Applicationid = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
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
                appval =Convert.ToInt32(RadioApproved.SelectedItem.Value);

                if (appval == 2)
                {
                    appresult = "Rejected";
                    teachappresul = 2;
                
                }
                else if (appval == 1)
                {
                    appresult = "Approved";
                
                }

           
             Appresonval = Resontxt.Text;
             LblAppli = Convert.ToString(LblApplication.Text);
             ipval = GetSystemIP();
             insertdt = DateTime.Now.ToString("MM/dd/yyyy");
             instrquery1 = "Execute dbo.usp_Leave @command='UpdateAdminapproval',@vchAdminRemark='" + Convert.ToString(Appresonval).Trim() + "',@bitAdminApproval='" + appval + "',@dtAdminApproval='" + insertdt + "',@intLeaveApplocation_id='" + LblAppli + "',@intSchool_id='" + Session["School_id"] + "'";

             str = sExecuteQuery(instrquery1);
            if (str != -1)
            {
                display = "Leave Application "+appresult+"!";
                MessageBox(display);

                btnSubmin.Visible = false;
                btnClear.Visible = false;
                TabContainer1.ActiveTabIndex = 0;
                TabPanel1.Visible = false;
                TabContainer1.ActiveTabIndex = 0;
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
    protected void droMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillGrid();
          string SelecName = DropName.SelectedItem.Value;
        if (SelecName == "A")
        {
             monthvals = Convert.ToString(droMonth.SelectedItem.Value);
            if (monthvals == "All")
            {
                 DisRepoquery = "Execute dbo.usp_Leave @command='GrTeaLeaveRepo',@intSchool_id='" + Session["School_id"] + "'";
                 Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);
            }
            else
            {
                 DisRepoquery = "Execute dbo.usp_Leave @command='GrTeaLeaveRepoMo',@intSchool_id='" + Session["School_id"] + "',@monthval='" + monthval + "'";
                 Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);
            }
        }
        else
        {

            monthvals = Convert.ToString(droMonth.SelectedItem.Value);
            if (monthvals == "All")
            {
                 DisRepoquery = "Execute dbo.usp_Leave @command='GrTeaLeaveRepo1',@intSchool_id='" + Session["School_id"] + "',@intUser_id='" + SelecName + "'";
                 Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);
            }
            else
            {
                 DisRepoquery = "Execute dbo.usp_Leave @command='GrTeaLeaveRepoMo1',@intSchool_id='" + Session["School_id"] + "',@monthval='" + monthval + "',@intUser_id='" + SelecName + "'";
                 Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);
            }
        }
        }
    protected void DropName_SelectedIndexChanged(object sender, EventArgs e)
    {
        monthvals = droMonth.SelectedItem.Value;

       
         selectNm = DropName.SelectedItem.Value;
        if (selectNm == "A")
        {

            if (monthvals == "All")
            {
                 DisRepoquery = "Execute dbo.usp_Leave @command='GrTeaLeaveRepo',@intSchool_id='" + Session["School_id"] + "'";
                 Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);
            }
            else
            {

                 DisRepoquery = "Execute dbo.usp_Leave @command='GrTeaLeaveRepoMo',@intSchool_id='" + Session["School_id"] + "',@monthval='" + monthvals + "'";
                 Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);
            }
        }

        else
        {

            if (monthvals == "All")
            {
                 DisRepoquery = "Execute dbo.usp_Leave @command='GrTeaLeaveRepo1',@intSchool_id='" + Session["School_id"] + "',@intUser_id='" + SelecName + "'";
                 Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);
            }
            else
            {
                 DisRepoquery = "Execute dbo.usp_Leave @command='GrTeaLeaveRepoNm',@intSchool_id='" + Session["School_id"] + "',@monthval='" + monthval + "',@intUser_id='" + selectNm + "'";
                 Leavegrid1 = sBindGrid(GridViewRepo, DisRepoquery);
            }
            }
        }
}