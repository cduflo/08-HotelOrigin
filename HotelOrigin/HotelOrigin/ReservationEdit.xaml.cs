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
    /// Interaction logic for ReservationEdit.xaml
    /// </summary>
    public partial class ReservationEdit : Window
    {
        Reservations temp { get; set; }
        int tempID;

        public ReservationEdit()
        {
            InitializeComponent();
        }
/*
        public ReservationEdit(Reservations x) : this()
        {
            InitializeComponent();
            this.temp = x;
            comboBoxCust.Items = temp.Customer;
            textBoxNum.Text = temp.RoomNumber.ToString();
            textBoxBeds.Text = temp.Beds.ToString();
            checkBox.IsChecked = temp.HasTV;
            tempID = temp.id;
        }
*/
    }
}
