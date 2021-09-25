using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HostelRoomAllotment : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                    FillSTD();
                    FillGrid();
                    checksession();
                }
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
            strQry = "exec usp_HostelRoomAllotment @type='Fillgrid',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(strQry);
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();

        }
        catch
        {

        }
    }
    public void clear()
    {
        try
        {
            drpBuilding.ClearSelection();
            drpWing.ClearSelection();
            drpRoom.ClearSelection();
            drpBed.ClearSelection();
            ddlFloor.SelectedValue = "0";
            btnSubmit.Text = "Submit";
        }
        catch
        {
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
    protected void grvDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvDetail.PageIndex = e.NewPageIndex;
            grvDetail.DataBind();
        }
        catch
        {

        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int id = (int)grvDetail.DataKeys[e.RowIndex].Value;
            strQry = "";
            strQry = "exec [usp_HostelRoomAllotment] @type='Delete',@HostelBed_Id='" + id + "',@intDeleted_By='" + Convert.ToString(Session["User_Id"]) + "',@vchDeleted_IP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                MessageBox("Record Deleted Successfully!");
                FillGrid();
            }
        }
        catch
        {

        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            strQry = "";
            int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
            ViewState["RoomAllotId"] = id;
            strQry = "exec [usp_HostelRoomAllotment] @type='Select',@HostelRoomAllot_Id='" + id + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpSatndard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                FillDIV();
                drpDivision.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                FillStudent();
                drpStudent.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
                FillBuilding();
                drpBuilding.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelBuilding_id"]);
                Fillwing();
                drpWing.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelWing_id"]);
                FillFloor();
                ddlFloor.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelFloor_id"]);
                FillRoom();
                drpRoom.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelRoom_id"]);
                FillBed();
                drpBed.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["HostelBed_Id"]);
                btnSubmit.Text = "Update";
                TBC.ActiveTabIndex = 1;
            }
        }
        catch
        {

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (drpSatndard.SelectedValue == "0")
        {
            MessageBox("Please Select Standard!");
            drpSatndard.Focus();
            return;
        }
        if (drpDivision.SelectedValue == "0")
        {
            MessageBox("Please Select Division!");
            drpDivision.Focus();
            return;
        }
        if (drpStudent.SelectedValue == "0")
        {
            MessageBox("Please Select Student!");
            drpStudent.Focus();
            return;
        }
        if (drpBuilding.SelectedValue == "0")
        {
            MessageBox("Please Select Building!");
            drpBuilding.Focus();
            return;
        }
        if (drpWing.SelectedValue == "0")
        {
            MessageBox("Please Select Wing!");
            drpWing.Focus();
            return;
        }
        if (ddlFloor.SelectedValue == "0")
        {
            MessageBox("Please Select Floor!");
            ddlFloor.Focus();
            return;
        }
        if (drpRoom.SelectedValue == "0")
        {
            MessageBox("Please Select Room!");
            drpRoom.Focus();
            return;
        }
        if (drpBed.SelectedValue == "0")
        {
            MessageBox("Please Select Bed!");
            drpBed.Focus();
            return;
        }
        try
        {
            geturl();
            strQry = "";
            if (btnSubmit.Text == "Submit")
            {
                strQry = "exec usp_HostelRoomAllotment @type='CheckSaveExist',@intstandard_id='" + Convert.ToString(drpSatndard.SelectedValue) + "',@intDivision_id='" + Convert.ToString(drpDivision.SelectedValue) + "',@intStudent_id='" + Convert.ToString(drpStudent.SelectedValue) + "',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@HostelRoom_id='" + Convert.ToString(drpRoom.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Bed Name Already Exist On Selected Room");
                    drpRoom.Focus();
                    return;
                }

                strQry = "exec usp_HostelRoomAllotment @type='Insert',@intstandard_id='" + Convert.ToString(drpSatndard.SelectedValue) + "',@intDivision_id='" + Convert.ToString(drpDivision.SelectedValue) + "',@intStudent_id='" + Convert.ToString(drpStudent.SelectedValue) + "',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@HostelRoom_id='" + Convert.ToString(drpRoom.SelectedValue).Trim() + "',@HostelBed_Id='" + Convert.ToString(drpBed.SelectedValue).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInserted_by='" + Convert.ToString(Session["User_Id"]) + "',@Inserted_IP='" + GetSystemIP() + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Saved Successfully");
                    FillGrid();
                    clear();
                }
            }
            else
            {
                strQry = "exec usp_HostelRoomAllotment @type='CheckUpdateExist',@intstandard_id='" + Convert.ToString(drpSatndard.SelectedValue) + "',@intDivision_id='" + Convert.ToString(drpDivision.SelectedValue) + "',@intStudent_id='" + Convert.ToString(drpStudent.SelectedValue) + "',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelBed_Id='" + ViewState["RoomAllotId"] + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@HostelRoom_id='" + Convert.ToString(drpRoom.SelectedValue) + "',@HostelBed_Id='" + Convert.ToString(drpBed.SelectedValue).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Entered Bed Name Already Exist On Selected Room");
                    drpRoom.Focus();
                    return;
                }

                strQry = "exec usp_HostelRoomAllotment @type='Update',@intstandard_id='" + Convert.ToString(drpSatndard.SelectedValue) + "',@intDivision_id='" + Convert.ToString(drpDivision.SelectedValue) + "',@intStudent_id='" + Convert.ToString(drpStudent.SelectedValue) + "',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@HostelRoom_id='" + Convert.ToString(drpRoom.SelectedValue) + "',@HostelBed_Id='" + Convert.ToString(ViewState["RoomAllotId"]) + "',@HostelBed_Id='" + Convert.ToString(drpBed.SelectedValue).Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@IntUpdated_By='" + Convert.ToString(Session["User_Id"]) + "',@Updated_IP='" + GetSystemIP() + "'";

                if (sExecuteQuery(strQry) != -1)
                {
                    MessageBox("Record Updated Successfully");
                    FillGrid();
                    clear();
                }
            }
            Response.Redirect("HostelRoomAllotment.aspx", false);
        }
        catch
        {

        }
    }
    protected void drpBuilding_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillwing();
    }
    protected void drpWing_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFloor();
    }
    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillRoom();
    }
    protected void drpRoom_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBed();
    }
    public void FillBuilding()
    {
        try
        {
            strQry = "exec usp_HostelRoomAllotment @type='FillBuilding',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpBuilding, strQry, "Building_name", "HostelBuilding_id");
        }
        catch
        {

        }
    }
    public void Fillwing()
    {
        try
        {
            strQry = "exec usp_HostelRoomAllotment @type='Fillwing',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpWing, strQry, "Building_wing", "HostelWing_id");
        }
        catch
        {

        }
    }
    public void FillFloor()
    {
        try
        {
            strQry = "exec usp_HostelRoomAllotment @type='FillFloor',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlFloor, strQry, "HostelFloor_name", "HostelFloor_id");
        }
        catch
        {

        }
    }
    public void FillRoom()
    {
        try
        {
            strQry = "exec usp_HostelRoomAllotment @type='FillRoom',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpRoom, strQry, "vchRoom_name", "HostelRoom_id");
        }
        catch
        {

        }
    }
    public void FillBed()
    {
        try
        {
            strQry = "exec usp_HostelRoomAllotment @type='FillBed',@HostelBuilding_id='" + Convert.ToString(drpBuilding.SelectedValue) + "',@HostelWing_id='" + Convert.ToString(drpWing.SelectedValue) + "',@HostelFloor_id='" + Convert.ToString(ddlFloor.SelectedValue) + "',@HostelRoom_id='" + Convert.ToString(drpRoom.SelectedValue) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(drpBed, strQry, "vchBed", "HostelBed_Id");
        }
        catch
        {

        }
    }
    protected void drpSatndard_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDIV();
    }
    protected void drpDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillStudent();
    }
    protected void drpStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillBuilding();
    }
    public void FillSTD()
    {
        try
        {
            //if (Convert.ToString(Session["UserType_Id"]) == "3")
            //{
                //strQry = "exec [usp_getAttendance] @type='FillStd',@TeacherId='" + Convert.ToString(Session["User_id"]) + "',@intSchool_id='" + Session["School_id"] + "'";
            strQry = "exec [usp_HostelRoomAllotment] @type='FillStd',@intSchool_id='" + Session["School_id"] + "'";
                sBindDropDownList(drpSatndard, strQry, "vchStandard_name", "intstandard_id");
              //  FillDIV();
            //}
            //else if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            //{
            //    strQry = "exec [usp_getAttendance] @type='FillAllStd',@intSchool_id='" + Session["School_id"] + "'";
            //    sBindDropDownList(drpSatndard, strQry, "vchStandard_name", "intstandard_id");
            //    FillDIV();
            //}

        }
        catch
        {

        }
    }
    public void FillDIV()
    {
        try
        {
            strQry = "exec usp_HostelRoomAllotment @type='FillDiv',@intstandard_id='" + Convert.ToString(drpSatndard.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(drpDivision, strQry, "vchDivisionName", "intDivision_id");
           // FillStudent();
        }
        catch
        {

        }
    }
    public void FillStudent()
    {
        try
        {
            strQry = "exec usp_HostelRoomAllotment @type='GetStudents',@intDivision_id='" + Convert.ToString(drpDivision.SelectedValue) + "',@intSchool_id='" + Session["School_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            sBindDropDownList(drpStudent, strQry, "Name", "intStudent_id");

            //if (drpStudent.Items.Count > 1)
            //    drpStudent.Items.Add(new ListItem("All", "-1"));
            //else
            //    drpStudent.DataSource = null;
        }
        catch
        {

        }
    }
}