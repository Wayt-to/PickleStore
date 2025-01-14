using PickleMainStoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickleMainStoreApp.Forms
{
    public partial class EmployeesForm : Form
    {
        Employee _user;
        GeneralDataModel dm = new GeneralDataModel();
        PickleStoreModel db = new PickleStoreModel();
        int rowIndex = -1;
        public EmployeesForm(Employee user)
        {
            InitializeComponent();
            _user = user;
            dm.LoadEmployees(dataGridView1);
        }

        private void tsmi_edit_Click(object sender, EventArgs e)
        {
            if (tb_id.Text == "" || tb_name.Text == "" || tb_surname.Text == "" || tb_phone.Text == "(___) ___-____" || tb_mail.Text == "")
            {
                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Employee s = db.Employees.Find(id);
                    tb_id.Text = s.ID.ToString();
                    tb_name.Text = s.Name;
                    tb_surname.Text = s.Surname;
                    tb_username.Text = s.Username;
                    tb_mail.Text = s.Mail;
                    tb_address.Text = s.Address;
                    tb_phone.Text = s.Phone;
                    tb_password.Text = s.Password;
                    tb_saveTime.Text = s.CreationTime.ToString("dd/MM/yyyy HH:mm");
                    if (s.Type=="Yönetici")
                    {
                        check_Admin.Checked = true;
                    }
                    else
                    {
                        check_Admin.Checked = false;
                    }
                    check_isActive.Checked = s.IsActive;
                }
            }
            else
            {
                if (MessageBox.Show("Ekranda kaydedilmeyen veri varsa silinecek, emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (rowIndex != -1)
                    {
                        
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Employee s = db.Employees.Find(id);
                    tb_id.Text = s.ID.ToString();
                    tb_name.Text = s.Name;
                    tb_surname.Text = s.Surname;
                    tb_username.Text = s.Username;
                    tb_mail.Text = s.Mail;
                    tb_address.Text = s.Address;
                    tb_phone.Text = s.Phone;
                    tb_password.Text = s.Password;
                    tb_saveTime.Text = s.CreationTime.ToString("dd/MM/yyyy HH:mm");
                    if (s.Type=="Yönetici")
                    {
                        check_Admin.Checked = true;
                    }
                    else
                    {
                        check_Admin.Checked = false;
                    }
                    check_isActive.Checked = s.IsActive;
                    }
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çalışanı silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Employee s = db.Employees.Find(id);
                    if (s.Type == "Yönetici")
                    {
                        var result = MessageBox.Show("Bu yönetici kullanıcıyı silmek istediğinizden emin misiniz? Sistemde en az bir yönetici kalmalıdır.", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                        int adminCount = db.Employees.Count(sq => sq.Type == "Yönetici" && sq.ID != id);
                        if (adminCount < 1)
                        {
                            MessageBox.Show("Sistemde en az bir yönetici olmalıdır. Bu yönetici silinemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    try
                    {
                        s.IsActive = false;
                        s.IsDeleted = true;
                        db.SaveChanges();
                        MessageBox.Show("Çalışan silme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadEmployees(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Çalışan silme işlemi başarısız : " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dm.ClearAllControls(this);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tb_id.Text != "")
            {
                if (!(string.IsNullOrWhiteSpace(tb_name.Text) || string.IsNullOrWhiteSpace(tb_mail.Text) || string.IsNullOrWhiteSpace(tb_phone.Text) || string.IsNullOrWhiteSpace(tb_surname.Text)|| string.IsNullOrWhiteSpace(tb_password.Text)))
                {
                    Employee s = db.Employees.Find(Convert.ToInt32(tb_id.Text));
                    s.Name = tb_name.Text;
                    s.Surname = tb_surname.Text;
                    s.Username = tb_username.Text;
                    s.Password = tb_password.Text;
                    s.Address = tb_address.Text;
                    s.Phone = tb_phone.Text;
                    s.Mail = tb_mail.Text;
                    s.CreationTime = DateTime.Now;
                    s.LastLoginTime = DateTime.Now;
                    s.IsActive = check_isActive.Checked;
                    if (check_Admin.Checked)
                    {
                        s.Type = "Yönetici";
                    }
                    else
                    {
                        s.Type = "Çalışan";
                    }
                    if (s.IsActive) s.IsDeleted = false;
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Çalışan düzenleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadEmployees(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Çalışan düzenlenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!(string.IsNullOrWhiteSpace(tb_name.Text) || string.IsNullOrWhiteSpace(tb_mail.Text) || string.IsNullOrWhiteSpace(tb_phone.Text) || string.IsNullOrWhiteSpace(tb_surname.Text) || string.IsNullOrWhiteSpace(tb_password.Text)))
                {
                    Employee s = new Employee();
                    s.Name = tb_name.Text;
                    s.Surname = tb_surname.Text;
                    s.Username = tb_username.Text;
                    s.Password = tb_password.Text;
                    s.Address = tb_address.Text;
                    s.Phone = tb_phone.Text;
                    s.Mail = tb_mail.Text;
                    s.CreationTime = DateTime.Now;
                    s.LastLoginTime = DateTime.Now;
                    s.IsActive = check_isActive.Checked;
                    if (check_Admin.Checked)
                    {
                        s.Type = "Yönetici";
                    }
                    else
                    {
                        s.Type = "Çalışan";
                    }
                    if (s.IsActive) s.IsDeleted = false;
                    try
                    {
                        db.Employees.Add(s);
                        db.SaveChanges();
                        MessageBox.Show("Çalışan ekleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadEmployees(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Çalışan eklenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowIndex = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (rowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[rowIndex].Selected = true;
                    contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Password" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
                e.FormattingApplied = true;
            }
        }

    }
}
