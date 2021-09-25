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
using System.Collections.Generic;


public partial class frmAdmStudent_Allocation : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            //Label lblTitle = new Label();
            //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
            //lblTitle.Visible = true;
            //lblTitle.Text = "Student-Bus Allocation";
            if (!IsPostBack)
            {
                clear();
                filldata();
                checksession();
                geturl();



            }

        }
        catch
        { 
        
        }

    }

    public void filldata()
    {
        string query1 = "Execute dbo.usp_BusService @command='Routeval',@intSchool_id='" + Session["School_id"] + "' ";
        bool st = sBindDropDownList(DropDownList1, query1, "vchRoute_name", "intRoute_id");

        string query2 = "Execute dbo.usp_BusService @command='tripval',@intSchool_id='" + Session["School_id"] + "'";
        bool st1 = sBindDropDownList(DropDownList2, query2, "vchTrip_name", "intTrip_id");


        string query3 = "Execute dbo.usp_BusService @command='Busstopvl',@intSchool_id='" + Session["School_id"] + "'";
        bool st2 = sBindDropDownList(DropDownList3, query3, "vchBusStop_name", "intBusStop_id");

        string query4 = "Execute dbo.usp_BusService @command='Stadval',@intSchool_id='" + Session["School_id"] + "'";
        bool st3 = sBindDropDownList(DropDownList4, query4, "vchStandard_name", "intStandard_id");

        

    }
    private IEnumerable<string> SelectedValues
    {
        get
        {
            if (ViewState["SelectedValues"] == null && chkSubmodule.SelectedIndex >= -1)
            {
                ViewState["SelectedValues"] = chkSubmodule.Items.Cast<ListItem>()
                    .Where(li => li.Selected)
                    .Select(li => li.Value)
                    .ToList();
            }
            else
                ViewState["SelectedValues"] = Enumerable.Empty<string>();

            return (IEnumerable<string>)ViewState["SelectedValues"];
        }
        set { ViewState["SelectedValues"] = value; }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string routvalid = Convert.ToString(DropDownList1.SelectedItem.Value);
        if (routvalid != "")
        {
            string query2 = "Execute dbo.usp_BusService @command='tripval',@routvalid='" + routvalid + "',@intSchool_id='" + Session["School_id"] + "'";
            bool st1 = sBindDropDownList(DropDownList2, query2, "vchTrip_name", "intTrip_id");
        }

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
       // std1.Visible = true;
       // std2.Visible = true;
        string stdvalid = Convert.ToString(DropDownList4.SelectedItem.Value);
        string divvalid = Convert.ToString(DropDownList5.SelectedItem.Value);
        if (divvalid != "")
        {
            string query5 = "Execute dbo.usp_BusService @command='SelectStud',@intstanderd_id='" + stdvalid + "',@intDivision_id='" + divvalid + "',@intSchool_id='" + Session["School_id"] + "'";
            bool st1 = sBindCheckBoxList(chkSubmodule, query5, "name", "intStudent_id");
        }

    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkAll.Checked)
            {
                txt1.Text = "";
                for (int i = 0; i < chkSubmodule.Items.Count; i++)
                {

                    chkSubmodule.Items[i].Selected = true;

                    string valim = chkSubmodule.Items[i].Text;
                    txt1.Text = txt1.Text + valim + '\n';

                } 
                
            }
            else
            {
                for (int i = 0; i < chkSubmodule.Items.Count; i++)
                {

                    chkSubmodule.Items[i].Selected = false;
                    txt1.Text = "";
                }
            }
        }
        catch { }

    }
    
    protected void chkSubmodule_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        try
        {
            if (chkSubmodule.SelectedItem == null)
            { 
            
                txt1.Text = "";
                chkAll.Checked = false;
            }

            if (chkSubmodule.SelectedItem.Selected)
            {
                txt1.Text = "";

                for (int i = 0; i < chkSubmodule.Items.Count; i++)
                 { 

                       if (chkSubmodule.Items[i].Selected)
                       {

                        string valim = chkSubmodule.Items[i].Text;
                        txt1.Text = txt1.Text + valim + '\n';
                       }
                }
            }
            else
            {

                string valim = chkSubmodule.SelectedItem.Text;
                txt1.Text = txt1.Text +valim+'\n';

            }



            }
        catch
        {
        
        
        }
    }
    protected void submit_Click(object sender, EventArgs e)
    {

     
        try
        {
            //clear();
            int intRoute_id = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            int intTrip_id = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            int intBusStop_id = Convert.ToInt32(DropDownList3.SelectedItem.Value);
            int intStandard_id = Convert.ToInt32(DropDownList4.SelectedItem.Value);
            int intDivision_id = Convert.ToInt32(DropDownList5.SelectedItem.Value);
            int stud_id = Convert.ToInt32(chkSubmodule.SelectedItem.Value);
            string rolnamval = Convert.ToString(chkSubmodule.SelectedItem.Text);
            int intschool_id = Convert.ToInt32(Session["School_id"]);
            int intinsert_id = Convert.ToInt32(Session["User_id"]);
            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");
            string ipval = GetSystemIP();
            int j = 0;
            
            for (int i = 0; i < chkSubmodule.Items.Count; i++)
            {

                if (chkSubmodule.Items[i].Selected)
                {

                    string valim = chkSubmodule.Items[i].Value;

                    string instrquery1 = "Execute dbo.usp_BusService @command='Studbuslink',@intRoute_id='" + intRoute_id + "',@intTrip_id='" + intTrip_id + "',@intSchool_id='" + Session["School_id"] + "',@intBusStop_id='" + intBusStop_id + "',@intStandard_id='" + intStandard_id + "',@intDivision_id='" + intDivision_id + "',@stud_id='" + valim + "',@fltinsertIP='" + ipval + "',@dtInsertedDate='" + insertdt + "',@intinsert_id='" + intinsert_id + "'";
                    j = sExecuteQuery(instrquery1);
                    
                }
            }
            
            if (j != -1)
            {
                string display = "Bus Service Successfully Activated!";
                MessageBox(display);
                clear();

            }
            else
            {
                MessageBox("ooopppsss!Bus Service Activation Failed");

            }
        }
        catch 
        {
        
        }
    }

    public void clear()
    {

        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList3.Items.Clear();
        DropDownList4.Items.Clear();
        DropDownList5.Items.Clear();

        filldata();

        //std1.Visible = false;
       // std2.Visible = false;
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query5 = "Execute dbo.usp_BusService @command='Stadivval',@intStandard_id='" + DropDownList4.SelectedValue.Trim() + "',@intSchool_id='" + Session["School_id"] + "'";
        bool st5 = sBindDropDownList(DropDownList5, query5, "vchDivisionName", "intDivision_id");
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "Execute dbo.usp_BusService @command='AvailableSeat',@intTrip_id='" + DropDownList2.SelectedValue.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            Label7.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchBusNumber"]);
            lab1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["avb"]);
        }
    }
}