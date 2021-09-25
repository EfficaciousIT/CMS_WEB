using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class frmEnglishReader  : DBUtility
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
            string query1 = "Execute dbo.usp_Area @command='SelectEnglishReaderStan',@intSchool_id='" + Session["School_id"] + "' ";
            bool st = sBindDropDownList(Standard_id, query1, "vchStandard_name", "intstandard_id");

            string query2 = "Execute dbo.usp_Area @command='SelectEnglishReaderStan',@intSchool_id='" + Session["School_id"] + "' ";
            bool st1 = sBindDropDownList(Stdrop1, query2, "vchStandard_name", "intstandard_id");

            string Disquery = "Execute dbo.usp_Area @command='GridEnglishReader',@intSchool_id='" + Session["School_id"] + "'";
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
                string intStandard_id = Convert.ToString(Standard_id.SelectedValue);
               // string intDivision_id = Convert.ToString(Division_id.SelectedValue);
              
                string instip = GetSystemIP();

                strQry = "exec [usp_Area] @command='checkEnglishReaderExists',@VchName='" + Name + "',@intStandard_id='" + intStandard_id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);

                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    filldata();
                    MessageBox("Record Exist Already");
                    return;
                }
                else
                {
                    itrque1 = "Execute dbo.usp_Area @command='InsertEnglishReader',@VchName='" + Name + "',@intStandard_id='" + intStandard_id + "',@fltinsertIP='" + instip + "',@intSchool_id='" + Session["School_id"] + "',@intInsert_By='" + Session["user_id"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";

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
                    string intStandard_id = Convert.ToString(Standard_id.SelectedValue);
                    //string intDivision_id = Convert.ToString(Division_id.SelectedValue);
                    string Updateip = GetSystemIP();
                    strQry = "exec [usp_Area] @command='checkEnglishReaderExists',@VchName='" + Name + "',@intStandard_id='" + intStandard_id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    dsObj = sGetDataset(strQry);

                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        filldata();
                        MessageBox("Record Exist Already");
                        return;
                    }
                    else
                    {
                        itrque1 = "Execute dbo.usp_Area @command='UpdateEnglishReader',@VchName='" + Name + "',@intStandard_id='" + intStandard_id + "',@IntUpdate_IP='" + Updateip + "',@intSchool_id='" + Session["School_id"] + "',@intUpdate_id='" + Session["user_id"] + "',@id='" + id + "',@intAcademic_id='" + Session["AcademicID"] + "'";

                        int result1 = sExecuteQuery(itrque1);

                        if (result1 != -1)
                        {
                            string display = "English Reader Update Successfully!";
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
                            MessageBox("ooopppsss!Subject Update Failed");
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
        Standard_id.ClearSelection();
        //Division_id.ClearSelection();
    }
    protected void Clear()
    {
        text1.Text = "";
        Standard_id.ClearSelection();
        //Division_id.ClearSelection();
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
            int id = Convert.ToInt32(SubReport.DataKeys[e.RowIndex].Value);
            Session["Deleteid"] = SubReport.DataKeys[e.RowIndex].Value;
            string DeleteIP = GetSystemIP();
            string strQry11 = "Execute dbo.usp_Area @command='DeleteEnglishReader',@id='" + id + "',@intschool_id='" + Session["School_id"] + "',@fltDeleteIP='" + DeleteIP + "',@intDeleted_by='" + Session["user_id"] + "'";
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
            int id = Convert.ToInt32(SubReport.DataKeys[e.NewEditIndex].Value);
            Session["id"] = SubReport.DataKeys[e.NewEditIndex].Value;
            DataSet dsObj = new DataSet();

            string strQry = "exec dbo.usp_Area @command='EditEnglishReader',@id='" + id + "',@intschool_id='" + Session["School_id"] + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                Button1.Text = "Update";
                hid1.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["id"]);
                Standard_id.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                //division();
                //Division_id.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]); 
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
            string Disquery = "Execute dbo.usp_Area @command='GridEnglishReader',@intSchool_id='" + Session["School_id"] + "'";
            int grvDetail1 = sBindGrid(SubReport, Disquery);
            SubReport.AllowPaging = true;

        }
        else
        {
            string Disquery2 = "Execute dbo.usp_Area @command='GridEnglishReaderStan',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + query2 + "'";
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
    //    string query3 = "Execute dbo.usp_Area @command='SelectEnglishReaderDiv',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + Convert.ToString(Standard_id.SelectedValue) + "'";
    //    bool st2 = sBindDropDownList(Division_id, query3, "vchDivisionName", "intDivision_id");
    //}
}