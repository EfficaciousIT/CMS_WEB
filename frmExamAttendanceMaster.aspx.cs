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

public partial class frmExamAttendanceMaster : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    int k = 0;
    string strID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillGrid();
            ViewState["Edit"] = "No";
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(ViewState["Edit"]) == "Yes")
        {
            strQry = "usp_Area  @command='CheckUpdateExist',@Name='" + txtName.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exist!");
                return;
            }
            else
            {
                strQry = "usp_Area  @command='UpdateExamAttendance',@Name='" + txtName.Text.Trim() + "',@IntUpdate_IP='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                k = sExecuteQuery(strQry);
                if (k > 0)
                {
                    fillGrid();
                    MessageBox("Record Updated Successfully");
                    txtName.Text = "";

                    btnUpdate.Text = "Sumbit";
                    ViewState["Edit"] = "No";
                }
            }
        }
        else
        {
            //strQry = "usp_Area  @command='CheckExamAttendanceExist',@Attendance='" + txtAttendance.Text.Trim() + "',@TeacherRemark='" + txtRemark.Text.Trim() + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Record Already Exist!");
            //    return;
            //}
            //else
            //{
            strQry = "usp_Area  @command='InsertExamAttendance',@Name='" + txtName.Text.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertby='" + Convert.ToString(Session["User_id"]) + "',@fltinsertIP='" + GetSystemIP() + "'";
            k = sExecuteQuery(strQry);
            if (k > 0)
            {
                fillGrid();
                MessageBox("Record Addedd Successfully");
                txtName.Text = "";

                btnUpdate.Text = "Sumbit";
                ViewState["Edit"] = "No";
            }

            //}
        }


    }
    protected void fillGrid()
    {
        strQry = "usp_Area  @command='getExamAttendance',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            TabContainer1.ActiveTabIndex = 0;
            grdExam.DataSource = dsObj;
            grdExam.DataBind();
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

        }
    }
    protected void grdExam_RowEditing(object sender, GridViewEditEventArgs e)
    {
        strID = Convert.ToString(grdExam.DataKeys[e.NewEditIndex].Value);

        ViewState["strID"] = strID;

        strQry = "usp_Area  @command='EditExamAttendance',@id='" + Convert.ToString(strID.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            ViewState["Edit"] = "Yes";
            TabContainer1.ActiveTabIndex = 1;
            txtName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Name"]);
            btnUpdate.Text = "Update";
        }
    }
    protected void grdExam_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strID = Convert.ToString(grdExam.DataKeys[e.RowIndex].Value);

        strQry = "usp_Area  @command='DeleteAreaandRemark',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@id='" + Convert.ToString(strID.Trim()) + "',@intDeleteBy='" + Session["User_id"] + "',@deleteIP='" + GetSystemIP() + "'";
        k = sExecuteQuery(strQry);
        if (k > 0)
        {
            fillGrid();
            MessageBox("Record Deleted Successfully");
        }
    }

}
