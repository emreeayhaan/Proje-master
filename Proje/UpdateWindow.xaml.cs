using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proje
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        MainWindow mw = new MainWindow();
        MySQLClass sQLClass;
        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection("server = localhost; database = proje ; uid = root; pwd = 17851765910;");
            baglan.Open();
            MySqlCommand comm = new MySqlCommand($"UPDATE user SET NAME = '{nameTB.Text}',SURNAME = '{surnameTB1.Text}',PHONENUMBER = '{phoneTB.Text }', GENDER = '{genderTB.Text}' WHERE ID = {idTB.Text}; ", baglan);
            comm.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Kayıt attı");
            mw.listView1.Items.Clear();
            baglan = new MySqlConnection("server = localhost; database = proje ; uid = root; pwd = 17851765910;");
            baglan.Open();
            comm = new MySqlCommand("select * from user", baglan);
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                mw.listView1.Items.Add(dr["ID"].ToString() + "\t" + dr["NAME"].ToString() + "\t" + dr["SURNAME"].ToString() + "\t" + dr["PHONENUMBER"].ToString() + "\t" + dr["GENDER"].ToString());
            }
            baglan.Close();
            this.Close();
            mw.Show();
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mw.Show();
        }
    }
}
