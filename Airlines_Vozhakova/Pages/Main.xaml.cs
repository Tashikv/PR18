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

namespace Airlines_Vozhakova.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.Close();
        }

        private void Find(object sender, RoutedEventArgs e)
        {
            string fromText = txtFrom.Text.Trim().ToLower();
            string toText = txtTo.Text.Trim().ToLower();

            var filteredTickets = MainWindow.mainWindow.ticketClasses
                .Where(t => t.from.ToLower() == fromText && t.to.ToLower() == toText)
                .ToList();

            MainWindow.mainWindow.frame.Navigate(new Pages.Ticket(MainWindow.mainWindow, filteredTickets, txtFrom.Text, txtTo.Text));
        }
    }
}
