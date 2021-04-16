using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
public partial class IOT_grafica : System.Web.UI.Page
{
    //static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    //private SqlConnection conn = new SqlConnection(conString);

   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dat();
        }

        //datos();
    }

    protected void dat()
    {
        int[] barras = { 24, 10, 70 };
        string[] nombres = { "brenda", "gerardo", "prueba" };

       
     

        for (int i = 0; i < nombres.Length; i++)

        {
            Series serie = Graficas.Series.Add(nombres[i]);
            serie.Label = barras[i].ToString();

            
            serie.Points.Add(barras[i]);


        }

    }
    }      