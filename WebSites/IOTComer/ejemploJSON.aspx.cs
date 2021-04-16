using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ejemploJSON : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string js = string.Empty;
        List<JSON> ejemplo = new List<JSON>();
        for (int i = 0; i < 5; i++) {
            JSON j = new JSON();
            j.riscei = "1710LU200" + i;
            if (i % 2 == 0)
                j.accion = "ON";
            else
                j.accion = "OFF";
            ejemplo.Add(j);
        }
        Response.ContentType = "application/json; charset=utf-8";
        js = JsonConvert.SerializeObject(ejemplo);
        Response.Write(js);
    }

    public class JSON {
        public string riscei { get; set; }
        public string accion { get; set; }
    }
}