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
    /// Interaction logic for detail.xaml
    /// </summary>
    public partial class detail : Window
    {
        STOEntities db;
        public detail()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db = new STOEntities();
            cDetail new_detail = new cDetail
            {
                Name = name.Text,
                Available_Amount = Int32.Parse(amount.Text)
            };
            db.cDetail.Add(new_detail);
            db.SaveChanges();
            MessageBox.Show("Detail will be added. Please update table.", "Adding Detail", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
