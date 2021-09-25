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

public partial class frmAdmissionCancel : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillAcademicYear();
            FillSTD();
        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_AdmissionCancelation @command='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlAcademiYear, strQry, "AcademicYear", "intAcademic_id");
            sBindDropDownList(drpAcademicYear, strQry, "AcademicYear", "intAcademic_id");
            ddlAcademiYear.SelectedValue = "1";
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
            strQry = "exec usp_AdmissionCancelation  @command='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
            sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intstandard_id");
            
        }
        catch
        {

        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectStudentGrid();       
    }
    protected void SelectStudentGrid()
    {
        strQry = "usp_AdmissionCancelation @command='SelectStudent',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(ddlAcademiYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            gvList.DataSource = dsObj;
            gvList.DataBind();

        }
    }
    protected void SelectCancelStudentGrid()
    {
        strQry = "usp_AdmissionCancelation @command='SelectCancelAdmissionStudent',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(drpAcademicYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            gvCancelDet.DataSource = dsObj;
            gvCancelDet.DataBind();

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlSTD.SelectedValue == "0")
        {
            MessageBox("Please Select Standard!");
            ddlSTD.Focus();
            return;
        }      
        try
        {
            if (btnSubmit.Text == "Submit")
            {
                foreach (GridViewRow gvrow in gvList.Rows)
                {
                    CheckBox chkRow = (gvrow.Cells[1].FindControl("chkCtrl") as CheckBox);

                    if (chkRow.Checked)
                    {                       
                        string Std = Convert.ToString(ddlSTD.SelectedValue);                     
                        string intStudent_id = this.gvList.DataKeys[gvrow.RowIndex].Values[0].ToString();

                        strQry = "exec [usp_AdmissionCancelation] @command='AdmissionCancel',@intstandard_id='" + Std + "',@intStudent_id='" + intStudent_id + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAdmissionCancelBy='" + Session["User_id"] + "',@AdmissionCancelIP='" + GetSystemIP() + "'";
                        sExecuteQuery(strQry);
                    }                   
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Admission Cancel Successfully');window.location ='frmAdmissionCancel.aspx';", true);
            }
        }
        catch
        {
        }
    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectCancelStudentGrid();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (drpAcademicYear.SelectedValue == "0")
        {
            MessageBox("Please Select Academic Year!");
            drpAcademicYear.Focus();
            return;
        }
        if (drpStandard.SelectedValue == "0")
        {
            MessageBox("Please Select Standard!");
            drpStandard.Focus();
            return;
        }
        try
        {
            if (btnCancel.Text == "Submit")
            {
                foreach (GridViewRow gvrow in gvCancelDet.Rows)
                {
                    CheckBox chkRow = (gvrow.Cells[1].FindControl("chkCtrl") as CheckBox);

                    if (chkRow.Checked)
                    {
                        string Std = Convert.ToString(drpStandard.SelectedValue);
                        string intStudent_id = this.gvCancelDet.DataKeys[gvrow.RowIndex].Values[0].ToString();

                        strQry = "exec [usp_AdmissionCancelation] @command='AdmissionEnable',@intstandard_id='" + Std + "',@intStudent_id='" + intStudent_id + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAdmissionCancelBy='" + Session["User_id"] + "',@AdmissionCancelIP='" + GetSystemIP() + "'";
                        sExecuteQuery(strQry);
                    }
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Admission Enable Successfully');window.location ='frmAdmissionCancel.aspx';", true);
            }
        }
        catch
        {
        }
    }
}