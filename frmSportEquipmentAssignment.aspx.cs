using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class frmSportEquipmentAssignment : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtAssignDate.Text = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy")).Replace("-", "/");
            GetStandard();
            GetEquipment();
            SportCardID();
            fGrid();
        }
    }


    protected void fGrid()
    {
        strQry = "[usp_tblSportEquipmentAssign] @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            clear();
        }
    }

    protected void GetStandard()
    {
        try
        {
            string str1 = "[usp_tblSportEquipmentAssign] @command='GetStandard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlStandard, str1, "vchStandard_name", "intstandard_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }

    protected void GetDivision()
    {
        string str1 = "[usp_tblSportEquipmentAssign] @command='GetDivision',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlDivision, str1, "vchDivisionName", "intDivision_id");

    }

    protected void GetStudent()
    {
        string str1 = "[usp_tblSportEquipmentAssign] @command='GetStudent',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivision.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

        sBindDropDownList(ddlStudentName, str1, "Student_name", "intStudent_id");

    }
    protected void GetEditStudent()
    {
        string str1 = "[usp_tblSportEquipmentAssign] @command='GetEditStudent',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivision.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlStudentName, str1, "Student_name", "intStudent_id");

    }
    
    protected void GetEquipment()
    {
        try
        {
            string str1 = "[usp_tblSportEquipmentAssign] @command='GetEquipment',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlEquipName, str1, "vchEquipment_name", "intEquipment_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }


    protected void SportCardID()
    {
        string str1 = "[usp_tblSportEquipmentAssign] @command='SportCardID',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlSportCardNo, str1, "vchSport_card_no", "intSport_card_id");

    }
     protected void getSportCard()
    {
        string str1 = "[usp_tblSportEquipmentAssign] @command='getSportCard',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        sBindDropDownList(ddlSportCardNo, str1, "vchSport_card_no", "intSport_card_id");
        
    }


    protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDivision();
    }
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetStudent();
    }


    public void clear()
    {
        try
        {
            //txtAssignDate.Text = "";
            txtReturnDate.Text = "";
            ddlStandard.ClearSelection();
            ddlDivision.ClearSelection();
            ddlEquipName.ClearSelection();
            ddlStudentName.ClearSelection();
            ddlSportCardNo.ClearSelection();
            btnSubmit.Text = "Submit";
            ddlSportCardNo.Enabled = true;
            ddlStudentName.Enabled = true;
            ddlStandard.Enabled=true;
            ddlDivision.Enabled = true;


            ddlStandard.ToolTip = "";
            ddlDivision.ToolTip = "";
            ddlStudentName.ToolTip = "";
            ddlSportCardNo.ToolTip = "";


            ddlStandard.BorderColor = System.Drawing.Color.Empty;
            ddlDivision.BorderColor = System.Drawing.Color.Empty;
            ddlStudentName.BorderColor = System.Drawing.Color.Empty;
            ddlSportCardNo.BorderColor = System.Drawing.Color.Empty;

            txtStatus.ClearSelection();
          
        }
        catch
        {
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }

    //public void MessageBox(string msg)
    //{
    //    try
    //    {
    //        string script = "alert(\"" + msg + "\");";
    //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
    //    }
    //    catch (Exception)
    //    {
    //        // return msg;
    //    }
    //}

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlSportCardNo.SelectedValue == "0")
        {
            MessageBox("Please select Sport Card Number");
            ddlSportCardNo.Focus();
            return;
        }
        if (ddlStandard.SelectedValue == "0")
        {
            MessageBox("Please select standard");
            ddlStandard.Focus();
            return;
        }

        if(ddlDivision.SelectedValue=="0")

            if (ddlStudentName.SelectedValue == "---Select----")
        {
            MessageBox("please select Student Name");
            ddlStudentName.Focus();
            return;
        }

        if (ddlEquipName.SelectedValue == "0")
        {
            MessageBox("Please select Equipment Name");
            ddlEquipName.Focus();
            return;
        }
    
       
        if (txtAssignDate.Text == "")
        {
            MessageBox("Please Assign date");
            txtAssignDate.Focus();
            return;
        }
        if (txtReturnDate.Text == "")
        {
            MessageBox("please select  Return Date");
            txtReturnDate.Focus();
            return;
        }
        if (txtStatus.SelectedValue == "0")
        {
            MessageBox("please select  Status");
            txtStatus.Focus();
            return;
        }

        strQry = "";

        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblSportEquipmentAssign @command='checkExist',@intSport_card_id='" + ddlSportCardNo.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Equipment Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblSportEquipmentAssign] @command='insert',@intEquipment_id='" + ddlEquipName.SelectedValue.Trim() + "',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivision.SelectedValue.Trim() + "',@intStudent_id='" + ddlStudentName.SelectedValue.Trim() + "',@intSport_card_id='" + ddlSportCardNo.SelectedValue.Trim() + "',@dtAssign_date='" + Convert.ToDateTime(txtAssignDate.Text) + "',@dtReturn_date='" + Convert.ToDateTime(txtReturnDate.Text) + "',@vchStatus='" + Convert.ToString(txtStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Card Assigned Successfully!");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Card Assigned Successfully!');window.location ='frmSportEquipmentAssignment.aspx';", true);
                    clear();
                }
            }
        }
        else
        {
            //strQry = "usp_tblSportEquipmentAssign @command='checkUpdateExist',@intStudent_id='" + ddlStudentName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Record Already Exists");
            //    return;
            //}
            //else
            //{
                strQry = "exec [usp_tblSportEquipmentAssign] @command='update',@intEquipment_Assign_id='" + Convert.ToString(Session["EquipAssignID"]) + "',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivision.SelectedValue.Trim() + "',@intStudent_id='" + ddlStudentName.SelectedValue.Trim() + "',@intEquipment_id='" + ddlEquipName.SelectedValue.Trim() + "',@intSport_card_id='" + ddlSportCardNo.SelectedValue.Trim() + "',@dtAssign_date='" + Convert.ToDateTime(txtAssignDate.Text) + "',@dtReturn_date='" + Convert.ToDateTime(txtReturnDate.Text) + "',@vchStatus='" + Convert.ToString(txtStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                ////strQry = "exec [usp_tblSportEquipmentAssign] @command='update',@intEquipment_Assign_id='" + Convert.ToString(Session["EquipAssignID"]) + "',@intEquipment_id='" + ddlEquipName.SelectedValue.Trim() + "',@dtAssign_date='" + Convert.ToDateTime(txtAssignDate.Text) + "',@dtReturn_date='" + Convert.ToDateTime(txtReturnDate.Text) + "',@vchStatus='" + Convert.ToString(txtStatus.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();

                    clear();
                    MessageBox("Card Updated Successfully!");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Card Updated Successfully!');window.location ='frmSportEquipmentAssignment.aspx';", true);
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
    //        }
        }
    }
   
   
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["EquipAssignID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblSportEquipmentAssign] @command='delete',@intEquipment_Assign_id='" + Convert.ToString(Session["EquipAssignID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Card Deleted Successfully!');window.location ='frmSportEquipmentAssignment.aspx';", true);
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
            getSportCard();
            Session["EquipAssignID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblSportEquipmentAssign @command='edit',@intEquipment_Assign_id='" + Convert.ToString(Session["EquipAssignID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
               //// ddlStandard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
               //// GetDivision();
               // //ddlDivision.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
               //// GetStudent();
               // //ddlStudentName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);

               // ddlStandard.Enabled = false;
               // ddlDivision.Enabled = false;
               // ddlStudentName.Enabled = false;
               // ddlSportCardNo.Enabled = false;

                

               // ddlStandard.ToolTip = "You Can not update  Standard, Division ,Student Name And Sport Card Number";
               // ddlDivision.ToolTip = "You Can not update  Standard, Division ,Student Name And Sport Card Number";
               // ddlStudentName.ToolTip = "You Can not update  Standard, Division ,Student Name And Sport Card Number";
               // ddlSportCardNo.ToolTip = "You Can not update  Standard, Division ,Student Name And Sport Card Number";


               // ddlStandard.BorderColor = System.Drawing.Color.Silver;
               // ddlDivision.BorderColor = System.Drawing.Color.Silver;
               // ddlStudentName.BorderColor = System.Drawing.Color.Silver;
               // ddlSportCardNo.BorderColor = System.Drawing.Color.Silver;

               // ddlEquipName.Focus();

               //// getSportCard();


                ddlSportCardNo.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intSport_card_id"]);
                ddlSportCardNo.Enabled = false;
                ddlStandard.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                GetDivision();
                ddlDivision.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                GetEditStudent();
                ddlStudentName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);


                ddlEquipName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intEquipment_id"]);
                txtAssignDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtReturn_date"]);
                txtAssignDate.Text = Convert.ToDateTime(txtAssignDate.Text).ToString("dd/MM/yyyy").Replace("-", "/");
                txtReturnDate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtReturn_date"]);
                txtReturnDate.Text = Convert.ToDateTime(txtReturnDate.Text).ToString("dd/MM/yyyy").Replace("-", "/");
                txtStatus.Text=Convert.ToString(dsObj.Tables[0].Rows[0]["vchStatus"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
   
}