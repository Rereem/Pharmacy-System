using Pharmacy.Services;
using Pharmacy.Services.Data;
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
    public partial class AddCompanyWin : Window
    {
        PharmDB db => App.db; 
        CompanyService cs;
        public AddCompanyWin()
        {
            InitializeComponent();
            cs = new CompanyService(db);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var comp = Resources["Company"] as Company;
            if (comp != null)
            {
                cs.AddCompany(comp);
                MessageBox.Show("Addtion successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }


            DialogResult = true;
        }


    }
}
