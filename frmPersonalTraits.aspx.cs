using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmPersonalTraits : DBUtility
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Button1.Text = "Submit";
                checksession();
                geturl();
                filldata();
            }
        }
        catch
        {

        }
    }
    protected void filldata()
    {
        try
        {
            string query1 = "Execute dbo.usp_Area @command='SelectPersonalTraitsStan',@intSchool_id='" + Session["School_id"] + "' ";
            bool st = sBindDropDownList(ddlStandard, query1, "vchStandard_name", "intstandard_id");

            string query2 = "Execute dbo.usp_Area @command='SelectPersonalTraitsStan',@intSchool_id='" + Session["School_id"] + "' ";
            bool st1 = sBindDropDownList(Stdrop1, query2, "vchStandard_name", "intstandard_id");

            string Disquery = "Execute dbo.usp_Area @command='GridPersonalTraits',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            int grvDetail1 = sBindGrid(SubReport, Disquery);
        }
        catch
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string strQry = "";
            DataSet dsObj = new DataSet();
            DataSet dsObjNew = new DataSet();
            string itrque1 = "";
            if (Button1.Text == "Submit")
            {
                string Name = Convert.ToString(text1.Text);
                string intStandard_id = Convert.ToString(ddlStandard.SelectedValue);
                //string intDivision_id = Convert.ToString(ddlDivison.SelectedValue);

                string instip = GetSystemIP();

                strQry = "exec [usp_Area] @command='checkPersonalTraitsExists',@VchName='" + Name + "',@intStandard_id='" + intStandard_id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                dsObj = sGetDataset(strQry);

                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    filldata();
                    MessageBox("Record Exist Already");
                    return;
                }
                else
                {
                    itrque1 = "Execute dbo.usp_Area @command='InsertPersonalTraits',@VchName='" + Name + "',@intStandard_id='" + intStandard_id + "',@fltinsertIP='" + instip + "',@intSchool_id='" + Session["School_id"] + "',@intInsert_By='" + Session["user_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";

                    int result1 = sExecuteQuery(itrque1);
                    if (result1 != -1)
                    {
                        string display = "Subject assignment Successfully!";
                        MessageBox(display);
                        Clear();
                        filldata();
                    }
                    else
                    {
                        MessageBox("ooopppsss!Subject Assignment Failed");
                    }
                }
            }
            else if (Button1.Text == "Update")
            {
                try
                {
                    string id = hid1.Value;
                    string Name = Convert.ToString(text1.Text).Trim();
                    string intStandard_id = Convert.ToString(ddlStandard.SelectedValue);
                   // string intDivision_id = Convert.ToString(ddlDivison.SelectedValue);


                    string Updateip = GetSystemIP();
                    strQry = "exec [usp_Area] @command='checkPersonalTraitsExists',@VchName='" + Name + "',@intStandard_id='" + intStandard_id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                    dsObj = sGetDataset(strQry);

                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        filldata();
                        MessageBox("Record Exist Already");
                        return;
                    }
                    else
                    {
                        itrque1 = "Execute dbo.usp_Area @command='UpdatePersonalTraits',@VchName='" + Name + "',@intStandard_id='" + intStandard_id + "',@IntUpdate_IP='" + Updateip + "',@intSchool_id='" + Session["School_id"] + "',@intUpdate_id='" + Session["user_id"] + "',@id='" + id + "',@intAcademic_id='" + Session["AcademicID"] + "'";

                        int result1 = sExecuteQuery(itrque1);

                        if (result1 != -1)
                        {
                            string display = "Personal Traits Name Update Successfully!";
                            MessageBox(display);
                            Clear();
                            filldata();
                            TabContainer1.ActiveTabIndex = 1;
                            Button1.Visible = true;
                            Button2.Visible = false;
                            Button1.Text = "Submit";
                        }
                        else
                        {
                            MessageBox("ooopppsss!Personal Traits Update Failed");
                        }
                    }
                }
                catch
                {

                }
            }
        }
        catch
        {

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button1.Text = "Submit";
        text1.Text = "";
        ddlStandard.ClearSelection();
        //ddlDivison.ClearSelection();
    }
    protected void Clear()
    {
        text1.Text = "";
        ddlStandard.ClearSelection();
        //ddlDivison.ClearSelection();
    }
    protected void SubReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        SubReport.PageIndex = e.NewPageIndex;
        filldata();
    }
    protected void SubReport_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
           
            Session["Deleteid"] = SubReport.DataKeys[e.RowIndex].Value;
            string DeleteIP = GetSystemIP();
            string strQry11 = "Execute dbo.usp_Area @command='DeletePersonalTraits',@id='" + Session["Deleteid"] + "',@intschool_id='" + Session["School_id"] + "',@fltDeleteIP='" + DeleteIP + "',@intDeleted_by='" + Session["user_id"] + "'";
            if (sExecuteQuery(strQry11) != -1)
            {
                MessageBox("Record Deleted Successfully");
                filldata();
            }
        }
        catch
        {

        }
    }
    protected void SubReport_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            
            Session["Id"] = Convert.ToString(SubReport.DataKeys[e.NewEditIndex].Value);
           
            DataSet dsObj = new DataSet();

            string strQry = "exec dbo.usp_Area @command='EditPersonalTraits',@id='" + Convert.ToString(Session["Id"]) + "',@intschool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Button1.Text = "Update";
                hid1.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["id"]);
                ddlStandard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                //division();
                //ddlDivison.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                text1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]).Trim();
            }
            TabContainer1.ActiveTabIndex = 1;
            Button1.Visible = true;
            Button2.Visible = false;

        }
        catch (Exception)
        {
            throw;
        }
    }

    protected void Stdrop1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query2 = Stdrop1.SelectedItem.Value;
        if (query2 == "A")
        {
            string Disquery = "Execute dbo.usp_Area @command='GridPersonalTraits',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            int grvDetail1 = sBindGrid(SubReport, Disquery);
            SubReport.AllowPaging = true;

        }
        else
        {
            string Disquery2 = "Execute dbo.usp_Area @command='GridPersonalTraitsStan',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + query2 + "',@intAcademic_id='" + Session["AcademicID"] + "'";
            int grvDetail2 = sBindGrid(SubReport, Disquery2);
            SubReport.AllowPaging = false;
        }
    }

    protected void Standard_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        //division();
    }
    //public void division()
    //{
    //    string query3 = "Execute dbo.usp_Area @command='SelectPersonalTraitsDiv',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + Convert.ToString(ddlStandard.SelectedValue) + "'";
    //    bool st2 = sBindDropDownList(ddlDivison, query3, "vchDivisionName", "intDivision_id");
    //}

}