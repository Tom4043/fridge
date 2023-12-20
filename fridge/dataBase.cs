using MySql.Data.MySqlClient;
using fridge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fridge
{
    public partial class dataBase : Form
    {
        public dataBase()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void HeadOfTable()
        {
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "номер";//текст в шапке
            column1.Width = 50;//ширина колонки
            column1.Name = "id";//имя столбца
            column1.Frozen = true;//запрет на изменение
            column1.CellTemplate = new DataGridViewTextBoxCell();//тип колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "название";//текст в шапке
            column2.Width = 200;//ширина колонки
            column2.Name = "name";//имя столбца
            column2.Frozen = true;//запрет на изменение
            column2.CellTemplate = new DataGridViewTextBoxCell();//тип колонки

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "время";//текст в шапке
            column3.Width = 100;//ширина колонки
            column3.Name = "time";//имя столбца
            column3.Frozen = true;//запрет на изменение
            column3.CellTemplate = new DataGridViewTextBoxCell();//тип колонки

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "действие";//текст в шапке
            column4.Width = 100;//ширина колонки
            column4.Name = "action";//имя столбца
            column4.Frozen = true;//запрет на изменение
            column4.CellTemplate = new DataGridViewTextBoxCell();//тип колонки


            dataC1.Columns.Add(column1);
            dataC1.Columns.Add(column2);
            dataC1.Columns.Add(column3);
            dataC1.Columns.Add(column4);


            dataC1.AllowUserToAddRows = false;//запрет пользователю добавлять элементы в бд
            dataC1.ReadOnly = true; //запрет пользователю менять данные

        }
        private void AddData(operat row)
        {
            dataC1.Rows.Add(row.id, row.name, row.time, row.action);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frige UH = new frige();
            UH.Show();
        }

        private void dataBase_Shown(object sender, EventArgs e)
        {
            HeadOfTable();
            List<operat> _data = new List<operat>();//создаём спсок данных

            //открываем базу данных и считываем с нее данные
            operation db = new operation();
            //DataTable Table = new DataTable();



            MySqlCommand _command = new MySqlCommand("SELECT * FROM `oper`", db.GetConnection());
            MySqlDataReader _reader;


            try//основная часть работает
            {
                db.OpenConnection();

                _reader = _command.ExecuteReader();
                // _reader = _command.ExecuteReader();

                while (_reader.Read())
                {
                    //заполняем данные
                    operat row = new operat(_reader["id"], _reader["name"], _reader["time"], _reader["action"]);
                    _data.Add(row);
                }

                //добавляем в таблицу данные
                for (int i = 0; i < _data.Count; i++)
                    AddData(_data[i]);

            }
            catch//если ошибка в основной части
            {
                MessageBox.Show("Ошибка работы с базой данных!", "Ошибка!");
            }
            finally//по окончанию (всегда)
            {
                db.CloseConnection();
            }
        }

        private void x_Click(object sender, EventArgs e)
        {
            operation db = new operation();
            MySqlCommand command = new MySqlCommand("DELETE FROM `oper`", db.GetConnection());
            db.OpenConnection();
            command.ExecuteNonQuery();
            db.CloseConnection();
            this.Close();
        }

        private void dataBase_Load(object sender, EventArgs e)
        {

        }
    }
}
