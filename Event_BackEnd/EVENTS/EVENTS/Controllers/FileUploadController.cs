using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;



namespace EVENTS.Controllers
{
    public class FileUploadController : ApiController
    {
        [HttpPost]
        [ActionName("uploadFile")]
        public KeyValuePair<bool, string> UploadFile()
        {
            Boolean fileOK = false;
            // Get the uploaded image from the Files collection
            var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
            string fileName = httpPostedFile.FileName.Replace(" ","");
            string fileSavePath = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + fileName);

            Console.WriteLine(httpPostedFile);
            if (httpPostedFile != null)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(httpPostedFile.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }
            if (fileOK)
            {
                try
                {
                    httpPostedFile.SaveAs(fileSavePath);
                    return new KeyValuePair<bool, string>(true, "File uploaded successfully.");
                }
                catch (Exception ex)
                {
                    return new KeyValuePair<bool, string>(false, "An error occurred while uploading the file. Error Message: " + ex.Message);
                }

            }
            else
            {
                return new KeyValuePair<bool, string>(false, "Cannot accept files with this type. Applicable extensions are .gif, .png, .jpeg, .jpg");
            }



        }
    }
}
    

