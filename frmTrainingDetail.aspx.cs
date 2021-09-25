using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmTrainingDetail : DBUtility
{
    DataSet dsObj, dsParent, dsStudent, dsTeacher;
    string strQry;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType_id"] != null && Session["User_Id"] != null)
        {

            if (!IsPostBack)
            {
                ViewState["TrainID"] = Request.QueryString["TrainingId"];
                LoadData();
                FillParentGrid();
                FillStudentGrid();
                FillTeacherGrid();
                FillMainGrid();
            }
        }
        else
        {
           // Response.Redirect("~\\index.aspx", false);
            Response.Redirect("~\\frmIndex.aspx", false);
        }
    }
    public void LoadData()
    {
        try
        {
            
           
            strQry = "";
            strQry = "exec [usp_TrainingMst] @type='GetSelectedData',@intTraining_id='" + ViewState["TrainID"] + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                lblTitle.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["varTitle"]);
                lblName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["varName"]);
                lblDesc.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["varDesc"]);
                lblFrmDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["FrmDt"]);
                lblToDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["ToDt"]);
                lblFrmTime.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["STime"]).ToString("HH:MM t.\\M");
                lblToTime.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["ETime"]).ToString("HH:MM t.\\M");
                lnkDoc.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["varDoc_Path"]);
            }
        }
        catch (Exception)
        {
            
        }
       
    }
    public void FillTeacherGrid()
    {
        try
        {
            
            dsTeacher = new DataSet();
            strQry = "";
            strQry = "exec usp_TrainingDetail @type='FillStaff',@intTraining_id='" + ViewState["TrainID"] + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsTeacher = sGetDataset(strQry);

            if (dsTeacher.Tables[0].Rows.Count > 0)
            {

                grvTeacher.DataSource = dsTeacher;
                grvTeacher.DataBind();
                
                if (Convert.ToString(Session["UserType_id"]) == "5")
                {
                    grvTeacher.Columns[0].Visible = false;
                }
                else
                {
                    grvTeacher.Columns[0].Visible = false;
                }
            }
        }
        catch
        {

        }
    }
    public void FillStudentGrid()
    {
        try
        {
            dsStudent = new DataSet();
            strQry = "";
            strQry = "exec usp_TrainingDetail @type='FillAll',@intTraining_id='" + ViewState["TrainID"] + "',@intUserType='1',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsStudent = sGetDataset(strQry);

            if (dsStudent.Tables[0].Rows.Count > 0)
            {
                grvStud.DataSource = dsStudent;
                grvStud.DataBind();

                if (Convert.ToString(Session["UserType_id"]) == "5")
                {
                    grvStud.Columns[0].Visible = false;
                }
                else
                {
                    grvStud.Columns[0].Visible = false;
                }
            }
        }
        catch
        {

        }
    }
    public void FillParentGrid()
    {
        try
        {
            dsParent = new DataSet();
            strQry = "";
            strQry = "exec usp_TrainingDetail @type='FillAll',@intTraining_id='" + ViewState["TrainID"] + "',@intUserType='2',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsParent = sGetDataset(strQry);

            if (dsParent.Tables[0].Rows.Count > 0)
            {
                grvParent.DataSource = dsParent;
                grvParent.DataBind();

                if (Convert.ToString(Session["UserType_id"]) == "5")
                {
                    grvParent.Columns[0].Visible = false;
                }
                else
                {
                    grvParent.Columns[0].Visible = false;
                }
            }
        }
        catch
        {

        }
    }
    public void FillMainGrid()
    {
        try
        {
            dsObj = new DataSet();
            strQry = "";
            strQry = "exec usp_TrainingDetail @type='FillAll',@intTraining_id='" + ViewState["TrainID"] + "',@intSchool_Id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);

            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvAll.DataSource = dsObj;
                grvAll.DataBind();

                if (Convert.ToString(Session["UserType_id"]) == "5")
                {
                    grvAll.Columns[0].Visible = false;
                }
                else
                {
                    grvAll.Columns[0].Visible = false;
                }
            }
        }
        catch
        {

        }
    }
    protected void grvStud_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvStud.PageIndex = e.NewPageIndex;
        grvStud.DataBind();
        FillStudentGrid();
    }
    protected void grvTeacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvTeacher.PageIndex = e.NewPageIndex;
        grvTeacher.DataBind();
        FillTeacherGrid();
    }
    protected void grvParent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvParent.PageIndex = e.NewPageIndex;
        grvParent.DataBind();
        FillParentGrid();
    }
    protected void grvAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvAll.PageIndex = e.NewPageIndex;
        grvAll.DataBind();
        FillMainGrid();
    }
    protected void grvStud_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(grvStud.DataKeys[e.RowIndex]["id"]);

        }
        catch
        {
            
        }
    }
    protected void lnkDoc_Click(object sender, EventArgs e)
    {
        try
        {
            if (lnkDoc.Text != "")
            {
                lnkDoc.Attributes.Add("onclick", "window.open('frmViewDoc.aspx?Path=Documents/Training&DocName=" + Convert.ToString(lnkDoc.Text) + "','_blank','toolbar=0,location=0,menubar=0,resizable=0,height=400,width=800,top=80,left=75');return false");
            }
        }
        catch 
        {
            
        }
    }
}