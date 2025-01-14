using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickleMainStoreApp.Models;
using System.Data.Entity;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static PickleMainStoreApp.Models.ViewModels;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Xml;

namespace PickleMainStoreApp.Models
{
    public class GeneralDataModel
    {
        PickleStoreModel db = new PickleStoreModel();
        //using System.Data.Entity eklenmezse lambda hata veriyor...
        public void LoadProducts(System.Windows.Forms.DataGridView dataGridView)
        {
            using (var context = new PickleStoreModel())
            {
                var products = context.Products.Include(p => p.Category).Include(p => p.Employee).Include(p => p.Brand).Select(p => new ProductViewModel()
                {
                    ID = p.ID,
                    CategoryName = p.Category.Name,
                    Name = p.ProductName,
                    Barcode = p.Barcode,
                    EmployeeName = p.Employee.Username,
                    BrandName = p.Brand.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    ReorderLevel = p.ReorderLevel,
                    CreationTime = p.CreationTime,
                    IsActive = p.IsActive,
                    IsDeleted = p.IsDeleted
                }).ToList();
                products = products.OrderBy(p => p.IsDeleted).ToList();
                dataGridView.DataSource = products;
                dataGridView.Columns["Name"].HeaderText = "Ürün Adı";
                dataGridView.Columns["CategoryName"].HeaderText = "Kategori Adı";
                dataGridView.Columns["EmployeeName"].HeaderText = "Ekleyen Kişi";
                dataGridView.Columns["BrandName"].HeaderText = "Marka";
                dataGridView.Columns["Barcode"].HeaderText = "Barkod";
                dataGridView.Columns["Description"].HeaderText = "Açıklama";
                dataGridView.Columns["Price"].HeaderText = "Fiyat";
                dataGridView.Columns["Stock"].HeaderText = "Stok";
                dataGridView.Columns["ReorderLevel"].HeaderText = "Güvenlik Stoğu";
                dataGridView.Columns["IsActive"].HeaderText = "Satış Durumu";
                dataGridView.Columns["IsDeleted"].HeaderText = "Silindi";
            }

        }
        public void LoadCategories(System.Windows.Forms.DataGridView dataGridView)
        {
            using (var db = new PickleStoreModel())
            {
                var categories = db.Categories.Include(c => c.Employee).Select(c => new CategoryViewModel()
                {
                    ID = c.ID,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    IsDeleted = c.IsDeleted,
                    Employee = c.Employee.Username,
                }).ToList();
                categories = categories.OrderBy(c => c.IsDeleted).ToList();
                dataGridView.DataSource = categories;
                dataGridView.Columns["ID"].HeaderText = "ID";
                dataGridView.Columns["Name"].HeaderText = "Kategori Adı";
                dataGridView.Columns["Description"].HeaderText = "Açıklama";
                dataGridView.Columns["IsActive"].HeaderText = "Aktiflik Durumu";
                dataGridView.Columns["IsDeleted"].HeaderText = "Silindi";
                dataGridView.Columns["Employee"].HeaderText = "Ekleyen Kişi";
            }

        }
        public void LoadBrands(System.Windows.Forms.DataGridView dataGridView)
        {
            using (var db = new PickleStoreModel())
            {
                var brands = db.Brands.Include(e => e.Employee).Select(e => new BrandViewModel()
                {
                    ID = e.ID,
                    Name = e.Name,
                    IsActive = e.IsActive,
                    IsDeleted = e.IsDeleted,
                    Employee = e.Employee.Username,
                }).ToList();
                brands = brands.OrderBy(b => b.IsDeleted).ToList();
                dataGridView.DataSource = brands;
                dataGridView.Columns["ID"].HeaderText = "ID";
                dataGridView.Columns["Name"].HeaderText = "Marka Adı";
                dataGridView.Columns["IsActive"].HeaderText = "Aktiflik Durumu";
                dataGridView.Columns["IsDeleted"].HeaderText = "Silindi";
                dataGridView.Columns["Employee"].HeaderText = "Ekleyen Kişi";
            }
        }
        public void LoadSales(System.Windows.Forms.DataGridView dataGridView)
        {
            using (var db = new PickleStoreModel())
            {
                var sales = db.Sales.Include(s => s.Employee).Include(s => s.Customer).Include(s => s.Product).Select(s => new SaleViewModel()
                {
                    ID = s.ID,
                    ProductName = s.Product.ProductName,
                    ProductBarcode = s.Product.Barcode,
                    Brand = s.Product.Brand.Name,
                    Price = s.Price,
                    Quantity = s.Quantity,
                    Total = s.TotalPrice,
                    SaleTime = s.SaleTime,
                    Costumer = s.Customer.Name,
                    EmployeeName = s.Employee.Name,
                    IsActive = s.IsActive,
                    IsDeleted = s.IsDeleted,
                    Discount = s.Customer.Type.Discount * 100

                }).ToList();
                sales = sales.OrderBy(s => s.IsDeleted).ToList();
                dataGridView.DataSource = sales;
                dataGridView.Columns["ID"].HeaderText = "Satış Kodu";
                dataGridView.Columns["ProductName"].HeaderText = "Ürün Adı";
                dataGridView.Columns["ProductBarcode"].HeaderText = "Ürün Barkodu";
                dataGridView.Columns["Brand"].HeaderText = "Marka";
                dataGridView.Columns["Price"].HeaderText = "Fiyat";
                dataGridView.Columns["Quantity"].HeaderText = "Adet";
                dataGridView.Columns["Total"].HeaderText = "Toplam Tutar";
                dataGridView.Columns["SaleTime"].HeaderText = "Satış Tarihi";
                dataGridView.Columns["Costumer"].HeaderText = "Alan Bayi Adı";
                dataGridView.Columns["EmployeeName"].HeaderText = "Satışı Düzenleyen";
                dataGridView.Columns["IsActive"].HeaderText = "Onay Durumu";
                dataGridView.Columns["IsDeleted"].HeaderText = "Silindi";
                dataGridView.Columns["Discount"].HeaderText = "İndirim Oranı(%)";

            }
        }
        public void LoadPurchases(System.Windows.Forms.DataGridView dataGridView)
        {
            using (var db = new PickleStoreModel())
            {
                var purchases = db.Purchases.Include(p => p.Employee).Include(p => p.Supplier).Include(p => p.Product).Select(p => new PurchaseViewModel()
                {
                    ID = p.ID,
                    ProductName = p.Product.ProductName,
                    ProductBarcode = p.Product.Barcode,
                    Brand = p.Product.Brand.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Total = p.TotalPrice,
                    PurchaseTime = p.PurchaseTime,
                    Supplier = p.Supplier.CompanyName,
                    EmployeeName = p.Employee.Username,
                    IsActive = p.IsActive,
                    IsDeleted = p.IsDeleted

                }).ToList();
                dataGridView.DataSource = purchases.OrderBy(p => p.IsDeleted).ToList();
                dataGridView.Columns["ID"].HeaderText = "Alış Kodu";
                dataGridView.Columns["ProductName"].HeaderText = "Ürün Adı";
                dataGridView.Columns["ProductBarcode"].HeaderText = "Ürün Barkodu";
                dataGridView.Columns["Brand"].HeaderText = "Marka";
                dataGridView.Columns["Price"].HeaderText = "Fiyat";
                dataGridView.Columns["Quantity"].HeaderText = "Adet";
                dataGridView.Columns["Total"].HeaderText = "Toplam Tutar";
                dataGridView.Columns["PurchaseTime"].HeaderText = "Alış Tarihi";
                dataGridView.Columns["Supplier"].HeaderText = "Alınan Tedarikçi";
                dataGridView.Columns["EmployeeName"].HeaderText = "Alımı Düzenleyen";
                dataGridView.Columns["IsActive"].HeaderText = "Onay Durumu";
                dataGridView.Columns["IsDeleted"].HeaderText = "Silindi";
            }
        }
        public void LoadSuppliers(DataGridView dataGridView)
        {
            using (var db = new PickleStoreModel())
            {
                var suppliers = db.Suppliers.Include(s => s.Employee).Select(s => new SupplierViewModel()
                {
                    ID = s.ID,
                    CompName = s.CompanyName,
                    ContactName = s.ContactName,
                    Address = s.Adress,
                    Phone = s.Phone,
                    Mail = s.ContactMail,
                    SaveTime = s.SaveTime,
                    EmployeeName = s.Employee.Username,
                    IsActive = s.IsActive,
                    IsDeleted = s.IsDeleted
                }).ToList();
                dataGridView.DataSource = suppliers.OrderBy(s => s.IsDeleted).ToList();
                dataGridView.Columns["ID"].HeaderText = "Şirket Kodu";
                dataGridView.Columns["CompName"].HeaderText = "Şirket Adı";
                dataGridView.Columns["ContactName"].HeaderText = "Bağlantı Adı";
                dataGridView.Columns["Address"].HeaderText = "Adres";
                dataGridView.Columns["Phone"].HeaderText = "Telefon";
                dataGridView.Columns["Mail"].HeaderText = "Mail";
                dataGridView.Columns["SaveTime"].HeaderText = "Eklenme Tarihi";
                dataGridView.Columns["EmployeeName"].HeaderText = "Ekleyen";
                dataGridView.Columns["IsActive"].HeaderText = "Aktiflik";
                dataGridView.Columns["IsDeleted"].HeaderText = "Silindi";

            }
        }
        public void LoadCustomers(DataGridView dataGridView)
        {
            using (var db = new PickleStoreModel())
            {
                var suppliers = db.Customers.Include(s => s.Employee).Include(s => s.Type).Select(s => new CustomerViewModel()
                {
                    ID = s.ID,
                    Name = s.Name,
                    Surname = s.Surname,
                    Address = s.Adress,
                    Phone = s.Phone,
                    Mail = s.Mail,
                    Type = s.Type.TypeName,
                    Discount=s.Type.Discount*100,
                    CreationTime = s.CreationTime,
                    EmployeeName = s.Employee.Username,
                    IsActive = s.IsActive,
                    IsDeleted = s.IsDeleted

                }).ToList();
                dataGridView.DataSource = suppliers.OrderBy(s => s.IsDeleted).ToList();
                dataGridView.Columns["ID"].HeaderText = "Müşteri Kodu";
                dataGridView.Columns["Name"].HeaderText = "Ad";
                dataGridView.Columns["Surname"].HeaderText = "Soyad";
                dataGridView.Columns["Address"].HeaderText = "Adres";
                dataGridView.Columns["Phone"].HeaderText = "Telefon";
                dataGridView.Columns["Discount"].HeaderText = "İndirim Oranı";
                dataGridView.Columns["Mail"].HeaderText = "Mail";
                dataGridView.Columns["Type"].HeaderText = "Müşteri Türü";
                dataGridView.Columns["CreationTime"].HeaderText = "Eklenme Tarihi";
                dataGridView.Columns["EmployeeName"].HeaderText = "Ekleyen";
                dataGridView.Columns["IsActive"].HeaderText = "Aktiflik";
                dataGridView.Columns["IsDeleted"].HeaderText = "Silindi";

            }
        }
        public void LoadEmployees(DataGridView dataGridView)
        {
            
            using (var db = new PickleStoreModel())
            {
                var employees = db.Employees.Select(s => new EmployeeViewModel()
                {
                    ID = s.ID,
                    Username = s.Username,
                    Name = s.Name,
                    Surname = s.Surname,
                    Phone = s.Phone,
                    Mail = s.Mail,
                    Password = s.Password,
                    Type = s.Type,
                    CreationTime = s.CreationTime,
                    LastLoginTime = s.LastLoginTime,
                    IsActive = s.IsActive,
                    IsDeleted = s.IsDeleted

                }).ToList();
                dataGridView.DataSource = employees.OrderBy(s => s.IsDeleted).ToList();
                dataGridView.Columns["ID"].HeaderText = "Çalışan Kodu";
                dataGridView.Columns["Name"].HeaderText = "Ad";
                dataGridView.Columns["Surname"].HeaderText = "Soyad";
                dataGridView.Columns["Phone"].HeaderText = "Telefon";
                dataGridView.Columns["Mail"].HeaderText = "Mail";
                dataGridView.Columns["Type"].HeaderText = "Çalışan Türü";
                dataGridView.Columns["CreationTime"].HeaderText = "Kayıt Tarihi";
                dataGridView.Columns["IsActive"].HeaderText = "Aktiflik";
                dataGridView.Columns["LastLoginTime"].HeaderText = "Son giriş Tarihi";
                dataGridView.Columns["IsActive"].HeaderText = "Aktif";
                dataGridView.Columns["IsDeleted"].HeaderText = "Silindi";
                dataGridView.Columns["Username"].HeaderText = "Kullanıcı Adı";
                dataGridView.Columns["Password"].HeaderText = "Şifre";
            }
        }
        public void LoadTypes(DataGridView dataGridView)
        {
            using (var db = new PickleStoreModel())
            {
                var types = db.Types.Select(t => new TypesViewModel()
                {
                    ID = t.ID,
                    TypeName=t.TypeName,
                    Discount=t.Discount*100,
                    IsActive=t.IsActive,
                    IsDeleted=t.IsDeleted,

                }).ToList();
                dataGridView.DataSource = types.OrderBy(t => t.IsDeleted).ToList();
                dataGridView.Columns["ID"].HeaderText = "Tür Kodu";
                dataGridView.Columns["TypeName"].HeaderText = "Tür";
                dataGridView.Columns["Discount"].HeaderText = "İndirim Yüzdesi";
                dataGridView.Columns["IsActive"].HeaderText = "Aktif";
                dataGridView.Columns["IsDeleted"].HeaderText = "Silindi";
            }
        }
        private void ClearAllControlsIn(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
                else if (item is NumericUpDown)
                {
                    ((NumericUpDown)item).Value = 0;
                }
                else if (item is MaskedTextBox)
                {
                    ((MaskedTextBox)item).Clear();
                }
                else if (item is CheckBox)
                {
                    ((CheckBox)item).Checked = false;
                }

                // Alt kontrolleri temizlemek için recursive çağrı yapıyoruz
                if (item.Controls.Count > 0)
                {
                    ClearAllControlsIn(item);
                }
            }
        }
        public void ClearAllControls(Control control)
        {
            if (MessageBox.Show("Ekranda kaydedilmeyen veri varsa silinecek, emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ClearAllControlsIn(control);
            }
            
        }
        public void UpdateComboBoxes(Control control)
        {
            foreach (Control item in control.Controls)
            {
                if (item is ComboBox)
                {
                    ((ComboBox)item).Update();
                }
            }
        }
        public bool CanDeleteCategory(int categoryId)
        {
            using (var db = new PickleStoreModel())
            {
                bool isCategoryInUse = db.Products.Any(p => p.Category_ID == categoryId && p.IsActive);
                return !isCategoryInUse;
            }
        }
        public bool CanDeleteBrand(int brandID)
        {
            using (var db = new PickleStoreModel())
            {
                bool isBrandInUse = db.Products.Any(p => p.Brand.ID == brandID && p.IsActive);
                return !isBrandInUse;
            }
        }
        public bool CanDeleteType(int typeID)
        {
            using (var db = new PickleStoreModel())
            {
                bool isTypeInUse = db.Customers.Any(p => p.Type.ID == typeID && p.IsActive);
                return !isTypeInUse;
            }
        }

        public void ExportSelectedRowToPdf(DataGridView dataGridView, string filePath, string headText)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Seçili satırı alma
            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

            // Türkçe karakterler için gerekli fontları ekliyoruz
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            // Font oluşturma - Normal stil
            Font fontNormal = new Font(baseFont, 10, 0);

            // Font oluşturma - Kalın stil
            Font fontBold = new Font(baseFont, 12, 1);

            Document document = new Document(PageSize.A4.Rotate()); // Yatay sayfa yönü
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
            document.Open();

            // İrsaliye başlıklarını ekleme
            Paragraph header = new Paragraph(headText, fontBold)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            document.Add(header);

            // PDF tablosunu oluştur
            int columnCount = dataGridView.Columns.Count - 2; // Son 2 sütunu hariç tutuyoruz
            PdfPTable table = new PdfPTable(columnCount);
            table.WidthPercentage = 100;

            // Sütun başlıklarını ekleme
            for (int i = 0; i < columnCount; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(dataGridView.Columns[i].HeaderText, fontNormal))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                table.AddCell(cell);
            }

            // Seçili satırdaki verileri tabloya ekleme
            for (int i = 0; i < columnCount; i++)
            {
                table.AddCell(new Phrase(selectedRow.Cells[i].Value?.ToString() ?? string.Empty, fontNormal));
            }

            document.Add(table);
            document.Close();
        }
        public void SaveSelectedRowPdf(DataGridView dataGridView, string headText)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.Title = "PDF Dosyasını Kaydet";
                saveFileDialog.FileName = "Irsaliye.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    ExportSelectedRowToPdf(dataGridView, filePath, headText);
                    MessageBox.Show($"İrsaliye PDF dosyası başarıyla kaydedildi: {filePath}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void XMLCatalogUpdate()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Catalog.xml");


            if (true)
            {
                using (XmlWriter writer = XmlWriter.Create(path))
                {
                    try
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("ProductCatalog");
                        foreach (var product in db.Products.Where(p => p.IsActive == true).ToList())
                        {
                            writer.WriteStartElement("Product");
                            writer.WriteElementString("Name", product.ProductName.ToString());
                            writer.WriteElementString("Barcode", product.Barcode.ToString());
                            writer.WriteElementString("Brand", product.Brand.Name);
                            writer.WriteElementString("Category", product.Category.Name.ToString());
                            writer.WriteElementString("Price", product.Price.ToString());
                            writer.WriteElementString("Category", product.Category.Name.ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        MessageBox.Show("Katalog güncelleme işlemi başarılı.", "İşlem Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
        }
    }
}
