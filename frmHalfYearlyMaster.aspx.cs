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


public partial class frmHalfYearlyMaster :DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
            FillDuration();
            btnSubmit.Visible = false;
            TabContainer1.Tabs[1].Visible = false;
        }
    }
    public void FillDuration()
    {
        try
        {

            strQry = "exec usp_tblHalfYearlyMaster @command='getDuration',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlType, strQry, "vchDuration", "intDuration_Id");
        }
        catch
        {

        }
    }
    protected void fGrid()
    {
        strQry = "usp_tblHalfYearlyMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtName.Text = "";
            TabContainer1.Tabs[1].Visible = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (btnSubmit.Text == "Update")
        {
            string str = "usp_tblHalfYearlyMaster @command='checkExist',@intDuration_Id='" + Convert.ToString(ddlType.SelectedValue) + "',@vchMonth='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(str);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblHalfYearlyMaster] @command='update',@intDuration_Id='" + Convert.ToString(ddlType.SelectedValue) + "',@vchMonth='" + Convert.ToString(txtName.Text.Trim()) + "',@int_half_yearly_id='" + Convert.ToString(Session["int_half_yearly_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                sExecuteQuery(strQry);
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
            }

        }
        else
        {
           
        }

    }


    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //try
        //{
        //    Session["int_half_yearly_ID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
        //    strQry = "";
        //    strQry = "exec [usp_tblHalfYearlyMaster] @command='delete',@int_half_yearly_id='" + Convert.ToString(Session["int_half_yearly_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
        //    if (sExecuteQuery(strQry) != -1)
        //    {
        //        fGrid();
        //        MessageBox("Record Deleted Successfully!");
        //    }
        //}
        //catch
        //{

        //}
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["int_half_yearly_ID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblHalfYearlyMaster @command='edit',@int_half_yearly_id='" + Convert.ToString(Session["int_half_yearly_ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlType.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDuration_Id"]);
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMonth"]);
                TabContainer1.Tabs[1].Visible = true;
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Visible = true;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
}