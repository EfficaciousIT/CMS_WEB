using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

public partial class frmviewSyllabusDoc : System.Web.UI.Page
{
    string FilePath = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Path"].ToString() != "")
            {                
                ViewState["Path"] = Request.QueryString["path"].ToString();
            }
            else
            {                
                ViewState["Path"] = Session["path"];
            }
            String ext = System.IO.Path.GetExtension(Convert.ToString(ViewState["Path"]).Substring(Convert.ToString(ViewState["Path"]).Length - 4, 4));
            FilePath = Server.MapPath("~"+ViewState["Path"].ToString());
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            FileInfo file = new FileInfo(FilePath);
            //FileInfo file = new FileInfo(FilePath);
            //E:\New\e-SMS1\Documents\syllabus\5\14\41
            if (FileBuffer != null)
            {
                if (ext == ".txt")
                {
                    System.Diagnostics.Process.Start("E:\\New\\e-SMS1\\Documents\\syllabus\\5\\14\\41\\Requirement for Vts module.docx");
                    HttpContext.Current.Response.ContentType = "text/plain";
                    HttpContext.Current.Response.AddHeader("content-length", file.Length.ToString());
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment; filename=\"" + file.Name + "");
                    HttpContext.Current.Response.TransmitFile(file.FullName);
                    HttpContext.Current.Response.Flush();
                    
                }
                else if (ext == ".xlsx")
                {
                    Response.ContentType = "application/ms-excel";
                    Response.AddHeader("content-length", file.Length.ToString());
                    Response.AddHeader("Content-Disposition", "Attachment; filename=\"" + file.Name + "");
                    Response.TransmitFile(file.FullName);
                }
                else if (ext == ".pdf")
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }
                else if (ext == ".doc")
                {
                    Response.ContentType = "application/ms-word";
                    Response.AddHeader("content-length", file.Length.ToString());
                    Response.AddHeader("Content-Disposition", "Attachment; filename=\"" + file.Name + "");
                    Response.TransmitFile(file.FullName);
                }
                else if (ext == ".docx")
                {
                    Response.ContentType = "application/ms-word";
                    Response.AddHeader("content-length", file.Length.ToString());
                    Response.AddHeader("Content-Disposition", "Attachment; filename=\"" + file.Name + "");
                    Response.TransmitFile(file.FullName);
                }
                else
                {
                    switch (ext)
                    {
                        case ".pdf": Response.ContentType = "application/pdf"; break;
                        case ".swf": Response.ContentType = "application/x-`-flash"; break;

                        case ".gif": Response.ContentType = "image/gif"; break;
                        case ".jpeg": Response.ContentType = "image/jpg"; break;
                        case ".jpg": Response.ContentType = "image/jpg"; break;
                        case ".png": Response.ContentType = "image/png"; break;

                        case ".mp4": Response.ContentType = "video/mp4"; break;
                        case ".mpeg": Response.ContentType = "video/mpeg"; break;
                        case ".mov": Response.ContentType = "video/quicktime"; break;
                        case ".wmv":
                        case ".avi": Response.ContentType = "video/x-ms-wmv"; break;

                        //and so on          

                        default: Response.ContentType = "application/octet-stream"; break;
                    }
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                    Response.End();
                }
            }
        }
        catch (System.Threading.ThreadAbortException lException)
        {

            // do nothing

        }
    }
}