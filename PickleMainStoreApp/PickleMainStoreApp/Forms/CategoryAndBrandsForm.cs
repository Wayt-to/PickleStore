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
    public partial class CategoryAndBrandsForm : Form
    {
        int rowIndex1=-1;
        int rowIndex2 = -1;
        Employee _user;
        GeneralDataModel dm = new GeneralDataModel();
        PickleStoreModel db = new PickleStoreModel();
        public CategoryAndBrandsForm(Employee user)
        {
            InitializeComponent();
            dm.LoadCategories(dataGridCategory);
            dm.LoadBrands(dataGridBrand);
            _user = user;
        }

        private void btn_catClear_Click(object sender, EventArgs e)
        {
            
             dm.ClearAllControls(this.groupBox1);
            
        }

        private void btn_catSave_Click(object sender, EventArgs e)
        {
            if (tb_catID.Text=="")
            {
                if (string.IsNullOrEmpty(tb_catName.Text)|| string.IsNullOrEmpty(tb_catDescription.Text))
                {
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    Category c = new Category();
                    c.Name = tb_catName.Text;
                    c.Description = tb_catDescription.Text;
                    c.Employee = db.Employees.Find(_user.ID);
                    c.IsActive = check_CatActive.Checked;
                    if (c.IsActive) c.IsDeleted = false;
                    
                    db.Categories.Add(c);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Kategori başarıyla eklendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadCategories(dataGridCategory);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Kategori eklenemedi. ", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                int id = Convert.ToInt32(tb_catID.Text);
                Category c = db.Categories.Find(id);
                if (c!=null)
                {
                    c.Name = tb_catName.Text;
                    c.Description = tb_catDescription.Text;
                    c.Employee = db.Employees.Find(_user.ID);
                    c.IsActive = check_CatActive.Checked;

                    if (c.IsActive)
                    {
                        c.IsDeleted = false;
                    }
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Kategori başarıyla düzenlendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadCategories(dataGridCategory);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Kategori düzenlenemedi. ", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        private void dataGridCategory_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowIndex1 = dataGridCategory.HitTest(e.X, e.Y).RowIndex;
                if (rowIndex1 >= 0)
                {
                    dataGridCategory.ClearSelection();
                    dataGridCategory.Rows[rowIndex1].Selected = true;
                    contextMenuStrip1.Show(dataGridCategory, e.X, e.Y);
                }
            }
        }

        private void btn_brandClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ekranı temizlemek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dm.ClearAllControls(this.groupBox2);
            }

        }

        private void btn_brandSave_Click(object sender, EventArgs e)
        {
            if (tb_brandID.Text == "")
            {
                if (string.IsNullOrEmpty(tb_brandName.Text))
                {
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    Brand b = new Brand();
                    b.Name = tb_brandName.Text;
                    b.Employee = db.Employees.Find(_user.ID);
                    b.IsActive = check_brandActive.Checked;
                    if (b.IsActive) b.IsDeleted = false;

                    db.Brands.Add(b);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Marka başarıyla eklendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadBrands(dataGridBrand);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Marka eklenemedi. ", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                int id = Convert.ToInt32(tb_brandID.Text);
                Brand c = db.Brands.Find(id);
                if (c != null)
                {
                    c.Name = tb_brandName.Text;
                    c.Employee = db.Employees.Find(_user.ID);
                    c.IsActive = check_brandActive.Checked;

                    if (c.IsActive)
                    {
                        c.IsDeleted = false;
                    }
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Marka başarıyla düzenlendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        dm.LoadBrands(dataGridBrand);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Marka düzenlenemedi. ", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }
                }

            }
        }

        private void dataGridBrand_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowIndex2 = dataGridBrand.HitTest(e.X, e.Y).RowIndex;
                if (rowIndex2 >= 0)
                {
                    dataGridBrand.ClearSelection();
                    dataGridBrand.Rows[rowIndex2].Selected = true;
                    contextMenuStrip2.Show(dataGridBrand, e.X, e.Y);
                }
            }
        }

        private void tsmi_edit_Click(object sender, EventArgs e)
        {
            if (tb_catID.Text != "" && tb_catDescription.Text != "" && tb_catName.Text != "")
            {
                if (MessageBox.Show("Ekranda kaydedilmeyen veri varsa silinecek, emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (rowIndex1 != -1)
                    {
                        int id = Convert.ToInt32(dataGridCategory.Rows[rowIndex1].Cells["ID"].Value);
                        Category c = db.Categories.Find(id);
                        if (c != null)
                        {
                            tb_catID.Text = c.ID.ToString();
                            tb_catName.Text = c.Name;
                            tb_catDescription.Text = c.Description;
                            tb_whoCat.Text = c.Employee.Name;
                            check_CatActive.Checked = c.IsActive;
                        }
                    }
                    else
                    {
                        MessageBox.Show("row index out of range!", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }

                }
            }
            else
            {
                if (rowIndex1 != -1)
                {
                    int id = Convert.ToInt32(dataGridCategory.Rows[rowIndex1].Cells["ID"].Value);
                    Category c = db.Categories.Find(id);
                    if (c != null)
                    {
                        tb_catID.Text = c.ID.ToString();
                        tb_catName.Text = c.Name;
                        tb_catDescription.Text = c.Description;
                        tb_whoCat.Text = c.Employee.Name;
                        check_CatActive.Checked = c.IsActive;
                    }
                }
            }
        }

        private void tsmi_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen kategoriyi silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (rowIndex1 != -1)
                {
                    int id = Convert.ToInt32(dataGridCategory.Rows[rowIndex1].Cells["ID"].Value);
                    if (dm.CanDeleteCategory(id))
                    {
                        Category c = db.Categories.Find(id);
                        if (c != null)
                        {
                            try
                            {
                                c.IsActive = false;
                                c.IsDeleted = true;
                                db.SaveChanges();
                                MessageBox.Show("Kategori başarıyla silindi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                dm.LoadCategories(dataGridCategory);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Kategori silinemedi.", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu kategoriye sahip aktif ürün mevcut olduğu için silinemedi. Detaylı bilgi için yardım sekmesine göz atın.", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void tsmi_edit2_Click(object sender, EventArgs e)
        {
            if (tb_brandName.Text != "" && tb_brandID.Text != "")
            {
                if (MessageBox.Show("Ekranda kaydedilmeyen veri varsa silinecek, emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (rowIndex2 != -1)
                    {
                        int id = Convert.ToInt32(dataGridBrand.Rows[rowIndex2].Cells["ID"].Value);
                        Brand c = db.Brands.Find(id);
                        if (c != null)
                        {
                            tb_brandID.Text = c.ID.ToString();
                            tb_brandName.Text = c.Name;
                            tb_whoBrand.Text = c.Employee.Name;
                            check_brandActive.Checked = c.IsActive;
                        }
                    }
                    else
                    {
                        MessageBox.Show("row index out of range!", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }

                }
            }
            else
            {
                if (rowIndex2 != -1)
                {
                    int id = Convert.ToInt32(dataGridBrand.Rows[rowIndex2].Cells["ID"].Value);
                    Brand c = db.Brands.Find(id);
                    if (c != null)
                    {
                        tb_brandID.Text = c.ID.ToString();
                        tb_brandName.Text = c.Name;
                        tb_whoBrand.Text = c.Employee.Name;
                        check_brandActive.Checked = c.IsActive;
                    }
                }
            }
        }

        private void tsmi_delete2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen markayı silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (rowIndex2 != -1)
                {
                    int id = Convert.ToInt32(dataGridBrand.Rows[rowIndex2].Cells["ID"].Value);
                    if (dm.CanDeleteBrand(id))
                    {
                        Brand c = db.Brands.Find(id);
                        if (c != null)
                        {
                            try
                            {
                                c.IsActive = false;
                                c.IsDeleted = true;
                                db.SaveChanges();
                                MessageBox.Show("Marka başarıyla silindi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                dm.LoadBrands(dataGridBrand);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Marka silinemedi.", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu markaya sahip aktif ürün mevcut olduğu için silinemedi. Detaylı bilgi için yardım sekmesine göz atın.", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }
    }
}
