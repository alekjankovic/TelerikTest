using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikTest02.Data;

namespace TelerikTest02.Models.HelperModels
{
    public class ProductEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ValidFrom { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }

        ApplicationDbContext _context;

        public ProductEditModel(ApplicationDbContext context) {
            _context = context;

            Id = 0;
            Name = "";
            ValidFrom = "";
            Quantity = 0;
            Price = 0;
            CategoryId = 0;
        }

        public ProductEditModel(ApplicationDbContext context, Products model)
        {
            _context = context;

            if (model == null)
                throw new System.Data.NoNullAllowedException("Null not allowed");

            Id = 0;
            Name = model.Name;
            ValidFrom = model.ValidFrom;
            Quantity = model.Quantity;
            Price = model.Price;
            CategoryId = model.CategoryId;
        }


        public int AddNew()
        {

            Products model = new Products();
            model.Name = Name;
            model.ValidFrom = ValidFrom;
            model.Quantity = Quantity;
            model.Price = Price;
            model.CategoryId = CategoryId;

            try
            {
                _context.Products.Add(model);
                var result = _context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                var a = ex;
                return 1;
            }

        }







    }
}
