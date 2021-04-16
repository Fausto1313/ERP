﻿using ClosedXML.Excel;
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
public partial class IOT_ReportesTemperatura : System.Web.UI.Page
{
    public string riscei = null;
    DataTable dt;
    protected static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con = new SqlConnection(conString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string usuario = User.Identity.Name;
        int pantalla = 35;
        Permisos permiso = new Permisos();
        if (permiso.returnPermiso(usuario, pantalla) == "Planos")
        {
            BindGrid();
        }
        else
            Response.Redirect("~/IOT/Home");
    }

    public void BindGrid()
    {
        string id = User.Identity.GetUserId();
        string usuario = User.Identity.Name;
        riscei = Request.QueryString["riscei"];
        try
        {
            riscei = riscei.Substring(1, 10);
        }
        catch
        {
            riscei = "";
        }
        if (riscei == null || riscei == "")
            riscei = "a";
        con.Open();
        SqlCommand cmd = new SqlCommand("select  id, RISCEI, Fecha, Temperatura, Humedad from Sensado where RISCEI = @riscei", con);
        cmd.Parameters.AddWithValue("@riscei", riscei);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        con.Close();
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

    protected void generaPDF_Click(object sender, EventArgs e)
    {
        ExportGridToPDF();
    }
    private void ExportGridToPDF()
    {
        string nombre = "Reporte-" + DateTime.Now.ToShortDateString();
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
        Paragraph twainBibText = new Paragraph("Reporte de eventos", times);
        twainBibText.Alignment = Element.ALIGN_CENTER;
        pdfDoc.Add(twainBibText);

        //Adding paragraph for report generated by
        Paragraph prgGeneratedBY = new Paragraph();
        BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 3, iTextSharp.text.BaseColor.DARK_GRAY);
        prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
        string usuario = User.Identity.Name;
        prgGeneratedBY.Add(new Chunk("Reporte Generado: " + usuario, fntAuthor));
        prgGeneratedBY.Add(new Chunk("\nFecha Creada : " + DateTime.Now.ToShortDateString(), fntAuthor));
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
            cellText = cell2.Text;
            PdfPCell cell = new PdfPCell();
            cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 13, 1, new BaseColor(ColorTranslator.FromHtml("#ffffff"))));
            cell.BackgroundColor = new BaseColor(ColorTranslator.FromHtml("#0c4566"));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.PaddingBottom = 5;
            table.AddCell(cell);
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                table.AddCell(dt.Rows[i][j].ToString());
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
        DataTable dt2 = new DataTable("Eventos del dispositivo");
        //int p = 0;
        foreach (TableCell cell in GridView1.HeaderRow.Cells)
        {
            dt2.Columns.Add(cell.Text);
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt2.Rows.Add();
            for (int j = 0; j < dt2.Columns.Count; j++)
            {
                dt2.Rows[dt2.Rows.Count - 1][j] = dt.Rows[i][j];
            }
        }
        using (var wb = new XLWorkbook())
        {
            var vv = wb.Worksheets.Add("Reporte de Eventos");
            vv.Range("A1:B1").Row(1).Merge();
            vv.Cell("A1").Style.Font.FontSize = 35;
            vv.Cells("c1:I1").Style.Font.FontSize = 20;
            vv.Cells("c1:I1").Style.Fill.BackgroundColor = XLColor.PowderBlue;
            vv.Cell("D1").Value = "Reporte de Eventos";
            vv.Cell("D1").Style.Font.Bold = true;
            vv.Cell("D1").Style.Font.FontColor = XLColor.BluePigment;
            vv.Range("D1:H1").Row(1).Merge();
            vv.Cell("D1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            vv.Cells("D6:J6").Style.Font.FontSize = 15;
            vv.Cell("G3").Value = "Fecha Creada: " + DateTime.Now.ToShortDateString();
            vv.Cell("G3").Style.Font.FontColor = XLColor.BluePigment;
            vv.Cell("G3").Style.Font.Bold = true;
            vv.Cell("G3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            vv.Cell("G3").Style.Font.FontSize = 13;
            vv.Range("G3:H3").Row(1).Merge();
            vv.Cell("G4").Value = "Dispositivo: " + riscei;
            vv.Cell("G4").Style.Font.Bold = true;
            vv.Cell("G4").Style.Font.FontColor = XLColor.BluePigment;
            vv.Cell("G4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
            vv.Cell("G4").Style.Font.FontSize = 13;
            vv.Range("G4:H4").Row(1).Merge();

            byte[] imagen = ConsultarIcono();
            MemoryStream buf = new MemoryStream(imagen);
            Bitmap im = new Bitmap(buf);
            vv.Worksheet.AddPicture(im);
            vv.Cell(7, 4).InsertTable(dt2);
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string filename = "Reporte-" + DateTime.Now.ToShortDateString();
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

}