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

public partial class frmTrashGenderMaster :DBUtility
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
        try
        {
            strQry = "";
            strQry = "exec [usp_TrashSchool]  @command='SelectGender',@intSchool_id='" + Session["School_Id"] + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["ID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec [usp_TrashSchool] @command='EnableGender',@intGender_Id='" + Convert.ToString(Session["ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@intUpdate_id='" + Session["User_id"] + "',@updateIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Enable Successfully!');window.location ='frmTrashGenderMaster.aspx';", true);
                fGrid();
            }
        }
        catch
        {

        }
    }
}