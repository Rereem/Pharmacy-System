using Pharmacy1.Data;
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

namespace Pharmacy1.Pages
{
    /// <summary>
    /// Interaction logic for AddSupplier.xaml
    /// </summary>
    public partial class AddSupplierWnd : Window
    {
        PharmDB db => App.db;
        public AddSupplierWnd()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sup = Resources["Supplier"] as Supplier;
            if (sup != null)
            {
                db.Suppliers.Local.Add(sup);
                db.SaveChanges();
                MessageBox.Show("Addtion successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }


            DialogResult = true;
        }
    }
}
