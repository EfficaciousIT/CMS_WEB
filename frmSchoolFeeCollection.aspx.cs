using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmSchoolFeeCollection : DBUtility
{
    string strQry = "";
    DataSet dsObj;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserType_Id"] != null && Session["User_Id"] != null)
            {
                if (!IsPostBack)
                {
                   // fillAcademicYear();
                    FillSTD();
                    Clear();
                    fillDurationType();
                }
            }
            else
            {
                Response.Redirect("~\\Index.aspx", false);
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
            strQry = "exec usp_SchoolFeeCollection @type='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlSTD, strQry, "vchStandard_name", "intstandard_id");
        }
        catch
        {

        }
    }
    //public void FillGrid()
    //{
    //    try
    //    {
    //        strQry = "";
    //        //strQry = "exec usp_SchoolFeeCollection @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(drpAcademiYear.SelectedValue) + "',@intSTD_Id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
    //        strQry = "exec usp_SchoolFeeCollection @type='FillGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "'";
    //        dsObj = sGetDataset(strQry);
    //        grvDetail.DataSource = dsObj;
    //        grvDetail.DataBind();
    //    }
    //    catch
    //    {

    //    }
    //}

    //public void fillAcademicYear()
    //{
    //    try
    //    {
    //        strQry = "";
    //        strQry = "exec usp_SchoolFeeCollection @type='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
    //        sBindDropDownList(drpAcademiYear, strQry, "AcademicYear", "intAcademic_id");
           
    //    }
    //    catch
    //    {

    //    }
    //}

    public void fillStudent()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_SchoolFeeCollection @type='getStudents',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";

            sBindDropDownList(ddlStudentName, strQry, "vchStudent", "intStudent_id");
        }
        catch
        {

        }
    }

    public void fillDurationType()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTD @type='GetDuration',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlDurationType, qry, "vchDuration", "intDuration_Id");
        }
        catch
        {
        }
    }

    public void fillpartType()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTD @type='GetDurType',@intTutionId='" + Convert.ToString(ddlFeeHead.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(qry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                //txtDurationType.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["feeType"]);
            }
        }
        catch
        {
        }
    }

    public void fillMonths()
    {
        try
        {
          
            strQry = "";
            strQry = "exec usp_SchoolFeeCollection @type='findMonth',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "'";
           // strQry = "exec usp_FeesAssignSTD @type='GetMonths',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlMonths, strQry, "MonthName", "MonthNo");
            //if (ddlMonths.Items.Count > 1)
            //    ddlMonths.Items.Add(new ListItem("All", "-1"));
            //else
            //    ddlMonths.DataSource = null;
        }
        catch
        {
        }
    }
    public void fillMultiMonths()
    {
        try
        {
            drpToMonth.Visible = true;
            strQry = "";            
            //strQry = "exec usp_FeesAssignSTD @type='GetMonths',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            strQry = "exec usp_SchoolFeeCollection @type='findMonth',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                ddlMonths.DataTextField = "MonthName";
                ddlMonths.DataValueField = "MonthNo";
                ddlMonths.DataSource = dsObj;
                ddlMonths.DataBind();
            }

            strQry = "";
            strQry = "exec usp_SchoolFeeCollection @type='findMonthBetween',@MonthNo='" + Convert.ToString(ddlMonths.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpToMonth.DataTextField = "MonthName";
                drpToMonth.DataValueField = "MonthNo";
                drpToMonth.DataSource = dsObj;
                drpToMonth.DataBind();
                drpToMonth.Items.Insert(0, "---Select---");
            }
        }
        catch
        {
        }
    }

    protected void ddlSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillStudent();
    }
   
    //protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    try
    //    {
    //        Clear();
    //        TabPanel1.Enabled = true;
    //        int id = (int)grvDetail.DataKeys[e.NewEditIndex].Value;
    //        ViewState["Id"] = id;
    //        FillTransGrid();
    //        strQry = "exec usp_SchoolFeeCollection @type='FillEdit',@intTest_id='" + ViewState["Id"] + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            lblName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["CandiateName"]);
    //            lblStd.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStandard_id"]);
    //            fillCategory();
    //            ddlCategory.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intCat_Id"]);                
    //            ddlCategory.Enabled = false;

    //            //txtAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
    //            //txtDesc.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFeeDesc"]);
    //            //txtFrmDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["FrmDt"]);
    //            //txtToDt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Todt"]);
    //            TabContainer1.ActiveTabIndex = 1;
    //            //btnSubmit.Text = "Update";
               
    //        }
    //        strQry = "exec usp_SchoolFeeCollection @type='getTotalFee',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intCat_Id='" + Convert.ToString(ddlCategory.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
    //        dsObj = sGetDataset(strQry);
    //        if (dsObj.Tables[0].Rows.Count > 0)
    //        {
    //            txtTotalFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalFee"]);
    //            txtTotalFee.Enabled = false;
    //            //fillHead();
    //        }

    //    }
    //    catch
    //    {

    //    }
       
    //}
    public void fillHead()
    {
        try
        {
            strQry = "";
            int sum = 0;
            //strQry = "exec usp_SchoolFeeCollection @type='FillHead',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            //sBindDropDownList(ddlFeeHead, strQry, "vchFee", "intTutionID");
            strQry = "exec usp_SchoolFeeCollection @type='FillHeadAmt1',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@feeType='" + Convert.ToString(ddlDurationType.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                gvHead.DataSource = dsObj;
                gvHead.DataBind();
                for (int i = 0; i < gvHead.Rows.Count; i++)
                {
                    sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
                if (ddlDurationType.SelectedValue == "3" && ddlMonths.SelectedValue == "-1")
                {
                   
                    Int32 val1 = Convert.ToInt32(txtEnterAmt.Text);
                    Int32 val2 = 2;
                    Int32 val3 = val1 * val2;
                    txtEnterAmt.Text = val3.ToString();
                }
                    //txtEnterAmt.Text = sum.ToString();
              
            }
            else
            {
                gvHead.DataSource = dsObj;
                gvHead.DataBind();
                for (int i = 0; i < gvHead.Rows.Count; i++)
                {
                    sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
            }
           

        }
        catch
        {

        }
    }
    protected void ddlFeeHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillpartType();
        //if (txtDurationType.Text == "Monthly")
        //{
        //    lblMonths.Visible = true;
        //    ddlMonths.Visible = true;
        //    fillMonths();
        //}
        //else
        //{
        //    lblMonths.Visible = false;
        //    ddlMonths.Visible = false;
        //    ddlMonths.ClearSelection();
        //}
        
        //strQry = "exec usp_SchoolFeeCollection @type='FillHeadAmt',@intTutionID='" + Convert.ToString(ddlFeeHead.SelectedValue) + "',@intCat_Id='" + Convert.ToString(ddlCategory.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
        //    dsObj = sGetDataset(strQry);
        //    if (dsObj.Tables[0].Rows.Count > 0)
        //    {
        //        //txtHeadAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
        //        //txtHeadAmt.Enabled = false;
        //        txtEnterAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
                
        //    }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlDurationType.SelectedValue == "0")
        {
            MessageBox("Please Select Type!");
            ddlDurationType.Focus();
            return;
        }
        if (ddlMonths.SelectedItem.Text == "")
        {
            MessageBox("Please Select Month!");
            ddlMonths.Focus();
            return;
        }
        if (drpPayMode.SelectedValue == "0")
        {
            MessageBox("Please Select Pay Mode!");
            drpPayMode.Focus();
            return;
        }

        try
        {
            checksession();
            if (btnSubmit.Text == "Pay")
            {
                if (drpPayMode.SelectedValue=="1")
                {
                    if (ddlDurationType.SelectedValue == "1")
                    {
                        if (ddlMonths.SelectedValue == "-1")
                        {
                            if (((DataSet)Session["AllMonth"] != null))
                            {

                                foreach (DataRow dr in ((DataSet)Session["AllMonth"]).Tables[0].Rows)
                                {
                                    for (int i = 0; i < gvHead.Rows.Count; i++)
                                    {
                                        string sid = Convert.ToString(gvHead.Rows[i].Cells[0].Text);
                                        string amt = Convert.ToString(gvHead.Rows[i].Cells[2].Text);
                                        string monthID = Convert.ToString(dr["MonthName"]);
                                        // string dtcheque = Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy");
                                        //strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intRegistration_id='" + ViewState["Id"] + "',@intTutionID='" + Convert.ToString(ddlFeeHead.SelectedValue) + "',@intMonth_ID='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intPaidAmt='" + Convert.ToString(txtEnterAmt.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@vchChequeNo='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@dtCheque='" + Convert.ToString(txtChequeDate.Text.Trim()) + "',@vchBankName='" + Convert.ToString(txtBankName.Text.Trim()) + "'";
                                        strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@Month_Id='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + sid + "',@intMonth_ID='" + monthID + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                                        sExecuteQuery(strQry);

                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < gvHead.Rows.Count; i++)
                            {
                                string sid = Convert.ToString(gvHead.Rows[i].Cells[0].Text);
                                string amt = Convert.ToString(gvHead.Rows[i].Cells[2].Text);
                                // string monthID = Convert.ToString(dr["MonthName"]);
                                // string dtcheque = Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy");
                                //strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intRegistration_id='" + ViewState["Id"] + "',@intTutionID='" + Convert.ToString(ddlFeeHead.SelectedValue) + "',@intMonth_ID='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intPaidAmt='" + Convert.ToString(txtEnterAmt.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@vchChequeNo='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@dtCheque='" + Convert.ToString(txtChequeDate.Text.Trim()) + "',@vchBankName='" + Convert.ToString(txtBankName.Text.Trim()) + "'";
                                strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@Month_Id='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + sid + "',@intMonth_ID='" + Convert.ToString(ddlMonths.SelectedItem.Text.Trim()) + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                                sExecuteQuery(strQry);
                            }
                        }
                    }
                   else if (ddlDurationType.SelectedValue == "3")
                    {
                        if (((DataSet)Session["AllHalfYearly"] != null))
                        {
                            if (ddlMonths.SelectedValue == "-1")
                            {
                                foreach (DataRow dr in ((DataSet)Session["AllHalfYearly"]).Tables[0].Rows)
                                {
                                    for (int i = 0; i < gvHead.Rows.Count; i++)
                                    {
                                        string sid = Convert.ToString(gvHead.Rows[i].Cells[0].Text);
                                        string amt = Convert.ToString(gvHead.Rows[i].Cells[2].Text);
                                        string monthID = Convert.ToString(dr["vchMonth"]);
                                        // string dtcheque = Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy");
                                        //strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intRegistration_id='" + ViewState["Id"] + "',@intTutionID='" + Convert.ToString(ddlFeeHead.SelectedValue) + "',@intMonth_ID='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intPaidAmt='" + Convert.ToString(txtEnterAmt.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@vchChequeNo='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@dtCheque='" + Convert.ToString(txtChequeDate.Text.Trim()) + "',@vchBankName='" + Convert.ToString(txtBankName.Text.Trim()) + "'";
                                        strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@Month_Id='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + sid + "',@intMonth_ID='" + monthID + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                                        sExecuteQuery(strQry);

                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < gvHead.Rows.Count; i++)
                                {
                                    string sid = Convert.ToString(gvHead.Rows[i].Cells[0].Text);
                                    string amt = Convert.ToString(gvHead.Rows[i].Cells[2].Text);

                                    // string dtcheque = Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy");
                                    //strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intRegistration_id='" + ViewState["Id"] + "',@intTutionID='" + Convert.ToString(ddlFeeHead.SelectedValue) + "',@intMonth_ID='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intPaidAmt='" + Convert.ToString(txtEnterAmt.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@vchChequeNo='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@dtCheque='" + Convert.ToString(txtChequeDate.Text.Trim()) + "',@vchBankName='" + Convert.ToString(txtBankName.Text.Trim()) + "'";
                                    strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@Month_Id='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + sid + "',@intMonth_ID='" + Convert.ToString(ddlMonths.SelectedItem.Text.Trim()) + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                                    sExecuteQuery(strQry);

                                }
                            }
                        }
                        
                    }
                    else if (ddlDurationType.SelectedValue == "111")
                    {
                        for (int j = 0; j < gvHead.Rows.Count; j++)
                        {
                            for (int i = Convert.ToInt32(ddlMonths.SelectedValue); i <= Convert.ToInt32(drpToMonth.SelectedValue); i++)
                            {
                                string strMonth = Convert.ToString(i);

                                strQry = "usp_SchoolFeeCollection @type='getvchMonth',@MonthNo='" + strMonth + "'";
                                dsObj = sGetDataset(strQry);
                                if (dsObj.Tables[0].Rows.Count > 0)
                                {
                                    string strvchMonth = Convert.ToString(dsObj.Tables[0].Rows[0][0]);
                                    string sid = Convert.ToString(gvHead.Rows[j].Cells[0].Text);
                                    string amt = Convert.ToString(gvHead.Rows[j].Cells[2].Text);

                                    strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@Month_Id='" + strMonth + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + sid + "',@intMonth_ID='" + strvchMonth + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                                    sExecuteQuery(strQry);

                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < gvHead.Rows.Count; i++)
                        {
                            string sid = Convert.ToString(gvHead.Rows[i].Cells[0].Text);
                            string amt = Convert.ToString(gvHead.Rows[i].Cells[2].Text);

                            // string dtcheque = Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy");
                            //strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intRegistration_id='" + ViewState["Id"] + "',@intTutionID='" + Convert.ToString(ddlFeeHead.SelectedValue) + "',@intMonth_ID='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intPaidAmt='" + Convert.ToString(txtEnterAmt.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@vchChequeNo='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@dtCheque='" + Convert.ToString(txtChequeDate.Text.Trim()) + "',@vchBankName='" + Convert.ToString(txtBankName.Text.Trim()) + "'";
                            strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@Month_Id='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + sid + "',@intMonth_ID='" + Convert.ToString(ddlMonths.SelectedItem.Text.Trim()) + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
                            sExecuteQuery(strQry);

                        }
                    }

                }
                if (drpPayMode.SelectedValue == "2")
                {
                    for (int i = 0; i < gvHead.Rows.Count; i++)
                    {
                        string sid = Convert.ToString(gvHead.Rows[i].Cells[0].Text);
                        string amt = Convert.ToString(gvHead.Rows[i].Cells[2].Text);

                        string dtcheque = Convert.ToDateTime(txtChequeDate.Text).ToString("MM/dd/yyyy");
                        //strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intRegistration_id='" + ViewState["Id"] + "',@intTutionID='" + Convert.ToString(ddlFeeHead.SelectedValue) + "',@intMonth_ID='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intPaidAmt='" + Convert.ToString(txtEnterAmt.Text.Trim()) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@vchChequeNo='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@dtCheque='" + Convert.ToString(txtChequeDate.Text.Trim()) + "',@vchBankName='" + Convert.ToString(txtBankName.Text.Trim()) + "'";
                        strQry = "exec [usp_SchoolFeeCollection] @type='InsertFee',@Month_Id='" + Convert.ToString(ddlMonths.SelectedValue) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "',@intTutionID='" + sid + "',@intMonth_ID='" + Convert.ToString(ddlMonths.SelectedItem.Text.Trim()) + "',@intPaidAmt='" + amt + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intPayMode='" + Convert.ToString(drpPayMode.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@vchChequeNo='" + Convert.ToString(txtChequeNo.Text.Trim()) + "',@dtCheque='" + dtcheque + "',@vchBankName='" + Convert.ToString(txtBankName.Text.Trim()) + "'";
                        sExecuteQuery(strQry);

                    }

                }
                FillTransGrid();
                MessageBox("Fee Accepted");
                ddlFeeHead.ClearSelection();
               // txtDurationType.Text = "";
                txtHeadAmt.Text = "";
                txtEnterAmt.Text = "";
                drpPayMode.ClearSelection();
                ddlDurationType.ClearSelection();
                txtChequeNo.Text = "";
                txtChequeDate.Text = "";
                txtBankName.Text = "";
                lblMonths.Visible = false;
                ddlMonths.Visible = false;
                drpToMonth.Visible = false;
                drpToMonth.ClearSelection();
                ddlMonths.ClearSelection();
                lblc1.Visible = false;
                lblc2.Visible = false;
                lblc3.Visible = false;
                txtChequeNo.Visible = false;
                txtChequeDate.Visible = false;
                txtBankName.Visible = false;
                fillHead();
                return;
            }
               
            }
            
        catch
        {

        }
    }
    public void FillTransGrid()
    {
        try
        {
            int sum = 0;
            strQry = "";
            strQry = "exec usp_SchoolFeeCollection @type='FillTransGrid',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue) + "'";
            dsObj = sGetDataset(strQry);
            grdTrans.DataSource = dsObj;
            grdTrans.DataBind();

            for (int i = 0; i < grdTrans.Rows.Count; i++)
            {
                sum += int.Parse(grdTrans.Rows[i].Cells[4].Text);
            }
            lblTotal.Text = sum.ToString();
            //int totFee = Convert.ToInt32(txtTotalFee.Text.Trim());
            //int amt = Convert.ToInt32(lblTotal.Text.Trim());
            //int remain = totFee - amt;

            //lblTotal.Text = remain.ToString();
               
        }
        catch
        {

        }
    }

     
    protected void drpPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpPayMode.SelectedValue == "2")
        {
            lblc1.Visible = true;
            lblc2.Visible = true;
            lblc3.Visible = true;
            txtChequeNo.Visible = true;
            txtChequeDate.Visible = true;
            txtBankName.Visible = true;
        }
        else
        {
            lblc1.Visible = false;
            lblc2.Visible = false;
            lblc3.Visible = false;
            txtChequeNo.Visible = false;
            txtChequeDate.Visible = false;
            txtBankName.Visible = false;
        }
    }
    public void Clear()
    {
        try
        {
            //lblName.Text = "";
            //lblStd.Text = "";
            //ddlCategory.ClearSelection();
            txtTotalFee.Text = "";
            ddlFeeHead.ClearSelection();
            //txtDurationType.Text = "";
            txtHeadAmt.Text = "";
            txtEnterAmt.Text = "";
            drpPayMode.ClearSelection();
            txtChequeNo.Text = "";
            txtChequeDate.Text = "";
            txtBankName.Text = "";
        }
        catch
        {

        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        DataSet dsObj = new DataSet();
        strQry = "";
        strQry = "exec usp_SchoolFeeCollection @type='CReportFeeTrans',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue.Trim()) + "'";
        dsObj = sGetDataset(strQry);
        Session["rptFee"] = dsObj;
        Response.Redirect("frmFeeReport.aspx", true);
    }
    protected void grdTrans_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            Session["intID"] = Convert.ToString(grdTrans.DataKeys[e.RowIndex].Value);
            strQry = "";
            strQry = "exec [usp_SchoolFeeCollection] @type='delete',@intID='" + Convert.ToString(Session["intID"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            if (sExecuteQuery(strQry) != -1)
            {
                FillTransGrid();
                MessageBox("Transaction Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
    protected void ddlDurationType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillHead();
        lblMonths.Visible=true;
        ddlMonths.Visible = true;
      
        if (ddlDurationType.SelectedValue == "1" || ddlDurationType.SelectedValue == "5")
        {           
            fillMonths();
            drpToMonth.Visible = false;
        }
        if (ddlDurationType.SelectedValue == "2" || ddlDurationType.SelectedValue == "6")
        {
            fillQuarterly();
            drpToMonth.Visible = false;
        }
        if (ddlDurationType.SelectedValue == "3" || ddlDurationType.SelectedValue == "7")
        {
            fillHalfYearly();
            drpToMonth.Visible = false;
        }
        if (ddlDurationType.SelectedValue == "4" || ddlDurationType.SelectedValue == "8")
        {
            fillAnnualy();
            drpToMonth.Visible = false;
        }
        if (ddlDurationType.SelectedValue == "111")
        {
            fillHeadforMulti();
            fillMultiMonths();
        }
    }
    public void fillQuarterly()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTD @type='fillQuarterly',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlMonths, qry, "vchMonth", "intQuartarly_id");
        }
        catch
        {
        }
    }
    public void fillHalfYearly()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTD @type='fillHalfYearly',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlMonths, qry, "vchMonth", "int_half_yearly_id");

            //if (ddlMonths.Items.Count > 1)
            //    ddlMonths.Items.Add(new ListItem("All", "-1"));
            //else
            //    ddlMonths.DataSource = null;
        }
        catch
        {
        }
    }
    public void fillAnnualy()
    {
        try
        {
            string qry = "exec usp_FeesAssignSTD @type='fillAnnualy',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlMonths, qry, "vchMonth", "intYearly_id");
        }
        catch
        {
        }
    }
    protected void ddlStudentName_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "exec usp_SchoolFeeCollection @type='getTotalFee',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    txtTotalFee.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalFee"]);
                }
                FillTransGrid();
    }
    protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDurationType.SelectedValue == "1" || ddlDurationType.SelectedValue == "5")
        {
            string qry1 = "exec usp_FeesAssignSTD @type='GetMonths',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(qry1);
            Session["AllMonth"] = dsObj;
        }
        if (ddlDurationType.SelectedValue == "2" || ddlDurationType.SelectedValue == "6")
        {
            string qry2 = "exec usp_FeesAssignSTD @type='fillQuarterly',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(qry2);
            Session["AllQuarterly"] = dsObj;            
        }
        if (ddlDurationType.SelectedValue == "3" || ddlDurationType.SelectedValue == "7")
        {
            string qry3 = "exec usp_FeesAssignSTD @type='fillHalfYearly',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            dsObj = sGetDataset(qry3);
            Session["AllHalfYearly"] = dsObj;
            fillHead();
        }       
    }
    protected void drpToMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intMonth = Convert.ToInt32(drpToMonth.SelectedValue) - Convert.ToInt32(ddlMonths.SelectedValue);

        ViewState["intMonth"] = intMonth + 1;
        strQry = "usp_SchoolFeeCollection @type='getFrmToMonthly',@TotalMonth='" + Convert.ToString(intMonth + 1) + "',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            txtEnterAmt.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["numAmount"]);
        }
    }
    public void fillHeadforMulti()
    {
        try
        {
            strQry = "";
            int sum = 0;
            strQry = "exec usp_SchoolFeeCollection @type='FillHeadAmt1',@intStandard_id='" + Convert.ToString(ddlSTD.SelectedValue) + "',@feeType='1',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                gvHead.DataSource = dsObj;
                gvHead.DataBind();
                for (int i = 0; i < gvHead.Rows.Count; i++)
                {
                    sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
            }
            else
            {
                gvHead.DataSource = dsObj;
                gvHead.DataBind();
                for (int i = 0; i < gvHead.Rows.Count; i++)
                {
                    sum += int.Parse(gvHead.Rows[i].Cells[2].Text);
                }
                txtEnterAmt.Text = sum.ToString();
            }


        }
        catch
        {

        }
    }

    protected void grdTrans_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intID"] = Convert.ToString(grdTrans.DataKeys[e.NewEditIndex].Value);
            DataSet dsObj = new DataSet();
            strQry = "";
            strQry = "exec usp_SchoolFeeCollection @type='CReportFeeTransPrint',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intstudent_id='" + Convert.ToString(ddlStudentName.SelectedValue.Trim()) + "',@intID='" + Convert.ToString(Session["intID"]) + "'";
            dsObj = sGetDataset(strQry);
            Session["rptFee"] = dsObj;
            Response.Redirect("frmFeeReport.aspx", true);
        }
        catch
        {

        }
    }
}