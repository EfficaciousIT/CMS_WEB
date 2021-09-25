using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class fileuploadall : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FileUpload1.Attributes["onchange"] = "UploadFile(this)";
    }
    protected void Upload(object sender, EventArgs e)
    {
        FileUpload1.SaveAs(Server.MapPath("~/Documents/Vacation/" + Path.GetFileName(FileUpload1.FileName)));
        lblMessage.Visible = true;
    }
}