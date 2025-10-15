using Airlines_Vozhakova.Classes;
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
    /// Логика взаимодействия для Ticket.xaml
    /// </summary>
    public partial class Ticket : Page
    {
        private MainWindow mainWindow;
        private string fromCity;
        private string toCity;
        public Ticket(MainWindow mw, List<TicketClass> tickets, string from, string to)
        {
            InitializeComponent();
            mainWindow = mw;
            fromCity = from;
            toCity = to;
            SetTickets(tickets);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.OpenPages(MainWindow.pages.main);
        }
        public void SetTickets(List<TicketClass> tickets)
        {
            parent.Children.Clear();
            foreach (var ticket in tickets)
            {
                var ticketItem = new Elements.TicketItem();

                DateTime startDateTime;
                if (DateTime.TryParseExact(ticket.time_start, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out startDateTime))
                {
                    ticketItem.timeFrom.Content = startDateTime.ToString("HH:mm");
                    ticketItem.dateFrom.Content = startDateTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    ticketItem.timeFrom.Content = ticket.time_start;
                    ticketItem.dateFrom.Content = "";
                }

                DateTime endDateTime;
                if (DateTime.TryParseExact(ticket.time_end, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out endDateTime))
                {
                    ticketItem.timeTo.Content = endDateTime.ToString("HH:mm");
                    ticketItem.dateTo.Content = endDateTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    ticketItem.timeTo.Content = ticket.time_end;
                    ticketItem.dateTo.Content = "";
                }

                ticketItem.price.Content = ticket.price;
                ticketItem.cityFrom.Content = ticket.from;
                ticketItem.cityTo.Content = ticket.to;
                ticketItem.timeWay.Content = ticket.time_way;

                parent.Children.Add(ticketItem);
            }
        }
    }
}
