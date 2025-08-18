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
        PharmDB db => App.db;
        private CollectionViewSource compviewsource;
        public Companies()
        {
            InitializeComponent();
            compviewsource = (CollectionViewSource)FindResource(nameof(compviewsource));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            //dataGrid.Companies.Refresh();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
//            edb.Database.EnsureCreated();
            db.Companies.Load();
            compviewsource.Source = db.Companies.Local.ToObservableCollection();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            AddCompany addCompany = new AddCompany();
            addCompany.ShowDialog();
      
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {

        }

    }
}
