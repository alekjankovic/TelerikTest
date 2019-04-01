using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikTest02.Data;

namespace TelerikTest02.Models.HelperModels
{
    public class CategoryEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        ApplicationDbContext _context;

        public CategoryEditModel(ApplicationDbContext context) {
            _context = context;
            Id = 0;
            Name = "";
        }

        public CategoryEditModel(ApplicationDbContext context, Categories model) {
            _context = context;

            if (model == null)
                throw new NoNullAllowedException("Null not allowed");
            Id = 0;
            Name = model.Name;
        }

        public int AddNew() {

            Categories model = new Categories();
            model.Name = Name;

            try
            {
                _context.Categories.Add(model);
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
