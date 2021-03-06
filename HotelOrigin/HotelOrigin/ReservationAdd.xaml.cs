﻿using System;
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
using System.Collections.ObjectModel;

namespace HotelOrigin
{
    /// <summary>
    /// Interaction logic for ReservationAdd.xaml
    /// </summary>
    public partial class ReservationAdd : Window
    {
        public ReservationAdd()
        {
            InitializeComponent();
            comboBoxCust.ItemsSource = HotelOrigin.Core.Repository.CustomerRepository.customers;
            comboBoxCust.DisplayMemberPath = "lastName";
            comboBoxRoom.ItemsSource = HotelOrigin.Core.Repository.RoomRepository.rooms;
            comboBoxRoom.DisplayMemberPath = "RoomNumber";
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            DateTime ci = checkInDatePicker.SelectedDate ?? DateTime.Now;
            DateTime co = checkOutDatePicker.SelectedDate ?? DateTime.Now;

            if (comboBoxCust.SelectedItem == null || comboBoxRoom.SelectedItem == null || checkInDatePicker.SelectedDate == null || checkOutDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please enter all fields before submitting.");
            }
            else if (dateCheck(ci, co) == false)
            {
                MessageBox.Show("Please ensure your Check-In Date is at least one day prior to your Check-Out Date.");
            }
            else
            {

                int f = Convert.ToInt32(comboBoxCust.SelectedValue.ToString());
                Customer x = CustomerRepository.GetByID(f);
                int j = Convert.ToInt32(comboBoxRoom.SelectedValue.ToString());
                Rooms y = RoomRepository.GetByID(j);
                ReservationRepository.Create(x, y, ci, co, textBoxNote.Text);

                this.Close();
            }

        }


        private bool dateCheck(DateTime ci, DateTime co)
        {
            if (ci >= co)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxCust.SelectedItem != null || comboBoxRoom.SelectedItem != null || checkInDatePicker.SelectedDate != null || checkOutDatePicker.SelectedDate != null)
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
