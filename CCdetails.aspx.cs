using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
public partial class CCdetails : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    DataSet dsObjgrade;
    string exam = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserType_id"] != null && Session["User_id"] != null || Session["Student_id"] != null)
        {
            if (!IsPostBack)
            {
                FillSTD();
                fillgrid();

            }
        }


    }
    public void fillgrid()
    {
        strQry = "exec usp_CharCertificate @command='SelectAll',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        grdTrans.DataSource = dsObj;
        grdTrans.DataBind();

    }
    public void FillSTD()
    {
        try
        {
            try
            {
                strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
                //sBindDropDownList(drpSTD, strQry, "vchStandard_name", "intstandard_id");
                // FillDIV();
                //FillExaminationType();
            }
            catch (Exception)
            {

                throw;
            }

        }
        catch
        {

        }
    }
    public void FillDIV()
    {
        try
        {
            //ddlGender.ClearSelection();
            strQry = "exec usp_getAttendance @type='FillDiv',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDIV, strQry, "vchDivisionName", "intDivision_id");
            FillStudent();
            //FillExam();
            //FillSubject();
        }
        catch
        {

        }
    }

    public void FillStudent()
    {
        try
        {

            strQry = "exec usp_FillDropDown @type='GetStudents',@StdId='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            //strQry = "exec usp_FillDropDown @type='GetStudents',@intDiv_id='" + Convert.ToString(ddlDIV.SelectedValue) + "',@vchGender='" + Convert.ToString(ddlGender.SelectedItem.Text) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");

            if (ddlStudent.Items.Count > 1)
                ddlStudent.Items.Add(new ListItem("All", "-1"));
            else
                ddlStudent.DataSource = null;
        }
        catch
        {

        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();

    }
    protected void ddlDIV_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStudent();

    }
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDetailTransGrid();

    }
    public void FillDetailTransGrid()
    {
        try
        {
            DataTable dt = new DataTable();

            strQry = "";


            //strQry = "exec usp_SchoolFeeCollectionNew_SP @type='FillTransGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstudent_id='" + detailddlStudentName.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            //dsObj = sGetDataset(strQry);


            strQry = "exec usp_CharCertificate @command='Selectstudent',@intstudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdTrans.DataSource = dsObj;
                grdTrans.DataBind();
            }
            else
            {
                MessageBox("Record not found");
                grdTrans.DataSource = dsObj;
                grdTrans.DataBind();
           
            
            }


        }
        catch
        { }
    }
    protected void grdTrans_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //ViewState["intID"] = this.grdTrans.DataKeys[e.RowIndex].Values[3].ToString();
            ViewState["StudentID"] = this.grdTrans.DataKeys[e.RowIndex].Values[1].ToString();
            strQry = "";

            // strQry = "exec [usp_SchoolFeeCollectionNew_SP] @type='delete',@intID='" + Convert.ToString(ViewState["intID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            strQry = "exec usp_CharCertificate @command='Deletestudent',@intstudent_id='" + Convert.ToString(ViewState["StudentID"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            if (sExecuteQuery(strQry) != -1)
            {
                // FillTransGrid();
                fillgrid();
                MessageBox("Transaction Deleted Successfully!");

            }
        }
        catch (Exception)
        {

        }
    }

    protected void grdTrans_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {

            //Session["SRNO"] = this.grdTrans.DataKeys[e.NewEditIndex].Values[0].ToString();
            Session["StudentID"] = this.grdTrans.DataKeys[e.NewEditIndex].Values[0].ToString();

            DataSet dsObj = new DataSet();
            strQry = "";
            strQry = "exec usp_CharCertificate @command='Selectstudent',@intstudent_id='" + Convert.ToString(Session["StudentID"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["rptStudentdetail"] = dsObj;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("rptcharcertificate.aspx", true);
            }
        }
        catch (Exception)
        {

        }
    }

    protected void gvTrans_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //getting username from particular row
            string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "vchStudent_name"));
            //identifying the control in gridview
            LinkButton lnkbtnresult = (LinkButton)e.Row.FindControl("lnkEdit");
            //raising javascript confirmationbox whenver user clicks on link button
            lnkbtnresult.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + username + "')");
        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {

            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting userid of particular row

            // string userid = grdTrans.DataKeys[gvrow.RowIndex].Value.ToString();
            //string SRNo = Convert.ToString(grdTrans.DataKeys[gvrow.RowIndex].Values[0]);
            string STudentID = Convert.ToString(grdTrans.DataKeys[gvrow.RowIndex].Values[0]);
            Session["intStudent_id"] = STudentID;

            DataSet dsObj = new DataSet();
            strQry = "";
            strQry = "exec usp_CharCertificate @command='Selectstudent',@intstudent_id='" + STudentID + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["rptStudentdetail"] = dsObj;
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("CCEdit.aspx", true);
            }
        }
        catch (Exception)
        {

        }

    }
    protected void show_Click(object sender, EventArgs e)
    {

    }


}