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
    /// Interaction logic for CustomerAdd.xaml
    /// </summary>
    public partial class CustomerEdit : Window
    {
        Customer tempCust { get; set; }
        int tempID;
        bool fieldsUpdated = false;

        public CustomerEdit()
        {
            InitializeComponent();
            
        }

        public CustomerEdit(Customer x) : this()
        {
            InitializeComponent();
            this.tempCust = x;
            textBoxFirst.Text = tempCust.firstName;
            textBoxLast.Text = tempCust.lastName;
            textBoxEmail.Text = tempCust.email;
            textBoxTele.Text = tempCust.tele;
            tempID = tempCust.id;
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            var custList = Owner as CustomerList;
            if (textBoxEmail.Text == "" || textBoxFirst.Text == "" || textBoxLast.Text == "" || textBoxTele.Text == "")
            {
                MessageBox.Show("Please ensure all fields are populated.");
                
            }
            else if (fieldsUpdated)
            {
                tempCust.firstName = textBoxFirst.Text;
                tempCust.lastName = textBoxLast.Text;
                tempCust.email = textBoxEmail.Text;
                tempCust.tele = textBoxTele.Text;

                custList.RefreshGrid();
                this.Close();   
            }
            else
            {
                this.Close();
            }
        }

        private void textBoxFirst_TextChanged(object sender, TextChangedEventArgs e)
        {
            fieldsUpdated = true;
        }

        private void textBoxLast_TextChanged(object sender, TextChangedEventArgs e)
        {
            fieldsUpdated = true;
        }

        private void textBoxEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            fieldsUpdated = true;
        }

        private void textBoxTele_TextChanged(object sender, TextChangedEventArgs e)
        {
            fieldsUpdated = true;
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
    }
}
