using Airlines_Vozhakova.Classes;
using Airlines_Vozhakova.Pages;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using WorkingBD;

namespace Airlines_Vozhakova
{
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public List<TicketClass> ticketClasses = new List<TicketClass>();
        public MainWindow()
        {
            InitializeComponent();
            mainWindow = this;
            OpenPages(pages.main);
            LoadTickets();
        }

        public void LoadTickets()
        {
            string sql = "SELECT * FROM tickets";
            MySqlConnection conn = null;
            try
            {
                conn = Class1.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                ticketClasses.Clear();
                while (reader.Read())
                {
                    string from = reader.GetString("from");
                    string to = reader.GetString("to");
                    string price = reader.GetString("price");
                    DateTime timeStart = reader.GetDateTime("timeStart");
                    DateTime timeEnd = reader.GetDateTime("timeEnd");

                    TimeSpan timeWay = timeEnd - timeStart;
                    string timeStartStr = timeStart.ToString("yyyy-MM-dd HH:mm");
                    string timeEndStr = timeEnd.ToString("yyyy-MM-dd HH:mm");
                    string timeWayStr = $"В пути: {(int)timeWay.TotalHours}ч {timeWay.Minutes}м";

                    ticketClasses.Add(new TicketClass(price, from, to, timeStartStr, timeEndStr, timeWayStr));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    Class1.CloseConnection(conn);
                }
            }
        }

        public enum pages
        {
            main,
            ticket
        }

        public void OpenPages(pages page)
        {
            if (page == pages.main)
            {
                frame.Navigate(new Main());
            }
        }
    }
}
