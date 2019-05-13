using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.CustomAttributes
{
    public class ValidImageFormatAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    if (img.RawFormat.Equals(ImageFormat.Png) ||
                        img.RawFormat.Equals(ImageFormat.Jpeg))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}