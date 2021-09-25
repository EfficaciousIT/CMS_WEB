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

public partial class frmTransporterDet : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
           if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                //Label lblTitle = new Label();
                //lblTitle = (Label)Page.Master.FindControl("lblPageTitle");
                //lblTitle.Visible = true;
                //lblTitle.Text = "Transporter Detail";
                if (!IsPostBack)
                {
         
                FillGrid();
                geturl();
            }
           
        }
           else
           {
               Response.Redirect("~\\frmIndex.aspx", false);
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            if (btnSubmit.Text == "Submit")
            {
                
                strQry = "exec [usp_transporter] @command='insert',@vchTransporter_name='" + Convert.ToString(txtTranspoterName.Text).Trim() + "',@vchContact_Person='" + Convert.ToString(txtContactPerson.Text).Trim() + "',@numTelNo1='" + Convert.ToString(txtTel_1.Text).Trim() + "',@numTelNo2='" + Convert.ToString(txtTel_2.Text).Trim() + "',@numMobileNo='" + Convert.ToString(txtMob.Text).Trim() + "',@vchEmailID='" + Convert.ToString(txtEmail.Text).Trim() + "',@dtContractStartDate='" + Convert.ToDateTime(txtContractFrmDt.Text).ToString("MM/dd/yyyy") + "',@dtContractEndDate='" + Convert.ToDateTime(txtContractToDate.Text).ToString("MM/dd/yyyy") + "',@intInsertedBy='" + Session["User_Id"] + "',@vchInsertedIp='" + GetSystemIP() + "',@intSchool_id='" + Session["School_id"] + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    
                    MessageBox("Record Saved Successfully!");
                }
            }
            else
            {
                strQry = "exec [usp_transporter] @command='Update',@intTransporter_id='" + ViewState["TransId"] + "',@vchContact_Person='" + Convert.ToString(txtContactPerson.Text).Trim() + "',@vchTransporter_name='" + Convert.ToString(txtTranspoterName.Text).Trim() + "',@numTelNo1='" + Convert.ToString(txtTel_1.Text).Trim() + "',@numTelNo2='" + Convert.ToString(txtTel_2.Text).Trim() + "',@numMobileNo='" + Convert.ToString(txtMob.Text).Trim() + "',@vchEmailID='" + Convert.ToString(txtEmail.Text).Trim() + "',@dtContractStartDate='" + Convert.ToDateTime(txtContractFrmDt.Text).ToString("MM/dd/yyyy") + "',@dtContractEndDate='" + Convert.ToDateTime(txtContractToDate.Text).ToString("MM/dd/yyyy") + "',@intUpdatedBy='" + Session["User_Id"] + "',@vchUpdatedIp='" + GetSystemIP() + "',@intSchool_id='" + Session["School_id"] + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully!");
                }
            }
            clear();
            FillGrid();
        }
        catch
        {
            MessageBox("Insertion Failed!");
        }
    }

    public void FillGrid()
    {
        try
        {
            strQry = "exec usp_transporter @command='gridfill',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = new DataSet();
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvTransport.DataSource = dsObj;
                grvTransport.DataBind();
            }
            else
            {
                grvTransport.DataSource = null;
                grvTransport.DataBind();
            }
        }
        catch 
        {
            
        }
    }
    protected void grvTransport_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Label lblid = (Label)grvTransport.Rows[e.NewEditIndex].FindControl("lblTransId");
            ViewState["TransId"]=Convert.ToString(lblid.Text);
            strQry = "exec [usp_transporter] @command='edit',@intTransporter_id='" + ViewState["TransId"] + "',@intSchool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtContactPerson.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchContact_Person"]);
                txtContractFrmDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtContractStartDate"]);
                txtContractToDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtContractEndDate"]);
                txtEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmailID"]);
                txtMob.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numMobileNo"]);
                txtTel_2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numTelNo2"]);
                txtTel_1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numTelNo1"]);
                txtTranspoterName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTransporter_name"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
              //  txtTel_1.Text = Convert.ToString(dsObj.Tables[0].Rows[0][""]);
            }
        }  
        catch
        {
            
        }
    }
    public void clear()
    {
        txtContactPerson.Text ="";
        txtContractFrmDt.Text ="";
        txtContractToDate.Text = "";
        txtEmail.Text ="";
        txtMob.Text = "";
        txtTel_2.Text = "";
        txtTel_1.Text = "";
        txtTranspoterName.Text = "";
        btnSubmit.Text = "Submit";
    }
    protected void grvTransport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Label lblid = (Label)grvTransport.Rows[e.RowIndex].FindControl("lblTransId");
            ViewState["TransId"] = Convert.ToString(lblid.Text);

            strQry = "exec [usp_transporter] @command='delete',@intTransporter_id='" + ViewState["TransId"] + "',@intSchool_id='" + Session["School_id"] + "',@intDeleteBy='" + Session["User_Id"] + "',@vchDeletedIp='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully!");
                FillGrid();
            }
        }
        catch (Exception)
        {
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void grvTransport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTransport.PageIndex = e.NewPageIndex;
        grvTransport.DataBind();
        FillGrid();
    }
}
