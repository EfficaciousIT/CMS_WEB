using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

public partial class rptResult_XI_XII_annual : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    Stream stream1;
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    DataSet dsObjgrade;
    string exam = "";
    List<byte[]> files = new List<byte[]>();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["rptAllStudentMark"] != null)
        {
            dsObjgrade = (DataSet)Session["rptAllStudentMark"];

            try
            {
                int i = 0;
                strQry = "select count(intExamSubject_id) from tblExamSubject_Master where intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "' and intactive_flg=1 and intAcademic_id='" + Convert.ToString(Session["AcademicID"]) + "'  ";
                string subcount = sExecuteReader(strQry);
                int count = Convert.ToInt32(subcount);

                if (count == 9)
                {
                if (Convert.ToString(Session["standard_id"]) == "XI Sc" || Convert.ToString(Session["standard_id"]) == "XI Com" || Convert.ToString(Session["standard_id"]) == "XI Arts")
                {
                    //string reportPath = Server.MapPath("Result_XI_XII_FirstTerm.rpt");
                    string reportPath = Server.MapPath("Result_XI_XII_New.rpt");
                    crystalReport.Load(reportPath);
                    TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text99"];
                    //TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
                    TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];
                    TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text98"];
                    TextObject mothername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text101"];
                    TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
                    TextObject birthdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text100"];
                    TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
                    TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text235"];

                    TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];
                    TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                    TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text202"];



                    TextObject SUBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text44"];
                    TextObject SUBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];
                    TextObject SUBPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text46"];
                    TextObject SUBChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text47"];
                    TextObject SUBBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text48"];
                    TextObject SUBCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
                    TextObject SUBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];
                    TextObject SUBPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text51"];
                    TextObject SUBCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text52"];
                    TextObject SUBEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text43"];
                    TextObject SUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text48"];

                    TextObject UTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text139"];
                    TextObject UTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text142"];
                    TextObject UTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text141"];
                    TextObject UTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text144"];
                    TextObject UTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text146"];
                    TextObject UTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text148"];
                    TextObject UTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text150"];
                    TextObject UTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text151"];
                    TextObject UTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text153"];
                    //TextObject UTEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text41"];
                    //TextObject UTSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];

                    TextObject UTIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];
                    TextObject UTIIHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text29"];
                    TextObject UTIIPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];
                    TextObject UTIIChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text31"];
                    TextObject UTIIBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text55"];
                    TextObject UTIICompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text56"];
                    TextObject UTIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text59"];
                    TextObject UTIIPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text61"];
                    TextObject UTIICommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];
                    //TextObject UTIIEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects[""];
                    //TextObject UTIISUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects[""];

                    TextObject TUTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text155"];
                    TextObject TUTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text157"];
                    TextObject TUTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text158"];
                    TextObject TUTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text160"];
                    TextObject TUTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text162"];
                    TextObject TUTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text164"];
                    TextObject TUTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text166"];
                    TextObject TUTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text167"];
                    TextObject TUTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text169"];


                    TextObject THYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text171"];
                    TextObject THYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text173"];
                    TextObject THYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text174"];
                    TextObject THYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text176"];
                    TextObject THYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text178"];
                    TextObject THYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text180"];
                    TextObject THYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text182"];
                    TextObject THYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text183"];
                    TextObject THYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text185"];

                    TextObject PRHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text13"];
                    TextObject PRHYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
                    TextObject PRHYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text16"];
                    TextObject PRHYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text17"];
                    TextObject PRHYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
                    TextObject PRHYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text19"];
                    TextObject PRHYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
                    TextObject PRHYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
                    TextObject PRHYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];

                    TextObject AUEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text187"];
                    TextObject AUHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text189"];
                    TextObject AUPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text190"];
                    TextObject AUChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text192"];
                    TextObject AUBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text194"];
                    TextObject AUCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text196"];
                    TextObject AUMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text198"];
                    TextObject AUPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text199"];
                    TextObject AUCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text204"];

                    TextObject PRAUEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text188"];
                    TextObject PRAUHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text11"];
                    TextObject PRAUPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text191"];
                    TextObject PRAUChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text193"];
                    TextObject PRAUBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text195"];
                    TextObject PRAUCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text197"];
                    TextObject PRAUMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text12"];
                    TextObject PRAUPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text200"];
                    TextObject PRAUCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text205"];

                    TextObject FAUEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text206"];
                    TextObject FAUHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text208"];
                    TextObject FAUPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text209"];
                    TextObject FAUChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text211"];
                    TextObject FAUBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text213"];
                    TextObject FAUCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text215"];
                    TextObject FAUMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text217"];
                    TextObject FAUPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text218"];
                    TextObject FAUCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text220"];

                    TextObject TOTALEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text222"];
                    TextObject TOTALHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text224"];
                    TextObject TOTALPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text225"];
                    TextObject TOTALChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text227"];
                    TextObject TOTALBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text229"];
                    TextObject TOTALCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text231"];
                    TextObject TOTALMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text233"];
                    TextObject TOTALPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text234"];
                    TextObject TOTALCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text238"];

                   
                    
                    
                    
                    
                    
                    //TextObject PRHYEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text39"];
                    //TextObject PRHYSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];


                      TextObject UTITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text240"];
                      TextObject UTIITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];
                      TextObject TUTTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text241"];
                      TextObject THYTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text242"];
                      TextObject AUTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text243"];
                      TextObject FAUTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text244"];
                      TextObject FTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text245"];

                    string UTEngstring = "";
                    string UTHindiBengalistring = "";
                    string UTPhysicsstring = "";
                    string UTChemistrystring = "";
                    string UTBiologystring = "";
                    string UTCompScistring = "";
                    string UTMathstring = "";
                    string UTPhysicalEdustring = "";
                    string UTCommercialArtstring = "";
                    //string UTEntrepreneurshipstring = "";
                    //string UTSUB11string = "";

                    string UTIIEngstring = "";
                    string UTIIHindiBengalistring = "";
                    string UTIIPhysicsstring = "";
                    string UTIIChemistrystring = "";
                    string UTIIBiologystring = "";
                    string UTIICompScistring = "";
                    string UTIIMathstring = "";
                    string UTIIPhysicalEdustring = "";
                    string UTIICommercialArtstring = "";

                    string TUTEngstring = "";
                    string TUTHindiBengalistring = "";
                    string TUTPhysicsstring = "";
                    string TUTChemistrystring = "";
                    string TUTBiologystring = "";
                    string TUTCompScistring = "";
                    string TUTPhysicalEdustring = "";
                    string TUTMathstring = "";
                    string TUTCommercialArtstring = "";
                    //string PRHYEntrepreneurshipstring = "";
                    //string PRHYSUB11string = "";

                    string THYEngstring = "";
                    string THYHindiBengalistring = "";
                    string THYPhysicsstring = "";
                    string THYChemistrystring = "";
                    string THYBiologystring = "";
                    string THYCompScistring = "";
                    string THYPhysicalEdustring = "";
                    string THYMathstring = "";
                    string THYCommercialArtstring = "";

                    string PRHYEngstring = "";
                    string PRHYHindiBengalistring = "";
                    string PRHYPhysicsstring = "";
                    string PRHYChemistrystring = "";
                    string PRHYBiologystring = "";
                    string PRHYCompScistring = "";
                    string PRHYPhysicalEdustring = "";
                    string PRHYMathstring = "";
                    string PRHYCommercialArtstring = "";

                    string AUEngstring = "";
                    string AUHindiBengalistring = "";
                    string AUPhysicsstring = "";
                    string AUChemistrystring = "";
                    string AUBiologystring = "";
                    string AUCompScistring = "";
                    string AUPhysicalEdustring = "";
                    string AUMathstring = "";
                    string AUCommercialArtstring = "";

                    string FAUEngstring = "";
                    string FAUHindiBengalistring = "";
                    string FAUPhysicsstring = "";
                    string FAUChemistrystring = "";
                    string FAUBiologystring = "";
                    string FAUCompScistring = "";
                    string FAUPhysicalEdustring = "";
                    string FAUMathstring = "";
                    string FAUCommercialArtstring = "";

                    string PRAUEngstring = "";
                    string PRAUHindiBengalistring = "";
                    string PRAUPhysicsstring = "";
                    string PRAUChemistrystring = "";
                    string PRAUBiologystring = "";
                    string PRAUCompScistring = "";
                    string PRAUPhysicalEdustring = "";
                    string PRAUMathstring = "";
                    string PRAUCommercialArtstring = "";

                    string TOTALEngstring = "";
                    string TOTALHindiBengalistring = "";
                    string TOTALPhysicsstring = "";
                    string TOTALChemistrystring = "";
                    string TOTALBiologystring = "";
                    string TOTALCompScistring = "";
                    string TOTALPhysicalEdustring = "";
                    string TOTALMathstring = "";
                    string TOTALCommercialArtstring = "";


                    List<byte[]> files = new List<byte[]>();

                    for (i = 0; i < dsObjgrade.Tables[0].Rows.Count; i++)
                    {

                        //strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                        //dsObj = sGetDataset(strQry);
                        //if (dsObj.Tables[0].Rows.Count > 0)
                        //{
                            // strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2018/10/29' And '2019/03/25' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                            // string attcount = sExecuteReader(strQry);
                            // PresentDay.Text = attcount;

                            //totaldays.Text = "70";
                            //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
                            //PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                        //}

                        //Code By Nikhil
                        try
                        {
                            if (Convert.ToString(Session["AcademicID"]) == "3")
                            {
                                strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2018/10/29' And '2019/03/14' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                string subcount1 = sExecuteReader(strQry);
                                PresentDay.Text = subcount1;

                                totaldays.Text = "69";
                            }
                            else if (Convert.ToString(Session["AcademicID"]) == "4")
                            {
                                strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2019/11/01' And '2020/03/14' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                string subcount1 = sExecuteReader(strQry);
                                PresentDay.Text = subcount1;
                                string query = " select  count(b.status) as TotalWorkingDays from Student_Master  a   inner join tblSchoolAttendance b   on  a.intStudent_id =b.intStudent_id where b.dtDate between '2019/11/01' And '2020/03/14'   and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                string totalworkingdays = sExecuteReader(query);
                                //Totaldays.Text = "70";
                                totaldays.Text = "75";
                            }
                        }
                        catch (Exception ex){
                            ex.Message.ToString();
                        }


                        session.Text = Convert.ToString(Session["YearName"]);
                        ExamName.Text = Convert.ToString(Session["Exam_id"]).ToUpper();
                        reportname.Text = "REPORT CARD FOR " + Convert.ToString(Session["standard_id"]).ToUpper();

                        strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + Session["standard_idnum"] + "'";
                        //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                            mothername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                            fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                            fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                            birthdate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                            rollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);

                            //class1.Text = ddlSTD.SelectedItem.ToString();
                            sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                        }

                        // @type='ResultXI'

                        strQry = "exec usp_ExamMarks @type='ResultXI_2021',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Session["standard_idnum"] + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                SUBEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            try
                            {
                                SUBCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["vchsubjectname"]);
                            }
                            catch
                            {
                            }
                            //try
                            //{
                            //    SUBEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["vchsubjectname"]);
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    SUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["vchsubjectname"]);
                            //}
                            //catch
                            //{
                            //}



                            ///////////////////////////////////////Changes done from here//////////////////////////////////////////
                            try
                            {
                                UTIIEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTII"]);
                                if (UTIIEng.Text == "NA" || UTIIEng.Text == "AB" || UTIIEng.Text == "NE")
                                {
                                    UTIIEngstring = "0";
                                }
                                else
                                {
                                    UTIIEngstring = UTIIEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTIIHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTII"]);
                                if (UTIIHindiBengali.Text == "NA" || UTIIHindiBengali.Text == "AB" || UTIIHindiBengali.Text == "NE")
                                {
                                    UTIIHindiBengalistring = "0";
                                }
                                else
                                {
                                    UTIIHindiBengalistring = UTIIHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTIIPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTII"]);
                                if (UTIIPhysics.Text == "NA" || UTIIPhysics.Text == "AB" || UTIIPhysics.Text == "NE")
                                {
                                    UTIIPhysicsstring = "0";
                                }
                                else
                                {
                                    UTIIPhysicsstring = UTIIPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTIIChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTII"]);
                                if (UTIIChemistry.Text == "NA" || UTIIChemistry.Text == "AB" || UTIIChemistry.Text == "NE")
                                {
                                    UTIIChemistrystring = "0";
                                }
                                else
                                {
                                    UTIIChemistrystring = UTIIChemistry.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTIIBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTII"]);
                                if (UTIIBiology.Text == "NA" || UTIIBiology.Text == "AB" || UTIIBiology.Text == "NE")
                                {
                                    UTIIBiologystring = "0";
                                }
                                else
                                {
                                    UTIIBiologystring = UTIIBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTIICompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTII"]);
                                if (UTIICompSci.Text == "NA" || UTIICompSci.Text == "AB" || UTIICompSci.Text == "NE")
                                {
                                    UTIICompScistring = "0";
                                }
                                else
                                {
                                    UTIICompScistring = UTIICompSci.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTIIMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTII"]);
                                if (UTIIMath.Text == "NA" || UTIIMath.Text == "AB" || UTIIMath.Text == "NE")
                                {
                                    UTIIMathstring = "0";

                                }
                                else
                                {
                                    UTIIMathstring = UTIIMath.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTIIPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTII"]);
                                if (UTIIPhysicalEdu.Text == "NA" || UTIIPhysicalEdu.Text == "AB" || UTIIPhysicalEdu.Text == "NE")
                                {
                                    UTIIPhysicalEdustring = "0";
                                }
                                else
                                {
                                    UTIIPhysicalEdustring = UTIIPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTIICommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTII"]);
                                if (UTIICommercialArt.Text == "NA" || UTIICommercialArt.Text == "AB" || UTIICommercialArt.Text == "NE")
                                {
                                    UTIICommercialArtstring = "0";
                                }
                                else
                                {
                                    UTIICommercialArtstring = UTIICommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }
                            //try
                            //{
                            //    UTIIEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTII"]);
                            //    if (UTIIEntrepreneurship.Text == "NA" || UTIIEntrepreneurship.Text == "AB")
                            //    {
                            //        UTEntrepreneurshipstring = "0";
                            //    }
                            //    else
                            //    {
                            //        UTEntrepreneurshipstring = UTIIEntrepreneurship.Text;
                            //    }
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    UTIISUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTII"]);
                            //    if (UTIISUB11.Text == "NA" || UTIISUB11.Text == "AB")
                            //    {
                            //        UTSUB11string = "0";
                            //    }
                            //    else
                            //    {
                            //        UTSUB11string = UTIISUB11.Text;
                            //    }
                            //}
                            //catch
                            //{
                            //}


                            ///////////////////////////////////
                            try
                            {
                                UTEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTI"]);
                                if (UTEng.Text == "NA" || UTEng.Text == "AB" || UTEng.Text == "NE")
                                {
                                    UTEngstring = "0";
                                }
                                else
                                {
                                    UTEngstring = UTEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTI"]);
                                if (UTHindiBengali.Text == "NA" || UTHindiBengali.Text == "AB" || UTHindiBengali.Text == "NE")
                                {
                                    UTHindiBengalistring = "0";
                                }
                                else
                                {
                                    UTHindiBengalistring = UTHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTI"]);
                                if (UTPhysics.Text == "NA" || UTPhysics.Text == "AB" || UTPhysics.Text == "NE")
                                {
                                    UTPhysicsstring = "0";
                                }
                                else
                                {
                                    UTPhysicsstring = UTPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTI"]);
                                if (UTChemistry.Text == "NA" || UTChemistry.Text == "AB" || UTChemistry.Text == "NE")
                                {
                                    UTChemistrystring = "0";
                                }
                                else
                                {
                                    UTChemistrystring = UTChemistry.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTI"]);
                                if (UTBiology.Text == "NA" || UTBiology.Text == "AB" || UTBiology.Text == "NE")
                                {
                                    UTBiologystring = "0";
                                }
                                else
                                {
                                    UTBiologystring = UTBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTI"]);
                                if (UTCompSci.Text == "NA" || UTCompSci.Text == "AB" || UTCompSci.Text == "NE")
                                {
                                    UTCompScistring = "0";
                                }
                                else
                                {
                                    UTCompScistring = UTCompSci.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTI"]);
                                if (UTMath.Text == "NA" || UTMath.Text == "AB" || UTMath.Text == "NE")
                                {
                                    UTMathstring = "0";

                                }
                                else
                                {
                                    UTMathstring = UTMath.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTI"]);
                                if (UTPhysicalEdu.Text == "NA" || UTPhysicalEdu.Text == "AB" || UTPhysicalEdu.Text == "NE")
                                {
                                    UTPhysicalEdustring = "0";
                                }
                                else
                                {
                                    UTPhysicalEdustring = UTPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                UTCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTI"]);
                                if (UTCommercialArt.Text == "NA" || UTCommercialArt.Text == "AB" || UTCommercialArt.Text == "NE")
                                {
                                    UTCommercialArtstring = "0";
                                }
                                else
                                {
                                    UTCommercialArtstring = UTCommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }
                            //try
                            //{
                            //    UTEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTI"]);
                            //    if (UTEntrepreneurship.Text == "NA" || UTEntrepreneurship.Text == "AB")
                            //    {
                            //        UTEntrepreneurshipstring = "0";
                            //    }
                            //    else
                            //    {
                            //        UTEntrepreneurshipstring = UTEntrepreneurship.Text;
                            //    }
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    UTSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTI"]);
                            //    if (UTSUB11.Text == "NA" || UTSUB11.Text == "AB")
                            //    {
                            //        UTSUB11string = "0";
                            //    }
                            //    else
                            //    {
                            //        UTSUB11string = UTSUB11.Text;
                            //    }
                            //}
                            //catch
                            //{
                            //}
///////////////////////////////////////////////////////////////////////////
                            try
                            {
                                TUTEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly"]);
                                if (TUTEng.Text == "NA" || TUTEng.Text == "AB" || TUTEng.Text == "NE")
                                {
                                    TUTEngstring = "0";
                                }
                                else
                                {
                                    TUTEngstring = TUTEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {

                                TUTHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly"]);
                                if (TUTHindiBengali.Text == "NA" || TUTHindiBengali.Text == "AB" || TUTHindiBengali.Text == "NE")
                                {
                                    TUTHindiBengalistring = "0";
                                }
                                else
                                {
                                    TUTHindiBengalistring = TUTHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TUTPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly"]);
                                if (TUTPhysics.Text == "NA" || TUTPhysics.Text == "AB" || TUTPhysics.Text == "NE")
                                {
                                    TUTPhysicsstring = "0";
                                }
                                else
                                {
                                    TUTPhysicsstring = TUTPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TUTChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly"]);
                                if (TUTChemistry.Text == "NA" || TUTChemistry.Text == "AB" || TUTChemistry.Text == "NE")
                                {
                                    TUTChemistrystring = "0";
                                }
                                else
                                {
                                    TUTChemistrystring = TUTChemistry.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TUTBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly"]);
                                if (TUTBiology.Text == "NA" || TUTBiology.Text == "AB" || TUTBiology.Text == "NE")
                                {
                                    TUTBiologystring = "0";
                                }
                                else
                                {
                                    TUTBiologystring = TUTBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TUTCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly"]);
                                if (TUTCompSci.Text == "NA" || TUTCompSci.Text == "AB" || TUTCompSci.Text == "NE")
                                {
                                    TUTCompScistring = "0";
                                }
                                else
                                {
                                    TUTCompScistring = TUTCompSci.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TUTMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly"]);
                                if (TUTMath.Text == "NA" || TUTMath.Text == "AB" || TUTMath.Text == "NE")
                                {
                                    TUTMathstring = "0";
                                }
                                else
                                {
                                    TUTMathstring = TUTMath.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TUTPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Half Yearly"]);
                                if (TUTPhysicalEdu.Text == "NA" || TUTPhysicalEdu.Text == "AB" || TUTPhysicalEdu.Text == "NE")
                                {
                                    TUTPhysicalEdustring = "0";
                                }
                                else
                                {

                                    TUTPhysicalEdustring = TUTPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TUTCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Half Yearly"]);
                                if (TUTCommercialArt.Text == "NA" || TUTCommercialArt.Text == "AB" || TUTCommercialArt.Text == "NE")
                                {
                                    TUTCommercialArtstring = "0";

                                }
                                else
                                {
                                    TUTCommercialArtstring = TUTCommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["HYPractical"]);
                                if (PRHYEng.Text == "NA" || PRHYEng.Text == "AB" || PRHYEng.Text == "NE")
                                {
                                    PRHYEngstring = "0";
                                }
                                else
                                {
                                    PRHYEngstring = PRHYEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {

                                PRHYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["HYPractical"]);
                                if (PRHYHindiBengali.Text == "NA" || PRHYHindiBengali.Text == "AB" || PRHYHindiBengali.Text == "NE")
                                {
                                    PRHYHindiBengalistring = "0";
                                }
                                else
                                {
                                    PRHYHindiBengalistring = PRHYHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["HYPractical"]);
                                if (PRHYPhysics.Text == "NA" || PRHYPhysics.Text == "AB" || PRHYPhysics.Text == "NE")
                                {
                                    PRHYPhysicsstring = "0";
                                }
                                else
                                {
                                    PRHYPhysicsstring = PRHYPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["HYPractical"]);
                                if (PRHYChemistry.Text == "NA" || PRHYChemistry.Text == "AB" || PRHYChemistry.Text == "NE")
                                {
                                    PRHYChemistrystring = "0";
                                }
                                else
                                {
                                    PRHYChemistrystring = PRHYChemistry.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["HYPractical"]);
                                if (PRHYBiology.Text == "NA" || PRHYBiology.Text == "AB" || PRHYBiology.Text == "NE")
                                {
                                    PRHYBiologystring = "0";
                                }
                                else
                                {
                                    PRHYBiologystring = PRHYBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["HYPractical"]);
                                if (PRHYCompSci.Text == "NA" || PRHYCompSci.Text == "AB" || PRHYCompSci.Text == "NE")
                                {
                                    PRHYCompScistring = "0";
                                }
                                else
                                {
                                    PRHYCompScistring = PRHYCompSci.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["HYPractical"]);
                                if (PRHYMath.Text == "NA" || PRHYMath.Text == "AB" || PRHYMath.Text == "NE")
                                {
                                    PRHYMathstring = "0";
                                }
                                else
                                {
                                    PRHYMathstring = PRHYMath.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["HYPractical"]);
                                if (PRHYPhysicalEdu.Text == "NA" || PRHYPhysicalEdu.Text == "AB" || PRHYPhysicalEdu.Text == "NE")
                                {
                                    PRHYPhysicalEdustring = "0";
                                }
                                else
                                {

                                    PRHYPhysicalEdustring = PRHYPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRHYCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["HYPractical"]);
                                if (PRHYCommercialArt.Text == "NA" || PRHYCommercialArt.Text == "AB" || PRHYCommercialArt.Text == "NE")
                                {
                                    PRHYCommercialArtstring = "0";

                                }
                                else
                                {
                                    PRHYCommercialArtstring = PRHYCommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }


                            try
                            {
                                THYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["30%_OF_HALFYEARLY"]);
                                if (THYEng.Text == "NA" || THYEng.Text == "AB" || THYEng.Text == "NE")
                                {
                                    THYEngstring = "0";
                                }
                                else
                                {
                                    THYEngstring = THYEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {

                                THYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["30%_OF_HALFYEARLY"]);
                                if (THYHindiBengali.Text == "NA" || THYHindiBengali.Text == "AB" || THYHindiBengali.Text == "NE")
                                {
                                    THYHindiBengalistring = "0";
                                }
                                else
                                {
                                    THYHindiBengalistring = THYHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                THYPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["30%_OF_HALFYEARLY"]);
                                if (THYPhysics.Text == "NA" || THYPhysics.Text == "AB" || THYPhysics.Text == "NE")
                                {
                                    THYPhysicsstring = "0";
                                }
                                else
                                {
                                    THYPhysicsstring = THYPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                THYChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["30%_OF_HALFYEARLY"]);
                                if (THYChemistry.Text == "NA" || THYChemistry.Text == "AB" || THYChemistry.Text == "NE")
                                {
                                    THYChemistrystring = "0";
                                }
                                else
                                {
                                    THYChemistrystring = THYChemistry.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                THYBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["30%_OF_HALFYEARLY"]);
                                if (THYBiology.Text == "NA" || THYBiology.Text == "AB" || THYBiology.Text == "NE")
                                {
                                    THYBiologystring = "0";
                                }
                                else
                                {
                                    THYBiologystring = THYBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                THYCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["30%_OF_HALFYEARLY"]);
                                if (THYCompSci.Text == "NA" || THYCompSci.Text == "AB" || THYCompSci.Text == "NE")
                                {
                                    THYCompScistring = "0";
                                }
                                else
                                {
                                    THYCompScistring = THYCompSci.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                THYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["30%_OF_HALFYEARLY"]);
                                if (THYMath.Text == "NA" || THYMath.Text == "AB" || THYMath.Text == "NE")
                                {
                                    THYMathstring = "0";
                                }
                                else
                                {
                                    THYMathstring = THYMath.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                THYPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["30%_OF_HALFYEARLY"]);
                                if (THYPhysicalEdu.Text == "NA" || THYPhysicalEdu.Text == "AB" || THYPhysicalEdu.Text == "NE")
                                {
                                    THYPhysicalEdustring = "0";
                                }
                                else
                                {

                                    THYPhysicalEdustring = THYPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                THYCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["30%_OF_HALFYEARLY"]);
                                if (THYCommercialArt.Text == "NA" || THYCommercialArt.Text == "AB" || THYCommercialArt.Text == "NE")
                                {
                                    THYCommercialArtstring = "0";

                                }
                                else
                                {
                                    THYCommercialArtstring = THYCommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }


                            try
                            {
                                AUEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Annual Exam"]);
                                if (AUEng.Text == "NA" || AUEng.Text == "AB" || AUEng.Text == "NE")
                                {
                                    AUEngstring = "0";
                                }
                                else
                                {
                                    AUEngstring = AUEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {

                                AUHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Annual Exam"]);
                                if (AUHindiBengali.Text == "NA" || AUHindiBengali.Text == "AB" || AUHindiBengali.Text == "NE")
                                {
                                    AUHindiBengalistring = "0";
                                }
                                else
                                {
                                    AUHindiBengalistring = AUHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                AUPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Annual Exam"]);
                                if (AUPhysics.Text == "NA" || AUPhysics.Text == "AB" || AUPhysics.Text == "NE")
                                {
                                    AUPhysicsstring = "0";
                                }
                                else
                                {
                                    AUPhysicsstring = AUPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                AUChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Exam"]);
                                if (AUChemistry.Text == "NA" || AUChemistry.Text == "AB" || AUChemistry.Text == "NE")
                                {
                                    AUChemistrystring = "0";
                                }
                                else
                                {
                                    AUChemistrystring = AUChemistry.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                AUBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Exam"]);
                                if (AUBiology.Text == "NA" || AUBiology.Text == "AB" || AUBiology.Text == "NE")
                                {
                                    AUBiologystring = "0";
                                }
                                else
                                {
                                    AUBiologystring = AUBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                AUCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Annual Exam"]);
                                if (AUCompSci.Text == "NA" || AUCompSci.Text == "AB" || AUCompSci.Text == "NE")
                                {
                                    AUCompScistring = "0";
                                }
                                else
                                {
                                    AUCompScistring = AUCompSci.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                AUMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Annual Exam"]);
                                if (AUMath.Text == "NA" || AUMath.Text == "AB" || AUMath.Text == "NE")
                                {
                                    AUMathstring = "0";
                                }
                                else
                                {
                                    AUMathstring = AUMath.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                AUPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Annual Exam"]);
                                if (AUPhysicalEdu.Text == "NA" || AUPhysicalEdu.Text == "AB" || AUPhysicalEdu.Text == "NE")
                                {
                                    AUPhysicalEdustring = "0";
                                }
                                else
                                {

                                    AUPhysicalEdustring = AUPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                AUCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Annual Exam"]);
                                if (AUCommercialArt.Text == "NA" || AUCommercialArt.Text == "AB" || AUCommercialArt.Text == "NE")
                                {
                                    AUCommercialArtstring = "0";

                                }
                                else
                                {
                                    AUCommercialArtstring = AUCommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }

                            try
                            {
                                PRAUEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Annual Practical"]);
                                if (PRAUEng.Text == "NA" || PRAUEng.Text == "AB" || PRAUEng.Text == "NE")
                                {
                                    PRAUEngstring = "0";
                                }
                                else
                                {
                                    PRAUEngstring = PRAUEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {

                                PRAUHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Annual Practical"]);
                                if (PRAUHindiBengali.Text == "NA" || PRAUHindiBengali.Text == "AB" || PRAUHindiBengali.Text == "NE")
                                {
                                    PRAUHindiBengalistring = "0";
                                }
                                else
                                {
                                    PRAUHindiBengalistring = PRAUHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRAUPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Annual Practical"]);
                                if (PRAUPhysics.Text == "NA" || PRAUPhysics.Text == "AB" || PRAUPhysics.Text == "NE")
                                {
                                    PRAUPhysicsstring = "0";
                                }
                                else
                                {
                                    PRAUPhysicsstring = PRAUPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRAUChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Practical"]);
                                if (PRAUChemistry.Text == "NA" || PRAUChemistry.Text == "AB" || PRAUChemistry.Text == "NE")
                                {
                                    PRAUChemistrystring = "0";
                                }
                                else
                                {
                                    PRAUChemistrystring = PRAUChemistry.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRAUBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Practical"]);
                                if (PRAUBiology.Text == "NA" || PRAUBiology.Text == "AB" || PRAUBiology.Text == "NE")
                                {
                                    PRAUBiologystring = "0";
                                }
                                else
                                {
                                    PRAUBiologystring = PRAUBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRAUCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Annual Practical"]);
                                if (PRAUCompSci.Text == "NA" || PRAUCompSci.Text == "AB" || PRAUCompSci.Text == "NE")
                                {
                                    PRAUCompScistring = "0";
                                }
                                else
                                {
                                    PRAUCompScistring = PRAUCompSci.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRAUMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Annual Practical"]);
                                if (PRAUMath.Text == "NA" || PRAUMath.Text == "AB" || PRAUMath.Text == "NE")
                                {
                                    PRAUMathstring = "0";
                                }
                                else
                                {
                                    PRAUMathstring = PRAUMath.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRAUPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Annual Practical"]);
                                if (PRAUPhysicalEdu.Text == "NA" || PRAUPhysicalEdu.Text == "AB" || PRAUPhysicalEdu.Text == "NE")
                                {
                                    PRAUPhysicalEdustring = "0";
                                }
                                else
                                {

                                    PRAUPhysicalEdustring = PRAUPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                PRAUCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Annual Practical"]);
                                if (PRAUCommercialArt.Text == "NA" || PRAUCommercialArt.Text == "AB" || PRAUCommercialArt.Text == "NE")
                                {
                                    PRAUCommercialArtstring = "0";

                                }
                                else
                                {
                                    PRAUCommercialArtstring = PRAUCommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }

                            try
                            {
                                FAUEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["50%_OF_ANNUAL"]);
                                if (FAUEng.Text == "NA" || FAUEng.Text == "AB" || FAUEng.Text == "NE")
                                {
                                    FAUEngstring = "0";
                                }
                                else
                                {
                                    FAUEngstring = FAUEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {

                                FAUHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["50%_OF_ANNUAL"]);
                                if (FAUHindiBengali.Text == "NA" || FAUHindiBengali.Text == "AB" || FAUHindiBengali.Text == "NE")
                                {
                                    FAUHindiBengalistring = "0";
                                }
                                else
                                {
                                    FAUHindiBengalistring = FAUHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                FAUPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["50%_OF_ANNUAL"]);
                                if (FAUPhysics.Text == "NA" || FAUPhysics.Text == "AB" || FAUPhysics.Text == "NE")
                                {
                                    FAUPhysicsstring = "0";
                                }
                                else
                                {
                                    FAUPhysicsstring = FAUPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                FAUChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["50%_OF_ANNUAL"]);
                                if (FAUChemistry.Text == "NA" || FAUChemistry.Text == "AB" || FAUChemistry.Text == "NE")
                                {
                                    FAUChemistrystring = "0";
                                }
                                else
                                {
                                    FAUChemistrystring = FAUChemistry.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                FAUBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["50%_OF_ANNUAL"]);
                                if (FAUBiology.Text == "NA" || FAUBiology.Text == "AB" || FAUBiology.Text == "NE")
                                {
                                    FAUBiologystring = "0";
                                }
                                else
                                {
                                    FAUBiologystring = FAUBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                FAUCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["50%_OF_ANNUAL"]);
                                if (FAUCompSci.Text == "NA" || FAUCompSci.Text == "AB" || FAUCompSci.Text == "NE")
                                {
                                    FAUCompScistring = "0";
                                }
                                else
                                {
                                    FAUCompScistring = FAUCompSci.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                FAUMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["50%_OF_ANNUAL"]);
                                if (FAUMath.Text == "NA" || FAUMath.Text == "AB" || FAUMath.Text == "NE")
                                {
                                    FAUMathstring = "0";
                                }
                                else
                                {
                                    FAUMathstring = FAUMath.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                FAUPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["50%_OF_ANNUAL"]);
                                if (FAUPhysicalEdu.Text == "NA" || FAUPhysicalEdu.Text == "AB" || FAUPhysicalEdu.Text == "NE")
                                {
                                   FAUPhysicalEdustring = "0";
                                }
                                else
                                {

                                    FAUPhysicalEdustring = FAUPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                FAUCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["50%_OF_ANNUAL"]);
                                if (FAUCommercialArt.Text == "NA" || FAUCommercialArt.Text == "AB" || FAUCommercialArt.Text == "NE")
                                {
                                    FAUCommercialArtstring = "0";

                                }
                                else
                                {
                                    FAUCommercialArtstring = FAUCommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }

                            try
                            {
                                TOTALEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["NEWFINAL TOTAL"]);
                                if (TOTALEng.Text == "NA" || TOTALEng.Text == "AB" || TOTALEng.Text == "NE")
                                {
                                    TOTALEngstring = "0";
                                }
                                else
                                {
                                    TOTALEngstring = TOTALEng.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {

                                TOTALHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["NEWFINAL TOTAL"]);
                                if (TOTALHindiBengali.Text == "NA" || TOTALHindiBengali.Text == "AB" || TOTALHindiBengali.Text == "NE")
                                {
                                    TOTALHindiBengalistring = "0";
                                }
                                else
                                {
                                    TOTALHindiBengalistring = TOTALHindiBengali.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TOTALPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["NEWFINAL TOTAL"]);
                                if (TOTALPhysics.Text == "NA" || TOTALPhysics.Text == "AB" || TOTALPhysics.Text == "NE")
                                {
                                    TOTALPhysicsstring = "0";
                                }
                                else
                                {
                                    TOTALPhysicsstring = TOTALPhysics.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TOTALChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["NEWFINAL TOTAL"]);
                                if (TOTALChemistry.Text == "NA" || TOTALChemistry.Text == "AB" || TOTALChemistry.Text == "NE")
                                {
                                    TOTALChemistrystring = "0";
                                }
                                else
                                {
                                    TOTALChemistrystring = TOTALChemistry.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TOTALBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["NEWFINAL TOTAL"]);
                                if (TOTALBiology.Text == "NA" || TOTALBiology.Text == "AB" || TOTALBiology.Text == "NE")
                                {
                                    TOTALBiologystring = "0";
                                }
                                else
                                {
                                    TOTALBiologystring = TOTALBiology.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TOTALCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["NEWFINAL TOTAL"]);
                                if (TOTALCompSci.Text == "NA" || TOTALCompSci.Text == "AB" || TOTALCompSci.Text == "NE")
                                {
                                    TOTALCompScistring = "0";
                                }
                                else
                                {
                                    TOTALCompScistring = TOTALCompSci.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TOTALMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["NEWFINAL TOTAL"]);
                                if (TOTALMath.Text == "NA" || TOTALMath.Text == "AB" || TOTALMath.Text == "NE")
                                {
                                    TOTALMathstring = "0";
                                }
                                else
                                {
                                    TOTALMathstring = TOTALMath.Text;

                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TOTALPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["NEWFINAL TOTAL"]);
                                if (TOTALPhysicalEdu.Text == "NA" || TOTALPhysicalEdu.Text == "AB" || TOTALPhysicalEdu.Text == "NE")
                                {
                                    TOTALPhysicalEdustring = "0";
                                }
                                else
                                {

                                    TOTALPhysicalEdustring = TOTALPhysicalEdu.Text;
                                }
                            }
                            catch
                            {
                            }
                            try
                            {
                                TOTALCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["NEWFINAL TOTAL"]);
                                if (TOTALCommercialArt.Text == "NA" || TOTALCommercialArt.Text == "AB" || TOTALCommercialArt.Text == "NE")
                                {
                                    TOTALCommercialArtstring = "0";

                                }
                                else
                                {
                                    TOTALCommercialArtstring = TOTALCommercialArt.Text;
                                }
                            }
                            catch
                            {
                            }

                            //try
                            //{
                            //    PRHYEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["20%_OF_UT"]);
                            //    if (PRHYEntrepreneurship.Text == "NA" || PRHYEntrepreneurship.Text == "AB")
                            //    {
                            //        PRHYEntrepreneurshipstring = "0";

                            //    }
                            //    else
                            //    {
                            //        PRHYEntrepreneurshipstring = PRHYEntrepreneurship.Text;
                            //    }
                            //}
                            //catch
                            //{
                            //}
                            //try
                            //{
                            //    PRHYSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["20%_OF_UT"]);
                            //    if (PRHYSUB11.Text == "NA" || PRHYSUB11.Text == "AB")
                            //    {
                            //        PRHYSUB11string = "0";

                            //    }
                            //    else
                            //    {
                            //        PRHYSUB11string = PRHYSUB11.Text;
                            //    }
                            //}
                            //catch
                            //{
                            //}
                            try
                            {
                                UTIITOT.Text=Convert.ToString(Convert.ToInt32(UTIIEngstring)+Convert.ToInt32(UTIIHindiBengalistring)+Convert.ToInt32(UTIIPhysicsstring)+Convert.ToInt32(UTIIChemistrystring)+Convert.ToInt32(UTIIBiologystring)+Convert.ToInt32(UTIICompScistring)+Convert.ToInt32(UTIIMathstring)+Convert.ToInt32(UTIIPhysicalEdustring)+Convert.ToInt32(UTIICommercialArtstring));
                                UTITOT.Text = Convert.ToString(Convert.ToInt32(UTEngstring) + Convert.ToInt32(UTHindiBengalistring) + Convert.ToInt32(UTPhysicsstring) + Convert.ToInt32(UTChemistrystring) + Convert.ToInt32(UTBiologystring) + Convert.ToInt32(UTCompScistring) + Convert.ToInt32(UTMathstring) + Convert.ToInt32(UTPhysicalEdustring) + Convert.ToInt32(UTCommercialArtstring));
                                TUTTOT.Text = Convert.ToString(Convert.ToInt32(TUTEngstring) + Convert.ToInt32(TUTHindiBengalistring) + Convert.ToInt32(TUTPhysicsstring) + Convert.ToInt32(TUTChemistrystring) + Convert.ToInt32(TUTBiologystring) + Convert.ToInt32(TUTCompScistring) + Convert.ToInt32(TUTMathstring) + Convert.ToInt32(TUTPhysicalEdustring) + Convert.ToInt32(TUTCommercialArtstring) + Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(PRHYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYMathstring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring));// + Convert.ToInt32(UTEntrepreneurshipstring) + Convert.ToInt32(UTSUB11string)) Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(PRHYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYMathstring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring) + Convert.ToInt32(PRHYEntrepreneurshipstring) + Convert.ToInt32(PRHYSUB11string));
                                THYTOT.Text = Convert.ToString(Convert.ToInt32(THYEngstring) + Convert.ToInt32(THYHindiBengalistring) + Convert.ToInt32(THYPhysicsstring) + Convert.ToInt32(THYChemistrystring) + Convert.ToInt32(THYBiologystring) + Convert.ToInt32(THYCompScistring) + Convert.ToInt32(THYMathstring) + Convert.ToInt32(THYPhysicalEdustring) + Convert.ToInt32(THYCommercialArtstring));
                                AUTOT.Text = Convert.ToString(Convert.ToInt32(AUEngstring) + Convert.ToInt32(AUHindiBengalistring) + Convert.ToInt32(AUPhysicsstring) + Convert.ToInt32(AUChemistrystring) + Convert.ToInt32(AUBiologystring) + Convert.ToInt32(AUCompScistring) + Convert.ToInt32(AUMathstring) + Convert.ToInt32(AUPhysicalEdustring) + Convert.ToInt32(AUCommercialArtstring)+Convert.ToInt32(PRAUEngstring) + Convert.ToInt32(PRAUHindiBengalistring) + Convert.ToInt32(PRAUPhysicsstring) + Convert.ToInt32(PRAUChemistrystring) + Convert.ToInt32(PRAUBiologystring) + Convert.ToInt32(PRAUCompScistring) + Convert.ToInt32(PRAUMathstring) + Convert.ToInt32(PRAUPhysicalEdustring) + Convert.ToInt32(PRAUCommercialArtstring));

                                FAUTOT.Text = Convert.ToString(Convert.ToInt32(FAUEngstring) + Convert.ToInt32(FAUHindiBengalistring) + Convert.ToInt32(FAUPhysicsstring) + Convert.ToInt32(FAUChemistrystring) + Convert.ToInt32(FAUBiologystring) + Convert.ToInt32(FAUCompScistring) + Convert.ToInt32(FAUMathstring) + Convert.ToInt32(FAUPhysicalEdustring) + Convert.ToInt32(FAUCommercialArtstring));
                                FTOT.Text = Convert.ToString(Convert.ToInt32(TOTALEngstring) + Convert.ToInt32(TOTALHindiBengalistring) + Convert.ToInt32(TOTALPhysicsstring) + Convert.ToInt32(TOTALChemistrystring) + Convert.ToInt32(TOTALBiologystring) + Convert.ToInt32(TOTALCompScistring) + Convert.ToInt32(TOTALMathstring) + Convert.ToInt32(TOTALPhysicalEdustring) + Convert.ToInt32(TOTALCommercialArtstring));
                            }
                            catch
                            {
                            }


                        }
                        crystalReport.Load(Server.MapPath(string.Format("Result_XI_XII_New.rpt", i)));
                        stream1 = crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);
                        files.Add(PrepareBytes(stream1));
                    }
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";

                    //// merge the all reports & show the reports            
                    Response.BinaryWrite(MergeReports(files).ToArray());
                    // AdmissionReport.ReportSource = crystalReport;
                    Response.End();
                }
            }
                else if(count==10)
                {
                    if (Convert.ToString(Session["standard_id"]) == "XI Sc" || Convert.ToString(Session["standard_id"]) == "XI Com" || Convert.ToString(Session["standard_id"]) == "XI Arts")
                    {
                        //string reportPath = Server.MapPath("Result_XI_XII_FirstTerm.rpt");
                        string reportPath = Server.MapPath("Result_XI_XII_ComAnnual.rpt");
                        crystalReport.Load(reportPath);
                        TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text99"];
                        //TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
                        TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];
                        TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text98"];
                        TextObject mothername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text101"];
                        TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
                        TextObject birthdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text100"];
                        TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
                        TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text235"];

                        TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];
                        TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                        TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text202"];



                        TextObject SUBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text44"];
                        TextObject SUBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];
                        TextObject SUBPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text46"];
                        TextObject SUBChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text47"];
                        TextObject SUBBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text48"];
                        TextObject SUBCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
                        TextObject SUBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];
                        TextObject SUBPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text51"];
                        TextObject SUBCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text52"];
                        TextObject SUBEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
                        //TextObject SUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text48"];

                        TextObject UTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text139"];
                        TextObject UTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text142"];
                        TextObject UTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text141"];
                        TextObject UTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text144"];
                        TextObject UTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text146"];
                        TextObject UTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text148"];
                        TextObject UTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text150"];
                        TextObject UTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text151"];
                        TextObject UTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text153"];
                        TextObject UTEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text19"];
                        //TextObject UTSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];

                        TextObject UTIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
                        TextObject UTIIHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
                        TextObject UTIIPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text76"];
                        TextObject UTIIChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];
                        TextObject UTIIBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
                        TextObject UTIICompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
                        TextObject UTIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                        TextObject UTIIPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];
                        TextObject UTIICommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text86"];
                        TextObject UTIIEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];

                        TextObject TUTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text155"];
                        TextObject TUTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text157"];
                        TextObject TUTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text158"];
                        TextObject TUTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text160"];
                        TextObject TUTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text162"];
                        TextObject TUTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text164"];
                        TextObject TUTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text166"];
                        TextObject TUTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text167"];
                        TextObject TUTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text169"];
                        TextObject TUTEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];

                        TextObject PRHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
                        TextObject PRHYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text31"];
                        TextObject PRHYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text23"];
                        TextObject PRHYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text24"];
                        TextObject PRHYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                        TextObject PRHYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];
                        TextObject PRHYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
                        TextObject PRHYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];
                        TextObject PRHYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text29"];
                        TextObject PRHYEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];


                        TextObject THYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text171"];
                        TextObject THYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text173"];
                        TextObject THYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text174"];
                        TextObject THYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text176"];
                        TextObject THYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text178"];
                        TextObject THYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text180"];
                        TextObject THYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text182"];
                        TextObject THYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text183"];
                        TextObject THYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text185"];
                        TextObject THYEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text17"];

                        TextObject AUEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text187"];
                        TextObject AUHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text189"];
                        TextObject AUPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text190"];
                        TextObject AUChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text192"];
                        TextObject AUBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text194"];
                        TextObject AUCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text196"];
                        TextObject AUMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text198"];
                        TextObject AUPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text199"];
                        TextObject AUCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text204"];
                        TextObject AUEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];

                        TextObject PRAUEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text188"];
                        TextObject PRAUHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text11"];
                        TextObject PRAUPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text191"];
                        TextObject PRAUChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text193"];
                        TextObject PRAUBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text195"];
                        TextObject PRAUCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text197"];
                        TextObject PRAUMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text12"];
                        TextObject PRAUPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text200"];
                        TextObject PRAUCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text205"];
                        TextObject PRAUEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];

                        TextObject FAUEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text206"];
                        TextObject FAUHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text208"];
                        TextObject FAUPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text209"];
                        TextObject FAUChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text211"];
                        TextObject FAUBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text213"];
                        TextObject FAUCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text215"];
                        TextObject FAUMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text217"];
                        TextObject FAUPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text218"];
                        TextObject FAUCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text220"];
                        TextObject FAUEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text56"];

                        TextObject TOTALEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text222"];
                        TextObject TOTALHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text224"];
                        TextObject TOTALPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text225"];
                        TextObject TOTALChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text227"];
                        TextObject TOTALBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text229"];
                        TextObject TOTALCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text231"];
                        TextObject TOTALMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text233"];
                        TextObject TOTALPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text234"];
                        TextObject TOTALCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text238"];
                        TextObject TOTALEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text55"];





                        //TextObject PRHYEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text39"];
                        //TextObject PRHYSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];


                        TextObject UTITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text240"];
                        TextObject UTIITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text104"];
                        TextObject TUTTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text241"];
                        TextObject THYTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text242"];
                        TextObject AUTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text243"];
                        TextObject FAUTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text244"];
                        TextObject FTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text245"];

                        string UTEngstring = "";
                        string UTHindiBengalistring = "";
                        string UTPhysicsstring = "";
                        string UTChemistrystring = "";
                        string UTBiologystring = "";
                        string UTCompScistring = "";
                        string UTMathstring = "";
                        string UTPhysicalEdustring = "";
                        string UTCommercialArtstring = "";
                        string UTEntrepreneurshipstring = "";
                        //string UTSUB11string = "";

                        string UTIIEngstring = "";
                        string UTIIHindiBengalistring = "";
                        string UTIIPhysicsstring = "";
                        string UTIIChemistrystring = "";
                        string UTIIBiologystring = "";
                        string UTIICompScistring = "";
                        string UTIIMathstring = "";
                        string UTIIPhysicalEdustring = "";
                        string UTIICommercialArtstring = "";
                        string UTIIEntrepreneurshipstring = "";

                        string TUTEngstring = "";
                        string TUTHindiBengalistring = "";
                        string TUTPhysicsstring = "";
                        string TUTChemistrystring = "";
                        string TUTBiologystring = "";
                        string TUTCompScistring = "";
                        string TUTPhysicalEdustring = "";
                        string TUTMathstring = "";
                        string TUTCommercialArtstring = "";
                        string TUTEntrepreneurshipstring = "";
                        //string PRHYEntrepreneurshipstring = "";
                        //string PRHYSUB11string = "";

                        string THYEngstring = "";
                        string THYHindiBengalistring = "";
                        string THYPhysicsstring = "";
                        string THYChemistrystring = "";
                        string THYBiologystring = "";
                        string THYCompScistring = "";
                        string THYPhysicalEdustring = "";
                        string THYMathstring = "";
                        string THYCommercialArtstring = "";
                        string THYEntrepreneurshipstring = "";

                        string PRHYEngstring = "";
                        string PRHYHindiBengalistring = "";
                        string PRHYPhysicsstring = "";
                        string PRHYChemistrystring = "";
                        string PRHYBiologystring = "";
                        string PRHYCompScistring = "";
                        string PRHYPhysicalEdustring = "";
                        string PRHYMathstring = "";
                        string PRHYCommercialArtstring = "";
                        string PRHYEntrepreneurshipstring = "";

                        string AUEngstring = "";
                        string AUHindiBengalistring = "";
                        string AUPhysicsstring = "";
                        string AUChemistrystring = "";
                        string AUBiologystring = "";
                        string AUCompScistring = "";
                        string AUPhysicalEdustring = "";
                        string AUMathstring = "";
                        string AUCommercialArtstring = "";
                        string AUEntrepreneurshipstring = "";

                        string FAUEngstring = "";
                        string FAUHindiBengalistring = "";
                        string FAUPhysicsstring = "";
                        string FAUChemistrystring = "";
                        string FAUBiologystring = "";
                        string FAUCompScistring = "";
                        string FAUPhysicalEdustring = "";
                        string FAUMathstring = "";
                        string FAUCommercialArtstring = "";
                        string FAUEntrepreneurshipstring = "";

                        string PRAUEngstring = "";
                        string PRAUHindiBengalistring = "";
                        string PRAUPhysicsstring = "";
                        string PRAUChemistrystring = "";
                        string PRAUBiologystring = "";
                        string PRAUCompScistring = "";
                        string PRAUPhysicalEdustring = "";
                        string PRAUMathstring = "";
                        string PRAUCommercialArtstring = "";
                        string PRAUEntrepreneurshipstring = "";

                        string TOTALEngstring = "";
                        string TOTALHindiBengalistring = "";
                        string TOTALPhysicsstring = "";
                        string TOTALChemistrystring = "";
                        string TOTALBiologystring = "";
                        string TOTALCompScistring = "";
                        string TOTALPhysicalEdustring = "";
                        string TOTALMathstring = "";
                        string TOTALCommercialArtstring = "";
                        string TOTALEntrepreneurshipstring = "";


                        List<byte[]> files = new List<byte[]>();

                        for (i = 0; i < dsObjgrade.Tables[0].Rows.Count; i++)
                        {

                            //strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                            //dsObj = sGetDataset(strQry);
                            //if (dsObj.Tables[0].Rows.Count > 0)
                            //{
                                //strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2018/10/29' And '2019/03/25' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                //string attcount = sExecuteReader(strQry);
                                //PresentDay.Text = attcount;

                                //totaldays.Text = "70";

                                //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
                                //PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                            //}


                            //Code By Nikhil
                                try
                                {
                                    if (Convert.ToString(Session["AcademicID"]) == "3")
                                    {
                                        strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2018/10/29' And '2019/03/14' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                        string subcount1 = sExecuteReader(strQry);
                                        PresentDay.Text = subcount1;

                                        totaldays.Text = "69";
                                    }
                                    else if (Convert.ToString(Session["AcademicID"]) == "4")
                                    {
                                        strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2019/11/01' And '2020/03/14' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                        string subcount1 = sExecuteReader(strQry);
                                        PresentDay.Text = subcount1;
                                        string query = " select  count(b.status) as TotalWorkingDays from Student_Master  a   inner join tblSchoolAttendance b   on  a.intStudent_id =b.intStudent_id where b.dtDate between '2019/11/01' And '2020/03/14'   and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                        string totalworkingdays = sExecuteReader(query);
                                        //Totaldays.Text = "70";
                                        totaldays.Text = "75";
                                    }
                                }
                                catch { }

                            session.Text = Convert.ToString(Session["YearName"]);
                            ExamName.Text = Convert.ToString(Session["Exam_id"]).ToUpper();
                            reportname.Text = "REPORT CARD FOR " + Convert.ToString(Session["standard_id"]).ToUpper();

                            strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + Session["standard_idnum"] + "'";
                            //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
                            dsObj = sGetDataset(strQry);
                            if (dsObj.Tables[0].Rows.Count > 0)
                            {
                                name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                                mothername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                                fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                                fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                                birthdate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                                rollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);

                                //class1.Text = ddlSTD.SelectedItem.ToString();
                                sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                            }


                            // @type='ResultXI'
                            strQry = "exec usp_ExamMarks  @type='ResultXI_2021',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Session["standard_idnum"] + "'";
                            dsObj = sGetDataset(strQry);
                            if (dsObj.Tables[0].Rows.Count > 0)
                            {
                                try
                                {
                                    SUBEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                               

                                try
                                {
                                    UTEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTI"]);
                                    if (UTEng.Text == "NA" || UTEng.Text == "AB" || UTEng.Text == "NE")
                                    {
                                        UTEngstring = "0";
                                    }
                                    else
                                    {
                                        UTEngstring = UTEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTI"]);
                                    if (UTHindiBengali.Text == "NA" || UTHindiBengali.Text == "AB" || UTHindiBengali.Text == "NE")
                                    {
                                        UTHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        UTHindiBengalistring = UTHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTI"]);
                                    if (UTPhysics.Text == "NA" || UTPhysics.Text == "AB" || UTPhysics.Text == "NE")
                                    {
                                        UTPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        UTPhysicsstring = UTPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTI"]);
                                    if (UTChemistry.Text == "NA" || UTChemistry.Text == "AB" || UTChemistry.Text == "NE")
                                    {
                                        UTChemistrystring = "0";
                                    }
                                    else
                                    {
                                        UTChemistrystring = UTChemistry.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTI"]);
                                    if (UTBiology.Text == "NA" || UTBiology.Text == "AB" || UTBiology.Text == "NE")
                                    {
                                        UTBiologystring = "0";
                                    }
                                    else
                                    {
                                        UTBiologystring = UTBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTI"]);
                                    if (UTCompSci.Text == "NA" || UTCompSci.Text == "AB" || UTCompSci.Text == "NE")
                                    {
                                        UTCompScistring = "0";
                                    }
                                    else
                                    {
                                        UTCompScistring = UTCompSci.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTI"]);
                                    if (UTMath.Text == "NA" || UTMath.Text == "AB" || UTMath.Text == "NE")
                                    {
                                        UTMathstring = "0";

                                    }
                                    else
                                    {
                                        UTMathstring = UTMath.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTI"]);
                                    if (UTPhysicalEdu.Text == "NA" || UTPhysicalEdu.Text == "AB" || UTPhysicalEdu.Text == "NE")
                                    {
                                        UTPhysicalEdustring = "0";
                                    }
                                    else
                                    {
                                        UTPhysicalEdustring = UTPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTI"]);
                                    if (UTCommercialArt.Text == "NA" || UTCommercialArt.Text == "AB" || UTCommercialArt.Text == "NE")
                                    {
                                        UTCommercialArtstring = "0";
                                    }
                                    else
                                    {
                                        UTCommercialArtstring = UTCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTI"]);
                                    if (UTEntrepreneurship.Text == "NA" || UTEntrepreneurship.Text == "AB" || UTEntrepreneurship.Text == "NE")
                                    {
                                        UTEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        UTEntrepreneurshipstring = UTEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                
                                //////// Changes done fro here//////
                                try
                                {
                                    UTIIEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTII"]);
                                    if (UTIIEng.Text == "NA" || UTEng.Text == "AB" || UTEng.Text == "NE")
                                    {
                                        UTIIEngstring = "0";
                                    }
                                    else
                                    {
                                        UTIIEngstring = UTIIEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTII"]);
                                    if (UTIIHindiBengali.Text == "NA" || UTIIHindiBengali.Text == "AB" || UTIIHindiBengali.Text == "NE")
                                    {
                                        UTIIHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        UTIIHindiBengalistring = UTIIHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTII"]);
                                    if (UTIIPhysics.Text == "NA" || UTIIPhysics.Text == "AB" || UTIIPhysics.Text == "NE")
                                    {
                                        UTIIPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        UTIIPhysicsstring = UTIIPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTII"]);
                                    if (UTIIChemistry.Text == "NA" || UTIIChemistry.Text == "AB" || UTIIChemistry.Text == "NE")
                                    {
                                        UTIIChemistrystring = "0";
                                    }
                                    else
                                    {
                                        UTIIChemistrystring = UTIIChemistry.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTII"]);
                                    if (UTIIBiology.Text == "NA" || UTIIBiology.Text == "AB" || UTIIBiology.Text == "NE")
                                    {
                                        UTIIBiologystring = "0";
                                    }
                                    else
                                    {
                                        UTIIBiologystring = UTIIBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIICompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTII"]);
                                    if (UTIICompSci.Text == "NA" || UTIICompSci.Text == "AB" || UTIICompSci.Text == "NE")
                                    {
                                        UTIICompScistring = "0";
                                    }
                                    else
                                    {
                                        UTIICompScistring = UTIICompSci.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTII"]);
                                    if (UTIIMath.Text == "NA" || UTIIMath.Text == "AB" || UTIIMath.Text == "NE")
                                    {
                                        UTIIMathstring = "0";

                                    }
                                    else
                                    {
                                        UTIIMathstring = UTIIMath.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTII"]);
                                    if (UTIIPhysicalEdu.Text == "NA" || UTIIPhysicalEdu.Text == "AB" || UTIIPhysicalEdu.Text == "NE")
                                    {
                                        UTIIPhysicalEdustring = "0";
                                    }
                                    else
                                    {
                                        UTIIPhysicalEdustring = UTIIPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIICommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTII"]);
                                    if (UTIICommercialArt.Text == "NA" || UTIICommercialArt.Text == "AB" || UTIICommercialArt.Text == "NE")
                                    {
                                        UTIICommercialArtstring = "0";
                                    }
                                    else
                                    {
                                        UTIICommercialArtstring = UTIICommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTII"]);
                                    if (UTIIEntrepreneurship.Text == "NA" || UTIIEntrepreneurship.Text == "AB" || UTIIEntrepreneurship.Text == "NE")
                                    {
                                        UTIIEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        UTIIEntrepreneurshipstring = UTIIEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                //////////////////////////////////////////
                                try
                                {
                                    TUTEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly"]);
                                    if (TUTEng.Text == "NA" || TUTEng.Text == "AB" || TUTEng.Text == "NE")
                                    {
                                        TUTEngstring = "0";
                                    }
                                    else
                                    {
                                        TUTEngstring = TUTEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    TUTHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly"]);
                                    if (TUTHindiBengali.Text == "NA" || TUTHindiBengali.Text == "AB" || TUTHindiBengali.Text == "NE")
                                    {
                                        TUTHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        TUTHindiBengalistring = TUTHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly"]);
                                    if (TUTPhysics.Text == "NA" || TUTPhysics.Text == "AB" || TUTPhysics.Text == "NE")
                                    {
                                        TUTPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        TUTPhysicsstring = TUTPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly"]);
                                    if (TUTChemistry.Text == "NA" || TUTChemistry.Text == "AB" || TUTChemistry.Text == "NE")
                                    {
                                        TUTChemistrystring = "0";
                                    }
                                    else
                                    {
                                        TUTChemistrystring = TUTChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly"]);
                                    if (TUTBiology.Text == "NA" || TUTBiology.Text == "AB" || TUTBiology.Text == "NE")
                                    {
                                        TUTBiologystring = "0";
                                    }
                                    else
                                    {
                                        TUTBiologystring = TUTBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly"]);
                                    if (TUTCompSci.Text == "NA" || TUTCompSci.Text == "AB" || TUTCompSci.Text == "NE")
                                    {
                                        TUTCompScistring = "0";
                                    }
                                    else
                                    {
                                        TUTCompScistring = TUTCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly"]);
                                    if (TUTMath.Text == "NA" || TUTMath.Text == "AB" || TUTMath.Text == "NE")
                                    {
                                        TUTMathstring = "0";
                                    }
                                    else
                                    {
                                        TUTMathstring = TUTMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Half Yearly"]);
                                    if (TUTPhysicalEdu.Text == "NA" || TUTPhysicalEdu.Text == "AB" || TUTPhysicalEdu.Text == "NE")
                                    {
                                        TUTPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        TUTPhysicalEdustring = TUTPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Half Yearly"]);
                                    if (TUTCommercialArt.Text == "NA" || TUTCommercialArt.Text == "AB" || TUTCommercialArt.Text == "NE")
                                    {
                                        TUTCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        TUTCommercialArtstring = TUTCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Half Yearly"]);
                                    if (TUTEntrepreneurship.Text == "NA" || TUTEntrepreneurship.Text == "AB" || TUTEntrepreneurship.Text == "NE")
                                    {
                                        TUTEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        TUTEntrepreneurshipstring = TUTEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }

                                try
                                {
                                    PRHYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["HYPractical"]);
                                    if (PRHYEng.Text == "NA" || PRHYEng.Text == "AB" || PRHYEng.Text == "NE")
                                    {
                                        PRHYEngstring = "0";
                                    }
                                    else
                                    {
                                        PRHYEngstring = PRHYEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    PRHYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["HYPractical"]);
                                    if (PRHYHindiBengali.Text == "NA" || PRHYHindiBengali.Text == "AB" || PRHYHindiBengali.Text == "NE")
                                    {
                                        PRHYHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        PRHYHindiBengalistring = PRHYHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["HYPractical"]);
                                    if (PRHYPhysics.Text == "NA" || PRHYPhysics.Text == "AB" || PRHYPhysics.Text == "NE")
                                    {
                                        PRHYPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        PRHYPhysicsstring = PRHYPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["HYPractical"]);
                                    if (PRHYChemistry.Text == "NA" || PRHYChemistry.Text == "AB" || PRHYChemistry.Text == "NE")
                                    {
                                        PRHYChemistrystring = "0";
                                    }
                                    else
                                    {
                                        PRHYChemistrystring = PRHYChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["HYPractical"]);
                                    if (PRHYBiology.Text == "NA" || PRHYBiology.Text == "AB" || PRHYBiology.Text == "NE")
                                    {
                                        PRHYBiologystring = "0";
                                    }
                                    else
                                    {
                                        PRHYBiologystring = PRHYBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["HYPractical"]);
                                    if (PRHYCompSci.Text == "NA" || PRHYCompSci.Text == "AB" || PRHYCompSci.Text == "NE")
                                    {
                                        PRHYCompScistring = "0";
                                    }
                                    else
                                    {
                                        PRHYCompScistring = PRHYCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["HYPractical"]);
                                    if (PRHYMath.Text == "NA" || PRHYMath.Text == "AB" || PRHYMath.Text == "NE")
                                    {
                                        PRHYMathstring = "0";
                                    }
                                    else
                                    {
                                        PRHYMathstring = PRHYMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["HYPractical"]);
                                    if (PRHYPhysicalEdu.Text == "NA" || PRHYPhysicalEdu.Text == "AB" || PRHYPhysicalEdu.Text == "NE")
                                    {
                                        PRHYPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        PRHYPhysicalEdustring = PRHYPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["HYPractical"]);
                                    if (PRHYCommercialArt.Text == "NA" || PRHYCommercialArt.Text == "AB" || PRHYCommercialArt.Text == "NE")
                                    {
                                        PRHYCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        PRHYCommercialArtstring = PRHYCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["HYPractical"]);
                                    if (PRHYEntrepreneurship.Text == "NA" || PRHYEntrepreneurship.Text == "AB" || PRHYEntrepreneurship.Text == "NE")
                                    {
                                        PRHYEntrepreneurshipstring = "0";

                                    }
                                    else
                                    {
                                        PRHYEntrepreneurshipstring = PRHYEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }

                                try
                                {
                                    THYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["30%_OF_HALFYEARLY"]);
                                    if (THYEng.Text == "NA" || THYEng.Text == "AB" || THYEng.Text == "NE")
                                    {
                                        THYEngstring = "0";
                                    }
                                    else
                                    {
                                        THYEngstring = THYEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    THYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["30%_OF_HALFYEARLY"]);
                                    if (THYHindiBengali.Text == "NA" || THYHindiBengali.Text == "AB" || THYHindiBengali.Text == "NE")
                                    {
                                        THYHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        THYHindiBengalistring = THYHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["30%_OF_HALFYEARLY"]);
                                    if (THYPhysics.Text == "NA" || THYPhysics.Text == "AB" || THYPhysics.Text == "NE")
                                    {
                                        THYPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        THYPhysicsstring = THYPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["30%_OF_HALFYEARLY"]);
                                    if (THYChemistry.Text == "NA" || THYChemistry.Text == "AB" || THYChemistry.Text == "NE")
                                    {
                                        THYChemistrystring = "0";
                                    }
                                    else
                                    {
                                        THYChemistrystring = THYChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["30%_OF_HALFYEARLY"]);
                                    if (THYBiology.Text == "NA" || THYBiology.Text == "AB" || THYBiology.Text == "NE")
                                    {
                                        THYBiologystring = "0";
                                    }
                                    else
                                    {
                                        THYBiologystring = THYBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["30%_OF_HALFYEARLY"]);
                                    if (THYCompSci.Text == "NA" || THYCompSci.Text == "AB" || THYCompSci.Text == "NE")
                                    {
                                        THYCompScistring = "0";
                                    }
                                    else
                                    {
                                        THYCompScistring = THYCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["30%_OF_HALFYEARLY"]);
                                    if (THYMath.Text == "NA" || THYMath.Text == "AB" || THYMath.Text == "NE")
                                    {
                                        THYMathstring = "0";
                                    }
                                    else
                                    {
                                        THYMathstring = THYMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["30%_OF_HALFYEARLY"]);
                                    if (THYPhysicalEdu.Text == "NA" || THYPhysicalEdu.Text == "AB" || THYPhysicalEdu.Text == "NE")
                                    {
                                        THYPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        THYPhysicalEdustring = THYPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["30%_OF_HALFYEARLY"]);
                                    if (THYCommercialArt.Text == "NA" || THYCommercialArt.Text == "AB" || THYCommercialArt.Text == "NE")
                                    {
                                        THYCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        THYCommercialArtstring = THYCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["30%_OF_HALFYEARLY"]);
                                    if (THYEntrepreneurship.Text == "NA" || THYEntrepreneurship.Text == "AB" || THYEntrepreneurship.Text == "NE")
                                    {
                                        THYEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        THYEntrepreneurshipstring = THYEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }

                                try
                                {
                                    AUEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Annual Exam"]);
                                    if (AUEng.Text == "NA" || AUEng.Text == "AB" || AUEng.Text == "NE")
                                    {
                                        AUEngstring = "0";
                                    }
                                    else
                                    {
                                        AUEngstring = AUEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    AUHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Annual Exam"]);
                                    if (AUHindiBengali.Text == "NA" || AUHindiBengali.Text == "AB" || AUHindiBengali.Text == "NE")
                                    {
                                        AUHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        AUHindiBengalistring = AUHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Annual Exam"]);
                                    if (AUPhysics.Text == "NA" || AUPhysics.Text == "AB" || AUPhysics.Text == "NE")
                                    {
                                        AUPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        AUPhysicsstring = AUPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Exam"]);
                                    if (AUChemistry.Text == "NA" || AUChemistry.Text == "AB" || AUChemistry.Text == "NE")
                                    {
                                        AUChemistrystring = "0";
                                    }
                                    else
                                    {
                                        AUChemistrystring = AUChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Exam"]);
                                    if (AUBiology.Text == "NA" || AUBiology.Text == "AB" || AUBiology.Text == "NE")
                                    {
                                        AUBiologystring = "0";
                                    }
                                    else
                                    {
                                        AUBiologystring = AUBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Annual Exam"]);
                                    if (AUCompSci.Text == "NA" || AUCompSci.Text == "AB" || AUCompSci.Text == "NE")
                                    {
                                        AUCompScistring = "0";
                                    }
                                    else
                                    {
                                        AUCompScistring = AUCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Annual Exam"]);
                                    if (AUMath.Text == "NA" || AUMath.Text == "AB" || AUMath.Text == "NE")
                                    {
                                        AUMathstring = "0";
                                    }
                                    else
                                    {
                                        AUMathstring = AUMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Annual Exam"]);
                                    if (AUPhysicalEdu.Text == "NA" || AUPhysicalEdu.Text == "AB" || AUPhysicalEdu.Text == "NE")
                                    {
                                        AUPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        AUPhysicalEdustring = AUPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Annual Exam"]);
                                    if (AUCommercialArt.Text == "NA" || AUCommercialArt.Text == "AB" || AUCommercialArt.Text == "NE")
                                    {
                                        AUCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        AUCommercialArtstring = AUCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Annual Exam"]);
                                    if (AUEntrepreneurship.Text == "NA" || AUEntrepreneurship.Text == "AB" || AUEntrepreneurship.Text == "NE")
                                    {
                                        AUEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        AUEntrepreneurshipstring = AUEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }

                                try
                                {
                                    PRAUEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Annual Practical"]);
                                    if (PRAUEng.Text == "NA" || PRAUEng.Text == "AB" || PRAUEng.Text == "NE")
                                    {
                                        PRAUEngstring = "0";
                                    }
                                    else
                                    {
                                        PRAUEngstring = PRAUEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    PRAUHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Annual Practical"]);
                                    if (PRAUHindiBengali.Text == "NA" || PRAUHindiBengali.Text == "AB" || PRAUHindiBengali.Text == "NE")
                                    {
                                        PRAUHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        PRAUHindiBengalistring = PRAUHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Annual Practical"]);
                                    if (PRAUPhysics.Text == "NA" || PRAUPhysics.Text == "AB" || PRAUPhysics.Text == "NE")
                                    {
                                        PRAUPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        PRAUPhysicsstring = PRAUPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Practical"]);
                                    if (PRAUChemistry.Text == "NA" || PRAUChemistry.Text == "AB" || PRAUChemistry.Text == "NE")
                                    {
                                        PRAUChemistrystring = "0";
                                    }
                                    else
                                    {
                                        PRAUChemistrystring = PRAUChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Practical"]);
                                    if (PRAUBiology.Text == "NA" || PRAUBiology.Text == "AB" || PRAUBiology.Text == "NE")
                                    {
                                        PRAUBiologystring = "0";
                                    }
                                    else
                                    {
                                        PRAUBiologystring = PRAUBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Annual Practical"]);
                                    if (PRAUCompSci.Text == "NA" || PRAUCompSci.Text == "AB" || PRAUCompSci.Text == "NE")
                                    {
                                        PRAUCompScistring = "0";
                                    }
                                    else
                                    {
                                        PRAUCompScistring = PRAUCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Annual Practical"]);
                                    if (PRAUMath.Text == "NA" || PRAUMath.Text == "AB" || PRAUMath.Text == "NE")
                                    {
                                        PRAUMathstring = "0";
                                    }
                                    else
                                    {
                                        PRAUMathstring = PRAUMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Annual Practical"]);
                                    if (PRAUPhysicalEdu.Text == "NA" || PRAUPhysicalEdu.Text == "AB" || PRAUPhysicalEdu.Text == "NE")
                                    {
                                        PRAUPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        PRAUPhysicalEdustring = PRAUPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Annual Practical"]);
                                    if (PRAUCommercialArt.Text == "NA" || PRAUCommercialArt.Text == "AB" || PRAUCommercialArt.Text == "NE")
                                    {
                                        PRAUCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        PRAUCommercialArtstring = PRAUCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Annual Practical"]);
                                    if (PRAUEntrepreneurship.Text == "NA" || PRAUEntrepreneurship.Text == "AB" || PRAUEntrepreneurship.Text == "NE")
                                    {
                                        PRAUEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        PRAUEntrepreneurshipstring = PRAUEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }


                                try
                                {
                                    FAUEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["50%_OF_ANNUAL"]);
                                    if (FAUEng.Text == "NA" || FAUEng.Text == "AB" || FAUEng.Text == "NE")
                                    {
                                        FAUEngstring = "0";
                                    }
                                    else
                                    {
                                        FAUEngstring = FAUEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    FAUHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["50%_OF_ANNUAL"]);
                                    if (FAUHindiBengali.Text == "NA" || FAUHindiBengali.Text == "AB" || FAUHindiBengali.Text == "NE")
                                    {
                                        FAUHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        FAUHindiBengalistring = FAUHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["50%_OF_ANNUAL"]);
                                    if (FAUPhysics.Text == "NA" || FAUPhysics.Text == "AB" || FAUPhysics.Text == "NE")
                                    {
                                        FAUPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        FAUPhysicsstring = FAUPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["50%_OF_ANNUAL"]);
                                    if (FAUChemistry.Text == "NA" || FAUChemistry.Text == "AB" || FAUChemistry.Text == "NE")
                                    {
                                        FAUChemistrystring = "0";
                                    }
                                    else
                                    {
                                        FAUChemistrystring = FAUChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["50%_OF_ANNUAL"]);
                                    if (FAUBiology.Text == "NA" || FAUBiology.Text == "AB" || FAUBiology.Text == "NE")
                                    {
                                        FAUBiologystring = "0";
                                    }
                                    else
                                    {
                                        FAUBiologystring = FAUBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["50%_OF_ANNUAL"]);
                                    if (FAUCompSci.Text == "NA" || FAUCompSci.Text == "AB" || FAUCompSci.Text == "NE")
                                    {
                                        FAUCompScistring = "0";
                                    }
                                    else
                                    {
                                        FAUCompScistring = FAUCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["50%_OF_ANNUAL"]);
                                    if (FAUMath.Text == "NA" || FAUMath.Text == "AB" || FAUMath.Text == "NE")
                                    {
                                        FAUMathstring = "0";
                                    }
                                    else
                                    {
                                        FAUMathstring = FAUMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["50%_OF_ANNUAL"]);
                                    if (FAUPhysicalEdu.Text == "NA" || FAUPhysicalEdu.Text == "AB" || FAUPhysicalEdu.Text == "NE")
                                    {
                                        FAUPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        FAUPhysicalEdustring = FAUPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["50%_OF_ANNUAL"]);
                                    if (FAUCommercialArt.Text == "NA" || FAUCommercialArt.Text == "AB" || FAUCommercialArt.Text == "NE")
                                    {
                                        FAUCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        FAUCommercialArtstring = FAUCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["50%_OF_ANNUAL"]);
                                    if (FAUEntrepreneurship.Text == "NA" || FAUEntrepreneurship.Text == "AB" || FAUEntrepreneurship.Text == "NE")
                                    {
                                        FAUEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        FAUEntrepreneurshipstring = FAUEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }


                                try
                                {
                                    TOTALEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["NEWFINAL TOTAL"]);
                                    if (TOTALEng.Text == "NA" || TOTALEng.Text == "AB" || TOTALEng.Text == "NE")
                                    {
                                        TOTALEngstring = "0";
                                    }
                                    else
                                    {
                                        TOTALEngstring = TOTALEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    TOTALHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["NEWFINAL TOTAL"]);
                                    if (TOTALHindiBengali.Text == "NA" || TOTALHindiBengali.Text == "AB" || TOTALHindiBengali.Text == "NE")
                                    {
                                        TOTALHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        TOTALHindiBengalistring = TOTALHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["NEWFINAL TOTAL"]);
                                    if (TOTALPhysics.Text == "NA" || TOTALPhysics.Text == "AB" || TOTALPhysics.Text == "NE")
                                    {
                                        TOTALPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        TOTALPhysicsstring = TOTALPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["NEWFINAL TOTAL"]);
                                    if (TOTALChemistry.Text == "NA" || TOTALChemistry.Text == "AB" || TOTALChemistry.Text == "NE")
                                    {
                                        TOTALChemistrystring = "0";
                                    }
                                    else
                                    {
                                        TOTALChemistrystring = TOTALChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["NEWFINAL TOTAL"]);
                                    if (TOTALBiology.Text == "NA" || TOTALBiology.Text == "AB" || TOTALBiology.Text == "NE")
                                    {
                                        TOTALBiologystring = "0";
                                    }
                                    else
                                    {
                                        TOTALBiologystring = TOTALBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["NEWFINAL TOTAL"]);
                                    if (TOTALCompSci.Text == "NA" || TOTALCompSci.Text == "AB" || TOTALCompSci.Text == "NE")
                                    {
                                        TOTALCompScistring = "0";
                                    }
                                    else
                                    {
                                        TOTALCompScistring = TOTALCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["NEWFINAL TOTAL"]);
                                    if (TOTALMath.Text == "NA" || TOTALMath.Text == "AB" || TOTALMath.Text == "NE")
                                    {
                                        TOTALMathstring = "0";
                                    }
                                    else
                                    {
                                        TOTALMathstring = TOTALMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["NEWFINAL TOTAL"]);
                                    if (TOTALPhysicalEdu.Text == "NA" || TOTALPhysicalEdu.Text == "AB" || TOTALPhysicalEdu.Text == "NE")
                                    {
                                        TOTALPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        TOTALPhysicalEdustring = TOTALPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["NEWFINAL TOTAL"]);
                                    if (TOTALCommercialArt.Text == "NA" || TOTALCommercialArt.Text == "AB" || TOTALCommercialArt.Text == "NE")
                                    {
                                        TOTALCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        TOTALCommercialArtstring = TOTALCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["NEWFINAL TOTAL"]);
                                    if (TOTALEntrepreneurship.Text == "NA" || TOTALEntrepreneurship.Text == "AB" || TOTALEntrepreneurship.Text == "NE")
                                    {
                                        TOTALEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        TOTALEntrepreneurshipstring = TOTALEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }

                                //try
                                //{
                                //    PRHYEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["20%_OF_UT"]);
                                //    if (PRHYEntrepreneurship.Text == "NA" || PRHYEntrepreneurship.Text == "AB")
                                //    {
                                //        PRHYEntrepreneurshipstring = "0";

                                //    }
                                //    else
                                //    {
                                //        PRHYEntrepreneurshipstring = PRHYEntrepreneurship.Text;
                                //    }
                                //}
                                //catch
                                //{
                                //}
                                //try
                                //{
                                //    PRHYSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["20%_OF_UT"]);
                                //    if (PRHYSUB11.Text == "NA" || PRHYSUB11.Text == "AB")
                                //    {
                                //        PRHYSUB11string = "0";

                                //    }
                                //    else
                                //    {
                                //        PRHYSUB11string = PRHYSUB11.Text;
                                //    }
                                //}
                                //catch
                                //{
                                //}
                                try
                                 {
                                    UTIITOT.Text = Convert.ToString(Convert.ToInt32(UTIIEngstring) + Convert.ToInt32(UTIIHindiBengalistring) + Convert.ToInt32(UTIIPhysicsstring) + Convert.ToInt32(UTIIChemistrystring) + Convert.ToInt32(UTIIBiologystring) + Convert.ToInt32(UTIICompScistring) + Convert.ToInt32(UTIIMathstring) + Convert.ToInt32(UTIIPhysicalEdustring) + Convert.ToInt32(UTIICommercialArtstring) + Convert.ToInt32(UTIIEntrepreneurshipstring));
                                    UTITOT.Text = Convert.ToString(Convert.ToInt32(UTEngstring) + Convert.ToInt32(UTHindiBengalistring) + Convert.ToInt32(UTPhysicsstring) + Convert.ToInt32(UTChemistrystring) + Convert.ToInt32(UTBiologystring) + Convert.ToInt32(UTCompScistring) + Convert.ToInt32(UTMathstring) + Convert.ToInt32(UTPhysicalEdustring) + Convert.ToInt32(UTCommercialArtstring) + Convert.ToInt32(UTEntrepreneurshipstring));
                                    TUTTOT.Text = Convert.ToString(Convert.ToInt32(TUTEngstring) + Convert.ToInt32(TUTHindiBengalistring) + Convert.ToInt32(TUTPhysicsstring) + Convert.ToInt32(TUTChemistrystring) + Convert.ToInt32(TUTBiologystring) + Convert.ToInt32(TUTCompScistring) + Convert.ToInt32(TUTMathstring) + Convert.ToInt32(TUTPhysicalEdustring) + Convert.ToInt32(TUTCommercialArtstring) + Convert.ToInt32(TUTEntrepreneurshipstring) + Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(PRHYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYMathstring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring) + Convert.ToInt32(PRHYEntrepreneurshipstring));// + Convert.ToInt32(UTEntrepreneurshipstring) + Convert.ToInt32(UTSUB11string)) Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(PRHYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYMathstring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring) + Convert.ToInt32(PRHYEntrepreneurshipstring) + Convert.ToInt32(PRHYSUB11string));
                                    THYTOT.Text = Convert.ToString(Convert.ToInt32(THYEngstring) + Convert.ToInt32(THYHindiBengalistring) + Convert.ToInt32(THYPhysicsstring) + Convert.ToInt32(THYChemistrystring) + Convert.ToInt32(THYBiologystring) + Convert.ToInt32(THYCompScistring) + Convert.ToInt32(THYMathstring) + Convert.ToInt32(THYPhysicalEdustring) + Convert.ToInt32(THYCommercialArtstring) + Convert.ToInt32(THYEntrepreneurshipstring));
                                    AUTOT.Text = Convert.ToString(Convert.ToInt32(AUEngstring) + Convert.ToInt32(AUHindiBengalistring) + Convert.ToInt32(AUPhysicsstring) + Convert.ToInt32(AUChemistrystring) + Convert.ToInt32(AUBiologystring) + Convert.ToInt32(AUCompScistring) + Convert.ToInt32(AUMathstring) + Convert.ToInt32(AUPhysicalEdustring) + Convert.ToInt32(AUCommercialArtstring) + Convert.ToInt32(AUEntrepreneurshipstring) + Convert.ToInt32(PRAUEngstring) + Convert.ToInt32(PRAUHindiBengalistring) + Convert.ToInt32(PRAUPhysicsstring) + Convert.ToInt32(PRAUChemistrystring) + Convert.ToInt32(PRAUBiologystring) + Convert.ToInt32(PRAUCompScistring) + Convert.ToInt32(PRAUMathstring) + Convert.ToInt32(PRAUPhysicalEdustring) + Convert.ToInt32(PRAUCommercialArtstring) + Convert.ToInt32(PRAUEntrepreneurshipstring));

                                    FAUTOT.Text = Convert.ToString(Convert.ToInt32(FAUEngstring) + Convert.ToInt32(FAUHindiBengalistring) + Convert.ToInt32(FAUPhysicsstring) + Convert.ToInt32(FAUChemistrystring) + Convert.ToInt32(FAUBiologystring) + Convert.ToInt32(FAUCompScistring) + Convert.ToInt32(FAUMathstring) + Convert.ToInt32(FAUPhysicalEdustring) + Convert.ToInt32(FAUCommercialArtstring) + Convert.ToInt32(FAUEntrepreneurshipstring));
                                    FTOT.Text = Convert.ToString(Convert.ToInt32(TOTALEngstring) + Convert.ToInt32(TOTALHindiBengalistring) + Convert.ToInt32(TOTALPhysicsstring) + Convert.ToInt32(TOTALChemistrystring) + Convert.ToInt32(TOTALBiologystring) + Convert.ToInt32(TOTALCompScistring) + Convert.ToInt32(TOTALMathstring) + Convert.ToInt32(TOTALPhysicalEdustring) + Convert.ToInt32(TOTALCommercialArtstring) + Convert.ToInt32(TOTALEntrepreneurshipstring));
                                }
                                catch
                                {
                                }


                            }
                            crystalReport.Load(Server.MapPath(string.Format("Result_XI_XII_ComAnnual.rpt", i)));
                            stream1 = crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);
                            files.Add(PrepareBytes(stream1));
                        }
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/pdf";

                        //// merge the all reports & show the reports            
                        Response.BinaryWrite(MergeReports(files).ToArray());
                        // AdmissionReport.ReportSource = crystalReport;
                        Response.End();
                    }
                
                }

                else if(count==11)
                {
                    if (Convert.ToString(Session["standard_id"]) == "XI Sc" || Convert.ToString(Session["standard_id"]) == "XI Com" || Convert.ToString(Session["standard_id"]) == "XI Arts")
                    {
                        //string reportPath = Server.MapPath("Result_XI_XII_FirstTerm.rpt");
                        string reportPath = Server.MapPath("Result_XI_XII_ArtsAnnual.rpt");
                        crystalReport.Load(reportPath);
                        TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text99"];
                        //TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
                        TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];
                        TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text98"];
                        TextObject mothername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text101"];
                        TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
                        TextObject birthdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text100"];
                        TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
                        TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text235"];

                        TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];
                        TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                        TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text202"];



                        TextObject SUBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text44"];
                        TextObject SUBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];
                        TextObject SUBPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text46"];
                        TextObject SUBChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text47"];
                        TextObject SUBBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text48"];
                        TextObject SUBCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
                        TextObject SUBMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];
                        TextObject SUBPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text51"];
                        TextObject SUBCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text52"];
                        TextObject SUBEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text15"];
                        TextObject SUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];

                        TextObject UTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text139"];
                        TextObject UTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text142"];
                        TextObject UTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text141"];
                        TextObject UTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text144"];
                        TextObject UTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text146"];
                        TextObject UTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text148"];
                        TextObject UTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text150"];
                        TextObject UTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text151"];
                        TextObject UTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text153"];
                        TextObject UTEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text19"];
                        TextObject UTSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];

                        //TextObject UTIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
                        //TextObject UTIIHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];
                        //TextObject UTIIPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];
                        //TextObject UTIIChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text138"];
                        //TextObject UTIIBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text140"];
                        //TextObject UTIICompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text143"];
                        //TextObject UTIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text145"];
                        //TextObject UTIIPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text147"];
                        //TextObject UTIICommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text149"];
                        //TextObject UTIIEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text152"];
                        //TextObject UTIISUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text154"];

                        TextObject TUTEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text155"];
                        TextObject TUTHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text157"];
                        TextObject TUTPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text158"];
                        TextObject TUTChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text160"];
                        TextObject TUTBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text162"];
                        TextObject TUTCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text164"];
                        TextObject TUTMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text166"];
                        TextObject TUTPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text167"];
                        TextObject TUTCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text169"];
                        TextObject TUTEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
                        TextObject TUTSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text29"];


                        TextObject THYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text171"];
                        TextObject THYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text173"];
                        TextObject THYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text174"];
                        TextObject THYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text176"];
                        TextObject THYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text178"];
                        TextObject THYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text180"];
                        TextObject THYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text182"];
                        TextObject THYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text183"];
                        TextObject THYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text185"];
                        TextObject THYEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text17"];
                        TextObject THYSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];

                        TextObject PRHYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];
                        TextObject PRHYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text64"];
                        TextObject PRHYPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text65"];
                        TextObject PRHYChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
                        TextObject PRHYBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
                        TextObject PRHYCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text76"];
                        TextObject PRHYMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];
                        TextObject PRHYPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
                        TextObject PRHYCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
                        TextObject PRHYEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                        TextObject PRHYSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];


                        TextObject UTIIEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
                        TextObject UTIIHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];
                        TextObject UTIIPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];
                        TextObject UTIIChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text138"];
                        TextObject UTIIBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text140"];
                        TextObject UTIICompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text143"];
                        TextObject UTIIMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text145"];
                        TextObject UTIIPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text147"];
                        TextObject UTIICommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text149"];
                        TextObject UTIIEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text152"];
                        TextObject UTIISUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text154"];

                        TextObject AUEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text187"];
                        TextObject AUHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text189"];
                        TextObject AUPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text190"];
                        TextObject AUChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text192"];
                        TextObject AUBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text194"];
                        TextObject AUCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text196"];
                        TextObject AUMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text198"];
                        TextObject AUPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text199"];
                        TextObject AUCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text204"];
                        TextObject AUEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
                        TextObject AUSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text55"];

                        TextObject PRAUEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text188"];
                        TextObject PRAUHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text11"];
                        TextObject PRAUPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text191"];
                        TextObject PRAUChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text193"];
                        TextObject PRAUBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text195"];
                        TextObject PRAUCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text197"];
                        TextObject PRAUMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text12"];
                        TextObject PRAUPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text200"];
                        TextObject PRAUCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text205"];
                        TextObject PRAUEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
                        TextObject PRAUSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text31"];

                        TextObject FAUEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text206"];
                        TextObject FAUHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text208"];
                        TextObject FAUPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text209"];
                        TextObject FAUChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text211"];
                        TextObject FAUBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text213"];
                        TextObject FAUCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text215"];
                        TextObject FAUMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text217"];
                        TextObject FAUPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text218"];
                        TextObject FAUCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text220"];
                        TextObject FAUEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text23"];
                        TextObject FAUSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];

                        TextObject TOTALEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text222"];
                        TextObject TOTALHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text224"];
                        TextObject TOTALPhysics = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text225"];
                        TextObject TOTALChemistry = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text227"];
                        TextObject TOTALBiology = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text229"];
                        TextObject TOTALCompSci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text231"];
                        TextObject TOTALMath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text233"];
                        TextObject TOTALPhysicalEdu = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text234"];
                        TextObject TOTALCommercialArt = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text238"];
                        TextObject TOTALEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
                        TextObject TOTALSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text61"];





                        //TextObject PRHYEntrepreneurship = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text39"];
                        //TextObject PRHYSUB11 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];


                        TextObject UTITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text240"];
                        TextObject TUTTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text241"];
                        TextObject THYTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text242"];
                        TextObject AUTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text243"];
                        TextObject FAUTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text244"];
                        TextObject FTOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text245"];
                        TextObject UTIITOT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text156"];

                        string UTEngstring = "";
                        string UTHindiBengalistring = "";
                        string UTPhysicsstring = "";
                        string UTChemistrystring = "";
                        string UTBiologystring = "";
                        string UTCompScistring = "";
                        string UTMathstring = "";
                        string UTPhysicalEdustring = "";
                        string UTCommercialArtstring = "";
                        string UTEntrepreneurshipstring = "";
                        string UTSUB11string = "";

                        string UTIIEngstring = "";
                        string UTIIHindiBengalistring = "";
                        string UTIIPhysicsstring = "";
                        string UTIIChemistrystring = "";
                        string UTIIBiologystring = "";
                        string UTIICompScistring = "";
                        string UTIIMathstring = "";
                        string UTIIPhysicalEdustring = "";
                        string UTIICommercialArtstring = "";
                        string UTIIEntrepreneurshipstring = "";
                        string UTIISUB11string = "";

                        string TUTEngstring = "";
                        string TUTHindiBengalistring = "";
                        string TUTPhysicsstring = "";
                        string TUTChemistrystring = "";
                        string TUTBiologystring = "";
                        string TUTCompScistring = "";
                        string TUTPhysicalEdustring = "";
                        string TUTMathstring = "";
                        string TUTCommercialArtstring = "";
                        string TUTEntrepreneurshipstring = "";
                        string TUTSUB11string = "";

                        string THYEngstring = "";
                        string THYHindiBengalistring = "";
                        string THYPhysicsstring = "";
                        string THYChemistrystring = "";
                        string THYBiologystring = "";
                        string THYCompScistring = "";
                        string THYPhysicalEdustring = "";
                        string THYMathstring = "";
                        string THYCommercialArtstring = "";
                        string THYEntrepreneurshipstring = "";
                        string THYSUB11string = "";

                        string PRHYEngstring = "";
                        string PRHYHindiBengalistring = "";
                        string PRHYPhysicsstring = "";
                        string PRHYChemistrystring = "";
                        string PRHYBiologystring = "";
                        string PRHYCompScistring = "";
                        string PRHYPhysicalEdustring = "";
                        string PRHYMathstring = "";
                        string PRHYCommercialArtstring = "";
                        string PRHYEntrepreneurshipstring = "";
                        string PRHYSUB11string = "";

                        string AUEngstring = "";
                        string AUHindiBengalistring = "";
                        string AUPhysicsstring = "";
                        string AUChemistrystring = "";
                        string AUBiologystring = "";
                        string AUCompScistring = "";
                        string AUPhysicalEdustring = "";
                        string AUMathstring = "";
                        string AUCommercialArtstring = "";
                        string AUEntrepreneurshipstring = "";
                        string AUSUB11string = "";

                        string FAUEngstring = "";
                        string FAUHindiBengalistring = "";
                        string FAUPhysicsstring = "";
                        string FAUChemistrystring = "";
                        string FAUBiologystring = "";
                        string FAUCompScistring = "";
                        string FAUPhysicalEdustring = "";
                        string FAUMathstring = "";
                        string FAUCommercialArtstring = "";
                        string FAUEntrepreneurshipstring = "";
                        string FAUSUB11string = "";

                        string PRAUEngstring = "";
                        string PRAUHindiBengalistring = "";
                        string PRAUPhysicsstring = "";
                        string PRAUChemistrystring = "";
                        string PRAUBiologystring = "";
                        string PRAUCompScistring = "";
                        string PRAUPhysicalEdustring = "";
                        string PRAUMathstring = "";
                        string PRAUCommercialArtstring = "";
                        string PRAUEntrepreneurshipstring = "";
                        string PRAUSUB11string = "";

                        string TOTALEngstring = "";
                        string TOTALHindiBengalistring = "";
                        string TOTALPhysicsstring = "";
                        string TOTALChemistrystring = "";
                        string TOTALBiologystring = "";
                        string TOTALCompScistring = "";
                        string TOTALPhysicalEdustring = "";
                        string TOTALMathstring = "";
                        string TOTALCommercialArtstring = "";
                        string TOTALEntrepreneurshipstring = "";
                        string TOTALSUB11string = "";


                        List<byte[]> files = new List<byte[]>();

                        for (i = 0; i < dsObjgrade.Tables[0].Rows.Count; i++)
                        {

                            //strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                           // dsObj = sGetDataset(strQry);
                            //if (dsObj.Tables[0].Rows.Count > 0)
                            //{
                                //strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2018/10/29' And '2019/03/25' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                //string attcount = sExecuteReader(strQry);
                                //PresentDay.Text = attcount;

                                //totaldays.Text = "70";

                                //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
                                //PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                           // }

                            //Code By Nikhil
                            try
                            {
                                if (Convert.ToString(Session["AcademicID"]) == "3")
                                {
                                    strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2018/10/29' And '2019/03/14' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                    string subcount1 = sExecuteReader(strQry);
                                    PresentDay.Text = subcount1;

                                    totaldays.Text = "69";
                                }
                                else if (Convert.ToString(Session["AcademicID"]) == "4")
                                {
                                    strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2019/11/30' And '2020/03/14' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                    string subcount1 = sExecuteReader(strQry);
                                    PresentDay.Text = subcount1;
                                    string query = " select  count(b.status) as TotalWorkingDays from Student_Master  a   inner join tblSchoolAttendance b   on  a.intStudent_id =b.intStudent_id where b.dtDate between '2019/11/01' And '2020/03/14'   and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                                    string totalworkingdays = sExecuteReader(query);
                                    //Totaldays.Text = "70";
                                    totaldays.Text = "75";
                                }
                            }
                            catch { }


                            session.Text = Convert.ToString(Session["YearName"]);
                            ExamName.Text = Convert.ToString(Session["Exam_id"]).ToUpper();
                            reportname.Text = "REPORT CARD FOR " + Convert.ToString(Session["standard_id"]).ToUpper();

                            strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + Session["standard_idnum"] + "'";
                            //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
                            dsObj = sGetDataset(strQry);
                            if (dsObj.Tables[0].Rows.Count > 0)
                            {
                                name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudentFirst_name"]);
                                mothername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchMotherName"]);
                                fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                                fathername.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                                birthdate.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["dtDOB"]);
                                rollno.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intRollNo"]);

                                //class1.Text = ddlSTD.SelectedItem.ToString();
                                sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                            }


                            // @type='ResultXI'
                            strQry = "exec usp_ExamMarks @type='ResultXI_2021',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Session["standard_idnum"] + "'";
                            dsObj = sGetDataset(strQry);
                            if (dsObj.Tables[0].Rows.Count > 0)
                            {
                                try
                                {
                                    SUBEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUBEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["vchsubjectname"]);
                                }
                                catch
                                {
                                }
                                try
                                {
                                    SUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["vchsubjectname"]);
                                }
                                catch
                                {
                                }

                                try
                                {
                                    UTEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTI"]);
                                    if (UTEng.Text == "NA" || UTEng.Text == "AB" || UTEng.Text == "NE")
                                    {
                                        UTEngstring = "0";
                                    }
                                    else
                                    {
                                        UTEngstring = UTEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTI"]);
                                    if (UTHindiBengali.Text == "NA" || UTHindiBengali.Text == "AB" || UTHindiBengali.Text == "NE")
                                    {
                                        UTHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        UTHindiBengalistring = UTHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTI"]);
                                    if (UTPhysics.Text == "NA" || UTPhysics.Text == "AB" || UTPhysics.Text == "NE")
                                    {
                                        UTPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        UTPhysicsstring = UTPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTI"]);
                                    if (UTChemistry.Text == "NA" || UTChemistry.Text == "AB" || UTChemistry.Text == "NE")
                                    {
                                        UTChemistrystring = "0";
                                    }
                                    else
                                    {
                                        UTChemistrystring = UTChemistry.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTI"]);
                                    if (UTBiology.Text == "NA" || UTBiology.Text == "AB" || UTBiology.Text == "NE")
                                    {
                                        UTBiologystring = "0";
                                    }
                                    else
                                    {
                                        UTBiologystring = UTBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTI"]);
                                    if (UTCompSci.Text == "NA" || UTCompSci.Text == "AB" || UTCompSci.Text == "NE")
                                    {
                                        UTCompScistring = "0";
                                    }
                                    else
                                    {
                                        UTCompScistring = UTCompSci.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTI"]);
                                    if (UTMath.Text == "NA" || UTMath.Text == "AB" || UTMath.Text == "NE")
                                    {
                                        UTMathstring = "0";

                                    }
                                    else
                                    {
                                        UTMathstring = UTMath.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTI"]);
                                    if (UTPhysicalEdu.Text == "NA" || UTPhysicalEdu.Text == "AB" || UTPhysicalEdu.Text == "NE")
                                    {
                                        UTPhysicalEdustring = "0";
                                    }
                                    else
                                    {
                                        UTPhysicalEdustring = UTPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTI"]);
                                    if (UTCommercialArt.Text == "NA" || UTCommercialArt.Text == "AB" || UTCommercialArt.Text == "NE")
                                    {
                                        UTCommercialArtstring = "0";
                                    }
                                    else
                                    {
                                        UTCommercialArtstring = UTCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTI"]);
                                    if (UTEntrepreneurship.Text == "NA" || UTEntrepreneurship.Text == "AB" || UTEntrepreneurship.Text == "NE")
                                    {
                                        UTEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        UTEntrepreneurshipstring = UTEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["UTI"]);
                                    if (UTSUB11.Text == "NA" || UTSUB11.Text == "AB" || UTSUB11.Text == "NE")
                                    {
                                        UTSUB11string = "0";
                                    }
                                    else
                                    {
                                        UTSUB11string = UTSUB11.Text;
                                    }
                                }
                                catch
                                {
                                }

                                /////////////////////////////////Changes done from here //////////////////////////////////////////////
                                try
                                {
                                    UTIIEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTII"]);
                                    if (UTIIEng.Text == "NA" || UTIIEng.Text == "AB" || UTIIEng.Text == "NE")
                                    {
                                        UTIIEngstring = "0";
                                    }
                                    else
                                    {
                                        UTIIEngstring = UTIIEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTII"]);
                                    if (UTIIHindiBengali.Text == "NA" || UTIIHindiBengali.Text == "AB" || UTIIHindiBengali.Text == "NE")
                                    {
                                        UTIIHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        UTIIHindiBengalistring = UTIIHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTII"]);
                                    if (UTIIPhysics.Text == "NA" || UTIIPhysics.Text == "AB" || UTIIPhysics.Text == "NE")
                                    {
                                        UTIIPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        UTIIPhysicsstring = UTIIPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTII"]);
                                    if (UTIIChemistry.Text == "NA" || UTIIChemistry.Text == "AB" || UTIIChemistry.Text == "NE")
                                    {
                                        UTIIChemistrystring = "0";
                                    }
                                    else
                                    {
                                        UTIIChemistrystring = UTIIChemistry.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTII"]);
                                    if (UTIIBiology.Text == "NA" || UTIIBiology.Text == "AB" || UTIIBiology.Text == "NE")
                                    {
                                        UTIIBiologystring = "0";
                                    }
                                    else
                                    {
                                        UTIIBiologystring = UTIIBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIICompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTII"]);
                                    if (UTIICompSci.Text == "NA" || UTIICompSci.Text == "AB" || UTIICompSci.Text == "NE")
                                    {
                                        UTIICompScistring = "0";
                                    }
                                    else
                                    {
                                        UTIICompScistring = UTIICompSci.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTII"]);
                                    if (UTIIMath.Text == "NA" || UTIIMath.Text == "AB" || UTIIMath.Text == "NE")
                                    {
                                        UTIIMathstring = "0";

                                    }
                                    else
                                    {
                                        UTIIMathstring = UTIIMath.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTII"]);
                                    if (UTIIPhysicalEdu.Text == "NA" || UTIIPhysicalEdu.Text == "AB" || UTIIPhysicalEdu.Text == "NE")
                                    {
                                        UTIIPhysicalEdustring = "0";
                                    }
                                    else
                                    {
                                        UTIIPhysicalEdustring = UTIIPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIICommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTII"]);
                                    if (UTIICommercialArt.Text == "NA" || UTIICommercialArt.Text == "AB" || UTIICommercialArt.Text == "NE")
                                    {
                                        UTIICommercialArtstring = "0";
                                    }
                                    else
                                    {
                                        UTIICommercialArtstring = UTIICommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIIEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTII"]);
                                    if (UTIIEntrepreneurship.Text == "NA" || UTIIEntrepreneurship.Text == "AB" || UTIIEntrepreneurship.Text == "NE")
                                    {
                                        UTIIEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        UTIIEntrepreneurshipstring = UTIIEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    UTIISUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["UTII"]);
                                    if (UTIISUB11.Text == "NA" || UTIISUB11.Text == "AB" || UTIISUB11.Text == "NE")
                                    {
                                        UTIISUB11string = "0";
                                    }
                                    else
                                    {
                                        UTIISUB11string = UTIISUB11.Text;
                                    }
                                }
                                catch
                                {
                                }
                                ////////////////////////////////////////////////////////

                                try
                                {
                                    TUTEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly"]);
                                    if (TUTEng.Text == "NA" || TUTEng.Text == "AB" || TUTEng.Text == "NE")
                                    {
                                        TUTEngstring = "0";
                                    }
                                    else
                                    {
                                        TUTEngstring = TUTEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    TUTHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly"]);
                                    if (TUTHindiBengali.Text == "NA" || TUTHindiBengali.Text == "AB" || TUTHindiBengali.Text == "NE")
                                    {
                                        TUTHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        TUTHindiBengalistring = TUTHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly"]);
                                    if (TUTPhysics.Text == "NA" || TUTPhysics.Text == "AB" || TUTPhysics.Text == "NE")
                                    {
                                        TUTPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        TUTPhysicsstring = TUTPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly"]);
                                    if (TUTChemistry.Text == "NA" || TUTChemistry.Text == "AB" || TUTChemistry.Text == "NE")
                                    {
                                        TUTChemistrystring = "0";
                                    }
                                    else
                                    {
                                        TUTChemistrystring = TUTChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly"]);
                                    if (TUTBiology.Text == "NA" || TUTBiology.Text == "AB" || TUTBiology.Text == "NE")
                                    {
                                        TUTBiologystring = "0";
                                    }
                                    else
                                    {
                                        TUTBiologystring = TUTBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly"]);
                                    if (TUTCompSci.Text == "NA" || TUTCompSci.Text == "AB" || TUTCompSci.Text == "NE")
                                    {
                                        TUTCompScistring = "0";
                                    }
                                    else
                                    {
                                        TUTCompScistring = TUTCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly"]);
                                    if (TUTMath.Text == "NA" || TUTMath.Text == "AB" || TUTMath.Text == "NE")
                                    {
                                        TUTMathstring = "0";
                                    }
                                    else
                                    {
                                        TUTMathstring = TUTMath.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Half Yearly"]);
                                    if (TUTPhysicalEdu.Text == "NA" || TUTPhysicalEdu.Text == "AB" || TUTPhysicalEdu.Text == "NE")
                                    {
                                        TUTPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        TUTPhysicalEdustring = TUTPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Half Yearly"]);
                                    if (TUTCommercialArt.Text == "NA" || TUTCommercialArt.Text == "AB" || TUTCommercialArt.Text == "NE")
                                    {
                                        TUTCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        TUTCommercialArtstring = TUTCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }

                                try
                                {
                                    TUTEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Half Yearly"]);
                                    if (TUTEntrepreneurship.Text == "NA" || TUTEntrepreneurship.Text == "AB" || TUTEntrepreneurship.Text == "NE")
                                    {
                                        TUTEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        TUTEntrepreneurshipstring = TUTEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TUTSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["Half Yearly"]);
                                    if (TUTSUB11.Text == "NA" || TUTSUB11.Text == "AB" || TUTSUB11.Text == "NE")
                                    {
                                        TUTSUB11string = "0";
                                    }
                                    else
                                    {
                                        TUTSUB11string = TUTSUB11.Text;
                                    }
                                }
                                catch
                                {
                                }

                                try
                                {
                                    PRHYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["HYPractical"]);
                                    if (PRHYEng.Text == "NA" || PRHYEng.Text == "AB" || PRHYEng.Text == "NE")
                                    {
                                        PRHYEngstring = "0";
                                    }
                                    else
                                    {
                                        PRHYEngstring = PRHYEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    PRHYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["HYPractical"]);
                                    if (PRHYHindiBengali.Text == "NA" || PRHYHindiBengali.Text == "AB" || PRHYHindiBengali.Text == "NE")
                                    {
                                        PRHYHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        PRHYHindiBengalistring = PRHYHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["HYPractical"]);
                                    if (PRHYPhysics.Text == "NA" || PRHYPhysics.Text == "AB" || PRHYPhysics.Text == "NE")
                                    {
                                        PRHYPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        PRHYPhysicsstring = PRHYPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["HYPractical"]);
                                    if (PRHYChemistry.Text == "NA" || PRHYChemistry.Text == "AB" || PRHYChemistry.Text == "NE")
                                    {
                                        PRHYChemistrystring = "0";
                                    }
                                    else
                                    {
                                        PRHYChemistrystring = PRHYChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["HYPractical"]);
                                    if (PRHYBiology.Text == "NA" || PRHYBiology.Text == "AB" || PRHYBiology.Text == "NE")
                                    {
                                        PRHYBiologystring = "0";
                                    }
                                    else
                                    {
                                        PRHYBiologystring = PRHYBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["HYPractical"]);
                                    if (PRHYCompSci.Text == "NA" || PRHYCompSci.Text == "AB" || PRHYCompSci.Text == "NE")
                                    {
                                        PRHYCompScistring = "0";
                                    }
                                    else
                                    {
                                        PRHYCompScistring = PRHYCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["HYPractical"]);
                                    if (PRHYMath.Text == "NA" || PRHYMath.Text == "AB" || PRHYMath.Text == "NE")
                                    {
                                        PRHYMathstring = "0";
                                    }
                                    else
                                    {
                                        PRHYMathstring = PRHYMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["HYPractical"]);
                                    if (PRHYPhysicalEdu.Text == "NA" || PRHYPhysicalEdu.Text == "AB" || PRHYPhysicalEdu.Text == "NE")
                                    {
                                        PRHYPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        PRHYPhysicalEdustring = PRHYPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["HYPractical"]);
                                    if (PRHYCommercialArt.Text == "NA" || PRHYCommercialArt.Text == "AB" || PRHYCommercialArt.Text == "NE")
                                    {
                                        PRHYCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        PRHYCommercialArtstring = PRHYCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["HYPractical"]);
                                    if (PRHYEntrepreneurship.Text == "NA" || PRHYEntrepreneurship.Text == "AB" || PRHYEntrepreneurship.Text == "NE")
                                    {
                                        PRHYEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        PRHYEntrepreneurshipstring = PRHYEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRHYSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["HYPractical"]);
                                    if (PRHYSUB11.Text == "NA" || PRHYSUB11.Text == "AB" || PRHYSUB11.Text == "NE")
                                    {
                                        PRHYSUB11string = "0";
                                    }
                                    else
                                    {
                                        PRHYSUB11string = PRHYSUB11.Text;
                                    }
                                }
                                catch
                                {
                                }


                                try
                                {
                                    THYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["30%_OF_HALFYEARLY"]);
                                    if (THYEng.Text == "NA" || THYEng.Text == "AB" || THYEng.Text == "NE")
                                    {
                                        THYEngstring = "0";
                                    }
                                    else
                                    {
                                        THYEngstring = THYEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    THYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["30%_OF_HALFYEARLY"]);
                                    if (THYHindiBengali.Text == "NA" || THYHindiBengali.Text == "AB" || THYHindiBengali.Text == "NE")
                                    {
                                        THYHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        THYHindiBengalistring = THYHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["30%_OF_HALFYEARLY"]);
                                    if (THYPhysics.Text == "NA" || THYPhysics.Text == "AB" || THYPhysics.Text == "NE")
                                    {
                                        THYPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        THYPhysicsstring = THYPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["30%_OF_HALFYEARLY"]);
                                    if (THYChemistry.Text == "NA" || THYChemistry.Text == "AB" || THYChemistry.Text == "NE")
                                    {
                                        THYChemistrystring = "0";
                                    }
                                    else
                                    {
                                        THYChemistrystring = THYChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["30%_OF_HALFYEARLY"]);
                                    if (THYBiology.Text == "NA" || THYBiology.Text == "AB" || THYBiology.Text == "NE")
                                    {
                                        THYBiologystring = "0";
                                    }
                                    else
                                    {
                                        THYBiologystring = THYBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["30%_OF_HALFYEARLY"]);
                                    if (THYCompSci.Text == "NA" || THYCompSci.Text == "AB" || THYCompSci.Text == "NE")
                                    {
                                        THYCompScistring = "0";
                                    }
                                    else
                                    {
                                        THYCompScistring = THYCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["30%_OF_HALFYEARLY"]);
                                    if (THYMath.Text == "NA" || THYMath.Text == "AB" || THYMath.Text == "NE")
                                    {
                                        THYMathstring = "0";
                                    }
                                    else
                                    {
                                        THYMathstring = THYMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["30%_OF_HALFYEARLY"]);
                                    if (THYPhysicalEdu.Text == "NA" || THYPhysicalEdu.Text == "AB" || THYPhysicalEdu.Text == "NE")
                                    {
                                        THYPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        THYPhysicalEdustring = THYPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["30%_OF_HALFYEARLY"]);
                                    if (THYCommercialArt.Text == "NA" || THYCommercialArt.Text == "AB" || THYCommercialArt.Text == "NE")
                                    {
                                        THYCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        THYCommercialArtstring = THYCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["30%_OF_HALFYEARLY"]);
                                    if (THYEntrepreneurship.Text == "NA" || THYEntrepreneurship.Text == "AB" || THYEntrepreneurship.Text == "NE")
                                    {
                                        THYEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        THYEntrepreneurshipstring = THYEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    THYSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["30%_OF_HALFYEARLY"]);
                                    if (THYSUB11.Text == "NA" || THYSUB11.Text == "AB" || THYSUB11.Text == "NE")
                                    {
                                        THYSUB11string = "0";
                                    }
                                    else
                                    {
                                        THYSUB11string = THYSUB11.Text;
                                    }
                                }
                                catch
                                {
                                }

                                try
                                {
                                    AUEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Annual Exam"]);
                                    if (AUEng.Text == "NA" || AUEng.Text == "AB" || AUEng.Text == "NE")
                                    {
                                        AUEngstring = "0";
                                    }
                                    else
                                    {
                                        AUEngstring = AUEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    AUHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Annual Exam"]);
                                    if (AUHindiBengali.Text == "NA" || AUHindiBengali.Text == "AB" || AUHindiBengali.Text == "NE")
                                    {
                                        AUHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        AUHindiBengalistring = AUHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Annual Exam"]);
                                    if (AUPhysics.Text == "NA" || AUPhysics.Text == "AB" || AUPhysics.Text == "NE")
                                    {
                                        AUPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        AUPhysicsstring = AUPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Exam"]);
                                    if (AUChemistry.Text == "NA" || AUChemistry.Text == "AB" || AUChemistry.Text == "NE")
                                    {
                                        AUChemistrystring = "0";
                                    }
                                    else
                                    {
                                        AUChemistrystring = AUChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Exam"]);
                                    if (AUBiology.Text == "NA" || AUBiology.Text == "AB" || AUBiology.Text == "NE")
                                    {
                                        AUBiologystring = "0";
                                    }
                                    else
                                    {
                                        AUBiologystring = AUBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Annual Exam"]);
                                    if (AUCompSci.Text == "NA" || AUCompSci.Text == "AB" || AUCompSci.Text == "NE")
                                    {
                                        AUCompScistring = "0";
                                    }
                                    else
                                    {
                                        AUCompScistring = AUCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Annual Exam"]);
                                    if (AUMath.Text == "NA" || AUMath.Text == "AB" || AUMath.Text == "NE")
                                    {
                                        AUMathstring = "0";
                                    }
                                    else
                                    {
                                        AUMathstring = AUMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Annual Exam"]);
                                    if (AUPhysicalEdu.Text == "NA" || AUPhysicalEdu.Text == "AB" || AUPhysicalEdu.Text == "NE")
                                    {
                                        AUPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        AUPhysicalEdustring = AUPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Annual Exam"]);
                                    if (AUCommercialArt.Text == "NA" || AUCommercialArt.Text == "AB" || AUCommercialArt.Text == "NE")
                                    {
                                        AUCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        AUCommercialArtstring = AUCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Annual Exam"]);
                                    if (AUEntrepreneurship.Text == "NA" || AUEntrepreneurship.Text == "AB" || AUEntrepreneurship.Text == "NE")
                                    {
                                        AUEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        AUEntrepreneurshipstring = AUEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    AUSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["Annual Exam"]);
                                    if (AUSUB11.Text == "NA" || AUSUB11.Text == "AB" || AUSUB11.Text == "NE")
                                    {
                                        AUSUB11string = "0";
                                    }
                                    else
                                    {
                                        AUSUB11string = AUSUB11.Text;
                                    }
                                }
                                catch
                                {
                                }

                                try
                                {
                                    PRAUEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Annual Practical"]);
                                    if (PRAUEng.Text == "NA" || PRAUEng.Text == "AB" || PRAUEng.Text == "NE")
                                    {
                                        PRAUEngstring = "0";
                                    }
                                    else
                                    {
                                        PRAUEngstring = PRAUEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    PRAUHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Annual Practical"]);
                                    if (PRAUHindiBengali.Text == "NA" || PRAUHindiBengali.Text == "AB" || PRAUHindiBengali.Text == "NE")
                                    {
                                        PRAUHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        PRAUHindiBengalistring = PRAUHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Annual Practical"]);
                                    if (PRAUPhysics.Text == "NA" || PRAUPhysics.Text == "AB" || PRAUPhysics.Text == "NE")
                                    {
                                        PRAUPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        PRAUPhysicsstring = PRAUPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Practical"]);
                                    if (PRAUChemistry.Text == "NA" || PRAUChemistry.Text == "AB" || PRAUChemistry.Text == "NE")
                                    {
                                        PRAUChemistrystring = "0";
                                    }
                                    else
                                    {
                                        PRAUChemistrystring = PRAUChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Practical"]);
                                    if (PRAUBiology.Text == "NA" || PRAUBiology.Text == "AB" || PRAUBiology.Text == "NE")
                                    {
                                        PRAUBiologystring = "0";
                                    }
                                    else
                                    {
                                        PRAUBiologystring = PRAUBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Annual Practical"]);
                                    if (PRAUCompSci.Text == "NA" || PRAUCompSci.Text == "AB" || PRAUCompSci.Text == "NE")
                                    {
                                        PRAUCompScistring = "0";
                                    }
                                    else
                                    {
                                        PRAUCompScistring = PRAUCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Annual Practical"]);
                                    if (PRAUMath.Text == "NA" || PRAUMath.Text == "AB" || PRAUMath.Text == "NE")
                                    {
                                        PRAUMathstring = "0";
                                    }
                                    else
                                    {
                                        PRAUMathstring = PRAUMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Annual Practical"]);
                                    if (PRAUPhysicalEdu.Text == "NA" || PRAUPhysicalEdu.Text == "AB" || PRAUPhysicalEdu.Text == "NE")
                                    {
                                        PRAUPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        PRAUPhysicalEdustring = PRAUPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Annual Practical"]);
                                    if (PRAUCommercialArt.Text == "NA" || PRAUCommercialArt.Text == "AB" || PRAUCommercialArt.Text == "NE")
                                    {
                                        PRAUCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        PRAUCommercialArtstring = PRAUCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Annual Practical"]);
                                    if (PRAUEntrepreneurship.Text == "NA" || PRAUEntrepreneurship.Text == "AB" || PRAUEntrepreneurship.Text == "NE")
                                    {
                                        PRAUEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        PRAUEntrepreneurshipstring = PRAUEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    PRAUSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["Annual Practical"]);
                                    if (PRAUSUB11.Text == "NA" || PRAUSUB11.Text == "AB" || PRAUSUB11.Text == "NE")
                                    {
                                        PRAUSUB11string = "0";
                                    }
                                    else
                                    {
                                        PRAUSUB11string = PRAUSUB11.Text;
                                    }
                                }
                                catch
                                {
                                }

                                try
                                {
                                    FAUEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["50%_OF_ANNUAL"]);
                                    if (FAUEng.Text == "NA" || FAUEng.Text == "AB" || FAUEng.Text == "NE")
                                    {
                                        FAUEngstring = "0";
                                    }
                                    else
                                    {
                                        FAUEngstring = FAUEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    FAUHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["50%_OF_ANNUAL"]);
                                    if (FAUHindiBengali.Text == "NA" || FAUHindiBengali.Text == "AB" || FAUHindiBengali.Text == "NE")
                                    {
                                        FAUHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        FAUHindiBengalistring = FAUHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["50%_OF_ANNUAL"]);
                                    if (FAUPhysics.Text == "NA" || FAUPhysics.Text == "AB" || FAUPhysics.Text == "NE")
                                    {
                                        FAUPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        FAUPhysicsstring = FAUPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["50%_OF_ANNUAL"]);
                                    if (FAUChemistry.Text == "NA" || FAUChemistry.Text == "AB" || FAUChemistry.Text == "NE")
                                    {
                                        FAUChemistrystring = "0";
                                    }
                                    else
                                    {
                                        FAUChemistrystring = FAUChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["50%_OF_ANNUAL"]);
                                    if (FAUBiology.Text == "NA" || FAUBiology.Text == "AB" || FAUBiology.Text == "NE")
                                    {
                                        FAUBiologystring = "0";
                                    }
                                    else
                                    {
                                        FAUBiologystring = FAUBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["50%_OF_ANNUAL"]);
                                    if (FAUCompSci.Text == "NA" || FAUCompSci.Text == "AB" || FAUCompSci.Text == "AB" || FAUCompSci.Text == "NE")
                                    {
                                        FAUCompScistring = "0";
                                    }
                                    else
                                    {
                                        FAUCompScistring = FAUCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["50%_OF_ANNUAL"]);
                                    if (FAUMath.Text == "NA" || FAUMath.Text == "AB" || FAUMath.Text == "NE")
                                    {
                                        FAUMathstring = "0";
                                    }
                                    else
                                    {
                                        FAUMathstring = FAUMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["50%_OF_ANNUAL"]);
                                    if (FAUPhysicalEdu.Text == "NA" || FAUPhysicalEdu.Text == "AB" || FAUPhysicalEdu.Text == "NE")
                                    {
                                        FAUPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        FAUPhysicalEdustring = FAUPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["50%_OF_ANNUAL"]);
                                    if (FAUCommercialArt.Text == "NA" || FAUCommercialArt.Text == "AB" || FAUCommercialArt.Text == "NE")
                                    {
                                        FAUCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        FAUCommercialArtstring = FAUCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["50%_OF_ANNUAL"]);
                                    if (FAUEntrepreneurship.Text == "NA" || FAUEntrepreneurship.Text == "AB" || FAUEntrepreneurship.Text == "NE")
                                    {
                                        FAUEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        FAUEntrepreneurshipstring = FAUEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    FAUSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["50%_OF_ANNUAL"]);
                                    if (FAUSUB11.Text == "NA" || FAUSUB11.Text == "AB" || FAUSUB11.Text == "NE")
                                    {
                                        FAUSUB11string = "0";
                                    }
                                    else
                                    {
                                        FAUSUB11string = FAUSUB11.Text;
                                    }
                                }
                                catch
                                {
                                }


                                try
                                {
                                    TOTALEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["NEWFINAL TOTAL"]);
                                    if (TOTALEng.Text == "NA" || TOTALEng.Text == "AB" || TOTALEng.Text == "NE")
                                    {
                                        TOTALEngstring = "0";
                                    }
                                    else
                                    {
                                        TOTALEngstring = TOTALEng.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {

                                    TOTALHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["NEWFINAL TOTAL"]);
                                    if (TOTALHindiBengali.Text == "NA" || TOTALHindiBengali.Text == "AB" || TOTALHindiBengali.Text == "NE")
                                    {
                                        TOTALHindiBengalistring = "0";
                                    }
                                    else
                                    {
                                        TOTALHindiBengalistring = TOTALHindiBengali.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALPhysics.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["NEWFINAL TOTAL"]);
                                    if (TOTALPhysics.Text == "NA" || TOTALPhysics.Text == "AB" || TOTALPhysics.Text == "NE")
                                    {
                                        TOTALPhysicsstring = "0";
                                    }
                                    else
                                    {
                                        TOTALPhysicsstring = TOTALPhysics.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALChemistry.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["NEWFINAL TOTAL"]);
                                    if (TOTALChemistry.Text == "NA" || TOTALChemistry.Text == "AB" || TOTALChemistry.Text == "NE")
                                    {
                                        TOTALChemistrystring = "0";
                                    }
                                    else
                                    {
                                        TOTALChemistrystring = TOTALChemistry.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALBiology.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["NEWFINAL TOTAL"]);
                                    if (TOTALBiology.Text == "NA" || TOTALBiology.Text == "AB" || TOTALBiology.Text == "NE")
                                    {
                                        TOTALBiologystring = "0";
                                    }
                                    else
                                    {
                                        TOTALBiologystring = TOTALBiology.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALCompSci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["NEWFINAL TOTAL"]);
                                    if (TOTALCompSci.Text == "NA" || TOTALCompSci.Text == "AB" || TOTALCompSci.Text == "NE")
                                    {
                                        TOTALCompScistring = "0";
                                    }
                                    else
                                    {
                                        TOTALCompScistring = TOTALCompSci.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALMath.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["NEWFINAL TOTAL"]);
                                    if (TOTALMath.Text == "NA" || TOTALMath.Text == "AB" || TOTALMath.Text == "NE")
                                    {
                                        TOTALMathstring = "0";
                                    }
                                    else
                                    {
                                        TOTALMathstring = TOTALMath.Text;

                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALPhysicalEdu.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["NEWFINAL TOTAL"]);
                                    if (TOTALPhysicalEdu.Text == "NA" || TOTALPhysicalEdu.Text == "AB" || TOTALPhysicalEdu.Text == "NE")
                                    {
                                        TOTALPhysicalEdustring = "0";
                                    }
                                    else
                                    {

                                        TOTALPhysicalEdustring = TOTALPhysicalEdu.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALCommercialArt.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["NEWFINAL TOTAL"]);
                                    if (TOTALCommercialArt.Text == "NA" || TOTALCommercialArt.Text == "AB" || TOTALCommercialArt.Text == "NE")
                                    {
                                        TOTALCommercialArtstring = "0";

                                    }
                                    else
                                    {
                                        TOTALCommercialArtstring = TOTALCommercialArt.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["NEWFINAL TOTAL"]);
                                    if (TOTALEntrepreneurship.Text == "NA" || TOTALEntrepreneurship.Text == "AB" || TOTALEntrepreneurship.Text == "NE")
                                    {
                                        TOTALEntrepreneurshipstring = "0";
                                    }
                                    else
                                    {
                                        TOTALEntrepreneurshipstring = TOTALEntrepreneurship.Text;
                                    }
                                }
                                catch
                                {
                                }
                                try
                                {
                                    TOTALSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[10]["NEWFINAL TOTAL"]);
                                    if (TOTALSUB11.Text == "NA" || TOTALSUB11.Text == "AB" || TOTALSUB11.Text == "NE")
                                    {
                                        TOTALSUB11string = "0";
                                    }
                                    else
                                    {
                                        TOTALSUB11string = TOTALSUB11.Text;
                                    }
                                }
                                catch
                                {
                                }

                                //try
                                //{
                                //    PRHYEntrepreneurship.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["20%_OF_UT"]);
                                //    if (PRHYEntrepreneurship.Text == "NA" || PRHYEntrepreneurship.Text == "AB")
                                //    {
                                //        PRHYEntrepreneurshipstring = "0";

                                //    }
                                //    else
                                //    {
                                //        PRHYEntrepreneurshipstring = PRHYEntrepreneurship.Text;
                                //    }
                                //}
                                //catch
                                //{
                                //}
                                //try
                                //{
                                //    PRHYSUB11.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["20%_OF_UT"]);
                                //    if (PRHYSUB11.Text == "NA" || PRHYSUB11.Text == "AB")
                                //    {
                                //        PRHYSUB11string = "0";

                                //    }
                                //    else
                                //    {
                                //        PRHYSUB11string = PRHYSUB11.Text;
                                //    }
                                //}
                                //catch
                                //{
                                //}
                                try
                                {
                                    UTITOT.Text = Convert.ToString(Convert.ToInt32(UTEngstring) + Convert.ToInt32(UTHindiBengalistring) + Convert.ToInt32(UTPhysicsstring) + Convert.ToInt32(UTChemistrystring) + Convert.ToInt32(UTBiologystring) + Convert.ToInt32(UTCompScistring) + Convert.ToInt32(UTMathstring) + Convert.ToInt32(UTPhysicalEdustring) + Convert.ToInt32(UTCommercialArtstring) + Convert.ToInt32(UTEntrepreneurshipstring) + Convert.ToInt32(UTSUB11string));
                                    UTIITOT.Text = Convert.ToString(Convert.ToInt32(UTIIEngstring) + Convert.ToInt32(UTIIHindiBengalistring) + Convert.ToInt32(UTIIPhysicsstring) + Convert.ToInt32(UTIIChemistrystring) + Convert.ToInt32(UTIIBiologystring) + Convert.ToInt32(UTIICompScistring) + Convert.ToInt32(UTIIMathstring) + Convert.ToInt32(UTIIPhysicalEdustring) + Convert.ToInt32(UTIICommercialArtstring) + Convert.ToInt32(UTIIEntrepreneurshipstring) + Convert.ToInt32(UTIISUB11string));
                                    TUTTOT.Text = Convert.ToString(Convert.ToInt32(TUTEngstring) + Convert.ToInt32(TUTHindiBengalistring) + Convert.ToInt32(TUTPhysicsstring) + Convert.ToInt32(TUTChemistrystring) + Convert.ToInt32(TUTBiologystring) + Convert.ToInt32(TUTCompScistring) + Convert.ToInt32(TUTMathstring) + Convert.ToInt32(TUTPhysicalEdustring) + Convert.ToInt32(TUTCommercialArtstring) + Convert.ToInt32(TUTEntrepreneurshipstring) + Convert.ToInt32(TUTSUB11string) + Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(PRHYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYMathstring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring) + Convert.ToInt32(PRHYEntrepreneurshipstring) + Convert.ToInt32(PRHYSUB11string));// + Convert.ToInt32(UTEntrepreneurshipstring) + Convert.ToInt32(UTSUB11string)) Convert.ToInt32(PRHYEngstring) + Convert.ToInt32(PRHYHindiBengalistring) + Convert.ToInt32(PRHYPhysicsstring) + Convert.ToInt32(PRHYChemistrystring) + Convert.ToInt32(PRHYBiologystring) + Convert.ToInt32(PRHYCompScistring) + Convert.ToInt32(PRHYMathstring) + Convert.ToInt32(PRHYPhysicalEdustring) + Convert.ToInt32(PRHYCommercialArtstring) + Convert.ToInt32(PRHYEntrepreneurshipstring) + Convert.ToInt32(PRHYSUB11string));
                                    THYTOT.Text = Convert.ToString(Convert.ToInt32(THYEngstring) + Convert.ToInt32(THYHindiBengalistring) + Convert.ToInt32(THYPhysicsstring) + Convert.ToInt32(THYChemistrystring) + Convert.ToInt32(THYBiologystring) + Convert.ToInt32(THYCompScistring) + Convert.ToInt32(THYMathstring) + Convert.ToInt32(THYPhysicalEdustring) + Convert.ToInt32(THYCommercialArtstring) + Convert.ToInt32(THYEntrepreneurshipstring) + Convert.ToInt32(THYSUB11string));
                                    AUTOT.Text = Convert.ToString(Convert.ToInt32(AUEngstring) + Convert.ToInt32(AUHindiBengalistring) + Convert.ToInt32(AUPhysicsstring) + Convert.ToInt32(AUChemistrystring) + Convert.ToInt32(AUBiologystring) + Convert.ToInt32(AUCompScistring) + Convert.ToInt32(AUMathstring) + Convert.ToInt32(AUPhysicalEdustring) + Convert.ToInt32(AUCommercialArtstring) + Convert.ToInt32(AUEntrepreneurshipstring) + Convert.ToInt32(AUSUB11string) + Convert.ToInt32(PRAUEngstring) + Convert.ToInt32(PRAUHindiBengalistring) + Convert.ToInt32(PRAUPhysicsstring) + Convert.ToInt32(PRAUChemistrystring) + Convert.ToInt32(PRAUBiologystring) + Convert.ToInt32(PRAUCompScistring) + Convert.ToInt32(PRAUMathstring) + Convert.ToInt32(PRAUPhysicalEdustring) + Convert.ToInt32(PRAUCommercialArtstring) + Convert.ToInt32(PRAUEntrepreneurshipstring) + Convert.ToInt32(PRAUSUB11string));

                                    FAUTOT.Text = Convert.ToString(Convert.ToInt32(FAUEngstring) + Convert.ToInt32(FAUHindiBengalistring) + Convert.ToInt32(FAUPhysicsstring) + Convert.ToInt32(FAUChemistrystring) + Convert.ToInt32(FAUBiologystring) + Convert.ToInt32(FAUCompScistring) + Convert.ToInt32(FAUMathstring) + Convert.ToInt32(FAUPhysicalEdustring) + Convert.ToInt32(FAUCommercialArtstring) + Convert.ToInt32(FAUEntrepreneurshipstring) + Convert.ToInt32(FAUSUB11string));
                                    FTOT.Text = Convert.ToString(Convert.ToInt32(TOTALEngstring) + Convert.ToInt32(TOTALHindiBengalistring) + Convert.ToInt32(TOTALPhysicsstring) + Convert.ToInt32(TOTALChemistrystring) + Convert.ToInt32(TOTALBiologystring) + Convert.ToInt32(TOTALCompScistring) + Convert.ToInt32(TOTALMathstring) + Convert.ToInt32(TOTALPhysicalEdustring) + Convert.ToInt32(TOTALCommercialArtstring) + Convert.ToInt32(TOTALEntrepreneurshipstring) + Convert.ToInt32(TOTALSUB11string));
                                }
                                catch
                                {
                                }


                            }
                            crystalReport.Load(Server.MapPath(string.Format("Result_XI_XII_ArtsAnnual.rpt", i)));
                            stream1 = crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);
                            files.Add(PrepareBytes(stream1));
                        }
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/pdf";

                        //// merge the all reports & show the reports            
                        Response.BinaryWrite(MergeReports(files).ToArray());
                        // AdmissionReport.ReportSource = crystalReport;
                        Response.End();
                    }
                
                }


            }
            catch
            { 
            
            }
        }




    }

    private MemoryStream MergeReports(List<byte[]> files)
    {
        if (files.Count > 1)
        {
            PdfReader pdfFile;

            Document doc;
            PdfWriter pCopy;
            MemoryStream msOutput = new MemoryStream();

            pdfFile = new PdfReader(files[0]);

            doc = new Document();
            pCopy = new PdfSmartCopy(doc, msOutput);

            doc.Open();

            for (int k = 0; k < files.Count; k++)
            {
                pdfFile = new PdfReader(files[k]);
                for (int i = 1; i < pdfFile.NumberOfPages + 1; i++)
                {
                    ((PdfSmartCopy)pCopy).AddPage(pCopy.GetImportedPage(pdfFile, i));
                }
                pCopy.FreeReader(pdfFile);
            }

            pdfFile.Close();
            pCopy.Close();
            doc.Close();

            return msOutput;
        }
        else if (files.Count == 1)
        {
            return new MemoryStream(files[0]);
        }

        return null;
    }
    private byte[] PrepareBytes(Stream stream)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            byte[] buffer = new byte[stream.Length];
            int read;
            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }

}