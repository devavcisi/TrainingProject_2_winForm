using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kk
{
    public partial class Form1 : Form
    {
        DBTalepFormEntities db = new DBTalepFormEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.DenemeUser.ToList();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DenemeUser du = new DenemeUser();

            du.Ad = isim.Text;
            du.Soyad = soyad.Text;
            du.Yaş=yas.Text;
            du.Telno=telno.Text;
            du.Adres=adres.Text;
            db.DenemeUser.Add(du);
            db.SaveChanges();
            dataGridView1.DataSource= db.DenemeUser.ToList();

           }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void güncelle_Click(object sender, EventArgs e)
        {
            int id= int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            DenemeUser du = db.DenemeUser.FirstOrDefault(x=>x.ID==id);
            du.Ad = isim.Text;
            du.Soyad = soyad.Text;
            du.Yaş = yas.Text;
            du.Telno = telno.Text;
            du.Adres = adres.Text;
            db.SaveChanges();
            dataGridView1.DataSource = db.DenemeUser.ToList();

        }

       

      

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            isim.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            soyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void sil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DenemeUser du = db.DenemeUser.FirstOrDefault(x=>x.ID==id);
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show($@"{du.Ad}  {du.Soyad}    Personeli Silinecek 
Personeli Kalıcı Olarak Silmek İstediğinize  eminmisiniz ? ", "Kalıcı Olarak Silinecek", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.DenemeUser.Remove(du);
                db.SaveChanges();
                dataGridView1.DataSource = db.DenemeUser.ToList();
                isim.Text = soyad.Text = null;
            }

            
        }
    }
}
