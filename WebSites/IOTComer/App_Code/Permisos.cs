using System;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de Permisos
/// </summary>
public class Permisos
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);
    public string returnPermiso(string usuario, int permiso)
    {
        string res = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select p.Modulo from Permisos p inner join PermisoRol pr on p.ID=pr.ID_Permiso and " +
            "pr.ID_Rol=(select ID_Rol from AspNetUsers where UserName=@user) and pr.ID_Permiso=@permiso", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        cmd.Parameters.AddWithValue("@permiso", permiso);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            res = Convert.ToString(dr[0]);
        }
        con.Close();

        return res;
    }

    public bool userHabilitado(string usuario) {
        bool habilitado = false;
        string res = string.Empty;
        con.Open();
        SqlCommand cmd = new SqlCommand("select Habilitado from AspNetUsers where UserName = @user", con);
        cmd.Parameters.AddWithValue("@user", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            res = Convert.ToString(dr[0]);
            if (res == "Habilitado" || res=="")
                habilitado = true;
        }
        con.Close();

        return habilitado;
    }

    public bool isCheckedAviso(string usuario) {
        con.Open();
        SqlCommand cmd = new SqlCommand("select AvisoPrivacidad from AspNetUsers where UserName = @usuario", con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        if (Convert.ToString(dr[0]) == "Aceptado")
            return true;
        else
            return false;

    }

    public bool isMultipleNOIP(int sitio) {
        bool multiple = false;
        con.Open();
        SqlCommand cmd = new SqlCommand("select MultipleNOIP from Sitios where ID = @id",con);
        cmd.Parameters.AddWithValue("@id",sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            if (Convert.ToInt32(dr[0]) == 1)
                multiple = true;
        }
        con.Close();
        return multiple;
    }
}