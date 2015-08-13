using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatterService.Common
{
    public class Constant
    {
    }

    public static class UploadPath
    {
        public static String Root { get { return HttpContext.Current.Server.MapPath("~/") + "\\"; } }
        public static String Temp { get { return Root + "Temp\\"; } }
        public static string PATH { get { return "~/App_Data" + "/" + DateTime.Now.ToString("yyyy") + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("dd"); } }



    }

    public sealed class Encription
    {
        public const string keyValue = "Teis";
    }

    public sealed class PetKind
    {
        public const int CAT = 1;
        public const int DOG = 2;
        
    }

}