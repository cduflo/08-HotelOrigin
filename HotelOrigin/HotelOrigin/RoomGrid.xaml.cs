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
    /// Interaction logic for RoomGrid.xaml
    /// </summary>
    public partial class RoomGrid : Window
    {
        public RoomGrid()
        {
            InitializeComponent();
            dataGridRooms.ItemsSource = HotelOrigin.Core.Repository.RoomRepository.rooms;

            dataGridRooms.Columns.Add(addColumn("Room", "RoomNumber"));
            dataGridRooms.Columns.Add(addColumn("Beds", "Beds"));
            dataGridRooms.Columns.Add(addColumn("TV", "HasTV"));
 
            dataGridRooms.IsReadOnly = true;
        }

    public DataGridTextColumn addColumn(string header, string source)
    {
        DataGridTextColumn x = new DataGridTextColumn();
        x.Header = header;
        x.Binding = new Binding(source);
        return x;
    }

    private void buttonDelete_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGridRooms.SelectedItem == null)
            { return; }
            Rooms selected = dataGridRooms.SelectedItem as Rooms;
            RoomRepository.rooms.Remove(selected);
        }

        private void buttonAdd_Click_1(object sender, RoutedEventArgs e)
        {
            RoomAdd1 addwin = new RoomAdd1();
            addwin.ShowDialog();
        }

        private void dataGridRooms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Rooms selected = dataGridRooms.SelectedItem as Rooms;
            if (dataGridRooms.SelectedItem == null)

            { return; }

            RoomEdit1 editWin = new RoomEdit1(selected);
            editWin.Owner = this;
            editWin.ShowDialog();

        }

        public void RefreshGrid()
        {
            dataGridRooms.CommitEdit();
            dataGridRooms.CommitEdit();
            dataGridRooms.Items.Refresh();
        }

    }
}
