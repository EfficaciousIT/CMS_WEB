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
using System.Net;
using System.IO;

public partial class frmUserRights : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    int i = 0;
    string VisitorsIPAddr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //GetComputer_InternetIP();
        

        if (!IsPostBack)
        {
            fillUserType();
            fillDepartment();
            fillParentModule();
        }
    }
    
    protected void fillUserType()
    {
        strQry = "usp_UserRights @command='usertype'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            drpType.DataTextField = "vchUser_name";
            drpType.DataValueField = "intUserType_id";
            drpType.DataSource = dsObj;
            drpType.DataBind();            
        }
        drpType.Items.Insert(0, "---Select---");
    }
    protected void fillDepartment()
    {
        strQry = "usp_UserRights @command='selectDepartment',@intSchool_id='1'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            drpDepartment.DataTextField = "vchDepartment_name";
            drpDepartment.DataValueField = "intDepartment";
            drpDepartment.DataSource = dsObj;
            drpDepartment.DataBind();
            drpDepartment.Items.Insert(0, "---Select---");
        }
        else
        {
            drpDepartment.DataSource = dsObj;
            drpDepartment.DataBind();
            drpDepartment.Items.Insert(0, "---Select---");
        }        
    }

    protected void fillParentModule()
    {
        strQry = "usp_UserRights @command='ParentModule',@intSchool_id='1'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            drpParent.DataTextField = "vchparentmodule_name";
            drpParent.DataValueField = "intparentmodule_id";
            drpParent.DataSource = dsObj;
            drpParent.DataBind();
            drpParent.Items.Insert(0, "---Select---");
        }
        else
        {            
            drpParent.DataSource = dsObj;
            drpParent.DataBind();
            drpParent.Items.Insert(0, "---Select---");
        }
        
    }
    protected void fillMainModule()
    {
        strQry = "usp_UserRights @command='Module',@intparent_id='" + Convert.ToString(drpParent.SelectedValue.ToString()) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            chkModule.DataTextField = "vchModule_name";
            chkModule.DataValueField = "intmodule_id";
            chkModule.DataSource = dsObj;
            chkModule.DataBind();
            
        }
        else
        {

            chkModule.DataSource = dsObj;
            chkModule.DataBind();
            chkModule.Items.Insert(0, "---Select---");
        }
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        for (int j = 0; j < chkModule.Items.Count; j++)
        {
            if(chkModule.Items[j].Selected)
            {
                string strModule_id = chkModule.Items[j].Value.ToString();
                strQry = "usp_UserRights @command='Insert',@intUserType_id='" + drpType.SelectedValue.ToString() + "',@intDepartment_id='" + Convert.ToString(drpDepartment.SelectedValue) + "', @intUser_id='" + Convert.ToString(drpUser.SelectedValue) + "', @intParent_id=' " + Convert.ToString(drpParent.SelectedValue) + "', @intModule_id='" + Convert.ToString(strModule_id) + "', @intSubModule_id='', @intSchool_id='1'";
                i = sExecuteQuery(strQry);
                if (i > 0)
                {
                    MessageBox("Rights Assign successfully");
                }
            }
        }
        
        
    }    
    protected void drpParent_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillMainModule();
    }
    protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_UserRights @command='UserName',@intUserType_id='" + drpType.SelectedValue.ToString() + "',@intDepartment_id='" + drpDepartment.SelectedValue.ToString() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            drpUser.DataTextField = "vchFirst_name";
            drpUser.DataValueField = "intTeacher_id";
            drpUser.DataSource = dsObj;
            drpUser.DataBind();
            drpUser.Items.Insert(0, "---Select---");
        }
        else
        {
            drpUser.DataSource = dsObj;
            drpUser.DataBind();
            drpUser.Items.Insert(0, "---Select---");
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
    protected void drpParent_SelectedIndexChanged1(object sender, EventArgs e)
    {
        fillMainModule();
    }
}
