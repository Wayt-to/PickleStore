using PickleMainStoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickleMainStoreApp
{
    public partial class LoginForm : Form
    {
        PickleStoreModel db = new PickleStoreModel();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text;
            string pass = tb_password.Text;
            Employee user = db.Employees.FirstOrDefault(u => u.Username == username && u.Password == pass);

            if (user != null)
            {
                if (user.IsActive)
                {
                    MainForm mainForm = new MainForm(user);
                    //db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    user.LastLoginTime = DateTime.Now;
                    db.SaveChanges();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    label3.Text = "Hesabınız aktif değil. Lütfen yetkiliyle iletişime geçin.";
                    label3.Visible = true;
                }
            }
            else
            {
                label3.Text = "Geçersiz kullanıcı adı veya şifre!";
                label3.Visible = true;
            }
        }

    }
}
