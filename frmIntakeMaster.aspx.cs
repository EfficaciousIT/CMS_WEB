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

public partial class frmIntakeMaster : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAcademicYear();
            FillStandard();
            FillCategory();
            fGrid();
        } 
    }
    protected void fGrid()
    {
        strQry = "usp_IntakeMaster @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            lblTotal.Visible = false;
            lblTotalSeat.Visible = false;
            drpAcademicYear.ClearSelection();
            drpStandard.ClearSelection();
            drpCategory.ClearSelection();
            txtSeat.Text = "";
            txtTotalSeat.Text = "";
        }
    }
    protected void FillAcademicYear()
    {
        strQry = "usp_IntakeMaster @command='selectAcademicYear'";
        bool stcardp = sBindDropDownList(drpAcademicYear, strQry, "AcademicYear", "intAcademic_id");
        sBindDropDownList(ddlAcademic, strQry, "AcademicYear", "intAcademic_id");
    }
    protected void FillStandard()
    {
        strQry = "usp_IntakeMaster @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
        sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intStandard_id");
    }
    protected void FillCategory()
    {
        strQry = "usp_IntakeMaster @command='selectCategory'";
        bool stcardp = sBindDropDownList(drpCategory, strQry, "vchCategory", "intCat_Id");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (drpAcademicYear.SelectedValue == "0")
        {
            MessageBox("Please Select Academic Year!");
            drpAcademicYear.Focus();
            return;
        }
        if (drpStandard.SelectedValue == "0")
        {
            MessageBox("Please Select Standard!");
            drpStandard.Focus();
            return;
        }
        if (drpCategory.SelectedValue == "0")
        {
            MessageBox("Please Select Category!");
            drpCategory.Focus();
            return;
        }
        if (txtSeat.Text == "")
        {
            MessageBox("Please Enter Seat!");
            txtSeat.Focus();
            return;
        }
        if (txtTotalSeat.Text == "")
        {
            MessageBox("Please Enter Total Seat!");
            txtTotalSeat.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_IntakeMaster @command='checkExist',@intAcademic_id='" + Convert.ToString(drpAcademicYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCategory.SelectedValue) + "',@vchSeat='" + Convert.ToString(txtSeat.Text.Trim()) + "',@vchTotalSeat='" + Convert.ToString(txtTotalSeat.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_IntakeMaster] @command='insert',@intAcademic_id='" + Convert.ToString(drpAcademicYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCategory.SelectedValue) + "',@vchSeat='" + Convert.ToString(txtSeat.Text.Trim()) + "',@vchTotalSeat='" + Convert.ToString(txtTotalSeat.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Inserted Successfully!");
                }
            }
        }
        else
        {
            strQry = "usp_IntakeMaster @command='checkExist',@intAcademic_id='" + Convert.ToString(drpAcademicYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCategory.SelectedValue) + "',@vchSeat='" + Convert.ToString(txtSeat.Text.Trim()) + "',@vchTotalSeat='" + Convert.ToString(txtTotalSeat.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_IntakeMaster] @command='update',@intAcademic_id='" + Convert.ToString(drpAcademicYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCategory.SelectedValue) + "',@vchSeat='" + Convert.ToString(txtSeat.Text.Trim()) + "',@vchTotalSeat='" + Convert.ToString(txtTotalSeat.Text.Trim()) + "',@intIntake_Id='" + Convert.ToString(Session["intIntake_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdate_id='" + Session["User_id"] + "',@IntUpdate_IP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
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
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intIntake_Id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_IntakeMaster @command='edit',@intIntake_Id='" + Convert.ToString(Session["intIntake_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpAcademicYear.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intAcademic_id"]);
                drpStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                drpCategory.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intCat_Id"]);
                txtSeat.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSeat"]);
                txtTotalSeat.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchTotalSeat"]);
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
            Session["intIntake_Id"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_IntakeMaster] @command='delete',@intIntake_Id='" + Convert.ToString(Session["intIntake_Id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Record Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
    protected void ddlAcademic_SelectedIndexChanged(object sender, EventArgs e)
    {
        fDDLGrid();
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        fDDLGrid();
    }
    protected void fDDLGrid()
    {
        strQry = "usp_IntakeMaster @command='fDDLGrid',@intAcademic_id='" + Convert.ToString(ddlAcademic.SelectedValue) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            lblTotal.Visible = true;
            lblTotalSeat.Visible = true;
             int sum = 0;
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();

            for (int i = 0; i < grvDetail.Rows.Count; i++)
            {
                sum += int.Parse(grvDetail.Rows[i].Cells[5].Text);
            }
            lblTotal.Text = sum.ToString();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
}