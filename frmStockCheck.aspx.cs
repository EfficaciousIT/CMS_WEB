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

public partial class frmStockCheck : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillStockInventory();
            FillRole();
            FillUnit();
            fInventoryEntryGrid();
        }
    }
    public void FillRole()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_tblSchoolStockTransaction  @command='FillRole',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpRole, strQry, "vchRole", "intRole_Id");
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
            strQry = "exec usp_tblSchoolStockTransaction  @command='FillDepartment',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpDept, strQry, "vchDepartment_name", "intDepartment");
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
            strQry = "exec usp_tblSchoolStockTransaction  @command='FillDesignation',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(drpDept.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpDesignation, strQry, "vchDesignation", "intDesignation_Id");
        }
        catch
        {

        }
    }
    public void FillStockInventory()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_tblSchoolStockTransaction  @command='FillInventory',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(ddlInventory, strQry, "vchEquipment_name", "intEquipment_id");
            sBindDropDownList(drpInventory, strQry, "vchEquipment_name", "intEquipment_id");
        }
        catch
        {

        }
    }
    public void FillUnit()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_tblSchoolStockTransaction  @command='FillUnit',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            sBindDropDownList(drpUnit, strQry, "vchUnit", "intUnit_Id");           
        }
        catch
        {

        }
    }
    protected void fInventoryEntryGrid()
    {
        strQry = "usp_tblSchoolStockTransaction @command='fInventoryEntryGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdDetails.DataSource = dsObj;
            grdDetails.DataBind();
            drpRole.ClearSelection();
            drpDept.ClearSelection();
            drpDesignation.ClearSelection();
            drpName.ClearSelection();
            drpInventory.ClearSelection();
            txtQty.Text = "";
            drpUnit.ClearSelection();
        }
        else
        {
            grdDetails.DataSource = dsObj;
            grdDetails.DataBind();

        }
    }
 
    protected void fGrid()
    {
        strQry = "usp_SchoolInventory @command='StockCheck',@intEquipment_id='" + Convert.ToString(ddlInventory.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            gvList.DataSource = dsObj;
            gvList.DataBind();

        }
        else
        {
            gvList.DataSource = dsObj;
            gvList.DataBind();

        }        
    }
    protected void ddlInventory_SelectedIndexChanged(object sender, EventArgs e)
    {
        fGrid();       
    }
    protected void drpRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDepartment();
    }
    protected void drpDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDesignation();
    }
    protected void drpDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpRole.SelectedValue == "3")
        {
            FillTeacher();
        }
        if (drpRole.SelectedValue == "4")
        {
            FillStaff();
        }
        if (drpRole.SelectedValue == "5")
        {
            FillAdmin();
        }
    }
    protected void FillTeacher()
    {
        strQry = "usp_tblSchoolStockTransaction @command='SelectTeacher',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(drpDept.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(drpDesignation.SelectedValue) + "'";
        sBindDropDownList(drpName, strQry, "name", "intID");
    }
    protected void FillStaff()
    {
        strQry = "usp_tblSchoolStockTransaction @command='SelectStaff',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(drpDept.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(drpDesignation.SelectedValue) + "'";
        sBindDropDownList(drpName, strQry, "name", "intID");
    }
    protected void FillAdmin()
    {
        strQry = "usp_tblSchoolStockTransaction @command='SelectAdmin',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(drpDept.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(drpDesignation.SelectedValue) + "'";
        sBindDropDownList(drpName, strQry, "name", "intID");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //if (txtName.Text == "")
        //{
        //    MessageBox("Please Insert Role Name!");         
        //    txtName.Focus();
        //    return;
        //}
        if (btnSubmit.Text == "Submit")
        {

            strQry = "exec [usp_tblSchoolStockTransaction] @command='insert',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(drpDept.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(drpDesignation.SelectedValue) + "',@intUser_id='" + Convert.ToString(drpName.SelectedValue) + "',@vchUserName='" + Convert.ToString(drpName.SelectedItem.Text.Trim()) + "',@intEquipment_id='" + Convert.ToString(drpInventory.SelectedValue) + "',@vchQty='" + Convert.ToString(txtQty.Text.Trim()) + "',@intUnit_Id='" + Convert.ToString(drpUnit.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fInventoryEntryGrid();
                    MessageBox("Record Inserted Successfully!");
                }           
        }
        else
        {
            strQry = "exec [usp_tblSchoolStockTransaction] @command='update',@intRole_Id='" + Convert.ToString(drpRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(drpDept.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(drpDesignation.SelectedValue) + "',@intUser_id='" + Convert.ToString(drpName.SelectedValue) + "',@vchUserName='" + Convert.ToString(drpName.SelectedItem.Text.Trim()) + "',@intEquipment_id='" + Convert.ToString(drpInventory.SelectedValue) + "',@vchQty='" + Convert.ToString(txtQty.Text.Trim()) + "',@intUnit_Id='" + Convert.ToString(drpUnit.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intStock_Id='" + Convert.ToString(Session["intStock_Id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fInventoryEntryGrid();
                    MessageBox("Record Updated Successfully!");
                    btnSubmit.Text = "Submit";
                }
        }
    }
    protected void grdDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intStock_Id"] = Convert.ToString(grdDetails.DataKeys[e.NewEditIndex].Value);
            Session["intUser_id"] = Convert.ToString(grdDetails.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblSchoolStockTransaction @command='edit',@intStock_Id='" + Convert.ToString(Session["intStock_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpRole.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intRole_Id"]);
                FillDepartment();
                drpDept.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDepartment"]);
                FillDesignation();
                drpDesignation.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDesignation_Id"]);
                if (drpRole.SelectedValue == "3")
                {
                    FillTeacher();
                }
                if (drpRole.SelectedValue == "4")
                {
                    FillStaff();
                }
                if (drpRole.SelectedValue == "5")
                {
                    FillAdmin();
                }
                drpName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intUser_id"]);
                drpInventory.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intEquipment_id"]);
                txtQty.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchQty"]);
                drpUnit.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intUnit_Id"]);   
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void grdDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["intStock_Id"] = Convert.ToString(grdDetails.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblSchoolStockTransaction] @command='delete',@intStock_Id='" + Convert.ToString(Session["intStock_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fInventoryEntryGrid();
                MessageBox("Role Deleted Successfully!");
            }
        }
        catch
        {

        }
       
    }
}