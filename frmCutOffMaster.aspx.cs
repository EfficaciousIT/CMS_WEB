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

public partial class frmCutOffMaster : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAcademicYear();
            FillStandard();
            FillCategory();
            fGrid();
        }  
    }
    protected void fGrid()
    {
        strQry = "usp_CutOffMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            drpAcademicYear.ClearSelection();
            drpStandard.ClearSelection();
            drpCategory.ClearSelection();
            txtPercentage.Text = "";
        }
    }
    protected void FillAcademicYear()
    {
        strQry = "usp_CutOffMaster @command='selectAcademicYear'";
        bool stcardp = sBindDropDownList(drpAcademicYear, strQry, "AcademicYear", "intAcademic_id");
        sBindDropDownList(ddlAcademic, strQry, "AcademicYear", "intAcademic_id");
    }
    protected void FillStandard()
    {
        strQry = "usp_CutOffMaster @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
        sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intStandard_id");
    }
    protected void FillCategory()
    {
        strQry = "usp_CutOffMaster @command='selectCategory'";
        bool stcardp = sBindDropDownList(drpCategory, strQry, "vchCategory", "intCat_Id");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
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
        if (drpCategory.SelectedValue == "0")
        {
            MessageBox("Please Select Category!");
            drpCategory.Focus();
            return;
        }
        if (txtPercentage.Text == "")
        {
            MessageBox("Please Enter Percentage!");
            txtPercentage.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_CutOffMaster @command='checkExist',@intAcademic_id='" + Convert.ToString(drpAcademicYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCategory.SelectedValue) + "',@vchPercentage='" + Convert.ToString(txtPercentage.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_CutOffMaster] @command='insert',@intAcademic_id='" + Convert.ToString(drpAcademicYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCategory.SelectedValue) + "',@vchPercentage='" + Convert.ToString(txtPercentage.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Inserted Successfully!");
                }
            }
        }
        else
        {
            strQry = "usp_CutOffMaster @command='checkExist',@intAcademic_id='" + Convert.ToString(drpAcademicYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCategory.SelectedValue) + "',@vchPercentage='" + Convert.ToString(txtPercentage.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_CutOffMaster] @command='update',@intAcademic_id='" + Convert.ToString(drpAcademicYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCategory.SelectedValue) + "',@vchPercentage='" + Convert.ToString(txtPercentage.Text.Trim()) + "',@intCutOff_Id='" + Convert.ToString(Session["intCutOff_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
            }
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
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intCutOff_Id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_CutOffMaster @command='edit',@intCutOff_Id='" + Convert.ToString(Session["intCutOff_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpAcademicYear.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAcademic_id"]);
                drpStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                drpCategory.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intCat_Id"]);
                txtPercentage.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPercentage"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["intCutOff_Id"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_CutOffMaster] @command='delete',@intCutOff_Id='" + Convert.ToString(Session["intCutOff_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Role Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
    protected void ddlAcademic_SelectedIndexChanged(object sender, EventArgs e)
    {
        fDDLGrid();
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        fDDLGrid();
    }
    protected void fDDLGrid()
    {
        strQry = "usp_CutOffMaster @command='fDDLGrid',@intAcademic_id='" + Convert.ToString(ddlAcademic.SelectedValue) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
}