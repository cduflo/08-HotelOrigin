using Newtonsoft.Json;
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
using HotelOrigin.Core.Repository;
using HotelOrigin.Core.Domain;
using System.IO;
using System.Collections.ObjectModel;

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
            LoadFromDiskCus();
            LoadFromDiskRes();
            LoadFromDiskRoom();
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

        public static void SaveToDiskCus()
        {
            string json = JsonConvert.SerializeObject(CustomerRepository.customers);
            File.WriteAllText("customers.json", json);
        }

        public static void SaveToDiskRoom()
        {
            string json = JsonConvert.SerializeObject(RoomRepository.rooms);
            File.WriteAllText("rooms.json", json);
        }

        public static void SaveToDiskRes()
        {
            string json = JsonConvert.SerializeObject(ReservationRepository.reservations);
            File.WriteAllText("reservations.json", json);
        }

        public static void LoadFromDiskCus()
        {
            if(File.Exists("customers.json"))
            {
                string json = File.ReadAllText("customers.json");
                CustomerRepository.customers = JsonConvert.DeserializeObject<ObservableCollection<Customer>>(json);
                            }
        }

        public static void LoadFromDiskRoom()
        {
            if (File.Exists("rooms.json"))
            {
                string json = File.ReadAllText("rooms.json");
                RoomRepository.rooms = JsonConvert.DeserializeObject<ObservableCollection<Rooms>>(json);
            }
        }

        public static void LoadFromDiskRes()
        {
            if (File.Exists("reservations.json"))
            {
                string json = File.ReadAllText("reservations.json");
                ReservationRepository.reservations = JsonConvert.DeserializeObject<ObservableCollection<Reservations>>(json);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveToDiskCus();
            SaveToDiskRoom();
            SaveToDiskRes();
        }
    }
}
