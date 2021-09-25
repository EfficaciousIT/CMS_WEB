using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmStudentFeeChart : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    Label6.Visible = false;
                    Label7.Visible = false;
                    Label10.Visible = false;
                    drpAcademiYear.Visible = false;
                    ddlSTD.Visible = false;
                    drpCat.Visible = false;

                    FillTransGrid();
                    fillDurationType();
                    fillAcademicYear();
                    FillSTD();
                    FillCategory();
                    geturl();
                    feegridDel();
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

    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpAcademiYear, strQry, "AcademicYear", "intAcademic_id");
            drpAcademiYear.SelectedValue = "1";
            drpAcademiYear.Enabled = false;
            ddlSTD.ClearSelection();
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
            strQry = "exec usp_FeesAssignSTD @type='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
            ddlSTD.SelectedValue = Convert.ToString(Session["Standard_id"]);
            ddlSTD.Enabled = false;
        }
        catch
        {

        }
    }
    public void FillCategory()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillCategory',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(drpCat, strQry, "vchCategory", "intCat_Id");
        }
        catch
        {

        }
    }

    protected void drpCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int sum = 0;
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intCat_Id='" + Convert.ToString(drpCat.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();


            for (int i = 0; i < grvDetail.Rows.Count; i++)
            {
                String test = grvDetail.Rows[i].Cells[3].Text;
                if (test == "Monthly")
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text) * 12);
                }
                else if (test == "Quarterly")
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text) * 4);
                }
                else if (test == "Half Yearly")
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text) * 2);
                }
                else
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text));
                }

                //sum += int.Parse(grvDetail.Rows[i].Cells[4].Text);

            }
            lblTotal.Text = sum.ToString();
        }
        catch
        {

        }
    }
    protected void ddlDurationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillHead();
        lblMonths.Visible = true;
        ddlMonths.Visible = true;
        fillMonths();
    }
    public void fillHead()
    {
        try
        {
            strQry = "";
            int sum = 0;
            strQry = "exec usp_SchoolFeeCollection @type='FillHeadAmt1',@feeType='" + Convert.ToString(ddlDurationType.SelectedValue) + "',@intCat_Id='" + 1 + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            gvHead.DataSource = dsObj;
            gvHead.DataBind();
            for (int i = 0; i < gvHead.Rows.Count; i++)
            {
                sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
            }
            txtEnterAmt.Text = sum.ToString();

        }
        catch
        {

        }
    }
    public void fillMonths()
    {
        try
        {   
            string qry = "exec usp_FeesAssignSTD @type='GetMonths',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlMonths, qry, "MonthName", "MonthNo");
        }
        catch
        {
        }
    }
    public void fillDurationType()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTD @type='GetDuration',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlDurationType, qry, "vchDuration", "intDuration_Id");
        }
        catch
        {
        }
    }
    public void FillTransGrid()
    {
        try
        {
            int sum = 0;
            strQry = "";
            strQry = "exec usp_SchoolFeeCollection @type='FillTransGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intRegistration_id='" + 1 + "'";
            dsObj = sGetDataset(strQry);
            grdTrans.DataSource = dsObj;
            grdTrans.DataBind();

            for (int i = 0; i < grdTrans.Rows.Count; i++)
            {
                sum += int.Parse(grdTrans.Rows[i].Cells[4].Text);
            }
            lblFee.Text = sum.ToString();

        }
        catch
        {

        }
    }
    public void feegridDel()
    {
        try
        {
            int sum = 0;
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + 1 + "',@intSTD_Id='" + 1 + "',@intCat_Id='" + 1 + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();


            for (int i = 0; i < grvDetail.Rows.Count; i++)
            {
                String test = grvDetail.Rows[i].Cells[3].Text;
                if (test == "Monthly")
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text) * 12);
                }
                else if (test == "Quarterly")
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text) * 4);
                }
                else if (test == "Half Yearly")
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text) * 2);
                }
                else
                {
                    sum += (int.Parse(grvDetail.Rows[i].Cells[2].Text));
                }

                //sum += int.Parse(grvDetail.Rows[i].Cells[4].Text);

            }
            lblTotal.Text = sum.ToString();
        }
        catch
        {

        }
    }
}