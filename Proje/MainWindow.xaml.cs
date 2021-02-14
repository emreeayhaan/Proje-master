using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySQLClass sQLClass = new MySQLClass();
        public MainWindow()
        {
            InitializeComponent();
            sQLClass.MySqlRefresh(listView1);
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Proje.SaveWindow saveWindow = new SaveWindow();
            saveWindow.Show();
            this.Close();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            Proje.UpdateWindow updateWindow = new UpdateWindow();
            updateWindow.Show();
            this.Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            sQLClass.MySqlDelete(listView1, db);
            sQLClass.MySqlRefresh(listView1);
        }

        private void refreshbtn_Click(object sender, RoutedEventArgs e)
        {
            sQLClass.MySqlRefresh(listView1);
            MessageBox.Show("Yenilendi");
        }

        private void db_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }


}


