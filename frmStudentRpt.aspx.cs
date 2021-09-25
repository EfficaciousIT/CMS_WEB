using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Shared;

public partial class frmStudentRpt : System.Web.UI.Page
{
    DataSet dtst = new DataSet();
    ReportDocument rptd = new ReportDocument();
    ConnectionInfo connectionInfo = new ConnectionInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["rptStudentDetails"] != null)
        {
            dtst = (DataSet)Session["rptStudentDetails"];

            string reportPath = Server.MapPath("CryStudentDetails.rpt");
            //string reportPath = Server.MapPath("CrystalFeeReport.rpt");
            rptd.Load(reportPath);
            rptd.SetDataSource(dtst.Tables[0]);
            StudentDetails.ReportSource = rptd;
            StudentDetails.DataBind();
            StudentDetails.RefreshReport();
        }
    }
}