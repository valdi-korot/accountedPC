using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Godun
{
    public partial class PCForm : Form
    {
        Model db=new Model();
        private int Org_Id;
        public PCForm()
        {
            InitializeComponent();
        }

        public PCForm(int org_id)
        {
            Org_Id = org_id;
            InitializeComponent();
            db.Organisations.Load();
            var list= db.PCs.Where(p => p.Org_Id == Org_Id).ToList();
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addPC form=new addPC();
            if(form.ShowDialog()==DialogResult.OK)
            {
                PCs row = new PCs()
                {
                    Name = form.textBox1.Text,
                    CPU = form.textBox2.Text,
                    RAM = form.textBox3.Text,
                    OZU = form.textBox4.Text,
                    HDD = form.textBox5.Text,
                    User = form.textBox6.Text,
                    OS = form.textBox7.Text,
                    IP = form.textBox8.Text,
                    MothersPlate = form.textBox9.Text,
                    Org_Id = Org_Id
                };
                db.PCs.Add(row);
                db.SaveChanges();
                dataGridView1.DataSource = db.PCs.Local.ToBindingList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index =  dataGridView1.SelectedRows[0].Index;
            int id = (int)dataGridView1[0, index].Value;
            PCs row = db.PCs.Find(id);
            addPC form = new addPC();
            form.textBox1.Text = row.Name;
            form.textBox2.Text = row.CPU;
            form.textBox3.Text = row.RAM;
            form.textBox4.Text = row.OZU;
            form.textBox5.Text = row.HDD;
            form.textBox6.Text = row.User;
            form.textBox7.Text = row.OS;
            form.textBox8.Text = row.IP;
            form.textBox9.Text = row.MothersPlate;
            if (form.ShowDialog() == DialogResult.OK)
            {

                row.Name = form.textBox1.Text;
                row.CPU = form.textBox2.Text;
                row.RAM = form.textBox3.Text;
                row.OZU = form.textBox4.Text;
                row.HDD = form.textBox5.Text;
                row.User = form.textBox6.Text;
                row.OS = form.textBox7.Text;
                row.IP = form.textBox8.Text;
                row.MothersPlate = form.textBox9.Text;
                row.Org_Id = Org_Id;
                db.Entry(row).State=EntityState.Modified;
                db.SaveChanges();
                db.Organisations.Load();
                dataGridView1.DataSource = db.PCs.Local.ToBindingList();
                dataGridView1.Update();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            int id = (int)dataGridView1[0, index].Value;
            PCs row = db.PCs.Find(id);
            if (MessageBox.Show("Вы действительно хотите удалить ?", "Удаление", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                db.PCs.Remove(row);
                db.SaveChanges();
                dataGridView1.DataSource = db.PCs.Local.ToBindingList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id;
            if(int.TryParse(textBox1.Text,out id))
            {
                var list = db.PCs.Where(p => p.Id == id);
                dataGridView1.DataSource = list.ToList();
            }
        else
            {
                dataGridView1.DataSource = db.PCs.ToList();
            }
        }
    }
}
