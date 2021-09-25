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

public partial class StandardMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            fGrid();
            FillStandard();
        }
    }
    protected void fGrid()
    {
        strQry = "usp_StandardMasterFee_master @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtFEE.Text = "";
        }
    }

    public void FillStandard()
    {
        
        try
        {
            strQry = "";
            strQry = "exec usp_StandardMasterFee_master @command='selectStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlStandard, strQry, "vchStandard_name", "intstandard_id");
            ddlStandard.SelectedValue = "1";

        }
        catch
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        if(ddlStandard.SelectedValue=="0")
        {
            MessageBox("Please Select Standard!");
            return;
        }
            if (txtFEE.Text == "")
        {
            MessageBox("Please Insert Standard Name!");
            txtFEE.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_StandardMasterFee_master @command='checkExiststandardFee',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";


            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Standard Already Exists");
                return;
            }
            //else
            //{
            //    //strQry = "exec [usp_StandardMaster] @command='insert',@vchStandard_name='" + Convert.ToString(txtFEE.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
            //    strQry = "exec [usp_StandardMaster] @command='insertFeeAmount',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@FeeAmount='" + Convert.ToString(txtFEE.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";

            //    if (sExecuteQuery(strQry) != -1)
            //    {
            //        fGrid();
            //        MessageBox("Standard Inserted Successfully!");
            //    }
            //}      
            strQry = "exec [usp_StandardMasterFee_master] @command='insertFeeAmount',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@FeeAmount='" + Convert.ToString(txtFEE.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["UserType_id"] + "',@InseretIP='" + GetSystemIP() + "',@intAcademic_id='" + Session["AcademicID"] + "'";

            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Standard Inserted Successfully!");
            }
        }
        else
        {
            strQry = "usp_StandardMaster @command='checkExist',@vchStandard_name='" + Convert.ToString(txtFEE.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Standard Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_StandardMasterFee_master] @command='update',@intstandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "',@FeeAmount='" + Convert.ToString(txtFEE.Text) + "',@intstandardFee_id='" + Convert.ToString(Session["intstandardFee_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["UserType_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtFEE.Text = "";
        ddlStandard.SelectedValue = "0";
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intstandardFee_id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_StandardMasterFee_master @command='edit',@intstandardFee_id='" + Convert.ToString(Session["intstandardFee_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtFEE.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["FeeAmount"]);           
                ddlStandard.SelectedValue= Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                TabContainer1.ActiveTabIndex = 1;
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
            Session["intstandardFee_id"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_StandardMasterFee_master] @command='delete',@intstandardFee_id='" + Convert.ToString(Session["intstandardFee_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Standard Deleted Successfully!");
            }
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
}
