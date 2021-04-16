using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eliminarTareas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime sd = DateTime.Today;
        sd = sd.AddDays(-1);
        string g = sd.ToString("yyyy-MM-dd");
        Response.Write(g);

    }

    //protected bool deleteTask() {

    //}
}