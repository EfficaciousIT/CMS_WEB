using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmBus_ser_reqby_pare : DBUtility
{

    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Convert.ToString(Session["UserType_id"]) == "2")
            {
                Label lblTitle = new Label();
                lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                lblTitle.Visible = true;
                lblTitle.Text = "Bus Service Request";
                GetSelectedRecord();
                if (!IsPostBack)
                {
                    checksession();
                    geturl();
                    fillgrid();
                }
            }
            else
            {
                MessageBox("Login Not allowed");
                Response.Redirect("frmIndex.aspx");


            }
        }
        catch
        { 
        
        
        }
        }
    protected void fillgrid()
    {
        try
        {

             string Disquery = "Execute dbo.usp_BusFeesMaster @command='GridBusSerReq',@intSchool_id='" + Session["School_id"] + "'";
            int grvDetail1 = sBindGrid(BusRequestDetail, Disquery);


            string Disy1 = "Execute dbo.usp_BusFeesMaster @command='grid_status',@intParent_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
            int grvDetail2 = sBindGrid(GridVApp, Disy1);

            string Disy3 = "Execute dbo.usp_BusFeesMaster @command='grid_status',@intParent_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
            int grvDetail3 = sBindGrid(GridView1, Disy3);
            //;
            //string query5 = "Execute dbo.usp_BusService @command='SelectStud',@intstanderd_id='" + stdvalid + "',@intDivision_id='" + divvalid + "',@intSchool_id='" + Session["School_id"] + "'";
            //bool st1 = sRadioButtonList(SelectBusSer, query5, "name", "intStudent_id");

        }
        catch (Exception ex)
        {
        }
    
    }
   
   
    private void GetSelectedRecord()
    {
        for (int i = 0; i < BusRequestDetail.Rows.Count; i++)
        {
            RadioButton rb = (RadioButton)BusRequestDetail.Rows[i]
                            .Cells[0].FindControl("id11");
            if (rb != null)
            {
                if (rb.Checked)
                {
                    HiddenField hf = (HiddenField)BusRequestDetail.Rows[i]
                                    .Cells[0].FindControl("HiddenField1");
                    if (hf != null)
                    {
                        ViewState["SelectedContact"] = hf.Value;
                        string st = Convert.ToString(ViewState["SelectedContact"]);
                        td1.Text = st;
                    }

                    break;
                }
            }
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            string idv = Convert.ToString(td1.Text);
            string ipval = GetSystemIP();

            string ins2 = "Execute dbo.usp_BusFeesMaster @command='Check_Bus_Service',@intParent_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "'";
            
             dsObj = sGetDataset(ins2);


            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Bus services Already Activated");
            }
            else
            {

                string insbusreq1 = "Execute dbo.usp_BusFeesMaster @command='Pare_bus_serappy',@intParent_id='" + Session["User_id"] + "',@intStudent_id='" + Session["Student_id"] + "',@intStandard_id='" + Session["Standard_id"] + "',@intDivision_id='" + Session["Division_id"] + "',@intBusService_id='" + idv + "',@IntInsert_id='" + Session["User_id"] + "',@IntInsert_IP='" + ipval + "',@intSchool_id='" + Session["School_id"] + "'";
                int str = sExecuteQuery(insbusreq1);
                if (str != -1)
                {
                    string display = "Bus Service Successfully Activated!";
                    MessageBox(display);
                    //clear();

                }
                else
                {
                    MessageBox("ooopppsss!Bus Service Activation Failed");

                }
            }
        }
        catch 
        {
        
        }

    }
    protected void BusRequestDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridVApp_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridVApp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(GridVApp.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = GridVApp.DataKeys[e.RowIndex].Value;
            string IntDelete_IP = GetSystemIP();
            string strQry1 = "Execute dbo.usp_BusFeesMaster @command='Delete_Request',@intService_id='" + id + "',@intParent_id='" + Session["User_id"] + "',@intschool_id='" + Session["School_id"] + "',@intDelete_id='" + Session["User_id"] + "',@IntDelete_IP='" + IntDelete_IP + "'";
            if (sExecuteQuery(strQry1) != -1)
            {
                MessageBox("Record Deleted Successfully");
                fillgrid();

            }

        }
        catch
        {


        }
    }

}