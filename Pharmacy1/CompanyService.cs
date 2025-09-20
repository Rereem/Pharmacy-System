using Microsoft.EntityFrameworkCore;
using Pharmacy1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Pharmacy1
{
  
    public class CompanyService
    {

        private  PharmDB db;

        public CompanyService(PharmDB _db) 
        {
            db = _db;
        }

    

        //// Gets all companies from the database
        //public List<Company> GetAllCompanies()
        //{
        //    return db.Companies.ToList();
        //}

        // Adds a new company to the database
        public void AddCompany(Company company)
        {
            db.Companies.Add(company);
            db.SaveChanges(); 
        }

        // Deletes a company by its ID
        public void DeleteCompany(int id)
        {
           
                var companyToDelete = db.Companies.Find(id);
                var itemCount = db.Items.Where(i => i.CompanyId == companyToDelete.Id).Count();
                if (companyToDelete != null && itemCount == 0)
                {
                    db.Companies.Remove(companyToDelete);
                    db.SaveChanges();
                }
                else //throws exception so the catch in button delete event handles it 
                {
                     throw new InvalidOperationException(
                            $"Cannot delete company '{companyToDelete.NameEn}'. " +
                            $"It is associated with {itemCount} item(s). " +
                            "Please reassign or delete the items first.");
            }
            
           
        }

        //Searches in the Company table
        public List<Company> SearchCompany(string searchText) 
        {
            return db.Companies.Local
                    .Where(comp =>
                    (comp.NameEn.ToLower().StartsWith(searchText) == true) ||
                    (comp.NameAr.ToLower().StartsWith(searchText) == true) ||
                    (comp.Code != null ? comp.Code.ToString() : string.Empty).ToLower().StartsWith(searchText))
                    .ToList();
        }
    }
}
