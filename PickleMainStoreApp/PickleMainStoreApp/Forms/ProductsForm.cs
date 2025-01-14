using PickleMainStoreApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PickleMainStoreApp.Models.GeneralDataModel;
using static PickleMainStoreApp.Models.ViewModels;

namespace PickleMainStoreApp.Forms
{
    public partial class ProductsForm : Form
    {
        GeneralDataModel dm = new GeneralDataModel();
        ProductViewModel vm = new ProductViewModel();
        PickleStoreModel db = new PickleStoreModel();
        public Employee _user;
        int rowIndex = -1;

        public ProductsForm(Employee user)
        {
            InitializeComponent();
            _user = user;
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            #region Brand Listing
            List<Brand> brands = db.Brands.Where(b => b.IsActive == true).ToList();
            cb_brand.DataSource = brands;
            cb_brand.DisplayMember = "Name";
            cb_brand.ValueMember = "ID";
            #endregion
            #region Category Listing
            List<Category> categories = db.Categories.Where(c => c.IsActive == true).ToList();
            cb_category.DataSource = categories;
            cb_category.DisplayMember = "Name";
            cb_category.ValueMember = "ID";
            #endregion

            dm.LoadProducts(dataGridView1);
        }
        
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tb_id.Text == "")
            {
                if (string.IsNullOrWhiteSpace(tb_barcode.Text) || string.IsNullOrWhiteSpace(tb_name.Text) ||
                string.IsNullOrWhiteSpace(tb_description.Text) || string.IsNullOrWhiteSpace(tb_price.Text) ||
                string.IsNullOrWhiteSpace(tb_stock.Text) || string.IsNullOrWhiteSpace(tb_reorder.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Product p = new Product();

                if (cb_category.SelectedItem != null)
                {
                    int selectedCategoryId = (int)cb_category.SelectedValue;
                    p.Category = db.Categories.Find(selectedCategoryId);
                    p.Category_ID = selectedCategoryId;
                }
                else
                {
                    MessageBox.Show("Lütfen bir kategori seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cb_brand.SelectedItem != null)
                {
                    int selectedBrandId = (int)cb_brand.SelectedValue;
                    p.Brand = db.Brands.Find(selectedBrandId);
                    p.Brand_ID = selectedBrandId;
                }
                else
                {
                    MessageBox.Show("Lütfen bir marka seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                p.Employee_ID = _user.ID;
                p.Employee = db.Employees.Find(_user.ID);
                p.Barcode = tb_barcode.Text;
                p.ProductName = tb_name.Text;
                p.Description = tb_description.Text;
                p.Price = Convert.ToDouble(tb_price.Text);
                p.Stock = Convert.ToInt16(tb_stock.Text);
                p.ReorderLevel = Convert.ToInt16(tb_reorder.Text);
                p.CreationTime = DateTime.Now;

                if (check_isActive.Checked)
                {
                    p.IsActive = true;
                }

                db.Products.Add(p);
                try
                {
                    db.SaveChanges();
                    MessageBox.Show("Ürün başarıyla eklendi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dm.LoadProducts(dataGridView1);
                    dm.XMLCatalogUpdate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün eklenemedi: " + ex.Message, "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(tb_barcode.Text) || string.IsNullOrWhiteSpace(tb_name.Text) ||
                string.IsNullOrWhiteSpace(tb_description.Text) || string.IsNullOrWhiteSpace(tb_price.Text) ||
                string.IsNullOrWhiteSpace(tb_stock.Text) || string.IsNullOrWhiteSpace(tb_reorder.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurduğunuzdan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    int id = Convert.ToInt32(tb_id.Text);
                    Product p = db.Products.Find(id);
                    Employee em = db.Employees.Find(_user.ID);
                    if (p != null)
                    {
                        p.Barcode = tb_barcode.Text;
                        p.ProductName = tb_name.Text;
                        p.Description = tb_description.Text;
                        p.Price = Convert.ToDouble(tb_price.Text);
                        p.Stock = Convert.ToInt16(tb_stock.Text);
                        p.ReorderLevel = Convert.ToInt16(tb_reorder.Text);
                        if (cb_category.SelectedItem != null)
                        {
                            Category c = db.Categories.Find((int)cb_category.SelectedValue);
                            p.Category_ID = c.ID;

                        }
                        else
                        {
                            p.Category = null;
                        }
                        if (cb_brand.SelectedItem != null)
                        {
                            Brand b = db.Brands.Find((int)cb_brand.SelectedValue);
                            p.Brand_ID = b.ID;
                        }
                        else
                        {
                            p.Brand = null;
                        }
                        p.Employee_ID = em.ID;
                        p.IsActive = check_isActive.Checked;
                        if (p.IsActive)
                        {
                            p.IsDeleted = false;
                        }
                        try
                        {
                            db.SaveChanges();
                            MessageBox.Show("Düzenleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            dm.LoadProducts(dataGridView1);
                            dm.XMLCatalogUpdate();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Düzenleme işlemi başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ekranı temizlemek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dm.ClearAllControls(this);
            }
        }

        private void tsmi_edit_Click(object sender, EventArgs e)
        {
            if (tb_id.Text != "" && tb_barcode.Text != "" && tb_name.Text != "" && tb_description.Text != "")
            {
                if (MessageBox.Show("Ekranda kaydedilmeyen veri varsa silinecek, emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (rowIndex != -1)
                    {
                        int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                        Product p = db.Products.Find(id);
                        if (p != null)
                        {
                            tb_id.Text = p.ID.ToString();
                            tb_name.Text = p.ProductName;
                            tb_barcode.Text = p.Barcode;
                            tb_description.Text = p.Description;
                            tb_price.Text = p.Price.ToString();
                            tb_stock.Text = p.Stock.ToString();
                            tb_reorder.Text = p.ReorderLevel.ToString();
                            if (p.Category==null)
                            {
                                cb_category = null;
                            }
                            else
                            {
                                cb_category.SelectedValue = p.Category_ID;
                            } 

                            if (p.Brand == null)
                            {
                                cb_brand = null;
                            }
                            else
                            {
                                cb_brand.SelectedValue = p.Brand_ID;
                            }
                            tb_whosaved.Text = p.Employee.Username;
                            check_isActive.Checked = p.IsActive;
                        }
                    }

                }
            }
            else
            {

                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Product p = db.Products.Find(id);
                    if (p != null)
                    {
                        tb_id.Text = p.ID.ToString();
                        tb_name.Text = p.ProductName;
                        tb_barcode.Text = p.Barcode;
                        tb_description.Text = p.Description;
                        tb_price.Text = p.Price.ToString();
                        tb_stock.Text = p.Stock.ToString();
                        tb_reorder.Text = p.ReorderLevel.ToString();
                        cb_category.SelectedValue = p.Category_ID;
                        cb_brand.SelectedValue = p.Brand_ID;
                        tb_whosaved.Text = p.Employee.Username;
                        check_isActive.Checked = p.IsActive;
                    }
                }
            }

        }

        private void tsmi_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçilen ürünü silmek istediğinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (rowIndex != -1)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["ID"].Value);
                    Product p = db.Products.Find(id);
                    if (p != null)
                    {
                        try
                        {
                            p.IsDeleted = true;
                            p.IsActive = false;
                            db.SaveChanges();
                            MessageBox.Show("Ürün başarıyla silindi", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            dm.LoadProducts(dataGridView1);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ürün silinemedi.", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                    }
                }
            }
        }

        private void ProductsForm_Activated(object sender, EventArgs e)
        {
            #region Brand Listing
            List<Brand> brands = db.Brands.Where(b => b.IsActive == true).ToList();
            cb_brand.DataSource = brands;
            cb_brand.DisplayMember = "Name";
            cb_brand.ValueMember = "ID";
            #endregion
            #region Category Listing
            List<Category> categories = db.Categories.Where(c => c.IsActive == true).ToList();
            cb_category.DataSource = categories;
            cb_category.DisplayMember = "Name";
            cb_category.ValueMember = "ID";
            #endregion

            dm.LoadProducts(dataGridView1);
        }

    }

}




