using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ComercSistemaVentas.Operadores
{
    public class CreacionXLSX
    {
        private string fileName;
        private string extension = ".xlsx";
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Comerc\Ventas\";

        public CreacionXLSX(string nombre = "file1")
        {
            fileName = nombre;
            filePath += fileName + extension;
        }
        public void CrearArchivo(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (var stream = File.Create(filePath))
                {
                    // Se crea el archivo vacío
                }
            }
        }

        public void DocumentCreation(DataTable dt)
        {
            CrearArchivo(filePath);

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Hoja 1" };
                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>() ?? new SheetData();

                Row headerRow = new Row();
                foreach (DataColumn column in dt.Columns)
                {
                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(column.ColumnName);
                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);

                foreach (DataRow row in dt.Rows)
                {
                    Row dataRow = new Row();
                    foreach (DataColumn column in dt.Columns)
                    {
                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(row[column]?.ToString() ?? string.Empty);
                        dataRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(dataRow);
                }

                workbookPart.Workbook.Save();
                document.Save();

            }
        }
    }
}
