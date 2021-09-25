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
using System.Web;
using System.Data.SqlClient;
using System.Diagnostics;
//using System.Web.Mvc;


public partial class ClsExportPdf : DBUtility
{
    static int PgCount = 0;
    static int i = 1;
    public string strUserId, strQry, strQ, str;
    public int flag = 0, flag1 = 0;
    DataSet dsPersonal, dsObj, ds, ds1;
    int countPersonal, num = 2;
    System.IO.FileStream fs;
    public void Page_Load(object sender, EventArgs e,GridView grv,string FileName,int Roll,string Name,string STD,string DIV,string UserType,string HeaderName)
    {
        string strfnYear = string.Empty;
        PdfPCell cell;
        PdfPTable table;
        FileName = FileName.Replace("/", "");
        FileName = FileName.Replace(" ", "");
        FileName = FileName.Replace(":", "");
        
        if (!IsPostBack)
        {
            try
            {


               fs = new FileStream(Server.MapPath("Documents") + "\\" + FileName + ".pdf", FileMode.Create);
                Document doc = new Document(PageSize.A4);

                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                strfnYear = GetCurrentFinancialYear();
                
                writer.PageEvent = new PDFFooter();
                doc.Open();

                //PdfPTable tabFot = new PdfPTable(new float[] { 1F });




                //strQry = "exec usp_ReportDetails @type='SchoolDetails',@intSchoolId='" + Session["School_Id"]  + "'";
                //ds = sGetDataset(strQry);

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    table = new PdfPTable(1);
                //    table.WidthPercentage = 100;
                //    cell = new PdfPCell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["vchSchool_name"]), FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
                //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //    cell.Border = 0;
                //    table.AddCell(cell);
                //    doc.Add(table);



                //    table = new PdfPTable(1);
                //    table.WidthPercentage = 100;
                //    cell = new PdfPCell(new iTextSharp.text.Phrase(Convert.ToString(ds.Tables[0].Rows[0]["vchAddress"]), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)));
                //    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //    cell.Border = 0;
                //    table.AddCell(cell);
                //    doc.Add(table);





                table = new PdfPTable(1);
                table.WidthPercentage = 100;
                cell = new PdfPCell(new iTextSharp.text.Phrase(" ", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = 0;
                cell.FixedHeight = 55F;
                table.AddCell(cell);
                doc.Add(table);


                //if (Convert.ToString(Session["UserType_id"]) == "5")
                //{
                    iTextSharp.text.Table tbl;

                    tbl = new iTextSharp.text.Table(6, 4);
                    tbl.Width = 40;
                    tbl.Alignment = Element.ALIGN_LEFT;
                    //tbl.Cellpadding = 3;
                    tbl.Cellspacing = 3;
                    tbl.Border = 0;

                    Cell cel = new Cell(new iTextSharp.text.Phrase(" ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
                    cel.Border = 0;
                    cel.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel.Colspan = 6;
                    cel.VerticalAlignment = Element.ALIGN_TOP;
                    tbl.AddCell(cel);

                    cel = new Cell(new iTextSharp.text.Phrase(" ", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
                    cel.Border = 0;
                    cel.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel.Colspan = 6;
                    cel.VerticalAlignment = Element.ALIGN_TOP;
                    tbl.AddCell(cel);

                    if (UserType == "1")
                    {
                        cel = new Cell(new iTextSharp.text.Phrase("Student Name", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    }
                    if (UserType == "3")
                    {
                        cel = new Cell(new iTextSharp.text.Phrase("Staff Name", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    }
                    cel.Border = 0;
                    cel.Colspan = 2;
                    cel.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel.VerticalAlignment = Element.ALIGN_TOP;
                    tbl.AddCell(cel);

                    cel = new Cell(new iTextSharp.text.Phrase(": " + Name, FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
                    cel.Border = 0;
                    cel.Colspan = 4;
                    cel.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel.VerticalAlignment = Element.ALIGN_TOP;
                    tbl.AddCell(cel);


                    if (UserType == "1")
                    {
                        cel = new Cell(new iTextSharp.text.Phrase("Roll No.", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    }
                    else
                    {
                        cel = new Cell(new iTextSharp.text.Phrase("Emp No.", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    }
                    cel.Border = 0;
                    cel.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel.Colspan = 2;
                    cel.VerticalAlignment = Element.ALIGN_TOP;
                    tbl.AddCell(cel);

                    cel = new Cell(new iTextSharp.text.Phrase(": " + Convert.ToString(Roll), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
                    cel.Border = 0;
                    cel.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel.Colspan = 4;
                    cel.VerticalAlignment = Element.ALIGN_TOP;
                    tbl.AddCell(cel);



                    if (UserType == "1")
                    {
                        cel = new Cell(new iTextSharp.text.Phrase("Standard", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    }
                    else
                    {
                        cel = new Cell(new iTextSharp.text.Phrase("Department", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    }
                    cel.Border = 0;
                    cel.HorizontalAlignment = Element.ALIGN_LEFT;
                    cel.VerticalAlignment = Element.ALIGN_TOP;
                    cel.Colspan = 2;
                    tbl.AddCell(cel);

                    if (UserType == "1")
                    {
                        cel = new Cell(new iTextSharp.text.Paragraph(": " + Convert.ToString(STD), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
                        cel.Border = 0;
                        cel.HorizontalAlignment = Element.ALIGN_LEFT;
                        cel.VerticalAlignment = Element.ALIGN_TOP;
                        tbl.AddCell(cel);
                    }
                    else
                    {
                        cel = new Cell(new iTextSharp.text.Paragraph(": " + Convert.ToString(STD), FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)));
                        cel.Border = 0;
                        cel.HorizontalAlignment = Element.ALIGN_LEFT;
                        cel.VerticalAlignment = Element.ALIGN_TOP;
                        cel.Colspan = 4;
                        tbl.AddCell(cel);
                    }

                    if (UserType == "1")
                    {
                        cel = new Cell(new iTextSharp.text.Phrase("Division", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                        cel.Border = 0;
                        cel.HorizontalAlignment = Element.ALIGN_LEFT;
                        cel.VerticalAlignment = Element.ALIGN_TOP;
                        cel.Colspan = 2;
                        tbl.AddCell(cel);
                    }
                    else
                    {
                        cel = new Cell(new iTextSharp.text.Phrase("", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                        cel.Border = 0;
                        cel.HorizontalAlignment = Element.ALIGN_LEFT;
                        cel.VerticalAlignment = Element.ALIGN_TOP;
                        cel.Colspan = 2;
                        tbl.AddCell(cel);
                    }
                   

                    if (UserType == "1")
                    {
                        cel = new Cell(new iTextSharp.text.Phrase(": " + DIV, FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
                        cel.Border = 0;
                        cel.HorizontalAlignment = Element.ALIGN_LEFT;
                        cel.VerticalAlignment = Element.ALIGN_TOP;
                        tbl.AddCell(cel);
                    }
                    else
                    {
                        cel = new Cell(new iTextSharp.text.Phrase("", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)));
                        cel.Border = 0;
                        cel.HorizontalAlignment = Element.ALIGN_LEFT;
                        cel.VerticalAlignment = Element.ALIGN_TOP;
                        tbl.AddCell(cel);
                    }
                  


                    doc.Add(tbl);
               // }

                table = new PdfPTable(1);
                table.WidthPercentage = 100;
                cell = new PdfPCell(new iTextSharp.text.Phrase(Convert.ToString(""), FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE)));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = 0;
                cell.FixedHeight = 30F;
                table.AddCell(cell);
                doc.Add(table);


                table = new PdfPTable(1);
                table.WidthPercentage = 100;
                cell = new PdfPCell(new iTextSharp.text.Phrase(Convert.ToString(HeaderName), FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE)));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Border = 0;
                cell.FixedHeight = 30F;
                table.AddCell(cell);
                doc.Add(table);

               
               
                int columnsCount = grv.HeaderRow.Cells.Count;
                // Create the PDF Table specifying the number of columns
                PdfPTable pdfTable = new PdfPTable(columnsCount);
                pdfTable.WidthPercentage = 100;
                // Loop thru each cell in GrdiView header row
                foreach (TableCell gridViewHeaderCell in grv.HeaderRow.Cells)
                {
                    if (gridViewHeaderCell.Visible == false)
                    {
                        continue;
                    }
                    // Create the Font Object for PDF document
                    Font font = new Font();
                    // Set the font color to GridView header row font color
                   // font.Color = new BaseColor(grv.HeaderStyle.ForeColor);
                    font.Size = 10;
                    font.IsBold();
                    // Create the PDF cell, specifying the text and font
                    PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text.Replace("&nbsp;",""), font));
                    pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                   
                    // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                   // pdfCell.BackgroundColor = new BaseColor(grv.HeaderStyle.BackColor);

                    // Add the cell to PDF table
                    pdfTable.AddCell(pdfCell);
                }

                // Loop thru each datarow in GrdiView
                foreach (GridViewRow gridViewRow in grv.Rows)
                {
                    if (gridViewRow.RowType == DataControlRowType.DataRow)
                    {
                        // Loop thru each cell in GrdiView data row
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {
                            if (gridViewCell.Visible == false)
                            {
                                continue;
                            }

                            Font font = new Font();
                           // font.Color = new  BaseColor(grv.RowStyle.ForeColor);
                            font.Size = 8;
                            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text.Replace("&nbsp;", ""), font));
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                       //     pdfCell.BackgroundColor = new BaseColor(grv.RowStyle.BackColor);

                            pdfTable.AddCell(pdfCell);
                        }
                    }
                    else if (gridViewRow.RowType == DataControlRowType.Footer)
                    {
                        foreach (TableCell gridViewCell in gridViewRow.Cells)
                        {
                            if (gridViewCell.Visible == false)
                            {
                                continue;
                            }

                            Font font = new Font();
                            // font.Color = new  BaseColor(grv.RowStyle.ForeColor);
                            font.Size = 8;
                            PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text.Replace("&nbsp;", ""), font));
                            pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            //     pdfCell.BackgroundColor = new BaseColor(grv.RowStyle.BackColor);

                            pdfTable.AddCell(pdfCell);
                        }
                    }
                }

             

                // Create the PDF document specifying page size and margins

                //PdfWriter.GetInstance(doc, Response.OutputStream);

               
                doc.Add(pdfTable);
               
                //PDFGenerator();
                doc.Close();
                writer.Close();
                
                fs.Close();
                //Response.Redirect("~//Document/" +FileName);

                

                Process.Start(Server.MapPath("Documents") + "\\" + FileName + ".pdf");

            }
            catch (Exception ex)
            {
               // ShowMessage("Exeption :- " + ex.Message.ToString());
            }
            finally
            {

            }

        }
    }

    //public FileStreamResult PDFGenerator()
    //{
    //    ///byte[] labelBuffer  generate the buffer from pdf  
    //    MemoryStream ms = new MemoryStream();
    //    // ms.Write(labelBuffer, 0, labelBuffer.Length);
    //    byte[] ar = new byte[(int)fs.Length];
    //    ms.Position = 0;
    //    //Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
    //    return new FileStreamResult(ms, "application/pdf");
    //}

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
                cb.AddTemplate(footerTemplate, 150+len, document.PageSize.GetBottom(30));
                

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

    private void SetPDFPassword(string FullPathPdfFileName, string DownloadPDFFileName, string ForOpenPassword)
    {
        string sname = FullPathPdfFileName;
        string sname1 = new System.IO.FileInfo(FullPathPdfFileName).DirectoryName + "/A0007_EmpFormWithPassword.pdf";
        PdfReader reader = new PdfReader(sname);
        int n = reader.NumberOfPages;

        Document document = new Document(reader.GetPageSizeWithRotation(1));
        PdfWriter writer = PdfWriter.GetInstance(document, new System.IO.FileStream(sname1, System.IO.FileMode.Create));
        writer.SetEncryption(PdfWriter.STRENGTH128BITS, ForOpenPassword, null, PdfWriter.AllowPrinting);
        document.Open();
        PdfContentByte cb = writer.DirectContent;
        PdfImportedPage page = default(PdfImportedPage);
        int rotation = 0;
        int i = 0;

        while (i < n)
        {
            i += 1;
            document.SetPageSize(reader.GetPageSizeWithRotation(i));
            document.NewPage();
            page = writer.GetImportedPage(reader, i);
            rotation = reader.GetPageRotation(i);
            if (rotation == 90 || rotation == 270)
            {
                cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
            }
            else
            {
                cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);

            }
        }

        document.Close();
        writer.Close();

        System.IO.FileStream PDFfile = new System.IO.FileStream(sname1, System.IO.FileMode.Open);
        long FileSize = 0;
        FileSize = PDFfile.Length;
        byte[] buffer = new byte[Convert.ToInt32(FileSize)];
        PDFfile.Read(buffer, 0, Convert.ToInt32(FileSize));
        PDFfile.Close();
        ////// System.IO.File.Delete(sname1);
        Response.AddHeader("Content-Disposition", "attachment;filename=" + DownloadPDFFileName);
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(buffer);
        Response.Flush();
        Response.Close();

    }



}

