using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmTrashTeacherMaster : DBUtility
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
            strQry = "exec [usp_TrashSchool]  @command='SelectTeacher',@intSchool_id='" + Session["School_Id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
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
            strQry = "exec [usp_TrashSchool] @command='EnableTeacher',@intTeacher_id='" + Convert.ToString(Session["ID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Enable Successfully!');window.location ='frmtrashteachermaster.aspx';", true);
                fGrid();
            }
        }
        catch
        {

        }
    }
}