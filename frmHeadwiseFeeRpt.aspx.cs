using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmHeadwiseFeeRpt : DBUtility
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
                    fillAcademicYear();
                    FillSTD();                   
                    FillGrid();
                    geturl();
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
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int sum = 0;
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
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
    protected void drpAcademiYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSTD.ClearSelection();
    }
    public void FillGrid()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_FeesAssignSTD @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
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
            strQry = "exec usp_FeesAssignSTD @type='fillAcademicYear'";
            sBindDropDownList(drpAcademiYear, strQry, "AcademicYear", "intAcademic_id");        
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
        }
        catch
        {

        }
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        if (drpAcademiYear.SelectedValue=="0")
        {
            drpAcademiYear.Focus();
            MessageBox("Please Select Academic Year!");
            return;
        }
        if (ddlSTD.SelectedValue == "0")
        {
            ddlSTD.Focus();
            MessageBox("Please Select Standard!");
            return;
        }
        DataSet dsObj = new DataSet();
        strQry = "";
        strQry = "exec usp_FeesAssignSTD @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        Session["rptFeeHeadWise"] = dsObj;
        Response.Redirect("frmFeeHeadWise.aspx", true);
    }
}