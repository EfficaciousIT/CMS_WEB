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

public partial class frmGenderwiseAttendence : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strFromDate = string.Empty;
    string strToDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            MessageBox("Please Select From Date!");
            txtFromDate.Focus();
            return;
        }
        if (txtToDate.Text == "")
        {
            MessageBox("Please Select To Date!");
            txtToDate.Focus();
            return;
        }
        strFromDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        //strQry = "[usp_GenderWiseAttendance] @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@FromDate='" + strFromDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@vchGender='" + Convert.ToString(ddlgender.SelectedItem.Text) + "'";
        strQry = "[usp_GenderWiseAttendance] @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@FromDate='" + strFromDate.Trim() + "',@ToDate='" + strToDate.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdGender.DataSource = dsObj;
            grdGender.DataBind();
            //grdGender.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Font.Bold = true;

            //grdGender.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[0].Text = "";
            //grdGender.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[1].Text = "";
            //grdGender.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[3].Text = "";
        }
        else
        {
            grdGender.DataSource = dsObj;
            grdGender.DataBind();
        }
    }
    protected void ddlgender_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvName.SelectedIndex = -1;
        //gvName.Visible = false;
    }   
    
    protected void grdGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        strFromDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strToDate = Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "[usp_GenderWiseAttendance] @command='selectName',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@FromDate='" + strFromDate.Trim() + "',@ToDate='" + strToDate.Trim() + "',@vchGender='" + Convert.ToString(ddlgender.SelectedItem.Text) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            gvName.DataSource = dsObj;
            gvName.DataBind();           
        }
        else
        {
            gvName.DataSource = dsObj;
            gvName.DataBind();
        }
    }
    protected void grdGender_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if ((Convert.ToString(Session["UserType_id"]) != "1") && (Convert.ToString(Session["UserType_id"]) != "2"))
            //{
            //    Session.Add("std", Convert.ToString(grdAbsent.DataKeys[e.Row.RowIndex].Values[0]));

            //}
            Label lblDate = (Label)e.Row.FindControl("lblDate");
            LinkButton lnkMale = (LinkButton)e.Row.FindControl("lnkMale");
            lnkMale.Attributes.Add("onclick", "window.open('AbsentGenderWise.aspx?date=" + lblDate.Text + "&vchGender=" + "Male" + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");                                                                                  
           // lnkButton.Attributes.Add("onclick", "window.open('AbsentGenderWise.aspx?date=" + lblDate.Text + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");

            LinkButton lnkFemale = (LinkButton)e.Row.FindControl("lnkFemale");
            lnkFemale.Attributes.Add("onclick", "window.open('AbsentGenderWise.aspx?date=" + lblDate.Text + "&vchGender=" + "Female" + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");                                                                                  
            //lnkButton.Attributes.Add("onclick", "window.open('AbsentGenderWise.aspx?date=" + lblDate.Text + "&vchGender=" + Convert.ToString(ddlgender.SelectedItem.Text) + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");                                                                                  
           // lnkButton.Attributes.Add("onclick", "window.open('AbsentGenderWise.aspx?date=" + lblDate.Text + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=660,width=950,top=5,left=150');return false");
        }
    }
}