using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frpRptStdWise : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillSTD();
            fillCategory();
        }
    }
    public void fillCategory()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SchoolFeeCollection @type='FillCategory',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpCAT, strQry, "vchCategory", "intCat_Id");
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
            sBindDropDownList(drpSTD, strQry, "vchStandard_name", "intstandard_id");
        }
        catch
        {

        }
    }
    protected void drpCAT_SelectedIndexChanged(object sender, EventArgs e)
    {
        //strQry = "exec usp_GetFeeStandardWiseCollection @type='getTotalFee',@intstandard_id='" + Convert.ToString(drpSTD.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCAT.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        strQry = "exec usp_GetFeeStandardWiseCollection @type='getTotalFee'";

            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtTotalFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["total_fee"]);              
            }
            //strQry = "exec usp_GetFeeStandardWiseCollection @type='getPaidFee',@intstandard_id='" + Convert.ToString(drpSTD.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCAT.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            strQry = "exec usp_GetFeeStandardWiseCollection @type='getPaidFee'";

            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtPaidFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["paid_Amount"]);            
            }
            //strQry = "exec usp_GetFeeStandardWiseCollection @type='getPendingFee',@intstandard_id='" + Convert.ToString(drpSTD.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCAT.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            strQry = "exec usp_GetFeeStandardWiseCollection @type='getPendingFee'";

            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtPendingFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Pending_amt"]);
            }
    }
    protected void drpSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTotalFee.Text = "";
        txtPaidFee.Text = "";
        txtPendingFee.Text = "";
        txtStudent.Text = "";
        strQry = "exec usp_GetFeeStandardWiseCollection @type='getTotalStudent',@intstandard_id='" + Convert.ToString(drpSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        //strQry = "exec usp_GetFeeStandardWiseCollection @type='getTotalFee'";

        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtStudent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total_Student"]);
        }
        strQry = "exec usp_GetFeeStandardWiseCollection @type='getTotalFee',@intstandard_id='" + Convert.ToString(drpSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        //strQry = "exec usp_GetFeeStandardWiseCollection @type='getTotalFee'";

        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtTotalFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["total_fee"]);
        }
        strQry = "exec usp_GetFeeStandardWiseCollection @type='getPaidFee',@intstandard_id='" + Convert.ToString(drpSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        //strQry = "exec usp_GetFeeStandardWiseCollection @type='getPaidFee'";

        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtPaidFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["paid_Amount"]);
        }
        strQry = "exec usp_GetFeeStandardWiseCollection @type='getPendingFee',@intstandard_id='" + Convert.ToString(drpSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        //strQry = "exec usp_GetFeeStandardWiseCollection @type='getPendingFee'";

        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtPendingFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Pending_amt"]);
        }
    }
}