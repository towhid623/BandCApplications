using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models
{
    public class VmQuesAns
    {
        [AllowHtml]
        public string ApplicationXml { get; set; }
    }
}