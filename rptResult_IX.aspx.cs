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

public partial class rptResult_IX : DBUtility
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

                string reportPath = Server.MapPath("Result_IX.rpt");
                crystalReport.Load(reportPath);

                TextObject name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];
                //TextObject class1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
                TextObject sec = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text66"];
                TextObject rollno = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text61"];
                TextObject mothername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text64"];
                TextObject fathername = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text65"];
                TextObject birthdate = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];
                TextObject session = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text110"];
                TextObject ExamName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text235"];
                TextObject reportname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text8"];

                TextObject totaldays = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text112"];
                TextObject PresentDay = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text67"];



                TextObject SUBlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text18"];
                TextObject SUBlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text19"];
                TextObject SUBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text20"];
                TextObject SUBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text21"];
                TextObject SUBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text22"];
                TextObject SUBIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text115"];
                TextObject SUBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text114"];

                TextObject lang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text68"];
                TextObject lang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text69"];
                TextObject math = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text70"];
                TextObject sci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text71"];
                TextObject Sosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];
                //TextObject general = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
                TextObject IT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text116"];
                TextObject EVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];

                TextObject NBlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
                TextObject NBlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text75"];
                TextObject NBmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text76"];
                TextObject NBsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text77"];
                TextObject NBSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text78"];
                //TextObject NBgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];
                TextObject NBIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text117"];
                TextObject NBEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text97"];

                TextObject SElang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text80"];
                TextObject SElang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text81"];
                TextObject SEmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text82"];
                TextObject SEsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text83"];
                TextObject SESosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text84"];
                //TextObject SEgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text85"];
                TextObject SEIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text118"];
                TextObject SEEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];

                TextObject AElang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text86"];
                TextObject AElang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text87"];
                TextObject AEmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text88"];
                TextObject AEsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text89"];
                TextObject AESosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text90"];
                //TextObject AEgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text91"];
                TextObject AEIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text119"];
                TextObject AEEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text85"];

                TextObject totlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text92"];
                TextObject totlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text93"];
                TextObject totmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];
                TextObject totsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text95"];
                TextObject totSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text96"];
                //TextObject totgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text97"];
                TextObject totIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text120"];
                TextObject totEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text79"];

                TextObject grlang1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text98"];
                TextObject grlang2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text99"];
                TextObject grmath = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text100"];
                TextObject grsci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text101"];
                TextObject grSosci = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text102"];
                //TextObject grgeneral = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text103"];
                TextObject grIT = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text121"];
                TextObject grEVS = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];

                TextObject WECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text104"];
                TextObject AECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text105"];
                TextObject HPECoscholastic = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text106"];

                TextObject DisciplineTerm1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text107"];
                TextObject Suggestion = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text108"];

                TextObject examname = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text14"];

                //strQry = "select count(intExamSubject_id) from tblExamSubject_Master where intStandard_id='" + Convert.ToString(Session["standard_idnum"]) + "' and intactive_flg=1 ";
                //string subcount = sExecuteReader(strQry);
                //int count = Convert.ToInt32(subcount);

                List<byte[]> files = new List<byte[]>();

                for (i = 0; i < dsObjgrade.Tables[0].Rows.Count; i ++)
                {
                    //if (Convert.ToString(Session["standard_id"]) == "IX")
                    //{


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
                            //PresentDay.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                       // }
                    //}

                session.Text = Convert.ToString(Session["YearName"]);
                ExamName.Text = Convert.ToString(Session["Exam_id"]).ToUpper();
                reportname.Text = "REPORT CARD FOR " + Convert.ToString(Session["standard_id"]);


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

                if (Convert.ToString(Session["Exam_id"]) == "Term-1")
                {


                    strQry = "exec usp_ExamMarks @type='ResultIX',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Convert.ToString(Session["standard_idnum"]) + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {

                        try
                        {
                            SUBlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                        }
                        catch { }
                        try
                        {
                            SUBlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            SUBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                        }
                        catch { }
                        try
                        {
                            SUBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                        }
                        catch { }
                        try
                        {
                            SUBSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                        }
                        catch { }
                        try
                        {
                            SUBIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                        }
                        catch { }

                        try
                        {
                            SUBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                        }
                        catch { }




                        try
                        {
                            lang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["PT"]);
                        }
                        catch { }
                        try
                        {
                            lang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["PT"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            math.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["PT"]);
                        }
                        catch { }
                        try
                        {
                            sci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["PT"]);
                        }
                        catch { }
                        try
                        {
                            Sosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["PT"]);
                        }
                        catch { }
                        try
                        {

                            //general.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["PT"]);
                        }
                        catch { }
                        try
                        {
                            IT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["PT"]);
                        }
                        catch { }
                        try
                        {
                            EVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["PT"]);
                        }
                        catch { }
                        try
                        {

                            NBlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Note Book"]);
                        }
                        catch { }
                        try
                        {
                            NBlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Note Book"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            NBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Note Book"]);
                        }
                        catch { }
                        try
                        {
                            NBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Note Book"]);
                        }
                        catch { }
                        try
                        {
                            NBSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Note Book"]);
                        }
                        catch { }
                        try
                        {
                            //NBgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Note Book"]);
                        }
                        catch { }
                        try
                        {
                            NBIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Note Book"]);
                        }
                        catch { }
                        try
                        {
                            NBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Note Book"]);
                        }
                        catch { }
                        try
                        {

                            SElang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            SElang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            SEmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            SEsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            SESosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            //SEgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            SEIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            SEEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {

                            AElang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["HY"]);
                        }
                        catch { }
                        try
                        {
                            AElang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["HY"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            AEmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["HY"]);
                        }
                        catch { }
                        try
                        {
                            AEsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["HY"]);
                        }
                        catch { }
                        try
                        {
                            AESosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["HY"]);
                        }
                        catch { }
                        try
                        {
                            //AEgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["HY"]);
                        }
                        catch { }
                        try
                        {
                            AEIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["HY"]);
                        }
                        catch { }
                        try
                        {
                            AEEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["HY"]);
                        }
                        catch { }
                        try
                        {

                            totlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                        }
                        catch { }
                        try
                        {
                            totlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Total"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            totmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Total"]);
                        }
                        catch { }
                        try
                        {
                            totsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Total"]);
                        }
                        catch { }
                        try
                        {
                            totSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Total"]);
                        }
                        catch { }
                        try
                        {
                            //totgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Total"]);
                        }
                        catch { }
                        try
                        {
                            totIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Total"]);
                        }
                        catch { }
                        try
                        {
                            totEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Total"]);
                        }
                        catch { }
                        try
                        {

                            grlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            grlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            grmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            grsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            grSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            //grgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            grIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Grade"]);
                        }
                        catch
                        { }
                        try
                        {
                            grEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Grade"]);
                        }
                        catch
                        { }
                    }



                    if (Convert.ToString(Session["Exam_id"]) == "Term-2")
                    {
                        strQry = "exec usp_ExamMarks @type='CoscholasticGradeIXstdAnnual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    }
                    else
                    {
                        strQry = "exec usp_ExamMarks @type='CoscholasticGradeIXstd',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    }
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            WECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        }
                        catch { }
                        try
                        {
                            AECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        }
                        catch { }
                        try
                        {
                            HPECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        }
                        catch
                        { }

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
                    catch
                    {

                    }
                    try
                    {

                        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'half%')";
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
                    catch { }
                }
                else
                {
                    examname.Text = "Annual Exam";
                    strQry = "exec usp_ExamMarks @type='ResultIXAnnual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "',@intstandard_id='" + Convert.ToString(Session["standard_idnum"]) + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {

                        try
                        {
                            SUBlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectname"]);
                        }
                        catch { }
                        try
                        {
                            SUBlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["vchsubjectname"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            SUBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["vchsubjectname"]);
                        }
                        catch { }
                        try
                        {
                            SUBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["vchsubjectname"]);
                        }
                        catch { }
                        try
                        {
                            SUBSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["vchsubjectname"]);
                        }
                        catch { }
                        try
                        {
                            SUBIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["vchsubjectname"]);
                        }
                        catch { }

                        try
                        {
                            SUBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["vchsubjectname"]);
                        }
                        catch { }




                        try
                        {
                            lang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["PT"]);
                        }
                        catch { }
                        try
                        {
                            lang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["PT"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            math.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["PT"]);
                        }
                        catch { }
                        try
                        {
                            sci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["PT"]);
                        }
                        catch { }
                        try
                        {
                            Sosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["PT"]);
                        }
                        catch { }
                        try
                        {

                            //general.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["PT"]);
                        }
                        catch { }
                        try
                        {
                            IT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["PT"]);
                        }
                        catch { }
                        try
                        {
                            EVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["PT"]);
                        }
                        catch { }
                        try
                        {

                            NBlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["NOTE BOOK"]);
                        }
                        catch { }
                        try
                        {
                            NBlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["NOTE BOOK"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            NBmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["NOTE BOOK"]);
                        }
                        catch { }
                        try
                        {
                            NBsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["NOTE BOOK"]);
                        }
                        catch { }
                        try
                        {
                            NBSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["NOTE BOOK"]);
                        }
                        catch { }
                        try
                        {
                            //NBgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Note Book"]);
                        }
                        catch { }
                        try
                        {
                            NBIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["NOTE BOOK"]);
                        }
                        catch { }
                        try
                        {
                            NBEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["NOTE BOOK"]);
                        }
                        catch { }
                        try
                        {

                            SElang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            SElang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            SEmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            SEsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            SESosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            //SEgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            SEIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {
                            SEEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Sub Enrichment"]);
                        }
                        catch { }
                        try
                        {

                            AElang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["AE"]);
                        }
                        catch { }
                        try
                        {
                            AElang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["AE"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            AEmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["AE"]);
                        }
                        catch { }
                        try
                        {
                            AEsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["AE"]);
                        }
                        catch { }
                        try
                        {
                            AESosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["AE"]);
                        }
                        catch { }
                        try
                        {
                            //AEgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["HY"]);
                        }
                        catch { }
                        try
                        {
                            AEIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["AE"]);
                        }
                        catch { }
                        try
                        {
                            AEEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["AE"]);
                        }
                        catch { }
                        try
                        {

                            totlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Total"]);
                        }
                        catch { }
                        try
                        {
                            totlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Total"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            totmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Total"]);
                        }
                        catch { }
                        try
                        {
                            totsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Total"]);
                        }
                        catch { }
                        try
                        {
                            totSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Total"]);
                        }
                        catch { }
                        try
                        {
                            //totgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Total"]);
                        }
                        catch { }
                        try
                        {
                            totIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Total"]);
                        }
                        catch { }
                        try
                        {
                            totEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Total"]);
                        }
                        catch { }
                        try
                        {

                            grlang1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            grlang2.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            //lang3.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[2]["TotalMark"]);
                            grmath.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            grsci.Text = Convert.ToString(dsObj.Tables[0].Rows[3]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            grSosci.Text = Convert.ToString(dsObj.Tables[0].Rows[4]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            //grgeneral.Text = Convert.ToString(dsObjgrade.Tables[0].Rows[5]["Grade"]);
                        }
                        catch { }
                        try
                        {
                            grIT.Text = Convert.ToString(dsObj.Tables[0].Rows[5]["Grade"]);
                        }
                        catch
                        { }
                        try
                        {
                            grEVS.Text = Convert.ToString(dsObj.Tables[0].Rows[6]["Grade"]);
                        }
                        catch
                        { }
                    }

                    strQry = "exec usp_ExamMarks @type='CoscholasticGradeIXstdannual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                    dsObj = sGetDataset(strQry);
                    if (dsObj.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            WECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);
                        }
                        catch { }
                        try
                        {
                            AECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[1]["GRADE"]);
                        }
                        catch { }
                        try
                        {
                            HPECoscholastic.Text = Convert.ToString(dsObj.Tables[0].Rows[2]["GRADE"]);
                        }
                        catch
                        { }

                    }

                    try
                    {

                        strQry = "exec usp_ExamMarks @type='DisciplineGradeannual',@intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "',@intExam_id='" + Session["Exam_idnum"] + "',@intAcademic_id='" + Session["AcademicID"] + "'";
                        dsObj = sGetDataset(strQry);
                        if (dsObj.Tables[0].Rows.Count > 0)
                        {
                            DisciplineTerm1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["GRADE"]);

                        }
                    }
                    catch
                    {

                    }


                    try
                    {

                        strQry = "select  TeacherRemark from  tblExamAttendance where intStudent_id='" + dsObjgrade.Tables[0].Rows[0 + i]["student_id"] + "' and intExam_id in(select intExam_id from tblExaminationDet where vchExamination_name like 'Annual%')";
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
                    catch { }
                
                }



                crystalReport.Load(Server.MapPath(string.Format("Result_IX.rpt", i)));


                //AdmissionReport.ReportSource = crystalReport;
                //crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, string.Empty);

                stream1 = crystalReport.ExportToStream(ExportFormatType.PortableDocFormat);

                files.Add(PrepareBytes(stream1));

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