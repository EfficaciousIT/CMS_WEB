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
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.IO;

public partial class frmUploadStudentdet : DBUtility
{
    string strQry = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string FilePath = Server.MapPath(FolderPath + FileName);
            FileUpload1.SaveAs(FilePath);
            Import_To_Grid(FilePath, Extension);
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
    private void Import_To_Grid(string FilePath, string Extension)
    {
        string conStr = "A";
        switch (Extension)
        {
            case ".xls": //Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                break;
            case ".xlsx": //Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                break;
        }

        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1;MAXSCANROWS=0\"");
        //con.Open();
      
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();
        DataSet _dsObj = new DataSet();

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }        
        DataTable dtExcelSchema;
        int j = 0;
        dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
        oda = new OleDbDataAdapter("SELECT * From [" + SheetName + "]", con);
        oda.Fill(_dsObj);
        if (_dsObj.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i <= _dsObj.Tables[0].Rows.Count-1; i++)
            {
                strQry = "usp_StudentMasterEntry @command='Insert',@vchapplication_no='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchapplication_no"]) + "',@intAddmission_id='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intAddmission_id"]).Replace("NULL", "0") + "',@intstanderd_id='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intstanderd_id"]).Replace("NULL", "0") + "',@intDivision_id='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intDivision_id"]) + "',@intRoll_id='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intRoll_id"]) + "',@vchStudentFirst_name='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchStudentFirst_name"]) + "',@vchStudentMiddle_name='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchStudentMiddle_name"]) + "',@vchStudentLast_name='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchStudentLast_name"]).Replace("'", "") + "',@vchFatherName='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchFatherName"]) + "',@vchMotherName='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchMotherName"]) + "',@intParentID='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intParentID"]).Replace("NULL", "") + "',@vchGender='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchGender"]) + "',@dtDOB='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["dtDOB"]) + "',@vchplaceofBirth='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchplaceofBirth"]) + "',@vchUser_name='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchUser_name"]) + "',@vchPassword='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchPassword"]) + "',@vchActivestatus='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchActivestatus"]) + "',@dtActivationDate='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["dtActivationDate"]).Replace("NULL", "") + "',@dtDeactivationDate='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["dtDeactivationDate"]).Replace("NULL", "2014-01-01") + "',@intActivationBy='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intActivationBy"]).Replace("NULL", "0") + "',@intDeactivationBy='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intDeactivationBy"]).Replace("NULL", "0") + "',@vchCast='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchCast"]) + "',@vchsubcast='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchsubcast"]) + "',@vchEmail='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchEmail"]) + "',@vchMothertongue='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchMothertongue"]) + "',@vchpresentAddress='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchpresentAddress"]).Replace("'", "") + "',@vchpermanentAddress='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchpermanentAddress"]) + "',@vchImageURL='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchImageURL"]) + "',@intHomePhoneNo1='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intHomePhoneNo1"]).Replace("NULL", "0") + "',@intHomePhoneNo2='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intHomePhoneNo2"]).Replace("NULL", "0") + "',@vchEmergencyConPerson1='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchEmergencyConPerson1"]) + "',@intEmergencyContat1='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intEmergencyContat1"]).Replace("NULL", "0") + "',@vchEmergencyConPerson2='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchEmergencyConPerson2"]) + "',@intEmergencyContat2='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intEmergencyContat2"]).Replace("NULL", "0").Replace(" ", "0") + "',@vchNeighbour_name='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchNeighbour_name"]) + "',@intNeighborConNo='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["intNeighborConNo"]).Replace("NULL", "0").Replace(" ", "0") + "',@chrBloodGrp='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["chrBloodGrp"]) + "',@vchPassport='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchPassport"]) + "',@dtpassportissue='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["dtpassportissue"]).Replace("NULL", "2014-01-01") + "',@dtexpiredate='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["dtexpiredate"]).Replace("NULL", "2014-01-01") + "',@vchHandicapedStatus='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchHandicapedStatus"]) + "',@vchDescription='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchDescription"]) + "',@vchIdentificationMarks='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchIdentificationMarks"]) + "',@chrLeftStatus='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["chrLeftStatus"]) + "',@dtLeftDate='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["dtLeftDate"]).Replace("NULL", "2014-01-01") + "',@vchLeftReason='" + Convert.ToString(_dsObj.Tables[0].Rows[i]["vchLeftReason"]) + "'";
                j = sExecuteQuery(strQry);
                i = _dsObj.Tables[0].Rows.Count - 1;
            }
            if (j > 0)
            {
                MessageBox("Student Details Uploaded successfully");
            }
        }
        if (con.State == ConnectionState.Closed)
        {
            con.Close();
        }       
    }
}
