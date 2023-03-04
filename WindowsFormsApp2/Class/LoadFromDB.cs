using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Class;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2
{  
    public class LoadFromDB
    { 
        SqlConnection connectionString;
        List<ProductDB> DB_Data;


        public void  saveFromDB()
        {
            LoadFromXLs xlsClass = new LoadFromXLs();
            List<ProductDB> saveFiles = xlsClass.getXLSData();
            foreach (var item in saveFiles)
            {
                    SqlCommand querySave = new SqlCommand($"INSERT INTO [dbo].[Products](" +
                        $"" +
                        $" Article, [Name], price, Quantity) VALUES ('{item.Article}','{item.Name}',{item.Price},{item.Quantity})", connectionString); // создать команду
                    querySave.ExecuteNonQuery(); // выполнить командлу
            }

        }


        public void saveFromDB(List<ProductDB> saveFile1)
        {
            LoadFromXLs xlsClass = new LoadFromXLs();

            SqlCommand querySave1 = new SqlCommand($"TRUNCATE TABLE [dbo].[Products]", connectionString); // создать команду
            querySave1.ExecuteNonQuery();

            saveFromDB();


            //foreach (var item in saveFile1)
            //{
            //    SqlCommand querySave = new SqlCommand($"INSERT INTO [dbo].[Products](" +
            //        $"" +
            //        $" Article, [Name], price, Quantity) VALUES ('{item.Article}','{item.Name}',{item.Price},{item.Quantity})", connectionString); // создать команду
            //    querySave.ExecuteNonQuery(); // выполнить командлу
            //}

        }


        public LoadFromDB()
        {
            connectionString = new SqlConnection(@"Server=LEGION\SQLEXPRESS;Database=D_BASE_1;Trusted_Connection=True");
            try
            {
                connectionString.Open();// открыть подключение
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("БД подключено");
            }

            int i = 0;
            if(i<1)
            {
                SqlCommand queryConnectDB =  new SqlCommand("use D_BASE_1", connectionString);// подключить БД 1 раз!!!!!!
                i++;
            }

            saveFromDB();
            SqlCommand query = new SqlCommand("SELECT * FROM Products", connectionString); // создать команду
                                         
       

            SqlDataReader answer = query.ExecuteReader(); // выполнить командлу

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

        }

        public List<ProductDB> GetData()
        {
            return DB_Data;
        }

        public void CloseDb()
        {
            connectionString.Close();
        }

    }
}
 