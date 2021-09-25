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

public partial class frmAdmStudentProfile : DBUtility
{
    DataSet dsObj1 = new DataSet();
    DataSet dsObj = new DataSet();
    string Mandatorysub1 = "";
    string Mandatorysub2 = "";
    string Mandatorysub3 = "";
    string Mandatorysub4 = "";
    string Optionalsub1 = "";
    string Optionalsub2 = "";
    string Optionalsub3 = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            //DateTime dat= DateTime.Now;
            //date1.Text = dat.AddYears(-1).ToString();
            date1.Text = (DateTime.Now).AddYears(-2).ToShortDateString();    

            if (!IsPostBack)
            {


                checksession();
                geturl();
                getCountry();
                //     DropDownList2.SelectedValue = "0";
                string query2 = "Execute dbo.usp_Profile @command='RemarkStandard',@intSchool_id='" + Session["School_id"] + "' ";
                bool st = sBindDropDownList(DropDownList2, query2, "Standard_name", "intStandard_id");
                sBindDropDownList(ddlStandrd, query2, "Standard_name", "intStandard_id");
                
                //fGrid();
                FillCategory();
                string st3 = Request.QueryString["successMessage3"];
                if (st3 != null)
                {
                    query();
                }
                else
                {
                    TabContainer1.ActiveTabIndex = 0;
                    Update.Visible = false;

                    TabPanel1.Visible = true;
                    TabPanel1.Enabled = true;
                   
                }
            }
            if (txt7.Text != "")
            {
                ViewState["Dob"] = txt7.Text;
            }
            if (FileUpload1.HasFile)
            {
                ViewState["Filename"] = FileUpload1.PostedFile.FileName;
            }
        }
        catch
        {

        }
    }
    protected void FillCategory()
    {
        string strQry = "usp_Profile @command='selectCategory',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        bool stcardp = sBindDropDownList(txt9, strQry, "vchCategory", "intCat_Id");       
    }
    protected void getCountry()
    {
        try
        {
            string str1 = "[usp_tblCityMaster] @command='GetCountry',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(DdlCountryName, str1, "vchCountry", "intCountry_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void getState()
    {
        try
        {
            string str1 = "[usp_tblCityMaster] @command='GetState',@intCountry_id='" + DdlCountryName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(DdlStateName, str1, "vchState", "intState_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void getCity()
    {
        try
        {
            string str1 = "[usp_tblCityMaster] @command='GetCity',@intCountry_id='" + DdlCountryName.SelectedValue.Trim() + "',@intState_id='" + DdlStateName.SelectedValue.Trim() + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(DdlCityName, str1, "vchCity", "intCity_id");
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }
    protected void fGrid()
    {
       string strQry = "usp_Profile @command='selectStudents',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        txtGRNo.Text = "";
        DropDownList2.ClearSelection();       
        DropDownList3.ClearSelection();
        TextBox1.Text = "";
        txt1.Text = "";
        txt2.Text = "";
        txt3.Text = "";
        txt4.Text = "";
        txt5.Text = "";
        txt6.Text = "";
        txt7.Text = "";
       // txt9.ClearSelection();
        txt10.Text = "";
        txt11.ClearSelection();
        txt13.Text = "";
        txt14.Text = "";
        txt34.Text = "";
        txt35.Text = "";
        txt44.Text = "";
        DropDownList1.ClearSelection();
        txt45.Text = "";
        txtStudentID.Text = "";
        txtPlaceOfBirth.Text = "";
        txtSMSMobile.Text = "";
        txtAdmissionDate.Text = "";
        txtMothertounge.Text = "";
        txtReligion.Text = "";
        txtFirstLanguage.Text = "";
        txtSecondLanguage.Text = "";
        txtThirdLanguage.Text = "";
        txtstdaadhar.Text = "";
        txtmotheraadhar.Text = "";
        txtfatheraadhar.Text = "";
        txtFatherOccupation.Text = "";
        txtMotherOccupation.Text = "";
        txtFatherDesignation.Text = "";
        txtMotherDesignation.Text = "";
        txtFatherIncome.Text = "";
        txtMotherIncome.Text = "";
        txtNationality.Text = "";
        txtLandmark.Text = "";
        txtPincode.Text = "";
        //code by nikhil
        DdlCountryName.ClearSelection();
        DdlStateName.ClearSelection();
        DdlCityName.ClearSelection();
        txtGuardianName.Text = "";
        txtGuardianNumber.Text = "";
        imgViewFile.ImageUrl = "images/Sample%20Photo1.jpg";
    }
    protected void query()
    {
        string st3 = Request.QueryString["successMessage3"];
        idv1.Text = st3;
        TabContainer1.ActiveTabIndex = 0;
        string query1 = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + st3 + "',@intSchool_id='" + Session["School_id"] + "'";

        dsObj = sGetDataset(query1);
        if (dsObj.Tables[0].Rows.Count > 0)
        {

            Session["Table"] = dsObj;

            if (((DataSet)Session["Table"] != null))
            {

                foreach (DataRow dr in ((DataSet)Session["Table"]).Tables[0].Rows)
                {
                    string standcv1 = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                    DropDownList2.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);

                    string que2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + standcv1 + "' ";
                    bool st2 = sBindDropDownList(DropDownList3, que2, "vchDivisionName", "intDivision_id");
                    DropDownList3.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                    TextBox1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                    txt1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                    txt2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentMiddle_name"]);
                    txt3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentLast_name"]);
                    txt4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                    txt5.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                    txt6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmail"]);
                    txt7.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                    txt9.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCast"]);
                    txt10.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubcast"]);
                    txt11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]);
                    txt13.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intFatherMobile"]);
                    txt14.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherMobile"]);
                    string src11 = Convert.ToString(dsObj.Tables[0].Rows[0]["vchImageURL"]);
                    String savePath = "~/images/";

                    imgViewFile.ImageUrl = savePath + src11;
                    txt34.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAddress"]);
                    txt35.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchPermanent"]);
                    txt44.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["chrBloodGrp"]);
                    DropDownList1.SelectedItem.Value = Convert.ToString(dsObj.Tables[0].Rows[0]["vchHandicapedStatus"]);
                    txt45.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDescription"]);
                    
                    Update.Visible = true;
                }
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (btnSubmit.Text == "Submit")
        {

            try
            {
                if (txt1.Text == "")
                {
                    MessageBox("Please Insert First Name!");
                    txt1.Focus();
                        return;
                }
                // ButN6.Enabled = false;
                string GRNo = Convert.ToString(txtGRNo.Text);
                string StandId = DropDownList2.SelectedItem.Value;
                string DiviId = DropDownList3.SelectedItem.Value;
                string rollno = Convert.ToString(TextBox1.Text);
                string Fname = Convert.ToString(txt1.Text);
                string Mname = Convert.ToString(txt2.Text);
                string lname = Convert.ToString(txt3.Text);
                string Fathername = Convert.ToString(txt4.Text);
                string Mothername = Convert.ToString(txt5.Text);
                string Emailid = Convert.ToString(txt6.Text);
                string Dobnm = null;
                if (!String.IsNullOrEmpty(txt7.Text))

                    Dobnm = Convert.ToDateTime(txt7.Text).ToString("MM/dd/yyyy");


                string cast = Convert.ToString(txt9.SelectedValue);
                string subcast = Convert.ToString(txt10.Text);
                string gender = Convert.ToString(txt11.SelectedItem.Value);
                string filnmn = null;

                if (ViewState["Filename"] != null)
                {
                    filnmn = ViewState["Filename"].ToString();
                }


                //if (txt13.Text != "")
                //{
                string fathno = Convert.ToString(txt13.Text);
                //}
                //if (txt14.Text != "")
                //{
                string mothno = Convert.ToString(txt14.Text);
                //}

                string Preadd = Convert.ToString(txt34.Text);
                string paradd = Convert.ToString(txt35.Text);
                string Bloodgp = Convert.ToString(txt44.Text);
                string healthdis = Convert.ToString(DropDownList1.SelectedItem.Value);
                string Descip = Convert.ToString(txt45.Text);
                string insertby = Convert.ToString(Session["User_id"]);
                //long insertby = Convert.ToInt64(Session["User_id"]);
                string insertdt = DateTime.Now.ToString("MM/dd/yyyy");
                string ipval = GetSystemIP();

                string StuID_Number = Convert.ToString(txtStudentID.Text);
                string BirthPlace = Convert.ToString(txtPlaceOfBirth.Text);
                string BusAlert = Convert.ToString(txtSMSMobile.Text);
                //string dtAdm = Convert.ToString(txtAdmissionDate.Text);
                string dtAdm = null;
                if (!String.IsNullOrEmpty(txtAdmissionDate.Text))

                    dtAdm = Convert.ToDateTime(txtAdmissionDate.Text).ToString("MM/dd/yyyy");
                string Mothertongue = Convert.ToString(txtMothertounge.Text);
                string Religion = Convert.ToString(txtReligion.Text);
                string FirstLang = Convert.ToString(txtFirstLanguage.Text);
                string SecondLang = Convert.ToString(txtSecondLanguage.Text);
                string ThirdLang = Convert.ToString(txtThirdLanguage.Text);

                string Studentaadhar = Convert.ToString(txtstdaadhar.Text);
                string Fatheraadhar = Convert.ToString(txtfatheraadhar .Text);
                string Motheraadhar = Convert.ToString(txtmotheraadhar .Text);

                string FatherOccu = Convert.ToString(txtFatherOccupation.Text);
                string MotherOccu = Convert.ToString(txtMotherOccupation.Text);
                string FatherDesign = Convert.ToString(txtFatherDesignation.Text);
                string MotherDesign = Convert.ToString(txtMotherDesignation.Text);
                string FatherIncome = Convert.ToString(txtFatherIncome.Text);
                string MotherIncome = Convert.ToString(txtMotherIncome.Text);
                string Nationality = Convert.ToString(txtNationality.Text);
                string LandMark = Convert.ToString(txtLandmark.Text);
                string Pincode = Convert.ToString(txtPincode.Text);
                string CountryID = DdlCountryName.SelectedItem.Value;
                string StateID = DdlStateName.SelectedItem.Value;
                string CityID = DdlCityName.SelectedItem.Value;

                //Code By Nikhil
                string GuardianNm = Convert.ToString(txtGuardianName.Text);
                string GuardianNumber = Convert.ToString(txtGuardianNumber.Text);

                if (ddlexamstdsub.SelectedValue == "11")
                {
                    Mandatorysub1 = lbl1.Text;
                    Mandatorysub2 = Label38.Text;
                    Mandatorysub3 = Label39.Text;
                    Mandatorysub4 = Label40.Text;
                    if (RadioButton7.Checked == true)
                    {
                        Optionalsub1 = RadioButton7.Text;
                    }
                    if (RadioButton8.Checked == true)
                    {
                        Optionalsub1 = RadioButton8.Text;
                    }
                    if (RadioButton1.Checked == true)
                    {
                        Optionalsub2 = RadioButton1.Text;
                    }
                    if (RadioButton2.Checked == true)
                    {
                        Optionalsub2 = RadioButton2.Text;
                    }
                    if (RadioButton3.Checked == true)
                    {
                        Optionalsub2 = RadioButton3.Text;
                    }
                    if (RadioButton38.Checked == true)
                    {
                        Optionalsub2 = RadioButton38.Text;
                    }

                }
                if (ddlexamstdsub.SelectedValue == "12")
                {
                    Mandatorysub1 = Label41.Text;
                    Mandatorysub2 = Label42.Text;
                    Mandatorysub3 = Label43.Text;
                    Mandatorysub4 = Label44.Text;
                    if (RadioButton4.Checked == true)
                    {
                        Optionalsub1 = RadioButton4.Text;
                    }
                    if (RadioButton5.Checked == true)
                    {
                        Optionalsub1 = RadioButton5.Text;
                    }
                    if (RadioButton6.Checked == true)
                    {
                        Optionalsub2 = RadioButton6.Text;
                    }
                    if (RadioButton9.Checked == true)
                    {
                        Optionalsub2 = RadioButton9.Text;
                    }
                    if (RadioButton10.Checked == true)
                    {
                        Optionalsub2 = RadioButton10.Text;
                    }
                    if (RadioButton39.Checked == true)
                    {
                        Optionalsub2 = RadioButton39.Text;
                    }

                }
                if (ddlexamstdsub.SelectedValue == "13")
                {
                    Mandatorysub1 = Label45.Text;
                    Mandatorysub2 = Label46.Text;
                    Mandatorysub3 = Label47.Text;
                    //Mandatorysub4 = Label40.Text;
                    if (RadioButton11.Checked == true)
                    {
                        Optionalsub1 = RadioButton11.Text;
                    }
                    if (RadioButton12.Checked == true)
                    {
                        Optionalsub1 = RadioButton12.Text;
                    }
                    if (RadioButton13.Checked == true)
                    {
                        Optionalsub2 = RadioButton13.Text;
                    }
                    if (RadioButton15.Checked == true)
                    {
                        Optionalsub2 = RadioButton15.Text;
                    }
                    if (RadioButton16.Checked == true)
                    {
                        Optionalsub3 = RadioButton16.Text;
                    }
                    if (RadioButton17.Checked == true)
                    {
                        Optionalsub3 = RadioButton17.Text;
                    }
                    if (RadioButton18.Checked == true)
                    {
                        Optionalsub3 = RadioButton18.Text;
                    }
                    if (RadioButton40.Checked == true)
                    {
                        Optionalsub3 = RadioButton40.Text;
                    }

                }
                if (ddlexamstdsub.SelectedValue == "14")
                {
                    Mandatorysub1 = Label48.Text;
                    Mandatorysub2 = Label49.Text;
                    Mandatorysub3 = Label50.Text;
                    Mandatorysub4 = Label51.Text;
                    if (RadioButton14.Checked == true)
                    {
                        Optionalsub1 = RadioButton14.Text;
                    }
                    if (RadioButton22.Checked == true)
                    {
                        Optionalsub1 = RadioButton22.Text;
                    }
                    if (RadioButton19.Checked == true)
                    {
                        Optionalsub1 = RadioButton19.Text;
                    }
                    if (RadioButton23.Checked == true)
                    {
                        Optionalsub2 = RadioButton23.Text;
                    }
                    if (RadioButton24.Checked == true)
                    {
                        Optionalsub2 = RadioButton24.Text;
                    }
                    if (RadioButton25.Checked == true)
                    {
                        Optionalsub2 = RadioButton25.Text;
                    }
                    if (RadioButton41.Checked == true)
                    {
                        Optionalsub2 = RadioButton41.Text;
                    }


                }
                if (ddlexamstdsub.SelectedValue == "15")
                {
                    Mandatorysub1 = Label53.Text;
                    Mandatorysub2 = Label54.Text;
                    Mandatorysub3 = Label55.Text;
                    //Mandatorysub4 = Label40.Text; 
                    if (RadioButton28.Checked == true)
                    {
                        Optionalsub1 = RadioButton28.Text;
                    }
                    if (RadioButton29.Checked == true)
                    {
                        Optionalsub1 = RadioButton29.Text;
                    }
                    if (RadioButton30.Checked == true)
                    {
                        Optionalsub1 = RadioButton30.Text;
                    }
                    if (RadioButton20.Checked == true)
                    {
                        Optionalsub2 = RadioButton20.Text;
                    }
                    if (RadioButton21.Checked == true)
                    {
                        Optionalsub2 = RadioButton21.Text;
                    }
                    if (RadioButton26.Checked == true)
                    {
                        Optionalsub3 = RadioButton26.Text;
                    }
                    if (RadioButton27.Checked == true)
                    {
                        Optionalsub3 = RadioButton27.Text;
                    }
                    if (RadioButton42.Checked == true)
                    {
                        Optionalsub3 = RadioButton42.Text;
                    }

                }
                if (ddlexamstdsub.SelectedValue == "16")
                {
                    Mandatorysub1 = Label56.Text;
                    Mandatorysub2 = Label57.Text;
                    Mandatorysub3 = Label58.Text;
                    //Mandatorysub4 = Label40.Text;
                    if (RadioButton31.Checked == true)
                    {
                        Optionalsub1 = RadioButton31.Text;
                    }
                    if (RadioButton32.Checked == true)
                    {
                        Optionalsub1 = RadioButton32.Text;
                    }
                    if (RadioButton33.Checked == true)
                    {
                        Optionalsub1 = RadioButton33.Text;
                    }
                    if (RadioButton34.Checked == true)
                    {
                        Optionalsub2 = RadioButton34.Text;
                    }
                    if (RadioButton35.Checked == true)
                    {
                        Optionalsub2 = RadioButton35.Text;
                    }
                    if (RadioButton36.Checked == true)
                    {
                        Optionalsub3 = RadioButton36.Text;
                    }
                    if (RadioButton37.Checked == true)
                    {
                        Optionalsub3 = RadioButton37.Text;
                    }
                    if (RadioButton43.Checked == true)
                    {
                        Optionalsub3 = RadioButton43.Text;
                    }


                }

                string instrquery1 = "Execute dbo.usp_Profile @command='InsertStudentProfile',@intGRNo='" + GRNo + "',@intstanderd_id='" + StandId + "',@intDivision_id='" + DiviId + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                                      "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@intHomePhoneNo1='" + fathno + "',@intHomePhoneNo2='" + mothno + "',@dtDOB='" + Dobnm + "',@dtActivationDate='" + insertdt + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                                      "@intStudentID_Number='" + StuID_Number + "',@vchplaceofBirth='" + BirthPlace + "',@intBusAlert1='" + BusAlert + "',@dtAdmission='" + dtAdm + "',@vchMothertongue='" + Mothertongue + "',@vchReligion='" + Religion + "',@vchFirstLanguage='" + FirstLang + "',@vchSecondLanguage='" + SecondLang + "'," +
                                      "@vchThirdLanguage='" + ThirdLang + "',@vchFatherOccupation='" + FatherOccu + "',@vchMotherOccupation='" + MotherOccu + "',@vchFatherDesignation='" + FatherDesign + "',@vchMotherDesignation='" + MotherDesign + "',@intFatherIncome='" + FatherIncome + "',@intMotherIncome='" + MotherIncome + "',@vchNationality='" + Nationality + "',@vchLandMark='" + LandMark + "',@vchPincode='" + Pincode + "'," +
                                      "@intCountry_id='" + CountryID + "',@intState_id='" + StateID + "',@intCity_id='" + CityID + "'," +

                                      "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchImageURL='" + filnmn + "',@chrBloodGrp='" + Bloodgp + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@intInserted_by='" + Session["User_id"] + "',@InseretIP='" + GetSystemIP() + "',@intSchool_id='" + Session["School_Id"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@vchaadhar_no='" +Studentaadhar + "',@vchEmergencyConPerson1='" + Fatheraadhar + "',@intEmergencyContat1='" + Motheraadhar + "'," +
                                      "@vchMandatory1='" + Mandatorysub1 + "',@vchMandatory2='" + Mandatorysub2 + "',@vchMandatory3='" + Mandatorysub3 + "',@vchMandatory4='" + Mandatorysub4 + "',@vchOptional1='" + Optionalsub1 + "',@vchOptional2='" + Optionalsub2 + "',@vchOptional3='" + Optionalsub3 + "',@vchGuardianName='" + GuardianNm + "',@intGuardianNumber='" + GuardianNumber + "'";
                                      
                                      

               

                int str = sExecuteQuery(instrquery1);

                if (str != -1)
                {
                    string display = "Student Profile Submit!";
                    MessageBox(display);
                    btnSubmit.Text = "Submit";
                    //ButN6.Visible = false;
                    // Clear();
                    fGrid();

                }
                else
                {
                    MessageBox("ooopppsss!Student Profile submission Failed");

                }



                TabPanel1.Visible = true;
                TabPanel1.Enabled = true;


            }

            catch (Exception Ex)
            {
            }
        }
        else
        {
            try
            {


                string GRNo = Convert.ToString(txtGRNo.Text);
                string StandId = DropDownList2.SelectedItem.Value;
                string DiviId = DropDownList3.SelectedItem.Value;
                string rollno = Convert.ToString(TextBox1.Text);
                string Fname = Convert.ToString(txt1.Text);
                string Mname = Convert.ToString(txt2.Text);
                string lname = Convert.ToString(txt3.Text);
                string Fathername = Convert.ToString(txt4.Text);
                string Mothername = Convert.ToString(txt5.Text);
                string Emailid = Convert.ToString(txt6.Text);
                string Dobnm = null;
                if (!String.IsNullOrEmpty(txt7.Text))

                    Dobnm = Convert.ToDateTime(txt7.Text).ToString("MM/dd/yyyy");


                string cast = Convert.ToString(txt9.SelectedValue);
                string subcast = Convert.ToString(txt10.Text);
                string gender = Convert.ToString(txt11.SelectedItem.Value);
                string filnmn = null;
                if (ViewState["Filename"] != null)
                {
                    filnmn = ViewState["Filename"].ToString();
                }

                //if (txt14.Text != "")
                //{
                string mothno = Convert.ToString(txt14.Text);
                //}
                //if (txt13.Text != "")
                //{
                string fathno = Convert.ToString(txt13.Text);
                //}



                string Preadd = Convert.ToString(txt34.Text);
                string paradd = Convert.ToString(txt35.Text);

                string Bloodgp = Convert.ToString(txt44.Text);
                string healthdis = Convert.ToString(DropDownList1.SelectedItem.Value);
                string Descip = Convert.ToString(txt45.Text);
                string Updateby = Convert.ToString(Session["User_id"]);
                
                string vchUpdated_IP = GetSystemIP();
                string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

                string Studentaadhar = Convert.ToString(txtstdaadhar.Text);
                string Fatheraadhar = Convert.ToString(txtfatheraadhar.Text);
                string Motheraadhar = Convert.ToString(txtmotheraadhar.Text);
                string StuID_Number = Convert.ToString(txtStudentID.Text);
                string BirthPlace = Convert.ToString(txtPlaceOfBirth.Text);
                string BusAlert = Convert.ToString(txtSMSMobile.Text);
                //string dtAdm = Convert.ToString(txtAdmissionDate.Text);
                string dtAdm = null;
                if (!String.IsNullOrEmpty(txtAdmissionDate.Text))

                    dtAdm = Convert.ToDateTime(txtAdmissionDate.Text).ToString("MM/dd/yyyy");
                string Mothertongue = Convert.ToString(txtMothertounge.Text);
                string Religion = Convert.ToString(txtReligion.Text);
                string FirstLang = Convert.ToString(txtFirstLanguage.Text);
                string SecondLang = Convert.ToString(txtSecondLanguage.Text);
                string ThirdLang = Convert.ToString(txtThirdLanguage.Text);
                string FatherOccu = Convert.ToString(txtFatherOccupation.Text);
                string MotherOccu = Convert.ToString(txtMotherOccupation.Text);
                string FatherDesign = Convert.ToString(txtFatherDesignation.Text);
                string MotherDesign = Convert.ToString(txtMotherDesignation.Text);
                string FatherIncome = Convert.ToString(txtFatherIncome.Text);
                string MotherIncome = Convert.ToString(txtMotherIncome.Text);
                string Nationality = Convert.ToString(txtNationality.Text);
                string LandMark = Convert.ToString(txtLandmark.Text);
                string Pincode = Convert.ToString(txtPincode.Text);
                string CountryID = DdlCountryName.SelectedItem.Value;
                string StateID = DdlStateName.SelectedItem.Value;
                string CityID = DdlCityName.SelectedItem.Value;

                //Code By Nikhil
                string GuardianNm = Convert.ToString(txtGuardianName.Text);
                string GuardianNumber = Convert.ToString(txtGuardianNumber.Text);

                if (ddlexamstdsub.SelectedValue == "11")
                {
                    Mandatorysub1 = lbl1.Text;
                    Mandatorysub2 = Label38.Text;
                    Mandatorysub3 = Label39.Text;
                    Mandatorysub4 = Label40.Text;
                    if (RadioButton7.Checked == true)
                    {
                        Optionalsub1 = RadioButton7.Text;
                    }
                    if (RadioButton8.Checked == true)
                    {
                        Optionalsub1 = RadioButton8.Text;
                    }
                    if (RadioButton1.Checked == true)
                    {
                        Optionalsub2 = RadioButton1.Text;
                    }
                    if (RadioButton2.Checked == true)
                    {
                        Optionalsub2 = RadioButton2.Text;
                    }
                    if (RadioButton3.Checked == true)
                    {
                        Optionalsub2 = RadioButton3.Text;
                    }
                    if (RadioButton38.Checked == true)
                    {
                        Optionalsub2 = RadioButton38.Text;
                    }

                }
                if (ddlexamstdsub.SelectedValue == "12")
                {
                    Mandatorysub1 = Label41.Text;
                    Mandatorysub2 = Label42.Text;
                    Mandatorysub3 = Label43.Text;
                    Mandatorysub4 = Label44.Text;
                    if (RadioButton4.Checked == true)
                    {
                        Optionalsub1 = RadioButton4.Text;
                    }
                    if (RadioButton5.Checked == true)
                    {
                        Optionalsub1 = RadioButton5.Text;
                    }
                    if (RadioButton6.Checked == true)
                    {
                        Optionalsub2 = RadioButton6.Text;
                    }
                    if (RadioButton9.Checked == true)
                    {
                        Optionalsub2 = RadioButton9.Text;
                    }
                    if (RadioButton10.Checked == true)
                    {
                        Optionalsub2 = RadioButton10.Text;
                    }
                    if (RadioButton39.Checked == true)
                    {
                        Optionalsub2 = RadioButton39.Text;
                    }

                }
                if (ddlexamstdsub.SelectedValue == "13")
                {
                    Mandatorysub1 = Label45.Text;
                    Mandatorysub2 = Label46.Text;
                    Mandatorysub3 = Label47.Text;
                    //Mandatorysub4 = Label40.Text;
                    if (RadioButton11.Checked == true)
                    {
                        Optionalsub1 = RadioButton11.Text;
                    }
                    if (RadioButton12.Checked == true)
                    {
                        Optionalsub1 = RadioButton12.Text;
                    }
                    if (RadioButton13.Checked == true)
                    {
                        Optionalsub2 = RadioButton13.Text;
                    }
                    if (RadioButton15.Checked == true)
                    {
                        Optionalsub2 = RadioButton15.Text;
                    }
                    if (RadioButton16.Checked == true)
                    {
                        Optionalsub3 = RadioButton16.Text;
                    }
                    if (RadioButton17.Checked == true)
                    {
                        Optionalsub3 = RadioButton17.Text;
                    }
                    if (RadioButton18.Checked == true)
                    {
                        Optionalsub3 = RadioButton18.Text;
                    }
                    if (RadioButton40.Checked == true)
                    {
                        Optionalsub3 = RadioButton40.Text;
                    }

                }
                if (ddlexamstdsub.SelectedValue == "14")
                {
                    Mandatorysub1 = Label48.Text;
                    Mandatorysub2 = Label49.Text;
                    Mandatorysub3 = Label50.Text;
                    Mandatorysub4 = Label51.Text;
                    if (RadioButton14.Checked == true)
                    {
                        Optionalsub1 = RadioButton14.Text;
                    }
                    if (RadioButton22.Checked == true)
                    {
                        Optionalsub1 = RadioButton22.Text;
                    }
                    if (RadioButton19.Checked == true)
                    {
                        Optionalsub1 = RadioButton19.Text;
                    }
                    if (RadioButton23.Checked == true)
                    {
                        Optionalsub2 = RadioButton23.Text;
                    }
                    if (RadioButton24.Checked == true)
                    {
                        Optionalsub2 = RadioButton24.Text;
                    }
                    if (RadioButton25.Checked == true)
                    {
                        Optionalsub2 = RadioButton25.Text;
                    }
                    if (RadioButton41.Checked == true)
                    {
                        Optionalsub2 = RadioButton41.Text;
                    }


                }
                if (ddlexamstdsub.SelectedValue == "15")
                {
                    Mandatorysub1 = Label53.Text;
                    Mandatorysub2 = Label54.Text;
                    Mandatorysub3 = Label55.Text;
                    //Mandatorysub4 = Label40.Text; 
                    if (RadioButton28.Checked == true)
                    {
                        Optionalsub1 = RadioButton28.Text;
                    }
                    if (RadioButton29.Checked == true)
                    {
                        Optionalsub1 = RadioButton29.Text;
                    }
                    if (RadioButton30.Checked == true)
                    {
                        Optionalsub1 = RadioButton30.Text;
                    }
                    if (RadioButton20.Checked == true)
                    {
                        Optionalsub2 = RadioButton20.Text;
                    }
                    if (RadioButton21.Checked == true)
                    {
                        Optionalsub2 = RadioButton21.Text;
                    }
                    if (RadioButton26.Checked == true)
                    {
                        Optionalsub3 = RadioButton26.Text;
                    }
                    if (RadioButton27.Checked == true)
                    {
                        Optionalsub3 = RadioButton27.Text;
                    }
                    if (RadioButton42.Checked == true)
                    {
                        Optionalsub3 = RadioButton42.Text;
                    }

                }
                if (ddlexamstdsub.SelectedValue == "16")
                {
                    Mandatorysub1 = Label56.Text;
                    Mandatorysub2 = Label57.Text;
                    Mandatorysub3 = Label58.Text;
                    //Mandatorysub4 = Label40.Text;
                    if (RadioButton31.Checked == true)
                    {
                        Optionalsub1 = RadioButton31.Text;
                    }
                    if (RadioButton32.Checked == true)
                    {
                        Optionalsub1 = RadioButton32.Text;
                    }
                    if (RadioButton33.Checked == true)
                    {
                        Optionalsub1 = RadioButton33.Text;
                    }
                    if (RadioButton34.Checked == true)
                    {
                        Optionalsub2 = RadioButton34.Text;
                    }
                    if (RadioButton35.Checked == true)
                    {
                        Optionalsub2 = RadioButton35.Text;
                    }
                    if (RadioButton36.Checked == true)
                    {
                        Optionalsub3 = RadioButton36.Text;
                    }
                    if (RadioButton37.Checked == true)
                    {
                        Optionalsub3 = RadioButton37.Text;
                    }
                    if (RadioButton43.Checked == true)
                    {
                        Optionalsub3 = RadioButton43.Text;
                    }

                }


                string instrquery1 = "Execute dbo.usp_Profile @command='UpdateStudentProfile',@intGRNo='" + GRNo + "',@intstanderd_id='" + StandId + "',@intDivision_id='" + DiviId + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                                      "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@intHomePhoneNo1='" + fathno + "',@intHomePhoneNo2='" + mothno + "',@dtDOB='" + Dobnm + "',@dtActivationDate='" + insertdt + "',@vchUser_name='" + Fname + "',@vchPassword='" + Fname + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                                      "@intStudentID_Number='" + StuID_Number + "',@vchplaceofBirth='" + BirthPlace + "',@intBusAlert1='" + BusAlert + "',@dtAdmission='" + dtAdm + "',@vchMothertongue='" + Mothertongue + "',@vchReligion='" + Religion + "',@vchFirstLanguage='" + FirstLang + "',@vchSecondLanguage='" + SecondLang + "'," +
                                      "@vchThirdLanguage='" + ThirdLang + "',@vchFatherOccupation='" + FatherOccu + "',@vchMotherOccupation='" + MotherOccu + "',@vchFatherDesignation='" + FatherDesign + "',@vchMotherDesignation='" + MotherDesign + "',@intFatherIncome='" + FatherIncome + "',@intMotherIncome='" + MotherIncome + "',@vchNationality='" + Nationality + "',@vchLandMark='" + LandMark + "',@vchPincode='" + Pincode + "'," +
                                      "@intCountry_id='" + CountryID + "',@intState_id='" + StateID + "',@intCity_id='" + CityID + "'," +
                                      "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchImageURL='" + filnmn + "',@chrBloodGrp='" + Bloodgp + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@intUpdate_id='" + Updateby + "',@vchUpdated_IP='" + vchUpdated_IP + "',@intschool_id='" + Session["school_id"] + "',@intstudent_id='" + Session["intStudent_id"] + "',@vchaadhar_no='" + Studentaadhar + "',@vchEmergencyConPerson1='" + Fatheraadhar + "',@intEmergencyContat1='" + Motheraadhar + "'," +
                                      "@vchMandatory1='" + Mandatorysub1 + "',@vchMandatory2='" + Mandatorysub2 + "',@vchMandatory3='" + Mandatorysub3 + "',@vchMandatory4='" + Mandatorysub4 + "',@vchOptional1='" + Optionalsub1 + "',@vchOptional2='" + Optionalsub2 + "',@vchOptional3='" + Optionalsub3 + "',@vchGuardianName='" + GuardianNm + "',@intGuardianNumber='" + GuardianNumber + "'";
                                      
                                      

                int str = sExecuteQuery(instrquery1);

                if (str != -1)
                {
                    fGrid();
                    btnSubmit.Text = "Submit";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Student Profile Updated!');window.location ='frmAdmStudentProfile.aspx';", true);
                    //string display = "Student Profile Updated!";
                    //MessageBox(display);
                    // Button1.Enabled = false;
                   // Clear();
                    

                }
                else
                {
                    MessageBox("ooopppsss!Student Profile updation Failed");

                }
            }
            catch
            {


            }
        }
    }
    public void Clear()
    {
        TextBox[] textBoxArray = new TextBox[51];
        int i;
        for (i = 0; i < 52; i++)
        {

            textBoxArray[i].Text = "";

        }
    }
    public void getDivision()
    {
        try
        {
            int stat = Convert.ToInt32(DropDownList2.SelectedItem.Value);

            string query2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "' ";
            bool st2 = sBindDropDownList(DropDownList3, query2, "vchDivisionName", "intDivision_id");

        }
        catch
        {

        }
    }
    public void getCast()
    {
        try
        {
            int cast = Convert.ToInt32(txt9.SelectedItem.Value);

            string query2 = "Execute dbo.usp_Profile @command='getCast'";
            bool st2 = sBindDropDownList(DropDownList3, query2, "vchCategory", "vchCast");

        }
        catch
        {

        }
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDivision();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int statv1 = Convert.ToInt32(DropDownList2.SelectedItem.Value);

            int Div1 = Convert.ToInt32(DropDownList3.SelectedItem.Value);



        }
        catch
        {

        }
    }
    protected void checkroll(object sender, EventArgs e)
    {

        try
        {
            int stat = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            int Divi = Convert.ToInt32(DropDownList3.SelectedItem.Value);

            string query3 = "Execute dbo.usp_Profile @command='checkExiRollNo',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + stat + "',@intDivision_id='" + Divi + "',@introllno='" + TextBox1.Text + "'  ";
            string qucount = sExecuteScalar(query3);
            if (qucount == "1")
            {
                Label4.Text = "Student Record Already Exist";
                TextBox1.Text = string.Empty;
            }
            else
            {
                Label4.Text = "";
            }
        }
        catch
        {


        }
    }
    protected void Update1(object sender, EventArgs e)
    {
        try
        {


            string GRNo = Convert.ToString(txtGRNo.Text);
            string StandId = DropDownList2.SelectedItem.Value;
            string DiviId = DropDownList3.SelectedItem.Value;
            string rollno = Convert.ToString(TextBox1.Text);
            string Fname = Convert.ToString(txt1.Text);
            string Mname = Convert.ToString(txt2.Text);
            string lname = Convert.ToString(txt3.Text);
            string Fathername = Convert.ToString(txt4.Text);
            string Mothername = Convert.ToString(txt5.Text);
            string Emailid = Convert.ToString(txt6.Text);
            string Dobnm = null;
            if (!String.IsNullOrEmpty(txt7.Text))

                Dobnm = Convert.ToDateTime(txt7.Text).ToString("MM/dd/yyyy");

            
            string cast = Convert.ToString(txt9.SelectedValue);
            string subcast = Convert.ToString(txt10.Text);
            string gender = Convert.ToString(txt11.SelectedItem.Value);
            string filnmn = null;
            if (ViewState["Filename"] != null)
            {
                filnmn = ViewState["Filename"].ToString();
            }
            
            //if (txt14.Text != "")
            //{
            string mothno = Convert.ToString(txt14.Text);
            //}
            //if (txt13.Text != "")
            //{
            string fathno = Convert.ToString(txt13.Text);
            //}


          
            string Preadd = Convert.ToString(txt34.Text);
            string paradd = Convert.ToString(txt35.Text);
           
            string Bloodgp = Convert.ToString(txt44.Text);
            string healthdis = Convert.ToString(DropDownList1.SelectedItem.Value);
            string Descip = Convert.ToString(txt45.Text);
            string Updateby = Convert.ToString(Session["User_id"]);
            //long intUpdate_id = Convert.ToInt64(Session["User_id"]);
            string vchUpdated_IP = GetSystemIP();
            string insertdt = DateTime.Now.ToString("MM/dd/yyyy");

            string instrquery1 = "Execute dbo.usp_Profile @command='UpdateStudentProfile',@intGRNo='" + GRNo + "',@intstanderd_id='" + StandId + "',@intDivision_id='" + DiviId + "',@intRollNo='" + rollno + "',@vchStudentFirst_name='" + Fname + "',@vchStudentMiddle_name='" + Mname + "'," +
                                  "@vchStudentLast_name='" + lname + "',@vchFatherName='" + Fathername + "',@vchMotherName='" + Mothername + "',@vchGender='" + gender + "',@intHomePhoneNo1='" + fathno + "',@intHomePhoneNo2='" + mothno + "',@dtDOB='" + Dobnm + "',@dtActivationDate='" + insertdt + "',@vchUser_name='" + Fname + "',@vchPassword='" + Fname + "',@vchActivestatus=1,@intActivationBy='" + Session["User_id"] + "'," +
                                   "@vchCast='" + cast + "',@vchsubcast='" + subcast + "',@vchEmail='" + Emailid + "',@vchpresentAddress='" + Preadd + "',@vchpermanentAddress='" + paradd + "',@vchImageURL='" + filnmn + "',@chrBloodGrp='" + Bloodgp + "',@vchHandicapedStatus='" + healthdis + "',@vchDescription='" + Descip + "',@intUpdate_id='" + Updateby + "',@vchUpdated_IP='" + vchUpdated_IP + "',@intschool_id='" + Session["school_id"] + "',@intstudent_id='" + idv1.Text + "'";



            int str = sExecuteQuery(instrquery1);

            if (str != -1)
            {
                string display = "Student Profile Updated!";
                MessageBox(display);
                // Button1.Enabled = false;
                //Clear();


            }
            else
            {
                MessageBox("ooopppsss!Student Profile updation Failed");

            }
        }
        catch
        {


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            String savePath = "~/images/Profile/Students/";

            if (FileUpload1.HasFile)
            {

                FileUpload1.SaveAs(Server.MapPath("images/Profile/Students/") + FileUpload1.FileName);
                string file = FileUpload1.PostedFile.FileName;

                imgViewFile.ImageUrl = savePath + file;
                Button1.Text = "Change Image";

            }

        }
        catch
        {

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "No")
        {
            txt45.Enabled = false;
        }
        else
        {
            txt45.Enabled = true;
        }
    }
    protected void grvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Session["intStudent_id"] = Convert.ToString(grvDetail.DataKeys[e.NewEditIndex].Value);
           string strQry = "";
           strQry = "exec usp_Profile @command='editStudent',@intStudent_id='" + Convert.ToString(Session["intStudent_id"]) + "',@intschool_id='" + Session["school_id"] + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                txtGRNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intGRNo"]);
                DropDownList2.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intstanderd_id"]);
                getDivision();
                DropDownList3.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intDivision_id"]);
                TextBox1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);
                txt1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                txt2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentMiddle_name"]);
                txt3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentLast_name"]);
                txt4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                txt5.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                txt6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmail"]);
                txt7.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                //getCast();
                //txt9.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["vchCast"]);
                txt10.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubcast"]);
                txt11.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGender"]);
                txt13.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo1"]);
                txt14.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo2"]);
                txt34.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpresentAddress"]);
                txt35.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpermanentAddress"]);
                txt44.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["chrBloodGrp"]);
                DropDownList1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchHandicapedStatus"]);
                txt45.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDescription"]);

                txtStudentID.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["intStudentID_Number"]);
                txtPlaceOfBirth.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchplaceofBirth"]);
                txtSMSMobile.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["intBusAlert1"]);
                txtAdmissionDate.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["dtAdmission"]);
                txtMothertounge.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchMothertongue"]);
                txtReligion.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchReligion"]);
                txtFirstLanguage.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchFirstLanguage"]);
                txtSecondLanguage.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchSecondLanguage"]);
                txtThirdLanguage.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchThirdLanguage"]);

                txtstdaadhar.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchaadhar_no"]);
                txtfatheraadhar.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchEmergencyConPerson1"]);
                txtmotheraadhar.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intEmergencyContat1"]);

                txtFatherOccupation.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherOccupation"]);
                txtMotherOccupation.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherOccupation"]);
                txtFatherDesignation.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherDesignation"]);
                txtMotherDesignation.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherDesignation"]);
                txtFatherIncome.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["intFatherIncome"]);
                txtMotherIncome.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["intMotherIncome"]);
                txtNationality.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchNationality"]);
                txtLandmark.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchLandMark"]);
                txtPincode.Text= Convert.ToString(dsObj.Tables[0].Rows[0]["vchPincode"]);
                DdlCountryName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intCountry_id"]);
                getState();
                DdlStateName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intState_id"]);
                getCity();
                DdlCityName.SelectedValue = Convert.ToString(dsObj.Tables[0].Rows[0]["intCity_id"]);

                //Code By Nikhil
                txtGuardianName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGuardianName"]);
                txtGuardianNumber.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intGuardianNumber"]);

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
            Session["intStudent_id"] = Convert.ToString(grvDetail.DataKeys[e.RowIndex].Value);
           string strQry1 = "";
           strQry1 = "exec [usp_Profile] @command='deleteStudent',@intStudent_id='" + Convert.ToString(Session["intStudent_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            if (sExecuteQuery(strQry1) != -1)
            {
                fGrid();
                MessageBox("Record Deleted Successfully!");
            }
        }
        catch
        {

        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        fGrid();
        btnSubmit.Text = "Submit";
    }
    protected void ddlexamstdsub_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlexamstdsub.SelectedValue == "11")
        {
            table11sciA.Visible = true;
            table11sciB.Visible = false;
            table11sciC.Visible = false;
            table11sciD.Visible = false;
            table1comm.Visible = false;
            table1arts.Visible = false;
        
        }
        if (ddlexamstdsub.SelectedValue == "12")
        {
            table11sciB.Visible = true;
            table11sciA.Visible = false;
            table11sciC.Visible = false;
            table11sciD.Visible = false;
            table1comm.Visible = false;
            table1arts.Visible = false;

        }
        if (ddlexamstdsub.SelectedValue == "13")
        {
            table11sciC.Visible = true;
            table11sciA.Visible = false;
            table11sciB.Visible = false;
            table11sciD.Visible = false;
            table1comm.Visible = false;
            table1arts.Visible = false;

        }
        if (ddlexamstdsub.SelectedValue == "14")
        {
            table11sciD.Visible = true;
            table11sciA.Visible = false;
            table11sciB.Visible = false;
            table11sciC.Visible = false;
            table1comm.Visible = false;
            table1arts.Visible = false;

        }
        if (ddlexamstdsub.SelectedValue == "15")
        {
            table1comm.Visible = true;
            table11sciD.Visible = false;
            table11sciA.Visible = false;
            table11sciB.Visible = false;
            table11sciC.Visible = false;
            table1arts.Visible = false;

        }
        if (ddlexamstdsub.SelectedValue == "16")
        {
            table1arts.Visible = true;
            table1comm.Visible = false;
            table11sciD.Visible = false;
            table11sciA.Visible = false;
            table11sciB.Visible = false;
            table11sciC.Visible = false;

        }
    }
    protected void FireOnCheckedChanged(object sender, EventArgs e)
    {
        RadioButton rb = sender as RadioButton;
        if (rb != null)
        {
            if (rb.Checked)
            {
                RadioButton18.Enabled = false;
            }
            
        }
    }
    protected void FireOnCheckedChangedcs(object sender, EventArgs e)
    {
        RadioButton rb = sender as RadioButton;
        if (rb != null)
        {
            if (rb.Checked)
            {
                RadioButton18.Enabled = true;
            }

        }
    }
    protected void ddlStandrd_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strQry = "usp_Profile @command='selectStudents',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        string que2 = "Execute dbo.usp_Profile @command='RemarkDivision',@intSchool_id='" + Session["School_id"] + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "' ";
        bool st2 = sBindDropDownList(ddlDivision, que2, "vchDivisionName", "intDivision_id");
    }
    protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strQry = "usp_Profile @command='selectStudentsDivWise',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDivision_id='" + Convert.ToString(ddlDivision.SelectedValue) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
        else
        {
            grvDetail.DataSource = dsObj;
            grvDetail.DataBind();
        }
    }
    protected void DdlCountryName_SelectedIndexChanged(object sender, EventArgs e)
    {
        getState();
    }
    protected void DdlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        getCity();
    }
    //protected void grvDetail_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //          TextBox thisTextBox = (TextBox)sender;
    //        GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
    //        int rowindex = 0;
    //        rowindex = currentRow.RowIndex;

    //// following line will get the label value in current row

    //        Label time = (Label)currentRow.FindControl("lblstudentsid");  
      
         
    //        //string strQry1 = "";
    //        //strQry1 = "exec [usp_Profile] @command='deleteStudent',@intStudent_id='" + Convert.ToString(Session["intStudent_id"]) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
    //        //if (sExecuteQuery(strQry1) != -1)
    //        //{
    //        //    fGrid();
    //        //    MessageBox("Record Deleted Successfully!");
    //        //}
    //    }
    //    catch
    //    {

    //    }
    //}



    protected void text_changed(object sender, EventArgs e)
    {



        try
        {
            TextBox thisTextBox = (TextBox)sender;
            GridViewRow currentRow = (GridViewRow)thisTextBox.Parent.Parent;
            int rowindex = 0;
            rowindex = currentRow.RowIndex;

            // following line will get the label value in current row
            TextBox timeid = (TextBox)currentRow.FindControl("txtName");
            Label time = (Label)currentRow.FindControl("lblstudentsid");


            string strQry1 = "";
            strQry1 = "exec [usp_Profile] @command='StudentRollNoUpdate',@intStudent_id='" + Convert.ToString(time.Text) + "',@intRollNo='" + Convert.ToString(timeid.Text) + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intDelete_by='" + Session["User_Id"] + "',@DeleteIP='" + GetSystemIP() + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'";
            if (sExecuteQuery(strQry1) != -1)
            {
                //fGrid();
                //MessageBox("Record Updated Successfully!");
            }
        }
        catch
        {
        }

      
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string strQry = "usp_Profile @command='Searchstudent_id',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "',@Searchbyvalue='" + TextBox2.Text + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
            string strQry1 = "usp_Profile @command='SearchStudentnm',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "',@Searchbyvalue='" + TextBox2.Text + "'";
            dsObj1 = sGetDataset(strQry1);
            if (dsObj1.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj1;
                grvDetail.DataBind();
            }
        }
        catch
        {
            string strQry = "usp_Profile @command='SearchStudentnm',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "',@intstanderd_id='" + Convert.ToString(ddlStandrd.SelectedValue) + "',@Searchbyvalue='" + TextBox2.Text + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
            }
        }
    }
}