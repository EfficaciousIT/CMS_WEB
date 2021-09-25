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

public partial class frmFeePaidTillDate : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    DataTable dtObj = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTile = new Label();
        //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTile.Visible = true;
        //lblTile.Text = "Fee Payments/Pending Details";
        if (!IsPostBack)
        {
            fillGrid();
        }
    }
    protected void fillGrid()
    {
        strQry = "usp_FeePaidTillDate @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dtObj = sGetDatatableNew(strQry);
        if (dtObj.Rows.Count > 0)
        {
            //if (ViewState["TotalPrice"] == null)
            //{
            //    Decimal dPrice = 0;
            //    Decimal Totalstudent = 0;
            //    Decimal Gross = 0;
            //    Decimal consession = 0;
            //    Decimal netfee = 0;
            //    Decimal due = 0;
            //    Decimal recd = 0;
            //    Decimal pending = 0;
            //    Decimal student = 0;
            //    for (int i = 0; i <= dtObj.Rows.Count - 1; i++)
            //    {                    
            //        Totalstudent += dtObj.Rows[i].Field<int>(2);
            //        Gross += dtObj.Rows[i].Field<Decimal>(3);
            //        consession += dtObj.Rows[i].Field<int>(4);

            //        netfee += dtObj.Rows[i].Field<Decimal>(5);
            //        due += dtObj.Rows[i].Field<Decimal>(6);
            //        recd += dtObj.Rows[i].Field<Decimal>(7);
            //        pending += dtObj.Rows[i].Field<Decimal>(8);
            //        student += dtObj.Rows[i].Field<int>(9);
            //    }

            //    ViewState["Totalstudent"] = Totalstudent;
            //    ViewState["Gross"] = Gross;
            //    ViewState["consession"] = consession;
            //    ViewState["netfee"] = netfee;

            //    ViewState["due"] = due;
            //    ViewState["recd"] = recd;
            //    ViewState["pending"] = pending;
            //    ViewState["student"] = student;
            //}

            grdFeeM.DataSource = dtObj;
            grdFeeM.DataBind();
        }
    }
    protected void grdFeeM_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;        
    }
    protected void grdFeeM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //int total=0;
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    if (ViewState["Totalstudent"] != null)
        //    {
                
        //        Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
        //        lblGrandTotal.Text = ViewState["Totalstudent"].ToString();

        //        Label lblGross = (Label)e.Row.FindControl("lblGross");
        //        lblGross.Text = ViewState["Gross"].ToString();

        //        Label lblConcession = (Label)e.Row.FindControl("lblConcession");
        //        lblConcession.Text = ViewState["consession"].ToString();


        //        Label lblNetFee = (Label)e.Row.FindControl("lblNetFee");
        //        lblNetFee.Text = ViewState["netfee"].ToString();

        //        Label lblDueTill = (Label)e.Row.FindControl("lblDueTill");
        //        lblDueTill.Text = ViewState["due"].ToString();

        //        Label lblAmount = (Label)e.Row.FindControl("lblAmount");
        //        lblAmount.Text = ViewState["recd"].ToString();

        //        Label lblPending = (Label)e.Row.FindControl("lblPending");
        //        lblPending.Text = ViewState["pending"].ToString();

        //        Label lblStudent = (Label)e.Row.FindControl("lblStudent");
        //        lblStudent.Text = ViewState["student"].ToString();

        //    }
        //}
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        DataSet dsObj = new DataSet();
        strQry = "";
        strQry = "usp_FeePaidTillDate @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        Session["rptFeePaid"] = dsObj;
        Response.Redirect("frmFeePaidReport.aspx", true);
    }
}
