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



public partial class IOT_Reportes : System.Web.UI.Page
{
    public int sitio = 0;
    DataTable dt = new DataTable();
    static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    private SqlConnection conn = new SqlConnection(conString);
    protected void Page_Load(object sender, EventArgs e)
    {
        sitio = Convert.ToInt32(Request.QueryString["sitio"]);
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
        DateTime aux = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day,0,0,1);
        fecha1 = aux;
        aux = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 23,59,59);
        fecha2 = aux;
        
        if (tipe == 2) {
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
                                                 "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and e.Sitio=@sit";
                }
                else
                {
                    query = "select e.id,e.nombre, e.apellidos, cd.fecha, cd.estatus from controlDactilar cd inner join Empleado e " +
                                                "on e.id = cd.IDEmpleado where Fecha between @fecha1 and @fecha2 and cd.IDEmpleado = @emp";
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
                query = "select e.id, e.nombre, e.apellidos, cd.fecha, cd.estatus from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado and e.Sitio=@sit";
            }
            else
            {
                query = "select e.id, e.nombre, e.apellidos, cd.fecha, cd.estatus from controlDactilar cd inner join Empleado e on e.id = cd.IDEmpleado where IDEmpleado=@emp";
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
                    catch {

                    }
                    string fecha = sd.ToString("dd/MM/yyyy"), hora = sd.ToString("hh:mm:tt");
                    table.AddCell(fecha);
                    j++;
                    table.AddCell(hora);
                    j++;
                }
                else {
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
        cmd.CommandText = "SELECT icono FROM Clientes Where ID=(select ID_Cliente from AspNetUsers where username = @usuario)";
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
        foreach (TableCell cell in GridView1.HeaderRow.Cells)
        {
            if (p == 4)
            {
                dt2.Columns.Add("Hora");
            }
            else if (p < 4)
            {
                dt2.Columns.Add(cell.Text);
            }
            p++;
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt2.Rows.Add();
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
                    string fecha= sd.ToString("dd/MM/yyyy"), hora = sd.ToString("hh:mm:tt");
                    dt2.Rows[dt2.Rows.Count - 1][j] = fecha;
                    j++;
                    dt2.Rows[dt2.Rows.Count - 1][j] = hora;
                    //i++;
                }
                else
                {
                    dt2.Rows[dt2.Rows.Count - 1][j] = dt.Rows[i][j];
                }
            }
        }
        using (var wb = new XLWorkbook())
        {
            var vv = wb.Worksheets.Add("Reporte de Asistencia");
            vv.Range("A1:B1").Row(1).Merge();
            vv.Cell("A1").Style.Font.FontSize = 35;
            vv.Cells("c1:I1").Style.Font.FontSize = 20;
            vv.Cells("c1:I1").Style.Fill.BackgroundColor = XLColor.PowderBlue;
            vv.Cell("D1").Value = "Reporte de Asistencia";
            vv.Cell("D1").Style.Font.Bold = true;
            vv.Cell("D1").Style.Font.FontColor = XLColor.BluePigment;
            vv.Range("D1:H1").Row(1).Merge();
            vv.Cell("D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            vv.Cells("D6:J6").Style.Font.FontSize = 15;
            vv.Cell("G3").Value = "Reporte Generado por: " + User.Identity.Name;
            vv.Cell("G3").Style.Font.FontColor = XLColor.BluePigment;
            vv.Cell("G3").Style.Font.Bold = true;
            vv.Cell("G3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            vv.Cell("G3").Style.Font.FontSize = 13;
            vv.Cell("G4").Value = "Fecha creación: " + DateTime.Now.ToString("dd/MM/yyyy");
            vv.Cell("G4").Style.Font.FontColor = XLColor.BluePigment;
            vv.Cell("G4").Style.Font.Bold = true;
            vv.Cell("G4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            vv.Cell("G4").Style.Font.FontSize = 13;
            vv.Range("G4:H3").Row(1).Merge();
            vv.Cell("G5").Value = "Sitio: " + returnSitioDesc(sitio);
            vv.Cell("G5").Style.Font.Bold = true;
            vv.Cell("G5").Style.Font.FontColor = XLColor.BluePigment;
            vv.Cell("G5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            vv.Cell("G5").Style.Font.FontSize = 13;
            vv.Range("G5:H4").Row(1).Merge();
            byte[] imagen = ConsultarIcono();
            MemoryStream buf = new MemoryStream(imagen);
            Bitmap im = new Bitmap(buf);
            vv.Worksheet.AddPicture(im);
            vv.Cell(7, 4).InsertTable(dt2);
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



    protected void tipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int tipe = tipo.SelectedIndex;
        if(tipe == 1 || tipe == 0)  
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

    protected string returnSitioDesc(int sitio){
    	string site = string.Empty;
    	conn.Open();
    	SqlCommand cmd = new SqlCommand("select Descripcion from Sitios where ID = @sitio", conn);
    	cmd.Parameters.AddWithValue("@sitio",sitio);
    	SqlDataReader dr = cmd.ExecuteReader();
    	if(dr.Read())
    		site = Convert.ToString(dr[0]);
    	conn.Close();
    	return site;
    }
}