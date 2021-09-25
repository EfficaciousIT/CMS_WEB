using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class FrmAdm_Action_complaint : DBUtility
{

    DataSet dsObj = new DataSet();
    public string Disquery = string.Empty;
    public int grvDetail1, grvDetail2, appval, complaintid, str, Applicationid, monid = 0; 
    public string Disquery1 = string.Empty;
    public string appresult = string.Empty;
    public string DiscriVal = string.Empty;
    public string ipval = string.Empty;
    public string instrquery1 = string.Empty;
    public string display = string.Empty;
    public string strQry = string.Empty;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label lblTitle = new Label();
            lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            lblTitle.Visible = true;
            lblTitle.Text = "Complaint Detail";
            if (!IsPostBack)
            {
			


                TabContainer1.ActiveTabIndex = 0;
                //DropDownList5.SelectedValue = DateTime.Now.Month.ToString();
                //DropDownList1.SelectedValue = DateTime.Now.Month.ToString();
                checksession();
                geturl();
                gridfill1();
                gridfill2();
            }
        }
        catch 
        {
        
        
        }
    }

    protected void gridfill1()
    {
         Disquery = "Execute dbo.usp_Complaint @command='AdmView_Complaint',@intSchool_id='" + Session["School_id"] + "'";
         grvDetail1 = sBindGrid(GridView1, Disquery);

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
     //  monid = Convert.ToInt32(DropDownList5.SelectedItem.Value);
        Disquery = "Execute dbo.usp_Complaint @command='AdmComplaint_ReportMon',@intSchool_id='" + Session["School_id"] + "',@mon_id='" + monid + "'";
        grvDetail1 = sBindGrid(GridView5, Disquery);


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
     //  monid = Convert.ToInt32(DropDownList1.SelectedItem.Value);
        Disquery = "Execute dbo.usp_Complaint @command='AdmComplaint_StatusMon',@intSchool_id='" + Session["School_id"] + "',@mon_id='" + monid + "'";
        grvDetail1 = sBindGrid(GridView1, Disquery);


    }
      protected void gridfill2()
    {
        Disquery = "Execute dbo.usp_Complaint @command='AdmComplaint_Report',@intSchool_id='" + Session["School_id"] + "'";
         grvDetail1 = sBindGrid(GridView5, Disquery);
         Disquery1 = "Execute dbo.usp_Complaint @command='AdmComplaint_Status',@intSchool_id='" + Session["School_id"] + "'";
         grvDetail2 = sBindGrid(GridView1, Disquery1);

    }
    
    protected void Submitval(object sender, EventArgs e)
    {
        try
        {
            
            appval = Convert.ToInt32(RadioApproved.SelectedItem.Value);
            if (appval == 2)
            {
                appresult = "Rejected";
               // teachappresul = 2;

            }
            else if (appval == 1)
            {
                appresult = "Approved";

            }
            DiscriVal = Convert.ToString(Discritxt.Text);
            
            ipval = GetSystemIP();
             complaintid=Convert.ToInt32(lblcomplaint.Text);
             instrquery1 = "Execute dbo.usp_Complaint @command='insert_CompSta',@btAdminApproval='" + appval + "',@vchAdmin_Discr='" + DiscriVal + "',@intAction_By='" + Session["User_id"] + "',@intschool_id='" + Session["school_id"] + "',@intComplaint_id='" + complaintid + "'";

             str = sExecuteQuery(instrquery1);
            if (str != -1)
            {
                display = "Leave Application " + appresult + "!";
                MessageBox(display);

                btnSubmin.Visible = false;
                btnClear.Visible = false;
                TabContainer1.ActiveTabIndex = 0;
                TabPanel1.Visible = false;
           
                gridfill1();
                gridfill2();
                //Clear();
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

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
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
            lblcomplaint.Text = Convert.ToString(Session["Applicationid"]);
            dsObj = new DataSet();

          strQry = "exec [usp_Complaint] @command='AdmEdit_Complaint',@intcomplaint_id='" + Session["Applicationid"] + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {

                la1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchcomplaint_title"]);
                la2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchcomplaint_discr"]);
                la3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intinsert_By"]);

              la4.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtinsertDate"]).ToString("dd/MM/yyyy");
               
            }

        }
        catch (Exception)
        {

          
        }
    }
 
}