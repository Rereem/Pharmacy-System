using Pharmacy.Services.Data;
using Pharmacy1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pharmacy1
{
    /// <summary>
    /// Interaction logic for EditCompany.xaml
    /// </summary>
    public partial class EditCompany : Window
    {


        public Company Company
        {
            get { return (Company)GetValue(CompanyProperty); }
            set { SetValue(CompanyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Company.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompanyProperty =
            DependencyProperty.Register("Company", typeof(Company), typeof(EditCompany), new PropertyMetadata(null));


        PharmDB db => App.db;
        public EditCompany()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grdMain.BindingGroup.CommitEdit();

            db.SaveChanges();
            MessageBox.Show("Edited successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


            DialogResult = true;
        }
    }
}
