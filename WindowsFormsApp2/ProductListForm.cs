using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Class;
using WindowsFormsApp2.Model;

namespace WindowsFormsApp2
{
    public partial class ProductListForm : Form
    {
        List<ProductDB> DB_Data;
        LoadFromDB data;
        public ProductListForm()
        {
            InitializeComponent();//

            LoadFromXLs xlas = new LoadFromXLs();
            xlas.loadXLS();

            Update();


        }
        private void Update()
        {
            DB_Data = new List<ProductDB>();

            LoadFromDB data = new LoadFromDB();
            DB_Data = data.GetData();

            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            foreach (var rowsProductDB in DB_Data)
            {
                dataGridView1.Rows.Add(rowsProductDB.ID,
                    rowsProductDB.Article,
                    rowsProductDB.Name,
                    rowsProductDB.Price,
                    rowsProductDB.Quantity);
            }

        }
        private void ProductListForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<ProductDB> DB_Data_2 = new List<ProductDB>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                ProductDB tempPr = new ProductDB()
                {
                    Article = Convert.ToString( row.Cells[1].Value),
                    Name = Convert.ToString (row.Cells[2].Value),
                    Price = Convert.ToDecimal( row.Cells[3].Value),
                    Quantity = Convert.ToInt32(row.Cells[4].Value)
                };
                DB_Data_2.Add(tempPr);
            }
            LoadFromDB saveToDB = new LoadFromDB();
            saveToDB.saveFromDB(DB_Data_2);
            Update();
        }
    }
}
