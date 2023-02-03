using Core.Entites.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<User> GoogleLogin(GoogleUser googleUser);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<User> UpdatePassword(UserForPasswordDto userForPasswordDto,string password);
    }
}
