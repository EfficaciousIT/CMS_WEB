using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmTrashHostelRoom : DBUtility
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
        strQry = "[usp_TrashHostel] @command='SelectRoom',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
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
            strQry = "exec [usp_TrashHostel] @command='EnableRoom',@HostelRoom_id='" + Convert.ToString(Session["ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@IntUpdated_By='" + Convert.ToString(Session["User_Id"]) + "',@Updated_IP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                //MessageBox("Building Enable Successfully!");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Room Enable Successfully!');window.location ='frmTrashHostelRoom.aspx';", true);
                fGrid();
            }
        }
        catch
        {

        }
    }
}