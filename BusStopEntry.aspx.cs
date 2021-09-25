using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Web.Services;
using System.Net;

public partial class BusStopEntry : DBUtility
{
    static string strConSBTS = ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString.ToString();
    DataTable dt1;
    string strQry;
    int i = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTitle = new Label();
        //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTitle.Visible = true;
        //lblTitle.Text = "Bus Stop Entry";     
        if (Session["School_id"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            if (!IsPostBack)
            {               
                showstop();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clientScript", "showmap();", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "setCentermap('mahape,ghansoli,maharastra');", true);
            }
        }
    }
    //public void findingaddress()
    //{
    //    dt1 = sGetDatatable("select vchSchoolAddress  from SBTS_School where intSchool_id=" + Session["School_id"] + "", "", strConSBTS);
    //    hdnCentermap.Value = dt1.Rows[0][0].ToString();      
    //}

    public void showstop()
    {

        string sQuery1;
        sQuery1 = "declare @vchdata varchar(max) set @vchdata=''  select @vchdata=@vchdata+Convert(varchar,fltLatitude,128)+'#'+Convert(varchar,fltLongitude,128)+'#'+vchBusStop_name+'#&'      from  tblbus_stop_master where intSchool_id='1' select @vchdata";
        DataTable dt1 = sGetDatatable(sQuery1,"Display");

        if (dt1 != null && dt1.Rows[0][0].ToString() != "")
        {
            hdnStops.Value = dt1.Rows[0][0].ToString().Trim();
        }
        // ScriptManager.RegisterStartupScript(this, this.GetType(), "ClientScript", "LoadMap();", true);
    }


    private void clearall()
    {
        lonbox.Text = "";
        latbox.Text = "";     
        txtName.Text = "";        
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
 
    } 
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {
            MessageBox("Please Enter Bus Stop!");
            txtName.Focus();
            return;
        }
        if (latbox.Text == "")
        {
            MessageBox("Please Enter Bus Location!");
            return;
        }
        try
        {
            strQry = "usp_BusEntryMaster @command='Insert',@vchBusStop_name='" + txtName.Text.Trim() + "',@fltLatitude='" + latbox.Text.Trim() + "',@fltLongitude='" + lonbox.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            i = sExecuteQuery(strQry);
            if (i > 0)
            {
                showstop();
                MessageBox("Bus stop addedd successfully");
            }
        }
        catch (Exception ex)
        {

        }        
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
}
