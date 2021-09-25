using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Net;

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
                SqlDataAdapter da = new SqlDataAdapter(sQuery, dbconn.getConnection());
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
    //Get DataTable
    public static DataTable sGetDatatable(string sQuery, string sTableName)
    {
        DataTable Retdt = new DataTable(sTableName);
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

    #endregion "Functions"
}

