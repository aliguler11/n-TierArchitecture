using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpegitim.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        Guide guide = new Guide();

        private void button1_Click(object sender, EventArgs e)
        {
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removeValue = db.Guide.Find(id);
            db.Guide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("rehber basarıyla silindi");


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            guide.GuideName = txtName.Text;
            guide.GuideSurname= txtSurname.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("rehber basarıyla eklendi");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.Guide.Find(id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("rehber güncellendi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var getById = db.Guide.Where(a=> a.GuideId==id).ToList();
            dataGridView1.DataSource = getById;


        }
    }
}
