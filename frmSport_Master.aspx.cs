using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class frmSport_Master : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fGrid();
        }
    }
    protected void fGrid()
    {
        strQry = "usp_tblSport_master @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtSportName.Text = "";
			txtSportTeacherName.Text="";
			txtEmail.Text = "";
			txtMobileNo.Text = "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtSportName.Text == "")
        {
            MessageBox("Please Insert Sport Name");
            txtSportName.Focus();
            return;
        }
        if (txtSportTeacherName.Text == "")
        {
            MessageBox("Please Insert Sport Teacher Name");
            txtSportTeacherName.Focus();
            return;
        }
        //if (txtEmail.Text == "")
        //{
        //    MessageBox("Please Insert Email Id");
        //    txtEmail.Focus();
        //    return;
        //}
        if (txtMobileNo.Text == "")
        {
            MessageBox("Please Insert Mobile Number");
            txtMobileNo.Focus();
            return;
        }
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblSport_master @command='checkExist',@vchSport_name='" + Convert.ToString(txtSportName.Text.Trim()) + "',@vchSport_teacher_name='" + Convert.ToString(txtSportTeacherName.Text.Trim()) + "',@vchSport_teacher_email='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchSport_teacher_mobile='" + Convert.ToString(txtMobileNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Record is Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblSport_master] @command='insert',@vchSport_name='" + Convert.ToString(txtSportName.Text.Trim()) + "',@vchSport_teacher_name='" + Convert.ToString(txtSportTeacherName.Text.Trim()) + "',@vchSport_teacher_email='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchSport_teacher_mobile='" + Convert.ToString(txtMobileNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Inserted Successfully!");
                }
            }
        }
        else
        {
            //strQry = "usp_tblSport_master @command='checkUdateExist',@vchSport_name='" + Convert.ToString(txtSportName.Text.Trim()) + "',@vchSport_teacher_name='" + Convert.ToString(txtSportTeacherName.Text.Trim()) + "',@vchSport_teacher_email='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchSport_teacher_mobile='" + Convert.ToString(txtMobileNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox("Record is Already Exists");
            //    return;
            //}
            //else
            //{
                strQry = "exec [usp_tblSport_master] @command='update',@intSport_id='" + Convert.ToString(Session["SportID"]) + "',@vchSport_name='" + Convert.ToString(txtSportName.Text.Trim()) + "',@vchSport_teacher_name='" + Convert.ToString(txtSportTeacherName.Text.Trim()) + "',@vchSport_teacher_email='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchSport_teacher_mobile='" + Convert.ToString(txtMobileNo.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Record Updated Successfully!");
                    TabContainer1.ActiveTabIndex = 0;
                    btnSubmit.Text = "Submit";
                }
           // }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtSportName.Text = "";
        txtSportTeacherName.Text = "";
        txtEmail.Text = "";
        txtMobileNo.Text = "";
        btnSubmit.Text = "Submit";
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





    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
             try
        {
            Session["SportID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblSport_master @command='edit',@intSport_id='" + Convert.ToString(Session["SportID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtSportName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSport_name"]);
                txtSportTeacherName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSport_teacher_name"]);
                txtEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSport_teacher_email"]);
                txtMobileNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSport_teacher_mobile"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
        protected void  grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
{
    
        try
        {
            Session["SportID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblSport_master] @command='delete',@intSport_id='" + Convert.ToString(Session["SportID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Sport Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
}