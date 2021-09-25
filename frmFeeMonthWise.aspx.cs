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

public partial class frmFeeMonthWise : DBUtility
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
        strQry = "usp_MonthWisePendingFee @intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dtObj = sGetDatatableNew(strQry);
        if (dtObj.Rows.Count > 0)
        {
            if (ViewState["TotalPrice"] == null)
            {
                Decimal FeeDue = 0;
                Decimal FeeRecd = 0;
                Decimal FeeOS = 0;
                string OSPercent = "";
                Decimal Student = 0;
                Decimal Penalty = 0;
                Decimal TotalDue = 0;
                Decimal Percent = 0;
                for (int i = 0; i <= dtObj.Rows.Count - 1; i++)
                {
                    FeeDue += dtObj.Rows[i].Field<Decimal>(2);
                    FeeRecd += dtObj.Rows[i].Field<Decimal>(3);
                    FeeOS += dtObj.Rows[i].Field<Decimal>(4);
                    //if (Percent == 0)
                    //{
                    //    Percent = Convert.ToDecimal(OSPercent = dtObj.Rows[i].Field<string>(5));
                    //}
                    //else
                    //{
                    //    Percent = Percent + Convert.ToDecimal(OSPercent = dtObj.Rows[i].Field<string>(5));
                    //}
                    
                    Penalty += dtObj.Rows[i].Field<int>(7);
                    TotalDue += dtObj.Rows[i].Field<Decimal>(8);
                    
                }

                ViewState["FeeDue"] = FeeDue;
                ViewState["FeeRecd"] = FeeRecd;
                ViewState["FeeOS"] = FeeOS;
                ViewState["OSPercent"] = "---";
                ViewState["Student"] = "---";
                ViewState["Penalty"] = Penalty;
                ViewState["TotalDue"] = TotalDue;

            }

            grdFeeM.DataSource = dtObj;
            grdFeeM.DataBind();
        }
        else
        {
            grdFeeM.DataSource = dtObj;
            grdFeeM.DataBind();
        }
    }
    protected void grdFeeM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (ViewState["FeeDue"] != null)
            {

                Label lblFeeDue = (Label)e.Row.FindControl("lblFeeDue");
                lblFeeDue.Text = ViewState["FeeDue"].ToString();

                Label lblFeeRecd = (Label)e.Row.FindControl("lblFeeRecd");
                lblFeeRecd.Text = ViewState["FeeRecd"].ToString();

                Label lblFeeOS = (Label)e.Row.FindControl("lblFeeOS");
                lblFeeOS.Text = ViewState["FeeOS"].ToString();


                Label lblNetFee = (Label)e.Row.FindControl("lblNetFee");
                lblNetFee.Text = ViewState["OSPercent"].ToString();

                Label lblStudent = (Label)e.Row.FindControl("lblStudent");
                lblStudent.Text = ViewState["Student"].ToString();

                Label lblAPenalty = (Label)e.Row.FindControl("lblAPenalty");
                lblAPenalty.Text = ViewState["Penalty"].ToString();

                Label lblTotalDue = (Label)e.Row.FindControl("lblTotalDue");
                lblTotalDue.Text = ViewState["TotalDue"].ToString();
            }
        }
    }
}
