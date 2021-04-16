using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

public partial class prueba : System.Web.UI.Page
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = string.Empty, comando = string.Empty, comando2 = string.Empty;
        usuario = Request["user"];
        comando = Request["comando"];
        
        comando2 = comando.ToUpper();
        if (comando2.Contains("NOTIFICACION"))
        avisoLLegada(usuario,comando2);

    }
    protected void avisoLLegada(string usuario, string comando) {
        comando = returnCadena(comando);
        int contador = 0;
        List<Empleado> resultado = returnEmpleados(usuario,1,"");
        List<int> numeros = returnNames(resultado, comando), segundos;
        contador = numeros.Count;
        if (contador == 1) {
            //Response.Write(resultado[numeros[0]].IDEmpleado + " " + resultado[numeros[0]].nombreEmpleado + " " + resultado[numeros[0]].apellidoEmpleado);
            if (programRule(resultado[numeros[0]].IDEmpleado, usuario))
                Response.Write("True");
            else
                Response.Write("False");
        }
        else if (contador > 1)
        {
            segundos = returnSurnames(resultado, comando, numeros);
            if (segundos.Count == 1)
            {
                //Response.Write(resultado[segundos[0]].IDEmpleado + " " + resultado[segundos[0]].nombreEmpleado + " " + resultado[segundos[0]].apellidoEmpleado);
                if (programRule(resultado[segundos[0]].IDEmpleado, usuario))
                    Response.Write("True");
                else
                    Response.Write("False");
            }
            else if (segundos.Count > 1)
                Response.Write("Multiples\n");
            else
                Response.Write("Falta apellidos");
        }

        else
            Response.Write("No existe");
    }

    protected bool programRule(int id, string usuario)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(ID) from CanalEmpleados where ID_Empleado = @id " +
                "if (select COUNT(ID) from CanalEmpleados where ID_Empleado = @id ) >= 1 " +
                "begin update CanalEmpleados set Estatus = 'Habilitado' where ID_Empleado = @id and Tipo = " +
                "'Unico' and ID_Telegram in (select CanalTelegram from CanalTelegram where Usuario = " +
                "@usuario and Primario = 'Primario') end " +
                "else begin insert into CanalEmpleados(ID_Sitio, ID_empleado, ID_Telegram, Tipo, Estatus) values " +
                "((select Sitio from Empleado where ID = @id ), @id, (select CanalTelegram from CanalTelegram where " +
                "Usuario = @usuario and Primario = 'Primario' and ID_Sitio = (select Sitio from Empleado where " +
                "ID = @id)), 'Unico', 'Habilitado') end", con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }
        catch (Exception e){
            Response.Write(e);
            return false;
        }
    }

    protected List<int> returnNames(List<Empleado> resultado, string comando) {
        List<int> num = new List<int>();
        int contador = 0;
        string auxiliar = string.Empty, auxiliar2 = string.Empty;
        contador = resultado.Count;
        if (contador > 0)
        {
            for (int i = 0; i < contador; i++)
            {
                auxiliar = resultado[i].nombreEmpleado.ToUpper();
                if (comando.Contains(auxiliar))
                {
                    num.Add(i);

                }
            }
        }
        return num;
    }

    protected List<int> returnSurnames(List<Empleado> resultado, string comando, List<int> ides)
    {
        List<int> num = new List<int>();
        int contador = 0;
        string auxiliar = string.Empty, auxiliar2 = string.Empty;
        contador = ides.Count;
        if (contador > 0)
        {
            for (int i = 0; i < contador; i++)
            {
                auxiliar = resultado[ides[i]].apellidoEmpleado.ToUpper();
                if (comando.Contains(auxiliar))
                {
                    num.Add(ides[i]);
                }
            }
        }
        return num;
    }

    protected List<Empleado> returnEmpleados(string usuario, int tipo, string sitio)
    {
        List<Empleado> e = new List<Empleado>();
        con.Open();
        SqlCommand cmd;
        string query = string.Empty;
        if (tipo == 1)
        {
            query = "select ID, Nombre, Apellidos from Empleado where Sitio = " +
            "(select C_Sitio from AspNetUsers where UserName = @usuario)";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
        }

        else {
            query = "select ID, Nombre, Apellidos from Empleado where Sitio in " +
                "(select ID from Sitios where Descripcion = @sitio and ID_Cliente = " +
                "(select ID_Cliente from AspNetUsers where UserName = @usuario))";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@sitio", sitio);
        }
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            Empleado ob = new Empleado();
            ob.IDEmpleado = Convert.ToInt32(dr[0]);
            ob.nombreEmpleado = Convert.ToString(dr[1]);
            ob.apellidoEmpleado = Convert.ToString(dr[2]);
            e.Add(ob);
        }
        con.Close();
        return e;
    }

    public class Empleado {

        public int IDEmpleado { get; set; }
        public string nombreEmpleado { get; set; }
        public string apellidoEmpleado { get; set; }
    }

    protected string returnCadena(string comando) {
        comando = comando.Replace("á","a");
        comando = comando.Replace("Á", "A");
        comando = comando.Replace("é", "e");
        comando = comando.Replace("É", "e");
        comando = comando.Replace("í", "i");
        comando = comando.Replace("Í", "i");
        comando = comando.Replace("ó", "o");
        comando = comando.Replace("Ó", "o");
        comando = comando.Replace("ú", "u");
        comando = comando.Replace("Ú", "u");
        return comando;
    }  

 
}