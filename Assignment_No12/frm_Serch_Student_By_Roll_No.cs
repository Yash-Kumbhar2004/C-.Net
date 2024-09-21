using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Assignment_No2
{
    public partial class frm_Serch_Student_By_Roll_No : Form
    {
        public frm_Serch_Student_By_Roll_No()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=LAPTOP-O5QJ9TA1;Initial Catalog=Assginment.DBO;Integrated Security=True");
        void Con_Open()
        {
            if (Con.State != ConnectionState.Open)
            {
                Con.Open();
            }
        }

        void Con_Close()
        {
            if (Con.State != ConnectionState.Closed)
            {
                Con.Close();
            }
        }
        private void Only_Numeric(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        void Clear_Fields()
        {
            tb_Roll_No.Clear();
            tb_Name.Clear();
            tb_Mobile_No.Clear();
            dtp_DOB.Text = "01-06-2007";
            cmb_Course.SelectedIndex = -1;
        }
        private void frm_Serch_Student_By_Roll_No_Load(object sender, EventArgs e)
        {
            lbl_Username.Text = "Welcome " + Shared_Content.Uname;
        }

        private void btn_Add_New_Student_Click(object sender, EventArgs e)
        {
            frm_Add_New_Student obj = new frm_Add_New_Student();
            obj.Show();
            this.Hide();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Con_Open();

            SqlCommand Cmd = new SqlCommand();

            Cmd.Connection = Con;
            Cmd.CommandText = "Select * From Student_Details Where Roll_No = @RNo";

            Cmd.Parameters.Add("RNo", SqlDbType.Int).Value = tb_Roll_No.Text;

            SqlDataReader Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                tb_Name.Text = Dr.GetString(Dr.GetOrdinal("Name"));
                tb_Mobile_No.Text = (Dr["Mobile_No"].ToString());
                dtp_DOB.Text = (Dr["DOB"].ToString());
                cmb_Course.Text = Dr.GetString(Dr.GetOrdinal("Course"));
            }
            else
            {
                MessageBox.Show("Invalid Roll Number", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Con_Close();
        }

        private void btn_View_All_Students_List_Click(object sender, EventArgs e)
        {
            frm_Student_List obj = new frm_Student_List();
            obj.Show();
            this.Hide();
        }

        private void btn_log_out_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure want to Logout", "Warning", MessageBoxButtons.YesNo);
            frm_Login_Form obj = new frm_Login_Form();
            obj.Show();
            this.Hide();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Clear_Fields();
        }

        private void tb_Roll_No_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
