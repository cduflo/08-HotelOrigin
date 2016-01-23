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
    /// Interaction logic for RoomEdit1.xaml
    /// </summary>
    public partial class RoomEdit1 : Window
    {
        Rooms temp { get; set; }
        int tempID;
        bool fieldsUpdated = false;

        public RoomEdit1()
        {
            InitializeComponent();
        }

        public RoomEdit1(Rooms x) : this()
        {
            InitializeComponent();
            this.temp = x;
            textBoxNum.Text = temp.RoomNumber.ToString();
            textBoxBeds.Text = temp.Beds.ToString();
            checkBox.IsChecked = temp.HasTV;
            tempID = temp.id;
        }

        private void buttonSubmit_Click_1(object sender, RoutedEventArgs e)
        {
           
            var roomList = Owner as RoomGrid;
            if (fieldsUpdated)
            {
                MessageBox.Show("Please ensure all fields are populated.");

            }
            else 
            {
                temp.RoomNumber = Convert.ToInt32(textBoxNum.Text);
                temp.Beds = Convert.ToInt32(textBoxBeds.Text);
                temp.HasTV = tvCheck();
                roomList.RefreshGrid();
                this.Close();
            }
        }


        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (fieldsUpdated)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Unsaved changes. Are you sure you want to close this window?", "Unsaved Work", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private bool tvCheck()
        {
            bool x;
            if (checkBox.IsChecked == null || checkBox.IsChecked == false)
            {
                x = false;
            }
            else
            {
                x = true;
            }
            return x;
        }

        private void textBoxNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                fieldsUpdated = true;
            }
        }

        private void textBoxBeds_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                fieldsUpdated = true;
            }
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsLoaded)
            {
          //      fieldsUpdated = true;
            }
        }
    }
}
