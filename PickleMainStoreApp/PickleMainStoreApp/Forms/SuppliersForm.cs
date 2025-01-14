using PickleMainStoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PickleMainStoreApp.Forms
{
    public partial class SuppliersForm : Form
    {
        GeneralDataModel dm = new GeneralDataModel();
        PickleStoreModel db = new PickleStoreModel();
        Employee _user;
        int rowIndex = -1;
        public SuppliersForm(Employee user)
        {
            InitializeComponent();
            _user = user;
            dm.LoadSuppliers(dataGridView1);
            dataGridView1.Columns["Address"].Width = 300;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dm.ClearAllControls(this);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tb_id.Text!="")
            {
                if (!(string.IsNullOrWhiteSpace(tb_contactName.Text) || string.IsNullOrWhiteSpace(tb_mail.Text) || string.IsNullOrWhiteSpace(tb_phone.Text) || string.IsNullOrWhiteSpace(tb_compName.Text)))
                {
                    Supplier s = db.Suppliers.Find(Convert.ToInt32(tb_id.Text));
                    s.CompanyName = tb_compName.Text;
                    s.ContactName = tb_contactName.Text;
                    s.Adress = tb_address.Text;
                    s.Phone = tb_phone.Text;
                    s.ContactMail = tb_mail.Text;
                    s.SaveTime = DateTime.Now;
                    s.EmployeeID = _user.ID;
                    s.IsActive = check_isActive.Checked;
                    if (s.IsActive) s.IsDeleted = false;
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Tedarik şirketi düzenleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadSuppliers(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tedarik şirketi düzenlenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!(string.IsNullOrWhiteSpace(tb_contactName.Text) || string.IsNullOrWhiteSpace(tb_mail.Text) || string.IsNullOrWhiteSpace(tb_phone.Text) || string.IsNullOrWhiteSpace(tb_compName.Text)))
                {
                    Supplier s = new Supplier();
                    s.CompanyName = tb_compName.Text;
                    s.ContactName = tb_contactName.Text;
                    s.Adress = tb_address.Text;
                    s.Phone = tb_phone.Text;
                    s.ContactMail = tb_mail.Text;
                    s.SaveTime = DateTime.Now;
                    s.EmployeeID = _user.ID;
                    s.IsActive = check_isActive.Checked;
                    s.IsDeleted = false;
                    try
                    {
                        db.Suppliers.Add(s);
                        db.SaveChanges();
                        MessageBox.Show("Tedarik şirketi ekleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadSuppliers(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tedarik şirketi eklenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsmi_edit_Click(object sender, EventArgs e)
        {
            if (tb_id.Text==""||tb_compName.Text==""||tb_contactName.Text==""||tb_phone.Text=="(___) ___-____"||tb_mail.Text=="")
            {
                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Supplier s = db.Suppliers.Find(id);
                    tb_id.Text = s.ID.ToString();
                    tb_compName.Text = s.CompanyName;
                    tb_contactName.Text = s.ContactName;
                    tb_address.Text = s.Adress;
                    tb_phone.Text = s.Phone;
                    tb_mail.Text = s.ContactMail;
                    tb_saveTime.Text = s.SaveTime.ToString("dd/MM/yyyy HH:mm");
                    tb_whosaved.Text = s.Employee?.Name ?? "";
                    check_isActive.Checked = s.IsActive;

                }
            }
            else
            {
                if (MessageBox.Show("Ekranda kaydedilmeyen veri varsa silinecek, emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (rowIndex !=-1)
                    {
                        int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                        Supplier s = db.Suppliers.Find(id);
                        tb_id.Text = s.ID.ToString();
                        tb_compName.Text = s.CompanyName;
                        tb_contactName.Text = s.ContactName;
                        tb_address.Text = s.Adress;
                        tb_phone.Text = s.Phone;
                        tb_mail.Text = s.ContactMail;
                        tb_saveTime.Text = s.SaveTime.ToString("dd/MM/yyyy HH:mm");
                        tb_whosaved.Text = s.Employee?.Name ?? "";
                        check_isActive.Checked = s.IsActive;

                    }
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

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tedarikçiyi silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Supplier s = db.Suppliers.Find(id);
                    try
                    {
                        s.IsActive = false;
                        s.IsDeleted = true;
                        db.SaveChanges();
                        MessageBox.Show("Tedarikçi silme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadSuppliers(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tedarikçi silme işlemi başarısız : " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
