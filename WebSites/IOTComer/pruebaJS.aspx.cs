using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pruebaJS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string cadenita = "Flancisco es una piluja";
        //System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //sb.Append(@"<script type='text/javascript'>");
        //sb.Append();
        ////sb.Append("$('#addModalNivel3').modal('hide');");
        //sb.Append(@"</script>");
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "hehe", sb.ToString(), false);

        Response.Write("<script type='text/javascript'>");
        Response.Write("var i = '"+cadenita+"Y de las balatas;';");
        Response.Write("alert(i);");
        Response.Write("var holi = document.getElementById('prueba1');");
        //Response.Write("alert(holi + ' hehe');");
        Response.Write("console.log(i);");
        Response.Write("</script>");

    }
}