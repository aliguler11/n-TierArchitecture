using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpegitim.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        Location location = new Location();
        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x => new
            {
                Fullname = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }
            ).ToList();
            cmbGuide.DisplayMember = "Fullname";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location.Select(x => new
            {
                x.LocationId,       
                x.City,            
                x.Country,        
                x.Capacity,        
                x.Price,           
                x.DayNight,         
                x.GuideId,          
                RehberAdSoyad = x.Guide.GuideName + " " + x.Guide.GuideSurname
            }).ToList();

            dataGridView1.DataSource = values; 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            location.Capacity = byte.Parse(nudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDate.Text;
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var removedValue = db.Location.Find(id);
            db.Location.Remove(removedValue);
            db.SaveChanges();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedValue = db.Location.Find(id);
            updatedValue.City = txtCity.Text;
            updatedValue.Country = txtCountry.Text;
            updatedValue.Price = decimal.Parse(txtPrice.Text);
            updatedValue.DayNight = txtDate.Text;
            updatedValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updatedValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCity.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCountry.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDate.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                nudCapacity.Value = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                cmbGuide.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[6].Value;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

      


        }
    }
}
