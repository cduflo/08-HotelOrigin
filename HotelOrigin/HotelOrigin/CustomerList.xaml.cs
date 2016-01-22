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
    /// Interaction logic for CustomerList.xaml
    /// </summary>
    public partial class CustomerList : Window
    {

        public CustomerList()
        {
            InitializeComponent();
            dataGridCustomers.ItemsSource = HotelOrigin.Core.Repository.CustomerRepository.customers;
            dataGridCustomers.IsReadOnly = true;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            CustomerAdd custaddwin = new CustomerAdd();
            custaddwin.ShowDialog();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridCustomers.SelectedItem == null)
            { return; }
            Customer selected = dataGridCustomers.SelectedItem as Customer;
            CustomerRepository.customers.Remove(selected);
        }

        private void dataGridCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Customer selected = dataGridCustomers.SelectedItem as Customer;
            if (selected.id <1)
            
            { return; }

                CustomerEdit editWin = new CustomerEdit(selected);
                editWin.Owner = this;
                editWin.ShowDialog();
        }

        public void RefreshGrid()
        {
            dataGridCustomers.CommitEdit();
            dataGridCustomers.CommitEdit();
            dataGridCustomers.Items.Refresh();
        }
    }
}
