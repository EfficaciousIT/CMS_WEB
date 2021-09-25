using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class frmAbsentSummary : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strDate = string.Empty;
    string strToDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //strQry = "usp_Attendacesummary  @command='select',@fromDate='01/01/2016',@ToDate='01/20/2016'";
        //dsObj = sGetDataset(strQry);
        //if (dsObj.Tables[0].Rows.Count > 0)
        //{
        //    grdAbsent.DataSource = dsObj;
        //    grdAbsent.DataBind();
        //}
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {       
        if (ddlFilter.SelectedValue=="1")
        {
            ShowAbsent();
        }
        if (ddlFilter.SelectedValue == "2")
        {
            ShowPresent();
        }
        
    }
    public void ShowAbsent()
    {
        strDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_Attendacesummary  @command='select',@fromDate='" + strDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }
    public void ShowPresent()
    {
        strDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_Attendacesummary  @command='selectPresent',@fromDate='" + strDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdAbsent.DataSource = dsObj;
            grdAbsent.DataBind();
        }
    }
    protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtFromDate.Text = "";
        txtDate.Text = "";
    }
    protected void grdAbsent_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if ((Convert.ToString(Session["UserType_id"]) != "1") && (Convert.ToString(Session["UserType_id"]) != "2"))
            //{
            //    Session.Add("std", Convert.ToString(grdAbsent.DataKeys[e.Row.RowIndex].Values[0]));                
            //}
            Label lblDate = (Label)e.Row.FindControl("lblDate");

            LinkButton lnkButton = (LinkButton)e.Row.FindControl("lnkAbsent");

            lnkButton.Attributes.Add("onclick", "window.open('Absentsummary.aspx?date=" + lblDate.Text + "&filter=" + ddlFilter.SelectedValue + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
            //lnkMale.Attributes.Add("onclick", "window.open('AbsentGenderWise.aspx?date=" + lblDate.Text + "&vchGender=" + "Male" + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");  
        }
    }
}