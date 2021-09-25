using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using iTextSharp.text;
using System.Security.Cryptography;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Net;
using context = System.Web.HttpContext;

public class DBConnection : IDisposable
{
    private static SqlConnection conn;
    private bool isDisposed = false;

    protected void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
        conn = null;
        isDisposed = true;
        //1.186.114.162;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    // Get SqlConnection
    public DBConnection(string sconn)
    {
        try
        {
            conn = new SqlConnection(sconn);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
    }
    //Open SqlConnection
    public SqlConnection getConnection()
    {
        try
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        return conn;

    }
    ~DBConnection()
    {
        Dispose(false);
    }
}
public class DBUtility : Page
{
    #region "Functions"
    //Get DataSet
    public static DataSet sGetDataset(string sQuery)
    {
        DataSet Retds = new DataSet();
        try
        {
            string sConStr = getConnectionString();
            using (DBConnection dbconn = new DBConnection(sConStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(sQuery, sConStr);
                if (da != null)
                {
                  
                    da.Fill(Retds);
                }
                else
                {
                    Retds = null;
                }
                dbconn.Dispose();
            }
        }
        catch (Exception ex)
        {
            Retds = null;
            //MessageBox.Show(ex.ToString());
        }

        return Retds;
    }
    public void checksession()
    {
        if (Session["School_id"] == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Session Expired'); window.location='" + Request.ApplicationPath + "/index.aspx';", true);
        }
        else
        {
            
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
    
    public void geturl()
    {
        try
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            string instremaquery1 = "Execute dbo.usp_log @command='url_visited',@vchUrl='" + url + "',@IntUser_type='" + Session["UserType_id"] + "',@intUser_id='" + Session["User_id"] + "',@intSchool_id='" + Session["School_id"] + "',@intStandard_id='" + Session["Standard_id"] + "',@intDivision_id='" + Session["Division_id"] + "',@intStudent_id='" + Session["Student_id"] + "'";

            int result1 = sExecuteQuery(instremaquery1);
        }
        catch (Exception)
        {

        }
    }

    public static bool sBindDropDownListAll(DropDownList sDdl, string sQuery, string sTextField, string sValueField)
    {
        bool retVal = false;
        try
        {
            DataTable dt = new DataTable();
            string strCon = getConnectionString();
            dt = sGetDatatable(sQuery, "");
            sDdl.Items.Clear();

            if (dt != null && dt.Rows.Count != 0)
            {
                sDdl.DataSource = dt;
                sDdl.DataTextField = sTextField;
                sDdl.DataValueField = sValueField;
                sDdl.DataBind();
                sDdl.Items.Insert(0, "---Select---");
                sDdl.Items[0].Value = "0";
                sDdl.SelectedIndex = 0;
                sDdl.Items.Insert(1, "---All---");
                sDdl.Items[1].Value = "A";
                // sDdl.SelectedIndex = 1;
                retVal = true;
            }
            else
            {
                sDdl.Items.Add("---Select---");
                sDdl.Items[0].Value = "0";
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        return retVal;
    }

    //Export 
    public void ExportGrid(GridView grv, string fileName, string contentType)
    {
        // throw new NotImplementedException();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;fileName=" + fileName);
        Response.Charset = "";
        Response.ContentType = contentType;
        
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        hw.Write("<table width='100%'><tr><td></td><td><img src='~\\images\\pdflogo.jpg' alt='' /></td><td colspan='2' ><h2>Deep Global School</h2></td></tr>");
        hw.Write("<table><tr><td><td></td></td><td >Boisar West</td><td> Pin:401501</td></tr><tr><td><br/></td></tr></table>");


        //hw.Write("<table width='100%'><tr><td>Student Name</td><td>'"+  +"'</td><td colspan='2' ><h2>Deep Global School</h2></td></tr>");
        //hw.Write("<table><tr><td><td></td></td><td >Boisar West</td><td> Pin:401501</td></tr><tr><td><br/></td></tr></table>");
        //try
        //{
        //    grv.HeaderRow.Style.Add("width", "15px");
        //    grv.HeaderRow.Style.Add("font-size", "14px");
        //    grv.HeaderRow.Style.Add("background-color", "gray");
        //}
        //catch 
        //{
            
        //}
        //grv.Rows[0].Style.Add("background-color", "gray");
        //grv.Style.Add("text-decoration", "none");
        //grv.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        //grv.Style.Add("font-size", "13px");
        grv.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.Close();
        grv.AllowPaging = true;
        grv.DataBind();
       HttpContext.Current.Response.End();

    }
    public static string GetCurrentFinancialYear()
    {
        
        int CurrentYear = DateTime.Today.Year;
        int PreviousYear = Convert.ToInt32(DateTime.Today.Year) - 1;
        int NextYear = DateTime.Today.Year + 1;
        string PreYear = Convert.ToString(PreviousYear).Substring(2, 2);
        string NexYear = Convert.ToString(NextYear).Substring(2, 2);
        string CurYear = Convert.ToString(CurrentYear).Substring(2, 2);
        string FinYear = null;

        if (DateTime.Today.Month > 3)

            FinYear = CurYear + NexYear;

        else

            FinYear = PreYear + CurYear;

        return FinYear.Trim();

    }
    public void ExportGridToPDF(GridView grv, string fileName, string contentType)
    {

        Response.ContentType = "application/pdf";
        fileName = fileName.Replace("/", "");
        Response.AddHeader("content-disposition", "attachment;fileName=" + fileName);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        grv.HeaderRow.Style.Add("width", "15px");
        grv.HeaderRow.Style.Add("font-size", "14px");
        grv.HeaderRow.Style.Add("background-color", "green");
        grv.Style.Add("text-decoration", "none");
        grv.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
        grv.Style.Add("font-size", "12px");
        grv.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 50f, 0f);
        string path = "C:\\Users\\administrator\\Downloads\\" + fileName.Replace("/", "");
        FileStream fs = new FileStream(path, FileMode.Create);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, fs);
        pdfWriter.PageEvent = new ITextEvents();
        pdfDoc.Open();
        pdfDoc.AddHeader(fileName, "ASD");
        
        pdfDoc.AddTitle(fileName);
        htmlparser.Parse(sr);
        Response.Write(pdfDoc);
        pdfDoc.Close();
        
      //  Response.End();
        grv.AllowPaging = true;
        grv.DataBind();
    }
  
    
    public void ExportToWord(GridView GridView1, string filename)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition",
        "attachment;filename="+ filename);
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-word ";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //hw.Write("<table width='100%'><tr><td></td><td><img src='~\\images\\pdflogo.jpg' alt='' /></td><td colspan='2' ><h2>Deep Global School</h2></td></tr><tr><td><td></td></td><td >Boisar West</td><td> Pin:401501</td></tr><tr><td><br/></td></tr></table>");
       
       
        //GridView1.AllowPaging = false;
       // GridView1.DataBind();
        
        GridView1.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    //Get DataTable
    public static DataTable sGetDatatable(string sQuery, string sTableName)
    {
        DataTable Retdt = new DataTable(sTableName);
        try
        {
            string sConStr = getConnectionString();
            using (DBConnection dbconn = new DBConnection(sConStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(sQuery, sConStr);
                if (da != null)
                {
                    da.Fill(Retdt);
                }
                else
                {
                    Retdt = null;
                }
                dbconn.Dispose();
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
            Retdt = null;
        }
        return Retdt;
    }
    public static DataTable sGetDatatableNew(string sQuery)
    {
        DataTable Retdt = new DataTable();
        try
        {
            string sConStr = getConnectionString();
            using (DBConnection dbconn = new DBConnection(sConStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(sQuery, dbconn.getConnection());
                if (da != null)
                {
                    da.Fill(Retdt);
                }
                else
                {
                    Retdt = null;
                }
                dbconn.Dispose();
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
            Retdt = null;
        }
        return Retdt;
    }
    // Bind ListBox
    public static bool sBindListBox(ListBox slb, string sQuery, string sTextField, string sValueField)
    {
        bool retVal = false;
        DataTable dt = new DataTable();
        try
        {
            string strCon = getConnectionString();
            dt = sGetDatatable(sQuery, "");
            slb.Items.Clear();

            if (dt != null && dt.Rows.Count != 0)
            {
                slb.DataSource = dt;
                slb.DataTextField = sTextField;
                slb.DataValueField = sValueField;
                slb.DataBind();
                //slb.Items.Insert(0, "---Select---");
                //sDdl.Items[0].Value = "0";
                //slb.SelectedIndex = 0;
                retVal = true;
            }
            else
            {
                slb.Items.Add("No Entry");
                slb.Items[0].Value = "0";
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        return retVal;
    }
    //Bind DropDownList
    public static bool sBindDropDownList(DropDownList sDdl, string sQuery, string sTextField, string sValueField)
    {
        bool retVal = false;
        try
        {
            DataTable dt = new DataTable();
            string strCon = getConnectionString();
            dt = sGetDatatable(sQuery, "");
            sDdl.Items.Clear();

            if (dt != null && dt.Rows.Count != 0)
            {
                sDdl.DataSource = dt;
                sDdl.DataTextField = sTextField;
                sDdl.DataValueField = sValueField;
                sDdl.DataBind();
                sDdl.Items.Insert(0, "---Select---");
                sDdl.Items[0].Value = "0";
                sDdl.SelectedIndex = 0;
                retVal = true;
            }
            else
            {
                sDdl.Items.Add("---Select---");
                sDdl.Items[0].Value = "0";                
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        return retVal;
    }
    //Bind CheckBoxList
    public static bool sBindCheckBoxList(CheckBoxList sCbl, string sQuery, string sTextField, string sValueField)
    {
        bool retVal = false;
        try
        {
            DataTable dt = new DataTable();
            string strCon = getConnectionString();
            dt = sGetDatatable(sQuery, "");
            sCbl.Items.Clear();

            if (dt != null && dt.Rows.Count != 0)
            {
                sCbl.DataSource = dt;
                sCbl.DataTextField = sTextField;
                sCbl.DataValueField = sValueField;
                sCbl.DataBind();                
                retVal = true;
            }
            else
            {        
       
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        return retVal;
    }


    public string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }
    public string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
    //Bind GridView
    public int sBindGrid(GridView sGview, string sQuery)
    {
        int retrow = 0;
        try
        {
            string strCon = getConnectionString();
            DataTable dt = sGetDatatable(sQuery,"");
            if (dt != null)
            {
                if (dt.Rows.Count != 0)
                {
                    sGview.DataSource = dt;
                    sGview.DataBind();
                    retrow = dt.Rows.Count;
                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    sGview.DataSource = dt;
                    sGview.DataBind();

                    int TotalColumns = sGview.Rows[0].Cells.Count;
                    sGview.Rows[0].Cells.Clear();
                    sGview.Rows[0].Cells.Add(new TableCell());
                    sGview.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                    sGview.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    sGview.Rows[0].Cells[0].Text = "No Record Found";
                }
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        return retrow;
    }


    //Get SystemIP
    public static string GetSystemIP()
    { 
        string retStr = "";        
        try
        {            
            string myHost = System.Net.Dns.GetHostName();
            retStr = Convert.ToString(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            string clientIPAddress = Convert.ToString(System.Net.Dns.GetHostAddresses(myHost).GetValue(0));
            retStr = retStr + ">>" + clientIPAddress;
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        return retStr;
    }

    //Execute Scalar
    public static string sExecuteScalar(string sQuery)
    {
        string retVal = "";
        try
        {
            string sConStr = getConnectionString();
            using (DBConnection dbconn = new DBConnection(sConStr))
            {
                SqlCommand cmdExe = new SqlCommand(sQuery, dbconn.getConnection());
                retVal = Convert.ToString(cmdExe.ExecuteScalar());
                dbconn.Dispose();
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
            retVal = null;
        }
        return retVal;
    }  

    //Execute NonQuery
    public static int sExecuteQuery(string sQuery)
    {
        //int retVal = 0;
        int retVal;
        try
        {
            string sConStr = getConnectionString();
            using (DBConnection dbconn = new DBConnection(sConStr))
            {
                SqlCommand cmdExe = new SqlCommand(sQuery, dbconn.getConnection());
                retVal = cmdExe.ExecuteNonQuery();
                dbconn.Dispose();
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
            retVal = -1;
        }
        return retVal;
    }
   // Execute Reader and get data in ArrayList
    public static ArrayList sExecuteReaderArrayList(string sQuery)
    {
        ArrayList retval = new ArrayList();
        try
        {
            string sConStr = getConnectionString();
            using (DBConnection dbconn = new DBConnection(sConStr))
            {
                SqlCommand cmdExe = new SqlCommand(sQuery, dbconn.getConnection());
                SqlDataReader sdr;

                sdr = cmdExe.ExecuteReader();
                while (sdr.Read())
                {
                    int j = 0;
                    retval.Add(Convert.ToInt32(Convert.ToString(sdr[j])));
                    j = j + 1;
                }
                dbconn.Dispose();
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
            retval = null;
        }
        return retval;
    }
    //Execute Procedure Without Parameter
    public static DataSet sExecuteProcedure(string ProcedureName)
    {
        DataSet Retds = new DataSet();
        try
        {
            string sConStr = getConnectionString();
            using (DBConnection dbconn = new DBConnection(sConStr))
            {
                SqlCommand Cmd = new SqlCommand(ProcedureName, dbconn.getConnection());

                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                if (da != null)
                {
                    da.Fill(Retds);
                }
                else
                {
                    Retds = null;
                }
                dbconn.Dispose();

            }
        }
        catch (Exception Ex)
        {
            throw Ex;
            Retds = null;
        }
        return Retds;
    }
    //Execute Reader returns data in first column and first row.
    public static string sExecuteReader(string sQuery)
    {
        string retval = "";
        try
        {
            string sConStr = getConnectionString();
            using (DBConnection dbconn = new DBConnection(sConStr))
            {
                SqlCommand cmdExe = new SqlCommand(sQuery, dbconn.getConnection());
                SqlDataReader sdr;

                sdr = cmdExe.ExecuteReader();
                while (sdr.Read())
                {
                    retval = sdr[0].ToString();
                }
                dbconn.Dispose();
            }
        }
        catch (Exception Ex)
        {
            throw Ex;
            retval = "";
        }
        return retval;
    }
    //Get Connection String
    public static string getConnectionString()
    {
        string retval = "";
        try
        {
            retval = System.Configuration.ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
        }
        catch (Exception Ex)
        {
            throw Ex;
            retval = "";
        }
        return retval;
    }

    public string GetComputer_InternetIP()
    {
        String direction = "";
        string ipAddress = "";

        WebRequest request = WebRequest.Create("http://checkip.dyndns.org");
        WebResponse response = request.GetResponse();
        StreamReader stream = new StreamReader(response.GetResponseStream());
        ipAddress = stream.ReadToEnd();

        int first = ipAddress.IndexOf("Address: ") + 9;
        int last = ipAddress.LastIndexOf("</body>");
        direction = ipAddress.Substring(first, last - first);

        return direction;
        //return ipAddress;

    }
    // Insert Exceptions in Log Fiile
    public static void logerrors(Exception ex, string projectname, string mod, string Apptype)
    {
        try
        {
            string[] DateTme;

            string LoginDate;

            DateTme = DateTime.Now.GetDateTimeFormats();

            LoginDate = DateTme[43];

            SqlConnection ErrCon = new SqlConnection(ConfigurationSettings.AppSettings["ErrLog"]);

            string Path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

            System.IO.FileInfo oinfo = new System.IO.FileInfo(Path);

            string TempPageName = oinfo.Name.Trim();

            string[] Spliter = TempPageName.Split(new char[] { '.' });

            string PageName = Spliter[0].ToString().Trim();

            string ExceTyp = ex.GetType().ToString().Trim();

            string errpath = ex.StackTrace.Replace("'", "").ToString().Trim();

            string[] errstr = errpath.Split(')');

            int len = errstr.Length;

            String seconlast = errstr[len - 2];

            String last = errstr[len - 1];

            string strat = seconlast + ")" + "" + last;

            strat = strat.Replace("\r\n", "");

            string ErrorMessage = ex.Message.ToString();

            string InsrtWebLogs = "insert into WebErrlogs(ProjectName,ApplicationType,Mod_Name,Pag_Name," +

            "ErrorMsg,Log_Date,Error_Type,Error_Trace)values('" + projectname + "','" + Apptype + "','" +

            mod + "','" + PageName.Trim() + "','" + ErrorMessage.Trim().Replace("'", "''") + "','" +

            LoginDate.Trim() + "','" + ExceTyp.Trim() + "','" + strat + "')";

            SqlCommand cmd = new SqlCommand(InsrtWebLogs, ErrCon);

            if (ErrCon.State == ConnectionState.Closed) { ErrCon.Open(); }

            cmd.ExecuteNonQuery();

            ErrCon.Close();

            ErrCon.Dispose();

            cmd.Dispose();
        }
        catch
        { }
    }

    //    Write exception to table.
    public static void WriteExceptionToTable(Exception Ex, string strModuleName, string strPageName)
    {
        try
        {
            string sConStr = getConnectionString();
            using (DBConnection dbconn = new DBConnection(sConStr))
            {

                string strErrorLog =
                    " INSERT INTO sf_weblogs (Mod_Name, Pag_Name, Err_Date, Err_Msg, Err_Type, Err_Trace, Err_Status)" +
                    " VALUES ('" + strModuleName.Trim() + "','" + strPageName.Trim() + "','" + DateTime.Now.ToString() + "', " +
                        " '" + Ex.Message.ToString().Trim() + "', '" + Ex.GetType().ToString().Trim() + "', " +
                        " '" + Ex.StackTrace.ToString().Trim() + "','N')";
                int result = sExecuteQuery(strErrorLog);
            }
        }
        catch (Exception Excp)
        {
            
        }
    }

    #region LogExceptionfile

    private static String ErrorlineNo, Errormsg, extype, exurl, ErrorText;
    /// <summary>
    /// Write error into the log file
    /// </summary>
    /// <param name="ex"><see cref="Exception"/></param>
    public static void LogException(Exception ex)
    {
        var line = Environment.NewLine;
        ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
        Errormsg = ex.GetType().Name.ToString();
        extype = ex.GetType().ToString();
        exurl = context.Current.Request.Url.ToString();
        ErrorText = ex.Message.ToString();
        try
        {
            string filepath = context.Current.Server.MapPath("~/Documents/Logs/");  //Text File Path

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            filepath = filepath + "ErrorLog-" + DateTime.Today.ToString("dd-MM-yy") + ".txt";   //Text File Name
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(filepath))
            {
                string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line + "Error Line No :" + " " + ErrorlineNo + line + "Error Message:" + " " + Errormsg + line + "Exception Type:" + " " + extype + line + "Error Location :" + " " + ErrorText + line + "Error Page Url:" + " " + exurl + line;
                sw.WriteLine("-----------Exception Details on " + " " + DateTime.Now.ToString() + "-----------------");
                sw.WriteLine("-------------------------------------------------------------------------------------");
                sw.WriteLine(error);
                sw.WriteLine("--------------------------------*End*------------------------------------------");
                sw.WriteLine(line);
                sw.Flush();
                sw.Close();
            }
        }
        catch (Exception e)
        {
            e.ToString();
        }
    }

    #endregion LogExceptionfile

    public void ShowSuccessMessage(string msg = "Record Saved Successfully")
    {
        try
        {
            string script = "$('#Success span i').html('');$('#Success span i').html(' " + msg + "');$('#Success').fadeIn();setTimeout(function(){ $('#Success').fadeOut(); }, 5000);";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    public void ShowErrorMessage(string msg = "Something went wrong!")
    {
        try
        {
            string script = "$('#Error span i').html('');$('#Error span i').html(' " + msg + "');$('#Error').fadeIn();setTimeout(function(){ $('#Error').fadeOut(); }, 5000);";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
        catch (Exception ex)
        {
            LogException(ex);
        }
    }

    #endregion "Functions"
}

