using Business.Abstract;
using Business.Constants;
using Core.Entites.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.DTOs;
using Google.Apis.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> GoogleLogin(GoogleUser googleUser)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { "266378806369-9tb21cto73n7303pnpuqboe842eh5fah.apps.googleusercontent.com" }
            };
            var payload = GoogleJsonWebSignature.ValidateAsync(googleUser.IdToken, settings);

            var userToCheck = _userService.GetByMail(googleUser.Email);
            if (userToCheck.Data == null)
            {
                var info = new User
                {
                    Email = googleUser.Email,
                    FirstName = googleUser.FirstName,
                    LastName = googleUser.LastName,
                    Status = true,
                };

                _userService.Add(info);
                return new SuccessDataResult<User>(info, Messages.UserRegistered);
            }
            return new SuccessDataResult<User>(userToCheck.Data, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            else if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> UpdatePassword(UserForPasswordDto userForPasswordDto, string newPassword)
        {
            //Business Rules
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
            var updatedUser = _userService.GetById(userForPasswordDto.UserId).Data;

            if (!HashingHelper.VerifyPasswordHash(userForPasswordDto.OldPassword, updatedUser.PasswordHash, updatedUser.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            if (!userForPasswordDto.NewPassword.Equals(userForPasswordDto.RepeatNewPassword))
            {
                return new ErrorDataResult<User>("Şifre tekrarı yanlış!");
            };

            updatedUser.PasswordHash = passwordHash;
            updatedUser.PasswordSalt = passwordSalt;

            _userService.Update(updatedUser);
            return new SuccessDataResult<User>(updatedUser, Messages.UserPasswordUpdated);
        }

        public IResult UserExists(string email)
        {
            var result = _userService.GetByMail(email).Data;
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.UserAlreadyExists);
        }
    }
}
