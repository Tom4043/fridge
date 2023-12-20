using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace fridge
{
    public partial class frige : Form
    {
        static Int32 val1 = 5;
        static Int32 contr = 0;
        static Int32 timer = 0;
        static Int32 timeop = 0;
        static Int32 timecl = 0;
        static Int32 openD = 0;
        static Int32 brackM = 0;
        static Int32 brackD = 0;

        public frige()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.UDoor.BackgroundImage = System.Drawing.Image.FromFile("C:\\Users\\Tom40\\OneDrive\\Изображения\\Balsa\\Frige.jpg");
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------
            int tmop = timer;
            timeop = timer;
            timecl = timer;


            openD = 1;
            
//-------------------------------------------------------------------------------------------------------------------------------------------------------------
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.UDoor.BackgroundImage = System.Drawing.Image.FromFile("C:\\Users\\Tom40\\OneDrive\\Изображения\\Balsa\\FrCam.png");

            openD = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();//в зависимости от промежутка будет разный звук
            int rand = rnd.Next(0, 30);
            if (rand>=0 && rand<16 && brackM==0)//motor
            {
                operation db = new operation();
                MySqlCommand command = new MySqlCommand("INSERT INTO `oper` (`name`, `time`, `action`) VALUES (  @name, @t, @ac);", db.GetConnection());
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "моторчик";
                command.Parameters.Add("@t", MySqlDbType.VarChar).Value = timer.ToString();
                command.Parameters.Add("@ac", MySqlDbType.VarChar).Value = "поломка";
                db.OpenConnection();
                command.ExecuteNonQuery();
                db.CloseConnection();
                brackM = 1;
                playaudio2();
            }
            /*if (rand >= 11 && rand < 21)//termoregulator
            {
                

            }*/
            if (rand >= 16 && rand < 31 && brackD==0)//open dore
            {
                operation db = new operation();
                MySqlCommand command = new MySqlCommand("INSERT INTO `oper` (`name`, `time`, `action`) VALUES (  @name, @t, @ac);", db.GetConnection());
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "датчик двери";
                command.Parameters.Add("@t", MySqlDbType.VarChar).Value = timer.ToString();
                command.Parameters.Add("@ac", MySqlDbType.VarChar).Value = "поломка";

                db.OpenConnection();
                command.ExecuteNonQuery();
                db.CloseConnection();
                brackD = 1;
                playaudio1();
            }
            //------------------------------------------------------------------------------------------------------------------------------------------





            /*проверка на добавление в бд
            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Добавлено");
            else
                MessageBox.Show("Не добавлено");

            db.CloseConnection();*/
        }

        private void playaudio1() // defining the function
        {
            SoundPlayer audio = new SoundPlayer(fridge.Properties.Resources.omg_poco);
            // здесь WindowsFormsApplication1 - это пространство имен, а Connect - это имя аудиофайла
            audio.Play();
        }
        private void playaudio2() // defining the function
        {
            SoundPlayer audio = new SoundPlayer(fridge.Properties.Resources.motor_br);
            // здесь WindowsFormsApplication1 - это пространство имен, а Connect - это имя аудиофайла
            audio.Play();
        }
        private void playaudio3() // defining the function
        {
            SoundPlayer audio = new SoundPlayer(fridge.Properties.Resources.not_close);
            // здесь WindowsFormsApplication1 - это пространство имен, а Connect - это имя аудиофайла
            audio.Play();
        }
        private void Time_Tick(object sender, EventArgs e)
        {
            timer++;
            
            if (val1 <= 13 && contr==0)
            {
                val1++;
                if (val1 == 13)
                {
                    //занесение в бд вкл мотора
                    contr = 1;
                }
            }
            
            if (val1 >= 4 && contr == 1)
            {
                val1--;
                if (val1 == 4)
                {
                    //занесение в бд выкл мотора
                    contr = 0;
                }
            }
            Int32 P1 = val1;
            this.label4.Text = val1.ToString();



            timeop++;
            if (timeop-timecl==7 && openD==1)
            {
                playaudio3();

                operation db = new operation();
                MySqlCommand command = new MySqlCommand("INSERT INTO `oper` (`name`, `time`, `action`) VALUES (  @name, @t, @ac);", db.GetConnection());
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "двери не закрыли";
                command.Parameters.Add("@t", MySqlDbType.VarChar).Value = timer.ToString();
                command.Parameters.Add("@ac", MySqlDbType.VarChar).Value = "предупреждение";
                db.OpenConnection();
                command.ExecuteNonQuery();
                db.CloseConnection();
            }

            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (Time.Enabled)
            {
                // Таймер работает, значит, щелчок на кнопке Стоп. 
                // Остановить таймер. 
                Time.Enabled = false;
                // Изменить текст на кнопке 
                // и сделать доступной кнопку Сброс 
                button5.Text = "начать работу";
                //button2.Enabled = true;
            }
            else
            {
                // Таймер не работает, значит, щелчок на Пуск. 
                // Запускаем таймер. 
                Time.Enabled = true;
                // изменить текст на кнопке 
                button5.Text = "закончить работу";
                // и сделать недоступной кнопку Сброс 
                //button2.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            dataBase UH = new dataBase();
            UH.Show();
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (brackD == 1)
            {
                operation db = new operation();
                MySqlCommand command = new MySqlCommand("INSERT INTO `oper` (`name`, `time`, `action`) VALUES (  @name, @t, @ac);", db.GetConnection());
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "датчик двери";
                command.Parameters.Add("@t", MySqlDbType.VarChar).Value = timer.ToString();
                command.Parameters.Add("@ac", MySqlDbType.VarChar).Value = "починка";

                db.OpenConnection();
                command.ExecuteNonQuery();
                db.CloseConnection();
                brackD = 0;
                //звук врум врум, тип магически починилось как пыльцой фей
            }
            if (brackM == 1)
            {
                operation db = new operation();
                MySqlCommand command = new MySqlCommand("INSERT INTO `oper` (`name`, `time`, `action`) VALUES (  @name, @t, @ac);", db.GetConnection());
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "моторчик";
                command.Parameters.Add("@t", MySqlDbType.VarChar).Value = timer.ToString();
                command.Parameters.Add("@ac", MySqlDbType.VarChar).Value = "починка";

                db.OpenConnection();
                command.ExecuteNonQuery();
                db.CloseConnection();
                brackM = 0;
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
    }
}
