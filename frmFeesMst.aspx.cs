using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmFeesMst : DBUtility
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
                    FillSTD();
                    FillParticulars();
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
            strQry = "exec usp_FeesAssignSTD @type='FillGrid',@intSchool_Id='"+ Convert.ToString(Session["School_Id"]) +"',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
            dsObj=sGetDataset(strQry);
            grvDetail.DataSource=dsObj;
            grvDetail.DataBind();
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
            strQry = "exec usp_FeesAssignSTD @type='FillSTD',@intSchool_Id='"+ Convert.ToString(Session["School_Id"]) +"'";
             sBindDropDownList(ddlSTD,strQry,"vchStandard_name","intstandard_id");
        }
        catch
        {
            
        }
    }
    public void FillParticulars()
    {
        try 
	    {	        
		    strQry="";
            strQry="exec usp_FeesAssignSTD @type='FillFeeType', @intSchool_Id='"+ Convert.ToString(Session["School_Id"]) +"'";
              sBindDropDownList(ddlParticular,strQry,"vchFee","intTutionId");          
	    }
	    catch 
	    {
		
	    }
    }
    protected void grvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try 
	    {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                strQry = "";
                Boolean chk = false;
                for (int i = 0; i < chkSTD.Items.Count; i++)
                {
                    if (chkSTD.Items[i].Selected == true)
                    {
                        strQry = "exec [usp_FeesAssignSTD] @type='checkFeeExists',@intFee_Id='" + Convert.ToString(ddlParticular.SelectedValue) + "',@intSTD_Id='" + Convert.ToString(chkSTD.Items[i].Value) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
                        dsObj = sGetDataset(strQry);

                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            FillGrid();
                            MessageBox("Record Exist Already");
                            return;
                        }
                        strQry = "exec usp_FeesAssignSTD @type='Insert',@intFee_Id='" + Convert.ToString(ddlParticular.SelectedValue) + "',@intSTD_Id='" + Convert.ToString(chkSTD.Items[i].Value) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInsertedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchInsertedIP='" + GetSystemIP() + "'";
                        //strQry = "exec usp_FeesAssignSTD @type='Insert',@intFee_Id='" + Convert.ToString(ddlParticular.SelectedValue) + "',@intSTD_Id='" + Convert.ToString(chkSTD.Items[i].Value) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@vchFeeDesc='" + Convert.ToString(txtDesc.Text) + "',@dtEffFromDate='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@dtEffToDate='" + Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy") + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInsertedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchInsertedIP='" + GetSystemIP() + "'";
                        if (sExecuteQuery(strQry) != -1)
                        {
                            chk = true;
                        }
                        else
                        {
                            chk = false;
                            break;
                        }
                    }
                }
                if (chk == true)
                {
                    MessageBox("Record Saved Successfully!");
                    FillGrid();
                    Clear();
                }
            }
            else
            {

                strQry = "exec [usp_FeesAssignSTD] @type='checkFeeExists',@intFee_Id='" + Convert.ToString(ddlParticular.SelectedValue) + "',@intSTD_Id='" + Convert.ToString(chkSTD.SelectedValue) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);

                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    FillGrid();
                    MessageBox("Record Exist Already");
                    return;
                }
                strQry = "exec usp_FeesAssignSTD @type='Update',@intFeeDetId='" + Convert.ToString(ViewState["Id"]) + "',@intFee_Id='" + Convert.ToString(ddlParticular.SelectedValue) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                //strQry = "exec usp_FeesAssignSTD @type='Update',@intFeeDetId='" + Convert.ToString(ViewState["Id"]) + "',@intFee_Id='" + Convert.ToString(ddlParticular.SelectedValue) + "',@numAmount='" + Convert.ToString(txtAmt.Text).Trim() + "',@vchFeeDesc='" + Convert.ToString(txtDesc.Text) + "',@dtEffFromDate='" + Convert.ToDateTime(txtFrmDt.Text).ToString("MM/dd/yyyy") + "',@dtEffToDate='" + Convert.ToDateTime(txtToDt.Text).ToString("MM/dd/yyyy") + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                    FillGrid();
                    Clear();
                }
            }            
	    }
	    catch 
	    {
		
	    }
    }
    public void Clear()
    {
        try 
	    {	        
		    txtAmt.Text="";
            txtDesc.Text="";
            txtFrmDt.Text="";
            txtToDt.Text="";
            ddlParticular.SelectedValue="0";
            chkSTD.Items.Clear();
            ddlParticular.Enabled = true;
            chkSTD.Enabled = true;
            btnSubmit.Text = "Submit";
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
protected void  ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
{
    try 
	{	        
		FillGrid();
	}
	catch
	{
		
	}
}
protected void  ddlParticular_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        strQry = "";
        strQry = "exec usp_FeesAssignSTD @type='FillSTD',@intFee_Id='" + Convert.ToString(ddlParticular.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        sBindCheckBoxList(chkSTD, strQry, "vchStandard_name", "intstandard_id");
    }
    catch
    {
        
    }
    
}
protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
{
    try
    {
        int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
        ViewState["Id"] = id;
        strQry = "exec usp_FeesAssignSTD @type='FillGrid',@intFeeDetId='" + ViewState["Id"] + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        chkSTD.Items.Clear();
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ddlParticular.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intFee_Id"]);
            chkSTD.Items.Add(new ListItem(Convert.ToString(dsObj.Tables[0].Rows[0]["vchStandard_name"]),Convert.ToString(dsObj.Tables[0].Rows[0]["intSTD_Id"])));
            chkSTD.Items[0].Selected = true;
            txtAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
            txtDesc.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFeeDesc"]);
            txtFrmDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["FrmDt"]);
            txtToDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Todt"]);
            TabContainer1.ActiveTabIndex = 1;
            btnSubmit.Text = "Update";
            ddlParticular.Enabled = false;
            chkSTD.Enabled = false;
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
        strQry = "exec usp_FeesAssignSTD @type='Delete',@intFeeDetId='" + id + "',@intDeletedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchDeletedIP='" + GetSystemIP() + "'";
        if (sExecuteQuery(strQry) != -1)
        {
            MessageBox("Record Deleted Successfully!");
            FillGrid();
        }
    }
    catch
    {
        
    }
}
protected void btnClear_Click(object sender, EventArgs e)
{
    try
    {
        Clear();
    }
    catch 
    {
        
    }
}
}