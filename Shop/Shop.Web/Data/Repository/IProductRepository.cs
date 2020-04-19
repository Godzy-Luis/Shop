using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Web.Data
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();
        IEnumerable<SelectListItem> GetComboProducts();
    }

}
