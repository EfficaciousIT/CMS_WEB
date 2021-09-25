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

public partial class frmRPTFeecollectionInDate : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strFromDate = string.Empty;
    string strToDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text == "")
        {
            MessageBox("Please Select From Date!");
            txtFromDate.Focus();
            return;
        }
        if (txtToDate.Text == "")
        {
            MessageBox("Please Select To Date!");
            txtToDate.Focus();
            return;
        }

        strFromDate = Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy").Replace("-","/");
        strToDate = Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy").Replace("-", "/");
        strQry = "usp_getAllFeePaidDetailsBetweenDates @command='select',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "',@FromDate='" + strFromDate.Trim() + "',@ToDate='" + strToDate.Trim() + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            int sum = 0;
            grdFeeM.DataSource = dsObj;
            grdFeeM.DataBind();
            for (int i = 0; i < grdFeeM.Rows.Count; i++)
            {
                sum += int.Parse(grdFeeM.Rows[i].Cells[7].Text);
            }
            lblTotal.Text = sum.ToString();
            //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Font.Bold = true;

            //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[0].Text = "";
            //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[1].Text = "";
            //grdFeeM.Rows[Convert.ToInt32(dsObj.Tables[0].Rows.Count - 1)].Cells[3].Text = "";
        }
        else
        {
            int sum = 0;
            grdFeeM.DataSource = dsObj;
            grdFeeM.DataBind();
            for (int i = 0; i < grdFeeM.Rows.Count; i++)
            {
                sum += int.Parse(grdFeeM.Rows[i].Cells[7].Text);
            }
            lblTotal.Text = sum.ToString();
        }
    }
}
