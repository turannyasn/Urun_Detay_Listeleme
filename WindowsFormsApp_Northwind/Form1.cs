using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp_Northwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            cmbkategori.SelectedIndexChanged += Cmbkategori_SelectedIndexChanged;
            cmburun.SelectedIndexChanged += Cmburun_SelectedIndexChanged;
            
        }

        private void Cmburun_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secili = 0;
            if (cmburun.SelectedIndex>0)
            {
                if (((ComboBox)sender).SelectedValue!=null)
                {
                    secili = (int)((ComboBox)sender).SelectedValue;
                    urundetaygetir(secili);
                }
                
            }

        }

        private void Cmbkategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secili = 0;
            if (cmbkategori.SelectedIndex>0)
            {
                if (((ComboBox)sender).SelectedValue!=null)
                {
                    secili= (int)((ComboBox)sender).SelectedValue;
                    urungetir(secili);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kategori_doldur();
            
        }

        SqlConnection con = new SqlConnection(database.database.GetConnectionString);

        SqlCommand cmd;

        public void kategori_doldur()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT CategoryID, CategoryName FROM Categories", con);

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                   

                }
                dt.Load(cmd.ExecuteReader());
                cmbkategori.DataSource = dt;
                cmbkategori.DisplayMember = "CategoryName";
                cmbkategori.ValueMember = "CategoryID";
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                if (con.State!=ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public void urungetir(int id)
        {
            DataTable dt = new DataTable("Products");
            cmd = new SqlCommand("SELECT ProductID,ProductName from Products where CategoryID=" + id,con);

            try
            {
                if (con.State != ConnectionState.Open) 
                {
                    con.Open();
                }
                dt.Load(cmd.ExecuteReader());
                cmburun.DataSource= dt;
                cmburun.DisplayMember = "ProductName";
                cmburun.ValueMember = "ProductID";

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void urundetaygetir(int urunid)
        {
            string query = "select ProductID,ProductName,UnitPrice,UnitsInStock from Products where ProductID=@urunid";
            DataTable dt = new DataTable("Productsdetails");
            cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@urunid",urunid);

            try
            {
                if (con.State!=ConnectionState.Open)
                {
                    con.Open();
                }
                dt.Load(cmd.ExecuteReader());
                label8_no.Text = dt.Rows[0]["ProductID"].ToString();
                label9_ad.Text = dt.Rows[0]["ProductName"].ToString();
                label10_fyt.Text = dt.Rows[0]["UnitPrice"].ToString();
                label11_adet.Text = dt.Rows[0]["UnitsInStock"].ToString();
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
