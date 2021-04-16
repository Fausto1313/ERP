using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskScheduler;
using System.Configuration;
using System.Data.SqlClient;

public partial class appActivariOS : System.Web.UI.Page
{

    private SqlConnection con = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=appAndroid;User ID=sa;Password=sa+LANSA!;Pooling=False");
    private SqlConnection con2 = new SqlConnection("Data Source=WIN-OQ2KAEBCJAI\\SQLS14L14;Initial Catalog=IOTComer;User ID=sa;Password=sa+LANSA!;Pooling=False");
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime fInicial = DateTime.Now, fFinal = DateTime.Now;
        String usser = null, pass = null;
        int aux = Convert.ToInt32(Request["v1"]);
        if (aux == 1)
        {
            fInicial = Convert.ToDateTime(Request["v2"]);
            fFinal = Convert.ToDateTime(Request["v3"]);
            insertarSeguridadiOS(fInicial, fFinal);
        }
        else
        {
            usser = Request["v2"];
            pass = Request["v3"];
            if (comprueba(usser, pass))
            {
                actualizar();
                Response.Write("True");
            }
            else
            {
                Response.Write("False");
            }
        }
    }

    protected void insertarSeguridadiOS(DateTime fIni, DateTime fFin){
        String status = "Activo";
        con2.Open();
        String updatecmd = "INSERT into Activador (FechaInicio, FechaFin, Estatus) VALUES (@FechaInicio, @FechaFin, @Estatus)";
        SqlCommand cmd = new SqlCommand(updatecmd, con2);
        cmd.Parameters.AddWithValue("@FechaInicio", fIni);
        cmd.Parameters.AddWithValue("@FechaFin", fFin);
        cmd.Parameters.AddWithValue("@Estatus", status);
        try{
            cmd.ExecuteNonQuery();
         }
         catch(Exception e){
             
         }
        con2.Close();
        Response.Write("True");
    }

    private bool comprueba(string user, string pass){
            bool context = false;
            string pss = null;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Password FROM Login where UserName=@user", con);
            cmd.Parameters.AddWithValue("@user", user);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                pss = Convert.ToString(dr[0]);
            }
            con.Close();
            if (pss != null)
            {
                if (pass == pss)
                {
                    context = true;
                }
            }
            else
                context = false;
            return context;
        }

        private void actualizar()
        {
            DateTime nombre = DateTime.Now;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update Activador set Estatus='Inactivo' where (FechaInicio <= @nombre and FechaFin >= @nombre) or (FechaInicio >= @nombre)";
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Connection = con2;
            con2.Open();
            cmd.ExecuteNonQuery();
            con2.Close();
        }
    }