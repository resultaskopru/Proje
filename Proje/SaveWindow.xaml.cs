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
    /// <summary>
    /// Interaction logic for SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        public SaveWindow()
        {
            InitializeComponent();

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            MySqlConnection baglan = new MySqlConnection("server = localhost; database = db; uid = root; pwd = 123456; ");
            baglan.Open();
            MySqlCommand ekle = new MySqlCommand($"INSERT INTO `db`.`user`(`ID`,`NAME`,`SURNAME`,`PHONENUMBER`)VALUES({idTB.Text},'{nameTB.Text}','{surnameTB.Text}','{phonenumberTB.Text}');", baglan);
            ekle.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Kayıt attı");   
            main = new MainWindow();
            main.listView1.Items.Clear();
            baglan = new MySqlConnection("server = localhost; database = db; uid = root; pwd = 123456;");
            baglan.Open();
            MySqlCommand refresh = new MySqlCommand("select * from user", baglan);
            MySqlDataReader dr = refresh.ExecuteReader();
            while (dr.Read())
            {
                main.listView1.Items.Add(dr["ID"].ToString() + "                " + dr["NAME"].ToString() + "              " + dr["SURNAME"].ToString() + "              " + dr["PHONENUMBER"].ToString() + "                " + dr["GENDER"].ToString());
            }
            baglan.Close();
            this.Close();
            main.Show();
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
            main.listView1.Items.Clear();
            MySqlConnection baglan = new MySqlConnection("server = localhost; database = db; uid = root; pwd = 123456;");
            baglan.Open();
            MySqlCommand refresh = new MySqlCommand("select * from user", baglan);
            MySqlDataReader dr = refresh.ExecuteReader();
            while (dr.Read())
            {
                main.listView1.Items.Add(dr["ID"].ToString() + "                " + dr["NAME"].ToString() + "              " + dr["SURNAME"].ToString() + "              " + dr["PHONENUMBER"].ToString() + "                " + dr["GENDER"].ToString());
            }
            baglan.Close();
            

        }
    }
}

          