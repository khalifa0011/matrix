using matrixTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrixTest.Iservice
{
    public interface IPropertyService
    {
        int AddProperty(Property property);
        List<Property> GetPropertyList();
        Property GetProperty(int Id);
        int UpdateProperty(Property property);
        int DeleteProperty(Property property);
    }
}
