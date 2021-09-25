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

public partial class HostelFeeMaster : DBUtility
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
            ViewState["Edit"] = "No";
        }
    }
    protected void fillGrid()
    {
        strQry = "usp_HostelFeesHead  @type='select',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
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
        strFeeID = Convert.ToString(grdFeeMaster.DataKeys[e.NewEditIndex].Value);

        ViewState["strFeeID"] = strFeeID;

        strQry = "usp_HostelFeesHead  @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@HostelFeeId='" + strFeeID.Trim() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ViewState["Edit"] = "Yes";
            TabContainer1.ActiveTabIndex = 1;
            txtParticular.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFee"]);
            txtFeeAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["FeeAmt"]);
            if (Convert.ToString(dsObj.Tables[0].Rows[0]["feeType"]) == "2")
            {
                drpType.SelectedValue = "2";
            }
            else
            {
                drpType.SelectedValue = "1";
            }

        }
    }
    protected void grdFeeMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strFeeID = Convert.ToString(grdFeeMaster.DataKeys[e.RowIndex].Value);

        strQry = "usp_HostelFeesHead @type='Delete',@HostelFeeId='" + Convert.ToString(strFeeID) + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

        k = sExecuteQuery(strQry);
        if (k > 0)
        {
            fillGrid();
            MessageBox("Particulars's Deleted Successfully");

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (drpType.SelectedValue == "0")
        {
            MessageBox("Please Select Type!");
            drpType.Focus();
            return;
        }
        if (txtParticular.Text == "")
        {
            MessageBox("Please Enter Head Name!");
            txtParticular.Focus();
            return;
        }
        if (txtFeeAmt.Text == "")
        {
            MessageBox("Please Enter Amount Name!");
            txtFeeAmt.Focus();
            return;
        }
        
        if (Convert.ToString(ViewState["Edit"]) == "Yes")
        {
            strQry = "usp_HostelFeesHead @type='Update',@feeType='" + drpType.Text.Trim() + "',@vchFee='" + txtParticular.Text.Trim() + "',@FeeAmt='" + txtFeeAmt.Text.Trim() + "',@HostelFeeId='" + Convert.ToString(ViewState["strFeeID"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@vchUpdatedIp='" + GetSystemIP() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            k = sExecuteQuery(strQry);
            if (k > 0)
            {
                
                MessageBox("Particulars's Updated Successfully");
                txtParticular.Text = "";
                drpType.SelectedValue = "0";
                txtFeeAmt.Text = "";
                fillGrid();

            }

        }
        else
        {
            strQry = "usp_HostelFeesHead @type='Insert',@feeType='" + drpType.Text.Trim() + "',@vchFee='" + txtParticular.Text.Trim() + "',@FeeAmt='" + txtFeeAmt.Text.Trim() + "',@intInsertedBy='" + Session["User_id"] + "',@vchInsertedIP='" + GetSystemIP() + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            k = sExecuteQuery(strQry);
            if (k > 0)
            {                
                MessageBox("Particulars's Addedd Successfully");
                txtParticular.Text = "";
                drpType.SelectedValue = "0";
                txtFeeAmt.Text = "";
                fillGrid();
            }

        }
    }
}