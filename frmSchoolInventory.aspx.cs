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

public partial class frmSchoolInventory : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
            FillInventory();
            FillUnit();
        }
    }
    public void FillInventory()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SchoolInventory  @command='FillInventory',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlInventory, strQry, "vchEquipment_name", "intEquipment_id");
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
            strQry = "exec usp_SchoolInventory  @command='FillUnit',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlUnit, strQry, "vchUnit", "intUnit_Id");
        }
        catch
        {

        }
    }
    protected void fGrid()
    {
        strQry = "usp_SchoolInventory @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            gvList.DataSource = dsObj;
            gvList.DataBind();
            ddlInventory.ClearSelection();
            txtQty.Text = "";
            ddlUnit.ClearSelection();
            txtPrice.Text = "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlInventory.SelectedValue== "0")
        {
            MessageBox("Please Select Inventory Name!");
            ddlInventory.Focus();
            return;
        }
        if (txtQty.Text == "")
        {
            MessageBox("Please Insert Quantity!");
            txtQty.Focus();
            return;
        }
        if (ddlUnit.Text == "")
        {
            MessageBox("Please Select Unit!");
            ddlUnit.Focus();
            return;
        }
        if (txtPrice.Text == "")
        {
            MessageBox("Please Insert Price!");
            txtPrice.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_SchoolInventory @command='checkExist',@intEquipment_id='" + Convert.ToString(ddlInventory.SelectedValue) + "',@vchQty='" + Convert.ToString(txtQty.Text.Trim()) + "',@intUnit_Id='" + Convert.ToString(ddlUnit.SelectedValue) + "',@vchPrice='" + Convert.ToString(txtPrice.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_SchoolInventory] @command='insert',@intEquipment_id='" + Convert.ToString(ddlInventory.SelectedValue) + "',@vchQty='" + Convert.ToString(txtQty.Text.Trim()) + "',@intUnit_Id='" + Convert.ToString(ddlUnit.SelectedValue) + "',@vchPrice='" + Convert.ToString(txtPrice.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Inserted Successfully!");
                }
            }
        }
        else
        {
            strQry = "usp_SchoolInventory @command='checkExist',@intEquipment_id='" + Convert.ToString(ddlInventory.SelectedValue) + "',@vchQty='" + Convert.ToString(txtQty.Text.Trim()) + "',@intUnit_Id='" + Convert.ToString(ddlUnit.SelectedValue) + "',@vchPrice='" + Convert.ToString(txtPrice.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_SchoolInventory] @command='update',@intEquipment_id='" + Convert.ToString(ddlInventory.SelectedValue) + "',@vchQty='" + Convert.ToString(txtQty.Text.Trim()) + "',@intUnit_Id='" + Convert.ToString(ddlUnit.SelectedValue) + "',@vchPrice='" + Convert.ToString(txtPrice.Text.Trim()) + "',@intInventory_Id='" + Convert.ToString(Session["intInventory_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");                 
                    btnSubmit.Text = "Submit";
                }
            }
        }
    }
    protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intInventory_Id"] = Convert.ToString(gvList.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_SchoolInventory @command='edit',@intInventory_Id='" + Convert.ToString(Session["intInventory_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlInventory.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intEquipment_id"]);
                txtQty.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchQty"]);
                ddlUnit.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intUnit_Id"]);
                txtPrice.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPrice"]);
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["intInventory_Id"] = Convert.ToString(gvList.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_SchoolInventory] @command='delete',@intInventory_Id='" + Convert.ToString(Session["intInventory_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Record Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
}