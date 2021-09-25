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

public partial class frmDivision_master : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    DataSet dsObjNew = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
       
       
        if (!IsPostBack)
        {
            fGridafill();
            fSession();
            fStandard();
            fFloor();          
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["DivisionID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec [usp_DivisionMaster] @command='edit',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDivision_id='" + Convert.ToString(Session["DivisionID"]) + "'";
            dsObjNew = sGetDataset(strQry);
            if (dsObjNew.Tables[0].Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["vchDivisionName"]);
                drpSession.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["intSession_id"]);
                drpStandard.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["intstandard_id"]);
                drpFloor.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["intFloor"]);
                fRoom(Convert.ToString(dsObjNew.Tables[0].Rows[0]["intFloor"]));
                drpRoom.Text = Convert.ToString(dsObjNew.Tables[0].Rows[0]["intRoomNo"]);
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
        string StrDivision_id = "";
        StrDivision_id = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
        strQry = "exec [usp_DivisionMaster] @command='delete',@intDivision_id='" + StrDivision_id.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
        if (sExecuteQuery(strQry) != -1)
        {
            fGridafill();
            MessageBox("Record deleted Successfully!");

        }
    }
   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (drpSession.SelectedValue == "---Select----")
        {
            MessageBox("Please Select Session!");
            drpSession.Focus();
            return;
        }
        if (drpStandard.SelectedValue == "---Select----")
        {
            MessageBox("Please Select Standard!");
            drpStandard.Focus();
            return;
        }
        if (txtName.Text == "")
        {
            MessageBox("Please Insert Division!");
            txtName.Focus();
            return;
        }
        if (drpFloor.SelectedValue == "---Select----")
        {
            MessageBox("Please Select Floor!");
            drpFloor.Focus();
            return;
        }
        if (drpRoom.SelectedValue == "---Select----")
        {
            MessageBox("Please Select Room!");
            drpRoom.Focus();
            return;
        }
        strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            //strQry = "exec [usp_DivisionMaster] @command='checkExists',@vchDivisionName='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + drpStandard.SelectedValue.Trim() + "'";
            strQry = "exec [usp_DivisionMaster] @command='checkExists',@vchDivisionName='" + Convert.ToString(txtName.Text.Trim()) + "',@intstandard_id='" + drpStandard.SelectedValue.Trim() + "',@intSession_id='" + drpSession.SelectedValue.Trim() + "',@intFloor='" + drpFloor.SelectedValue.Trim() + "',@intRoomNo='" + drpRoom.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                fGridafill();
                MessageBox("Record Exist Already");
                return;
            }
            else
            {
                strQry = "exec [usp_DivisionMaster] @command='insert',@vchDivisionName='" + txtName.Text.Trim() + "',@intstandard_id='" + drpStandard.SelectedValue.Trim() + "',@intSession_id='" + drpSession.SelectedValue.Trim() + "',@intFloor='" + drpFloor.SelectedValue.Trim() + "',@intRoomNo='" + drpRoom.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGridafill();
                    MessageBox("Record Saved Successfully!");
                    clear();
                }               
            }            
        }
        else
        {
            //strQry = "exec [usp_DivisionMaster] @command='checkExists',@vchDivisionName='" + Convert.ToString(txtName.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + drpStandard.SelectedValue.Trim() + "'";
            strQry = "exec [usp_DivisionMaster] @command='checkExists',@vchDivisionName='" + Convert.ToString(txtName.Text.Trim()) + "',@intstandard_id='" + drpStandard.SelectedValue.Trim() + "',@intSession_id='" + drpSession.SelectedValue.Trim() + "',@intFloor='" + drpFloor.SelectedValue.Trim() + "',@intRoomNo='" + drpRoom.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Exist Already");
                return;
            }
            else
            {
                strQry = "exec [usp_DivisionMaster] @command='update',@vchDivisionName='" + txtName.Text.Trim() + "',@intstandard_id='" + drpStandard.SelectedValue.Trim() + "',@intSession_id='" + drpSession.SelectedValue.Trim() + "',@intFloor='" + drpFloor.SelectedValue.Trim() + "',@intRoomNo='" + drpRoom.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDivision_id='" + Convert.ToString(Session["DivisionID"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGridafill();
                    MessageBox("Record Updated Successfully!");
                    clear();                   
                }               
            }            
        }
       
    }
    public void clear()
    {
        try
        {
            drpSession.ClearSelection();
            drpStandard.ClearSelection(); ;
            txtName.Text = "";
            drpFloor.ClearSelection(); ;
            drpRoom.ClearSelection(); ;
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
    protected void btnClear_Click(object sender, EventArgs e)
    {

    }
    protected void fGridafill()
    {
        strQry = "usp_DivisionMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtName.Text = "";
        }
    }
    protected void fSession()
    {
        strQry = "usp_DivisionMaster @command='session',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            drpSession.DataTextField = "vchSessionName";
            drpSession.DataValueField = "intSession_id";
            drpSession.DataSource = dsObj;
            drpSession.DataBind();            
            drpSession.Items.Insert(0, "---Select----");
        }
        else
        {           
            drpSession.DataSource = dsObj;
            drpSession.DataBind();
            drpSession.Items.Insert(0, "---Select----");
        }
    }
    protected void fStandard()
    {
        strQry = "usp_DivisionMaster @command='standard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            drpStandard.DataTextField = "vchStandard_name";
            drpStandard.DataValueField = "intstandard_id";
            drpStandard.DataSource = dsObj;
            drpStandard.DataBind();
            drpStandard.Items.Insert(0, "---Select----");
        }
        else
        {           
            drpStandard.DataSource = dsObj;
            drpStandard.DataBind();
            drpStandard.Items.Insert(0, "---Select----");
        }
    }

    protected void fFloor()
    {
        strQry = "usp_DivisionMaster @command='floor',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            drpFloor.DataTextField = "vchFloor_name";
            drpFloor.DataValueField = "intFloor_id";
            drpFloor.DataSource = dsObj;
            drpFloor.DataBind();
            drpFloor.Items.Insert(0, "---Select----");
        }
        else
        {           
            drpFloor.DataSource = dsObj;
            drpFloor.DataBind();
            drpFloor.Items.Insert(0, "---Select----");
        }
    }
    protected void fRoom(string strFloorID)
    {
        strQry = "usp_DivisionMaster @command='Room',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intFloor='" + strFloorID.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            drpRoom.DataTextField = "vchRoom_name";
            drpRoom.DataValueField = "intRoom_id";
            drpRoom.DataSource = dsObj;
            drpRoom.DataBind();
            drpRoom.Items.Insert(0, "---Select----");
        }
        else
        {           
            drpRoom.DataSource = dsObj;
            drpRoom.DataBind();
            drpRoom.Items.Insert(0, "---Select----");
        }
    }
    protected void drpFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        fRoom(drpFloor.SelectedValue.ToString());
    }
}
