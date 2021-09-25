using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AbsentGenderWise : DBUtility
{
    string strDate = string.Empty;
    DataSet dsObj = new DataSet();
    string strQry = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        strDate = Convert.ToDateTime(Request.QueryString["date"]).ToString("MM/dd/yyyy").Replace("-", "/");
       
        string gender = Convert.ToString(Request.QueryString["vchGender"]);

        if (strDate != "")
        {
            strQry = "usp_GenderWiseAttendance  @command='selectName',@fromDate='" + strDate.Trim() + "',@vchGender='" + gender.Trim() + "'";
            //strQry = "usp_GenderWiseAttendance  @command='selectName',@fromDate='" + strDate.Trim() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grdDet.DataSource = dsObj;
                grdDet.DataBind();
            }
        }
    }
}