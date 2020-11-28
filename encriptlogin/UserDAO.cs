using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace encriptlogin
{
    class UserDAO
    {
        public static void login(User user)
        {
            MySqlConnection con = DBConnection.getConnection();
            if(con==null)
            {
                throw new Exception("Nu s-a putut realiza conexiunea la baza de date");
            }

            MySqlCommand com = con.CreateCommand();

            com.CommandText = "SELECT * FROM login WHERE @id=id AND @parola=parola";
            com.Parameters.AddWithValue("@id", user.getId());
            com.Parameters.AddWithValue("@parola", user.getParola());
            MySqlDataReader login = com.ExecuteReader();
            if (login.Read())
            {
                MessageBox.Show("V-ati autentificat cu succes", "Confirmare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                throw new Exception("Nu s-a putut face autentificarea");
            }

        }

        public static void register(User user)
        {

            MySqlConnection con = DBConnection.getConnection();

            if (con == null)
            {
                throw new Exception("Conexiunea la baza de date nu s-a realizat.");
            }

            MySqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "INSERT INTO login(id,parola) VALUES(@id, @parola)";
            cmd.Parameters.AddWithValue("@id",user.getId());
            cmd.Parameters.AddWithValue("@parola",user.getParola());

            if (cmd.ExecuteNonQuery() != 1)
            {
                throw new Exception("Inserarea nu s-a putut face.");
            }
            else
            {
                MessageBox.Show("V-ati inregistrat cu succes", "Confirmare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            con.Close();
        }
    }
}
