using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for AddItemPage.xaml
    /// </summary>
    public partial class AddItemPage : Page
    {

        private PharmDB db = new PharmDB();
        public AddItemPage()
        {
            InitializeComponent();
            LoadCompanyNames();
            //LoadItemOrigin();
            DataContext = this; // Important for binding
            ;
        }
    


     


        private void LoadCompanyNames()
        {
            try
            {
                var companies = db.Set<Company>().ToList();
                CompanyName.ItemsSource = companies;

                // Set initial selection if needed
                //if (companies.Any() && comp_Id > 0) // If editing existing item
                //{
                //    comp_name.SelectedValue = comp_Id;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading companies: {ex.Message}");
            }
        }

        //private void LoadItemOrigin()
        //{
        //    try
        //    {
        //        var origin = db.Origins.ToList();
        //        origin_name.ItemsSource = origin;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading companies: {ex.Message}");
        //    }
        //}

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var it = Resources["item"] as Item;
            if (it != null)
            {
                db.Items.Add(it);
                //db.SaveChanges();
                MessageBox.Show("Addtion successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }

            NavigationService.GoBack();
        }

        private void CompanyName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Unit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
