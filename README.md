# App_DB
example of using a database with the Sqlclient class c#
working with DB and excel downloading & uploading data

Example of working with a database via Sql Commands

 DB_Data = new List<ProductDB>();// Массив строк {id,article,Name,Price,Quantity}

            if (answer.HasRows)//не пустой ли ответ
            {
                while (answer.Read())// ссчитать строку
                {
                    int index = 0;


                    ProductDB temp = new ProductDB() // создать класс  который равен 1 строке
                    {
                        ID = answer.GetInt32(0),
                        Article =   answer.GetString(1),
                        Name =      answer.GetString(2),
                        Price =     answer.GetDecimal(3),
                        Quantity =  answer.GetInt32(4), 
                        
                        
                    };  

                    DB_Data.Add(temp);// добавить в
                    Console.WriteLine(index);
                    index++;
                }
                answer.Close();
            } 

Downloading data from Excel
  
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
  
