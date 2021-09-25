using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class frmBookPublicationMaster : DBUtility
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
        strQry = "usp_tblBookPublication_master @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
            txtPublication_name.Text = "";
           
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtPublication_name.Text == "")
        {
            MessageBox("Please Insert publication Name!");
            txtPublication_name.Focus();
            return;
        }
        //if (txtAddress.Text == "")
        //{
        //    MessageBox("Please Insert Insert Address !");
        //    txtAddress.Focus();
        //    return;
        //}
        //if (txtEmail.Text == "")
        //{
        //    MessageBox("Please Insert Email id!");
        //    txtPublication_name.Focus();
        //    return;
        //}
        //if (txtContact.Text == "")
        //{
        //    MessageBox("Please Insert Contact number!");
        //    txtPublication_name.Focus();
        //    return;
        //}
        if (btnSubmit.Text == "Submit")
        {
            strQry = "usp_tblBookPublication_master @command='checkExist',@vchBook_publication_name='" + Convert.ToString(txtPublication_name.Text.Trim()) + "',@vchAddress='" + Convert.ToString(txtAddress.Text.Trim()) + "',@vchEmail='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchContact='" + Convert.ToString(txtContact.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                MessageBox("Type Publication Already Exists");
                return;
            }
            else
            {
                strQry = "exec [usp_tblBookPublication_master] @command='insert',@vchBook_publication_name='" + Convert.ToString(txtPublication_name.Text.Trim()) + "',@vchAddress='" + Convert.ToString(txtAddress.Text.Trim()) + "',@vchEmail='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchContact='" + Convert.ToString(txtContact.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intInsertedBy='" + Session["User_id"] + "',@insertIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    fGrid();
                    MessageBox("Publication Inserted Successfully!");
                }
            }
        }
        else
        {
            //strQry = "usp_tblBookPublication_master @command='checkExist',@vchBook_publication_name='" + Convert.ToString(txtPublication_name.Text.Trim()) + "',@vchAddress='" + Convert.ToString(txtAddress.Text.Trim()) + "',@vchEmail='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchContact='" + Convert.ToString(txtContact.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            //dsObj = sGetDataset(strQry);
            //if (dsObj.Tables[0].Rows.Count > 0)
            //{
            //    MessageBox(" Record Already Exists");
            //    return;
            //}
            //else
            //{
                strQry = "exec [usp_tblBookPublication_master] @command='update',@intBook_publication_id='" + Convert.ToString(Session["BookPublicationID"]) + "',@vchBook_publication_name='" + Convert.ToString(txtPublication_name.Text.Trim()) + "',@vchAddress='" + Convert.ToString(txtAddress.Text.Trim()) + "',@vchEmail='" + Convert.ToString(txtEmail.Text.Trim()) + "',@vchContact='" + Convert.ToString(txtContact.Text.Trim()) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intUpdatedBy='" + Session["User_id"] + "',@UpdatedIP='" + GetSystemIP() + "'";
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
        txtPublication_name.Text = "";
        txtAddress.Text = "";
        txtEmail.Text = "";
        txtContact.Text = "";
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
            Session["BookPublicationID"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
            strQry = "";
            strQry = "exec usp_tblBookPublication_master @command='edit',@intBook_publication_id='" + Convert.ToString(Session["BookPublicationID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtPublication_name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchBook_publication_name"]);
                txtAddress.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                txtEmail.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmail"]);
                txtContact.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchContact"]);
                TabContainer1.ActiveTabIndex = 1;
                btnSubmit.Text = "Update";
            }
        }
        catch
        {

        }
    }
    protected void grvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["BookPublicationID"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_tblBookPublication_master] @command='delete',@intBook_publication_id='" + Convert.ToString(Session["BookPublicationID"]) + "',@intDeletedBy='" + Session["User_Id"] + "',@deletedIP='" + GetSystemIP() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                fGrid();
                MessageBox("Publication has been Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
}