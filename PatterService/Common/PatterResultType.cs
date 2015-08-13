using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatterService.Common
{
    //[JsonObject]
    public class PatterResultType
    {
        public string JsonDataSet;
        public bool IsSuccessful;
        public int AffectedRow; 
        public string ErrorCode;
        public string ErrorMessage;
        public int ScalarValue; 
        public string StringValue;
    }
}