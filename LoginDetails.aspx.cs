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

public partial class LoginDetails : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strFromDate = string.Empty;
    string strToDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillRole();
        }
    }
    public void FillRole()
    {
        try
        {
            strQry = "exec [usp_LoginDetails] @command='getRole',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlRole, strQry, "vchRole", "intRole_Id");
        }
        catch
        {

        }
    }
    public void FillSTD()
    {
        try
        {
            strQry = "exec [usp_LoginDetails] @command='getStd',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
        }
        catch
        {

        }
    }
    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRole.SelectedValue == "1" || ddlRole.SelectedValue == "2")
            {
                lblStd.Visible = true;
                ddlSTD.Visible = true;
                FillSTD();
            }
            if (ddlRole.SelectedValue == "3")
            {
                lblStd.Visible = false;
                ddlSTD.Visible = false;
                strQry = "usp_LoginDetails @command='loginTeacher',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grd.DataSource = dsObj;
                    grd.DataBind();
                }
                else
                {
                    grd.DataSource = dsObj;
                    grd.DataBind();

                }
            }
            if (ddlRole.SelectedValue == "4")
            {
                lblStd.Visible = false;
                ddlSTD.Visible = false;
                strQry = "usp_LoginDetails @command='loginStaff',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grd.DataSource = dsObj;
                    grd.DataBind();
                }
                else
                {
                    grd.DataSource = dsObj;
                    grd.DataBind();

                }
            }
            if (ddlRole.SelectedValue == "5")
            {
                lblStd.Visible = false;
                ddlSTD.Visible = false;
                strQry = "usp_LoginDetails @command='loginAdmin',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    grd.DataSource = dsObj;
                    grd.DataBind();
                }
                else
                {
                    grd.DataSource = dsObj;
                    grd.DataBind();

                }
            }
        }
        catch
        {

        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.SelectedValue == "1")
        {
            strQry = "usp_LoginDetails @command='loginStudent',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grd.DataSource = dsObj;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = dsObj;
                grd.DataBind();
            }
        }
        if (ddlRole.SelectedValue == "2")
        {
            strQry = "usp_LoginDetails @command='loginParent',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + ddlSTD.SelectedValue + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grd.DataSource = dsObj;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = dsObj;
                grd.DataBind();
            }
        }
       
    }
}