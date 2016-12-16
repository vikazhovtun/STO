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

namespace STO
{
    /// <summary>
    /// Interaction logic for client.xaml
    /// </summary>
    public partial class client : Window
    {
        STOEntities db;
        public client()
        {
            InitializeComponent();
        }
        private void adding(object sender, RoutedEventArgs e)
        {
            db = new STOEntities();
            int result;
            if (!Int32.TryParse(phone.Text, out result))
            {
                MessageBox.Show("Please enter numeric value in field 'Phone number' (even without symbols)", "Adding Client", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            cClient new_client = new cClient
            {
                Full_Name = name.Text,
                Phone_Number = phone.Text,
            };
            db.cClient.Add(new_client);
            db.SaveChanges();
            MessageBox.Show("Client will be added. Please update table.", "Adding Client", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
