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

public partial class rptResult_VI_VIII : DBUtility
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
                string reportPath = Server.MapPath("Result_VI-VIII.rpt");
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




                TextObject SUBlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text24"];
                TextObject SUBlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text25"];
                TextObject SUBlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text26"];
                TextObject SUBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text27"];
                TextObject SUBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text28"];
                TextObject SUBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text29"];
                TextObject SUBgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
                TextObject SUBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text30"];
                TextObject SUBLS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
                TextObject SUBVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];

                TextObject lang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text104"];
                TextObject lang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text105"];
                TextObject lang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text106"];
                TextObject math = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text107"];
                TextObject sci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text108"];
                TextObject Sosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text109"];
                TextObject general = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text110"];
                TextObject EVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
                TextObject LS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                TextObject VPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];


                TextObject lang12 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text146"];
                TextObject lang22 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text147"];
                TextObject lang32 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text148"];
                TextObject math2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text149"];
                TextObject sci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text150"];
                TextObject Sosci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text151"];
                TextObject general2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text217"];
                TextObject EVS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text152"];
                TextObject LS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text218"];
                TextObject VPA2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text219"];



                TextObject NBlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text111"];
                TextObject NBlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text112"];
                TextObject NBlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text113"];
                TextObject NBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text114"];
                TextObject NBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text115"];
                TextObject NBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text116"];
                TextObject NBgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text117"];
                TextObject NBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
                TextObject NBLS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text200"];
                TextObject NBVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text204"];

                TextObject NBlang12 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text153"];
                TextObject NBlang22 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text154"];
                TextObject NBlang32 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text155"];
                TextObject NBmath2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text156"];
                TextObject NBsci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text157"];
                TextObject NBSosci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text158"];
                TextObject NBgeneral2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text220"];
                TextObject NBEVS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text159"];
                TextObject NBLS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text221"];
                TextObject NBVPA2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text222"];


                TextObject SElang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text118"];
                TextObject SElang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text119"];
                TextObject SElang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];
                TextObject SEmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];
                TextObject SEsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text122"];
                TextObject SESosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text123"];
                TextObject SEgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text124"];
                TextObject SEEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text205"];
                TextObject SELS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text206"];
                TextObject SEVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text207"];

                TextObject SElang12 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text160"];
                TextObject SElang22 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text161"];
                TextObject SElang32 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text162"];
                TextObject SEmath2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text163"];
                TextObject SEsci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text164"];
                TextObject SESosci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text165"];
                TextObject SEgeneral2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text223"];
                TextObject SEEVS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text166"];
                TextObject SELS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text224"];
                TextObject SEVPA2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text225"];


                TextObject HYlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text125"];
                TextObject HYlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text126"];
                TextObject HYlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text127"];
                TextObject HYmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text128"];
                TextObject HYsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text129"];
                TextObject HYSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text130"];
                TextObject HYgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text131"];
                TextObject HYEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text208"];
                TextObject HYLS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text209"];
                TextObject HYVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text210"];


                TextObject AUlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text167"];
                TextObject AUlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text168"];
                TextObject AUlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text169"];
                TextObject AUmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text170"];
                TextObject AUsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text171"];
                TextObject AUSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text172"];
                TextObject AUgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text226"];
                TextObject AUEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text173"];
                TextObject AULS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text227"];
                TextObject AUVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text228"];

                TextObject totlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text132"];
                TextObject totlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
                TextObject totlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text134"];
                TextObject totmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text135"];
                TextObject totsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text136"];
                TextObject totSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text137"];
                TextObject totgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text138"];
                TextObject totEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text211"];
                TextObject totLS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text212"];
                TextObject totVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text213"];

                TextObject totlang12 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text174"];
                TextObject totlang22 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text175"];
                TextObject totlang32 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text176"];
                TextObject totmath2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text177"];
                TextObject totsci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text178"];
                TextObject totSosci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text179"];
                TextObject totgeneral2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text229"];
                TextObject totEVS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text180"];
                TextObject totLS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text230"];
                TextObject totVPA2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text231"];

                TextObject grlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text139"];
                TextObject grlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text140"];
                TextObject grlang3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text141"];
                TextObject grmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text142"];
                TextObject grsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text143"];
                TextObject grSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text144"];
                TextObject grgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text145"];
                TextObject grEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text214"];
                TextObject grLS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text215"];
                TextObject grVPA = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text216"];


                TextObject grlang12 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text181"];
                TextObject grlang22 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text182"];
                TextObject grlang32 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text183"];
                TextObject grmath2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text184"];
                TextObject grsci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text185"];
                TextObject grSosci2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text186"];
                TextObject grgeneral2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text232"];
                TextObject grEVS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text187"];
                TextObject grLS2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text233"];
                TextObject grVPA2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text234"];


                //TextObject WECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text188"];
                TextObject AECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text190"];
                TextObject HPECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text192"];

                TextObject AECoscholastic2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text191"];
                TextObject HPECoscholastic2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text193"];

                //TextObject WECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text188"];
                TextObject SUBAECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text40"];
                TextObject SUBHPECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text41"];

                TextObject SUBAECoscholastic2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text43"];
                TextObject SUBHPECoscholastic2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text44"];

                TextObject DisciplineTerm1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text194"];
                TextObject DisciplineTerm2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text195"];
                TextObject Suggestion = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text196"];

                TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text202"];

                session.Text = Convert.ToString(Session["YearName"]);
                ExamName.Text = Convert.ToString(Session["Exam_id"]).ToUpper();
                reportname.Text = "REPORT CARD FOR " + Convert.ToString(Session["standard_id"]).ToUpper();

                //strQry = "select count(intExamSubject_id) from tblExamSubject_Master where intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "' and intactive_flg=1 ";
                //string subcount = sExecuteReader(strQry);
                //int count = Convert.ToInt32(subcount);

                List<byte[]> files = new List<byte[]>();
                for (i = 0; i < dsObjgrade.Tables[0].Rows.Count; i ++)
                {

                 //strQry = "Execute dbo.usp_Profile @command='attendance' ,@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'";
                //dsObj = sGetDataset(strQry);
                //if (dsObj.Tables[0].Rows.Count > 0)
                //{
                    try
                    {
                        if (Convert.ToString(Session["AcademicID"]) == "3")
                        {
                            strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2018/10/29' And '2019/03/14' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                            string subcount = sExecuteReader(strQry);
                            PresentDay.Text = subcount;

                            totaldays.Text = "69";
                        }
                        else if (Convert.ToString(Session["AcademicID"]) == "4")
                        {
                            strQry = " select  count(b.status) as PrsentDay from Student_Master  a   inner join tblSchoolAttendance b  on  a.intStudent_id =b.intStudent_id where b.dtDate between '2019/11/01' And '2020/03/14' and b.status='Present' and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                            string subcount = sExecuteReader(strQry);
                            PresentDay.Text = subcount;
                            string query = " select  count(b.status) as TotalWorkingDays from Student_Master  a   inner join tblSchoolAttendance b   on  a.intStudent_id =b.intStudent_id where b.dtDate between '2019/11/01' And '2020/03/14'   and b.intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' group by a.intStudent_id";
                            string totalworkingdays = sExecuteReader(query);
                            //Totaldays.Text = "70";
                            totaldays.Text = "75";
                        }
                    }
                    catch { }
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

                    //class1.Text = ddlSTD.SelectedItem.ToString();
                    sec.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDivisionName"]);
                }

                strQry = "exec usp_ExamMarks @type='ExamMark_Half',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Convert.ToString(Session["standard_idnum"]) + "'";
                dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        SUBlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                    }
                    catch (Exception ex)
                    { }
                    try
                    {
                        SUBlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                    }
                    catch (Exception ex)
                    { }
                    try
                    {
                        SUBlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                    }
                    catch (Exception ex)
                    { }
                    try
                    {
                        SUBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                    }
                    catch (Exception ex)
                    { }
                    try
                    {
                        SUBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                    }
                    catch (Exception ex)
                    { }
                    try
                    {
                        SUBSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                    }
                    catch (Exception ex)
                    { }
                    try
                    {
                        SUBgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                    }
                    catch (Exception ex)
                    { }
                    try
                    {
                        SUBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["vchsubjectname"]);
                    }
                    catch (Exception ex)
                    { }
                    try
                    {
                        SUBLS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["vchsubjectname"]);
                    }
                    catch (Exception ex)
                    { }
                    try
                    {
                        SUBVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["vchsubjectname"]);
                    }
                    catch (Exception ex)
                    { }

                    if (Convert.ToString(Session["Exam_id"]) == "Term-1")
                    {
                        try
                        {

                            lang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTI"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            lang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTI"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            lang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTI"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            math.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTI"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            sci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTI"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            Sosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTI"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            EVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTI"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            general.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTI"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            LS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTI"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            VPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTI"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {

                            NBlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Note Book"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Note Book"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Note Book"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Note Book"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Note Book"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBLS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Note Book"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Note Book"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {

                            SElang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SElang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SElang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SEmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SEsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SESosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SEEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Sub Enrichment"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SEgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Sub Enrichment"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SELS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Sub Enrichment"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SEVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Sub Enrichment"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {

                            HYlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Half Yearly Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYLS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Half Yearly Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Half Yearly Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {

                            totlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Total"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Total"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Total"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Total"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Total"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Total"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Total"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totLS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Total"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Total"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {

                            grlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Grade"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Grade"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Grade"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Grade"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Grade"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Grade"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Grade"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grLS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Grade"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Grade"]);
                        }
                        catch (Exception ex)
                        { }
                    }

                    else
                    {
                        try
                        {

                            lang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTI"]);
                            lang12.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["UTII"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            lang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTI"]);
                            lang22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["UTII"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            lang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTI"]);
                            lang32.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["UTII"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            math.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTI"]);
                            math2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["UTII"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            sci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTI"]);
                            sci2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["UTII"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            Sosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTI"]);
                            Sosci2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["UTII"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            EVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTI"]);
                            EVS2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["UTII"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            general.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTI"]);
                            general2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["UTII"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            LS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTI"]);
                            LS2.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["UTII"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            VPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTI"]);
                            VPA2.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["UTII"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {

                            NBlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Note Book"]);
                            NBlang12.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Note Book-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Note Book"]);
                            NBlang22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Note Book-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Note Book"]);
                            NBlang32.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Note Book-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book"]);
                            NBmath2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book"]);
                            NBsci2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book"]);
                            NBSosci2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Note Book"]);
                            NBEVS2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Note Book-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Note Book"]);
                            NBgeneral2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Note Book-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBLS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Note Book"]);
                            NBLS2.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Note Book-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            NBVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Note Book"]);
                            NBVPA2.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Note Book-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {

                            SElang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment"]);
                            SElang12.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SElang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment"]);
                            SElang22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SElang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment"]);
                            SElang32.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SEmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment"]);
                            SEmath2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SEsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment"]);
                            SEsci2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SESosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment"]);
                            SESosci2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SEEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Sub Enrichment"]);
                            SEEVS2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Sub Enrichment-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SEgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Sub Enrichment"]);
                            SEgeneral2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Sub Enrichment-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SELS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Sub Enrichment"]);
                            SELS2.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Sub Enrichment-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            SEVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Sub Enrichment"]);
                            SEVPA2.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Sub Enrichment-II"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {

                            HYlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Half Yearly Exam"]);
                            AUlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Annual Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Half Yearly Exam"]);
                            AUlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Annual Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Half Yearly Exam"]);
                            AUlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Annual Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Half Yearly Exam"]);
                            AUmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Annual Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Half Yearly Exam"]);
                            AUsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Annual Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Half Yearly Exam"]);
                            AUSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Annual Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Half Yearly Exam"]);
                            AUEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Annual Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Half Yearly Exam"]);
                            AUgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Annual Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYLS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Half Yearly Exam"]);
                            AULS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Annual Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            HYVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Half Yearly Exam"]);
                            AUVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Annual Exam"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {

                            totlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                            totlang12.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["TotalAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Total"]);
                            totlang22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["TotalAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Total"]);
                            totlang32.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["TotalAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Total"]);
                            totmath2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["TotalAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Total"]);
                            totsci2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["TotalAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Total"]);
                            totSosci2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["TotalAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Total"]);
                            totEVS2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["TotalAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Total"]);
                            totgeneral2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["TotalAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totLS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Total"]);
                            totLS2.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["TotalAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            totVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Total"]);
                            totVPA2.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["TotalAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {

                            grlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Grade"]);
                            grlang12.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GradeAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Grade"]);
                            grlang22.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GradeAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grlang3.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Grade"]);
                            grlang32.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GradeAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grmath.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                            grmath2.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["GradeAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grsci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Grade"]);
                            grsci2.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["GradeAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Grade"]);
                            grSosci2.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["GradeAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Grade"]);
                            grEVS2.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["GradeAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grgeneral.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["Grade"]);
                            grgeneral2.Text = Convert.ToString(dsObj.Tables[0].Rows[7]["GradeAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grLS.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["Grade"]);
                            grLS2.Text = Convert.ToString(dsObj.Tables[0].Rows[8]["GradeAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                        try
                        {
                            grVPA.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["Grade"]);
                            grVPA2.Text = Convert.ToString(dsObj.Tables[0].Rows[9]["GradeAnnual"]);
                        }
                        catch (Exception ex)
                        { }
                    }

                }


                    try
                    {
                        strQry = "exec usp_ExamMarks @type='CoscholasticGrade',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            SUBAECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
                            SUBHPECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);

                            //WECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                            AECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                            HPECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);

                        }
                    }
                    catch (Exception ex)
                    { }
                


                if (Convert.ToString(Session["Exam_id"]) == "Term-2")
                {
                    try
                    {

                        strQry = "exec usp_ExamMarks @type='CoscholasticGradeAnnual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            SUBAECoscholastic2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["VchName"]);
                            SUBHPECoscholastic2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["VchName"]);

                            //WECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                            AECoscholastic2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                            HPECoscholastic2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);

                        }

                    }
                    catch 
                    { 
                    
                    }
                
                }


               
                try
                {

                    strQry = "exec usp_ExamMarks @type='DisciplineGrade',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        DisciplineTerm1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);

                    }
                }
                catch (Exception ex) { }
                

                if (Convert.ToString(Session["Exam_id"]) == "Term-2")
                {
                    try
                    {
                        strQry = "exec usp_ExamMarks @type='DisciplineGradeannual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            DisciplineTerm2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);

                        }

                    }
                    catch
                    { 
                    
                    }
                }

                

                    try
                    {
                        //strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
                        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'  and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'half%') ";
                        // string remark = sExecuteReader(strQry)
                        string remark = sExecuteReader(strQry);
                        if (remark == "-2")
                        {
                            Suggestion.Text = "NA";
                        }
                        else
                        {
                            Suggestion.Text = remark;
                        }
                    }
                    catch (Exception ex)
                    { }
                    if (Convert.ToString(Session["Exam_id"]) == "Term-2")
                    {

                        try
                        {
                            //strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + ddlStudent.SelectedValue.ToString() + "'";
                            strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "'  and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'Annual%') ";
                            // string remark = sExecuteReader(strQry)
                            string remark = sExecuteReader(strQry);
                            if (remark == "-2")
                            {
                                Suggestion.Text = "NA";
                            }
                            else
                            {
                                Suggestion.Text = remark;
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                


                crystalReport.Load(Server.MapPath(string.Format("Result_VI-VIII.rpt", i)));


                //AdmissionReport.ReportSource = crystalReport;
                //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, string.Empty);

                stream1 = crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);

                files.Add(PrepareBytes(stream1));

            }

                //AdmissionReport.ReportSource = files;
                //AdmissionReport.SeparatePages = false;


                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";

                //// merge the all reports & show the reports            
                Response.BinaryWrite(MergeReports(files).ToArray());
                // AdmissionReport.ReportSource = crystalReport;
                Response.End(); 
            }
            catch(Exception ex)
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