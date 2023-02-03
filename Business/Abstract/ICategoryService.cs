using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int id);
        IResult Add(Category category);
        IResult Delete(int id);
        IResult Update(Category category);
    }
}
