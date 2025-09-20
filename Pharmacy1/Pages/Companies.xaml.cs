using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pharmacy1.Pages
{
    /// <summary>
    /// Interaction logic for Companies.xaml
    /// </summary>
    public partial class Companies : Page
    {
        
        PharmDB db => App.db; //is not set only get
        private CollectionViewSource compviewsource;
   
        CompanyService comp;
        public Companies()
        {
            InitializeComponent();
            compviewsource = (CollectionViewSource)FindResource(nameof(compviewsource));
            comp = new CompanyService(db);
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
            db.Companies.Load();
            db.Items.Load();
         
            compviewsource.Source = db.Companies.Local.ToObservableCollection();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
           AddCompanyWin addCompanyWin = new AddCompanyWin();
            addCompanyWin.ShowDialog();
      
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Company company)
            {
                EditCompany editCompany = new EditCompany();
                editCompany.Company = company;
                editCompany.ShowDialog();
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            String searchText = Search.Text;
            dataGrid.ItemsSource = comp.SearchCompany(searchText);
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            try 
            { 
                if (dataGrid.SelectedItem is Company company)
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        comp.DeleteCompany(company.Id);
                    }
                }
            }
            catch (Exception ex) //handles the exception thrown from else in DeleteCompany Method in CompanyService
            {
                MessageBox.Show(ex.Message, "Fail", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
