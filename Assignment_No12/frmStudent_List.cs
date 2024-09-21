using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_No2
{
    public partial class frm_Student_List : Form
    {
        public frm_Student_List()
        {
            InitializeComponent();
        }

        private void lbl_Student_List_Click(object sender, EventArgs e)
        {

        }

        private void btn_Search_Student_Click(object sender, EventArgs e)
        {
            frm_Serch_Student_By_Roll_No obj = new frm_Serch_Student_By_Roll_No();
            obj.Show();
            this.Hide();
        }

        private void btn_Add_New_Student_Click(object sender, EventArgs e)
        {
            frm_Add_New_Student obj = new frm_Add_New_Student();
            obj.Show();
            this.Hide();
        }

        private void btn_Log_Out_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure want to Logout", "Warning", MessageBoxButtons.YesNo);
            frm_Login_Form obj = new frm_Login_Form();
            obj.Show();
            this.Hide();
        }

        private void lbl_Username_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_Student_List_Load(object sender, EventArgs e)
        {
            lbl_Username.Text = "Welcome " + Shared_Content.Uname;
            // TODO: This line of code loads data into the '_Assginment_DBODataSet.Student_Details' table. You can move, or remove it, as needed.
            this.student_DetailsTableAdapter.Fill(this._Assginment_DBODataSet.Student_Details);

        }
    }
}
