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
            DataGridTextColumn cusColumn = new DataGridTextColumn();
            cusColumn.Header = "Customer";
            cusColumn.Binding = new Binding("Customer.lastName");
            dataGridReservations.Columns.Add(cusColumn);
            DataGridTextColumn roomColumn = new DataGridTextColumn();
            roomColumn.Header = "Room";
            roomColumn.Binding = new Binding("Room.RoomNumber");
            dataGridReservations.Columns.Add(roomColumn);
            DataGridTextColumn ciColumn = new DataGridTextColumn();
            ciColumn.Header = "Check-In";
            ciColumn.Binding = new Binding("CheckIn");
            dataGridReservations.Columns.Add(ciColumn);
            DataGridTextColumn coColumn = new DataGridTextColumn();
            coColumn.Header = "Check-Out";
            coColumn.Binding = new Binding("CheckOut");
            dataGridReservations.Columns.Add(coColumn);                 
            DataGridTextColumn noteColumn = new DataGridTextColumn();
            noteColumn.Header = "Notes";
            noteColumn.Binding = new Binding("Notes");
            dataGridReservations.Columns.Add(noteColumn);
            

            dataGridReservations.IsReadOnly = true;
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
