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

public partial class frmRoleWisePromotion : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillAcademicYear();
            FillRole();
            Clear();
           // fGrid();
            lblStd.Visible = false;
            ddlSTD.Visible = false;
            lblDiv.Visible = false;
            ddlDIV.Visible = false;
        }
    }
    protected void fGrid()
    {
        if (drpRole.SelectedValue == "3")
        {
            grvDetail.Columns[5].Visible = true;
            grvDetail.Columns[6].Visible = true;
            strQry = "usp_PromotionTransaction @command='selectTeacher',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
        }
        if (drpRole.SelectedValue == "4")
        {
            grvDetail.Columns[5].Visible = false;
            grvDetail.Columns[6].Visible = false;
            strQry = "usp_PromotionTransaction @command='selectStaff',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
        }
        if (drpRole.SelectedValue == "5")
        {
            grvDetail.Columns[5].Visible = false;
            grvDetail.Columns[6].Visible = false;
            strQry = "usp_PromotionTransaction @command='selectAdmin',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_PromotionTransaction @command='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlAcademiYear, strQry, "AcademicYear", "intAcademic_id");
            sBindDropDownList(ddlToAcademicYear, strQry, "AcademicYear", "intAcademic_id");
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
            strQry = "exec usp_PromotionTransaction  @command='FillRole',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlRole, strQry, "vchRole", "intRole_Id");
            sBindDropDownList(drpRole, strQry, "vchRole", "intRole_Id");
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
            strQry = "exec usp_PromotionTransaction  @command='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
            strQry = "";
            strQry = "exec usp_PromotionTransaction  @command='FillDepartment',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
            strQry = "";
            strQry = "exec usp_PromotionTransaction  @command='FillDesignation',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
            strQry = "";
            strQry = "exec usp_PromotionTransaction  @command='FillTeacher',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlName, strQry, "vchfirst_name", "intTeacher_id");

            
        }
        catch
        {

        }
    }
    public void FillStaff()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_PromotionTransaction  @command='FillStaff',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlName, strQry, "vchfirst_name", "intStaff_id");          
        }
        catch
        {

        }
    }
    public void FillAdmin()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_PromotionTransaction  @command='FillAdmin',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlName, strQry, "vchfirst_name", "intAdmin_id");
        }
        catch
        {

        }
    }
    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDepartment();
        if (ddlRole.SelectedValue == "3")
        {
            lblStd.Visible = true;
            ddlSTD.Visible = true;
            lblDiv.Visible = true;
            ddlDIV.Visible = true;
            ddlSTD.ClearSelection();
            ddlDIV.ClearSelection();
        }     
        else 
        {
            lblStd.Visible = false;
            ddlSTD.Visible = false;
            lblDiv.Visible = false;
            ddlDIV.Visible = false;
            ddlSTD.ClearSelection();
            ddlDIV.ClearSelection();
        }

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
            FillSTD();
        }
        if (ddlRole.SelectedValue == "4")
        {
            FillStaff();
        }
        if (ddlRole.SelectedValue == "5")
        {
            FillAdmin();
        }
    }
    public void FillDivision()
    {
        try
        {
            string str1 = "exec [usp_PromotionTransaction] @command='FillDiv',@intSchool_id='" + Session["School_id"] + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlDIV, str1, "vchDivisionName", "intDivision_id");
        }
        catch
        {

        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDivision();
    }
    public void Clear()
    {
        ddlToAcademicYear.ClearSelection();
        ddlRole.ClearSelection();
        ddlDepartment.ClearSelection();
        ddlDesignation.ClearSelection();
        ddlName.ClearSelection();
        ddlSTD.ClearSelection();
        ddlDIV.ClearSelection();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlToAcademicYear.SelectedValue == "0")
        {
            MessageBox("Please Select To Academic Year!");
            ddlToAcademicYear.Focus();
            return;
        }
        if (ddlRole.SelectedValue == "0")
        {
            MessageBox("Please Select Role!");
            ddlRole.Focus();
            return;
        }
        if (ddlDepartment.SelectedValue == "0")
        {
            MessageBox("Please Select Department!");
            ddlDepartment.Focus();
            return;
        }
        if (ddlDesignation.SelectedValue == "0")
        {
            MessageBox("Please Select Designation!");
            ddlDesignation.Focus();
            return;
        }
        if (ddlName.SelectedValue == "0")
        {
            MessageBox("Please Select Name!");
            ddlName.Focus();
            return;
        }
        if (ddlRole.SelectedValue == "3")
        {
            if (ddlSTD.SelectedValue == "0")
            {
                MessageBox("Please Select Standard!");
                ddlSTD.Focus();
                return;
            }
            if (ddlDIV.SelectedValue == "0")
            {
                MessageBox("Please Select Division!");
                ddlDIV.Focus();
                return;
            }
        }
        if (btnSubmit.Text == "Submit")
        {
            if (ddlRole.SelectedValue != null && ddlName.SelectedValue != null)
            {
                strQry = "exec [usp_PromotionTransaction] @command='insertTransaction',@intAcademic_id='" + Convert.ToString(ddlToAcademicYear.SelectedValue) + "',@intUserType_id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment_id='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "',@intUser_id='" + Convert.ToString(ddlName.SelectedValue) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDivision_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_id='" + Session["User_id"] + "',@vchInserted_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    Clear();
                    MessageBox("Record Inserted Successfully!");
                }
            }           
            else
            {
                
            }
        }
        else
        {
            if (ddlRole.SelectedValue != null && ddlName.SelectedValue != null)
            {
                strQry = "exec [usp_PromotionTransaction] @command='UpdateTransaction',@intTransUser_id='" + Convert.ToString(Session["intTransUser_id"]) + "',@intAcademic_id='" + Convert.ToString(ddlToAcademicYear.SelectedValue) + "',@intUserType_id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment_id='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "',@intUser_id='" + Convert.ToString(ddlName.SelectedValue) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDivision_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdated_id='" + Session["User_id"] + "',@vchUpdated_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    Clear();
                    MessageBox("Record Updated Successfully!");
                    TBC.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
                else
                {

                }
            }
        }
    }
    protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        fGrid();
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {            
            Session["intTransUser_id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);            
            strQry = "";
            strQry = "exec usp_PromotionTransaction @command='editTeacher',@intTransUser_id='" + Convert.ToString(Session["intTransUser_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlToAcademicYear.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAcademic_id"]);
                ddlRole.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intUserType_id"]);
                FillDepartment();
                ddlDepartment.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment_id"]);
                FillDesignation();
                ddlDesignation.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDesignation_Id"]);
                if (ddlRole.SelectedValue == "3")
                {
                    FillTeacher();
                    FillSTD();
                    lblStd.Visible = true;
                    ddlSTD.Visible = true;
                    lblDiv.Visible = true;
                    ddlDIV.Visible = true;
                }
                if (ddlRole.SelectedValue == "4")
                {
                    FillStaff();
                    lblStd.Visible = false ;
                    ddlSTD.Visible = false;
                    lblDiv.Visible = false;
                    ddlDIV.Visible = false;
                }
                if (ddlRole.SelectedValue == "5")
                {
                    FillAdmin();
                    lblStd.Visible = false;
                    ddlSTD.Visible = false;
                    lblDiv.Visible = false;
                    ddlDIV.Visible = false;
                }
                ddlName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intUser_id"]);
                ddlSTD.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                FillDivision();
                ddlDIV.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                TBC.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
}