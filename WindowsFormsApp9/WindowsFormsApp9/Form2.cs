using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db_csDataSet);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_csDataSet.user' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.db_csDataSet.user);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controler c = new Controler();
            bool resLog = false;
            db_csDataSet ds = db_csDataSet;
            resLog = c.checkLogin(textBox1.Text, textBox2.Text, ds);
            if (resLog)
            {
                Form1 frm1 = new Form1();
                frm1.ShowDialog();
                frm1.Activate();
                this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง", "ข้อมูลไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
