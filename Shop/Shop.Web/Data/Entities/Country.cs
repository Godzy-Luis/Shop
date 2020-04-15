using Shop.Web.Data.Entities;

namespace Shop.Web.Data
{
    public class Country : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
