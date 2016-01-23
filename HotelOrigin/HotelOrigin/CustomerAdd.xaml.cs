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

namespace HotelOrigin
{
    /// <summary>
    /// Interaction logic for CustomerAdd.xaml
    /// </summary>
    public partial class CustomerAdd : Window
    {
        public CustomerAdd()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text == "" || textBoxFirst.Text == "" || textBoxLast.Text == "" || textBoxTele.Text == "")
            {
                MessageBox.Show("Please enter all fields before submitting.");
            }
            else
            {
                CustomerRepository.Create(textBoxFirst.Text, textBoxLast.Text, textBoxEmail.Text, textBoxTele.Text);
            }

            this.Close();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text != "" || textBoxFirst.Text != "" || textBoxLast.Text != "" || textBoxTele.Text != "")
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

        private void textBoxLast_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxLast.SelectAll();
        }
    }
}
