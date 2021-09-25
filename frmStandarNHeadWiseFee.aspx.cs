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

public partial class frmStandarNHeadWiseFee : DBUtility
{
    string strQry = string.Empty;
    DataSet dsObj = new DataSet();
    string strSubject = string.Empty;
    DataTable dtObj = new DataTable();
    DataTable dtObjNew = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label lblTile = new Label();
        //lblTile = (Label)Page.Master.FindControl("lblPageTitle");
        //lblTile.Visible = true;
        //lblTile.Text = "Head Wise Payments Details";
        if (!IsPostBack)
        {
            fillGrid();
        }
    }
    protected void fillGrid()
    {       
        strQry = "usp_getSubjectName @intschool_id='" + Convert.ToString(Session["School_id"]) + "'";
        dsObj = sGetDataset(strQry);
        if (dsObj.Tables[0].Rows.Count > 0)
        {
            strSubject = Convert.ToString(dsObj.Tables[0].Rows[0][0]);

            strQry = "SELECT * FROM (select t1.intstandard_id,vchStandard_name as [Standard],t2.Student,vchFee,numAmount*t2.Student as numAmount from (select feetype,intstandard_id,vchStandard_name,vchFee,isnull(numAmount,0) as numAmount from tbl_FeesAssignSTD 	inner join tblFeeDesc on tbl_FeesAssignSTD.intFee_Id=tblFeeDesc.intTutionId	inner join tblstandard_master on tbl_FeesAssignSTD.intSTD_Id=tblstandard_master.intstandard_id 		where tbl_FeesAssignSTD.intschool_id=1	and tbl_FeesAssignSTD.bitActiveFlg=1 and tblFeeDesc.btActiveFlg=1) as t1	inner join	(select tblstandard_master.intstandard_id,count(*) as student from student_master inner join tblstandard_master on student_master.intstanderd_id=tblstandard_master.intstandard_id where student_master.intschool_id=1 and vchActivestatus=0 group by intstandard_id) t2 on t1.intstandard_id=t2.intstandard_id	) as s PIVOT( SUM(numAmount) FOR [vchFee] IN (" + strSubject + "))AS p order by intstandard_id ";
            dtObj = sGetDatatableNew(strQry);
            if (dtObj.Rows.Count > 0)
            {              

                strQry = "SELECT * FROM (select '0' as intstandard_id,'0' as [Standard],'0' as Student,vchfee,sum(numamount) as numamount from  (select t1.intstandard_id,vchStandard_name as [Standard],t2.Student,vchFee,numAmount*t2.Student as numAmount from (select feetype,intstandard_id,vchStandard_name,vchFee,isnull(numAmount,0) as numAmount from tbl_FeesAssignSTD inner join tblFeeDesc on tbl_FeesAssignSTD.intFee_Id=tblFeeDesc.intTutionId inner join tblstandard_master on tbl_FeesAssignSTD.intSTD_Id=tblstandard_master.intstandard_id where tbl_FeesAssignSTD.intschool_id=1	and tbl_FeesAssignSTD.bitActiveFlg=1 and tblFeeDesc.btActiveFlg=1) as t1 inner join (select tblstandard_master.intstandard_id,count(*) as student from student_master inner join tblstandard_master on student_master.intstanderd_id=tblstandard_master.intstandard_id where student_master.intschool_id=1 and vchActivestatus=0 group by intstandard_id) t2 on t1.intstandard_id=t2.intstandard_id) as t3 group by vchfee) as s PIVOT(SUM(numamount)FOR [vchfee] IN ("+strSubject+"))AS p ";
                dtObjNew = sGetDatatableNew(strQry);
                if (dtObjNew.Rows.Count > 0)
                { 
                    //dtObj.Merge(dtObjNew);
                    dtObj.Merge(dtObjNew, true, MissingSchemaAction.Ignore);
                    dsObj.Tables.Add(dtObj);
                    grdFeeM.DataSource = dtObj;
                    grdFeeM.DataBind();
                    grdFeeM.Rows[Convert.ToInt32(dtObj.Rows.Count - 1)].Font.Bold = true;
                    grdFeeM.Rows[Convert.ToInt32(dtObj.Rows.Count - 1)].Cells[2].Text = "";
                    grdFeeM.Rows[Convert.ToInt32(dtObj.Rows.Count - 1)].Cells[2].Text = "Total";
                }
            }
            else
            {
                grdFeeM.DataSource = dsObj;
                grdFeeM.DataBind();
            }
        }       

    }
    protected void grdFeeM_RowCreated(object sender, GridViewRowEventArgs e)
    {        
        e.Row.Cells[0].Visible = false;
        
        //for (int i = 0; i <= grdFeeM.Rows.Count; i++)
        //{
        //    sum += Convert.ToDouble(this.grdFeeM.Rows[i].Cells[1].Text);
        //    //for (int j = 0; j <= grdFeeM.Rows[1].Cells.Count; j++)
        //    //{
        //    //    string strVal = Convert.ToString(e.Row.Cells[j].Text);
        //    //}
        //}
    }
}
