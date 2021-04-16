using System;

public partial class Automatizado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        Permisos permiso = new Permisos();
        int pantalla = 11;
        if (permiso.returnPermiso(usuario, pantalla) != "Programacion de Tareas")
        {
            Response.Redirect("~/IOT/Home");
        }
    }
}