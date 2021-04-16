using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de UsuarioExterno
/// </summary>
public class UsuarioExterno
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);

    public string Login(string usuario, string contraseña) {
        string result = string.Empty, contraseña2 = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select contraseña from UsuarioRestaurant where Usuario = @usuario " +
            "and (Habilitado is NULL or Habilitado = 'Habilitado')",con);
        cmd.Parameters.AddWithValue("@usuario",usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            contraseña2 = Convert.ToString(dr[0]);
            contraseña2 = Encrypt.Desencriptar(contraseña2);
        }
        if (contraseña2 == contraseña)
            result = "True";
        else
            result = "False";
        return result;
    }
}