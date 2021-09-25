using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class frmBookDetailsReport : DBUtility
{
    string strQry = "";
    DataSet dsObj = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fBookCategory();
            fBookEdition();
            fBookPublication();
            fBookAuthor();
        }
    }

    protected void fBookCategory()
    {
        try
        {
            strQry = "[usp_BookDetails] @command='BookCategory',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlBookCategory, strQry, "vchCategory_name", "intCategory_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void fBookEdition()
    {
        try
        {
            strQry = "[usp_BookDetails] @command='BookEdition',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlBookEdition, strQry, "vchBookEdition_name", "intBookEdition_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void fBookPublication()
    {
        try
        {
            strQry = "[usp_BookDetails] @command='BookPublication',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlBookPublication, strQry, "vchBook_publication_name", "intBook_publication_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void fBookAuthor()
    {
        try
        {
            strQry = "[usp_BookDetails] @command='BookAuthor',@intSchool_id='" + Convert.ToString(Session["School_id"]) + "'";
            sBindDropDownList(ddlBookAuthor, strQry, "vchBook_Author_name", "intBook_Author_id");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void fGrid()
    {
        try
        {
            if (ddlBookCategory.SelectedValue == "0" && ddlBookEdition.SelectedValue == "0" && ddlBookPublication.SelectedValue == "0" && ddlBookAuthor.SelectedValue == "0")
            {
                ShowErrorMessage("Please select atleast one value");
                return;
            }
            strQry = "usp_BookDetails @command='BookDetailsReport',@intCategory_id='" + ddlBookCategory.SelectedValue.Trim() 
                + "',@intBookEdition_id='" + ddlBookEdition.SelectedValue.ToString()
                + "',@intBook_publication_id='" + ddlBookPublication.SelectedValue.ToString()
                + "',@intSchool_id='" + Convert.ToString(Session["School_id"]) 
                + "',@intBook_Author_id='" + ddlBookAuthor.SelectedValue.ToString() + "'";
            dsObj = sGetDataset(strQry);
            if (dsObj.Tables[0].Rows.Count > 0)
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                Session["BookDetailsReportTableDummy"] = dsObj;
            }
            else
            {
                grvDetail.DataSource = dsObj;
                grvDetail.DataBind();
                Session["BookDetailsReportTableDummy"] = dsObj;
            }
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }
    }

    protected void grvDetail_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvDetail.PageIndex = e.NewPageIndex;
        fGrid();
    }

    protected void getResult(object sender, EventArgs e)
    {
        fGrid();
    }

    protected void ExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Session["BookDetailsReportTable"] = Session["BookDetailsReportTableDummy"];
            if (grvDetail.Rows.Count > 0)
                Response.Redirect("frmExcel.aspx");
            else
                MessageBox("No Records found!");
        }
        catch (Exception ex)
        {
            LogException(ex);
            throw ex;
        }

    }
}