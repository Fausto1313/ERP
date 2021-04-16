using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.Globalization;
using System.Collections;
public partial class IOT_ReporteExcelRisc : System.Web.UI.Page
{
    public int sitio = 0;
    DataTable dt = new DataTable();
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        //sitio = Convert.ToInt32(Request.QueryString["sitio"]);
        sitio = 7;
        string usuario = User.Identity.Name;
        if (!IsPostBack)
        {
            CargaEmpleado(sitio);
            Tipo_Historial();
        }

        bindgrid(sitio);

    }
    protected void bindgrid(int sitio)
    {
        int tipe = tipo.SelectedIndex;
        DateTime holi = Calendario.SelectedDate;
        int i = holi.Year;
        string query = null;
        int emp = Convert.ToInt32(Empleado.SelectedValue);
        DateTime fecha1 = Calendario.SelectedDate;
        DateTime fecha2 = Calendario2.SelectedDate;
        DateTime aux = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 1);
        fecha1 = aux;
        aux = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 23, 59, 59);
        fecha2 = aux;

        if (tipe == 2)
        {
            lblFecha1.Visible = true;
            Fecha1.Visible = true;
            Calendar.Visible = true;
            lblFecha2.Visible = true;
            Fecha2.Visible = true;
            Calendar2.Visible = true;
            if (fecha1.Year > 1900 && fecha1.Year < 2100 && fecha2.Year > 1900 && fecha2.Year < 2100)
            {
                conn.Open();
                if (emp == -1)
                {
                    query = "select e.id,e.nombre, e.apellidos, cd.fecha, cd.estatus from controlDactilar cd inner join Empleado e " +
                                                 "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and e.Sitio=@sit order by cd.ID desc";
                }
                else
                {
                    query = "select e.id,e.nombre, e.apellidos, cd.fecha, cd.estatus from controlDactilar cd inner join Empleado e " +
                                                "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and cd.IDEmpleado = @emp order by cd.ID desc";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emp", emp);
                cmd.Parameters.AddWithValue("@sit", sitio);
                cmd.Parameters.AddWithValue("@fecha1", fecha1);
                cmd.Parameters.AddWithValue("@fecha2", fecha2);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                dt = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    int columncount = GridView1.Rows[0].Cells.Count;
                    GridView1.Rows[0].Cells.Clear();
                    GridView1.Rows[0].Cells.Add(new TableCell());
                    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                    GridView1.Rows[0].Cells[0].Text = "No se encontraron Registros";
                }
            }

        }
        else if (tipe == 1)
        {
            lblFecha1.Visible = false;
            Fecha1.Visible = false;
            Calendar.Visible = false;
            lblFecha2.Visible = false;
            Fecha2.Visible = false;
            Calendar2.Visible = false;
            conn.Open();
            if (emp == -1)
            {
                query = "select e.id, e.nombre, e.apellidos, cd.fecha, cd.estatus from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado and e.Sitio=@sit order by cd.ID desc";
            }
            else
            {
                query = "select e.id, e.nombre, e.apellidos, cd.fecha, cd.estatus from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado where IDEmpleado=@emp order by cd.ID desc";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@sit", sitio);
            cmd.Parameters.AddWithValue("@emp", emp);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            dt = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No se encontraron Registros";
            }
        }

    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.bindgrid(sitio);
    }
    protected void Tipo_Historial()
    {

        tipo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccionar]", "0"));
        tipo.Items.Insert(1, new System.Web.UI.WebControls.ListItem("Completo", "1"));
        tipo.Items.Insert(2, new System.Web.UI.WebControls.ListItem("Por fechas", "2"));

    }
    protected void CargaEmpleado(int sitio)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("select id, nombre from Empleado where Sitio=@sit", conn);
        cmd.Parameters.AddWithValue("@sit", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        Empleado.DataSource = dr;
        Empleado.DataTextField = "Nombre";
        Empleado.DataValueField = "id";
        Empleado.DataBind();
        Empleado.Items.Insert(0, new System.Web.UI.WebControls.ListItem("[Seleccionar]", "0"));
        Empleado.Items.Insert(1, new System.Web.UI.WebControls.ListItem("Todos los empleados", "-1"));
        conn.Close();
    }
    protected void Carga_select(object sender, EventArgs e)
    {
        CargaEmpleado(sitio);
    }

    protected DataSet Consultar(string consulta)
    {
        string usuario = Context.User.Identity.Name;
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmd = new SqlCommand(consulta, con);
        cmd.Parameters.AddWithValue("@usuario", usuario);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
        return ds;
    }

    protected void Calendar_Click(object sender, ImageClickEventArgs e)
    {

        Calendario.Visible = true;

    }
    protected void Calendar_Click2(object sender, ImageClickEventArgs e)
    {
        Calendario2.Visible = true;

    }
    protected void Calendario_SelectionChanged(object sender, EventArgs e)
    {
        Fecha1.Text = Calendario.SelectedDate.ToShortDateString();
        Calendario.Visible = false;
        bindgrid(sitio);

    }
    protected void Calendario_SelectionChanged2(object sender, EventArgs e)
    {
        Fecha2.Text = Calendario2.SelectedDate.ToShortDateString();
        Calendario2.Visible = false;
        bindgrid(sitio);
    }


    /**++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++**/
    protected void generaPDF_Click(object sender, EventArgs e)
    {
        ExportGridToPDF();
    }

    private void ExportGridToPDF()
    {
        string nombre = "Reporte-" + DateTime.Now.ToString("dd/MM/yyyy");
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + nombre + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //GridView1.RenderControl(hw);

        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A3, 20f, 20f, 35f, 0f);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

        //TABLA//
        iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A3);
        rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);
        //Document doc = new Document(rec);
        pdfDoc.SetPageSize(PageSize.A3);
        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();

        //LOGO DEL PDF//
        iTextSharp.text.Font times = FontFactory.GetFont(FontFactory.TIMES_BOLD, 20, BaseColor.BLUE);
        var logo = iTextSharp.text.Image.GetInstance(ConsultarIcono());
        logo.SetAbsolutePosition(40, 1090);
        logo.ScaleAbsoluteHeight(50);
        logo.ScaleAbsoluteWidth(50);

        pdfDoc.Add(logo);
        //TITULO PRINCIPAL//
        Paragraph twainBibText = new Paragraph("Reporte de Asistencia", times);
        twainBibText.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(twainBibText);

        //Adding paragraph for report generated by
        Paragraph prgGeneratedBY = new Paragraph();
        BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 3, iTextSharp.text.BaseColor.DARK_GRAY);
        prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
        string usuario = User.Identity.Name;
        prgGeneratedBY.Add(new Chunk("Reporte Generado por: " + usuario, fntAuthor));
        prgGeneratedBY.Add(new Chunk("\nFecha creación : " + DateTime.Now.ToString("dd/MM/yyyy"), fntAuthor));
        prgGeneratedBY.Add(new Chunk("\nSitio : " + returnSitioDesc(sitio), fntAuthor));
        pdfDoc.Add(prgGeneratedBY);
        //LINEA//
        Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
        pdfDoc.Add(p);

        //Adding line break
        pdfDoc.Add(new Chunk("\n"));
        //Adding  PdfPTable
        int p2 = 0;
        PdfPTable table = new PdfPTable(dt.Columns.Count);
        foreach (TableCell cell2 in GridView1.HeaderRow.Cells)
        {
            string cellText = null;
            if (p2 == 4)
            {
                cellText = "Hora";
            }
            else
            {
                cellText = cell2.Text;
            }
            //cellText = cell2.Text;
            PdfPCell cell = new PdfPCell();
            cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 13, 1, new BaseColor(ColorTranslator.FromHtml("#ffffff"))));
            cell.BackgroundColor = new BaseColor(ColorTranslator.FromHtml("#0c4566"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.PaddingBottom = 5;
            table.AddCell(cell);
            p2++;
        }


        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                if (j == 3)
                {
                    DateTime sd = DateTime.Today;
                    try
                    {
                        sd = Convert.ToDateTime(dt.Rows[i][j]);

                    }
                    catch
                    {

                    }
                    string fecha = sd.ToString("dd/MM/yyyy"), hora = sd.ToString("hh:mm:tt");
                    table.AddCell(fecha);
                    j++;
                    table.AddCell(hora);
                    j++;
                }
                else
                {
                    table.AddCell(dt.Rows[i][j].ToString());
                }
            }
        }

        pdfDoc.Add(table);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        GridView1.AllowPaging = true;
        GridView1.DataBind();
    }
    protected byte[] ConsultarIcono()
    {

        string usuario = Context.User.Identity.GetUserName();
        string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT  icono FROM Clientes Where ID=(select ID_Cliente from AspNetUsers where username = @usuario)";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Connection = con;
        con.Open();
        //objCmd.CommandType = CommandType.Text;
        object result = cmd.ExecuteScalar();
        con.Close();
        return (byte[])result;
    }
    /***********************************CREA EXCEL***********************************************************************************************************/
    protected void generaExcel_Click(object sender, EventArgs e)
    {
        DataTable dt2 = new DataTable("Reporte de asistencia");
        int p = 0;

        DateTime holi = Calendario.SelectedDate;
        int a = holi.Year;
        int emp = Convert.ToInt32(Empleado.SelectedValue);
        DateTime fecha1 = Calendario.SelectedDate;
        DateTime fecha2 = Calendario2.SelectedDate;
        DateTime aux = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 1);
        fecha1 = aux;
        aux = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 23, 59, 59);
        fecha2 = aux;
        string fecha_inicial_dia = fecha1.ToString("dd");
        string fecha_inicial_mes = fecha1.ToString("MM");
        int numeromes = Int32.Parse(fecha_inicial_mes);
        String nombreMes = obtenerNombreMes(numeromes);
        string fecha_inicial_a = fecha1.ToString("yyyy");

        string fecha_final_dia = fecha2.ToString("dd");
        string fecha_final_mes = fecha2.ToString("MM");
        String nombreMesfinal = obtenerNombreMes(Int32.Parse(fecha_final_mes));
        string fecha_final_a = fecha2.ToString("yyyy");

        using (var wb = new XLWorkbook())
        {
            var vv = wb.Worksheets.Add("Reporte de Asistencia ");
            vv.Cell("A2").Value = "SISTEMAS DE INVESTIGACION Y ADMINISTRACION SA DE CV ";
            vv.Cell("A2").Style.Font.Bold = true;
            vv.Cell("A2").Style.Font.FontColor = XLColor.Black;
            vv.Cells("A2:H2").Style.Font.FontSize = 14;
            vv.Range("A2:H2").Row(1).Merge();
            vv.Cell("A2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            vv.Cell("A3").Value = "LISTA DE ASISTENCIA DEL PERSONAL ASIGNADO AL CLIENTE REINTEGRACION EN SERVICIOS DE COMPUTO SA DE CV";
            vv.Cell("A3").Style.Font.Bold = true;
            vv.Cell("A3").Style.Font.FontColor = XLColor.Black;
            vv.Cells("A3:H3").Style.Font.FontSize = 12;
            vv.Range("A3:H3").Row(1).Merge();
            vv.Cell("A3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            vv.Cell("A4").Value = "PERIODO: ";
            vv.Cell("A4").Style.Font.Bold = true;
            vv.Cell("A4").Style.Font.FontColor = XLColor.Black;
            vv.Cell("A4").Style.Font.FontSize = 11;

            if (!(nombreMes.Equals(nombreMesfinal)) && fecha_inicial_a != fecha_final_a)
                vv.Cell("B4").Value = "DEL " + fecha_inicial_dia + " DE " + nombreMes.ToUpper() + " AL " + fecha_final_dia + " DE "
                + nombreMesfinal.ToUpper() + " DEL " + fecha_inicial_a+"-"+fecha_final_a + " EN " + returnSitioDesc(sitio).ToUpper();
            else if (nombreMes.Equals(nombreMesfinal))
                vv.Cell("B4").Value = "DEL "+fecha_inicial_dia +" AL "+ fecha_final_dia + " DE "
                +nombreMes.ToUpper()  + " DEL " + fecha_inicial_a+ " EN "+ returnSitioDesc(sitio).ToUpper();
            else
                vv.Cell("B4").Value = "DEL " + fecha_inicial_dia +" DE "+ nombreMes.ToUpper() +" AL " + fecha_final_dia + " DE "
                + nombreMesfinal.ToUpper() + " DEL " + fecha_inicial_a + " EN " + returnSitioDesc(sitio).ToUpper();

            vv.Range("B4:H4").Merge();
            vv.Cell("B4").Style.Font.Bold = true;
            vv.Cell("B4").Style.Font.FontColor = XLColor.Black;
            vv.Cell("B4").Style.Font.FontSize = 11;
            vv.Cell("B4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            vv.Range("I1:J5").Merge();
            var imagePath = @"~/recursos/SIA_sin.png";
            var image = vv.AddPicture(Server.MapPath(imagePath))
                .MoveTo(vv.Cell("I1"));
            vv.Cell("I1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            vv.Range("A7:C7").Merge();
            vv.Cells("A7:C7").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            vv.Cells("A7:C7").Style.Border.OutsideBorderColor = XLColor.Black;
            vv.Range("D7:R7").Merge();
            vv.Cell("D7").Value ="DIAS";
            vv.Cell("D7").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            vv.Cells("D7:R7").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            vv.Cells("D7:R7").Style.Border.OutsideBorderColor = XLColor.Black;
            vv.Cell("A8").Value = "ID Nomina";
            vv.Cell("A8").Style.Font.Bold = true;
            vv.Cell("A8").Style.Border.OutsideBorderColor = XLColor.Black;
            vv.Cell("A8").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            vv.Cell("B8").Value = "ID Empleado";
            vv.Cell("B8").Style.Font.Bold = true;
            vv.Cell("B8").Style.Border.OutsideBorderColor = XLColor.Black;
            vv.Cell("B8").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            vv.Cell("C8").Value = "Empleado";
            vv.Cell("C8").Style.Font.Bold = true;
            vv.Cell("C8").Style.Border.OutsideBorderColor = XLColor.Black;
            vv.Cell("C8").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

            ArrayList list_idnomina = new ArrayList();
            list_idnomina = obtenerIDNomina(fecha1, fecha2, sitio);
            for (int idnom = 0; idnom < list_idnomina.Count; idnom++)
            {
                vv.Cell(idnom + 9, 1).Value = list_idnomina[idnom];
            }

            ArrayList list_idempleado = new ArrayList();
            list_idempleado = obtenerIDEmpleado(fecha1, fecha2, sitio);
            for (int idempl = 0; idempl < list_idempleado.Count; idempl++)
            {
                vv.Cell(idempl + 9, 2).Value = list_idempleado[idempl];
            }

            ArrayList listEmpleados2 = new ArrayList();
            listEmpleados2 = ObtenerEmpleados2(fecha1, fecha2, sitio);
            for (int le = 0; le < listEmpleados2.Count; le++)
            {
                vv.Cell(le + 9, 3).Value = listEmpleados2[le];
            }

            List<string> listaHoras = new List<string>();
            listaHoras = ObtenerListAsistencia(fecha1, fecha2, sitio);

            int numEmpleados = listEmpleados2.Count;

            List<List<string>> registros_horas = new List<List<string>>();

            registros_horas = dividirLista(listaHoras,numEmpleados);

            int count = 0;

            foreach (List<string> lista in registros_horas)
                {
                    for (int i = 0; i < registros_horas.Capacity; i++) { 
                    vv.Cell(9, 4 + count).Value = lista;
                }
                count++;
            }

            vv.Column(1).Width = 10;
            vv.Column(2).Width = 12;
            vv.Column(3).Width = 35;
            vv.Column(19).Width = 15;

            ArrayList listFechas = new ArrayList();
            listFechas = ObtenerConsecutivofecha(fecha1, fecha2, sitio);

            for (int i = 0; i < listFechas.Count; i++)
            {
                vv.Cell(8, i+4).Value = listFechas[i];
                vv.Column(i + 4).Width = 12;

            }

            int numFechas = listFechas.Count;
            int casilla_total_faltas = (numFechas )+4;
            vv.Cell(8 , casilla_total_faltas).Value = "TOTAL FALTAS ";
            vv.Cell(8 , casilla_total_faltas).Style.Font.Bold = true;
            vv.Cell(8 , casilla_total_faltas).Style.Border.OutsideBorderColor = XLColor.Black;
            vv.Cell(8 , casilla_total_faltas).Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            string ult_letra = ExcelColumnFromNumber((listFechas.Count+3));
            for (int i = 0; i < listEmpleados2.Count; i++)
            {
                vv.Cell(i + 9, casilla_total_faltas).SetFormulaA1("=COUNTIF(D" + (i+9) +":"+ ult_letra+(i + 9) + ",\"Falta\")");
            }
            int col_de_emp = numEmpleados + 11;
            int col_final_cuadro = col_de_emp + 7;
            string fil_ini_Cuadro = "C";
            string fil_fin_Cuadro = "D";


            vv.Range("" + fil_ini_Cuadro + (col_de_emp - 1) + ":" + fil_fin_Cuadro + (col_de_emp - 1) + "").Merge().Rows();
            vv.Cell("" + fil_ini_Cuadro + (col_de_emp - 1) + "").Value = "Vo. Bo.";
            vv.Cell("" + fil_ini_Cuadro + (col_de_emp - 1) + "").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


            vv.Cells("" + fil_ini_Cuadro + col_de_emp + ":" + fil_fin_Cuadro + col_final_cuadro + "").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            vv.Cells("" + fil_ini_Cuadro + col_de_emp + ":" + fil_fin_Cuadro + col_final_cuadro + "").Style.Border.SetBottomBorder(XLBorderStyleValues.Medium);

            vv.Range("" + fil_ini_Cuadro + (col_final_cuadro + 1) + ":" + fil_fin_Cuadro + (col_final_cuadro + 1) + "").Merge().Rows();
            vv.Cell("" + fil_ini_Cuadro + (col_final_cuadro + 1) + "").Value = "RECURSOS HUMANOS";
            vv.Cell("" + fil_ini_Cuadro + (col_final_cuadro + 1) + "").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


            vv.Range("" + fil_ini_Cuadro + (col_final_cuadro + 2) + ":" + fil_fin_Cuadro + (col_final_cuadro + 2) + "").Merge().Rows();
            vv.Cell("" + fil_ini_Cuadro + (col_final_cuadro + 2) + "").Value = returnSitioDesc(sitio).ToUpper();
            vv.Cell("" + fil_ini_Cuadro + (col_final_cuadro + 2) + "").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


            vv.Range(""+ fil_ini_Cuadro +col_de_emp+ ":"+fil_fin_Cuadro+col_final_cuadro+"").Merge().Rows();
            //vv.Cells("" + fil_ini_Cuadro + col_de_emp + ":" + fil_fin_Cuadro + col_final_cuadro + "").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            //vv.Cells("" + fil_ini_Cuadro + col_de_emp + ":" + fil_fin_Cuadro + col_final_cuadro + "").Style.Border.OutsideBorderColor = XLColor.Black;

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string filename = "Reporte-" + DateTime.Now.ToString("dd/MM/yyyy");
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }
    }

    public static List<List<string>> dividirLista(List<string> source, int maxSubItems)
    {
        return source
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / maxSubItems)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }

    public static string ExcelColumnFromNumber(int column)
    {
        string columnString = "";
        decimal columnNumber = column;
        while (columnNumber > 0)
        {
            decimal currentLetterNumber = (columnNumber - 1) % 26;
            char currentLetter = (char)(currentLetterNumber + 65);
            columnString = currentLetter + columnString;
            columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
        }
        return columnString;
    }

    protected void tipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int tipe = tipo.SelectedIndex;
        if (tipe == 1 || tipe == 0)
        {
            Calendario.Visible = false;
            Calendar.Visible = false;
            lblFecha1.Visible = false;
            Fecha1.Visible = false;
            Calendario2.Visible = false;
            Calendar2.Visible = false;
            lblFecha2.Visible = false;
            Fecha2.Visible = false;
        }
    }

    protected string returnSitioDesc(int sitio)
    {
        string site = string.Empty;
        conn.Open();
        SqlCommand cmd = new SqlCommand("select Descripcion from Sitios where ID = @sitio", conn);
        cmd.Parameters.AddWithValue("@sitio", sitio);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
            site = Convert.ToString(dr[0]);
        conn.Close();
        return site;
    }

    private string obtenerNombreMes(int numeroMes)
    {
        try
        {
            DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
            //CultureInfo ci = new CultureInfo("es-MX");
            //string nombreMes = formatoFecha.GetMonthName(numeroMes).ToString(ci);
            string nombreMes = formatoFecha.GetMonthName(numeroMes);
            return nombreMes;
        }
        catch
        {
            return "Desconocido";
        }
    }

    private ArrayList ObtenerEmpleados(DateTime fecha1, DateTime fecha2, int sitio)
    {
        int tipe = tipo.SelectedIndex;
        string query = null;
        int emp = Convert.ToInt32(Empleado.SelectedValue);
        ArrayList objEmpleados = new ArrayList();
        ArrayList nombre_completo = new ArrayList();
        
        if (tipe == 2)
        {
            conn.Open();
                if (emp == -1)
                {
                    query = "select distinct e.apellidos from controlDactilar cd inner join Empleado e " +
                                                 "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and e.Sitio=@sit ";
                }
                else
                {
                    query = "select distinct e.apellidos from controlDactilar cd inner join Empleado e " +
                                                "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and cd.IDEmpleado = @emp ";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@emp", emp);
                cmd.Parameters.AddWithValue("@sit", sitio);
                cmd.Parameters.AddWithValue("@fecha1", fecha1);
                cmd.Parameters.AddWithValue("@fecha2", fecha2);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nombre_completo.Add(reader[0].ToString());

            }

            conn.Close();
        }
        else if (tipe == 1)
        {
            conn.Open();
            if (emp == -1)
            {
                query = "select  distinct  e.apellidos from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado and e.Sitio=@sit ";
            }
            else
            {
                query = "select distinct e.apellidos from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado where IDEmpleado=@emp ";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@sit", sitio);
            cmd.Parameters.AddWithValue("@emp", emp);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nombre_completo.Add(reader[0].ToString());

            }
            conn.Close();
        }
        return nombre_completo;
    }



    /*
     * Metodo ObtenerEmpleados2 para Matriz funciona para traer el Nombre Completo de Empleados(Apellidos y Nombre) 
     * 
     */
    private ArrayList ObtenerEmpleados2(DateTime fecha1, DateTime fecha2, int sitio)
    {
        int tipe = tipo.SelectedIndex;
        string query = null;
        int emp = Convert.ToInt32(Empleado.SelectedValue);
        ArrayList objEmpleados = new ArrayList();
        ArrayList nombre_completo = new ArrayList();

        if (tipe == 2)
        {
            conn.Open();
            if (emp == -1)
            {
                query = "select distinct e.apellidos, e.nombre from controlDactilar cd inner join Empleado e " +
                                             "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and e.Sitio=@sit ";
            }
            else
            {
                query = "select distinct e.apellidos, e.nombre from controlDactilar cd inner join Empleado e " +
                                            "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and cd.IDEmpleado = @emp ";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@emp", emp);
            cmd.Parameters.AddWithValue("@sit", sitio);
            cmd.Parameters.AddWithValue("@fecha1", fecha1);
            cmd.Parameters.AddWithValue("@fecha2", fecha2);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string nomCompleto = reader[0].ToString() + " " + reader[1].ToString();

                nombre_completo.Add(nomCompleto);

            }

            conn.Close();
        }
        else if (tipe == 1)
        {
            conn.Open();
            if (emp == -1)
            {
                query = "select  distinct e.apellidos, e.nombre from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado and e.Sitio=@sit ";
            }
            else
            {
                query = "select distinct e.apellidos, e.nombre from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado where IDEmpleado=@emp ";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@sit", sitio);
            cmd.Parameters.AddWithValue("@emp", emp);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                objEmpleados.Add(reader[0].ToString());
                objEmpleados.Add(reader[1].ToString());

                string nomCompleto = reader[0].ToString() + " " + reader[1].ToString();

                nombre_completo.Add(nomCompleto);

            }
            conn.Close();
        }
        return nombre_completo;
    }

    /*
     * Metodo obtenerIDNomina para Matriz funciona para traer el IDNomina del Empleado 
     * 
     */
    private ArrayList obtenerIDNomina(DateTime fecha1, DateTime fecha2, int sitio)
    {
        int tipe = tipo.SelectedIndex;
        string query = null;
        int emp = Convert.ToInt32(Empleado.SelectedValue);
        ArrayList objEmpleados = new ArrayList();
        ArrayList nombre_completo = new ArrayList();

        if (tipe == 2)
        {
            conn.Open();
            if (emp == -1)
            {
                query = "select distinct e.apellidos, e.nombre, id_nomina from controlDactilar cd inner join Empleado e " +
                                             "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and e.Sitio=@sit ";
            }
            else
            {
                query = "select distinct e.apellidos, e.nombre, id_nomina from controlDactilar cd inner join Empleado e " +
                                            "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and cd.IDEmpleado = @emp ";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@emp", emp);
            cmd.Parameters.AddWithValue("@sit", sitio);
            cmd.Parameters.AddWithValue("@fecha1", fecha1);
            cmd.Parameters.AddWithValue("@fecha2", fecha2);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                
                nombre_completo.Add(reader[2].ToString());

            }

            conn.Close();
        }
        else if (tipe == 1)
        {
            conn.Open();
            if (emp == -1)
            {
                query = "select  distinct e.apellidos, e.nombre, id_nomina from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado and e.Sitio=@sit ";
            }
            else
            {
                query = "select distinct e.apellidos, e.nombre, id_nomina from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado where IDEmpleado=@emp ";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@sit", sitio);
            cmd.Parameters.AddWithValue("@emp", emp);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nombre_completo.Add(reader[2].ToString());

            }
            conn.Close();
        }
        return nombre_completo;
    }

    /*
     * Metodo ObtenerEmpleados2 para Matriz funciona para traer el Nombre Completo de Empleados(Apellidos y Nombre) 
     * 
     */
    private ArrayList obtenerIDEmpleado(DateTime fecha1, DateTime fecha2, int sitio)
    {
        int tipe = tipo.SelectedIndex;
        string query = null;
        int emp = Convert.ToInt32(Empleado.SelectedValue);
        ArrayList objEmpleados = new ArrayList();
        ArrayList nombre_completo = new ArrayList();

        if (tipe == 2)
        {
            conn.Open();
            if (emp == -1)
            {
                query = "select distinct e.apellidos, e.nombre, id_empleado from controlDactilar cd inner join Empleado e " +
                                             "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and e.Sitio=@sit ";
            }
            else
            {
                query = "select distinct e.apellidos, e.nombre, id_empleado from controlDactilar cd inner join Empleado e " +
                                            "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and cd.IDEmpleado = @emp ";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@emp", emp);
            cmd.Parameters.AddWithValue("@sit", sitio);
            cmd.Parameters.AddWithValue("@fecha1", fecha1);
            cmd.Parameters.AddWithValue("@fecha2", fecha2);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nombre_completo.Add(reader[2].ToString());
            }

            conn.Close();
        }
        else if (tipe == 1)
        {
            conn.Open();
            if (emp == -1)
            {
                query = "select  distinct e.apellidos, e.nombre, id_empleado from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado and e.Sitio=@sit ";
            }
            else
            {
                query = "select distinct e.apellidos, e.nombre, id_empleado from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado where IDEmpleado=@emp ";
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@sit", sitio);
            cmd.Parameters.AddWithValue("@emp", emp);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                nombre_completo.Add(reader[2].ToString());
            }
            conn.Close();
        }
        return nombre_completo;
    }


    private ArrayList ObtenerConsecutivofecha(DateTime fecha1, DateTime fecha2, int sitio)
    {
        ArrayList fechas = new ArrayList();
        string fecha = null;
        string query = null;

        SqlCommand cmd = null;
        SqlDataReader reader = null;


        query = "SELECT distinct (CONVERT(VARCHAR(10), cd.Fecha, 120)) " +
                " FROM  controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado" +
                " WHERE Fecha between @fecha1 and @fecha2 and e.Sitio=@sit ";

        conn.Open();

        cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@sit", sitio);
        cmd.Parameters.AddWithValue("@fecha1", fecha1);
        cmd.Parameters.AddWithValue("@fecha2", fecha2);

        reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            fechas.Add(reader[0]);

        }
        conn.Close();

        return fechas;
    }

    private List<string> ObtenerListAsistencia(DateTime fecha1, DateTime fecha2, int sitio)
    {
        int tipe = tipo.SelectedIndex;
        string query = null;
        int emp = Convert.ToInt32(Empleado.SelectedValue);
        ArrayList empleados = new ArrayList();
        List<string> nombre_completo = new List<string>();
        ArrayList listfechas = new ArrayList();
        

        SqlCommand cmd = null;
        SqlDataReader reader = null;
        string hora = null;
        listfechas = ObtenerConsecutivofecha(fecha1, fecha2, sitio);
        empleados = ObtenerEmpleados(fecha1, fecha2, sitio);
        string anterior = null;
        if (tipe == 2)
        {
            //foreach (string fecha in listfechas)
            for (int i = 0; i < listfechas.Count; i++)
            {
                //         if (anterior != null) 

                if (!(listfechas[i].Equals(anterior)))
                    
                    foreach (string empleado in empleados)
                    {
                        if (emp == -1)
                        {

                            query = "select top(1) cd.fecha, e.nombre, e.apellidos from controlDactilar cd inner join Empleado e " +
                                    " on e.id = cd.IDEmpleado where CONVERT(VARCHAR(10), cd.Fecha, 120) = @fecha " +
                                    " and e.Sitio=@sit and e.apellidos = @empleado ";

                        }
                        else
                        {
                            query = "select top(1) cd.fecha, e.nombre, e.apellidos from controlDactilar cd inner join Empleado e " +
                                   " on e.id = cd.IDEmpleado where CONVERT(VARCHAR(10), cd.Fecha, 120) = @fecha " +
                                   " and cd.IDEmpleado = @emp";

                           // query = "select distinct e.nombre, e.apellidos from controlDactilar cd inner join Empleado e " +
                           //                             "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and cd.IDEmpleado = @emp ";
                        }
                        conn.Open();

                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@emp", emp);
                        cmd.Parameters.AddWithValue("@fecha", listfechas[i]);
                        cmd.Parameters.AddWithValue("@sit", sitio);
                        cmd.Parameters.AddWithValue("@empleado", empleado);

                        reader = cmd.ExecuteReader();

                        if (reader.HasRows == false)
                        {
                            DateTime fecha = Convert.ToDateTime(listfechas[i]);
                            if (fecha.DayOfWeek == DayOfWeek.Saturday  || fecha.DayOfWeek == DayOfWeek.Sunday)
                            {
                                nombre_completo.Add("");

                            }
                            else
                            {
                                hora = "Falta";
                                nombre_completo.Add(hora);
                            }
                        }
                        else
                        {
                            while (reader.Read())
                            {

                                DateTime fecha_completa = (DateTime)reader[0];
                                hora = fecha_completa.ToString("hh:mm:tt");
                                nombre_completo.Add(hora);

                            }
                        }
                        conn.Close();
                    }
                anterior = listfechas[i].ToString();
                
            }

        }
        else if (tipe == 1)
        {
            //foreach (string fecha in listfechas)
            for (int i = 0; i < listfechas.Count; i++)
            {
                //         if (anterior != null) 

                if (!(listfechas[i].Equals(anterior)))

                    foreach (string empleado in empleados)
                    {
                        if (emp == -1)
                        {

                            query = "select top(1) cd.fecha, e.nombre, e.apellidos from controlDactilar cd inner join Empleado e " +
                                    " on e.id = cd.IDEmpleado where CONVERT(VARCHAR(10), cd.Fecha, 120) = @fecha " +
                                    " and e.Sitio=@sit and e.apellidos = @empleado ";

                        }
                        else
                        {
                            query = "select top(1) cd.fecha, e.nombre, e.apellidos from controlDactilar cd inner join Empleado e " +
                                   " on e.id = cd.IDEmpleado where CONVERT(VARCHAR(10), cd.Fecha, 120) = @fecha " +
                                   " and cd.IDEmpleado = @emp";

                            // query = "select distinct e.nombre, e.apellidos from controlDactilar cd inner join Empleado e " +
                            //                             "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and cd.IDEmpleado = @emp ";
                        }
                        conn.Open();

                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@emp", emp);
                        cmd.Parameters.AddWithValue("@fecha", listfechas[i]);
                        cmd.Parameters.AddWithValue("@sit", sitio);
                        cmd.Parameters.AddWithValue("@empleado", empleado);

                        reader = cmd.ExecuteReader();

                        if (reader.HasRows == false)
                        {
                            DateTime fecha = Convert.ToDateTime(listfechas[i]);
                            if (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
                            {
                                nombre_completo.Add("");

                            }
                            else
                            {
                                hora = "Falta";
                                nombre_completo.Add(hora);
                            }
                        }
                        else
                        {
                            while (reader.Read())
                            {

                                DateTime fecha_completa = (DateTime)reader[0];
                                hora = fecha_completa.ToString("hh:mm:tt");
                                nombre_completo.Add(hora);

                            }
                        }
                        conn.Close();
                    }
                anterior = listfechas[i].ToString();

            }
        }

        return nombre_completo;
    }

}