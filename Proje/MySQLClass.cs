using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Proje
{
    public class MySQLClass
    {
        public MySqlConnection baglan;
        public MySqlDataReader dr;
        public MySqlCommand comm;
        /// <summary>
        /// Mysql den çektiği veriyi listviewa güncelleyen method.
        /// </summary>
        /// <param name="lv"></param>
        public void MySqlRefresh(ListView lv)
        {
            lv.Items.Clear();
            baglan = new MySqlConnection("server = localhost; database = proje ; uid = root; pwd = 17851765910;");
            baglan.Open();
            comm = new MySqlCommand("select * from user", baglan);
            dr = comm.ExecuteReader();
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString() + "\t" + dr["NAME"].ToString() + "\t" + dr["SURNAME"].ToString() + "\t" + dr["PHONENUMBER"].ToString() + "\t" + dr["GENDER"].ToString());
            }
            baglan.Close();
        }
        /// <summary>
        /// Textboxtan girilen id'yi veri tabanından silen method.
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="tb"></param>
        public void MySqlDelete(ListView lv, TextBox tb)
        {
            baglan = new MySqlConnection("server = localhost; database = proje ; uid = root; pwd = 17851765910;");
            baglan.Open();
            comm = new MySqlCommand($"DELETE FROM user WHERE ID ={tb.Text};", baglan);
            comm.ExecuteNonQuery();
            baglan.Close();
            lv.Items.Clear();
        }
        /// <summary>
        /// Textboxt'tan aldığı bilgilerle veri tabanına ekleme yapan method.
        /// </summary>
        /// <param name="idTB"></param>
        /// <param name="nameTB"></param>
        /// <param name="surnameTB"></param>
        /// <param name="phonenumberTB"></param>
        /// <param name="genderTB"></param>
        public void MySqlAdd(TextBox idTB, TextBox nameTB, TextBox surnameTB, TextBox phonenumberTB, TextBox genderTB)
        {
            baglan = new MySqlConnection("server = localhost; database = proje ; uid = root; pwd = 17851765910;");
            baglan.Open();
            comm = new MySqlCommand($"INSERT INTO user (`ID`,`NAME`,`SURNAME`,`PHONENUMBER`,`GENDER`)VALUES({idTB.Text},'{nameTB.Text}','{surnameTB.Text}','{phonenumberTB.Text}','{genderTB.Text}');", baglan);
            comm.ExecuteNonQuery();
            baglan.Close();
        }
    }
}
