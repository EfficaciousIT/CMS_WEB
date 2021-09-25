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

public partial class rpttccertificate : DBUtility
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
        
        

       

       // if (Session["rptAllStudentMark"] != null)
       // {
            //dsObjgrade = (DataSet)Session["rptAllStudentMark"];

            try
            {
                string reportPath = Server.MapPath("rptTCcertificate.rpt");
                crystalReport.Load(reportPath);
                //AdmissionReport.ReportSource = crystalReport;

                TextObject SRNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text41"];
                TextObject AdmissionNo = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text42"];
                TextObject vchStudent_name = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text43"];
                TextObject vchFatherName = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text44"];
                TextObject vchNationalty = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text45"];
                TextObject vchSCST = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text46"];
                TextObject dtAdmission = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text47"];
                TextObject vchAdmissionclass = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text126"];
                TextObject dtDOB = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text49"];
               // TextObject vchDOBword = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text50"];
                TextObject vchlastclassfig = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text51"];
                TextObject vchlastclassword = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text52"];

                TextObject vchanuualexamlast = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text53"];
                TextObject vchsameclass = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text54"];
                TextObject vchsubjectStudied1 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text55"];
                TextObject vchsubjectStudied2 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text56"];
                TextObject vchsubjectStudied3 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text57"];
                TextObject vchsubjectStudied4 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text58"];
                TextObject vchsubjectStudied5 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text12"];
                TextObject vchsubjectStudied6 = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text59"];
                TextObject vchpromotionHigherclass = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text60"];
                TextObject vchpromotionHigherclassFig = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text61"];

                TextObject vchpromotionHigherclassWord = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text62"];
                TextObject vchschoolduepaid = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text63"];
                TextObject vchfeeconcession = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text64"];
                TextObject vchNumberworkingday = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text65"];
                TextObject vchNumberPresentday = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text66"];
                TextObject vchNCC = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text67"];
                TextObject vchExtracurriculam = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text69"];
                TextObject vchGeneralconduct = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text70"];
                TextObject dtApplication = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text71"];
                TextObject dtcertificateissue = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text72"];

                TextObject vchreasonlevaning = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text73"];
                TextObject vchotherremark = (TextObject)crystalReport.ReportDefinition.Sections["Section3"].ReportObjects["Text74"];
                if (Session["rptStudentdetail"] != null)
                {
                    if (Session["rptUpdatedStudentdetail"] == null)
                    {
                        dsObj = (DataSet)Session["rptStudentdetail"];
                    }
                    else if (Session["rptUpdatedStudentdetail"] != null)
                    {
                        dsObj = (DataSet)Session["rptUpdatedStudentdetail"];
                    }
                }
                else
                {
                    strQry = "Execute dbo.usp_TCcertificate @command='Selectrecord',@intAcademic_id='" + Session["AcademicID"] + "'";
                    //strQry = "Execute dbo.usp_Profile @command='ShowProfile' ,@intUser_id='" + Convert.ToString(ddlStudent.SelectedValue) + "',@intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
                    dsObj = sGetDataset(strQry);
                
                }

                //strQry = "Execute dbo.usp_TCcertificate @command='Selectrecord',@intAcademic_id='" + Session["AcademicID"] + "'";
               
                //dsObj = sGetDataset(strQry);
                if (dsObj.Tables[0].Rows.Count > 0)
                {

                    //SRNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["SRNo"]);
                    SRNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["AdmissionNo"]);

                    AdmissionNo.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["BoardRegiNo"]);
                    try{
                    vchStudent_name.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchStudent_name"]);
                    vchStudent_name.Text = char.ToUpper(vchStudent_name.Text[0]) + vchStudent_name.Text.Substring(1);
                        }
                    catch (Exception ex)
                    { }
                    try{
                    vchFatherName.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchFatherName"]);
                    vchFatherName.Text = char.ToUpper(vchFatherName.Text[0]) + vchFatherName.Text.Substring(1);
                        }
                    catch (Exception ex)
                    { }
                    try{
                    vchNationalty.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNationalty"]);
                    vchNationalty.Text = char.ToUpper(vchNationalty.Text[0]) + vchNationalty.Text.Substring(1);
                        }
                    catch (Exception ex)
                    { }
                    try{
                    vchSCST.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchSCST"]);
                    vchSCST.Text = char.ToUpper(vchSCST.Text[0]) + vchSCST.Text.Substring(1);
                        }
                    catch (Exception ex)
                    { }
                    try{
                    dtAdmission.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtAdmission"]).ToString("dd/MM/yyyy");
                    }
                    catch (Exception ex)
                    { }
                    try
                    {
                        vchAdmissionclass.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchAdmissionclass"]);
                        vchAdmissionclass.Text = Convert.ToString(vchAdmissionclass.Text).ToUpper();
                    }
                    catch (Exception ex)
                    { }
                    try{
                    dtDOB.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtDOB"]).ToString("dd/MMMM/yyyy");
                    //vchDOBword.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchDOBword"]); 
                    vchlastclassfig.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchlastclassfig"]);
                    vchlastclassfig.Text = Convert.ToString(vchlastclassfig.Text).ToUpper();
                        }
                    catch (Exception ex)
                    { }
                    try
                    {
                        vchlastclassword.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchlastclassword"]);
                        vchlastclassword.Text = Convert.ToString(vchlastclassword.Text).ToUpper();
                    }
                    catch (Exception ex)
                    { }
                    try{
                    vchanuualexamlast.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchanuualexamlast"]);
                    vchanuualexamlast.Text = Convert.ToString(vchanuualexamlast.Text).ToUpper();
                    }
                    catch (Exception ex)
                    { }
                    try{
                    vchsameclass.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsameclass"]);
                    vchsameclass.Text = char.ToUpper(vchsameclass.Text[0]) + vchsameclass.Text.Substring(1);
                    }
                    catch (Exception ex)
                    { }
                    try{
                    vchsubjectStudied1.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied1"]);
                    vchsubjectStudied1.Text = char.ToUpper(vchsubjectStudied1.Text[0]) + vchsubjectStudied1.Text.Substring(1);
                        }
                    catch (Exception ex)
                    { }
                    try{

                    vchsubjectStudied2.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied2"]);
                    vchsubjectStudied2.Text = char.ToUpper(vchsubjectStudied2.Text[0]) + vchsubjectStudied2.Text.Substring(1);
                        }
                    catch (Exception ex)
                    { }
                    try{

                    vchsubjectStudied3.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied3"]);
                    vchsubjectStudied3.Text = char.ToUpper(vchsubjectStudied3.Text[0]) + vchsubjectStudied3.Text.Substring(1);
                        }
                    catch (Exception ex)
                    { }
                    try{

                    vchsubjectStudied4.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied4"]);
                    vchsubjectStudied4.Text = char.ToUpper(vchsubjectStudied4.Text[0]) + vchsubjectStudied4.Text.Substring(1);
                        }
                    catch (Exception ex)
                    { }
                    try{

                    vchsubjectStudied5.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied5"]);
                    vchsubjectStudied5.Text = char.ToUpper(vchsubjectStudied5.Text[0]) + vchsubjectStudied5.Text.Substring(1);
                        }
                    catch (Exception ex)
                    { }
                    try{

                    vchsubjectStudied6.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchsubjectStudied6"]);
                    vchsubjectStudied6.Text = char.ToUpper(vchsubjectStudied6.Text[0]) + vchsubjectStudied6.Text.Substring(1);
                        }
                    catch (Exception ex)
                    { }
                    try{

                    vchpromotionHigherclass.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpromotionHigherclass"]);
                    vchpromotionHigherclass.Text = Convert.ToString(vchpromotionHigherclass.Text).ToUpper();
                        }
                    catch (Exception ex)
                    { }

                    try{
                    vchpromotionHigherclassFig.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpromotionHigherclassFig"]);
                    vchpromotionHigherclassFig.Text = Convert.ToString(vchpromotionHigherclassFig.Text).ToUpper();

                        }
                    catch (Exception ex)
                    { }
                    
                    try{
                    vchpromotionHigherclassWord.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchpromotionHigherclassWord"]);
                    vchpromotionHigherclassWord.Text = Convert.ToString(vchpromotionHigherclassWord.Text).ToUpper();
                         }
                    catch (Exception ex)
                    { }

                    try{
                    vchschoolduepaid.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchschoolduepaid"]);
                    vchschoolduepaid.Text = char.ToUpper(vchschoolduepaid.Text[0]) + vchschoolduepaid.Text.Substring(1);
                         }
                    catch (Exception ex)
                    { }

                    try{
                    vchfeeconcession.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchfeeconcession"]);
                    vchfeeconcession.Text = char.ToUpper(vchfeeconcession.Text[0]) + vchfeeconcession.Text.Substring(1);
                         }
                    catch (Exception ex)
                    { }

                    try{
                    vchNumberworkingday.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNumberworkingday"]);

                    vchNumberPresentday.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNumberPresentday"]);
                         }
                    catch (Exception ex)
                    { }

                    try{
                    vchNCC.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchNCC"]);
                    vchNCC.Text = char.ToUpper(vchNCC.Text[0]) + vchNCC.Text.Substring(1);
                         }
                    catch (Exception ex)
                    { }

                    try{
                    vchExtracurriculam.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchExtracurriculam"]);
                    vchExtracurriculam.Text = char.ToUpper(vchExtracurriculam.Text[0]) + vchExtracurriculam.Text.Substring(1);
                         }
                    catch (Exception ex)
                    { }

                    try{
                    vchGeneralconduct.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchGeneralconduct"]);
                    vchGeneralconduct.Text = char.ToUpper(vchGeneralconduct.Text[0]) + vchGeneralconduct.Text.Substring(1);
                         }
                    catch (Exception ex)
                    { }

                    try{
                    dtApplication.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtApplication"]).ToString("dd/MM/yyyy"); 
                    dtcertificateissue.Text = Convert.ToDateTime(dsObj.Tables[0].Rows[0]["dtcertificateissue"]).ToString("dd/MM/yyyy");  
                         }
                    catch (Exception ex)
                    { }

                    try{
                    vchreasonlevaning.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchreasonlevaning"]);
                    vchreasonlevaning.Text = char.ToUpper(vchreasonlevaning.Text[0]) + vchreasonlevaning.Text.Substring(1);
                         }
                    catch (Exception ex)
                    { }

                    try{
                    vchotherremark.Text = Convert.ToString(dsObj.Tables[0].Rows[0]["vchotherremark"]);
                    vchotherremark.Text = char.ToUpper(vchotherremark.Text[0]) + vchotherremark.Text.Substring(1);
                         }
                    catch (Exception ex)
                    { }

                    
                }
                crystalReport.Load(Server.MapPath(string.Format("rptTCcertificate.rpt")));
                //AdmissionReport.ReportSource = crystalReport;
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, string.Empty);
                
            }
            catch
            { 
            
            }
       // }

    }
}