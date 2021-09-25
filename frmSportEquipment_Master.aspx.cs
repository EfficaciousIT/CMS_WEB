using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class frmSportEquipment_Master : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
            fGetSportName();
            fGetStoreName();
        }
    }

    protected void fGrid()
    {
        strQry = "usp_tblSportEquipment_Master @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtEquipmentName.Text = "";
			txtEquipmentQuantity.Text = "";
			txtEquipmentPrice.Text = "";
			txtEquipmentDetails.Text = "";
			ddlSportName.ClearSelection();
			ddlStoreName.ClearSelection();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtEquipmentName.Text == "")
        {
            MessageBox("Please Insert Equipment  Name");
            txtEquipmentName.Focus();
            return;
        }

        if (txtEquipmentQuantity.Text == "")
        {
            MessageBox("Please Insert Equipment Quantity Name");
            txtEquipmentQuantity.Focus();
            return;
        }

        if (txtEquipmentPrice.Text == "")
        {
            MessageBox("Please Insert Price");
            txtEquipmentPrice.Focus();
            return;
        }

        if (txtEquipmentDetails.Text == "")
        {
            MessageBox("Please Insert Equipment Details");
            txtEquipmentName.Focus();
            return;
        }

        if (ddlSportName.Text == "0")
        {
            MessageBox("Please Select Sport name");
            ddlSportName.Focus();
            return;
        }

        if (ddlStoreName.Text == "0")
        {
            MessageBox("Please Select Store name");
            ddlStoreName.Focus();
            return;
        }

        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblSportEquipment_Master @command='checkExist',@vchEquipment_name='" + Convert.ToString(txtEquipmentName.Text.Trim()) + "',@intEquipment_quantity='" + Convert.ToString(txtEquipmentQuantity.Text.Trim()) + "',@intEquipment_price='" + Convert.ToString(txtEquipmentPrice.Text.Trim()) + "',@vchEquipment_detail='" + Convert.ToString(txtEquipmentDetails.Text.Trim()) + "', @intSport_id='" + ddlSportName.SelectedValue.Trim() + "',@intStore_id='" + ddlStoreName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Equipment Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblSportEquipment_Master] @command='insert',@vchEquipment_name='" + Convert.ToString(txtEquipmentName.Text.Trim()) + "',@intEquipment_quantity='" + Convert.ToString(txtEquipmentQuantity.Text.Trim()) + "',@intEquipment_price='" + Convert.ToString(txtEquipmentPrice.Text.Trim()) + "',@vchEquipment_detail='" + Convert.ToString(txtEquipmentDetails.Text.Trim()) + "',@intSport_id='" + ddlSportName.SelectedValue.Trim() + "',@intStore_id='" + ddlStoreName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {                   
                    MessageBox("Equipment Inserted Successfully!");
                    fGrid();
                }
            }
        }
        else
        {
            //strQry = "usp_tblSportEquipment_Master @command='checkExist',@vchEquipment_name='" + Convert.ToString(txtEquipmentName.Text.Trim()) + "',@intEquipment_quantity='" + Convert.ToString(txtEquipmentQuantity.Text.Trim()) + "',@intEquipment_price='" + Convert.ToString(txtEquipmentPrice.Text.Trim()) + "',@vchEquipment_detail='" + Convert.ToString(txtEquipmentDetails.Text.Trim()) + "', @intSport_id='" + ddlSportName.SelectedValue.Trim() + "',@intStore_id='" + ddlStoreName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Record Already Exists");
            //    return;
            //}
            //else
            //{
                strQry = "exec [usp_tblSportEquipment_Master] @command='update',@intEquipment_id='" + Convert.ToString(Session["EquipmentID"]) + "',@vchEquipment_name='" + Convert.ToString(txtEquipmentName.Text.Trim()) + "',@intEquipment_quantity='" + Convert.ToString(txtEquipmentQuantity.Text.Trim()) + "',@intEquipment_price='" + Convert.ToString(txtEquipmentPrice.Text.Trim()) + "',@vchEquipment_detail='" + Convert.ToString(txtEquipmentDetails.Text.Trim()) + "', @intSport_id='" + ddlSportName.SelectedValue.Trim() + "',@intStore_id='" + ddlStoreName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";

                if (sExecuteQuery(strQry) != -1)
                {                               
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                    fGrid(); 
                }
           // }
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtEquipmentName.Text = "";
        txtEquipmentQuantity.Text = "";
        txtEquipmentPrice.Text = "";
        txtEquipmentDetails.Text = "";
        ddlSportName.ClearSelection();
        ddlStoreName.ClearSelection();
        btnSubmit.Text = "Submit";
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



    public void fGetStoreName()
    {
        try
        {
            strQry = "exec usp_tblSportEquipment_Master @command='GetStoreName',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlStoreName, strQry, "vchStore_name", "intStore_id");

            //if (ddlStudent.Items.Count > 1)
            //    ddlStudent.Items.Add(new ListItem("All", "-1"));
            //else
            //    ddlStudent.DataSource = null;
        }
        catch
        {

        }
    }
    public void fGetSportName()
    {
        try
        {
            strQry = "exec usp_tblSportEquipment_Master @command='GetSportName',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlSportName, strQry, "vchSport_name", "intSport_id");

            //if (ddlStudent.Items.Count > 1)
            //    ddlStudent.Items.Add(new ListItem("All", "-1"));
            //else
            //    ddlStudent.DataSource = null;
        }
        catch
        {

        }
    }

   /* protected void fGetStoreName()
    {
        string str1 = "[usp_tblSportEquipment_Master] @command='GetStoreName',@intStore_id='" + ddlStoreName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlStoreName, str1, "vchStore_name","intStore_id");
    }
    */
    /*protected void fGetSportName()
    {
        string str1 = "[usp_tblSportEquipment_Master] @command='GetSportName',@intSport_id='" + ddlSportName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlSportName, str1, "vchSport_name", "intSport_id");
    }
    */
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["EquipmentID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblSportEquipment_Master] @command='delete',@intEquipment_id='" + Convert.ToString(Session["EquipmentID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Equipment has been Deleted Successfully!");
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
            Session["EquipmentID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblSportEquipment_Master @command='edit',@intEquipment_id='" + Convert.ToString(Session["EquipmentID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtEquipmentName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEquipment_name"]);
                txtEquipmentQuantity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intEquipment_quantity"]);
                txtEquipmentPrice.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intEquipment_price"]);
                txtEquipmentDetails.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEquipment_detail"]);
                ddlSportName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intSport_id"]);
                ddlStoreName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStore_id"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    
}