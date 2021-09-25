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

public partial class frmModuleDetails : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillAcademicYear();
            FillRole();
            lblDept.Visible = false;
            ddlDepartment.Visible = false;           
            lblDesi.Visible = false;
            ddlDesignation.Visible = false;          
            lblTchr.Visible = false;
            ddlTeacher.Visible = false;           
            lblStd.Visible = false;
            ddlSTD.Visible = false;
        }
    }
  
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ModuleAssignment @command='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlAcademiYear, strQry, "AcademicYear", "intAcademic_id");
            ddlAcademiYear.SelectedValue = "1";
        }
        catch
        {

        }
    }
    public void FillRole()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillRole',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlRole, strQry, "vchRole", "intRole_Id");
        }
        catch
        {

        }
    }
    public void FillSTD()
    {
        try
        {
            lblStd.Visible = true;
            ddlSTD.Visible = true;
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
        }
        catch
        {

        }
    }
    public void FillDepartment()
    {
        try
        {
            lblDept.Visible = true;
            ddlDepartment.Visible = true;
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillDepartment',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlDepartment, strQry, "vchDepartment_name", "intDepartment");
        }
        catch
        {

        }
    }
    public void FillDesignation()
    {
        try
        {
            lblDesi.Visible = true;
            ddlDesignation.Visible = true;
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillDesignation',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlDesignation, strQry, "vchDesignation", "intDesignation_Id");
        }
        catch
        {

        }
    }
    public void FillTeacher()
    {
        try
        {
            lblTchr.Visible = true;
            ddlTeacher.Visible = true;
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillTeacher',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "'";
            sBindDropDownList(ddlTeacher, strQry, "vchfirst_name", "intTeacher_id");          
        }
        catch
        {

        }
    }
    public void FillStaff()
    {
        try
        {
            lblTchr.Visible = true;
            ddlTeacher.Visible = true;
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillStaff',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "'";
            sBindDropDownList(ddlTeacher, strQry, "vchfirst_name", "intStaff_id");           
        }
        catch
        {

        }
    }

    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.SelectedValue == "1")
        {
            lblDept.Visible = false;
            ddlDepartment.Visible = false;
            ddlDepartment.ClearSelection();
            lblDesi.Visible = false;
            ddlDesignation.Visible = false;
            ddlDesignation.ClearSelection();
            lblTchr.Visible = false;
            ddlTeacher.Visible = false;
            lblStd.Visible = true;
            ddlSTD.Visible = true;
            ddlTeacher.ClearSelection();
            FillSTD();
        }
        else if (ddlRole.SelectedValue == "2")
        {
            lblDept.Visible = false;
            ddlDepartment.Visible = false;
            ddlDepartment.ClearSelection();
            lblDesi.Visible = false;
            ddlDesignation.Visible = false;
            ddlDesignation.ClearSelection();
            lblTchr.Visible = false;
            ddlTeacher.Visible = false;
            ddlTeacher.ClearSelection();
            lblStd.Visible = true;
            ddlSTD.Visible = true;
            FillSTD();
        }
        else if (ddlRole.SelectedValue == "3")
        {
            lblDept.Visible = true;
            ddlDepartment.Visible = true;
            ddlDepartment.ClearSelection();
            lblDesi.Visible = true;
            ddlDesignation.Visible = true;
            ddlDesignation.ClearSelection();
            lblTchr.Visible = true;
            ddlTeacher.Visible = true;
            ddlTeacher.ClearSelection();
            lblStd.Visible = false;
            ddlSTD.Visible = false;
            ddlSTD.ClearSelection();
            FillDepartment();
        }
        else if (ddlRole.SelectedValue == "4")
        {
            lblDept.Visible = true;
            ddlDepartment.Visible = true;
            ddlDepartment.ClearSelection();
            lblDesi.Visible = true;
            ddlDesignation.Visible = true;
            ddlDesignation.ClearSelection();
            lblTchr.Visible = true;
            ddlTeacher.Visible = true;
            ddlTeacher.ClearSelection();
            lblStd.Visible = false;
            ddlSTD.Visible = false;
            ddlSTD.ClearSelection();
            FillDepartment();
        }
        //else if (ddlRole.SelectedValue == "5")
        //{
        //    lblDept.Visible = true;
        //    ddlDepartment.Visible = true;
        //    ddlDepartment.ClearSelection();
        //    lblDesi.Visible = true;
        //    ddlDesignation.Visible = true;
        //    ddlDesignation.ClearSelection();
        //    lblTchr.Visible = true;
        //    ddlTeacher.Visible = true;
        //    ddlTeacher.ClearSelection();
        //    lblStd.Visible = false;
        //    ddlSTD.Visible = false;
        //    ddlSTD.ClearSelection();
        //    lblStd.Visible = false;
        //    ddlSTD.Visible = false;
        //    ddlSTD.ClearSelection();
        //    FillDepartment();
        //}
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDesignation();
    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.SelectedValue == "3")
        {
            FillTeacher();
        }
        if (ddlRole.SelectedValue == "4")
        {
            FillStaff();
        }
    }
    protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        fAssignGrid();
    }
    protected void fAssignGrid()
    {
        string AcaYr = Convert.ToString(ddlAcademiYear.SelectedValue);
        string Role = Convert.ToString(ddlRole.SelectedValue);
        string Dept = Convert.ToString(ddlDepartment.SelectedValue);
        string Desi = Convert.ToString(ddlDesignation.SelectedValue);
        string Tchr = Convert.ToString(ddlTeacher.SelectedValue);

        strQry = "usp_ModuleAssignment @command='fAssignGrid',@intAcademic_id='" + AcaYr + "',@intRole_Id='" + Role + "',@intDepartment='" + Dept + "',@intDesignation_Id='" + Desi + "',@intUser_id='" + Tchr + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            gvDetails.DataSource = dsObj;
            gvDetails.DataBind();
        }
        else
        {
            gvDetails.DataSource = dsObj;
            gvDetails.DataBind();

        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        string AcaYr = Convert.ToString(ddlAcademiYear.SelectedValue);
        string Role = Convert.ToString(ddlRole.SelectedValue);
        string std = Convert.ToString(ddlSTD.SelectedValue);

        strQry = "usp_ModuleAssignment @command='getAssModuleDetails',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + AcaYr + "',@intRole_Id='" + Role + "',@intstandard_id='" + std + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            gvDetails.DataSource = dsObj;
            gvDetails.DataBind();

        }
        else
        {
            gvDetails.DataSource = dsObj;
            gvDetails.DataBind();

        }
    }
    protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["ID"] = Convert.ToString(gvDetails.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_ModuleAssignment] @command='delete',@intModuleAssign_Id='" + Convert.ToString(Session["ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Module Deleted Successfully!');window.location ='frmModuleDetails.aspx';", true);
               
            }
        }
        catch
        {

        }
    }
}