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
    public partial class Form1 : Form
    {
        Model db=new Model();
        public Form1()
        {
            InitializeComponent();
            db.Organisations.Load();
            comboBox1.DataSource = db.Organisations.Local.ToBindingList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Organisations row = new Organisations()
            {
                Name = OrgName.Text
            };
            db.Organisations.Add(row);
            db.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int org_id = (int) comboBox1.SelectedValue;
            PCForm form=new PCForm(org_id);
            form.ShowDialog();
        }
    }
}
