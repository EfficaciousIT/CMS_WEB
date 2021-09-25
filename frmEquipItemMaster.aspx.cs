using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmEquipItemMaster : DBUtility
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
                    geturl();
                }
            }
            else
            {
                Response.Redirect("~\\Index.aspx", false);
            }

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
            strQry = "exec usp_EquipItemMaster @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                strQry = "exec usp_EquipItemMaster  @type='CheckSaveExist',@vchItem_name='" + Convert.ToString(txtItem.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_EquipItemMaster  @type='Insert',@vchItem_name='" + Convert.ToString(txtItem.Text).Trim() + "',@vchQuantity='" + Convert.ToString(txtQuantity.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully!");
                    txtItem.Text = "";
                    txtQuantity.Text = "";
                    FillGrid();
                }
            }
            else
            {

                strQry = "";
                strQry = "exec usp_EquipItemMaster  @type='CheckUpdateExist',@intEquipItem_id='" + ViewState["ItemID"] + "',@vchItem_name='" + Convert.ToString(txtItem.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Record Already Exist");
                    return;
                }

                strQry = "exec usp_EquipItemMaster  @type='Update',@intEquipItem_id='" + ViewState["ItemID"] + "',@vchItem_name='" + Convert.ToString(txtItem.Text).Trim() + "',@vchQuantity='" + Convert.ToString(txtQuantity.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    txtItem.Text = "";
                    txtQuantity.Text = "";
                    btnSubmit.Text = "Submit";
                    FillGrid();
                }

            }

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
            ViewState["ItemID"] = id;
            strQry = "exec usp_EquipItemMaster  @type='FillGrid',@intEquipItem_id='" + Convert.ToString(id) + "',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtItem.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchItem_name"]);
                txtQuantity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchQuantity"]);
                TBC.ActiveTabIndex = 1;
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
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            ViewState["ItemID"] = id;
            strQry = "exec usp_EquipItemMaster @type='Delete',@intEquipItem_id='" + Convert.ToString(id) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
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
            FillGrid();
        }
        catch
        {

        }
    }
}