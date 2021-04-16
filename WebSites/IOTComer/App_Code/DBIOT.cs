using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de DBIOT
/// </summary>
public class DBIOT
{
    string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public DataSet Consultar(SqlCommand consulta)
    {
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        consulta.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter(consulta);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }
    public void insert(SqlCommand consulta) {
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        consulta.Connection = con;
        consulta.ExecuteNonQuery();
        con.Close();
    }

    public string consultaUnDato(SqlCommand consulta) {
        string resultado = string.Empty;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        consulta.Connection = con;
        SqlDataReader dr = consulta.ExecuteReader();
        if (dr.Read())
            resultado = Convert.ToString(dr[0]);
        con.Close();
        return resultado;
    }
}