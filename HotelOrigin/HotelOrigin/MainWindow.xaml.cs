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

namespace HotelOrigin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonCustMan_Click(object sender, RoutedEventArgs e)
        {
            CustomerList custListWin = new CustomerList();
            custListWin.Show();
        }

        private void buttonRoomMan_Click(object sender, RoutedEventArgs e)
        {
            RoomGrid roomGridWin = new RoomGrid();
            roomGridWin.Show();
        }

        private void buttonResMan_Click(object sender, RoutedEventArgs e)
        {
            ReservationGrid resGridWin = new ReservationGrid();
            resGridWin.Show();
        }
    }
}
