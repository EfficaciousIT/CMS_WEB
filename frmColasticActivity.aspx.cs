using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmColasticActivity : DBUtility
{
    string strQry;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        Gdata();
       
    }
    public void Gdata()
    {
        strQry = "execute usp_tblColasticactivity @command='select',@intSchool_id='" + Session["School_Id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
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
        if (btnSubmit.Text == "Submit")
        {
            strQry = "execute usp_tblColasticactivity @command='insert',@intSection_id='" + ddlSection.SelectedValue.ToString() + "',@dtDate='" + txtDate.Text.Trim().ToString() + "',@vchDescription='" + txtDet.Text.Trim().ToString() + "',@intInsertedBy='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
           
                MessageBox("Record has been inserted");
                Gdata();
                clear();
                TabContainer1.ActiveTabIndex = 0;


        }
        if(btnSubmit.Text=="update")
        {
            strQry = "execute usp_tblColasticactivity @command='update',@intColasticActivity_id='" + Session["intColasticActivityID"] + "',@intSection_id='" + ddlSection.SelectedValue.ToString() + "',@dtDate='" + txtDate.Text.Trim().ToString() + "',@vchDescription='" + txtDet.Text.Trim().ToString() + "',@intInsertedBy='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            MessageBox("Record has been Updated");
            clear();
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    public void clear()
    {
        txtDate.Text = "";
        txtDet.Text = "";
        ddlSection.ClearSelection();
        btnSubmit.Text = "Submit";
    }
    protected void grvDetail_RowEditing1(object sender, GridViewEditEventArgs e)
    {
        Session["intColasticActivityID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
        strQry = "execute usp_tblColasticactivity @command='edit',@intSchool_id='" + Session["School_id"] + "',@intColasticActivity_id='" + Session["intColasticActivityID"].ToString() + "',@intAcademic_id='" + Session["AcademicID"].ToString() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ddlSection.SelectedValue = dsObj.Tables[0].Rows[0]["intSection_id"].ToString();
            txtDate.Text = dsObj.Tables[0].Rows[0]["dtDate"].ToString();
            txtDet.Text = dsObj.Tables[0].Rows[0]["vchDescription"].ToString();
            btnSubmit.Text = "update";
            TabContainer1.ActiveTabIndex = 1;
        }
        if (ddlSection.SelectedValue == "1")
        {
            ddlSection.SelectedIndex = 1;
        }
        if (ddlSection.SelectedValue == "2")
        {
            ddlSection.SelectedIndex = 2;
        }

      
    }
    protected void grvDetail_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        ViewState["intColasticActivityID1"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
        strQry = "execute usp_tblColasticactivity @command='delete',@intSchool_id='" + Session["School_id"] + "',@intColasticActivity_id='" + ViewState["intColasticActivityID1"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
        dsObj = sGetDataset(strQry);
        MessageBox("Record has been Deleted");
        Gdata();
    }
}