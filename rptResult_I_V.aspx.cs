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

public partial class rptResult_I_V : DBUtility
{
    ReportDocument crystalReport = new ReportDocument();
    Stream stream1;
    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    string strQry = "";
    DataSet dsObj;
    DataSet dsObjgrade;
    string exam = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["rptAllStudentMark"] != null)
        {
            dsObjgrade = (DataSet)Session["rptAllStudentMark"];

            try
            {
                int i = 0;
                string reportPath = Server.MapPath("Result_I_V.rpt");
                crystalReport.Load(reportPath);

                TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text130"];
                TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text2"];
                TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text131"];
                TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text128"];
                TextObject mothername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
                TextObject birthdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text132"];
                TextObject Address = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text135"];
                TextObject PhoneNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];
                TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text259"];
                TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text257"];

                TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];
                session.Text = Convert.ToString(Session["YearName"]);
                ExamName.Text = Convert.ToString(Session["Exam_id"]).ToUpper();
                //reportname.Text = "REPORT CARD FOR " + ddlSTD.SelectedItem.ToString().ToUpper();
                class1.Text = Convert.ToString(Session["standard_id"]).ToUpper();
                TextObject SUBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text33"];
                TextObject SUBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text34"];
                TextObject SUBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text35"];
                TextObject SUBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text36"];
                TextObject SUBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text37"];
                TextObject SUBEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text38"];
                TextObject SUBLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text10"];
                TextObject SUBComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text261"];
                TextObject SUBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text262"];

                TextObject Eng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text139"];
                TextObject HindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text140"];
                TextObject math = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text141"];
                TextObject sci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text142"];
                TextObject Sosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text143"];
                TextObject Evs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text144"];
                TextObject LHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text145"];
                TextObject Comp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text263"];
                TextObject EVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text264"];

                TextObject Eng2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text181"];
                TextObject HindiBengali2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text182"];
                TextObject math2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text183"];
                TextObject sci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text184"];
                TextObject Sosci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text185"];
                TextObject Evs2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text186"];
                TextObject LHLB2= (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text187"];
                TextObject Comp2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text275"];
                TextObject EVS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text276"];

                TextObject NBEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text146"];
                TextObject NBHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text147"];
                TextObject NBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text148"];
                TextObject NBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text149"];
                TextObject NBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text150"];
                TextObject NBEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text151"];
                TextObject NBLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text152"];
                TextObject NBComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text265"];
                TextObject NBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text266"];

                TextObject NBEng2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text188"];
                TextObject NBHindiBengali2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text189"];
                TextObject NBmath2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text190"];
                TextObject NBsci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text191"];
                TextObject NBSosci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text192"];
                TextObject NBEvs2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text193"];
                TextObject NBLHLB2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text194"];
                TextObject NBComp2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text277"];
                TextObject NBEVS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text278"];

                TextObject SEEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text153"];
                TextObject SEHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text154"];
                TextObject SEmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text155"];
                TextObject SEsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text156"];
                TextObject SESosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text157"];
                TextObject SEEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text158"];
                TextObject SELHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text159"];
                TextObject SEComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text267"];
                TextObject SEEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text268"];

                TextObject SEEng2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text195"];
                TextObject SEHindiBengali2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text196"];
                TextObject SEmath2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text197"];
                TextObject SEsci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text198"];
                TextObject SESosci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text199"];
                TextObject SEEvs2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text200"];
                TextObject SELHLB2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text201"];
                TextObject SEComp2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text279"];
                TextObject SEEVS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text280"];

                TextObject HYEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text160"];
                TextObject HYHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text161"];
                TextObject HYmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text162"];
                TextObject HYsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text163"];
                TextObject HYSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text164"];
                TextObject HYEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text165"];
                TextObject HYLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text166"];
                TextObject HYComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text269"];
                TextObject HYEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text270"];

                TextObject AUEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text202"];
                TextObject AUHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text203"];
                TextObject AUmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text204"];
                TextObject AUsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text205"];
                TextObject AUSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text206"];
                TextObject AUEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text207"];
                TextObject AULHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text208"];
                TextObject AUComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text281"];
                TextObject AUEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text282"];

                TextObject MOEng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text167"];
                TextObject MOHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text168"];
                TextObject MOmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text169"];
                TextObject MOsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text170"];
                TextObject MOSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text171"];
                TextObject MOEvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text172"];
                TextObject MOLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text173"];
                TextObject MOComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text271"];
                TextObject MOEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text272"];

                TextObject MOEng2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text209"];
                TextObject MOHindiBengali2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text210"];
                TextObject MOmath2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text211"];
                TextObject MOsci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text212"];
                TextObject MOSosci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text213"];
                TextObject MOEvs2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text214"];
                TextObject MOLHLB2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text215"];
                TextObject MOComp2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text283"];
                TextObject MOEVS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text284"];

                TextObject GREng = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text174"];
                TextObject GRHindiBengali = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text175"];
                TextObject GRmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text176"];
                TextObject GRsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text177"];
                TextObject GRSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text178"];
                TextObject GREvs = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text179"];
                TextObject GRLHLB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text180"];
                TextObject GRComp = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text273"];
                TextObject GREVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text274"];

                TextObject GREng2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text216"];
                TextObject GRHindiBengali2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text217"];
                TextObject GRmath2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text218"];
                TextObject GRsci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text219"];
                TextObject GRSosci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text220"];
                TextObject GREvs2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text221"];
                TextObject GRLHLB2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text222"];
                TextObject GRComp2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text285"];
                TextObject GREVS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text286"];

                TextObject SUBWEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
                TextObject SUBAEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
                TextObject SUBHPEEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                TextObject SUBLSActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
                TextObject SUBDHActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text7"];
                TextObject SUBMUActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text29"];
                TextObject SUBPTActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];

                TextObject WEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text223"];
                TextObject AEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text224"];
                TextObject HPEEActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text225"];
                TextObject LSActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text226"];
                TextObject DHActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text227"];
                TextObject MUActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text228"];
                TextObject PTActivity = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text229"];

                TextObject WEActivity2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text230"];
                TextObject AEActivity2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text231"];
                TextObject HPEEActivity2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text232"];
                TextObject LSActivity2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text233"];
                TextObject DHActivity2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text234"];
                TextObject MUActivity2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text235"];
                TextObject PTActivity2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text236"];

                TextObject SUBRPElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
                TextObject SUBSIElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text88"];
                TextObject SUBBVElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
                TextObject SUBRRRElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];
                TextObject SUBATElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];
                TextObject SUBATSElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
                TextObject SUBASElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text95"];
                TextObject SUBATNElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];

                TextObject RPElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text237"];
                TextObject SIElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text238"];
                TextObject BVElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text239"];
                TextObject RRRElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text240"];
                TextObject ATElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text241"];
                TextObject ATSElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text242"];
                TextObject ASElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text243"];
                TextObject ATNElements = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text244"];

                TextObject RPElements2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text245"];
                TextObject SIElements2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text246"];
                TextObject BVElements2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text247"];
                TextObject RRRElements2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text248"];
                TextObject ATElements2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text249"];
                TextObject ATSElements2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text250"];
                TextObject ASElements2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text251"];
                TextObject ATNElements2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text252"];

                TextObject Suggestion = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text254"];
                TextObject AreaofStrength = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text5"];

                TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text138"];
                TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];
                TextObject StudentId = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text129"];

                TextObject Result = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text255"];

                List<byte[]> files = new List<byte[]>();
                for (i = 0; i < dsObjgrade.Tables[0].Rows.Count; i ++)
                {

                    // strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                    // dsObj = sGetDataset(strQry);
                    // if (dsObj.Tables[0].Rows.Count > 0)
                    // {
                    try
                    {
                        if (Convert.ToString(Session["AcademicID"]) == "3")
                        {

                            strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2018/10/05' And '2019/03/14' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                            string subcount = sExecuteReader(strQry);
                            PresentDay.Text = subcount;

                            totaldays.Text = "74";
                        }
                        else if (Convert.ToString(Session["AcademicID"]) == "4")
                        {
                            strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2019/11/01' And '2020/03/30' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                            string subcount = sExecuteReader(strQry);
                            PresentDay.Text = subcount;
                            string query = " select  count(b.status) as TotalWorkingDays from Student_Master  a   inner join tblSchoolAttendance b   on  a.intStudent_id =b.intStudent_id where b.dtDate between '2019/11/01' And '2020/03/30'   and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                            string totalworkingdays = sExecuteReader(query);
                            //Totaldays.Text = "70";
                            totaldays.Text = "79";
                        }
                    }
                    catch
                    { }
                    //totaldays.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalDay"]);
                    //PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                    //}


                strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "',@intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "'";
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
                    Address.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpresentAddress"]);
                    PhoneNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intHomePhoneNo1"]);
                    //class1.Text = ddlSTD.SelectedItem.ToString();
                    sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                    StudentId.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["intStudentID_Number"]);
                }

                strQry = "exec usp_ExamMarks @type='ExamMark_Half',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Convert.ToString(Session["standard_idnum"]) + "'";
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
                        SUBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SUBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SUBSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SUBEvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SUBLHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SUBComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    try
                    {
                        SUBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["vchsubjectname"]);
                    }
                    catch
                    {

                    }
                    if (Convert.ToString(Session["Exam_id"]) == "Term-1")
                    {
                        try
                        {

                            Eng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTI"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTI"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            math.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTI"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            sci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTI"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Sosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTI"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Evs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTI"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            LHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTI"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Comp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTI"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            EVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTI"]);
                        }
                        catch
                        {

                        }

                        try
                        {
                            NBEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Note Book"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Note Book"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Note Book"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBEvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBLHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Note Book"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Note Book"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Note Book"]);
                        }
                        catch
                        {

                        }
                        try
                        {



                            SEEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SESosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEEvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SELHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Sub Enrichment"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Sub Enrichment"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Sub Enrichment"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYEvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYLHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Half Yearly Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Half Yearly Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {



                            MOEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Total"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Total"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Total"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Total"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOEvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Total"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOLHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Total"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Total"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Total"]);
                            if (MOEVS.Text != "0")
                            {
                                Result.Text = "Passed";
                            }
                        }
                        catch
                        {

                        }
                        try
                        {


                            GREng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Grade"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Grade"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Grade"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Grade"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GREvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Grade"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRLHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Grade"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Grade"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GREVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Grade"]);
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {

                            Eng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTI"]);
                            Eng2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTII"]);

                        }
                        catch
                        {

                        }
                        try
                        {
                            HindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTI"]);
                            HindiBengali2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTII"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            math.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTI"]);
                            math2.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTII"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            sci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTI"]);
                            sci2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTII"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Sosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTI"]);
                            Sosci2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTII"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Evs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTI"]);
                            Evs2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTII"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            LHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTI"]);
                            LHLB2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTII"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            Comp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTI"]);
                            Comp2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTII"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            EVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTI"]);
                            EVS2.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTII"]);
                        }
                        catch
                        {

                        }

                        try
                        {
                            NBEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Note Book"]);
                            NBEng2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Note Book-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Note Book"]);
                            NBHindiBengali2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Note Book-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Note Book"]);
                            NBmath2.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Note Book-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book"]);
                            NBsci2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book"]);
                            NBSosci2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBEvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book"]);
                            NBEvs2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBLHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Note Book"]);
                            NBLHLB2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Note Book-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Note Book"]);
                            NBComp2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Note Book-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            NBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Note Book"]);
                            NBEVS2.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Note Book-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment"]);
                            SEEng2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment"]);
                            SEHindiBengali2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment"]);
                            SEmath2.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment"]);
                            SEsci2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SESosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment"]);
                            SESosci2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEEvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment"]);
                            SEEvs2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SELHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Sub Enrichment"]);
                            SELHLB2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Sub Enrichment-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Sub Enrichment"]);
                            SEComp2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Sub Enrichment-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SEEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Sub Enrichment"]);
                            SEEVS2.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Sub Enrichment-II"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly Exam"]);
                            AUEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Annual Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly Exam"]);
                            AUHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Annual Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly Exam"]);
                            AUmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Annual Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly Exam"]);
                            AUsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly Exam"]);
                            AUSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYEvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly Exam"]);
                            AUEvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Annual Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYLHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly Exam"]);
                            AULHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Annual Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Half Yearly Exam"]);
                            AUComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Annual Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HYEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Half Yearly Exam"]);
                            AUEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Annual Exam"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOEng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                            MOEng2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Total"]);
                            MOHindiBengali2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["TotalAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Total"]);
                            MOmath2.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["TotalAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Total"]);
                            MOsci2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["TotalAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Total"]);
                            MOSosci2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["TotalAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOEvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Total"]);
                            MOEvs2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["TotalAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOLHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Total"]);
                            MOLHLB2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["TotalAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Total"]);
                            MOComp2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["TotalAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MOEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Total"]);
                            MOEVS2.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["TotalAnnual"]);
                            if (MOEVS.Text != "0")
                            {
                                Result.Text = "Passed";
                            }
                        }
                        catch
                        {

                        }
                        try
                        {

                            GREng.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Grade"]);
                            GREng2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GradeAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRHindiBengali.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Grade"]);
                            GRHindiBengali2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GradeAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Grade"]);
                            GRmath2.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GradeAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                            GRsci2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GradeAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Grade"]);
                            GRSosci2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GradeAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GREvs.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Grade"]);
                            GREvs2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GradeAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRLHLB.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Grade"]);
                            GRLHLB2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GradeAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GRComp.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Grade"]);
                            GRComp2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["GradeAnnual"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            GREVS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Grade"]);
                            GREVS2.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["GradeAnnual"]);
                        }
                        catch { }
                    
                    }
                }

                strQry = "exec usp_ExamMarks @type='ActivityGrade',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(Session["Exam_id"]) == "Term-1")
                    {
                        try
                        {
                            WEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            AEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HPEEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            LSActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DHActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MUActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            PTActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBWEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBAEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBHPEEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBLSActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBDHActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBMUActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBPTActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["VchName"]);
                        }
                        catch { }
                    }
                    else
                    {

                        try
                        {
                            WEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            AEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            HPEEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            LSActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            DHActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            MUActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            PTActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBWEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBAEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBHPEEActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBLSActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBDHActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBMUActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBPTActivity.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["VchName"]);
                        }
                        catch { }
                        strQry = "exec usp_ExamMarks @type='ActivityGradeAnnual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                WEActivity2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                AEActivity2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                HPEEActivity2.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                LSActivity2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                DHActivity2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                MUActivity2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                PTActivity2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GRADE"]);
                            }
                            catch
                            {

                            }

                        }
                    
                    }
                }

                    

                strQry = "exec usp_ExamMarks @type='ElementGrade',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToString(Session["Exam_id"]) == "Term-1")
                    {
                        try
                        {
                            RPElements.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SIElements.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            BVElements.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            RRRElements.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            ATElements.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            ATSElements.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            ASElements.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            ATNElements.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["GRADE"]);
                        }
                        catch { }

                        try
                        {
                            SUBRPElements.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBSIElements.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBBVElements.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBRRRElements.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBATElements.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBATSElements.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBASElements.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBATNElements.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["VchName"]);
                        }
                        catch { }
                    }
                    else 
                    {
                        try
                        {
                            RPElements.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SIElements.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            BVElements.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            RRRElements.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            ATElements.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            ATSElements.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            ASElements.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GRADE"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            ATNElements.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["GRADE"]);
                        }
                        catch { }

                        try
                        {
                            SUBRPElements.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBSIElements.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBBVElements.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBRRRElements.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBATElements.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBATSElements.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBASElements.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["VchName"]);
                        }
                        catch
                        {

                        }
                        try
                        {
                            SUBATNElements.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["VchName"]);
                        }
                        catch { }

                        strQry = "exec usp_ExamMarks @type='ElementGradeAnnual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            try
                            {
                                RPElements2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                SIElements2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                BVElements2.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                RRRElements2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                ATElements2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                ATSElements2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                ASElements2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GRADE"]);
                            }
                            catch
                            {

                            }
                            try
                            {
                                ATNElements2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["GRADE"]);
                            }
                            catch { }

                        }


                    }
                }
                if (Convert.ToString(Session["Exam_id"]) == "Term-1")
                {

                    try
                    {
                        Result.Text = "";
                        //strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
                        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' and intAttendance=2 and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'half%') ";
                        string remark = sExecuteReader(strQry);
                        Suggestion.Text = remark;

                        if (remark == "-2")
                        {
                            Suggestion.Text = "NA";
                        }
                        else
                        {
                            Suggestion.Text = remark;
                        }
                    }
                    catch
                    {
                        //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
                        //Response.End();
                    }
                    try
                    {
                        //strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
                        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' and intAttendance=6 and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'half%') ";
                        string area = sExecuteReader(strQry);
                        // AreaofStrength.Text = area;
                        if (area == "-2")
                        {
                            AreaofStrength.Text = "NA";
                        }
                        else
                        {
                            AreaofStrength.Text = area;
                        }
                    }
                    catch
                    {
                        //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
                        //Response.End();
                    }
                }
                else
                {

                    try
                    {
                        //strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
                        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' and intAttendance=2 and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'Annual%') ";
                        string remark = sExecuteReader(strQry);
                        Suggestion.Text = remark;

                        if (remark == "-2")
                        {
                            Suggestion.Text = "NA";
                        }
                        else
                        {
                            Suggestion.Text = remark;
                        }
                    }
                    catch
                    {
                        //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
                        //Response.End();
                    }
                    try
                    {
                        //strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
                        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' and intAttendance=6 and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'Annual%') ";
                        string area = sExecuteReader(strQry);
                        // AreaofStrength.Text = area;
                        if (area == "-2")
                        {
                            AreaofStrength.Text = "NA";
                        }
                        else
                        {
                            AreaofStrength.Text = area;
                        }
                    }
                    catch
                    {
                        //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "'" + ddlStudent.SelectedItem + "'");
                        //Response.End();
                    }   
                
                }

                

                crystalReport.Load(Server.MapPath(string.Format("Result_I_V.rpt", i)));


                //AdmissionReport.ReportSource = crystalReport;
                //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, string.Empty);
                try
                {
                    stream1 = crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);
                }
                catch { }
                try
                {
                    files.Add(PrepareBytes(stream1));
                }
                catch { }

            }

                AdmissionReport.ReportSource = files;
                AdmissionReport.SeparatePages = false;


                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";

                //// merge the all reports & show the reports            
                Response.BinaryWrite(MergeReports(files).ToArray());
                // AdmissionReport.ReportSource = crystalReport;
                Response.End(); 

                
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