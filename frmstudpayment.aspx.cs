using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

    public partial class frmpayment : DBUtility
    {

        string strQry = "";
        DataSet dsObj;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _FillStudDetails();
            }
        }

        protected void _FillStudDetails()
        {
            string student_id =Convert.ToString(Session["Student_id"]);
            string academicid = Convert.ToString(Session["AcademicID"]);
            strQry = "exec usp_GetStudDetails @intStudent_id='" + student_id + "',@intSchool_id='" + Session["AcademicID"] + "'";
            dsObj = sGetDataset(strQry);
          
           
        }
    }
