using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MobileShopMgmSys
{
    public partial class Form1 : Form
    {
        int cid = 0, sid = 0, pid = 0, sp = 0, bp = 0;
        string[] num = { "1", "2", "3", "6", "4", "5", "7", "8", "9", "0" };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel_ca.Location = new Point(panel_menu.Location.X, panel_menu.Location.Y);
            panel_cv.Location = new Point(panel_menu.Location.X, panel_menu.Location.Y);
            panel_sa.Location = new Point(panel_menu.Location.X, panel_menu.Location.Y);
            panel_sv.Location = new Point(panel_menu.Location.X, panel_menu.Location.Y);
            panel_pa.Location = new Point(panel_menu.Location.X, panel_menu.Location.Y);
            panel_pv.Location = new Point(panel_menu.Location.X, panel_menu.Location.Y);
            panel_spa.Location = new Point(panel_menu.Location.X, panel_menu.Location.Y);
            panel_spv.Location = new Point(panel_menu.Location.X, panel_menu.Location.Y);
            panel_bpa.Location = new Point(panel_menu.Location.X, panel_menu.Location.Y);
            panel_bpv.Location = new Point(panel_menu.Location.X, panel_menu.Location.Y);
        }

        private void btn_li_login_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection1.Open();

                SqlCommand cmd = new SqlCommand("select * from table_1 where username='" + tbx_li_user.Text + "' and password='" + tbx_li_pass.Text + "'", sqlConnection1);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    panel_menu.Show();
                    button_exit.Hide();
                    admin_login.Text = "Logged in with user : " + tbx_li_user.Text;
                    MessageBox.Show("Login Successfully");
                    tbx_li_user.Text = ""; tbx_li_pass.Text = "";
                    linkLabel1.Visible = false;
                    label14.Visible = false;
                }
                else
                {
                    linkLabel1.Visible = true;
                    label14.Visible = true;
                    tbx_li_user.Text = ""; tbx_li_pass.Text = "";
                }
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("You are not connected to Internet right now"+Environment.NewLine+ Environment.NewLine+"Hint : Readme.txt", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_m_lo_Click(object sender, EventArgs e)
        {
            DialogResult diares = MessageBox.Show("Are You Sure You Want To LogOut?", "LOGOUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diares == DialogResult.Yes)
            {
                panel_menu.Hide();
                panel_ca.Hide();
                panel_cv.Hide();
                panel_sa.Hide();
                panel_sv.Hide();
                panel_pa.Hide();
                panel_pv.Hide();
                panel_spa.Hide();
                panel_spv.Hide();
                panel_bpa.Hide();
                panel_bpv.Hide();
                button_exit.Show();
                admin_login.Text = "";
                MessageBox.Show("Logged Out...");
            }
            else if (diares == DialogResult.No)
            {

            }
        }

        private void btn_m_ca_Click(object sender, EventArgs e)
        {
            panel_menu.Hide();
            panel_ca.Show();

            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(custid) from cust", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cid = Convert.ToInt32(dr[0]);
                cid++;
            }
            else
            {
                cid++;
            }
            sqlConnection1.Close();
            tbx_ac_custID.Text = "CUST" + cid + System.DateTime.Today.DayOfYear + System.DateTime.Today.Year;
        }

        private void btn_m_cv_Click(object sender, EventArgs e)
        {
            panel_menu.Hide();
            panel_cv.Show();

            cbx_vc_id.Items.Clear();
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select custid from cust", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbx_vc_id.Items.Add(dr["custid"].ToString());
            }
            sqlConnection1.Close();
        }

        private void btn_m_sa_Click(object sender, EventArgs e)
        {
            panel_menu.Hide();
            panel_sa.Show();

            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(suppid) from supp", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sid = Convert.ToInt32(dr[0]);
                sid++;
            }
            else
            {
                sid++;
            }
            sqlConnection1.Close();
            tbx_as_suppID.Text = "SUPP" + sid + System.DateTime.Today.DayOfYear + System.DateTime.Today.Year;
        }

        private void btn_m_sv_Click(object sender, EventArgs e)
        {
            panel_menu.Hide();
            panel_sv.Show();

            cbx_vs_id.Items.Clear();
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select suppid from supp", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbx_vs_id.Items.Add(dr["suppid"].ToString());
            }
            sqlConnection1.Close();
        }

        private void btn_m_pa_Click(object sender, EventArgs e)
        {
            panel_menu.Hide();
            panel_pa.Show();

            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(prodid) from prod", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                pid = Convert.ToInt32(dr[0]);
                pid++;
            }
            else
            {
                pid++;
            }
            sqlConnection1.Close();
            tbx_ap_prodID.Text = "PROD" + pid + System.DateTime.Today.DayOfYear + System.DateTime.Today.Year;
        }

        private void btn_m_pv_Click(object sender, EventArgs e)
        {
            panel_menu.Hide();
            panel_pv.Show();

            cbx_vp_id.Items.Clear();
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select prodid from prod", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbx_vp_id.Items.Add(dr["prodid"].ToString());
            }
            sqlConnection1.Close();
        }

        private void btn_ca_back_Click(object sender, EventArgs e)
        {
            panel_ca.Hide();
            panel_menu.Show();
        }

        private void btn_ac_add_Click(object sender, EventArgs e)
        {
            if (tbx_ac_custName.Text != "" &&
            tbx_ac_add.Text != "" &&
            tbx_ac_contNo.Text != "" &&
            tbx_ac_email.Text != "")
            {
                try
                {
                    sqlConnection1.Open();
                    SqlCommand cmd = new SqlCommand("insert into cust(custID,custName,gender,address,contNo,email,createdDate,modifiedDate) values(@custID,@custName,@gender,@address,@contNo,@email,@createdDate,@modifiedDate)", sqlConnection1);
                    cmd.Parameters.AddWithValue("@custID", tbx_ac_custID.Text);
                    cmd.Parameters.AddWithValue("@custName", tbx_ac_custName.Text);
                    if (rbtn_ac_female.Checked)
                    {
                        cmd.Parameters.AddWithValue("@gender", "Female");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@gender", "Male");
                    }
                    cmd.Parameters.AddWithValue("@address", tbx_ac_add.Text);
                    cmd.Parameters.AddWithValue("@contNo", tbx_ac_contNo.Text);
                    cmd.Parameters.AddWithValue("@email", tbx_ac_email.Text);
                    cmd.Parameters.AddWithValue("@createdDate", System.DateTime.Today.ToString());
                    cmd.Parameters.AddWithValue("@modifiedDate", System.DateTime.Today.ToString());

                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();

                    tbx_ac_custID.Text = "";
                    tbx_ac_custName.Text = "";
                    tbx_ac_add.Text = "";
                    tbx_ac_contNo.Text = "";
                    tbx_ac_email.Text = "";
                    cid++;
                    tbx_ac_custID.Text = "CUST" + cid + System.DateTime.Today.DayOfYear + System.DateTime.Today.Year;

                    MessageBox.Show("Customer Record Added...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Error Occured while processing this work" + Environment.NewLine + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Something is Missing....!!");
            }
        }

        private void btn_sa_back_Click(object sender, EventArgs e)
        {
            panel_sa.Hide();
            panel_menu.Show();
        }

        private void btn_as_add_Click(object sender, EventArgs e)
        {
            if (tbx_as_suppName.Text != "" &&
            tbx_as_add.Text != "" &&
            tbx_as_contNo.Text != "" &&
            tbx_as_email.Text != "")
            {
                try
                {
                    sqlConnection1.Open();
                    SqlCommand cmd = new SqlCommand("insert into Supp(suppID,suppName,company,contNo,email,createdDate,modifiedDate) values(@suppID,@suppName,@address,@contNo,@email,@createdDate,@modifiedDate)", sqlConnection1);
                    cmd.Parameters.AddWithValue("@suppID", tbx_as_suppID.Text);
                    cmd.Parameters.AddWithValue("@suppName", tbx_as_suppName.Text);
                    cmd.Parameters.AddWithValue("@address", tbx_as_add.Text);
                    cmd.Parameters.AddWithValue("@contNo", tbx_as_contNo.Text);
                    cmd.Parameters.AddWithValue("@email", tbx_as_email.Text);
                    cmd.Parameters.AddWithValue("@createdDate", System.DateTime.Today.ToString());
                    cmd.Parameters.AddWithValue("@modifiedDate", System.DateTime.Today.ToString());

                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();

                    tbx_as_suppID.Text = "";
                    tbx_as_suppName.Text = "";
                    tbx_as_add.Text = "";
                    tbx_as_contNo.Text = "";
                    tbx_as_email.Text = "";
                    sid++;
                    tbx_as_suppID.Text = "supp" + sid + System.DateTime.Today.DayOfYear + System.DateTime.Today.Year;

                    MessageBox.Show("Supplier Record Added...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Error Occured while processing this work" + Environment.NewLine + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlConnection1.Close();
                }
            }
            else
            {
                MessageBox.Show("Something is Missing....!!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_cv.Hide();
            panel_menu.Show();
        }

        private void btn_sv_back_Click(object sender, EventArgs e)
        {
            panel_sv.Hide();
            panel_menu.Show();

        }

        private void tbx_as_contNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_vc_view_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from cust", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgw_vc.DataSource = dt;
            sqlConnection1.Close();
        }

        private void cbx_vc_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from cust where custid='" + cbx_vc_id.Text + "'", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgw_vc.DataSource = dt;
            sqlConnection1.Close();

            pnl_vc_update.Show();

        }

        private void btn_vc_update_Click(object sender, EventArgs e)
        {
            if (tbx_vc_value.Text != "")
            {
                string s = cbx_vc_field.Text;
                sqlConnection1.Open();
                if (s == "custName")
                {
                    SqlCommand cmd = new SqlCommand("update cust set custname = '" + tbx_vc_value.Text + "' where custid='" + cbx_vc_id.Text + "'", sqlConnection1);
                    cmd.ExecuteNonQuery();
                }
                if (s == "address")
                {
                    SqlCommand cmd = new SqlCommand("update cust set address = '" + tbx_vc_value.Text + "' where custid='" + cbx_vc_id.Text + "'", sqlConnection1);
                    cmd.ExecuteNonQuery();
                }
                if (s == "contNo")
                {
                    SqlCommand cmd = new SqlCommand("update cust set contno = '" + tbx_vc_value.Text + "' where custid='" + cbx_vc_id.Text + "'", sqlConnection1);
                    cmd.ExecuteNonQuery();
                }
                if (s == "email")
                {
                    SqlCommand cmd = new SqlCommand("update cust set email = '" + tbx_vc_value.Text + "' where custid='" + cbx_vc_id.Text + "'", sqlConnection1);
                    cmd.ExecuteNonQuery();
                }

                SqlCommand cmd2 = new SqlCommand("update cust set modifieddate = '" + System.DateTime.Today.ToString() + "' where custid='" + cbx_vc_id.Text + "'", sqlConnection1);
                cmd2.ExecuteReader();
                sqlConnection1.Close();

                pnl_vc_update.Hide();

                sqlConnection1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from cust where custid='" + cbx_vc_id.Text + "'", sqlConnection1);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr1);
                dgw_vc.DataSource = dt;
                sqlConnection1.Close();
            }
            else
            {
                MessageBox.Show("Something is Missing....!!");
            }
        }

        private void cbx_vs_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from supp where suppid='" + cbx_vs_id.Text + "'", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgw_vs.DataSource = dt;
            sqlConnection1.Close();

            pnl_vs_update.Show();
        }

        private void btn_vs_view_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from supp", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgw_vs.DataSource = dt;
            sqlConnection1.Close();
        }

        private void cbx_vs_field_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbx_vc_field_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_vs_update_Click(object sender, EventArgs e)
        {
            if (tbx_vs_value.Text !="")
            {
                string s = cbx_vs_field.Text;
                sqlConnection1.Open();
                if (s == "suppName")
                {
                    SqlCommand cmd = new SqlCommand("update supp set suppname = '" + tbx_vs_value.Text + "' where suppid='" + cbx_vs_id.Text + "'", sqlConnection1);
                    cmd.ExecuteNonQuery();
                }
                if (s == "company")
                {
                    SqlCommand cmd = new SqlCommand("update supp set company = '" + tbx_vs_value.Text + "' where suppid='" + cbx_vs_id.Text + "'", sqlConnection1);
                    cmd.ExecuteNonQuery();
                }
                if (s == "contNo")
                {
                    SqlCommand cmd = new SqlCommand("update supp set contno = '" + tbx_vs_value.Text + "' where suppid='" + cbx_vs_id.Text + "'", sqlConnection1);
                    cmd.ExecuteNonQuery();
                }
                if (s == "email")
                {
                    SqlCommand cmd = new SqlCommand("update supp set email = '" + tbx_vs_value.Text + "' where suppid='" + cbx_vs_id.Text + "'", sqlConnection1);
                    cmd.ExecuteNonQuery();
                }

                SqlCommand cmd2 = new SqlCommand("update supp set modifieddate = '" + System.DateTime.Today.ToString() + "' where suppid='" + cbx_vs_id.Text + "'", sqlConnection1);
                cmd2.ExecuteReader();
                sqlConnection1.Close();

                pnl_vs_update.Hide();

                sqlConnection1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from supp where suppid='" + cbx_vs_id.Text + "'", sqlConnection1);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr1);
                dgw_vs.DataSource = dt;
                sqlConnection1.Close();
            }
            else
            {
                MessageBox.Show("Something is Missing....!!");
            }
        } 


        private void btn_pa_back_Click(object sender, EventArgs e)
        {
            panel_pa.Hide();
            panel_menu.Show();
        }

        private void btn_ap_add_Click(object sender, EventArgs e)
        {

            if (tbx_ap_prodName.Text != "" &&
            tbx_ap_unitPrice.Text != "")
            {
                try
                {
                    sqlConnection1.Open();
                    SqlCommand cmd = new SqlCommand("insert into prod(prodID,prodName,unitPrice,quantity,createdDate,modifiedDate) values(@prodID,@prodName,@unitPrice,@quantity,@createdDate,@modifiedDate)", sqlConnection1);
                    cmd.Parameters.AddWithValue("@prodID", tbx_ap_prodID.Text);
                    cmd.Parameters.AddWithValue("@prodName", tbx_ap_prodName.Text);
                    cmd.Parameters.AddWithValue("@unitPrice", tbx_ap_unitPrice.Text);
                    cmd.Parameters.AddWithValue("@quantity", "0");
                    cmd.Parameters.AddWithValue("@createdDate", System.DateTime.Today.ToString());
                    cmd.Parameters.AddWithValue("@modifiedDate", System.DateTime.Today.ToString());

                    cmd.ExecuteNonQuery();
                    sqlConnection1.Close();

                    tbx_ap_prodID.Text = "";
                    tbx_ap_prodName.Text = "";
                    tbx_ap_unitPrice.Text = "";
                    pid++;
                    tbx_ap_prodID.Text = "PROD" + pid + System.DateTime.Today.DayOfYear + System.DateTime.Today.Year;

                    MessageBox.Show("Product Record Added...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Error Occured while processing this work" + Environment.NewLine + Environment.NewLine + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Something is Missing....!!");
            }
        }

        private void cbx_vp_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from prod where prodid='"+cbx_vp_id.Text+"'", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgw_vp.DataSource = dt;
            sqlConnection1.Close();

            pnl_vp_update.Show();
            
        }

        private void btn_vp_update_Click(object sender, EventArgs e)
        {
            if (tbx_vp_value.Text != "")
            {
                string s = cbx_vp_field.Text;
                sqlConnection1.Open();
                if (s == "prodName")
                {
                    SqlCommand cmd = new SqlCommand("update prod set prodname = '" + tbx_vp_value.Text + "' where prodid='" + cbx_vp_id.Text + "'", sqlConnection1);
                    cmd.ExecuteNonQuery();
                }
                if (s == "unitPrice")
                {
                    SqlCommand cmd = new SqlCommand("update prod set unitPrice = '" + tbx_vp_value.Text + "' where prodid='" + cbx_vp_id.Text + "'", sqlConnection1);
                    cmd.ExecuteNonQuery();
                }

                SqlCommand cmd2 = new SqlCommand("update prod set modifieddate = '" + System.DateTime.Today.ToString() + "' where prodid='" + cbx_vp_id.Text + "'", sqlConnection1);
                cmd2.ExecuteReader();
                sqlConnection1.Close();

                pnl_vp_update.Hide();

                sqlConnection1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from prod where prodid='" + cbx_vp_id.Text + "'", sqlConnection1);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr1);
                dgw_vp.DataSource = dt;
                sqlConnection1.Close();
            }
            else
            {
                MessageBox.Show("Something is Missing....!!");
            }
        }

        private void btn_pv_back_Click(object sender, EventArgs e)
        {
            panel_pv.Hide();
            panel_menu.Show();
        }

        private void btn_vp_view_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from prod", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgw_vp.DataSource = dt;
            sqlConnection1.Close();
        }

        private void tbx_aspo_qty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int qty = Convert.ToInt32(tbx_aspo_qty.Text);
                if (qty > 100)
                {
                    tbx_aspo_qty.Text = "100";
                    qty = 100;
                }
                int tp = qty * Convert.ToInt32(tbx_aspo_unitPrice.Text);
                tbx_aspo_totalPricd.Text = tp.ToString();
            }
            catch (Exception)
            {
                tbx_aspo_totalPricd.Text = "";
            }

        }
    

        private void btn_aspo_back_Click(object sender, EventArgs e)
        {
            panel_menu.Show();
            panel_bpa.Hide();
        }

        private void cbx_aspo_suppID_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from supp where suppid='"+cbx_aspo_suppID.Text+"'", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tbx_aspo_suppName.Text = dr["suppName"].ToString();
                tbx_aspo_ContNo.Text = dr["contNo"].ToString();
            }
            sqlConnection1.Close();

            cbx_aspo_prodID.Items.Clear();
            sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select prodid from prod", sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                cbx_aspo_prodID.Items.Add(dr1["prodid"].ToString());
            }
            sqlConnection1.Close();
        }

        private void cbx_aspo_prodID_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from prod where prodid='" + cbx_aspo_prodID.Text + "'", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tbx_aspo_prodName.Text = dr["prodName"].ToString();
                tbx_aspo_unitPrice.Text = dr["unitPrice"].ToString();
                tbx_aspo_qtyHave.Text = dr["quantity"].ToString();
            }
            sqlConnection1.Close();
        }

        private void tbx_aspo_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_aspo_add_Click(object sender, EventArgs e)
        {
            if (tbx_aspo_suppName.Text != "" &&
            tbx_aspo_ContNo.Text != "" &&
            tbx_aspo_prodName.Text != "" &&
            tbx_aspo_qty.Text != "" &&
            tbx_aspo_totalPricd.Text != "" &&
            tbx_aspo_unitPrice.Text != "")
            {
                int qtyhave = Convert.ToInt32(tbx_aspo_qtyHave.Text);
                int qtyord = Convert.ToInt32(tbx_aspo_qty.Text);
                int totpr = Convert.ToInt32(tbx_aspo_totalPricd.Text);
                int qty = qtyhave + qtyord;
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("insert into spo(poID,suppID,prodID,prodQty,poTP,createdDate) values(@poID,@suppID,@prodID,@prodQty,@poTP,@createdDate)", sqlConnection1);
                cmd.Parameters.AddWithValue(@"poID", tbx_aspo_poID.Text);
                cmd.Parameters.AddWithValue(@"suppID", cbx_aspo_suppID.Text);
                cmd.Parameters.AddWithValue(@"prodID", cbx_aspo_prodID.Text);
                cmd.Parameters.AddWithValue(@"prodQty", tbx_aspo_qty.Text);
                cmd.Parameters.AddWithValue(@"poTP", tbx_aspo_totalPricd.Text);
                cmd.Parameters.AddWithValue(@"createdDate", System.DateTime.Today.ToString());
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                tbx_aspo_qtyHave.Text = qty.ToString();
                sqlConnection1.Open();
                SqlCommand cmd1 = new SqlCommand("update prod set quantity='" + qty.ToString() + "' where prodid='" + cbx_aspo_prodID.Text + "'", sqlConnection1);
                cmd1.ExecuteNonQuery();
                sqlConnection1.Close();

                tbx_aspo_suppName.Text = "";
                tbx_aspo_ContNo.Text = "";
                tbx_aspo_prodName.Text = "";
                tbx_aspo_qty.Text = "";
                tbx_aspo_totalPricd.Text = "";
                tbx_aspo_unitPrice.Text = "";
                cbx_aspo_prodID.Text = "";
                cbx_aspo_suppID.Text = "";
                cbx_aspo_prodID.Items.Clear();
                bp++;
                tbx_aspo_poID.Text = "SPO" + bp + System.DateTime.Today.DayOfYear + System.DateTime.Today.Year;

                MessageBox.Show("Product Order Added Successfully...");
            }
            else
            {
                MessageBox.Show("Something is Missing....!!");
            }
        }

        private void tbx_ac_contNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbx_as_contNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbx_ap_unitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbx_acpo_suppID_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from cust where custid='" + cbx_acpo_custID.Text + "'", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tbx_acpo_custName.Text = dr["custName"].ToString();
                tbx_acpo_ContNo.Text = dr["contNo"].ToString();
            }
            sqlConnection1.Close();

            cbx_acpo_prodID.Items.Clear();
            sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select prodid from prod", sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                cbx_acpo_prodID.Items.Add(dr1["prodid"].ToString());
            }
            sqlConnection1.Close();
        }

        private void cbx_acpo_prodID_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from prod where prodid='" + cbx_acpo_prodID.Text + "'", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                tbx_acpo_prodName.Text = dr["prodName"].ToString();
                string up = dr["unitPrice"].ToString();

                tbx_acpo_unitPrice.Text = (Convert.ToInt32(up) + (Convert.ToInt32(up) / 3)).ToString();
                tbx_acpo_qtyHave.Text = dr["quantity"].ToString();
            }
            sqlConnection1.Close();
        }

        private void tbx_acpo_qty_TextChanged(object sender, EventArgs e)
        {
            try
            {
            int qtyhave = Convert.ToInt32(tbx_acpo_qtyHave.Text);
                int qty = Convert.ToInt32(tbx_acpo_qty.Text);
                if (qty > qtyhave)
                {
                    tbx_acpo_qty.Text = qtyhave.ToString();
                    qty = qtyhave;
                }
                int tp = qty * Convert.ToInt32(tbx_acpo_unitPrice.Text);
                tbx_acpo_totalPricd.Text = tp.ToString();
            }
            catch (Exception)
            {
                tbx_acpo_totalPricd.Text = "";
            }
        }

        private void btn_acpo_add_Click(object sender, EventArgs e)
        {
            if (tbx_acpo_custName.Text != "" &&
            tbx_acpo_ContNo.Text != "" &&
            tbx_acpo_prodName.Text != "" &&
            tbx_acpo_qty.Text != "" &&
            tbx_acpo_totalPricd.Text != "" &&
            tbx_acpo_unitPrice.Text != "")
            {
                int qtyhave = Convert.ToInt32(tbx_acpo_qtyHave.Text);
                int qtyord = Convert.ToInt32(tbx_acpo_qty.Text);
                int totpr = Convert.ToInt32(tbx_acpo_totalPricd.Text);
                int qty = qtyhave - qtyord;
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("insert into cpo(poID,custID,prodID,prodQty,poTP,createdDate) values(@poID,@custID,@prodID,@prodQty,@poTP,@createdDate)", sqlConnection1);
                cmd.Parameters.AddWithValue(@"poID", tbx_acpo_poID.Text);
                cmd.Parameters.AddWithValue(@"custID", cbx_acpo_custID.Text);
                cmd.Parameters.AddWithValue(@"prodID", cbx_acpo_prodID.Text);
                cmd.Parameters.AddWithValue(@"prodQty", tbx_acpo_qty.Text);
                cmd.Parameters.AddWithValue(@"poTP", tbx_acpo_totalPricd.Text);
                cmd.Parameters.AddWithValue(@"createdDate", System.DateTime.Today.ToString());
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();

                sqlConnection1.Open();
                SqlCommand cmd1 = new SqlCommand("update prod set quantity='" + qty.ToString() + "' where prodid='" + cbx_acpo_prodID.Text + "'", sqlConnection1);
                cmd1.ExecuteNonQuery();
                sqlConnection1.Close();

                tbx_acpo_custName.Text = "";
                tbx_acpo_ContNo.Text = "";
                tbx_acpo_prodName.Text = "";
                tbx_acpo_qty.Text = "";
                tbx_acpo_totalPricd.Text = "";
                tbx_acpo_unitPrice.Text = "";
                cbx_acpo_prodID.Text = "";
                cbx_acpo_custID.Text = "";
                cbx_acpo_prodID.Items.Clear();
                sp++;
                tbx_acpo_poID.Text = "CPO" + sp + System.DateTime.Today.DayOfYear + System.DateTime.Today.Year;

                MessageBox.Show("Product Order Added Successfully...");
            }
            else
            {
                MessageBox.Show("Something is Missing....!!");
            }
        }
        private void btn_acpo_back_Click(object sender, EventArgs e)
        {
            panel_menu.Show();
            panel_spa.Hide();
        }

        private void tbx_acpo_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_vspo_view_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from spo", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgw_vspo.DataSource = dt;
            sqlConnection1.Close();
        }

        private void btn_vspo_back_Click(object sender, EventArgs e)
        {
            panel_menu.Show();
            panel_bpv.Hide();
        }

        private void cbx_vspo_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from spo where poid='" + cbx_vspo_id.Text + "'", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgw_vspo.DataSource = dt;
            sqlConnection1.Close();
        }

        private void btn_vcpo_view_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from cpo", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgv_vcpo.DataSource = dt;
            sqlConnection1.Close();
        }

        private void btn_vcpo_back_Click(object sender, EventArgs e)
        {
            panel_menu.Show();
            panel_spv.Hide();
        }

        private void cbx_vcpo_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select * from cpo where poid='" + cbx_vcpo_view.Text + "'", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dgv_vcpo.DataSource = dt;
            sqlConnection1.Close();
        }

        private void btn_m_spa_Click(object sender, EventArgs e)
        {
            panel_menu.Hide();
            panel_spa.Show();

            cbx_acpo_custID.Items.Clear();
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(poid) from CPO", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sp = Convert.ToInt32(dr[0]);
                sp++;
            }
            else
            {
                sp++;
            }
            tbx_acpo_poID.Text = "CPO" + sp + System.DateTime.Today.DayOfYear + System.DateTime.Today.Year;
            sqlConnection1.Close();
            sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select custid from cust", sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                cbx_acpo_custID.Items.Add(dr1["custid"].ToString());
            }
            sqlConnection1.Close();
        }

        private void btn_m_spv_Click(object sender, EventArgs e)
        {
            panel_menu.Hide();
            panel_spv.Show();

            cbx_vcpo_view.Items.Clear();
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select poid from cpo", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbx_vcpo_view.Items.Add(dr["poid"].ToString());
            }
            sqlConnection1.Close();
        }

        private void btn_m_bpa_Click(object sender, EventArgs e)
        {
            panel_menu.Hide();
            panel_bpa.Show();
            cbx_aspo_suppID.Items.Clear();

            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select count(poid) from SPO", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                bp = Convert.ToInt32(dr[0]);
                bp++;
            }
            else
            {
                bp++;
            }
            tbx_aspo_poID.Text = "SPO" + bp + System.DateTime.Today.DayOfYear + System.DateTime.Today.Year;
            sqlConnection1.Close();
            sqlConnection1.Open();
            SqlCommand cmd1 = new SqlCommand("select suppid from supp", sqlConnection1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                cbx_aspo_suppID.Items.Add(dr1["suppid"].ToString());
            }
            sqlConnection1.Close();
        }

        private void btn_m_bpv_Click(object sender, EventArgs e)
        {
            panel_menu.Hide();
            panel_bpv.Show();

            cbx_vspo_id.Items.Clear();
            sqlConnection1.Open();
            SqlCommand cmd = new SqlCommand("select poid from spo", sqlConnection1);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbx_vspo_id.Items.Add(dr["poid"].ToString());
            }
            sqlConnection1.Close();
        }
    }
}
