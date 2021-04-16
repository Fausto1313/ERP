using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de clase "VinculacionOdoo" en el código, en svc y en el archivo de configuración a la vez.
public class VinculacionOdoo : IVinculacionOdoo
{
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);

    public Garantia regresaDatosGarantia(string riscei) {
        Garantia gar = new Garantia();
        con.Open();
        SqlCommand cmd = new SqlCommand("select d.Descripcion, n1.Nombre, n2.Nombre2, n3.Nombre3, d.FechaInstalacion, " +
            "d.PeriodoGarantia from DARS d inner join UbiDis u on u.Id = d.UbiDis inner join Nivel1 n1 on " +
            "u.nivel1 = n1.ID inner join Nivel2 n2 on u.nivel2 = n2.ID inner join Nivel3 n3 on n3.ID = u.nivel3 " +
            "where d.RISCEI = @riscei",con);
        cmd.Parameters.AddWithValue("@riscei",riscei);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read()) {
            gar.nombre = Convert.ToString(dr[0]);
            gar.ubicacion = Convert.ToString(dr[1]) + " "+Convert.ToString(dr[2]) + " "+ Convert.ToString(dr[3]);
            if (Convert.ToString(dr[4]) == "")
            {
                gar.fechaInstalacion = new DateTime(2019, 1, 1, 0, 1, 0);
            }
            else {
                gar.fechaInstalacion = Convert.ToDateTime(dr[4]);
            }
            gar.periodoGarantia = Convert.ToString(dr[5]);
        }
        con.Close();
        //json = JsonConvert.SerializeObject(gar);
        return gar;
    }
}

public class Garantia { 
    public string nombre { get; set; }
    public string ubicacion { get; set; }
    public DateTime fechaInstalacion { get; set; }
    public string periodoGarantia { get; set; }
}
