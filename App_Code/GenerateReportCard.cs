using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using itext = iTextSharp.text;
using System.Data.SqlClient;
using System.Diagnostics;

/// <summary>
/// Summary description for GenerateReportCard
/// </summary>
public class GenerateReportCard : DBUtility
{
    static int PgCount = 0;
    static int i = 1;
    public string strUserId, strQry, strQ, str;
    public int flag = 0, flag1 = 0;
    string Result = "";
    string Rank = "";
    DataSet dsPersonal, dsObj, ds, ds1;
    int countPersonal, num = 2;
    System.IO.FileStream fs;
      string strfnYear = string.Empty;
        PdfPCell cell;
        PdfPTable table;
	public GenerateReportCard()
	{
		
	}
    public void FillTable(DataSet ds)
    {
        try
        {
            if (File.Exists(Server.MapPath("Documents") + "\\" + Convert.ToString(ds.Tables[0].Rows[0]["Name"]) + Convert.ToString(ds.Tables[0].Rows[0]["Examination"]) + ".pdf"))
            {
                File.Delete(Server.MapPath("Documents") + "\\" + Convert.ToString(ds.Tables[0].Rows[0]["Name"]) + Convert.ToString(ds.Tables[0].Rows[0]["Examination"]) + ".pdf");
            }
            fs = new FileStream(Server.MapPath("Documents") + "\\" + Convert.ToString(ds.Tables[0].Rows[0]["Name"]) + Convert.ToString(ds.Tables[0].Rows[0]["Examination"]) + ".pdf", FileMode.Create);
            Document doc = new Document(PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            strfnYear = GetCurrentFinancialYear();



            doc.Open();

            iTextSharp.text.Table tbl, tbl1, tbl2, tbl3, tbl4;

            tbl = new iTextSharp.text.Table(140, 20);
            tbl.Width = 100;
            tbl.Alignment = Element.ALIGN_LEFT;
            tbl.DefaultVerticalAlignment = Element.ALIGN_MIDDLE;
            //tbl.Cellpadding = 3;
            //  tbl.Cellspacing = 3;
            tbl.Border = 1;
            Cell cel;

            string imageURL = HttpContext.Current.Server.MapPath("images") + "\\pdflogo.jpg";
            iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(imageURL);
            img1.ScaleAbsoluteWidth(80);
            img1.ScaleAbsoluteHeight(80);


            cel = new Cell(img1);
            // cel.Border = 1;
            //cel.HorizontalAlignment = Element.ALIGN_LEFT;
            cel.Colspan = 20;
            cel.Rowspan = 8;
            //  cel.Border = Cell.BOTTOM_BORDER;
            //cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl.AddCell(cel);

            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["vchSchool_name"]), FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
            cel.Border = 0;
            cel.Rowspan = 3;
            cel.UseBorderPadding = true;
            //cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 100;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl.AddCell(cel);


            imageURL = HttpContext.Current.Server.MapPath("images") + "\\" + Convert.ToString(ds.Tables[0].Rows[0]["vchImageURL"]);
            img1 = iTextSharp.text.Image.GetInstance(imageURL);
            img1.ScaleAbsoluteWidth(70);
            img1.ScaleAbsoluteHeight(90);
            cel = new Cell(img1);
            //cel.Border = 0;
            cel.Colspan = 20;
            cel.Rowspan = 8;
            tbl.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["Address"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = 0;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 100;
            cel.Rowspan = 2;
            // cel.Border = Cell.LEFT_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase("Tel. "+Convert.ToString(ds.Tables[0].Rows[0]["Tel"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = 0;

            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 100;
            cel.Rowspan = 2;
            // cel.Border = Cell.LEFT_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl.AddCell(cel);



            cel = new Cell(new iTextSharp.text.Phrase(" ", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            // cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 100;
            cel.Rowspan = 2;
            //  cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl.AddCell(cel);

            doc.Add(tbl);

            tbl1 = new iTextSharp.text.Table(140, 50);
            tbl1.Width = 100;
            tbl1.Alignment = Element.ALIGN_LEFT;
            tbl1.Border = 1;
            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["Examination"]), FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
            //cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 140;
            //  cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl1.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase("Name :", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cel.Colspan = 20;
            cel.Rowspan = 2;

            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl1.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["Name"]).ToUpper(), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
            //cel.Border = 0;
            cel.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cel.Colspan = 120;
            cel.Rowspan = 2;
            cel.Border = Cell.RIGHT_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl1.AddCell(cel);

            cel = new Cell(new iTextSharp.text.Phrase("Std :", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cel.Colspan = 20;
            cel.Rowspan = 5;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl1.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["vchStandard_name"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
            cel.Border = 0;
            cel.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cel.Colspan = 30;
            cel.Rowspan = 5;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl1.AddCell(cel);

            cel = new Cell(new iTextSharp.text.Phrase("Div :", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = 0;
            cel.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cel.Colspan = 20;
            cel.Rowspan = 5;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl1.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["vchDivisionName"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
            cel.Border = 0;
            cel.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cel.Colspan = 30;
            cel.Rowspan = 5;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl1.AddCell(cel);

            cel = new Cell(new iTextSharp.text.Phrase("Roll No. :", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = 0;
            cel.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cel.Colspan = 20;
            cel.Rowspan = 5;
            //cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl1.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["RollNo"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
            cel.Border = Cell.RIGHT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
            cel.Colspan = 20;
            cel.Rowspan = 5;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl1.AddCell(cel);
            // doc.Add(tbl1);

            doc.Add(tbl1);



            table = new PdfPTable(2);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" "));
            cell.FixedHeight = 4f;
            cell.Border = Cell.LEFT_BORDER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(" "));
            cell.FixedHeight = 4f;
            cell.Border = Cell.RIGHT_BORDER;
            table.AddCell(cell);
            doc.Add(table);


            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" "));
            cell.FixedHeight = 20f;
            cell.Border = 1;
            table.AddCell(cell);
            doc.Add(table);


            tbl2 = new iTextSharp.text.Table(180, 50);
            tbl2.Width = 100;
            tbl2.Border = 1;
            tbl2.DefaultVerticalAlignment = Element.ALIGN_MIDDLE;
            cel = new Cell(new iTextSharp.text.Phrase("Subject", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            // cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.UseBorderPadding = true;
            cel.Colspan = 60;
            cel.Rowspan = 2;
            // cel.Border = 1;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl2.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase("Max Marks", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            // cel.Border =1;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 40;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl2.AddCell(cel);

            cel = new Cell(new iTextSharp.text.Phrase("Min Marks", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            //cel.Border = 1;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 40;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl2.AddCell(cel);

            cel = new Cell(new iTextSharp.text.Phrase("Marks Obtain", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            // cel.Border = 1;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 40;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl2.AddCell(cel);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[i]["vchSubjectName"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
                //cel.Border = Cell.LEFT_BORDER;
                cel.HorizontalAlignment = Element.ALIGN_CENTER;
                cel.Colspan = 60;
                cel.Rowspan = 2;
                // cel.Border = Cell.BOTTOM_BORDER;
                // cel.VerticalAlignment = Element.ALIGN_TOP;
                tbl2.AddCell(cel);

                cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[i]["intMaxMark"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
                // cel.Border = Cell.LEFT_BORDER;
                cel.HorizontalAlignment = Element.ALIGN_CENTER;
                cel.Colspan = 40;
                cel.Rowspan = 2;
                // cel.Border = Cell.BOTTOM_BORDER;
                //  cel.VerticalAlignment = Element.ALIGN_TOP;
                tbl2.AddCell(cel);

                cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[i]["intMinMark"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
                //cel.Border = Cell.LEFT_BORDER;
                cel.HorizontalAlignment = Element.ALIGN_CENTER;
                cel.Colspan = 40;
                cel.Rowspan = 2;
                // cel.Border = Cell.BOTTOM_BORDER;
                // cel.VerticalAlignment = Element.ALIGN_TOP;
                tbl2.AddCell(cel);

                cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[i]["decMark"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
                // cel.Border = Cell.LEFT_BORDER;
                cel.HorizontalAlignment = Element.ALIGN_CENTER;
                cel.Colspan = 40;
                cel.Rowspan = 2;
                // cel.Border = Cell.BOTTOM_BORDER;
                //  cel.VerticalAlignment = Element.ALIGN_TOP;
                tbl2.AddCell(cel);
            }

            doc.Add(tbl2);

            table = new PdfPTable(1);

            cell = new PdfPCell(new Phrase(" "));
            cell.FixedHeight = 10f;
            cell.Border = 0;
            table.AddCell(cell);
            doc.Add(table);


            tbl3 = new iTextSharp.text.Table(180, 50);
            tbl3.Width = 100;
            cel = new Cell(new iTextSharp.text.Phrase("Total", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 60;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl3.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["MaxTotal"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 40;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl3.AddCell(cel);

            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["MinTotal"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 40;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl3.AddCell(cel);

            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["ObtainMark"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 40;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl3.AddCell(cel);

            doc.Add(tbl3);


            table = new PdfPTable(1);

            cell = new PdfPCell(new Phrase(" "));
            cell.FixedHeight = 15f;
            cell.Border = 0;
            table.AddCell(cell);
            doc.Add(table);


            tbl3 = new iTextSharp.text.Table(180, 50);
            tbl3.Width = 100;
            cel = new Cell(new iTextSharp.text.Phrase("Percentage", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 60;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl3.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase("Rank", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 60;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl3.AddCell(cel);

            cel = new Cell(new iTextSharp.text.Phrase("Result (Pass/Fail)", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 60;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl3.AddCell(cel);


            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["Percent"]), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 60;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl3.AddCell(cel);

           
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["Result"].ToString() == "Fail")
                {
                    Result = "Fail";
                    Rank = "-";
                    break;
                }
                else
                {
                    Result = "Pass";
                    Rank = Convert.ToString(ds.Tables[0].Rows[0]["Rank"]);
                }
            }

            cel = new Cell(new iTextSharp.text.Phrase(Rank, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 60;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl3.AddCell(cel);

            cel = new Cell(new iTextSharp.text.Phrase(Convert.ToString(Result), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            cel.Border = Cell.LEFT_BORDER;
            cel.HorizontalAlignment = Element.ALIGN_CENTER;
            cel.Colspan = 60;
            cel.Rowspan = 2;
            // cel.Border = Cell.BOTTOM_BORDER;
            cel.VerticalAlignment = Element.ALIGN_TOP;
            tbl3.AddCell(cel);
            doc.Add(tbl3);

            table = new PdfPTable(1);

            cell = new PdfPCell(new Phrase(" "));
            cell.FixedHeight = 5f;
            cell.Border = 0;
            table.AddCell(cell);
            doc.Add(table);






            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" "));
            cell.FixedHeight = 2f;
            cell.Border = Cell.LEFT_BORDER;
            table.AddCell(cell);


            cell = new PdfPCell(new iTextSharp.text.Phrase("Teacher's Remark", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            //  cell.FixedHeight = 20f;
            cell.Border = 1;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new iTextSharp.text.Phrase(" ", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
              cell.FixedHeight = 20f;
            cell.Border = 1;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            // cell.Border = 1;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(""));
            //  cell.FixedHeight = 20f;
            //cell.Border = 1;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Border = Cell.BOTTOM_BORDER; ;
            table.AddCell(cell);

            doc.Add(table);





            table = new PdfPTable(1);

            cell = new PdfPCell(new Phrase(" "));
            cell.FixedHeight = 5f;
            cell.Border = 0;
            table.AddCell(cell);
            doc.Add(table);


            table = new PdfPTable(2);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" "));
            cell.FixedHeight = 40f;
            cell.Border = Cell.LEFT_BORDER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(" "));
            cell.FixedHeight = 40f;
            cell.Border = Cell.RIGHT_BORDER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Parent Sign"));
            //  cell.FixedHeight = 20f;
            cell.Border = Cell.LEFT_BORDER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Principal"));
            //  cell.FixedHeight = 20f;
            cell.Border = Cell.RIGHT_BORDER;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            // cell.Border = 1;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(""));
            //  cell.FixedHeight = 20f;
            cell.Colspan = 2;
            cell.Border = Cell.BOTTOM_BORDER;
            table.AddCell(cell);

            doc.Add(table);


            doc.Close();
            writer.Close();
            fs.Close();
            //Response.Redirect("~//Document/" +FileName);

            //Process.Start(Server.MapPath("Documents") + "\\" + Convert.ToString(ds.Tables[0].Rows[0]["Name"]) + Convert.ToString(ds.Tables[0].Rows[0]["Examination"]) + ".pdf");

            Process process = new Process();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = Server.MapPath("Documents") + "\\" + Convert.ToString(ds.Tables[0].Rows[0]["Name"]) + Convert.ToString(ds.Tables[0].Rows[0]["Examination"]) + ".pdf";
            process.Start();
        }
        catch
        {
            
           
        }
       
    }
    public class PDFFooter : PdfPageEventHelper
    {

        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;


        #region Fields
        private string _header;
        #endregion

        #region Properties
        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }
        #endregion


        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(100, 100);
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException de)
            {

            }
            catch (System.IO.IOException ioe)
            {

            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);

            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);

            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 10f, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLACK);

            Phrase p1Header = new Phrase("Deep Global School", baseFontBig);

            //Create PdfTable object
            PdfPTable pdfTab = new PdfPTable(3);

            //We will have to create separate cells to include image logo and 2 separate strings
            //Row 1
            string imageURL = HttpContext.Current.Server.MapPath("images") + "\\pdflogo.jpg";
            iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(imageURL);
            img1.ScaleAbsoluteWidth(40);
            img1.ScaleAbsoluteHeight(40);


            PdfPCell pdfCell1 = new PdfPCell(img1);
            PdfPCell pdfCell2 = new PdfPCell(p1Header);
            PdfPCell pdfCell3 = new PdfPCell();
            String text = "Page " + writer.PageNumber + " of ";


            //Add paging to header
            //{
            //    cb.BeginText();
            //    cb.SetFontAndSize(bf, 12);
            //    cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(45));
            //    cb.ShowText(text);
            //    cb.EndText();
            //    float len = bf.GetWidthPoint(text, 12);
            //    //Adds "12" in Page 1 of 12
            //    cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
            //}
            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 12);
                cb.SetTextMatrix(150, document.PageSize.GetBottom(30));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 12);
                cb.AddTemplate(footerTemplate, 150 + len, document.PageSize.GetBottom(30));


                cb.BeginText();
                cb.SetFontAndSize(bf, 6);
                cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetBottom(20));
                cb.ShowText("Pdf Format");
                cb.EndText();
                len = bf.GetWidthPoint("Pdf Format", 6);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetBottom(20));
            }
            //Row 2
            PdfPCell pdfCell4 = new PdfPCell(new Phrase("Chembur (East), Pin : 400022", baseFontNormal));
            //Row 3
            DateTime dt = DateTime.Today;

            PdfPCell pdfCell5 = new PdfPCell(new Phrase("Date:" + PrintTime.ToShortDateString(), baseFontNormal));
            PdfPCell pdfCell6 = new PdfPCell();
            PdfPCell pdfCell7 = new PdfPCell(new Phrase("Time:" + DateTime.Now.ToString("hh:mm tt"), baseFontNormal));


            //set the alignment of all three cells and set border to 0
            pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell7.HorizontalAlignment = Element.ALIGN_CENTER;


            pdfCell1.VerticalAlignment = Element.ALIGN_BOTTOM;
            pdfCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell3.VerticalAlignment = Element.ALIGN_TOP;
            pdfCell4.VerticalAlignment = Element.ALIGN_TOP;
            pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE;


            pdfCell4.Colspan = 3;



            pdfCell1.Border = 0;
            pdfCell2.Border = 0;
            pdfCell3.Border = 0;
            pdfCell4.Border = 0;
            pdfCell5.Border = 0;
            pdfCell6.Border = 0;
            pdfCell7.Border = 0;


            //add all three cells into PdfTable
            pdfTab.AddCell(pdfCell1);
            pdfTab.AddCell(pdfCell2);
            pdfTab.AddCell(pdfCell3);
            pdfTab.AddCell(pdfCell4);
            pdfTab.AddCell(pdfCell5);
            pdfTab.AddCell(pdfCell6);
            pdfTab.AddCell(pdfCell7);

            pdfTab.TotalWidth = document.PageSize.Width - 80f;
            pdfTab.WidthPercentage = 70;
            //pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;


            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
            pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
            //set pdfContent value

            //Move the pointer and draw line to separate header section from rest of page
            cb.MoveTo(40, document.PageSize.Height - 100);
            cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
            cb.Stroke();

            //Move the pointer and draw line to separate footer section from rest of page
            cb.MoveTo(40, document.PageSize.GetBottom(50));
            cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
            cb.Stroke();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            headerTemplate.BeginText();
            headerTemplate.SetFontAndSize(bf, 12);
            headerTemplate.SetTextMatrix(0, 0);
            headerTemplate.ShowText((writer.PageNumber - 1).ToString());
            headerTemplate.EndText();

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 12);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();


        }







        //// write on top of document
        //public override void OnOpenDocument(PdfWriter writer, Document document)
        //{
        //    base.OnOpenDocument(writer, document);
        //    //PdfPTable tabFot = new PdfPTable(new float[] { 1F });
        //    //tabFot.SpacingAfter = 10F;
        //    //PdfPCell cell;
        //    //tabFot.TotalWidth = 300F;
        //    //cell = new PdfPCell(new Phrase("Header"));
        //    //tabFot.AddCell(cell);
        //    //tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);


        //    //----On Open-----//

        //    //PdfPTable table = new PdfPTable(1);
        //    //table.TotalWidth = 300F;
        //    //string imageURL = HttpContext.Current.Server.MapPath("images") + "\\ShellEx_ logo.jpg";
        //    //iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(imageURL);
        //    //img1.ScaleAbsoluteWidth(70);
        //    //img1.ScaleAbsoluteHeight(40);
        //    //PdfPCell cell = null;
        //    //cell = new PdfPCell(img1);
        //    //cell.Border = 0;
        //    //cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    //table.AddCell(cell);
        //    //table.WriteSelectedRows(0, -1, 100, document.Top , writer.DirectContent);


        //}

        //// write on start of each page
        //public override void OnStartPage(PdfWriter writer, Document document)
        //{
        //    base.OnStartPage(writer, document);
        //    //base.OnOpenDocument(writer, document);
        //    //PdfPTable tabFot = new PdfPTable(new float[] { 1F });
        //    //tabFot.SpacingAfter = 10F;
        //    //PdfPCell cell;
        //    //tabFot.TotalWidth = 300F;
        //    //cell = new PdfPCell(new Phrase("Header"));
        //    //tabFot.AddCell(cell);
        //    //tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);

        //    PdfPTable table = new PdfPTable(1);
        //    table.WidthPercentage = 300F;
        //    PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase("SWP School ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell.Border = 0;
        //    table.AddCell(cell);
        //    table.WriteSelectedRows(0, -1, 250, document.Top, writer.DirectContent);



        //    table = new PdfPTable(1);
        //    table.WidthPercentage = 100F;
        //    cell = new PdfPCell(new iTextSharp.text.Phrase("Chembur (East)", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)));
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell.Border = 0;
        //    table.AddCell(cell);
        //    table.WriteSelectedRows(0, -1, 250, document.Top, writer.DirectContent);





        //    table = new PdfPTable(1);
        //    table.WidthPercentage = 100F;
        //    cell = new PdfPCell(new iTextSharp.text.Phrase("Pin : " + "4000222", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)));
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell.Border = 0;
        //    table.AddCell(cell);
        //    table.WriteSelectedRows(0, -1, 250, document.Top, writer.DirectContent);

        //    table = new PdfPTable(1);
        //    table.WidthPercentage = 100F;
        //    cell = new PdfPCell(new iTextSharp.text.Phrase("www.swp.com", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)));
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell.Border = 0;
        //    table.AddCell(cell);
        //    table.WriteSelectedRows(0, -1, 250, document.Top, writer.DirectContent);



        //    table = new PdfPTable(1);
        //    table.TotalWidth = 300F;
        //    string imageURL = HttpContext.Current.Server.MapPath("images") + "\\attendence.png";
        //    iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(imageURL);
        //    img1.ScaleAbsoluteWidth(80);
        //    img1.ScaleAbsoluteHeight(35);

        //    cell = new PdfPCell(img1);
        //    cell.Border = 0;
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    table.AddCell(cell);
        //    //table.WriteSelectedRows(0, -1, 250, document.Top, writer.DirectContent);
        //    table.WriteSelectedRows(0, -1, 0 , document.Top, writer.DirectContent);

        //}

        //// write on end of each page
        //public override void OnEndPage(PdfWriter writer, Document document)
        //{

        //    base.OnEndPage(writer, document);
        //    int pageN = writer.PageNumber;
        //    String text = "Page: " + pageN.ToString() + " of 5";
        //    //PdfPTable tabFot = new PdfPTable(new float[] { 1F });
        //    //PdfPCell cell;
        //    //tabFot.TotalWidth = 300F;
        //    //cell = new PdfPCell(new Phrase("Footer"));
        //    //tabFot.AddCell(cell);
        //    //tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
        //    PdfPCell cell = null;
        //    PdfPTable table = new PdfPTable(3);
        //    table.WidthPercentage = 100;
        //    table.HorizontalAlignment = Element.ALIGN_LEFT;
        //    table.TotalWidth = 500F;

        //    cell = new PdfPCell(new Phrase("Private & Strictly Confidential", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
        //    cell.Border = 0;
        //    cell.HorizontalAlignment = Element.ALIGN_LEFT;

        //    table.AddCell(cell);
        //    cell = new PdfPCell(new Phrase(text, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
        //    cell.Border = 0;
        //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    table.AddCell(cell);
        //    string imageURL = HttpContext.Current.Server.MapPath("images") + "\\attendence.png";
        //    iTextSharp.text.Image img1 = iTextSharp.text.Image.GetInstance(imageURL);
        //    img1.ScaleAbsoluteWidth(50);
        //    img1.ScaleAbsoluteHeight(30);

        //    cell = new PdfPCell(img1);
        //    cell.Border = 0;
        //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    table.AddCell(cell);
        //    table.WriteSelectedRows(0, -1, 50, document.Bottom, writer.DirectContent);
        //}

        ////write on close of document
        //public override void OnCloseDocument(PdfWriter writer, Document document)
        //{
        //    base.OnCloseDocument(writer, document);
        //}
    }
}