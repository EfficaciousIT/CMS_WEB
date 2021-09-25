using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;

public partial class frmCardAssignment : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillStandard();
            //FillDivision();
            //FillStudent();
            FillCardNo();
            fGrid();
        }
    }

    protected void fGrid()
    {
        strQry = "usp_Lib_Card_Assignment @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            ddlCardNum.ClearSelection();
        }
    }


    public void FillStandard()
    {
        try
        {
            strQry = "exec usp_Lib_Card_Assignment @command='GetStandard',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlStandard, strQry, "StandardName", "intstandard_id");

            //if (ddlStudent.Items.Count > 1)
            //    ddlStudent.Items.Add(new ListItem("All", "-1"));
            //else
            //    ddlStudent.DataSource = null;
        }
        catch
        {

        }
    }
    public void FillDivision()
    {
        try
        {
            strQry = "exec usp_Lib_Card_Assignment @command='GetDivision',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlDivisionId, strQry, "DivisionName", "intDivision_id");

            //if (ddlStudent.Items.Count > 1)
            //    ddlStudent.Items.Add(new ListItem("All", "-1"));
            //else
            //    ddlStudent.DataSource = null;
        }
        catch
        {

        }
    }
    public void FillStudent()
    {
        try
        {
            strQry = "exec usp_Lib_Card_Assignment @command='GetStudents',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");

            //if (ddlStudent.Items.Count > 1)
            //    ddlStudent.Items.Add(new ListItem("All", "-1"));
            //else
            //    ddlStudent.DataSource = null;
        }
        catch
        {

        }
    }
    public void FillCardNo()
    {
        try
        {
            strQry = "exec usp_Lib_Card_Assignment @command='GetCardNumber',@intSchool_id='" + Session["School_id"] + "'";
            sBindDropDownList(ddlCardNum, strQry, "CardName", "intLib_card_id");
        }
        catch
        {

        }
    }
    public void clear()
    {
        try
        {
            ddlCardNum.ClearSelection();
           
            ddlStudent.ClearSelection();
           
            ddlStandard.ClearSelection();
            ddlDivisionId.ClearSelection();
            btnSubmit.Text = "Submit";
            
        }
        catch
        {
        }
    }




        protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
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


     

        protected void grvDetail_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Session["CardAssignmentID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
                strQry = "";
                strQry = "exec [usp_Lib_Card_Assignment] @command='delete',@intCard_assignment_id='" + Convert.ToString(Session["CardAssignmentID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Deleted Successfully!");
                }
            }
            catch
            {

            }
        }
        protected void grvDetail_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["CardAssignmentID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
                strQry = "";
                strQry = "exec usp_Lib_Card_Assignment @command='edit',@intCard_assignment_id='" + Convert.ToString(Session["CardAssignmentID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {

                    ddlStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                    FillDivision();
                    

                    ddlDivisionId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                    FillStudent();
                    ddlStudent.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
                    ddlCardNum.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intLib_card_id"]);
                   
                    TabContainer1.ActiveTabIndex = 1;
                    btnSubmit.Text = "Update";

                }
            }
            catch
            {

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlStandard.SelectedValue == "0")
            {
                MessageBox("Please Select Standard Name!");
                ddlStandard.Focus();
                return;
            }
            if (ddlDivisionId.SelectedValue == "0")
            {
                MessageBox("Please Select Division Name!");
                ddlDivisionId.Focus();
                return;
            }
            if (ddlStudent.SelectedValue == "0")
            {
                MessageBox("Please Select Student Name!");
                ddlStudent.Focus();
                return;
            }
            if (ddlCardNum.SelectedValue == "0")
            {
                MessageBox("Please Select Card Number!");
                ddlCardNum.Focus();
                return;
            }
            strQry = "";

            if (btnSubmit.Text == "Submit")
            {
                strQry = "usp_Lib_Card_Assignment @command='checkExist',@intCard_assignment_id='" + Convert.ToString(Session["CardAssignmentID"]) + "',@intLib_card_id='" + Convert.ToString(ddlCardNum.SelectedValue.Trim()) + "',@intStudent_id='" + ddlStudent.SelectedValue.Trim() + "',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Already Exists");
                    return;
                }
                else
                {
                    strQry = "exec [usp_Lib_Card_Assignment] @command='insert',@intLib_card_id='" + Convert.ToString(ddlCardNum.SelectedValue.Trim()) + "',@intStudent_id='" + ddlStudent.SelectedValue.Trim() + "',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        fGrid();
                        MessageBox("Card Assigned  Successfully");
                        clear();
                    }
                }
            }
            else
            {
                //strQry = "usp_Lib_Card_Assignment @command='checkExist',@intCard_assignment_id='" + Convert.ToString(Session["CardAssignmentID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                strQry = "usp_Lib_Card_Assignment @command='checkUpdateExist',@intCard_assignment_id='" + Convert.ToString(Session["CardAssignmentID"]) + "',@intLib_card_id='" + Convert.ToString(ddlCardNum.SelectedValue.Trim()) + "',@intStudent_id='" + ddlStudent.SelectedValue.Trim() + "',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    MessageBox("Record Already Exists");
                    return;
                }
                else
                {

                    strQry = "exec [usp_Lib_Card_Assignment] @command='update',@intCard_assignment_id='" + Convert.ToString(Session["CardAssignmentID"]) + "',@intStudent_id='" + ddlStudent.SelectedValue.Trim() + "',@intstandard_id='" + ddlStandard.SelectedValue.Trim() + "',@intDivision_id='" + ddlDivisionId.SelectedValue.Trim() + "',@intLib_card_id='" + Convert.ToString(ddlCardNum.SelectedValue.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                    if (sExecuteQuery(strQry) != -1)
                    {
                        fGrid();
                        clear();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Record Updated Successfully');window.location ='frmCardAssignment.aspx';", true);
                       // MessageBox("Record Updated Successfully!");
                        TabContainer1.ActiveTabIndex = 0;
                        btnSubmit.Text = "Submit";
                    }
                }
            }
        }

      

        protected void ddlStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDivision();
        }
        protected void ddlDivisionId_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStudent();
        }
}