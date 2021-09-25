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

public partial class frmRegistrationSearch : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTile = new Label();
        //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTile.Visible = true;
        //lblTile.Text = "Registration From";
        if (!IsPostBack)
        {
            Button2.Visible = false;
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
        if ((btnYes.Checked == false) && (btnNo.Checked == false))
        {
            MessageBox("Please select option");
        }
        else
        {
            if (btnYes.Checked == true)
            {                
                for (int i = 0; i < grdTestSchedule.Rows.Count; i++)
                {
                    Label Label = (Label)grdTestSchedule.Rows[i].Cells[0].FindControl("lblTestID");

                    RadioButton chk = (RadioButton)grdTestSchedule.Rows[i].Cells[0].FindControl("chkCtrl");

                    if (chk.Checked)
                    {
                        Response.Redirect("frmRegistrationSlip.aspx?EnquiryID=" + Label.Text.Trim() + "");
                    }
                }
            }
            if (btnNo.Checked == true)
            {
                Response.Redirect("frmRegistrationSlip.aspx?EnquiryID=0");
            }
            
        }
        
    }
    protected void BbtnSearch_Click(object sender, EventArgs e)
    {
        strQry = "usp_TestSchedule @command='SearchCandidate',@candiateName='" + txtCandidateName.Text.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grdTestSchedule.Visible = true;
            grdTestSchedule.DataSource = dsObj;
            grdTestSchedule.DataBind();
            Button2.Visible = true;

        }
        else
        {
            grdTestSchedule.DataSource = dsObj;
            grdTestSchedule.DataBind();
            Button2.Visible = false;
        }
    }
    protected void btnYes_CheckedChanged(object sender, EventArgs e)
    {
        trSearch.Visible = true;
    }
    protected void btnNo_CheckedChanged(object sender, EventArgs e)
    {
        trSearch.Visible = false;
        grdTestSchedule.Visible = false;
        Response.Redirect("frmNewInquiry.aspx", true);
    }
}
