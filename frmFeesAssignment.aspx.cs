using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmFeesAssignment : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
                if (Session["UserType_Id"] != null && Session["User_Id"] != null)
                {
                    Label lblTile = new Label();
                    lblTile = (Label)Page.Master.FindControl("lblPageTitle");
                    lblTile.Visible = true;
                    lblTile.Text = "Academic Fee Detail";
                    if (!IsPostBack)
                    {
                    LBLTotal.Visible = false;
                    lbl.Visible = false;
                    btnSubmit.Visible = false;
                    FillSTD();
                    FillStudent();
                    FillGrid();
                    geturl();
                }
                
            }
                else
                {
                    Response.Redirect("~\\frmIndex.aspx", false);
                }
        }
        catch
        {

        }
    }
    public void FillStudent()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_tbl_StudentFeeAssignment @type='FillStudent',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@STD='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
            sBindDropDownList(ddlStudent, strQry, "Name", "intStudent_id");
        }
        catch 
        {
            
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            checksession();
            Boolean chk = false;
            for (int i = 0; i < grvDetail.Rows.Count; i++)
            {
                TextBox txtDis = (TextBox)grvDetail.Rows[i].FindControl("txtDiscount");
                Label lblFeeDet = (Label)grvDetail.Rows[i].FindControl("lblFeeDetId");
                Label lblFeeId = (Label)grvDetail.Rows[i].FindControl("lblId");

                strQry = "exec usp_tbl_StudentFeeAssignment @type='InsertUpdate',@intStudFee_Id='" + Convert.ToString(lblFeeId.Text) + "',@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@Discount='" + Convert.ToString(txtDis.Text) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInsertedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchInsertedIp='" + GetSystemIP() + "',@intFeeDet_Id='" + Convert.ToString(lblFeeDet.Text) + "',@intUpdatedBy='" + Convert.ToString(Session["User_Id"]) + "',@vchUpdatedIp='" + GetSystemIP() + "'";
                if (sExecuteQuery(strQry) != -1)
                {
                    chk = true;
                }
                else
                {
                    chk = false;
                    break;
                }
            }
            if (chk == true)
            {
                MessageBox("Fees Assigned Successfully!");
                ddlStudent.SelectedValue = "0";
                FillGrid();
               // ddlStudent.SelectedValue = "0";
            }
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
    public void FillGrid()
    {
        try
        {
            double Total = 0;
            strQry = "";
            if (Convert.ToString(Session["UserType_Id"]) == "5" || Convert.ToString(Session["UserType_Id"]) == "6")
            {

                TBC.Tabs[1].Visible = false;



                strQry = "exec usp_tbl_StudentFeeAssignment  @type='FillGrid',@intStudent_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";

                dsObj = sGetDataset(strQry);

                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    Total += Convert.ToDouble(dsObj.Tables[0].Rows[i]["AmtWidDiscount"]);
                    LBLTotal.Visible = true;
                    btnSubmit.Visible = true;
                    lbl.Visible = true;
                }
                LBLTotal.Text = Convert.ToString(Total);
             
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                grvDetail.Rows[0].Cells[3].Focus();

            }
            else if (Convert.ToString(Session["UserType_Id"]) == "1" || Convert.ToString(Session["UserType_Id"]) == "2")
            {

                

                strQry = "exec usp_tbl_StudentFeeAssignment  @type='FillGrid',@intStudent_id='" + Convert.ToString(Session["Student_id"]) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";

                dsObj = sGetDataset(strQry);



                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    Total += Convert.ToDouble(dsObj.Tables[0].Rows[i]["AmtWidDiscount"]);
             
                }
                lblAmt.Text = Convert.ToString(Total);
              
                //For Anual
                grvFee.DataSource = dsObj;
                grvFee.DataBind();


                //For Half Yearly
                DataTable dt = new DataTable();
                dt.Columns.Add("vchFee");
                dt.Columns.Add("AmtWidDiscount");
                DataRow dr;
                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["vchFee"] = Convert.ToString(dsObj.Tables[0].Rows[i]["vchFee"]);
                    dr["AmtWidDiscount"] = Convert.ToString(Convert.ToInt32(dsObj.Tables[0].Rows[i]["AmtWidDiscount"]) / 2);
                    dt.Rows.Add(dr);
                }

                grvHalf.DataSource = dt;
                grvHalf.DataBind();

                lblTotHalf.Text = Convert.ToString(Convert.ToInt32(Total) / 2);

                //For Quaterly
                dt = new DataTable();
                dt.Columns.Add("vchFee");
                dt.Columns.Add("AmtWidDiscount");

                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["vchFee"] = Convert.ToString(dsObj.Tables[0].Rows[i]["vchFee"]);
                    dr["AmtWidDiscount"] = Convert.ToString(Convert.ToInt32(dsObj.Tables[0].Rows[i]["AmtWidDiscount"]) / 4);
                    dt.Rows.Add(dr);
                }

                grvQuarter.DataSource = dt;
                grvQuarter.DataBind();

                lblTotQuat.Text = Convert.ToString(Convert.ToInt32(Total) / 4);

                //For MOnthly
                dt = new DataTable();
                dt.Columns.Add("vchFee");
                dt.Columns.Add("AmtWidDiscount");

                for (int i = 0; i < dsObj.Tables[0].Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["vchFee"] = Convert.ToString(dsObj.Tables[0].Rows[i]["vchFee"]);
                    dr["AmtWidDiscount"] = Convert.ToString(Convert.ToInt32(dsObj.Tables[0].Rows[i]["AmtWidDiscount"]) / 12);
                    dt.Rows.Add(dr);
                }

                grvMonth.DataSource = dt;
                grvMonth.DataBind();

                lblTotMonth.Text = Convert.ToString(Convert.ToInt32(Total) / 12);

                TBC.Tabs[0].Visible = true;
                TBC.Tabs[1].Visible = true;
                TBC.Tabs[0].Enabled = false;
            }
            
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
    protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillGrid();
            if (ddlStudent.SelectedValue == "0")
            {
                LBLTotal.Visible = false;
                btnSubmit.Visible = false;
                lbl.Visible = false;
            }
        }
        catch
        {
            
        }
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch
        {
            
        }
    }
    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           
            FillStudent();
            ddlStudent.SelectedValue = "0";
            grvDetail.DataSource = null;
            grvDetail.DataBind();
            LBLTotal.Visible = false;
            lbl.Visible = false;
            btnSubmit.Visible = false;
        }
        catch 
        {
            
        }
    }
}