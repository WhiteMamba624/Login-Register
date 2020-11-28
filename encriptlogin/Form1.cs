using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace encriptlogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        public string encrypt(string parola)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] data = md5.ComputeHash(utf8.GetBytes(parola));
            return Convert.ToBase64String(data);
        }
        private void login_Click(object sender, EventArgs e)
        {
            verificare();
            User user = new User();
            user.setId(txtEmail.Text);
            user.setParola(encrypt(txtPassword.Text));
            UserDAO.login(user);
            txtEmail.Clear();
            txtPassword.Clear();
            txtEmail.Focus();
        }

        private void register_Click(object sender, EventArgs e)
        {
            verificare();
            User user = new User();
            user.setId(txtEmail.Text);
            user.setParola(encrypt(txtPassword.Text));
            UserDAO.register(user);
            txtEmail.Clear();
            txtPassword.Clear();
            txtEmail.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
        }

        private void verificare()
        {
            if (string.IsNullOrEmpty(txtEmail.Text) == true)
            {
                MessageBox.Show("Nu ati introdus email-ul", "Atentionare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Clear();
                txtEmail.Focus();
            }
            else
                if (string.IsNullOrEmpty(txtPassword.Text) == true)
            {
                MessageBox.Show("Nu ati introdus parola", "Atentionare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
    }
}
