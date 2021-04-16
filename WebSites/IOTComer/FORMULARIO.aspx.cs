using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FORMULARIO : System.Web.UI.Page
{

    private SqlConnection conn = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=multicliente;User ID=sa;Password=sa+LANSA!;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {

        }
    } 
    protected void Button_Click(object sender, EventArgs e)    {
       
        string Activador = txtActivador.Text;
        string Nombre = txtNombre.Text;
        DateTime Inicio = inicio.SelectedDate;
        DateTime Fin = fin.SelectedDate;
        string Estatus = Habilitar.Text;
        ExecuteAdd(Activador, Nombre,Inicio, Fin, Estatus);

    }
    private void ExecuteAdd(string Activador, string Nombre, DateTime Inicio, DateTime Fin, string Estatus)

    {

        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);

        con.Open();

        string updatecmd = "insert into Activador (cveActivador,Nombre, FechaInicio, FechaFin, Estatus ) values (@cveActivador, @Nombre,@FechaInicio,@FechaFin,@Estatus)";
        SqlCommand addCmd = new SqlCommand(updatecmd, con);
        addCmd.Parameters.AddWithValue("@cveActivador", Activador);
        addCmd.Parameters.AddWithValue("@Nombre",Nombre);
        addCmd.Parameters.AddWithValue("@FechaInicio",Inicio);
        addCmd.Parameters.AddWithValue("@FechaFin",Fin);
        addCmd.Parameters.AddWithValue("@Estatus",Estatus);
        addCmd.ExecuteNonQuery();
        con.Close();

    }
  
}


       