using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class frmStudentAllotment : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    string strStudent_id = string.Empty;
    string strMaxID = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    TabPanel1.Enabled = false;
                    fillAcademicYear();
                }
            }
            else
            {
                Response.Redirect("~\\Index.aspx", false);
            }
        }
        catch
        {

        }
    }
    public void FillGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_StudentAllotment @type='FillGrid',@intAcademic_id='" + Convert.ToString(ddlAcademiYear.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intCat_Id='" + Convert.ToString(ddlCast.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_StudentAllotment @type='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlAcademiYear, strQry, "AcademicYear", "intAcademic_id");

            ddlSTD.ClearSelection();
            ddlCast.ClearSelection();
        }
        catch
        {

        }
    }
    public void FillSTD()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_StudentAllotment @type='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
            ddlCast.ClearSelection();
        }
        catch
        {

        }
    }
    public void fillCategory()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_StudentAllotment @type='FillCategory',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlCast, strQry, "vchCategory", "intCat_Id");
        }
        catch
        {

        }
    }

    protected void ddlCast_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void ddlAcademiYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSTD();
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillCategory();
    }

    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //try
        //{
        //    //Clear();
        //    TabPanel1.Enabled = true;
        //    int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
        //    ViewState["Id"] = id;
        //    strQry = "exec usp_SchoolFeeCollection @type='FillEdit',@intTest_id='" + ViewState["Id"] + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        //    dsObj = sGetDataset(strQry);
        //    if (dsObj.Tables[0].Rows.Count > 0)
        //    {
        //        lblName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["CandiateName"]);
        //        lblStd.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
        //        fillCategory();
        //        ddlCategory.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intCat_Id"]);
        //        ddlCategory.Enabled = false;


        //        TabContainer1.ActiveTabIndex = 1;


        //    }
        //}
        //catch
        //{ }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSubmit.Text == "Assign")
            {
                foreach (GridViewRow gvrow in grvDetail.Rows)
                {
                    //CheckBox chk = (CheckBox)gvrow.FindControl("chkSelect");
                    //if (chk != null & chk.Checked)
                    //{
                    //    strStudent_id = this.grvDetail.DataKeys[row.RowIndex].Values[0].ToString();
                    //}
                    CheckBox chkRow = (gvrow.Cells[5].FindControl("chkCtrl") as CheckBox);
                    if (chkRow.Checked)
                    {
                        //strStudent_id = this.grvDetail.DataKeys[gvrow.RowIndex].Values[5].ToString();
                        string admission_id = this.grvDetail.DataKeys[gvrow.RowIndex].Values[0].ToString();
                        string Standard_id = this.grvDetail.DataKeys[gvrow.RowIndex].Values[1].ToString();
                        string FirstName = this.grvDetail.DataKeys[gvrow.RowIndex].Values[2].ToString();
                        string LastName = this.grvDetail.DataKeys[gvrow.RowIndex].Values[3].ToString();
                        string Academic_id = this.grvDetail.DataKeys[gvrow.RowIndex].Values[4].ToString();
                        string Cat_Id = this.grvDetail.DataKeys[gvrow.RowIndex].Values[5].ToString();

                        strQry = "exec [usp_StudentAllotment] @type='InsertIntoStudentMst',@intAddmission_id='" + admission_id + "',@intStandard_id='" + Standard_id + "',@vchStudentFirst_name='" + FirstName + "',@vchStudentLast_name='" + LastName + "',@intAcademic_id='" + Academic_id + "',@vchCast='" + Cat_Id + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                        sExecuteQuery(strQry);

                        string strQry1 = "exec [usp_StudentAllotment] @type='getNewID'";
                        dsObj = sGetDataset(strQry1);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            strMaxID = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                        }

                        string strQry2 = "exec [usp_StudentAllotment] @type='InsertIntoUserMst',@StudentID='" + strMaxID + "',@intStandard_id='" + Standard_id + "',@intAcademic_id='" + Academic_id + "',@vchUser_name='" + admission_id + "',@vchPassword='" + admission_id + "',@intAddmission_id='" + admission_id + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
                        sExecuteQuery(strQry2);
                    }
                }
                //int k = sExecuteQuery(strQry);
                //if (k > 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Activated Successfully');window.location ='frmStudentAllotment.aspx';", true);
                //}
                MessageBox("Records Activated Successfully");
            }
        }
        catch
        {
        }
    }
}
