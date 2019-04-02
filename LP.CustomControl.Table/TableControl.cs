using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//the namespaces used in the control
using SourceCode.Forms.Controls.Web.SDK;
using SourceCode.Forms.Controls.Web.SDK.Attributes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Add the java script file to the control
[assembly: WebResource("LP.CustomControl.Table.Script.js", "text/javascript", PerformSubstitution = true)]

namespace LP.CustomControl.Table
{
    //Link to the definition file and the script file to the class
    [ControlTypeDefinition("LP.CustomControl.Table.Definition.xml")]
    [ClientScript("LP.CustomControl.Table.Script.js")]

    public class TableControl : BaseControl
    {
        protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
        {
            //View Designer
            writer.Write("<b>HelloWorldExample</b> <button id='btn1' style='color:red;'>Print</button><br /> <div>dadsa</div>");
        }
    }
}
