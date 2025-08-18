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

namespace Pharmacy1
{
    /// <summary>
    /// Interaction logic for AddCompany.xaml
    /// </summary>
    public partial class AddCompany : Window
    {
        PharmDB db => App.db;
        public AddCompany()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var comp = Resources["Company"] as Company;
            if (comp != null)
            {
                db.Companies.Add(comp);
                db.SaveChanges();
                MessageBox.Show("Addtion successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }


            DialogResult = true;
        }
    }
}
