using MyEshop.Models;

namespace MyEshop.Data.Repositories
{
    public interface IGroupRepository
    {

        IEnumerable<Category> GetAllCategories();
        IEnumerable<ShowGroupViewModel> GetGroupForShow();

    }

    public class GroupRepository : IGroupRepository
    {
       private MyEshopContext _context;

        public GroupRepository(MyEshopContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShowGroupViewModel> GetGroupForShow()
        {
            return _context.Categories
                      .Select(c => new ShowGroupViewModel()
                      {
                          GroupId = c.Id,
                          Name = c.Name,
                          ProductCount = _context.categoryToProducts.Count(g => g.CategoryId == c.Id)
                      }).ToList();
        }
    }
}
