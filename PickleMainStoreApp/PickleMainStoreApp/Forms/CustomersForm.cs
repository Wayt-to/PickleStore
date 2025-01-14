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
    public partial class CustomersForm : Form
    {
        int rowIndex = -1;
        int rowIndex2 = -1;
        GeneralDataModel dm = new GeneralDataModel();
        PickleStoreModel db = new PickleStoreModel();
        Employee _user;
        public CustomersForm(Employee user)
        {
            InitializeComponent();
            dm.LoadCustomers(dataGridView1);
            dm.LoadTypes(dataGridView2);
            _user = user;
            Load();

        }

        private void Load()
        {
            cb_type.DataSource = db.Types.ToList();
            cb_type.DisplayMember = "TypeName";
            cb_type.ValueMember = "ID";
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            dm.ClearAllControls(this.groupBox1);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tb_id.Text != "")
            {
                if (!(string.IsNullOrWhiteSpace(tb_Name.Text) || string.IsNullOrWhiteSpace(tb_mail.Text) || string.IsNullOrWhiteSpace(tb_phone.Text) || string.IsNullOrWhiteSpace(tb_surname.Text)))
                {
                    Customer s = db.Customers.Find(Convert.ToInt32(tb_id.Text));
                    s.Name = tb_Name.Text;
                    s.Surname = tb_surname.Text;
                    s.Adress = tb_address.Text;
                    s.Phone = tb_phone.Text;
                    s.Mail = tb_mail.Text;
                    s.CreationTime = DateTime.Now;
                    s.Employee_ID = _user.ID;
                    s.TypesAndDiscounts_ID = (int)cb_type.SelectedValue;
                    s.IsActive = check_isActive.Checked;
                    if (s.Type.IsActive==false)
                    {
                        if (MessageBox.Show("Aktifleştirmek istediğiniz müşterinin türü aktif değil, eğer evet'e tıklarsanız tür de aktifleştirelecek, emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            s.IsDeleted = false;
                            s.Type.IsActive = true;
                            s.Type.IsDeleted = false;
                        }

                    }
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Müşteri düzenleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadCustomers(dataGridView1);
                        dm.LoadTypes(dataGridView2);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Müşteri düzenlenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!(string.IsNullOrWhiteSpace(tb_Name.Text) || string.IsNullOrWhiteSpace(tb_mail.Text) || string.IsNullOrWhiteSpace(tb_phone.Text) || string.IsNullOrWhiteSpace(tb_surname.Text)))
                {
                    Customer s = new Customer();
                    s.Name = tb_Name.Text;
                    s.Surname = tb_surname.Text;
                    s.Adress = tb_address.Text;
                    s.Phone = tb_phone.Text;
                    s.Mail = tb_mail.Text;
                    s.CreationTime = DateTime.Now;
                    s.Employee_ID = _user.ID;
                    s.TypesAndDiscounts_ID = (int)cb_type.SelectedValue;
                    s.IsActive = check_isActive.Checked;
                    if (s.IsActive) s.IsDeleted = false;
                    try
                    {
                        db.Customers.Add(s);
                        db.SaveChanges();
                        MessageBox.Show("Müşteri ekleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadCustomers(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Müşteri eklenemedi.: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void tsmi_edit_Click(object sender, EventArgs e)
        {
            if (tb_id.Text == "" || tb_Name.Text == "" || tb_surname.Text == "" || tb_phone.Text == "(___) ___-____" || tb_mail.Text == "")
            {
                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Customer s = db.Customers.Find(id);
                    tb_id.Text = s.ID.ToString();
                    tb_Name.Text = s.Name;
                    tb_surname.Text = s.Surname;
                    tb_address.Text = s.Adress;
                    tb_phone.Text = s.Phone;
                    tb_mail.Text = s.Mail;
                    tb_saveTime.Text = s.CreationTime.ToString("dd/MM/yyyy HH:mm");
                    cb_type.SelectedValue = s.Type.ID;
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
                        Customer s = db.Customers.Find(id);
                        tb_id.Text = s.ID.ToString();
                        tb_Name.Text = s.Name;
                        tb_surname.Text = s.Surname;
                        tb_address.Text = s.Adress;
                        tb_phone.Text = s.Phone;
                        tb_mail.Text = s.Mail;
                        tb_saveTime.Text = s.CreationTime.ToString("dd/MM/yyyy HH:mm");
                        cb_type.SelectedValue = s.Type.ID;
                        check_isActive.Checked = s.IsActive;
                    }
                }
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Müşteriyi silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Customer s = db.Customers.Find(id);
                    try
                    {
                        s.IsActive = false;
                        s.IsDeleted = true;
                        db.SaveChanges();
                        MessageBox.Show("Müşteri silme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadCustomers(dataGridView1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Müşteri silme işlemi başarısız : " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CustomersForm_Activated(object sender, EventArgs e)
        {
            Load();
        }

        private void btn_TypeClear_Click(object sender, EventArgs e)
        {
            dm.ClearAllControls(this.groupBox2);
        }

        private void btn_TypeSave_Click(object sender, EventArgs e)
        {
            if (tb_typeID.Text != "")
            {
                if (!(string.IsNullOrWhiteSpace(tb_typeName.Text) ))
                {
                    TypesAndDiscounts s = db.Types.Find(Convert.ToInt32(tb_typeID.Text));
                    s.TypeName = tb_typeName.Text;
                    s.Discount = Convert.ToDouble(tb_discount.Value/100);
                    s.IsActive = check_typeActive.Checked;
                    if (s.IsActive) s.IsDeleted = false;
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Tür düzenleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadTypes(dataGridView2);
                        dm.LoadCustomers(dataGridView1);
                        Load();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tür düzenlenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!(string.IsNullOrWhiteSpace(tb_typeName.Text)))
                {
                    TypesAndDiscounts s = new TypesAndDiscounts();
                    s.TypeName = tb_typeName.Text;
                    s.Discount = Convert.ToDouble(tb_discount.Value / 100);
                    s.IsActive = check_typeActive.Checked;
                    if (s.IsActive) s.IsDeleted = false;
                    try
                    {
                        db.Types.Add(s);
                        db.SaveChanges();
                        MessageBox.Show("Tür ekleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadTypes(dataGridView2);
                        dm.LoadCustomers(dataGridView1);
                        Load();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Tür eklenemedi.: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowIndex2 = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                if (rowIndex2 >= 0)
                {
                    dataGridView2.ClearSelection();
                    dataGridView2.Rows[rowIndex2].Selected = true;
                    contextMenuStrip2.Show(dataGridView2, e.X, e.Y);
                }
            }
        }

        private void tsmi_edit2_Click(object sender, EventArgs e)
        {
            if (tb_typeID.Text == "" || tb_discount.Text == "" || tb_typeName.Text == "" )
            {
                if (rowIndex2 != -1)
                {
                    int id = Convert.ToInt32(dataGridView2.Rows[rowIndex2].Cells["ID"].Value);
                    TypesAndDiscounts s = db.Types.Find(id);
                    tb_typeID.Text = s.ID.ToString();
                    tb_typeName.Text = s.TypeName;
                    tb_discount.Value = Convert.ToDecimal(s.Discount*100);
                    check_isActive.Checked = s.IsActive;
                }
            }
            else
            {
                if (MessageBox.Show("Ekranda kaydedilmeyen veri varsa silinecek, emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (rowIndex2 != -1)
                    {
                        int id = Convert.ToInt32(dataGridView2.Rows[rowIndex2].Cells["ID"].Value);
                        TypesAndDiscounts s = db.Types.Find(id);
                        tb_typeID.Text = s.ID.ToString();
                        tb_typeName.Text = s.TypeName;
                        tb_discount.Value = Convert.ToDecimal(s.Discount * 100);
                        check_isActive.Checked = s.IsActive;
                    }
                }
            }
        }

        private void tsmi_delete2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Türü silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (rowIndex2 != -1)
                {
                    int id = Convert.ToInt32(dataGridView2.Rows[rowIndex2].Cells["ID"].Value);
                    if (dm.CanDeleteType(id))
                    {
                        TypesAndDiscounts s = db.Types.Find(id);
                        try
                        {
                            s.IsActive = false;
                            s.IsDeleted = true;
                            db.SaveChanges();
                            MessageBox.Show("Tür silme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            dm.LoadTypes(dataGridView2);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Tür silme işlemi başarısız : " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu türe sahip aktif müşteri mevcut olduğu için silinemedi. Detaylı bilgi için yardım sekmesine göz atın.", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
