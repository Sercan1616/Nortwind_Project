using Log_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApi;

namespace Application_UI
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        NorthwindApi northwindApi = new NorthwindApi();
        private void btnListele_Click(object sender, EventArgs e)
        {

            lstUrunler.Items.AddRange(northwindApi.GetProducts().ToArray());
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                NorthwindApi northwindApi = new NorthwindApi();

                if (string.IsNullOrEmpty(txtUrunAdi.Text))
                {
                    MessageBox.Show("Ürün Adı Boş Olamaz");
                    return;
                }

                Product newproduct = new Product()
                {
                    //id=0,
                    category = null,
                    categoryId = 3,
                    name = txtUrunAdi.Text,
                    quantityPerUnit = txtBirim.Text,
                    discontinued = true,
                    reorderLevel = 0,
                    supplier = null,
                    supplierId = 2,
                    unitPrice = Convert.ToDouble(txtFiyati.Text),
                    unitsInStock = Convert.ToDouble(txtStokMiktari.Text),
                    unitsOnOrder = 0,                  

                };

                string yeniurun = northwindApi.PostProduct(newproduct);
                Log log = new Log();
                LogModel logModel = new LogModel()
                {
                   // ID = 0,
                    MODAL = "Product",
                    DESCRIPTION = "Yeni Ürün Eklendi " + " Eklenen Ürün " + newproduct.name + DateTime.Now
                };
                log.Insert(logModel);
                MessageBox.Show("Yeni Ürün Kaydı Yapıldı.");
                btnListele.PerformClick(); //buton refresh
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            NorthwindApi northwindApi = new NorthwindApi();

            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Ürün Seçiniz!");
                return;
            }

            northwindApi.DeleteProduct(Convert.ToInt32(txtId.Text));
            Log log = new Log();
            LogModel logModel = new LogModel()
            {                
                MODAL = "Product",
                DESCRIPTION = "Ürün Silindi" + " Silinen Id " + txtId.Text + " Silinme Tarihi " + DateTime.Now
            };
            log.Insert(logModel);
            MessageBox.Show("Ürün Silindi." + " Silinen Ürün " + txtUrunAdi.Text);
            btnListele.PerformClick();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                NorthwindApi northwindApi = new NorthwindApi();

                if (string.IsNullOrEmpty(txtUrunAdi.Text))
                {
                    MessageBox.Show("Ürün Adı Boş Olamaz");
                    return;
                }

                Product newproduct = new Product()
                {
                    id=Convert.ToInt32(txtId.Text),
                    category = null,
                    categoryId = 3,
                    name = txtUrunAdi.Text,
                    quantityPerUnit = txtBirim.Text,
                    discontinued = true,
                    reorderLevel = 0,
                    supplier = null,
                    supplierId = 2,
                    unitPrice = Convert.ToDouble(txtFiyati.Text),
                    unitsInStock = Convert.ToDouble(txtStokMiktari.Text),
                    unitsOnOrder = 0,

                };

                northwindApi.UpdateProduct(newproduct);
                Log log = new Log();
                LogModel logModel = new LogModel()
                {
                    MODAL = "Product",
                    DESCRIPTION = "Ürün Güncellendi" + " Güncellenen Ürün " + newproduct.name + " Güncelleme Tarihi " + DateTime.Now
                };
                log.Insert(logModel);
                MessageBox.Show("Ürün Güncellendi.");
                btnListele.PerformClick(); //buton refresh
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedIndex != -1)

            {
                Product SecilenUrun = lstUrunler.SelectedItem as Product;
                txtBirim.Text = SecilenUrun.quantityPerUnit.ToString();
                txtStokMiktari.Text = SecilenUrun.unitsInStock.ToString();
                txtUrunAdi.Text = SecilenUrun.name;
                txtFiyati.Text = Convert.ToInt32(SecilenUrun.unitPrice).ToString();
                txtId.Text = Convert.ToInt32(SecilenUrun.id).ToString();
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            NorthwindApi northwindApi = new NorthwindApi();

            if (!string.IsNullOrEmpty(txtId.Text))
            {
               
                txtUrunAdi.Text = northwindApi.GetProductsById(Convert.ToInt32(txtId.Text)); 
               
            }
           
        }
    }
}
