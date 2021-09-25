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


public partial class frmPromotionDemotion : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillAcademicYear();
            fillToAcademicYear();
            FillfrmSTD();
        }
    }
    public void fillAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_PromotionDemotion @command='fillAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlAcademiYear, strQry, "AcademicYear", "intAcademic_id");           
           // sBindDropDownList(ddlToAcademiYear, strQry, "AcademicYear", "intAcademic_id");
           // ddlAcademiYear.SelectedValue = "1";
            ddlAcademiYear.SelectedIndex = 1;
        }
        catch
        {
            
        }
    }
    public void fillToAcademicYear()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_PromotionDemotion @command='fillToAcademicYear',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";           
            sBindDropDownList(ddlToAcademiYear, strQry, "AcademicYear", "intAcademic_id");
           
        }
        catch
        {

        }
    }
    public void FillfrmSTD()
    {
        try
        {           
            strQry = "";
            strQry = "exec usp_PromotionDemotion  @command='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlFromSTD, strQry, "vchStandard_name", "intstandard_id");           
        }
        catch
        {

        }
    }
    public void FilltoSTD()
    {
        try
        {
            strQry = "";
            strQry = "exec usp_PromotionDemotion  @command='FillSTD',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "'";
            sBindDropDownList(ddlToSTD, strQry, "vchStandard_name", "intstandard_id");
        }
        catch
        {

        }
    }
    protected void SelectStudentGrid()
    {
        strQry = "usp_PromotionDemotion @command='SelectStudent',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(ddlAcademiYear.SelectedValue) + "',@intstandard_id='" + Convert.ToString(ddlFromSTD.SelectedValue) + "',@intDivision_id='" + ddlfromdiv.SelectedValue + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            gvList.DataSource = dsObj;
            gvList.DataBind();

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlFromSTD.SelectedValue == "0")
        {
            MessageBox("Please Select From Standard!");
            ddlFromSTD.Focus();
            return;
        }
        if (ddlToAcademiYear.SelectedValue == "0")
        {
            MessageBox("Please Select To Academic Year!");
            ddlToAcademiYear.Focus();
            return;
        }
        if (ddlToSTD.SelectedValue == "0")
        {
            MessageBox("Please Select To Standard!");
            ddlToSTD.Focus();
            return;
        }

        if (ddlfromdiv.SelectedValue == "0")
        {
            MessageBox("Please Select From  Division!");
            ddlfromdiv.Focus();
            return;
        }

        if (ddltodiv.SelectedValue == "0")
        {
            MessageBox("Please Select To  Division!");
            ddltodiv.Focus();
            return;
        }
        try
        {
            if (btnSubmit.Text == "Promote")
            {
                foreach (GridViewRow gvrow in gvList.Rows)
                {
                    CheckBox chkRow = (gvrow.Cells[1].FindControl("chkCtrl") as CheckBox);

                    if (chkRow.Checked)
                    {
                        string Fromacademicyrs = Convert.ToString(ddlAcademiYear.SelectedValue);
                        string AcaYr = Convert.ToString(ddlToAcademiYear.SelectedValue);
                        string frmStd = Convert.ToString(ddlFromSTD.SelectedValue);
                        string toStd = Convert.ToString(ddlToSTD.SelectedValue);
                        string ToDivision = Convert.ToString(ddltodiv.SelectedValue);
                        string intStudent_id = this.gvList.DataKeys[gvrow.RowIndex].Values[0].ToString();
                        string StudentName = this.gvList.DataKeys[gvrow.RowIndex].Values[1].ToString();

                        //strQry = "exec [usp_PromotionDemotion] @command='InsertPromotion',@FromAcademicId='" + Fromacademicyrs + "',@intAcademic_id='" + AcaYr + "',@intstandard_id='" + toStd + "',@intstandard_idFrom='" + frmStd + "',@intStudent_id='" + intStudent_id + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                        //sExecuteQuery(strQry);

                        //Code By Nikhil
                        strQry = "exec [usp_PromotionDemotion] @command='SelectStudentData',@intStudent_id='" + intStudent_id + "'";
                        dsObj = sGetDataset(strQry);

                        string vchapplication_no = Convert.ToString(dsObj.Tables[0].Rows[0]["vchapplication_no"]);

                        string GRNo = Convert.ToString(dsObj.Tables[0].Rows[0]["intGRNo"]);
                        // string StandId = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                        string StandId = toStd;
                        //string DiviId = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                        string DiviId = ToDivision;
                        string rollno = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                        string Fname = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                        string Mname = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentMiddle_name"]);
                        string lname = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentLast_name"]);
                        string Fathername = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                        string Mothername = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                        string Emailid = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmail"]); 
                        string Dobnm = null;
                        Dobnm = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("MM/dd/yyyy");
                        string cast = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCast"]);
                        string subcast = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubcast"]);
                        string gender = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]);
                        string filnmn = null;
                        filnmn = Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);

                        string fathno = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo1"]);

                        string mothno = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo2"]);


                        string Preadd = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpresentAddress"]);
                        string paradd = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpermanentAddress"]);
                        string Bloodgp = Convert.ToString(dsObj.Tables[0].Rows[0]["chrBloodGrp"]);
                        string healthdis = Convert.ToString(dsObj.Tables[0].Rows[0]["vchHandicapedStatus"]);
                        string Descip = Convert.ToString(dsObj.Tables[0].Rows[0]["vchHandicapedStatus"]);
                        string insertby = Convert.ToString(Session["User_id"]);

                        string insertdt = DateTime.Now.ToString("MM/dd/yyyy");
                        string ipval = GetSystemIP();

                        string StuID_Number = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudentID_Number"]);
                        string BirthPlace = Convert.ToString(dsObj.Tables[0].Rows[0]["vchplaceofBirth"]);
                        string BusAlert = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert1"]);
                        //string dtAdm = Convert.ToString(txtAdmissionDate.Text);
                        string dtAdm = null;
                        dtAdm = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtAdmission"]).ToString("MM/dd/yyyy");
                        string Mothertongue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMothertongue"]);
                        string Religion = Convert.ToString(dsObj.Tables[0].Rows[0]["vchReligion"]);
                        string FirstLang = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirstLanguage"]);
                        string SecondLang = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSecondLanguage"]);
                        string ThirdLang = Convert.ToString(dsObj.Tables[0].Rows[0]["vchThirdLanguage"]);

                        string Studentaadhar = Convert.ToString(dsObj.Tables[0].Rows[0]["vchaadhar_no"]);
                        string Fatheraadhar = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmergencyConPerson1"]);
                        string Motheraadhar = Convert.ToString(dsObj.Tables[0].Rows[0]["intEmergencyContat1"]);

                        string FatherOccu = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherOccupation"]);
                        string MotherOccu = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherOccupation"]);
                        string FatherDesign = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherDesignation"]);
                        string MotherDesign = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherDesignation"]);
                        string FatherIncome = Convert.ToString(dsObj.Tables[0].Rows[0]["intFatherIncome"]);
                        string MotherIncome = Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherIncome"]);
                        string UserName = Convert.ToString(dsObj.Tables[0].Rows[0]["vchUser_name"]);
                        string Password = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPassword"]);
                        string Nationality = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNationality"]);
                        string LandMark = Convert.ToString(dsObj.Tables[0].Rows[0]["vchLandMark"]);
                        string Pincode = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPincode"]);

                        string CountryID = Convert.ToString(dsObj.Tables[0].Rows[0]["intCountry_id"]);
                        string StateID = Convert.ToString(dsObj.Tables[0].Rows[0]["intState_id"]);
                        string CityID = Convert.ToString(dsObj.Tables[0].Rows[0]["intCity_id"]);

                        string instrquery1 = "Execute usp_PromotionDemotion @command='StudentPromotion',@vchapplication_no='" + vchapplication_no + "', @intGRNo='" + GRNo + "',@intstanderd_id='" + StandId + "',@intDivision_id='" + DiviId + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                                              "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@intHomePhoneNo1='" + fathno + "',@intHomePhoneNo2='" + mothno + "',@dtDOB='" + Dobnm + "',@dtActivationDate='" + insertdt + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                                              "@intStudentID_Number='" + StuID_Number + "',@vchplaceofBirth='" + BirthPlace + "',@intBusAlert1='" + BusAlert + "',@dtAdmission='" + dtAdm + "',@vchMothertongue='" + Mothertongue + "',@vchReligion='" + Religion + "',@vchFirstLanguage='" + FirstLang + "',@vchSecondLanguage='" + SecondLang + "'," +
                                              "@vchThirdLanguage='" + ThirdLang + "',@vchFatherOccupation='" + FatherOccu + "',@vchMotherOccupation='" + MotherOccu + "',@vchFatherDesignation='" + FatherDesign + "',@vchMotherDesignation='" + MotherDesign + "',@intFatherIncome='" + FatherIncome + "',@intMotherIncome='" + MotherIncome + "',@vchNationality='" + Nationality + "',@vchLandMark='" + LandMark + "',@vchPincode='" + Pincode + "'," +
                                              "@intCountry_id='" + CountryID + "',@intState_id='" + StateID + "',@intCity_id='" + CityID + "'," +

                                              "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchProfile='" + filnmn + "',@chrBloodGrp='" + Bloodgp + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intSchool_id='" + Session["School_Id"] + "',@intAcademic_id='" + AcaYr + "',@vchaadhar_no='" + Studentaadhar + "',@vchEmergencyConPerson1='" + Fatheraadhar + "',@intEmergencyContat1='" + Motheraadhar + "',@vchUser_name='" + UserName + "',@vchPassword='" + Password + "'";


                        int str = sExecuteQuery(instrquery1);

                        if (str > 0)
                        {
                            string query = " Execute usp_PromotionDemotion  @command='UpdateStatus',@vchPromotion=Promoted,@intStudent_id='" + intStudent_id + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                            int result = sExecuteQuery(query);
                            if (result > 0)
                            {
                                MessageBox("Records Promoted Successfully");
                            }
                        }


                    }

                    else
                    {
                        //string AcaYr = Convert.ToString(ddlToAcademiYear.SelectedValue);
                        //string frmStd = Convert.ToString(ddlFromSTD.SelectedValue);                                  
                        //string intStudent_id = this.gvList.DataKeys[gvrow.RowIndex].Values[0].ToString();
                        //strQry = "exec [usp_PromotionDemotion] @command='UpdateDemotion',@intAcademic_id='" + AcaYr + "',@intstandard_id='" + frmStd + "',@intStudent_id='" + intStudent_id + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                        //sExecuteQuery(strQry);     

                        //string Fromacademicyrs = Convert.ToString(ddlAcademiYear.SelectedValue);
                        //string AcaYr = Convert.ToString(ddlToAcademiYear.SelectedValue);
                        //string frmStd = Convert.ToString(ddlFromSTD.SelectedValue);
                        //string toStd = Convert.ToString(ddlToSTD.SelectedValue);
                        //string ToDivision = Convert.ToString(ddltodiv.SelectedValue);
                        //string intStudent_id = this.gvList.DataKeys[gvrow.RowIndex].Values[0].ToString();
                        //string StudentName = this.gvList.DataKeys[gvrow.RowIndex].Values[1].ToString();

                        ////strQry = "exec [usp_PromotionDemotion] @command='InsertPromotion',@FromAcademicId='" + Fromacademicyrs + "',@intAcademic_id='" + AcaYr + "',@intstandard_id='" + toStd + "',@intstandard_idFrom='" + frmStd + "',@intStudent_id='" + intStudent_id + "',@intSchool_Id='" + Convert.ToString(Session["School_Id"]) + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "'";
                        ////sExecuteQuery(strQry);

                        ////Code By Nikhil
                        //strQry = "exec [usp_PromotionDemotion] @command='SelectStudentData',@intStudent_id='" + intStudent_id + "'";
                        //dsObj = sGetDataset(strQry);

                        //string vchapplication_no = Convert.ToString(dsObj.Tables[0].Rows[0]["vchapplication_no"]);

                        //string GRNo = Convert.ToString(dsObj.Tables[0].Rows[0]["intGRNo"]);
                        //// string StandId = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                        //string StandId = frmStd;
                        ////string DiviId = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                        //string DiviId = ToDivision;
                        //string rollno = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                        //string Fname = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                        //string Mname = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentMiddle_name"]);
                        //string lname = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentLast_name"]);
                        //string Fathername = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                        //string Mothername = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                        //string Emailid = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmail"]);
                        //string Dobnm = null;
                        //Dobnm = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("MM/dd/yyyy");
                        //string cast = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCast"]);
                        //string subcast = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubcast"]);
                        //string gender = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]);
                        //string filnmn = null;
                        //filnmn = Convert.ToString(dsObj.Tables[0].Rows[0]["vchProfile"]);

                        //string fathno = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo1"]);

                        //string mothno = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo2"]);


                        //string Preadd = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpresentAddress"]);
                        //string paradd = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpermanentAddress"]);
                        //string Bloodgp = Convert.ToString(dsObj.Tables[0].Rows[0]["chrBloodGrp"]);
                        //string healthdis = Convert.ToString(dsObj.Tables[0].Rows[0]["vchHandicapedStatus"]);
                        //string Descip = Convert.ToString(dsObj.Tables[0].Rows[0]["vchHandicapedStatus"]);
                        //string insertby = Convert.ToString(Session["User_id"]);

                        //string insertdt = DateTime.Now.ToString("MM/dd/yyyy");
                        //string ipval = GetSystemIP();

                        //string StuID_Number = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudentID_Number"]);
                        //string BirthPlace = Convert.ToString(dsObj.Tables[0].Rows[0]["vchplaceofBirth"]);
                        //string BusAlert = Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert1"]);
                        ////string dtAdm = Convert.ToString(txtAdmissionDate.Text);
                        //string dtAdm = null;
                        //dtAdm = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtAdmission"]).ToString("MM/dd/yyyy");
                        //string Mothertongue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMothertongue"]);
                        //string Religion = Convert.ToString(dsObj.Tables[0].Rows[0]["vchReligion"]);
                        //string FirstLang = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirstLanguage"]);
                        //string SecondLang = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSecondLanguage"]);
                        //string ThirdLang = Convert.ToString(dsObj.Tables[0].Rows[0]["vchThirdLanguage"]);

                        //string Studentaadhar = Convert.ToString(dsObj.Tables[0].Rows[0]["vchaadhar_no"]);
                        //string Fatheraadhar = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmergencyConPerson1"]);
                        //string Motheraadhar = Convert.ToString(dsObj.Tables[0].Rows[0]["intEmergencyContat1"]);

                        //string FatherOccu = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherOccupation"]);
                        //string MotherOccu = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherOccupation"]);
                        //string FatherDesign = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherDesignation"]);
                        //string MotherDesign = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherDesignation"]);
                        //string FatherIncome = Convert.ToString(dsObj.Tables[0].Rows[0]["intFatherIncome"]);
                        //string MotherIncome = Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherIncome"]);
                        //string UserName = Convert.ToString(dsObj.Tables[0].Rows[0]["vchUser_name"]);
                        //string Password = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPassword"]);
                        //string Nationality = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNationality"]);
                        //string LandMark = Convert.ToString(dsObj.Tables[0].Rows[0]["vchLandMark"]);
                        //string Pincode = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPincode"]);

                        //string CountryID = Convert.ToString(dsObj.Tables[0].Rows[0]["intCountry_id"]);
                        //string StateID = Convert.ToString(dsObj.Tables[0].Rows[0]["intState_id"]);
                        //string CityID = Convert.ToString(dsObj.Tables[0].Rows[0]["intCity_id"]);

                        //string ReceiptNo = Convert.ToString(dsObj.Tables[0].Rows[0]["Receipt_no"]);

                        //string instrquery1 = "Execute usp_PromotionDemotion @command='StudentPromotion',@vchapplication_no='" + vchapplication_no + "', @intGRNo='" + GRNo + "',@intstanderd_id='" + StandId + "',@intDivision_id='" + ddlfromdiv.SelectedValue  + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                        //                      "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@intHomePhoneNo1='" + fathno + "',@intHomePhoneNo2='" + mothno + "',@dtDOB='" + Dobnm + "',@dtActivationDate='" + insertdt + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                        //                      "@intStudentID_Number='" + StuID_Number + "',@vchplaceofBirth='" + BirthPlace + "',@intBusAlert1='" + BusAlert + "',@dtAdmission='" + dtAdm + "',@vchMothertongue='" + Mothertongue + "',@vchReligion='" + Religion + "',@vchFirstLanguage='" + FirstLang + "',@vchSecondLanguage='" + SecondLang + "'," +
                        //                      "@vchThirdLanguage='" + ThirdLang + "',@vchFatherOccupation='" + FatherOccu + "',@vchMotherOccupation='" + MotherOccu + "',@vchFatherDesignation='" + FatherDesign + "',@vchMotherDesignation='" + MotherDesign + "',@intFatherIncome='" + FatherIncome + "',@intMotherIncome='" + MotherIncome + "',@vchNationality='" + Nationality + "',@vchLandMark='" + LandMark + "',@vchPincode='" + Pincode + "'," +
                        //                      "@intCountry_id='" + CountryID + "',@intState_id='" + StateID + "',@intCity_id='" + CityID + "'," +

                        //                      "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchProfile='" + filnmn + "',@chrBloodGrp='" + Bloodgp + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intSchool_id='" + Session["School_Id"] + "',@intAcademic_id='" + AcaYr + "',@vchaadhar_no='" + Studentaadhar + "',@vchEmergencyConPerson1='" + Fatheraadhar + "',@intEmergencyContat1='" + Motheraadhar + "',@vchUser_name='" + UserName + "',@vchPassword='" + Password + "',@Receipt_no='" + ReceiptNo + "'";


                        //int str = sExecuteQuery(instrquery1);

                        //if (str > 0)
                        //{
                        //    string query = " Execute usp_PromotionDemotion  @command='UpdateStatus',@vchPromotion=Demoted,@intStudent_id='" + intStudent_id + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                        //    int result = sExecuteQuery(query);
                        //    if (result > 0)
                        //    {
                        //        MessageBox("Records Promoted Successfully");
                        //    }
                        //}


                    }
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Records Promoted Successfully');window.location ='frmPromotionDemotion.aspx';", true);
            }
        }

        catch
        {
        }
    }
    protected void ddlFromSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        FilltoSTD();
        string que2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Convert.ToString(ddlFromSTD.SelectedValue) + "' ";
        bool st2 = sBindDropDownList(ddlfromdiv, que2, "vchDivisionName", "intDivision_id");
    }
    protected void ddlToSTD_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectStudentGrid();

         string que2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Convert.ToString(ddlToSTD.SelectedValue) + "' ";
        bool st2 = sBindDropDownList(ddltodiv, que2, "vchDivisionName", "intDivision_id");
    }
    }
