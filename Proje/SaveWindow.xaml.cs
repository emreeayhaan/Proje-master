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
    public enum Gender { Erkek, Kadın, Diğer };
    public partial class SaveWindow : Window
    {
        MainWindow mw = new MainWindow();
        MySQLClass sQLClass = new MySQLClass();
        public SaveWindow()
        {
            InitializeComponent();

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            sQLClass.MySqlAdd(idTB, nameTB, surnameTB, phonenumberTB, genderTB);
            MessageBox.Show("Kayıt attı");
            sQLClass.MySqlRefresh(mw.listView1);
            this.Close();
            mw.Show();
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            sQLClass.MySqlRefresh(mw.listView1);
            mw.Show();   
        }
    }
}

          