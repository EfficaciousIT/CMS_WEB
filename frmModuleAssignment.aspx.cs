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
public partial class frmModuleAssignment : DBUtility
{
     string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
            fillAcademicYear();
            FillRole();
            fGrid();
        }
    }
    protected void fGrid()
    {
        strQry = "usp_ModuleAssignment @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
          
        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_PromotionDemotion @command='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlAcademiYear, strQry, "AcademicYear", "intAcademic_id");
            // sBindDropDownList(ddlToAcademiYear, strQry, "AcademicYear", "intAcademic_id");
            ddlAcademiYear.SelectedValue = "1";
        }
        catch
        {

        }
    }
    public void FillRole()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillRole',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
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
            lblStd.Visible = true;
            ddlSTD.Visible = true;
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");

            if (ddlSTD.Items.Count > 1)
                ddlSTD.Items.Add(new ListItem("All", "-1"));
            else
                ddlSTD.DataSource = null;
        }
        catch
        {

        }
    }
    public void FillDepartment()
    {
        try
        {
            lblDept.Visible = true;
            ddlDepartment.Visible = true;
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillDepartment',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlDepartment, strQry, "vchDepartment_name", "intDepartment");
        }
        catch
        {

        }
    }
    public void FillDesignation()
    {
        try
        {
            lblDesi.Visible = true;
            ddlDesignation.Visible = true;
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillDesignation',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlDesignation, strQry, "vchDesignation", "intDesignation_Id");
        }
        catch
        {

        }
    }
    public void FillTeacher()
    {
        try
        {
            lblTchr.Visible = true;
            ddlTeacher.Visible = true;
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillTeacher',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "'";
            sBindDropDownList(ddlTeacher, strQry, "vchfirst_name", "intTeacher_id");

            if (ddlTeacher.Items.Count > 1)
                ddlTeacher.Items.Add(new ListItem("All", "-1"));
            else
                ddlTeacher.DataSource = null;
        }
        catch
        {

        }
    }
    public void FillStaff()
    {
        try
        {
            lblTchr.Visible = true;
            ddlTeacher.Visible = true;
            strQry = "";
            strQry = "exec usp_ModuleAssignment  @command='FillStaff',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "'";
            sBindDropDownList(ddlTeacher, strQry, "vchfirst_name", "intStaff_id");

            if (ddlTeacher.Items.Count > 1)
                ddlTeacher.Items.Add(new ListItem("All", "-1"));
            else
                ddlTeacher.DataSource = null;
        }
        catch
        {

        }
    }

    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.SelectedValue == "1")
        {
            lblDept.Visible = false;
            ddlDepartment.Visible = false;
            ddlDepartment.ClearSelection();
            lblDesi.Visible = false;
            ddlDesignation.Visible = false;
            ddlDesignation.ClearSelection();
            lblTchr.Visible = false;
            ddlTeacher.Visible = false;
            ddlTeacher.ClearSelection();
            FillSTD();
        }
        else if (ddlRole.SelectedValue == "2")
        {
            lblDept.Visible = false;
            ddlDepartment.Visible = false;
            ddlDepartment.ClearSelection();
            lblDesi.Visible = false;
            ddlDesignation.Visible = false;
            ddlDesignation.ClearSelection();
            lblTchr.Visible = false;
            ddlTeacher.Visible = false;
            ddlTeacher.ClearSelection();
            FillSTD();
        }
        else if (ddlRole.SelectedValue == "3")
        {
            lblStd.Visible = false;
            ddlSTD.Visible = false;
            ddlSTD.ClearSelection();
            FillDepartment();
        }
        else if (ddlRole.SelectedValue == "4")
        {
            lblStd.Visible = false;
            ddlSTD.Visible = false;
            ddlSTD.ClearSelection();
            FillDepartment();
        }
        else if (ddlRole.SelectedValue == "5")
        {
            lblStd.Visible = false;
            ddlSTD.Visible = false;
            ddlSTD.ClearSelection();
            FillDepartment();
        }
       
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDesignation();
    }
    protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.SelectedValue == "3")
        {
            FillTeacher();
        }
        if (ddlRole.SelectedValue == "4")
        {
            FillStaff();
        }
      
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (btnSubmit.Text == "Assign")
            {
                if (ddlRole.SelectedValue == "1")
                {
                    foreach (GridViewRow gvrow in grvDetail.Rows)
                    {
                        CheckBox chkRow = (gvrow.Cells[1].FindControl("chkCtrl") as CheckBox);

                        if (ddlSTD.SelectedValue == "-1")
                        {
                            if (((DataSet)Session["AllStand"] != null))
                            {

                                foreach (DataRow dr in ((DataSet)Session["AllStand"]).Tables[0].Rows)
                                {
                                    if (chkRow.Checked)
                                    {
                                        string AcaYr = Convert.ToString(ddlAcademiYear.SelectedValue);
                                        string Role = Convert.ToString(ddlRole.SelectedValue);
                                        string std = Convert.ToString(dr["intstandard_id"]);
                                        string Modul = this.grvDetail.DataKeys[gvrow.RowIndex].Values[0].ToString();

                                        string status = "Y";

                                        strQry = "exec [usp_ModuleAssignment] @command='InsertStudentModuleAssignment',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intRole_Id='" + Role + "',@intstandard_id='" + std + "',@intModule_Id='" + Modul + "',@ModuleStatus='" + status + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                                        sExecuteQuery(strQry);
                                    }
                                }
                            }
                        }
                        else
                        {

                            if (chkRow.Checked)
                            {
                                string AcaYr = Convert.ToString(ddlAcademiYear.SelectedValue);
                                string Role = Convert.ToString(ddlRole.SelectedValue);
                                string std = Convert.ToString(ddlSTD.SelectedValue);                              
                                string Modul = this.grvDetail.DataKeys[gvrow.RowIndex].Values[0].ToString();

                                string status = "Y";

                                strQry = "exec [usp_ModuleAssignment] @command='InsertStudentModuleAssignment',@intAcademic_id='" + AcaYr + "',@intRole_Id='" + Role + "',@intstandard_id='" + std + "',@intModule_Id='" + Modul + "',@ModuleStatus='" + status + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                                sExecuteQuery(strQry);
                            }
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Module Assign Successfully');window.location ='frmModuleAssignment.aspx';", true);

                }
                if (ddlRole.SelectedValue == "2")
                {
                    foreach (GridViewRow gvrow in grvDetail.Rows)
                    {
                        CheckBox chkRow = (gvrow.Cells[1].FindControl("chkCtrl") as CheckBox);

                        if (ddlSTD.SelectedValue == "-1")
                        {
                            if (((DataSet)Session["AllStand"] != null))
                            {

                                foreach (DataRow dr in ((DataSet)Session["AllStand"]).Tables[0].Rows)
                                {
                                    if (chkRow.Checked)
                                    {
                                        string AcaYr = Convert.ToString(ddlAcademiYear.SelectedValue);
                                        string Role = Convert.ToString(ddlRole.SelectedValue);
                                        string std = Convert.ToString(dr["intstandard_id"]);
                                        string Modul = this.grvDetail.DataKeys[gvrow.RowIndex].Values[0].ToString();

                                        string status = "Y";

                                        strQry = "exec [usp_ModuleAssignment] @command='InsertStudentModuleAssignment',@intAcademic_id='" + AcaYr + "',@intRole_Id='" + Role + "',@intstandard_id='" + std + "',@intModule_Id='" + Modul + "',@ModuleStatus='" + status + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                                        sExecuteQuery(strQry);
                                    }
                                }
                            }
                        }
                        else
                        {

                            if (chkRow.Checked)
                            {
                                string AcaYr = Convert.ToString(ddlAcademiYear.SelectedValue);
                                string Role = Convert.ToString(ddlRole.SelectedValue);
                                string std = Convert.ToString(ddlSTD.SelectedValue);
                                string Modul = this.grvDetail.DataKeys[gvrow.RowIndex].Values[0].ToString();

                                string status = "Y";

                                strQry = "exec [usp_ModuleAssignment] @command='InsertStudentModuleAssignment',@intAcademic_id='" + AcaYr + "',@intRole_Id='" + Role + "',@intstandard_id='" + std + "',@intModule_Id='" + Modul + "',@ModuleStatus='" + status + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                                sExecuteQuery(strQry);
                            }
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Module Assign Successfully');window.location ='frmModuleAssignment.aspx';", true);

                }
               else if (ddlRole.SelectedValue == "3")
                {
                    foreach (GridViewRow gvrow in grvDetail.Rows)
                    {
                        CheckBox chkRow = (gvrow.Cells[1].FindControl("chkCtrl") as CheckBox);

                        if (ddlTeacher.SelectedValue == "-1")
                        {
                            if (((DataSet)Session["AllTeacher"] != null))
                            {

                                foreach (DataRow dr in ((DataSet)Session["AllTeacher"]).Tables[0].Rows)
                                {
                                    if (chkRow.Checked)
                                    {
                                        string AcaYr = Convert.ToString(ddlAcademiYear.SelectedValue);
                                        string Role = Convert.ToString(ddlRole.SelectedValue);
                                        string Dept = Convert.ToString(ddlDepartment.SelectedValue);
                                        string Desi = Convert.ToString(ddlDesignation.SelectedValue);
                                        string Tchr = Convert.ToString(dr["intTeacher_id"]);
                                        string Modul = this.grvDetail.DataKeys[gvrow.RowIndex].Values[0].ToString();

                                        string status = "Y";

                                        strQry = "exec [usp_ModuleAssignment] @command='InsertModuleAssignment',@intAcademic_id='" + AcaYr + "',@intRole_Id='" + Role + "',@intDepartment='" + Dept + "',@intDesignation_Id='" + Desi + "',@intUser_id='" + Tchr + "',@intModule_Id='" + Modul + "',@ModuleStatus='" + status + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                                        sExecuteQuery(strQry);
                                    }
                                }
                            }
                        }
                        else
                        {

                            if (chkRow.Checked)
                            {
                                string AcaYr = Convert.ToString(ddlAcademiYear.SelectedValue);
                                string Role = Convert.ToString(ddlRole.SelectedValue);
                                string Dept = Convert.ToString(ddlDepartment.SelectedValue);
                                string Desi = Convert.ToString(ddlDesignation.SelectedValue);
                                string Tchr = Convert.ToString(ddlTeacher.SelectedValue);
                                string Modul = this.grvDetail.DataKeys[gvrow.RowIndex].Values[0].ToString();

                                string status = "Y";

                                strQry = "exec [usp_ModuleAssignment] @command='InsertModuleAssignment',@intAcademic_id='" + AcaYr + "',@intRole_Id='" + Role + "',@intDepartment='" + Dept + "',@intDesignation_Id='" + Desi + "',@intUser_id='" + Tchr + "',@intModule_Id='" + Modul + "',@ModuleStatus='" + status + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                                sExecuteQuery(strQry);
                            }
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Module Assign Successfully');window.location ='frmModuleAssignment.aspx';", true);

                }
                else if (ddlRole.SelectedValue == "4")
                {
                    foreach (GridViewRow gvrow in grvDetail.Rows)
                    {
                        CheckBox chkRow = (gvrow.Cells[1].FindControl("chkCtrl") as CheckBox);

                        if (ddlTeacher.SelectedValue == "-1")
                        {
                            if (((DataSet)Session["AllStaff"] != null))
                            {

                                foreach (DataRow dr in ((DataSet)Session["AllStaff"]).Tables[0].Rows)
                                {
                                    if (chkRow.Checked)
                                    {
                                        string AcaYr = Convert.ToString(ddlAcademiYear.SelectedValue);
                                        string Role = Convert.ToString(ddlRole.SelectedValue);
                                        string Dept = Convert.ToString(ddlDepartment.SelectedValue);
                                        string Desi = Convert.ToString(ddlDesignation.SelectedValue);
                                        string stff = Convert.ToString(dr["intStaff_id"]);
                                        string Modul = this.grvDetail.DataKeys[gvrow.RowIndex].Values[0].ToString();

                                        string status = "Y";

                                        strQry = "exec [usp_ModuleAssignment] @command='InsertModuleAssignment',@intAcademic_id='" + AcaYr + "',@intRole_Id='" + Role + "',@intDepartment='" + Dept + "',@intDesignation_Id='" + Desi + "',@intUser_id='" + stff + "',@intModule_Id='" + Modul + "',@ModuleStatus='" + status + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                                        sExecuteQuery(strQry);
                                    }
                                }
                            }
                        }
                        else
                        {

                            if (chkRow.Checked)
                            {
                                string AcaYr = Convert.ToString(ddlAcademiYear.SelectedValue);
                                string Role = Convert.ToString(ddlRole.SelectedValue);
                                string Dept = Convert.ToString(ddlDepartment.SelectedValue);
                                string Desi = Convert.ToString(ddlDesignation.SelectedValue);
                                string stff = Convert.ToString(ddlTeacher.SelectedValue);
                                string Modul = this.grvDetail.DataKeys[gvrow.RowIndex].Values[0].ToString();

                                string status = "Y";

                               string strQryt = "exec [usp_ModuleAssignment] @command='InsertModuleAssignment',@intAcademic_id='" + AcaYr + "',@intRole_Id='" + Role + "',@intDepartment='" + Dept + "',@intDesignation_Id='" + Desi + "',@intUser_id='" + stff + "',@intModule_Id='" + Modul + "',@ModuleStatus='" + status + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                               sExecuteQuery(strQryt);
                            }
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Module Assign Successfully');window.location ='frmModuleAssignment.aspx';", true);

                }
            }
        }
        catch
        {
        }
    }
    protected void ddlTeacher_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRole.SelectedValue == "3")
        {
            strQry = "exec usp_ModuleAssignment  @command='FillTeacher',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            Session["AllTeacher"] = dsObj;
        }
        if (ddlRole.SelectedValue == "4")
        {
            strQry = "exec usp_ModuleAssignment  @command='FillStaff',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intRole_Id='" + Convert.ToString(ddlRole.SelectedValue) + "',@intDepartment='" + Convert.ToString(ddlDepartment.SelectedValue) + "',@intDesignation_Id='" + Convert.ToString(ddlDesignation.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            Session["AllStaff"] = dsObj;
        }
       
        //fAssignGrid();
    }
    protected void fAssignGrid()
    {
        strQry = "usp_ModuleAssignment @command='fAssignGrid',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUser_id='" + Convert.ToString(ddlTeacher.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();

        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        int index = row.RowIndex;
        CheckBox cb1 = (CheckBox)grvDetail.Rows[index].FindControl("chkCtrl");
 
        if (cb1.Checked == true)
        {           
            row.BackColor = System.Drawing.Color.Cornsilk;
        }
        else if (cb1.Checked == false)
        {         
            row.BackColor = System.Drawing.Color.Transparent;
        }
    }
    protected void Status_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = (sender as DropDownList).NamingContainer as GridViewRow;

        string dataKey = this.grvDetail.DataKeys[row.RowIndex].Value.ToString();

        CheckBox chk = (CheckBox)row.FindControl("chkCtrl");

        chk.Checked = true;

        row.BackColor = System.Drawing.Color.Cornsilk;

    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "exec usp_ModuleAssignment  @command='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        dsObj = sGetDataset(strQry);
        Session["AllStand"] = dsObj;
    }
}