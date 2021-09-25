using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class frmsubjectorder : DBUtility 
{
    string strQry = "";
    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["esmsCentralModel"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            filldata();
        }
    }

    protected void filldata()
    {
        strQry = "Execute dbo.usp_Area @command='GridSubStad',@intSchool_id='" + Session["School_id"] + "' ";
        bool st1 = sBindDropDownListAll(Stdrop1, strQry, "vchStandard_name", "intstandard_id");

    }

    protected void Stdrop1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Stan1 = Stdrop1.SelectedItem.Value;
      

      //  strQry = "select b.intSubject_id as intSubject_id,b.vchSubjectName as vchSubjectName from tblstandard_master a inner join tblsubject_master b on b.intschool_id=1 and b.intactive_flg=1 and a.intstandard_id=b.intStandard_id and b.intStandard_id='" + Stan1 + "'";
        strQry = "select intExamSubject_id,vchSubjectName from tblExamSubject_Master where intStandard_id='" + Stan1 + "' and intactive_flg=1 and intAcademic_id='" + Session["AcademicID"] + "'";
        bool st1 = sBindDropDownListAll(DropDownList1, strQry, "vchSubjectName", "intExamSubject_id");
    }
    protected void button3_click(object sender, EventArgs e)
    {
        string subject = DropDownList1.SelectedValue;
        using (SqlConnection con = new SqlConnection(constr))
        {
            con.Open();
            SqlCommand strQry = new SqlCommand("update tblExamSubject_Master set intSubjectOrder='" + TextBox1.Text + "' where intExamSubject_id='" + subject + "'", con);

            int i = strQry.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                MessageBox("Updated Successfully");
            }
            else
            {
                MessageBox("Update Failed..");
            }
        }
    }
}