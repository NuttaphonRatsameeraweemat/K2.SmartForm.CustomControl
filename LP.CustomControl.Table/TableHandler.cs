using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using LP.CustomControl.Helper;

// SourceCode namespaces used in the control
using SourceCode.Forms.Controls.Web.SDK.Attributes;

// Adding the AJAX Handler Class
// This topic takes the Hello World custom control example and adds a handler class for using AJAX calls.
// Two things are needed:
// - A new public class in the HelloWorld namespace
// - An IHttpHandler definition within the new class

namespace LP.CustomControl.Table
{

    [ClientAjaxHandler("TableHandler")]
    public class Handler : IHttpHandler
    {
        bool IHttpHandler.IsReusable
        {
            get
            {
                return true;
            }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            string name = context.Request.QueryString["name"];
            if (string.IsNullOrEmpty(name))
                name = "(Unknown)";

            context.Response.Write(string.Format("Hello {0}, {1}", name, DateTime.Now.ToString("o")));

            //Get Smartobject
            SmartObjectControl service = new SmartObjectControl();

            var result = service.GetSmartObject("", "");

            //Mapping Smartobject to ViewModel

            //Return string json

        }
    }
}