using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class FrmAdm_AppBusSerReq :DBUtility
{
    public string Disquery = string.Empty;
    public int grvDetail1,id,result1 = 0;
    DataSet dsObj1 = new DataSet();
    public string strQry4 = string.Empty;
    public string display = string.Empty;
    public string intService_id = string.Empty;
    public string remarkval = string.Empty;
    public string instremaquery1 = string.Empty;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
			Label lblTitle = new Label();
                    lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                    lblTitle.Visible = true;
                    lblTitle.Text = "Bus Service Request";

            if (!IsPostBack)
            {

                checksession();
                geturl();
                TabContainer1.ActiveTabIndex = 0;
                fillgrid();
                TabPanel2.Visible = false;
            }
        }
        catch 
        {
        
        
        }
        }
    protected void Apbusre_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void fillgrid()
    {
        try
        {
             Disquery = "Execute dbo.usp_BusFeesMaster @command='appro_requ',@intSchool_id='" + Session["School_id"] + "'";
             grvDetail1 = sBindGrid(Apbusre, Disquery);

        }
        catch 
        {
        
        
        }
    }
 
    protected void Apbusre_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
             id = Convert.ToInt32(Apbusre.DataKeys[e.NewEditIndex].Value);
            Session["id"] = Apbusre.DataKeys[e.NewEditIndex].Value;
          
            TabPanel2.Visible = true;
             strQry4 = "exec dbo.usp_BusFeesMaster @command='appro_requEdit',@intService_id='" + id + "',@intschool_id='" + Session["School_id"] + "'";
            dsObj1 = sGetDataset(strQry4);

            if (dsObj1.Tables[0].Rows.Count > 0)
            {
                TabContainer1.ActiveTabIndex = 1;
                txt1.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["intService_id"]);
                lab2.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["StudentName"]);
                lab4.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["vchArea_Name"]);
               
                lab6.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["dtEffectiveFrom"]);
                lab8.Text = Convert.ToString(dsObj1.Tables[0].Rows[0]["dtEffectiveTo"]);

            }
            else
            {
                 display = "Area Editing Not Allowed!";
                MessageBox(display);

            }
        }
        catch
        {
        }
        
    }

    protected void Apbusre_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void Apbusre_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void id1_Click(object sender, EventArgs e)
    {

        try
        {

            intService_id = Convert.ToString(txt1.Text);
             remarkval = Convert.ToString(remark1.Text);



            instremaquery1 = "Execute dbo.usp_BusFeesMaster @command='req_approval',@vchRemarkByAppro='" + remarkval + "',@intService_id='" + intService_id + "',@intschool_id='" + Session["School_id"] + "',@intApprovalBy='" + Session["user_id"] + "'";

            result1 = sExecuteQuery(instremaquery1);

            if (result1 != -1)
            {
                 display = "Bus Services  Assigned Successfully!";
                MessageBox(display);
                TabPanel2.Visible = false;
                Clear();
                fillgrid();
                TabContainer1.ActiveTabIndex = 0;
            }
            else
            {
                MessageBox("ooopppsss!Bus Services Assignment Failed");

            }

        }
        catch
        { 
        }


    }
    protected void Clear()
    {
        lab2.Text = string.Empty;
        lab4.Text = string.Empty;
        lab6.Text = string.Empty;
        lab8.Text = string.Empty;
        remark1.Text = string.Empty;
         Disquery = string.Empty;
        grvDetail1=0;
        id=0;
        result1 = 0;  
        strQry4 = string.Empty;
        display = string.Empty;
        intService_id = string.Empty;
        remarkval = string.Empty;
        instremaquery1 = string.Empty;
    }
}