using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmAdmEnquiry_Received :DBUtility
{

    public string Disquery = string.Empty;
    public int grvDetail1,monid=0;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                TabContainer1.ActiveTabIndex = 0;
                DropDown5.SelectedValue = DateTime.Now.Month.ToString();
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
        

         Disquery = "Execute dbo.usp_Enquiry @command='view_Enquiry_monAll',@intSchool_id='" + Session["School_id"] + "'";
         grvDetail1 = sBindGrid(GridViewEnquiry, Disquery);

    }
    protected void DropDown5_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        monid = Convert.ToInt32(DropDown5.SelectedItem.Value);

         Disquery = "Execute dbo.usp_Enquiry @command='view_Enquiry_mon',@intSchool_id='" + Session["School_id"] + "',@month_id='" + monid + "'";
         grvDetail1 = sBindGrid(GridViewEnquiry, Disquery);


   }
}