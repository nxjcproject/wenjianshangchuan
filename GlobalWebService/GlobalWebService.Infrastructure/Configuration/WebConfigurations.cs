using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalWebService.Infrastructure.Configuration
{
    public class WebConfigurations
    {
        public static string FileRootPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["FileRootPath"] != null ? System.Configuration.ConfigurationManager.AppSettings["FileRootPath"].ToString() : "C:\\UserUploadFiles";
            }
        }
    }
}
