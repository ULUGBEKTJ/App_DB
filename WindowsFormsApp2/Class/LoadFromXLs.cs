using Aspose.Cells;
using System;
using System.Collections.Generic;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2.Class
{
    public class LoadFromXLs
    {
        List<ProductDB> DB_Data;
        public void loadXLS(string path = "C:\\Users\\ULUGBEK\\Desktop\\1.xlsx")
        {
            DB_Data = new List<ProductDB>();
            // Загрузить файл Excel
            Workbook wb = new Workbook(path);

            // Получить все рабочие листы
            WorksheetCollection collection = wb.Worksheets;

            // Перебрать все рабочие листы
            for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
            {

                // Получить рабочий лист, используя его индекс
                Worksheet worksheet = collection[worksheetIndex];

                // Печать имени рабочего листа
                Console.WriteLine("Worksheet: " + worksheet.Name);

                // Получить количество строк и столбцов
                int rows = worksheet.Cells.MaxDataRow;
                int cols = worksheet.Cells.MaxDataColumn;

                // Цикл по строкам
                for (int i = 0; i < rows+1; i++)
                { 
                    ProductDB temp = new ProductDB()
                    {
                        ID = Convert.ToInt32( worksheet.Cells[i, 0].Value),
                        Article =  worksheet.Cells[i, 1].Value.ToString(),
                        Name = (string)worksheet.Cells[i, 2].Value.ToString(),
                        Price = Convert.ToDecimal(worksheet.Cells[i, 3].Value),
                        Quantity = Convert.ToInt32(worksheet.Cells[i, 4].Value)
                    };

                    DB_Data.Add(temp);
                }
            }
        }


        public List<ProductDB> getXLSData()
        {
            loadXLS();
            return DB_Data;
        }
         
    }
}
