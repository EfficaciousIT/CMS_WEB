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
using System.Data.SqlClient;

public partial class frmFeeHead : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    int k = 0;
    string strFeeID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            fillGrid();
            fillDuration();
            ViewState["Edit"] = "No";
        }
    }
    public void fillDuration()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesEntry @type='fillDuration',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpType, strQry, "vchDuration", "intDuration_Id");
        }
        catch
        {

        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(ViewState["Edit"]) == "Yes")
        {
            strQry = "exec [usp_FeesEntry] @type='CheckExist',@vchFee='" + txtParticular.Text.Trim() + "',@feeType='" + drpType.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                fillGrid();
                MessageBox("Record Exist Already");
                return;
            }
            else
            {
                strQry = "usp_FeesEntry @type='Update',@vchFee='" + txtParticular.Text.Trim() + "',@feeType='" + drpType.SelectedValue.Trim() + "',@intTutionId='" + Convert.ToString(ViewState["strFeeID"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@vchUpdatedIP='" + GetSystemIP() + "'";
                k = sExecuteQuery(strQry);
                if (k > 0)
                {
                    fillGrid();
                    MessageBox("Particulars's Updated Successfully");
                    txtParticular.Text = "";
                    drpType.SelectedValue = "0";
                }
            }
        }
        else
        {
            strQry = "exec [usp_FeesEntry] @type='CheckExist',@vchFee='" + txtParticular.Text.Trim() + "',@feeType='" + drpType.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                fillGrid();
                MessageBox("Record Exist Already");
                return;
            }
            else
            {
                strQry = "usp_FeesEntry @type='Insert',@vchFee='" + txtParticular.Text.Trim() + "',@feeType='" + drpType.SelectedValue.Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@vchInsertedIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                k = sExecuteQuery(strQry);
                if (k > 0)
                {
                    fillGrid();
                    MessageBox("Particulars's Addedd Successfully");
                    txtParticular.Text = "";
                    drpType.SelectedValue = "0";
                }
            }
        }        
    }
    protected void fillGrid()
    {
        strQry = "usp_FeesEntry  @type='select',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            TabContainer1.ActiveTabIndex = 0;
            grdFeeMaster.DataSource = dsObj;
            grdFeeMaster.DataBind();
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
    protected void grdFeeMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Button1.Text = "Update";
        strFeeID = Convert.ToString(grdFeeMaster.DataKeys[e.NewEditIndex].Value);

        ViewState["strFeeID"] = strFeeID;

        strQry = "usp_FeesEntry  @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intTutionId='" + strFeeID.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ViewState["Edit"] = "Yes";
            TabContainer1.ActiveTabIndex = 1;
            txtParticular.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFee"]);
            drpType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["feeType"]);
            //if (Convert.ToString(dsObj.Tables[0].Rows[0]["feeType"]) == "2")
            //{
            //    drpType.SelectedValue = "2";
            //}
            //else
            //{
            //    drpType.SelectedValue = "1";
            //}
            
        }

    }
    protected void grdFeeMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strFeeID = Convert.ToString(grdFeeMaster.DataKeys[e.RowIndex].Value);

        strQry = "usp_FeesEntry @type='Delete',@intTutionId='" + Convert.ToString(strFeeID) + "',@intDeletedBy='" + Session["User_Id"] + "',@vchDeletedIP='" + GetSystemIP() + "'";

        k = sExecuteQuery(strQry);
        if (k > 0)
        {
            fillGrid();
            MessageBox("Particulars's Deleted Successfully");

        }
    }
}
