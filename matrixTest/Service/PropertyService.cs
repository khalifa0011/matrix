using matrixTest.Iservice;
using matrixTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrixTest.Service
{
    public class PropertyService : IPropertyService
    {
        private readonly MyDbContext context;
        public PropertyService(MyDbContext _context)
        {
            context = _context;
        }

        public int AddProperty(Property property)
        {
            context.Properties.Add(property);
            context.SaveChanges();
            return property.Id;
        }

        public int DeleteProperty(Property property)
        {
            context.Properties.Remove(property);
            context.SaveChanges();
            return property.Id;
        }

        public Property GetProperty(int Id)
        {
            return context.Properties.Where(c => c.Id == Id).FirstOrDefault();
        }

        public List<Property> GetPropertyList()
        {
            return context.Properties.ToList();
        }

        public int UpdateProperty(Property property)
        {
            context.Update(property);
            context.SaveChanges();
            return property.Id;
        }
    }
}
