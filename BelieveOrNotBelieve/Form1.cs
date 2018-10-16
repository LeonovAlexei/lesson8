//Леонов Алексей
//Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок
//(не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
//б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие 
//«косметические» улучшения на свое усмотрение.
//в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, 
//авторские права и др.).
//г)* Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных
//(элемент SaveFileDialog).
//Добавил чтение и запись в формате Json

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BelieveOrNotBelieve
{
    public partial class Form1 : Form
    {
        // База данных с вопросами
        TrueFalse database;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void formTextValk(string fileName)
        {
            this.Text = $"Верю - Не верю. Открыт файл:{fileName}";

        }
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("123", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                
            };
            formTextValk(sfd.FileName);
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
            cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null) return;
            database.Remove((int)nudNumber.Value);
            nudNumber.Maximum--;
            if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;


        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else MessageBox.Show("База данных не создана");

        }

        public void miOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    database = new TrueFalse(ofd.FileName);
                    database.Load();
                    nudNumber.Minimum = 1;
                    nudNumber.Maximum = database.Count;
                    nudNumber.Value = 1;
                    
                }
                formTextValk(ofd.FileName);
            }
            catch (InvalidOperationException)//открываем файл отличный от фрмата
            {
                MessageBox.Show("Невозможно прочитать файл XML загрузчиком! Пробуйте открыть  файл формата XML", "Сообщение"); 
                
                 miOpen_Click(sender, e);
                // throw;
            }
            finally
            {
               
            }
            

        }

        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            database[(int)nudNumber.Value - 1].text = tboxQuestion.Text;
            database[(int)nudNumber.Value - 1].trueFalse = cboxTrue.Checked;

        }

        private void miSaveJson_Click(object sender, EventArgs e)
        {
            if (database != null) database.SaveJson();
            else MessageBox.Show("База данных не создана");
        }

        private void miOpenJson_Click(object sender, EventArgs e)
        {


            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    database = new TrueFalse(ofd.FileName);
                    database.LoadJson();
                    nudNumber.Minimum = 1;
                    nudNumber.Maximum = database.Count;
                    nudNumber.Value = 1;
                }
                formTextValk(ofd.FileName);
            }
            catch (Newtonsoft.Json.JsonReaderException) //открываем файл отличный от фрмата
            {
                MessageBox.Show("Невозможно прочитать файл Json загрузчиком! Пробуйте открыть  файл формата Json", "Сообщение"); //+ ofd.FileName

                miOpenJson_Click(sender, e);
                //throw;
            }
            
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version ver = new Version();
            ver.Show();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;

            };
            formTextValk(sfd.FileName);
        }
    }
}
