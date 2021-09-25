using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmSubModuleMaster : DBUtility
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
                    FillGrid();
                    FillModule();
                    geturl();
                }
            }
            else
            {
                Response.Redirect("~\\index.aspx", false);
            }
        }
        catch
        {

        }
    }
    public void FillModule()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SubModuleMaster @type='FillModule',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlModule, strQry, "vchModule", "intModule_Id");
        }
        catch
        {

        }
    }
    public void FillGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SubModuleMaster @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlModule.SelectedValue == "0")
        {
            MessageBox("Please Select Module!");
            ddlModule.Focus();
            return;
        }
        if (txtSubModule.Text == "")
        {
            MessageBox("Please Insert Sub-Module!");
            txtSubModule.Focus();
            return;
        }

        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_SubModuleMaster  @type='CheckSaveExist',@intModule_Id='" + Convert.ToString(ddlModule.SelectedValue).Trim() + "',@vchSubModule='" + Convert.ToString(txtSubModule.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_SubModuleMaster  @type='Insert',@intModule_Id='" + Convert.ToString(ddlModule.SelectedValue).Trim() + "',@vchSubModule='" + Convert.ToString(txtSubModule.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInerted_by='" + Session["User_id"] + "',@InsertIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    txtSubModule.Text = "";
                    ddlModule.ClearSelection();
                    FillGrid();
                }
            }
            else
            {
                strQry = "";
                strQry = "exec usp_SubModuleMaster  @type='CheckUpdateExist',@intModule_Id='" + Convert.ToString(ddlModule.SelectedValue).Trim() + "',@intSubModule_Id='" + ViewState["int_ID"] + "',@vchSubModule='" + Convert.ToString(txtSubModule.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_SubModuleMaster  @type='Update',@intModule_Id='" + Convert.ToString(ddlModule.SelectedValue).Trim() + "',@intSubModule_Id='" + ViewState["int_ID"] + "',@vchSubModule='" + Convert.ToString(txtSubModule.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    txtSubModule.Text = "";
                    ddlModule.ClearSelection();
                    btnSubmit.Text = "Submit";
                    FillGrid();
                }
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
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            ViewState["int_ID"] = id;
            strQry = "exec usp_SubModuleMaster @type='Delete',@intSubModule_Id='" + Convert.ToString(id) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully");
                FillGrid();
            }
        }
        catch
        {

        } 

    }
    protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvDetail.PageIndex = e.NewPageIndex;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            strQry = "";
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["int_ID"] = id;
            strQry = "exec usp_SubModuleMaster  @type='Edit',@intSubModule_Id='" + Convert.ToString(id) + "',@intSchool_id='" + Session["School_Id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlModule.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intModule_Id"]);
                txtSubModule.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSubModule"]);
                TBC.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
}