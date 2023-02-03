using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDirectorImageService
    {
        IResult Add(IFormFile file, DirectorImage directorImage);
        IResult Update(IFormFile file, DirectorImage directorImage);
        IResult Delete(int id);
        IDataResult<List<DirectorImage>> GetAll();
        IDataResult<List<DirectorImage>> GetByDirectorId(int directorId);
        IDataResult<DirectorImage> GetById(int id);

    }
}
