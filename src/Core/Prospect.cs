using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TimeTracker.Model.Common;

namespace TimeTracker.Model
{
    public class Prospect : AuditableEntity<int>
    {
        //public int? ShopGroupId { get; set; }
        //public virtual ShopGroup ShopGroup { get; set; }
        [StringLength(200)]
        public string Name { get; set; }

        //// public virtual Category Category { get; set; }
        //public virtual Country Country { get; set; }

        //public virtual Theme Theme { get; set; }
        //public virtual List<Currency> Currency { get; set; }
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public List<Address> Contacts { get; set; }
        //public virtual List<Store> Stores { get; set; }
        //public virtual List<Employee> Employees { get; set; }
        //public virtual List<Contact> Contacts { get; set; }
        //public virtual List<Product> Products { get; set; }
        //public virtual List<Warehouse> Warehouses { get; set; }
        //public virtual List<Zone> Zones { get; set; }
        //public virtual List<CartRule> CartRoles { get; set; }
        //public virtual List<Supplier> Suppliers { get; set; }
        //public virtual List<Manufacturer> Manufacturers { get; set; }
        //public virtual List<TaxRulesGroup> TaxRulesGroups { get; set; }
        //public virtual List<Cms> Cms { get; set; }
        //public virtual List<Category> Categories { get; set; }
        //public virtual List<Carrier> Carriers { get; set; }
    }
}