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
        
        public MainWindow()
        {
            InitializeComponent();
            
            listView1.Items.Clear();
            MySqlConnection baglan = new MySqlConnection("server = localhost; database = db; uid = root; pwd = 123456;");
            baglan.Open();
            MySqlCommand ekle = new MySqlCommand("select * from user", baglan);
            MySqlDataReader dr = ekle.ExecuteReader();
            while (dr.Read())
            {
                listView1.Items.Add(dr["ID"].ToString() + "                " + dr["NAME"].ToString() + "              " + dr["SURNAME"].ToString() + "              " + dr["PHONENUMBER"].ToString() + "                " + dr["GENDER"].ToString());
            }
            baglan.Close();
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
            MySqlConnection baglan = new MySqlConnection("server = localhost; database = db; uid = root; pwd = 123456; ");
            baglan.Open();
            MySqlCommand delete = new MySqlCommand($"DELETE FROM `db`.`user`WHERE ID ={db.Text};", baglan);          
            delete.ExecuteNonQuery();
            baglan.Close();
            listView1.Items.Clear();
            baglan = new MySqlConnection("server = localhost; database = db; uid = root; pwd = 123456;");
            baglan.Open();
            MySqlCommand refresh = new MySqlCommand("select * from user", baglan);
            MySqlDataReader dr = refresh.ExecuteReader();
            while (dr.Read())

            {
                listView1.Items.Add(dr["ID"].ToString() + "                " + dr["NAME"].ToString() + "              " + dr["SURNAME"].ToString() + "              " + dr["PHONENUMBER"].ToString() + "                " + dr["GENDER"].ToString());
            }
            baglan.Close();
        }

        private void refreshbtn_Click(object sender, RoutedEventArgs e)
        {
            listView1.Items.Clear();
            MySqlConnection baglan = new MySqlConnection("server = localhost; database = db; uid = root; pwd = 123456;");
            baglan.Open();
            MySqlCommand refresh = new MySqlCommand("select * from user", baglan);
            MySqlDataReader dr = refresh.ExecuteReader();
            while (dr.Read())
            {
                listView1.Items.Add(dr["ID"].ToString() + "                " + dr["NAME"].ToString() + "              " + dr["SURNAME"].ToString() + "              " + dr["PHONENUMBER"].ToString() + "                " + dr["GENDER"].ToString());
            }
            baglan.Close();
            MessageBox.Show("Yenilendi");
        }

        private void db_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }


}


