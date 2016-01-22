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
    /// Interaction logic for RoomAdd1.xaml
    /// </summary>
    public partial class RoomAdd1 : Window
    {
        bool TV = false;

        public RoomAdd1()
        {
            InitializeComponent();
        }


        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            TV = true;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            TV = false;
        }

        private void buttonSubmit_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBoxBeds.Text == "" || textBoxNum.Text == "")
            {
                MessageBox.Show("Please enter all fields before submitting.");
            }
            else
            {
                RoomRepository.Create(Convert.ToInt32(textBoxNum.Text), Convert.ToInt32(textBoxBeds.Text), TV);
            }

            this.Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxBeds.Text != "" || textBoxNum.Text != "" || TV == true)
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
    }
}
