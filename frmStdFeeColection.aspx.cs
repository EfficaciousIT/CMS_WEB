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

public partial class frmStdFeeColection : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strTutionFeeType = string.Empty, strLibraryFeeType = string.Empty, strComputerType = string.Empty, strClubActivityType = string.Empty;
    string strActivityFeeType = string.Empty, strAdmissionFeeType = string.Empty, strRegistrationFeeType = string.Empty, strSecurityFeeType = string.Empty;
    string strAnnualFeeType = string.Empty, strDevelopmentFeeType = string.Empty, strIDCardFeeType = string.Empty, strMagazineFeeType = string.Empty;
    bool boolFillExam;
    int TutionFee = 0, LibraryFee = 0, Computer = 0, ClubActivity = 0, ActivityFee = 0, AdmissionFee = 0, RegistrationFee = 0, SecurityFee = 0;
    int AnnualFee = 0, DevelopmentFee = 0, IDCardFee = 0, MagazineFee = 0;
    int intTotal = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label lblTile = new Label();
        lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        lblTile.Visible = true;
        lblTile.Text = "Fee Collection";
        if (!IsPostBack)
        {
            drpStandard.Enabled = true;
            drpPayType.Enabled = false;
            drpPayMode.Enabled = false;
            btnSub.Visible = false;
            FillStandard();
        }
    }
    protected void FillStandard()
    {
        strQry = "usp_TestSchedule @command='selectStandard',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(drpStandard, strQry, "vchStandard_name", "intStandard_id");
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        if (txtNameNo.Text != "")
        {
            //string strRegistrationNo = txtRegistrationNo.Text.Trim();

            //strRegistrationNo = strRegistrationNo.Insert(2, "/").Insert(5, "/").Insert(10, "/");

            //txtRegistrationNo.Text = strRegistrationNo;

            strQry = "usp_studentFee @command='select',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intDivision_id='" + drpDisivion.SelectedValue.Trim() + "',@studentName='" + txtNameNo.Text.Trim() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = dsObj;
                GridView1.DataBind();

                HiddenField1.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                HiddenField2.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                ViewState["student_id"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudent_id"]);
                
                

                drpPayType.Enabled = true;
                drpPayMode.Enabled = true;
                btnSub.Visible = true;


                strQry = "usp_feeCollection @command='GetNewID'";
                dsObj = sGetDataset(strQry);
                HiddenField4.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["No"]);

            }
            else
            {
                GridView1.DataSource = dsObj;
                GridView1.DataBind();
            }



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
    protected void drpPayType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpPayType.Text != "--Select--" & drpStandard.Text != "--Select--")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Sr. No.", typeof(string));
            dt.Columns.Add("Particulars", typeof(string));
            //dt.Columns.Add("Received Type", typeof(string));
            dt.Columns.Add("Amount", typeof(string));

            strQry = "usp_feeCollection @command='FeeCalcnew',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intstudent_id='" + Convert.ToString(ViewState["student_id"]) + "'";
            //strQry = "usp_feeCollection @command='FeeCalc',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "'";
            //usp_feeCollection @command='FeeCalcnew',@intstudent_id='541',@intStandard_id='5'
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpPayType.Enabled = true;
                drpPayMode.Enabled = true;
                btnSub.Visible = true;

                strTutionFeeType = Convert.ToString(dsObj.Tables[0].Rows[0]["TutionFeeType"]);
                strLibraryFeeType = Convert.ToString(dsObj.Tables[0].Rows[0]["LibraryFeeType"]);
                strComputerType = Convert.ToString(dsObj.Tables[0].Rows[0]["ComputerType"]);
                strClubActivityType = Convert.ToString(dsObj.Tables[0].Rows[0]["ClubActivityType"]);

                RegistrationFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["RegistrationFee"]);
                AdmissionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["AdmissionFee"]);
                SecurityFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["SecurityFee"]);

                AnnualFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["AnnualFee"]);
                DevelopmentFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["DevelopmentFee"]);
                IDCardFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["IDCardFee"]);
                MagazineFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["MagazineFee"]);

                if (strTutionFeeType == "Monthly")
                {
                    if (drpPayType.Text.Trim() == "Monthly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 1;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 1;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 1;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 1;

                        ViewState["TutionFee"] = "Monthly";
                        ViewState["LibraryFee"] = "Monthly";
                        ViewState["Computer"] = "Monthly";
                        ViewState["ClubActivity"] = "Monthly";


                        //dt.Rows.Add("1", "Tution", "Monthly", TutionFee);
                        //dt.Rows.Add("2", "Library", "Monthly", LibraryFee);
                        //dt.Rows.Add("3", "Computer", "Monthly", Computer);
                        //dt.Rows.Add("4", "Club Activity", "Monthly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                    }
                    else if (drpPayType.Text.Trim() == "Quarterly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 3;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 3;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 3;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 3;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Monthly", "Quarterly", TutionFee);
                        //dt.Rows.Add("Library", "Monthly", "Quarterly", LibraryFee);
                        //dt.Rows.Add("Computer", "Monthly", "Quarterly", Computer);
                        //dt.Rows.Add("Club Activity", "Monthly", "Quarterly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Quarterly";
                        ViewState["LibraryFee"] = "Quarterly";
                        ViewState["Computer"] = "Quarterly";
                        ViewState["ClubActivity"] = "Quarterly";
                    }
                    else if (drpPayType.Text.Trim() == "Halfyearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 6;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 6;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 6;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 6;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Monthly", "Halfyearly", TutionFee);
                        //dt.Rows.Add("Library", "Monthly", "Halfyearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Monthly", "Halfyearly", Computer);
                        //dt.Rows.Add("Club Activity", "Monthly", "Halfyearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Halfyearly";
                        ViewState["LibraryFee"] = "Halfyearly";
                        ViewState["Computer"] = "Halfyearly";
                        ViewState["ClubActivity"] = "Halfyearly";
                    }
                    else if (drpPayType.Text.Trim() == "Yearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 12;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 12;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 12;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 12;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Monthly", "Yearly", TutionFee);
                        //dt.Rows.Add("Library", "Monthly", "Yearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Monthly", "Yearly", Computer);
                        //dt.Rows.Add("Club Activity", "Monthly", "Yearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Yearly";
                        ViewState["LibraryFee"] = "Yearly";
                        ViewState["Computer"] = "Yearly";
                        ViewState["ClubActivity"] = "Yearly";
                    }
                }
                else if (strTutionFeeType == "Quarterly")
                {
                    if (drpPayType.Text.Trim() == "Quarterly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 1;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 1;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 1;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 1;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Quarterly", "Quarterly", TutionFee);
                        //dt.Rows.Add("Library", "Quarterly", "Quarterly", LibraryFee);
                        //dt.Rows.Add("Computer", "Quarterly", "Quarterly", Computer);
                        //dt.Rows.Add("Club Activity", "Quarterly", "Quarterly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Quarterly";
                        ViewState["LibraryFee"] = "Quarterly";
                        ViewState["Computer"] = "Quarterly";
                        ViewState["ClubActivity"] = "Quarterly";
                    }
                    else if (drpPayType.Text.Trim() == "Halfyearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 2;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 2;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 2;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 2;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Quarterly", "Halfyearly", TutionFee);
                        //dt.Rows.Add("Library", "Quarterly", "Halfyearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Quarterly", "Halfyearly", Computer);
                        //dt.Rows.Add("Club Activity", "Quarterly", "Halfyearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Halfyearly";
                        ViewState["LibraryFee"] = "Halfyearly";
                        ViewState["Computer"] = "Halfyearly";
                        ViewState["ClubActivity"] = "Halfyearly";
                    }
                    else if (drpPayType.Text.Trim() == "Yearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 4;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 4;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 4;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 4;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Quarterly", "Yearly", TutionFee);
                        //dt.Rows.Add("Library", "Quarterly", "Yearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Quarterly", "Yearly", Computer);
                        //dt.Rows.Add("Club Activity", "Quarterly", "Yearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Yearly";
                        ViewState["LibraryFee"] = "Yearly";
                        ViewState["Computer"] = "Yearly";
                        ViewState["ClubActivity"] = "Yearly";
                    }
                }
                else if (strTutionFeeType == "Halfyearly")
                {
                    if (drpPayType.Text.Trim() == "Halfyearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 1;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 1;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 1;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 1;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Halfyearly", "Halfyearly", TutionFee);
                        //dt.Rows.Add("Library", "Halfyearly", "Halfyearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Halfyearly", "Halfyearly", Computer);
                        //dt.Rows.Add("Club Activity", "Halfyearly", "Halfyearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Halfyearly";
                        ViewState["LibraryFee"] = "Halfyearly";
                        ViewState["Computer"] = "Halfyearly";
                        ViewState["ClubActivity"] = "Halfyearly";
                    }
                    else if (drpPayType.Text.Trim() == "Yearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 2;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 2;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 2;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 2;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Halfyearly", "Yearly", TutionFee);
                        //dt.Rows.Add("Library", "Halfyearly", "Yearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Halfyearly", "Yearly", Computer);
                        //dt.Rows.Add("Club Activity", "Halfyearly", "Yearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Yearly";
                        ViewState["LibraryFee"] = "Yearly";
                        ViewState["Computer"] = "Yearly";
                        ViewState["ClubActivity"] = "Yearly";
                    }
                }
                else if (strTutionFeeType == "Yearly")
                {
                    if (drpPayType.Text.Trim() == "Yearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 1;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 1;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 1;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 1;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Yearly", "Yearly", TutionFee);
                        //dt.Rows.Add("Library", "Yearly", "Yearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Yearly", "Yearly", Computer);
                        //dt.Rows.Add("Club Activity", "Yearly", "Yearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Yearly";
                        ViewState["LibraryFee"] = "Yearly";
                        ViewState["Computer"] = "Yearly";
                        ViewState["ClubActivity"] = "Yearly";
                    }

                }

                //dt.Rows.Add("Registration Fee", "One Time", "One Time", RegistrationFee);
                //dt.Rows.Add("Admission Fee", "One Time", "One Time", AdmissionFee);
                //dt.Rows.Add("Security Fee", "One Time", "One Time", SecurityFee);

                //dt.Rows.Add("Annual Fee", "Yearly", "Yearly", AnnualFee);
                //dt.Rows.Add("Development Fee", "Yearly", "Yearly", DevelopmentFee);
                //dt.Rows.Add("ID Card Fee", "Yearly", "Yearly", IDCardFee);
                //dt.Rows.Add("Magazine Fee", "Yearly", "Yearly", MagazineFee);

                dt.Rows.Add("5", "Registration Fee", RegistrationFee);
                dt.Rows.Add("6", "Admission Fee", AdmissionFee);
                dt.Rows.Add("7", "Security Fee", SecurityFee);

                dt.Rows.Add("8", "Annual Fee", AnnualFee);
                dt.Rows.Add("9", "Development Fee", DevelopmentFee);
                dt.Rows.Add("10", "ID Card Fee", IDCardFee);
                dt.Rows.Add("11", "Magazine Fee", MagazineFee);

                intTotal = intTotal + RegistrationFee + AdmissionFee + SecurityFee + AnnualFee + DevelopmentFee + IDCardFee + MagazineFee;

                ViewState["intTotal"] = intTotal;

                dt.Rows.Add("", "Total", intTotal);

                HiddenField5.Value = drpPayMode.Text + " " + Convert.ToString(intTotal);

                ViewState["dt"] = dt;

                grdFee.DataSource = dt;
                grdFee.DataBind();

            }
            else
            {
                grdFee.DataSource = null;
                grdFee.DataBind();

                drpPayType.Enabled = false;
                drpPayMode.Enabled = false;
                btnSub.Visible = false;
            }
        }
    }
    protected void btnSub_Click(object sender, EventArgs e)
    {
        DataTable dtObj = new DataTable();
        dtObj = (DataTable)ViewState["dt"];
        for (int i = 0; i <= dtObj.Rows.Count - 1; i++)
        {
            TutionFee = Convert.ToInt32(dtObj.Rows[i]["Amount"]);
            strTutionFeeType = Convert.ToString(dtObj.Rows[i]["Particulars"]);

            LibraryFee = Convert.ToInt32(dtObj.Rows[i + 1]["Amount"]);
            strLibraryFeeType = Convert.ToString(dtObj.Rows[i + 1]["Particulars"]);

            Computer = Convert.ToInt32(dtObj.Rows[i + 2]["Amount"]);
            strComputerType = Convert.ToString(dtObj.Rows[i + 1]["Particulars"]);

            ClubActivity = Convert.ToInt32(dtObj.Rows[i + 3]["Amount"]);
            strClubActivityType = Convert.ToString(dtObj.Rows[i + 3]["Particulars"]);

            ////------

            RegistrationFee = Convert.ToInt32(dtObj.Rows[i + 4]["Amount"]);
            strRegistrationFeeType = Convert.ToString(dtObj.Rows[i + 4]["Particulars"]);

            AdmissionFee = Convert.ToInt32(dtObj.Rows[i + 5]["Amount"]);
            strAdmissionFeeType = Convert.ToString(dtObj.Rows[i + 5]["Particulars"]);

            SecurityFee = Convert.ToInt32(dtObj.Rows[i + 6]["Amount"]);
            strSecurityFeeType = Convert.ToString(dtObj.Rows[i + 6]["Particulars"]);

            ////------

            AnnualFee = Convert.ToInt32(dtObj.Rows[i + 7]["Amount"]);
            strAnnualFeeType = Convert.ToString(dtObj.Rows[i + 7]["Particulars"]);

            DevelopmentFee = Convert.ToInt32(dtObj.Rows[i + 8]["Amount"]);
            strDevelopmentFeeType = Convert.ToString(dtObj.Rows[i + 8]["Particulars"]);

            IDCardFee = Convert.ToInt32(dtObj.Rows[i + 9]["Amount"]);
            strIDCardFeeType = Convert.ToString(dtObj.Rows[i + 9]["Particulars"]);

            MagazineFee = Convert.ToInt32(dtObj.Rows[i + 10]["Amount"]);
            strMagazineFeeType = Convert.ToString(dtObj.Rows[i + 10]["Particulars"]);

            string strRegistrationNo = HiddenField6.Value.Trim();

            //strRegistrationNo = strRegistrationNo.Insert(2, "/").Insert(5, "/").Insert(10, "/");

            //txtRegistrationNo.Text = strRegistrationNo;

            strQry = "usp_ReceiveFee @command='Insert',@academic_Year='',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "',@intStudent_id='" + Convert.ToString(ViewState["student_id"]) + "',@intRegistration_id='" + Convert.ToString(ViewState["RFID"]) + "',@AmountRecive='" + Convert.ToString(ViewState["intTotal"]) + "',@ReceiveBy='" + Convert.ToString(ViewState["User_id"]) + "',@RegistrationNo='" + strRegistrationNo.Trim() + "',@TutionFee='" + TutionFee + "',@TutionFeeType='" + Convert.ToString(ViewState["TutionFee"]) + "',@LibraryFee='" + LibraryFee + "',@LibraryFeeType='" + Convert.ToString(ViewState["LibraryFee"]) + "',@Computer='" + Computer + "',@ComputerType='" + Convert.ToString(ViewState["Computer"]) + "',@ClubActivity='" + ClubActivity + "',@ClubActivityType='" + Convert.ToString(ViewState["ClubActivity"]) + "',@ActivityFee='',@ActivityFeeType='',@AdmissionFee='" + AdmissionFee + "',@AdmissionFeeType='One Time',@RegistrationFee='" + RegistrationFee + "',@RegistrationFeeType='One Time',@SecurityFee='" + SecurityFee + "',@SecurityFeeType='One Time',@AnnualFee='" + AnnualFee + "',@AnnualFeeType='Yearly',@DevelopmentFee='" + DevelopmentFee + "',@DevelopmentFeeType='Yearly',@IDCardFee='" + IDCardFee + "',@IDCardFeeType='Yearly',@MagazineFee='" + MagazineFee + "',@MagazineFeeType='Yearly',@totalonetime='',@totalonetimeType='',@totalyearly='',@totalyearlyType='',@PaymentMode='" + drpPayMode.Text.Trim() + "',@ChequeNo='" + txtChequeNo.Text.Trim() + "',@ChequeDate='" + txtChequeDate.Text.Trim() + "',@BankName='" + txtBankname.Text.Trim() + "'";
            int k = sExecuteQuery(strQry);
            //int k = 1;
            if (k > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "print()", true);
                //MessageBox("Fee Details Addedd Successfully");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Fee Details Addedd Successfully');window.location ='frmStdFeeColection.aspx';", true);
            }

            i = dtObj.Rows.Count;
        }
    }
    protected void drpStandard_SelectedIndexChanged(object sender, EventArgs e)
    {
        strQry = "usp_Examination @command='Division',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intstandard_id='" + Convert.ToString(drpStandard.SelectedValue.Trim()) + "'";
        boolFillExam = sBindDropDownList(drpDisivion, strQry, "vchDivisionName", "intDivision_id");

        if (drpPayType.Text != "--Select--" & drpStandard.Text != "--Select--")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Sr. No.", typeof(string));
            dt.Columns.Add("Particulars", typeof(string));
            //dt.Columns.Add("Received Type", typeof(string));
            dt.Columns.Add("Amount", typeof(string));

            strQry = "usp_feeCollection @command='FeeCalc',@intStandard_id='" + drpStandard.SelectedValue.Trim() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                drpPayType.Enabled = true;
                drpPayMode.Enabled = true;
                btnSub.Visible = true;

                strTutionFeeType = Convert.ToString(dsObj.Tables[0].Rows[0]["TutionFeeType"]);
                strLibraryFeeType = Convert.ToString(dsObj.Tables[0].Rows[0]["LibraryFeeType"]);
                strComputerType = Convert.ToString(dsObj.Tables[0].Rows[0]["ComputerType"]);
                strClubActivityType = Convert.ToString(dsObj.Tables[0].Rows[0]["ClubActivityType"]);

                RegistrationFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["RegistrationFee"]);
                AdmissionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["AdmissionFee"]);
                SecurityFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["SecurityFee"]);

                AnnualFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["AnnualFee"]);
                DevelopmentFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["DevelopmentFee"]);
                IDCardFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["IDCardFee"]);
                MagazineFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["MagazineFee"]);

                if (strTutionFeeType == "Monthly")
                {
                    if (drpPayType.Text.Trim() == "Monthly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 1;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 1;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 1;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 1;

                        ViewState["TutionFee"] = "Monthly";
                        ViewState["LibraryFee"] = "Monthly";
                        ViewState["Computer"] = "Monthly";
                        ViewState["ClubActivity"] = "Monthly";


                        //dt.Rows.Add("1", "Tution", "Monthly", TutionFee);
                        //dt.Rows.Add("2", "Library", "Monthly", LibraryFee);
                        //dt.Rows.Add("3", "Computer", "Monthly", Computer);
                        //dt.Rows.Add("4", "Club Activity", "Monthly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                    }
                    else if (drpPayType.Text.Trim() == "Quarterly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 3;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 3;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 3;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 3;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Monthly", "Quarterly", TutionFee);
                        //dt.Rows.Add("Library", "Monthly", "Quarterly", LibraryFee);
                        //dt.Rows.Add("Computer", "Monthly", "Quarterly", Computer);
                        //dt.Rows.Add("Club Activity", "Monthly", "Quarterly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Quarterly";
                        ViewState["LibraryFee"] = "Quarterly";
                        ViewState["Computer"] = "Quarterly";
                        ViewState["ClubActivity"] = "Quarterly";
                    }
                    else if (drpPayType.Text.Trim() == "Halfyearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 6;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 6;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 6;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 6;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Monthly", "Halfyearly", TutionFee);
                        //dt.Rows.Add("Library", "Monthly", "Halfyearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Monthly", "Halfyearly", Computer);
                        //dt.Rows.Add("Club Activity", "Monthly", "Halfyearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Halfyearly";
                        ViewState["LibraryFee"] = "Halfyearly";
                        ViewState["Computer"] = "Halfyearly";
                        ViewState["ClubActivity"] = "Halfyearly";
                    }
                    else if (drpPayType.Text.Trim() == "Yearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 12;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 12;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 12;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 12;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Monthly", "Yearly", TutionFee);
                        //dt.Rows.Add("Library", "Monthly", "Yearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Monthly", "Yearly", Computer);
                        //dt.Rows.Add("Club Activity", "Monthly", "Yearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Yearly";
                        ViewState["LibraryFee"] = "Yearly";
                        ViewState["Computer"] = "Yearly";
                        ViewState["ClubActivity"] = "Yearly";
                    }
                }
                else if (strTutionFeeType == "Quarterly")
                {
                    if (drpPayType.Text.Trim() == "Quarterly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 1;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 1;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 1;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 1;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Quarterly", "Quarterly", TutionFee);
                        //dt.Rows.Add("Library", "Quarterly", "Quarterly", LibraryFee);
                        //dt.Rows.Add("Computer", "Quarterly", "Quarterly", Computer);
                        //dt.Rows.Add("Club Activity", "Quarterly", "Quarterly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Quarterly";
                        ViewState["LibraryFee"] = "Quarterly";
                        ViewState["Computer"] = "Quarterly";
                        ViewState["ClubActivity"] = "Quarterly";
                    }
                    else if (drpPayType.Text.Trim() == "Halfyearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 2;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 2;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 2;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 2;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Quarterly", "Halfyearly", TutionFee);
                        //dt.Rows.Add("Library", "Quarterly", "Halfyearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Quarterly", "Halfyearly", Computer);
                        //dt.Rows.Add("Club Activity", "Quarterly", "Halfyearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Halfyearly";
                        ViewState["LibraryFee"] = "Halfyearly";
                        ViewState["Computer"] = "Halfyearly";
                        ViewState["ClubActivity"] = "Halfyearly";
                    }
                    else if (drpPayType.Text.Trim() == "Yearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 4;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 4;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 4;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 4;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Quarterly", "Yearly", TutionFee);
                        //dt.Rows.Add("Library", "Quarterly", "Yearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Quarterly", "Yearly", Computer);
                        //dt.Rows.Add("Club Activity", "Quarterly", "Yearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Yearly";
                        ViewState["LibraryFee"] = "Yearly";
                        ViewState["Computer"] = "Yearly";
                        ViewState["ClubActivity"] = "Yearly";
                    }
                }
                else if (strTutionFeeType == "Halfyearly")
                {
                    if (drpPayType.Text.Trim() == "Halfyearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 1;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 1;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 1;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 1;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Halfyearly", "Halfyearly", TutionFee);
                        //dt.Rows.Add("Library", "Halfyearly", "Halfyearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Halfyearly", "Halfyearly", Computer);
                        //dt.Rows.Add("Club Activity", "Halfyearly", "Halfyearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Halfyearly";
                        ViewState["LibraryFee"] = "Halfyearly";
                        ViewState["Computer"] = "Halfyearly";
                        ViewState["ClubActivity"] = "Halfyearly";
                    }
                    else if (drpPayType.Text.Trim() == "Yearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 2;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 2;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 2;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 2;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Halfyearly", "Yearly", TutionFee);
                        //dt.Rows.Add("Library", "Halfyearly", "Yearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Halfyearly", "Yearly", Computer);
                        //dt.Rows.Add("Club Activity", "Halfyearly", "Yearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Yearly";
                        ViewState["LibraryFee"] = "Yearly";
                        ViewState["Computer"] = "Yearly";
                        ViewState["ClubActivity"] = "Yearly";
                    }
                }
                else if (strTutionFeeType == "Yearly")
                {
                    if (drpPayType.Text.Trim() == "Yearly")
                    {
                        TutionFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["TutionFee"]) * 1;
                        LibraryFee = Convert.ToInt32(dsObj.Tables[0].Rows[0]["LibraryFee"]) * 1;
                        Computer = Convert.ToInt32(dsObj.Tables[0].Rows[0]["Computer"]) * 1;
                        ClubActivity = Convert.ToInt32(dsObj.Tables[0].Rows[0]["ClubActivity"]) * 1;

                        intTotal = TutionFee + LibraryFee + Computer + ClubActivity;

                        //dt.Rows.Add("Tution", "Yearly", "Yearly", TutionFee);
                        //dt.Rows.Add("Library", "Yearly", "Yearly", LibraryFee);
                        //dt.Rows.Add("Computer", "Yearly", "Yearly", Computer);
                        //dt.Rows.Add("Club Activity", "Yearly", "Yearly", ClubActivity);

                        dt.Rows.Add("1", "Tution", TutionFee);
                        dt.Rows.Add("2", "Library", LibraryFee);
                        dt.Rows.Add("3", "Computer", Computer);
                        dt.Rows.Add("4", "Club Activity", ClubActivity);

                        ViewState["TutionFee"] = "Yearly";
                        ViewState["LibraryFee"] = "Yearly";
                        ViewState["Computer"] = "Yearly";
                        ViewState["ClubActivity"] = "Yearly";
                    }

                }

                //dt.Rows.Add("Registration Fee", "One Time", "One Time", RegistrationFee);
                //dt.Rows.Add("Admission Fee", "One Time", "One Time", AdmissionFee);
                //dt.Rows.Add("Security Fee", "One Time", "One Time", SecurityFee);

                //dt.Rows.Add("Annual Fee", "Yearly", "Yearly", AnnualFee);
                //dt.Rows.Add("Development Fee", "Yearly", "Yearly", DevelopmentFee);
                //dt.Rows.Add("ID Card Fee", "Yearly", "Yearly", IDCardFee);
                //dt.Rows.Add("Magazine Fee", "Yearly", "Yearly", MagazineFee);

                dt.Rows.Add("5", "Registration Fee", RegistrationFee);
                dt.Rows.Add("6", "Admission Fee", AdmissionFee);
                dt.Rows.Add("7", "Security Fee", SecurityFee);

                dt.Rows.Add("8,", "Annual Fee", AnnualFee);
                dt.Rows.Add("9", "Development Fee", DevelopmentFee);
                dt.Rows.Add("10", "ID Card Fee", IDCardFee);
                dt.Rows.Add("11", "Magazine Fee", MagazineFee);

                intTotal = intTotal + RegistrationFee + AdmissionFee + SecurityFee + AnnualFee + DevelopmentFee + IDCardFee + MagazineFee;

                ViewState["intTotal"] = intTotal;

                dt.Rows.Add("", "", "Total", intTotal);

                ViewState["dt"] = dt;

                grdFee.DataSource = dt;
                grdFee.DataBind();



            }
            else
            {
                grdFee.DataSource = null;
                grdFee.DataBind();

                drpPayType.Enabled = false;
                drpPayMode.Enabled = false;
                btnSub.Visible = false;
            }
        }
    }
    protected void rbName_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            Label Label = (Label)GridView1.Rows[i].Cells[0].FindControl("lblTestID");

            RadioButton chk = (RadioButton)GridView1.Rows[i].Cells[0].FindControl("chkCtrl");

            if (chk.Checked)
            {
                strQry = "usp_feeCollection @command='select',@vchRF_no='" + Label.Text.Trim() + "'";

                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    ViewState["RFID"] = Convert.ToString(dsObj.Tables[0].Rows[0]["intRF_id"]);

                    HiddenField1.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["Candidate Name"]);
                    HiddenField2.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["Father Name"]);
                    HiddenField3.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["RegistrationNo"]);
                    HiddenField6.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["No"]);

                    grdcandidate.DataSource = dsObj;
                    grdcandidate.DataBind();

                    drpStandard.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intstandard_id"]);
                    drpStandard.Enabled = false;

                    drpPayType.Enabled = true;
                    drpPayMode.Enabled = true;
                    btnSub.Visible = true;


                    strQry = "usp_feeCollection @command='GetNewID'";
                    dsObj = sGetDataset(strQry);
                    HiddenField4.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["No"]);

                }
            }
        }
    }
    protected void drpPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpPayMode.Text == "Cheque")
        {
            tblCheque.Visible = true;
        }
        else
        {
            tblCheque.Visible = false;
        }

    }
}
