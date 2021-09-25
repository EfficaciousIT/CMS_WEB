using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Globalization;
using System.Web.Script.Services;
using System.Web.Services;

namespace CentralModelServices
{
    /// <summary>
    /// Summary description for CentralModelService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CentralModelService : System.Web.Services.WebService
    {
        public CentralModelService()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        string connectionString = "Data Source=103.255.188.128;Initial Catalog=DBCentralModel;User Id=sa;Password=SA@Admin;Max Pool Size=5000;";
        //string connectionString = "Data Source=103.255.188.128;Initial Catalog=DBLincoln;User Id=sa;Password=SA@Admin;Max Pool Size=5000;";
        //string connectionString = ConfigurationManager.ConnectionStrings["esms"].ToString();
        string sp_Name = String.Empty;
        SqlConnection Conn = null;
        SqlConnection Con = null;
        SqlCommand Cmd;
        DataSet ds;
        SqlDataAdapter da;
        string strJSON = String.Empty;

        [WebMethod]
        public XmlElement LoginDetails(string command, string userType_id, string userName, string password, string intschool_id, string intAcademic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_usermaster @command='" + command + "',@usertype='" + userType_id + "',@username='" + userName + "',@password='" + password + "',@intschool_id='" + intschool_id + "',@intAcademic_id='" + intAcademic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "LoginDetails");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod(Description = "JSON example demo")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Login(string command, string userType_id, string userName, string password, string intschool_id, string intAcademic_id)
        {
            try
            {
               
                sp_Name = "usp_Mob_usermaster @command='" + command + "',@usertype='" + userType_id + "',@username='" + userName + "',@password='" + password + "',@intschool_id='" + intschool_id + "',@intAcademic_id='" + intAcademic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Login");
                
                // Create a multidimensional jagged array
                string[][] JaggedArray = new string[ds.Tables[0].Rows.Count][];
                int i = 0;
                foreach (DataRow rs in ds.Tables[0].Rows)
                {
                    JaggedArray[i] = new string[] 
                    {
                        rs["intUserType_id"].ToString(),
                        rs["intAdmin_id"].ToString(),
                        rs["vchFirst_name"].ToString(),
                        rs["vchLast_name"].ToString(),
                        rs["name"].ToString(),
                        rs["vchUser_name"].ToString(),
                        rs["vchPassword"].ToString()
                    };
                    i = i + 1;
                }

                // Return JSON data
                JavaScriptSerializer js = new JavaScriptSerializer();
                strJSON = js.Serialize(JaggedArray);
                return strJSON;

            }
            catch (Exception ex)
            {
                return strJSON = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Profiler(string command, string user_id, string academic_id, string intschool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_profiler @command='" + command + "',@intUser_id='" + user_id + "',@intAcademic_id='" + academic_id + "',@intschool_id='" + intschool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Profiler");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement ProfileForStudents(string command, string User_id, string name, string email, string address, string mobile, string image, string vchLastName, string academic_id, string intschool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_profiler @command='" + command + "',@intUser_id='" + User_id + "',@vchStudentName='" + name + "',@vchEmailAddress='" + email + "',@vchAddress='" + address + "',@vchMobileNo='" + mobile + "',@vchProfile='" + image + "',@vchLastName='" + vchLastName + "',@intAcademic_id='" + academic_id + "',@intschool_id='" + intschool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "ProfileForStudents");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement ProfileForTeacher(string command, string User_id, string name, string email, string address, string mobile, string image, string vchLastName, string academic_id, string intschool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_profiler @command='" + command + "',@intUser_id='" + User_id + "',@vchTeacherName='" + name + "',@vchEmailAddress='" + email + "',@vchAddress='" + address + "',@vchMobileNo='" + mobile + "',@vchProfile='" + image + "',@vchLastName='" + vchLastName + "',@intAcademic_id='" + academic_id + "',@intschool_id='" + intschool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "ProfileForTeacher");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement ProfileForStaff(string command, string User_id, string name, string email, string address, string mobile, string image, string academic_id, string intschool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_profiler @command='" + command + "',@intUser_id='" + User_id + "',@vchStaffName='" + name + "',@vchEmailAddress='" + email + "',@vchAddress='" + address + "',@vchMobileNo='" + mobile + "',@vchProfile='" + image + "',@intAcademic_id='" + academic_id + "',@intschool_id='" + intschool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "ProfileForStaff");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement ProfileForAdmin(string command, string User_id, string name, string email, string address, string mobile, string image, string vchLastName, string academic_id, string intschool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_profiler @command='" + command + "',@intUser_id='" + User_id + "',@vchAdminName='" + name + "',@vchEmailAddress='" + email + "',@vchAddress='" + address + "',@vchMobileNo='" + mobile + "',@vchProfile='" + image + "',@vchLastName='" + vchLastName + "',@intAcademic_id='" + academic_id + "',@intschool_id='" + intschool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "ProfileForAdmin");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }


        [WebMethod]
        public XmlElement HolidayList(string command, string academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_setHolidayList @type='" + command + "',@intAcademic_id='" + academic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "HolidayList");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Feecollection(string school_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_getFeeTillDate @intschool_id='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Feecollection");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentList(string command, string school_id, string academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "', @SchoolId='" + school_id + "', @AcademicID='" + academic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentList");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentCountList(string command, string school_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "', @SchoolId='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentCountList");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement TeacherCountList(string command, string school_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "', @SchoolId='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "TeacherCountList");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StaffCountList(string command, string school_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "', @SchoolId='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StaffCountList");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }


        [WebMethod]
        public XmlElement AdminCountList(string command, string school_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "', @SchoolId='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "AdminCountList");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }


        [WebMethod]
        public XmlElement AdminNoticeboard(string command, string school_id, string intStandard_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "', @SchoolId='" + school_id + "',@intStandard_id='" + intStandard_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "AdminNoticeboard");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement SubjectList(string command)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_Subject @command='" + command + "'";//, @intstandard_id ='" + std_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "SubjectList");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Standard(string command, string intTeacher_id, string intAcademic_id, string intStandard_id, string intDivision_id, string vchType, string intSchool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_Statndard @command='" + command + "',@intTeacher_id='" + intTeacher_id + "',@intAcademic_id='" + intAcademic_id + "',@intStandard_id='" + intStandard_id + "',@intDivision_id='" + intDivision_id + "',@vchType='" + vchType + "',@intSchool_id='" + intSchool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Standard");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement AllStandardSMS(string command, string school_id, string academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "', @SchoolId ='" + school_id + "',@AcademicID='" + academic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "AllStandardSMS");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StandardSMS(string command, string standard_id, string division_id, string school_id, string academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "',@DIV ='" + division_id + "',@STD ='" + standard_id + "', @SchoolId ='" + school_id + "', @AcademicID ='" + academic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StandardSMS");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public XmlElement Division(string command, string standard, string intTeacher_id, string intAcademic_id, string intSchool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_Statndard @command='" + command + "', @intStandard_id ='" + standard + "', @intTeacher_id ='" + intTeacher_id + "', @intAcademic_id ='" + intAcademic_id + "', @intSchool_id ='" + intSchool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Division");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }


        [WebMethod]
        public XmlElement StaffSMS(string command, string school_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "',@SchoolId='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StaffSMS");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StandardWiseSubject(string command, string standard_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StandardwiseSubject @command='" + command + "', @Standard_id ='" + standard_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StandardWiseSubject");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Exam(string command)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_ExamType @command='" + command + "'";//, @intstandard_id ='" + std_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Exam");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentChangePassword(string command, string userName, string password, string intUserType_id, string academic_id, string intschool_id, string User_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_Studentchangepassword @command='" + command + "', @userName ='" + userName + "',@password ='" + password + "',@User_id ='" + User_id + "',@intAcademic_id ='" + academic_id + "',@intschool_id='" + intschool_id + "',@intUserType_id='" + intUserType_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentChangePassword");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement VacationList(string command, string academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_setVacationList @type='" + command + "',@intAcademic_id='" + academic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "VacationList");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentProfile(string command, string Student_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StudentProfile @command='" + command + "', @intstudent_id='" + Student_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentProfile");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Student(string command, string standard_id, string division_id, string academic_id, string intschool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_Student @command='" + command + "',@Standard_id='" + standard_id + "',@Division_id='" + division_id + "',@Academic_id='" + academic_id + "',@intschool_id='" + intschool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Student");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentAttSummery(string command, string school_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_MOB_Attendacesummary @command='" + command + "', @intschool_id='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentAttSummery");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Studentcount(string command, string school_id, string academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "', @SchoolId='" + school_id + "',@AcademicID='" + academic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Studentcount");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Teacher(string command, string intSchool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_Teacher @command='" + command + "',@intSchool_id='" + intSchool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Teacher");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Teachercount(string command, string school_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "', @SchoolId='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Teachercount");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Staffcount(string command, string school_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_NewAdminDashboard @type='" + command + "', @SchoolId='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Staffcount");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }


        //[WebMethod]
        //public XmlElement TeacherTimeTable(string command, string teacher_id)
        //{
        //    XmlDataDocument xmldata;
        //    XmlElement xmlElement;
        //    try
        //    {
        //        sp_Name = "usp_Mob_TeacherTimeTable @command='" + command + "', @intTeacher_id='" + teacher_id + "'";
        //        DataSet ds = new DataSet();
        //        SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
        //        da.Fill(ds, "TeacherTimeTable");
        //        xmldata = new XmlDataDocument(ds);
        //        xmlElement = xmldata.DocumentElement;
        //        return xmlElement;
        //    }
        //    catch (Exception ex)
        //    {
        //        return xmlElement = null;
        //    }
        //    finally
        //    {
        //        if (sp_Name != null)
        //            sp_Name = null;
        //    }
        //}

        [WebMethod]
        public XmlElement StudentTimeTable(string command, string std_id, string day, string intSchool_id, string intAcademic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StudentTimeTable @command='" + command + "', @Std='" + std_id + "', @Day='" + day + "', @intSchool_id='" + intSchool_id + "', @intAcademic_id='" + intAcademic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentTimeTable");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }


        [WebMethod]
        public XmlElement TeacherTimeTable(string command, string teacher_id, string day, string academic_id, string intSchool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_TeacherTimeTable @command='" + command + "', @Teacher_id='" + teacher_id + "', @Day='" + day + "',@intAcademic_id='" + academic_id + "',@intSchool_id='" + intSchool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "TeacherTimeTable");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentExamTimetable(string command, string std_id, string academic_id, string intSchool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StudentExamTimetable @command='" + command + "', @intstandard_id='" + std_id + "', @intAcademic_id='" + academic_id + "',@intSchool_id='" + intSchool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentExamTimetable");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Staff(string command)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_Staff @command='" + command + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Staff");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Admin(string command)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_Admin @command='" + command + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Admin");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement Syllabus(string command, string Std_id, string sub_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_SYllabus @command='" + command + "',@intstandard_id='" + Std_id + "',@intsubject_id='" + sub_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Syllabus");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentSyllabus(string command, string Std_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StudentSyllabus @command='" + command + "',@intstandard_id='" + Std_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentSyllabus");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentNoticeboard(string command, string std_id, string academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StudentNoticeboard @command='" + command + "',@intstandard_id='" + std_id + "',@intAcademic_id='" + academic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentNoticeboard");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentBookAssigned(string command, string stud_id, string intschool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StudentBookAssigned @command='" + command + "',@intStudent_id='" + stud_id + "',@intschool_id='" + intschool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentBookAssigned");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement TeacherProfile(string command, string teacher_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_TeacherProfile @command='" + command + "',@intTEacher_id='" + teacher_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "TeacherProfile");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement AdminProfile(string command, string admin_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_AdminProfile @command='" + command + "',@intAdmin_id='" + admin_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "AdminProfile");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentAttendance(string command, string stud_id, string month_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StudentAttendance @command='" + command + "',@Student_id='" + stud_id + "', @Month_id='" + month_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentAttendance");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentPresent(string command, string date)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StudentPresent @command='" + command + "', @Date='" + date + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentPresent");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement TeacherPresent(string command, string date)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_TeacherPresent @command='" + command + "', @Date='" + date + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "TeacherPresent");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StaffPresent(string command, string date)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StaffPresent @command='" + command + "', @Date='" + date + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StaffPresent");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }



        [WebMethod]
        public XmlElement StudentAttendanceSummery(string command, string student_id, string academic_id, string intSchool_Id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StudentAttendanceSummery @command='" + command + "', @Student_id='" + student_id + "', @intAcademic_id='" + academic_id + "', @intSchool_Id='" + intSchool_Id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentAttendanceSummery");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement AdminAttendanceSummery(string command, string admin_id, string academic_id, string school_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_AdminAttendanceSummery @command='" + command + "', @Admin_id='" + admin_id + "', @intAcademic_id='" + academic_id + "',@intSchool_Id='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "AdminAttendanceSummery");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement TeacherAttendanceSummery(string command, string teacher_id, string academic_id, string intSchool_Id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_TeacherAttendanceSummery @command='" + command + "', @Teacher_id='" + teacher_id + "', @intAcademic_id='" + academic_id + "', @intSchool_Id='" + intSchool_Id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "TeacherAttendanceSummery");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StudentTabular(string command, string intstudent_id, string year)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_MOB_Attendacesummary @command='" + command + "', @intStudent_id='" + intstudent_id + "', @year='" + year + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StudentTabular");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public XmlElement StaffAttendanceSummery(string command, string staff_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_StaffAttendanceSummery @command='" + command + "', @Staff_id='" + staff_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StaffAttendanceSummery");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public XmlElement BookDetailsLibrary(string command, string standard_id, string School_d)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_BookDetails @command='" + command + "', @intStandard_id='" + standard_id + "', @intschool_id='" + School_d + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StaffAttendanceSummery");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }

        [WebMethod]
        public Boolean MarkAttendence(string dtDateSelected, string command, string intschool_id, string intUserType_id, string intUser_id, string dtDate, string status, string intstanderd_id, string intdivision_id, string intAcademic_id, string FCMToken)
        {
            try
            {
                sp_Name = "usp_Mob_MarkAttendance";
                Conn = new SqlConnection(connectionString);
                Cmd = new SqlCommand(sp_Name, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@command", command);
                Cmd.Parameters.AddWithValue("@intschool_id", intschool_id);
                Cmd.Parameters.AddWithValue("@intUserType_id", intUserType_id);
                Cmd.Parameters.AddWithValue("@intUser_id", intUser_id);
                Cmd.Parameters.AddWithValue("@dtDate", dtDate);
                Cmd.Parameters.AddWithValue("@status", status);
                Cmd.Parameters.AddWithValue("@intstanderd_id", intstanderd_id);
                Cmd.Parameters.AddWithValue("@intdivision_id", intdivision_id);
                Cmd.Parameters.AddWithValue("@intAcademic_id", intAcademic_id);
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();
                //string regId = "f-SirJyFN7k:APA91bGqa38apb97PTGHJ7-KxcCigw8_OQhr903g3sHe10Nd6sPhWfZWQtgKXDvlRPE4cb0CZQmiGrsnYWLbs6vrbinOtlusAmKWan_5g7LOrXcG5O4O4dgFoaAPwa2Z6F9n5WBK9mAI";
                string regId = FCMToken.ToString().Trim();
                var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                var value = "";
                string title = "Message Center";
                var SENDER_ID = "154368864541";
                // 73064704159
                if (status == "Present")
                {
                    value = "You are marked Present as on " + dtDateSelected;
                }
                else
                {
                    value = "You are marked Absent as on " + dtDateSelected;
                }

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                    + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";

                Console.WriteLine(postData);
                Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                tRequest.ContentLength = byteArray.Length;

                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                String sResponseFromServer = tReader.ReadToEnd();

                //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                //txtStream.Text = postData.ToString().Trim();
                tReader.Close();
                dataStream.Close();
                tResponse.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }


        [WebMethod]
        public XmlElement GetMarkAttendence(string command, string intschool_id, string intUserType_id, string dtDate, string intstanderd_id, string intdivision_id, string intAcademic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_GetMarkAttendance @command='" + command + "',@intschool_id='" + intschool_id + "',@intUserType_id='" + intUserType_id + "', @dtDate='" + dtDate + "',@intstanderd_id='" + intstanderd_id + "',@intdivision_id='" + intdivision_id + "',@intAcademic_id='" + intAcademic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Student");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public Boolean FCMTokenUpdate(string command, string vchFCMToken, string vchEmail, string intUser_id, string intSchool_id, string intAcademic_id)
        {
            try
            {
                sp_Name = "usp_LoginDetails";
                Conn = new SqlConnection(connectionString);
                Cmd = new SqlCommand(sp_Name, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@command", command);
                Cmd.Parameters.AddWithValue("@vchFCMToken", vchFCMToken);
                Cmd.Parameters.AddWithValue("@vchEmail", vchEmail);
                Cmd.Parameters.AddWithValue("@intUser_id", intUser_id);
                Cmd.Parameters.AddWithValue("@intSchool_id", intSchool_id);
                Cmd.Parameters.AddWithValue("@intAcademic_id", intAcademic_id);
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }
        [WebMethod]
        public XmlElement ChatUsersName(string command, string standard_id, string division_id, string academic_id, string intUserId, string intschool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_ChatUser @command='" + command + "',@Standard_id='" + standard_id + "',@Division_id='" + division_id + "', @Academic_id='" + academic_id + "', @intUser_id='" + intUserId + "',@intschool_id='" + intschool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "Student");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public Boolean ChatMessage(string User_id, string FCMToken, string Message, string ReceiverName, string SenderName, string SenderFCMToken, string UserTypeId)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                string regId = FCMToken.ToString().Trim();
                var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                var value = Message.Trim();
                string userid = User_id.Trim();
                string title = "IndividualChat";
                var SENDER_ID = "154368864541";
                string ReceivrName = ReceiverName.Trim();
                string RecieverFCMTOken = FCMToken.Trim();
                string Sendername = SenderName.Trim();
                string senderFCMToken = SenderFCMToken.Trim();
                string UserTypeid = UserTypeId.Trim();
                WebRequest tRequest;
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                    + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "&data.userid=" + userid + "&data.ReceivrName=" + ReceivrName + "&data.RecieverFCMTOken=" + RecieverFCMTOken + "&data.Sendername=" + Sendername + "&data.senderFCMToken=" + senderFCMToken + "&data.UserTypeid=" + UserTypeid + "";

                Console.WriteLine(postData);
                Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                tRequest.ContentLength = byteArray.Length;

                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                String sResponseFromServer = tReader.ReadToEnd();

                //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                //txtStream.Text = postData.ToString().Trim();
                tReader.Close();
                dataStream.Close();
                tResponse.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public Boolean GPSTracker(string command, string latitude, string longitude, string timing, string speed, string altitude)
        {
            try
            {
                sp_Name = "usp_Mob_GPSTracker";
                Conn = new SqlConnection(connectionString);
                Cmd = new SqlCommand(sp_Name, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@command", command);
                Cmd.Parameters.AddWithValue("@Latitude", latitude);
                Cmd.Parameters.AddWithValue("@Longitude", longitude);
                Cmd.Parameters.AddWithValue("@Timing", timing);
                Cmd.Parameters.AddWithValue("@Speed", speed);
                Cmd.Parameters.AddWithValue("@Altitude", altitude);

                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }
        [WebMethod]
        public Boolean AddGroup(string command, string Created_UserId, string UserTypeId, string Created_User_Email_id, string GroupName, string Craeted_Date, string Group_Member_Id, string FCMToken, string intGroup_id, string Group_Member_Name)
        {
            try
            {
                sp_Name = "usp_Mob_GroupChat";
                Conn = new SqlConnection(connectionString);
                Cmd = new SqlCommand(sp_Name, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@command", command);
                Cmd.Parameters.AddWithValue("@Created_UserId", Created_UserId);
                Cmd.Parameters.AddWithValue("@UserTypeId", UserTypeId);
                Cmd.Parameters.AddWithValue("@Created_User_Email_id", Created_User_Email_id);
                Cmd.Parameters.AddWithValue("@vchGroup_name", GroupName);
                Cmd.Parameters.AddWithValue("@Craeted_Date", Craeted_Date);
                Cmd.Parameters.AddWithValue("@Group_Member_Id", Group_Member_Id);
                Cmd.Parameters.AddWithValue("@Group_Member_FCMToken", FCMToken);
                Cmd.Parameters.AddWithValue("@intGroup_id", intGroup_id);
                Cmd.Parameters.AddWithValue("@Group_Member_Name", Group_Member_Name);
                //Cmd.Parameters.AddWithValue("@IMEI_Number", IMEI_Number);
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }
        [WebMethod]
        public XmlElement ADDGroupName(string command, string GroupName, string intUserType_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_GroupChat @command='" + command + "',@vchGroup_name='" + GroupName + "',@intUserType_id='" + intUserType_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "GroupName");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public XmlElement ChatUsersGroupName(string command, string intUserType_id, string vchGroupMemeber_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_GroupChatUser @command='" + command + "',@intUserType_id='" + intUserType_id + "',@vchGroupMemeber_id='" + vchGroupMemeber_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "GroupName");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public Boolean ChatGroupMessageForTeacher(string Standard_id, string Division_id, string Message, string SenderName, string GRoupName, string intSchool_id, string Academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {

                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection(connectionString);
                string SqlString = "";
                SqlString = "select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken!='' and intstanderd_id='" + Standard_id + "' and intDivision_id='" + Division_id + "' and intschool_id='" + intSchool_id + "' and intAcademic_id='" + Academic_id + "'";
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);


                string s = Message.Trim();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string regId = dt.Rows[i]["vchFCMToken"].ToString();
                    var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                    string message = Message.Trim();
                    string title = "Group";
                    string Sendername = SenderName;
                    string GroupName = GRoupName;
                    var SENDER_ID = "154368864541";
                    var value = Message.Trim();
                    WebRequest tRequest;
                    tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                    string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                        + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "&data.Sendername=" + Sendername + "&data.GroupName=" + GroupName + "&data.Standard_id=" + Standard_id + "&data.Division_id=" + Division_id + "";
                    Console.WriteLine(postData);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    tRequest.ContentLength = byteArray.Length;
                    Stream dataStream = tRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    WebResponse tResponse = tRequest.GetResponse();
                    dataStream = tResponse.GetResponseStream();
                    StreamReader tReader = new StreamReader(dataStream);
                    String sResponseFromServer = tReader.ReadToEnd();
                    //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                    //txtStream.Text = postData.ToString().Trim();
                    tReader.Close();
                    dataStream.Close();
                    tResponse.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }


        [WebMethod]
        public Boolean ChatGroupMessageForStudent(string Standard_id, string Division_id, string Message, string SenderName, string GRoupName, string SenderId, string intSchool_id, string Academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {

                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection(connectionString);
                string SqlString = "";
                SqlString = "select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken!='' and intstanderd_id='" + Standard_id + "' and intDivision_id='" + Division_id + "' and intStudent_id not in('" + SenderId + "') and intschool_id='" + intSchool_id + "' and intAcademic_id='" + Academic_id + "'";
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);


                string s = Message.Trim();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string regId = dt.Rows[i]["vchFCMToken"].ToString();
                    var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                    string message = Message.Trim();
                    string title = "Group";
                    string Sendername = SenderName;
                    string GroupName = GRoupName;
                    var SENDER_ID = "154368864541";
                    var value = Message.Trim();
                    WebRequest tRequest;
                    tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                    string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                        + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "&data.Sendername=" + Sendername + "&data.GroupName=" + GroupName + "&data.Standard_id=" + Standard_id + "&data.Division_id=" + Division_id + "";
                    Console.WriteLine(postData);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    tRequest.ContentLength = byteArray.Length;
                    Stream dataStream = tRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    WebResponse tResponse = tRequest.GetResponse();
                    dataStream = tResponse.GetResponseStream();
                    StreamReader tReader = new StreamReader(dataStream);
                    String sResponseFromServer = tReader.ReadToEnd();
                    //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                    //txtStream.Text = postData.ToString().Trim();
                    tReader.Close();
                    dataStream.Close();
                    tResponse.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public Boolean ChatGroupMessageFromStudentToTeacher(string Standard_id, string Division_id, string Message, string SenderName, string GRoupName, string TeacherId, string intSchool_id, string Academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {

                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection(connectionString);
                string SqlString = "";
                SqlString = "select  vchFCMToken from tblTeacher_Master where intTeacher_id='" + TeacherId + "' and vchFCMToken IS NOT NULL and vchFCMToken!='' and intSchool_id='" + intSchool_id + "'";
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);


                string s = Message.Trim();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string regId = dt.Rows[i]["vchFCMToken"].ToString();
                    var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                    string message = Message.Trim();
                    string title = "Group";
                    string Sendername = SenderName;
                    string GroupName = GRoupName;
                    var SENDER_ID = "154368864541";
                    var value = Message.Trim();
                    WebRequest tRequest;
                    tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                    string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                        + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "&data.Sendername=" + Sendername + "&data.GroupName=" + GroupName + "&data.Standard_id=" + Standard_id + "&data.Division_id=" + Division_id + "";
                    Console.WriteLine(postData);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    tRequest.ContentLength = byteArray.Length;
                    Stream dataStream = tRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    WebResponse tResponse = tRequest.GetResponse();
                    dataStream = tResponse.GetResponseStream();
                    StreamReader tReader = new StreamReader(dataStream);
                    String sResponseFromServer = tReader.ReadToEnd();
                    //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                    //txtStream.Text = postData.ToString().Trim();
                    tReader.Close();
                    dataStream.Close();
                    tResponse.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public XmlElement LeaveApply(string command, string vchLeaveType, string UserName, string userType_id, string Type_id, string User_id, string From_date, string To_date, string Reason, string days, string adminApproval, string school_id, string leavetype_id, string year_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_LeaveApply @command='" + command + "',@intUserType_id='" + userType_id + "',@intType_id='" + Type_id + "',@intUser_id='" + User_id + "',@dtFrom_date='" + DateTime.Parse(From_date) + "',@dtTo_Date='" + DateTime.Parse(To_date) + "',@vchReason='" + Reason + "',@intTotalDays='" + days + "',@bitAdminApproval='" + adminApproval + "',@intSchool_id='" + school_id + "', @intLeaveType_id='" + leavetype_id + "',@intAcademic_id='" + year_id + "',@vchLeaveType='" + vchLeaveType + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "LeaveApply");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;

                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection(connectionString);
                string SqlString = "";

                if (command == "insert")
                {
                    SqlString = "select vchFCMToken from tblAdmin_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intSchool_id='" + school_id + "' union  select vchFCMToken from tblPrincipal_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' union  select vchFCMToken from tblManager_Master where vchFCMToken IS NOT NULL and vchFCMToken<>''";

                    SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string regId = dt.Rows[i]["vchFCMToken"].ToString();
                        var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                        string title = "LeaveApply";

                        var SENDER_ID = "154368864541";
                        String message = "" + UserName + " applied For Leave ";
                        var value = message.Trim();
                        WebRequest tRequest;
                        tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                        tRequest.Method = "post";
                        tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                        tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                        tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                        string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                            + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";
                        Console.WriteLine(postData);
                        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                        tRequest.ContentLength = byteArray.Length;
                        Stream dataStream = tRequest.GetRequestStream();
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();
                        WebResponse tResponse = tRequest.GetResponse();
                        dataStream = tResponse.GetResponseStream();
                        StreamReader tReader = new StreamReader(dataStream);
                        String sResponseFromServer = tReader.ReadToEnd();
                        //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                        //txtStream.Text = postData.ToString().Trim();
                        tReader.Close();
                        dataStream.Close();
                        tResponse.Close();

                    }
                }
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public XmlElement LeaveDetails(string command, string intTeacher_id, string intCL, string intML, string bitAdminApproval, string intUser_id, string Usertype, string userType_id, string User_id, string year_id, string school_id, string leaveApplication_id)
        {

            string msg;
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_LeaveApply @command='" + command + "',@bitAdminApproval='" + bitAdminApproval + "',@intUserType_id='" + userType_id + "',@intUser_id='" + User_id + "',@intSchool_id='" + school_id + "',@intAcademic_id='" + year_id + "',@intLeaveApplocation_id='" + leaveApplication_id + "',@intTeacher_id='" + intTeacher_id + "',@intCL='" + intCL + "',@intML='" + intML + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "LeaveDetails");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection(connectionString);
                string SqlString = "";

                if (command == "UpdateStatus")
                {
                    if (Usertype == "Teacher")
                    {
                        if (bitAdminApproval == "2")
                        {
                            SqlString = "select vchFCMToken from tblTeacher_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intTeacher_id='" + intUser_id + "'";
                            msg = "Your Leave has been Rejected";
                        }
                        else
                        {
                            msg = "Your Leave has been Approved";
                            SqlString = "select vchFCMToken from tblTeacher_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intTeacher_id='" + intUser_id + "'";
                        }
                    }
                    else
                    {

                        if (bitAdminApproval == "2")
                        {
                            SqlString = "select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intStudent_id='" + intUser_id + "'";
                            msg = "Your Leave has been Rejected";
                        }
                        else
                        {
                            msg = "Your Leave has been Approved";
                            SqlString = "select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intStudent_id='" + intUser_id + "'";
                        }

                    }


                    SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string regId = dt.Rows[i]["vchFCMToken"].ToString();
                        var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                        string title = "Leave Approval";

                        var SENDER_ID = "154368864541";
                        String message = msg;
                        var value = message.Trim();
                        WebRequest tRequest;
                        tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                        tRequest.Method = "post";
                        tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                        tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                        tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                        string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                            + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";
                        Console.WriteLine(postData);
                        Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                        tRequest.ContentLength = byteArray.Length;
                        Stream dataStream = tRequest.GetRequestStream();
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        dataStream.Close();
                        WebResponse tResponse = tRequest.GetResponse();
                        dataStream = tResponse.GetResponseStream();
                        StreamReader tReader = new StreamReader(dataStream);
                        String sResponseFromServer = tReader.ReadToEnd();
                        //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                        //txtStream.Text = postData.ToString().Trim();
                        tReader.Close();
                        dataStream.Close();
                        tResponse.Close();

                    }
                }
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public XmlElement TeacherLeaveDetails(string command, string school_id, String AcademicID)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_LeaveApply @command='" + command + "',@intSchool_id='" + school_id + "',@intAcademic_id='" + AcademicID + "'";//,@intSchool_id='" + school_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "TeacherLeaveDetails");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public Boolean DailyDiary(string command, string messageStatus, string intAcademic_id, string vchFilePath2, string vchFilePath3, string TeacherName, string StandardName, string DivisionName, string SubjectName, string int_Approval, string vchComment, string intTeacher_id, string intSubject_id, string intStandard_id, string intDivision_id, string dtDatetime, string intSchool_id, string vchType, string vchFileName, string vchFilePath, string intMy_id)
        {
            try
            {
                string message = "";
                sp_Name = "usp_Mob_DailyDiary";
                Conn = new SqlConnection(connectionString);
                Cmd = new SqlCommand(sp_Name, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@command", command);
                Cmd.Parameters.AddWithValue("@vchComment", vchComment);
                Cmd.Parameters.AddWithValue("@intTeacher_id", intTeacher_id);
                Cmd.Parameters.AddWithValue("@intSubject_id", intSubject_id);
                Cmd.Parameters.AddWithValue("@intStandard_id", intStandard_id);
                Cmd.Parameters.AddWithValue("@intDivision_id", intDivision_id);
                Cmd.Parameters.AddWithValue("@dtDatetime", dtDatetime);
                Cmd.Parameters.AddWithValue("@intSchool_id", intSchool_id);
                Cmd.Parameters.AddWithValue("@vchType", vchType);
                Cmd.Parameters.AddWithValue("@vchFileName", vchFileName);
                Cmd.Parameters.AddWithValue("@vchFilePath", vchFilePath);
                Cmd.Parameters.AddWithValue("@vchFilePath2", vchFilePath2);
                Cmd.Parameters.AddWithValue("@vchFilePath3", vchFilePath3);
                Cmd.Parameters.AddWithValue("@int_Approval", int_Approval);
                Cmd.Parameters.AddWithValue("@intMy_id", intMy_id);
                Cmd.Parameters.AddWithValue("@intAcademic_id", intAcademic_id);
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();

                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection(connectionString);
                string SqlString = "";

                if (command == "Insert" && vchType == "HomeWork")
                {
                    SqlString = "select vchFCMToken from tblAdmin_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intSchool_id='" + intSchool_id + "'";
                    message = "A new Home Work is added by " + TeacherName + " for Standard " + StandardName + " Division " + DivisionName + " for Subject " + SubjectName + "";
                }
                else if (command == "Update" && int_Approval == "1")
                {
                    SqlString = " select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intstanderd_id=" + intStandard_id + " and intDivision_id=" + intDivision_id + " ";
                    vchType = "HomeWork";
                    message = "A new Home Work is added for " + SubjectName + "";
                }
                else if (command == "Update" && int_Approval == "2" && messageStatus == "1")
                {
                    SqlString = " select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intstanderd_id=" + intStandard_id + " and intDivision_id=" + intDivision_id + " ";
                    vchType = "HomeWork";
                    message = " Home Work is Cancelled for " + SubjectName + "";
                }
                else if (command == "Insert" && vchType == "DailyDiary")
                {
                    SqlString = "select vchFCMToken from tblAdmin_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intSchool_id='" + intSchool_id + "' union  select vchFCMToken from tblPrincipal_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' union  select vchFCMToken from tblManager_Master where vchFCMToken IS NOT NULL and vchFCMToken<>''";
                    message = "A new DailyDiary is added by " + TeacherName + " for Standard " + StandardName + " Division " + DivisionName + " for Subject " + SubjectName + "";
                }
                else
                {
                }

                SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string regId = dt.Rows[i]["vchFCMToken"].ToString();
                    var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                    string title = vchType;

                    var SENDER_ID = "154368864541";
                    var value = message.Trim();
                    WebRequest tRequest;
                    tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                    string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                        + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";
                    Console.WriteLine(postData);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    tRequest.ContentLength = byteArray.Length;
                    Stream dataStream = tRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    WebResponse tResponse = tRequest.GetResponse();
                    dataStream = tResponse.GetResponseStream();
                    StreamReader tReader = new StreamReader(dataStream);
                    String sResponseFromServer = tReader.ReadToEnd();
                    //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                    //txtStream.Text = postData.ToString().Trim();
                    tReader.Close();
                    dataStream.Close();
                    tResponse.Close();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }

        [WebMethod]
        public Boolean galleryData(string command, string FileName, string EventDescription, string Uploadedfrom, string Filetype)
        {
            try
            {
                sp_Name = "usp_Mob_galleryData";
                Conn = new SqlConnection(connectionString);
                Cmd = new SqlCommand(sp_Name, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@command", command);
                Cmd.Parameters.AddWithValue("@FileName", FileName);
                Cmd.Parameters.AddWithValue("@EventDescription", EventDescription);
                // Cmd.Parameters.AddWithValue("@Path", Path);
                Cmd.Parameters.AddWithValue("@Uploadedfrom", Uploadedfrom);
                Cmd.Parameters.AddWithValue("@Filetype", Filetype);
                //Cmd.Parameters.AddWithValue("@image", image);
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();


                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection(connectionString);
                string SqlString = "";
                SqlString = "select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' union select vchFCMToken from tblTeacher_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' union select vchFCMToken from tblAdmin_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' union select vchFCMToken from tblPrincipal_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' union select vchFCMToken from tblManager_Master where vchFCMToken IS NOT NULL and vchFCMToken<>''";
                SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string regId = dt.Rows[i]["vchFCMToken"].ToString();
                    var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2
                    string message = "A new Image is added in Gallery";
                    string title = "Gallery";

                    var SENDER_ID = "154368864541";
                    var value = message.Trim();
                    WebRequest tRequest;
                    tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                    string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                        + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";
                    Console.WriteLine(postData);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    tRequest.ContentLength = byteArray.Length;
                    Stream dataStream = tRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    WebResponse tResponse = tRequest.GetResponse();
                    dataStream = tResponse.GetResponseStream();
                    StreamReader tReader = new StreamReader(dataStream);
                    String sResponseFromServer = tReader.ReadToEnd();
                    //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                    //txtStream.Text = postData.ToString().Trim();
                    tReader.Close();
                    dataStream.Close();
                    tResponse.Close();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }
        [WebMethod]
        public Boolean gallery(string base64String, string FileName)
        {
            try
            {

                string strm = base64String;

                //this is a simple white background image
                string myfilename = FileName;


                //string filepath = "C:/inetpub/wwwroot/NPST/Demo/e-SMS1/NPSTDemoServices/UploadImages/" + myfilename + ".jpeg";
                string filepath = "C:/inetpub/wwwroot/Kolkata/CentralModel/e-SMS1/CentralModelServices/UploadImages/" + myfilename + ".jpeg";
                var bytess = Convert.FromBase64String(strm);
                using (var imageFile = new FileStream(filepath, FileMode.Create))
                {
                    imageFile.Write(bytess, 0, bytess.Length);
                    imageFile.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }
        [WebMethod]
        public Boolean SyllabusAttachemnt(string base64String, string FileName, string FileExtension)
        {
            try
            {

                string strm = base64String;

                //this is a simple white background image
                string myfilename = FileName + FileExtension;

                //string filepath = "C:/inetpub/wwwroot/NPST/Demo/e-SMS1/NPSTDemoServices/UploadImages/" + myfilename + "";
                string filepath = "C:/inetpub/wwwroot/Kolkata/CentralModel/e-SMS1/CentralModelServices/UploadImages/" + myfilename + "";
                var bytess = Convert.FromBase64String(strm);
                using (var imageFile = new FileStream(filepath, FileMode.Create))
                {
                    imageFile.Write(bytess, 0, bytess.Length);
                    imageFile.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }
        [WebMethod]
        public XmlElement SchoolName(string command)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_School @command='" + command + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "StaffAttendanceSummery");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public XmlElement EventList(string command, string vchstandard_id, string school_id, string academic_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {
                sp_Name = "usp_Mob_EventList @command='" + command + "',@vchStandard_id='" + vchstandard_id + "',@intSchool_id='" + school_id + "', @intAcademic_id='" + academic_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "EventList");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        [WebMethod]
        public Boolean EventParticipation(string command, string intEvent_id, string intStandard_id, string intDivision_id, string intUser_id, string intUserType_id, string intAcademic_id, string intSchool_id)
        {
            try
            {
                sp_Name = "usp_Mob_EventParticipation";
                Conn = new SqlConnection(connectionString);
                Cmd = new SqlCommand(sp_Name, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@command", command);
                Cmd.Parameters.AddWithValue("@intEvent_id", intEvent_id);
                Cmd.Parameters.AddWithValue("@intStandard_id", intStandard_id);
                Cmd.Parameters.AddWithValue("@intDivision_id", intDivision_id);
                Cmd.Parameters.AddWithValue("@intUser_id", intUser_id);
                Cmd.Parameters.AddWithValue("@intUserType_id", intUserType_id);
                Cmd.Parameters.AddWithValue("@intAcademic_id", intAcademic_id);
                Cmd.Parameters.AddWithValue("@intSchool_id", intSchool_id);
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }

        [WebMethod]
        public Boolean Event(string command, string dtEventEndDate, string vchEventName, string vchEventFees, string vchEventDescription, string vchStandard_id, string intUser_id, string intAcademic_id, string intUserType_id, string intSchool_id, string dtRegistrartionStartDate, string dtRegistrationEndDate, string dtEventStartDate)
        {
            try
            {
                sp_Name = "usp_Mob_Event";
                Conn = new SqlConnection(connectionString);
                Cmd = new SqlCommand(sp_Name, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@command", command);
                Cmd.Parameters.AddWithValue("@dtEventEndDate", dtEventEndDate);
                Cmd.Parameters.AddWithValue("@vchEventName", vchEventName);
                Cmd.Parameters.AddWithValue("@vchEventFees", vchEventFees);
                Cmd.Parameters.AddWithValue("@vchEventDescription", vchEventDescription);
                Cmd.Parameters.AddWithValue("@vchStandard_id", vchStandard_id);
                Cmd.Parameters.AddWithValue("@intUser_id", intUser_id);
                Cmd.Parameters.AddWithValue("@intAcademic_id", intAcademic_id);
                Cmd.Parameters.AddWithValue("@intUserType_id", intUserType_id);
                Cmd.Parameters.AddWithValue("@intSchool_id", intSchool_id);
                Cmd.Parameters.AddWithValue("@dtRegistrartionStartDate", dtRegistrartionStartDate);
                Cmd.Parameters.AddWithValue("@dtRegistrationEndDate", dtRegistrationEndDate);
                Cmd.Parameters.AddWithValue("@dtEventStartDate", dtEventStartDate);
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();

                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection(connectionString);
                string SqlString = "";


                if (command == "Insert" && vchStandard_id == "AllStudent & AllTeacher")
                {
                    SqlString = "select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and  intSchool_id='" + intSchool_id + "' union select vchFCMToken from tblTeacher_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intSchool_id='" + intSchool_id + "'";

                }
                else if (command == "Insert" && vchStandard_id == "AllStudent")
                {
                    SqlString = " select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and  intSchool_id='" + intSchool_id + "'";

                }
                else if (command == "Insert" && vchStandard_id == "AllTeacher")
                {
                    SqlString = "select vchFCMToken from tblTeacher_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and  intSchool_id='" + intSchool_id + "' ";

                }
                else
                {
                    SqlString = "select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intstanderd_id=" + vchStandard_id + " ";
                }



                SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string regId = dt.Rows[i]["vchFCMToken"].ToString();
                    var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                    string title = "Event";
                    string message = "A new Event has been Organized";
                    var SENDER_ID = "154368864541";
                    var value = message.Trim();
                    WebRequest tRequest;
                    tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                    string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                        + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";
                    Console.WriteLine(postData);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    tRequest.ContentLength = byteArray.Length;
                    Stream dataStream = tRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    WebResponse tResponse = tRequest.GetResponse();
                    dataStream = tResponse.GetResponseStream();
                    StreamReader tReader = new StreamReader(dataStream);
                    String sResponseFromServer = tReader.ReadToEnd();
                    //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                    //txtStream.Text = postData.ToString().Trim();
                    tReader.Close();
                    dataStream.Close();
                    tResponse.Close();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }
        [WebMethod]
        public Boolean NoticeBoard(string command, string intschool_id, string intUserType_id, string intStandard_id, string intDepartment_id, string intTeacher_id, string dtIssue_date, string dtEnd_date, string vchSubject, string vchNotice, string intInserted_by)
        {

            try
            {
                sp_Name = "usp_NocticeBoard";
                Conn = new SqlConnection(connectionString);
                Cmd = new SqlCommand(sp_Name, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@command", command);
                Cmd.Parameters.AddWithValue("@intschool_id", intschool_id);
                Cmd.Parameters.AddWithValue("@intUserType_id", intUserType_id);
                Cmd.Parameters.AddWithValue("@intStandard_id", intStandard_id);
                Cmd.Parameters.AddWithValue("@intDepartment_id", intDepartment_id);
                Cmd.Parameters.AddWithValue("@intTeacher_id", intTeacher_id);
                Cmd.Parameters.AddWithValue("@dtIssue_date", DateTime.Parse(dtIssue_date));
                Cmd.Parameters.AddWithValue("@dtEnd_date", DateTime.Parse(dtEnd_date));
                Cmd.Parameters.AddWithValue("@vchSubject", vchSubject);
                Cmd.Parameters.AddWithValue("@vchNotice", vchNotice);
                Cmd.Parameters.AddWithValue("@intInserted_by", intInserted_by);
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();

                SqlConnection conn = new SqlConnection();
                conn = new SqlConnection(connectionString);
                string SqlString = "";

                if (intUserType_id == "1" && intStandard_id == "0")
                {
                    SqlString = "select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and  intSchool_id='" + intschool_id + "' ";

                }
                else if (intUserType_id == "1" && intStandard_id != "0")
                {
                    SqlString = " select vchFCMToken from Student_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and intstanderd_id=" + intStandard_id + "";

                }
                else if (intUserType_id == "3")
                {
                    SqlString = "select vchFCMToken from tblTeacher_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and  intSchool_id='" + intschool_id + "' ";

                }
                else if (intUserType_id == "5")
                {
                    SqlString = "select vchFCMToken from tblAdmin_Master where vchFCMToken IS NOT NULL and vchFCMToken<>'' and  intSchool_id='" + intschool_id + "'";
                }
                else
                {
                }

                SqlDataAdapter sda = new SqlDataAdapter(SqlString, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string regId = dt.Rows[i]["vchFCMToken"].ToString();
                    var applicationID = "AIzaSyBhKk8a8prrNtRy1uc0Q8yp7QG0vI4dykU"; // PbojmyrmspdqkZ0pINni7DyqvhY2

                    string title = "Notice Board";
                    string message = "A new Notice For you";
                    var SENDER_ID = "154368864541";
                    var value = message.Trim();
                    WebRequest tRequest;
                    tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                    string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                        + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "&data.title=" + title + "";
                    Console.WriteLine(postData);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    tRequest.ContentLength = byteArray.Length;
                    Stream dataStream = tRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Close();
                    WebResponse tResponse = tRequest.GetResponse();
                    dataStream = tResponse.GetResponseStream();
                    StreamReader tReader = new StreamReader(dataStream);
                    String sResponseFromServer = tReader.ReadToEnd();
                    //txtResponse.Text = sResponseFromServer; //printing response from GCM server.
                    //txtStream.Text = postData.ToString().Trim();
                    tReader.Close();
                    dataStream.Close();
                    tResponse.Close();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }
        [WebMethod]
        public XmlElement SubjectMaster(string command, string intSTD_id, string intSubject_id, string intSchool_id)
        {
            XmlDataDocument xmldata;
            XmlElement xmlElement;
            try
            {

                sp_Name = "usp_TopicMaster @type='" + command + "',@intSTD_id='" + intSTD_id + "',@intSubject_id='" + intSubject_id + "',@intSchool_id='" + intSchool_id + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(sp_Name, connectionString);
                da.Fill(ds, "SubjectMaster");
                xmldata = new XmlDataDocument(ds);
                xmlElement = xmldata.DocumentElement;
                return xmlElement;
            }
            catch (Exception ex)
            {
                return xmlElement = null;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
            }
        }
        // android push notification service
        [WebMethod]
        public Boolean Post_AndroidRegId(string regid)
        {
            try
            {
                sp_Name = "Proc_PushData_Android";
                Conn = new SqlConnection(connectionString);
                Cmd = new SqlCommand(sp_Name, Conn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@User_RegId", regid);
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (sp_Name != null)
                    sp_Name = null;
                if (Conn != null)
                    Conn.Dispose();
            }
        }
    }
}
