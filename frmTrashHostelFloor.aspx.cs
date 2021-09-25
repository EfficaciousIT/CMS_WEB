using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class frmTrashHostelFloor : DBUtility
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
        strQry = "[usp_TrashHostel] @command='SelectFloor',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["ID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec [usp_TrashHostel] @command='EnableFloor',@HostelFloor_id='" + Convert.ToString(Session["ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@IntUpdate_by='" + Session["User_id"] + "',@UpdateIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                //MessageBox("Building Enable Successfully!");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Floor Enable Successfully!');window.location ='frmTrashHostelFloor.aspx';", true);
                fGrid();
            }
        }
        catch
        {

        }
    }
}