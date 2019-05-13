using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.FinalTask.PhotoAlbum.MVCWebUI.CustomAttributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxSize;

        public MaxFileSizeAttribute(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;

            if (file == null)
            {
                return false;
            }

            if (file.ContentLength > maxSize)
            {
                return false;
            }

            return true;
        }
    }
}