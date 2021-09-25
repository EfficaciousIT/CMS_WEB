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

public partial class frmSessionMaster : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();            
        }
    }
    protected void fGrid()
    {
        strQry = "usp_SessionMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DateTime t1 = Convert.ToDateTime(txtFrmTime.Text);

        DateTime t2 = Convert.ToDateTime(txttotime.Text);

        if (t1.TimeOfDay.Ticks > t2.TimeOfDay.Ticks)
        {

            MessageBox("Invalid Time Format!");
            return;
        }
        
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_SessionMaster @command='checkExist',@dtStartTime='" + Convert.ToString(txtFrmTime.Text) + "',@dtEndTime='" + Convert.ToString(txttotime.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_SessionMaster] @command='insert',@vchSessionName='" + Convert.ToString(txtName.Text.Trim()) + "',@dtStartTime='" + Convert.ToString(txtFrmTime.Text) + "',@dtEndTime='" + Convert.ToString(txttotime.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Session Inserted Successfully!");
                    txtFrmTime.Text = "";
                    txtName.Text = "";
                    txttotime.Text = "";
                }
            }
        }
        else
        {
            strQry = "usp_SessionMaster @command='checkExist',@dtStartTime='" + Convert.ToString(txtFrmTime.Text) + "',@dtEndTime='" + Convert.ToString(txttotime.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_SessionMaster] @command='update',@vchSessionName='" + Convert.ToString(txtName.Text.Trim()) + "',@dtStartTime='" + Convert.ToString(txtFrmTime.Text) + "',@dtEndTime='" + Convert.ToString(txttotime.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSession_id='" + Convert.ToString(Session["SessionID"]) + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    txtFrmTime.Text = "";
                    txtName.Text = "";
                    txttotime.Text = "";

                }
            }
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
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtFrmTime.Text = "";
        txtName.Text = "";
        txttotime.Text = "";
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["SessionID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_SessionMaster @command='edit',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intSession_id='" + Convert.ToString(Session["SessionID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSessionName"]);
                txtFrmTime.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtStartTime"]);
                txttotime.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtEndTime"]);                
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
            Session["SessionID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_SessionMaster] @command='delete',@intSession_id='" + Convert.ToString(Session["SessionID"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Session Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
}
