using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService
    {
        IDataResult<List<Content>> GetAll();
        IDataResult<int> Add(Content content);
        IResult Delete(int id);
        IResult Update(Content content);
        IDataResult<Content> GetById(int id);
        IDataResult<List<ContentDetailDto>> GetContentDetails();
        IDataResult<ContentDetailDto> GetContentById(int id);
        IDataResult<List<ContentDetailDto>> GetContentByCategoryId(int Categoryid);

    }
}
