using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;



public partial class frmItemTypeMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj;

    public SqlConnection strCOn = new SqlConnection("Data Source=103.255.188.128;Initial Catalog=DBCentralModel;User Id=sa;Password=SA@Admin;Max Pool Size=5000;Pooling=False;");
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    FillItem();
                    FillGrid();
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
    public void FillItem()
    {
        try
        {
            strQry = "exec usp_ItemType @type='FillItem',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpItem, strQry, "vchItem_name", "intEquipItem_id");
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
            strQry = "exec usp_ItemType @type='FillGrid',@intSchool_id='" + Session["School_Id"] + "'";
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
        if (drpItem.SelectedValue == "0")
        {
            MessageBox("Please Select Building Name!");
            drpItem.Focus();
            return;
        }
        if (txtType.Text == "")
        {
            MessageBox("Please Enter Wing Name!");
            txtType.Focus();
            return;
        }

        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                //strQry = "exec usp_ItemType  @type='CheckSaveExist',@intEquipItem_id='" + Convert.ToString(drpItem.SelectedValue).Trim() + "',@vchItem_Type='" + Convert.ToString(txtType.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                //dsObj = sGetDataset(strQry);
                //if (dsObj.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox("Entered Record Already Exist");
                //    return;
                //}

                //strQry = "exec usp_ItemType  @type='Insert',@intEquipItem_id='" + Convert.ToString(drpItem.SelectedValue).Trim() + "',@vchItem_Type=" + Convert.ToString(txtType.Text).Trim() + ",@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                //if (sExecuteQuery(strQry) != -1)
                //{
                //    MessageBox("Record Saved Successfully!");
                //    drpItem.ClearSelection();
                //    txtType.Text = "";
                //    FillGrid();
                //}
                strCOn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = strCOn;
                // cmd.CommandText = "Insert into Category1 (HeadName,Type) values('" + txtCAtegory1.Text + "','" + Type + "')";
                cmd.CommandText = "Insert into tblEquipTypeMaster (intEquipItem_id,vchItem_Type,intSchool_id,intInserted_by,InseretIP,intAcademic_id) values(@intEquipItem_id,@vchItem_Type,@intSchool_id,@intInserted_by,@InseretIP,@intAcademic_id)";
                cmd.Parameters.AddRange(new SqlParameter[]
                   {
                      new SqlParameter("@intEquipItem_id", Convert.ToString(drpItem.SelectedValue).Trim()),
                      new SqlParameter("@vchItem_Type", Convert.ToString(txtType.Text).Trim()),
                      new SqlParameter("@intSchool_id", Session["School_Id"]),
                      new SqlParameter("@intInserted_by", Session["User_id"]),
                      new SqlParameter("@InseretIP", GetSystemIP()),
                      new SqlParameter("@intAcademic_id", Convert.ToString(Session["AcademicID"])),
                   });

                int ans = cmd.ExecuteNonQuery();

                strCOn.Close();
                if (ans > 0)
                {
                    MessageBox("Record Saved Successfully!");
                    drpItem.ClearSelection();
                    txtType.Text = "";
                    FillGrid();
                }
                
            }
            else
            {
                //strQry = "";
                //strQry = "exec usp_ItemType  @type='CheckUpdateExist',@intType_id='" + ViewState["TypeID"] + "',@intEquipItem_id='" + Convert.ToString(drpItem.SelectedValue).Trim() + "',@vchItem_Type='" + Convert.ToString(txtType.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                //dsObj = sGetDataset(strQry);
                //if (dsObj.Tables[0].Rows.Count > 0)
                //{
                //    MessageBox("Entered Record Already Exist");
                //    return;
                //}

                //strQry = "exec usp_ItemType  @type='Update',@intType_id='" + ViewState["TypeID"] + "',@intEquipItem_id='" + Convert.ToString(drpItem.SelectedValue).Trim() + "',@vchItem_Type='" + Convert.ToString(txtType.Text).Trim() + "',@intSchool_id='" + Session["School_Id"] + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                //if (sExecuteQuery(strQry) != -1)
                //{
                //    MessageBox("Record Updated Successfully!");
                //    drpItem.ClearSelection();
                //    txtType.Text = "";
                //    btnSubmit.Text = "Submit";
                //    FillGrid();
                //}
                strCOn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = strCOn;
                // cmd.CommandText = "Insert into Category1 (HeadName,Type) values('" + txtCAtegory1.Text + "','" + Type + "')";
                cmd.CommandText = "update tblEquipTypeMaster set intEquipItem_id=@intEquipItem_id,vchItem_Type=@vchItem_Type,intSchool_id=@intSchool_id,IntUpdate_by=@IntUpdate_by,UpdateIP=@UpdateIP where intType_id=@intType_id";
                cmd.Parameters.AddRange(new SqlParameter[]
                   {
                       new SqlParameter("@intType_id", ViewState["TypeID"]),
                      new SqlParameter("@intEquipItem_id", Convert.ToString(drpItem.SelectedValue).Trim()),
                      new SqlParameter("@vchItem_Type", Convert.ToString(txtType.Text).Trim()),
                      new SqlParameter("@intSchool_id", Session["School_Id"]),
                      new SqlParameter("@IntUpdate_by", Session["User_id"]),
                      new SqlParameter("@UpdateIP", GetSystemIP()),
                   });

                int ans = cmd.ExecuteNonQuery();

                strCOn.Close();
                if (ans > 0)
                {
                    MessageBox("Record Updated Successfully!");
                    drpItem.ClearSelection();
                    txtType.Text = "";
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
            ViewState["TypeID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["TypeID"] = id;
            strQry = "exec usp_ItemType  @type='Edit',@intType_id='" + Convert.ToString(id) + "',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpItem.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intEquipItem_id"]);
                txtType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchItem_Type"]);

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
            ViewState["TypeID"] = id;
            strQry = "exec usp_ItemType @type='Delete',@intType_id='" + Convert.ToString(id) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
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