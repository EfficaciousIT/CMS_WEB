using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmStandardWiseRpt : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {                   
                    FillSTD();                    
                    geturl();
                }
            }
            else
            {
                Response.Redirect("~\\Index.aspx", false);
            }
        }
        catch
        {

        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int sum = 0;
            strQry = "";
            strQry = "exec usp_SchoolFeeCollection @type='FillStandardWiseGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();          
        }
        catch
        {

        }
    }
    public void FillSTD()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SchoolFeeCollection @type='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
        }
        catch
        {

        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {        
        if (ddlSTD.SelectedValue == "0")
        {
            ddlSTD.Focus();
            MessageBox("Please Select Standard!");
            return;
        }
        DataSet dsObj = new DataSet();
        strQry = "";
        strQry = "exec usp_SchoolFeeCollection @type='FillStandardWiseGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        Session["rptStdWiseStuFee"] = dsObj;
        Response.Redirect("rptStandardWise.aspx", true);
    }
}