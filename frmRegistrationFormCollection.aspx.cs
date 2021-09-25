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

public partial class frmRegistrationFormCollection : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strReffNo = string.Empty;
    string strMaxID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTile = new Label();
        //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTile.Visible = true;
        //lblTile.Text = "Form Acceptance";
        if (!IsPostBack)
        {
            btnSub.Visible = false;
            fGrid();
        }

    }
    protected void fGrid()
    {
        strQry = "usp_RegistrationAccept @command='gridSelect',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetails.DataSource = dsObj;
            grvDetails.DataBind();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
       
        if (txtRegistrationNo.Text != "")
        {
            //string strRegistrationNo = txtRegistrationNo.Text.Trim();

            //strRegistrationNo = strRegistrationNo.Insert(2, "/").Insert(5, "/").Insert(10, "/");

            //txtRegistrationNo.Text = strRegistrationNo;

            strQry = "usp_RegistrationAccept @command='select',@vchRF_no='" + txtRegistrationNo.Text.Trim() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdcandidate.DataSource = dsObj;
                grdcandidate.DataBind();
                btnSub.Visible = true;

            }
            else
            {
                grdcandidate.DataSource = dsObj;
                grdcandidate.DataBind();
                btnSub.Visible = false;
            }

        }
    }    
    protected void btnSub_Click(object sender, EventArgs e)
    {
        //string strRegistrationNo = txtRegistrationNo.Text.Trim();

        //strRegistrationNo = strRegistrationNo.Insert(2, "/").Insert(5, "/").Insert(10, "/");

        //txtRegistrationNo.Text = strRegistrationNo;

        //strQry = "usp_RegistrationAccept @command='GetNewID'";
        //dsObj = sGetDataset(strQry);
        //if (dsObj.Tables[0].Rows.Count > 0)
        //{
        //    strReffNo = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
        //    strMaxID = Convert.ToString(dsObj.Tables[0].Rows[0][1]);

        //    strQry = "usp_RegistrationAccept @command='Update',@RegistrationNo='" + strReffNo.Trim() + "',@vchRF_no='" + strRegistrationNo.Trim() + "',@ReffNo='" + strMaxID.Trim() + "'";
        //    int i = sExecuteQuery(strQry);
        //    if (i > 0)
        //    {
        //        //MessageBox("Registration Form Accepted");

        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registration Form Accepted');window.location ='frmRegistrationFormCollection.aspx';", true);
        //    }

        //}

        for (int i = 0; i < grdcandidate.Rows.Count; i++)
        {
            Label Label = (Label)grdcandidate.Rows[i].Cells[0].FindControl("lblTestID");

            RadioButton chk = (RadioButton)grdcandidate.Rows[i].Cells[0].FindControl("chkCtrl");

            if (chk.Checked)
            {
                strQry = "usp_RegistrationAccept @command='GetNewID'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    strReffNo = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                    strMaxID = Convert.ToString(dsObj.Tables[0].Rows[0][1]);

                    strQry = "usp_RegistrationAccept @command='Update',@RegistrationNo='" + strReffNo.Trim() + "',@vchRF_no='" + Label.Text.Trim() + "',@ReffNo='" + strMaxID.Trim() + "'";
                    int k = sExecuteQuery(strQry);
                    if (k > 0)
                    {
                        //MessageBox("Registration Form Accepted");

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registration Form Accepted');window.location ='frmRegistrationFormCollection.aspx';", true);
                    }

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
}
