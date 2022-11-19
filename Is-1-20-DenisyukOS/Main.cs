using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;

namespace Is_1_20_DenisyukOS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public void ManagerRole(int role)
        {
            switch (role)
            {
                case 1:
                    guna2HtmlLabel1.Text = "Сотрудник";
                    guna2HtmlLabel1.ForeColor = Color.Pink;
                    guna2HtmlLabel1.Enabled = true;
                    guna2HtmlLabel2.Enabled = true;
                    guna2HtmlLabel3.Enabled = false;
                    break;
                case 2:
                    guna2HtmlLabel1.Text = "Администратор";
                    guna2HtmlLabel1.ForeColor = Color.Green;
                    guna2HtmlLabel1.Enabled = true;
                    guna2HtmlLabel2.Enabled = true;
                    guna2HtmlLabel3.Enabled = true;
                    break;
                case 3:
                    guna2HtmlLabel1.Text = "Помошник";
                    guna2HtmlLabel1.ForeColor = Color.Orange;
                    guna2HtmlLabel1.Enabled = true;
                    guna2HtmlLabel2.Enabled = false;
                    guna2HtmlLabel3.Enabled = false;
                    break;
                default:
                    guna2HtmlLabel1.Text = "Неизвестный пользователь";
                    guna2HtmlLabel1.ForeColor = Color.Red;
                    guna2HtmlLabel1.Enabled = true;
                    guna2HtmlLabel2.Enabled = false;
                    guna2HtmlLabel3.Enabled = false;
                    break;
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //Сокрытие текущей формы
            this.Hide();
            //Инициализируем и вызываем форму диалога авторизации
            Authh Auth2 = new Authh();
            //Вызов формы в режиме диалога
            Auth2.ShowDialog();
            //Если авторизации была успешна и в поле класса хранится истина, то делаем движуху:
            if (Auth.auth)
            {
                //Отображаем рабочую форму
                this.Show();
                //Вытаскиваем из класса поля в label'ы
                guna2HtmlLabel2.Text = Auth.auth_id;
                guna2HtmlLabel3.Text = Auth.auth_fio;
                guna2HtmlLabel4.Text = "Лецензированый пользователь";
                guna2HtmlLabel4.ForeColor = Color.Green;
                ManagerRole(Auth.auth_role);
            }
            //иначе
            else
            {
                //Закрываем форму
                this.Show();
                guna2HtmlLabel2.Text = "Неизвестный пользователь";
                guna2HtmlLabel3.Text = "Отсутствует информация";
                guna2HtmlLabel4.Text = "Уходи";
                guna2HtmlLabel4.ForeColor = Color.Red;
                ManagerRole(Auth.auth_role);
            }
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            guna2Panel1.Controls.Add(childForm);
            guna2Panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            openChildForm(new Сlient());
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            openChildForm(new Employees());
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            openChildForm(new Price());
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            openChildForm(new Notice());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
