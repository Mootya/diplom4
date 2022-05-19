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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace KURS1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
         
        }

        private void voyti_Click(object sender, RoutedEventArgs e)
        {
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("select *  from [avtoriz] where [avtoriz].[login] = '"
                            + login.Text + "'and [avtoriz].[Password] = '" + password.Text + "'", connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)//если естьданные 
                        {
                            while (reader.Read())// построчно считываем данные
                            {
                                string rol = reader.GetValue(3).ToString();
                                MessageBox.Show("Добро пожаловать!");

                            }
                        }
                        else
                        {
                            MessageBox.Show("Такого пользователя нет");
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Введите корректные данные");
                }
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Window1 form1 = new Window1();
            form1.Show();
            Hide();
        }
    }
}
