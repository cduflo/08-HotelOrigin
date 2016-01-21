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
using HotelOrigin.Core.Repository;
using HotelOrigin.Core.Domain;

namespace HotelOrigin
{
    /// <summary>
    /// Interaction logic for ReservationGrid.xaml
    /// </summary>
    public partial class ReservationGrid : Window
    {
        public ReservationGrid()
        {
            InitializeComponent();
            dataGridReservations.ItemsSource = HotelOrigin.Core.Repository.ReservationRepository.reservations;

        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            ReservationAdd addwin = new ReservationAdd();
            addwin.ShowDialog();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridReservations.SelectedItem == null)
            { return; }
            Reservations selected = dataGridReservations.SelectedItem as Reservations;
            ReservationRepository.reservations.Remove(selected);
        }

        private void dataGridReservations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Reservations selected = dataGridReservations.SelectedItem as Reservations;
            if (selected.id < 1)

            { return; }

            ReservationEdit editWin = new ReservationEdit();
            editWin.Owner = this;
            editWin.ShowDialog();

        }
    }
}
