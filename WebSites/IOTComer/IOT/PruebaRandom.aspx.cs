using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IOT_PruebaRandom : System.Web.UI.Page
{
    protected static string conection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    public SqlConnection con = new SqlConnection(conection);
    public SqlConnection con2 = new SqlConnection(conection);

    protected void Page_Load(object sender, EventArgs e)
    {
        //Random();
        //Folio();
        //ValorAuxiliar();
    }


  
     protected string ValorAuxiliar()
     {
        con.Open();
        string valor = null;
        SqlCommand cmd = new SqlCommand("SELECT Valor FROM FolioAuxiliar", con); 
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
           valor = Convert.ToString(dr[0]);
        }
        con.Close();
        return valor;
     }

    private void Folio(string riscei)
    {
        DateTime fecha = DateTime.Now;
        string final = string.Empty, r = "0";
        string año = fecha.ToString("yy");
        string valor = ValorAuxiliar();
        int lon = valor.Length;
        string folio = null;
        for (int i = 0; i < 8 - lon; i++)
        {
            final = r + final;
            folio = año + final + valor;
        }
        saveRegister2(folio, riscei, fecha);
        updAuxiliar(valor);

    }

    protected void saveRegister2(string folio, string riscei, DateTime fecha)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "INSERT Folios (Folio,RISCEI,Fecha) VALUES (@Folio, @RISCEI, @Fecha)";
        cmd.Parameters.AddWithValue("@Folio", folio);
        cmd.Parameters.AddWithValue("@RISCEI", riscei);
        cmd.Parameters.AddWithValue("@Fecha", fecha);
        cmd.Connection = con;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    protected void updAuxiliar(string valorViejo)
    {
         
        int valorNuevo = Convert.ToInt32(valorViejo);
        string conString1 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con1 = new SqlConnection(conString1);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = "UPDATE FolioAuxiliar SET Valor=@valorNuevo";
        cmd.Parameters.AddWithValue("@valorNuevo", valorNuevo + 1);
        cmd.Connection = con1;
        con1.Open();
        cmd.ExecuteNonQuery();
        con1.Close();
        
    }


}