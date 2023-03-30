using Business.Abstract;
using Business.Constants;
using Core.Entites.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entity.DTOs;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Cryptography;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMailService _mailService;
        private readonly ITokenHelper _tokenHelper;

        public UserManager(IUserDal userDal, IMailService mailService, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _mailService = mailService;
            _tokenHelper = tokenHelper;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(int userId)
        {
            _userDal.Delete(userId);
            return new SuccessResult(Messages.UserDeleted);
        }


        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.Id == userId));
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            byte[] passwordHash, passwordSalt;
            var user = _userDal.Get(u => u.Email == updatePasswordDto.Email);
            if (user is not null)
            {

                if (updatePasswordDto.Password.Equals(updatePasswordDto.ConfirmPassword))
                {
                    HashingHelper.CreatePasswordHash(updatePasswordDto.Password, out passwordHash, out passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    _userDal.Update(user);
                    return new SuccessResult(Messages.UserPasswordUpdated);
                }
                return new ErrorResult(Messages.PasswordError);

            }
            return new ErrorResult(Messages.UserNotFound);
        }

        public IResult UpdateUserName(UserForNameDto userForNameDto)
        {
            var updatedUser = _userDal.Get(u => u.Id == userForNameDto.userId);
            updatedUser.FirstName = userForNameDto.FirstName;
            updatedUser.LastName = userForNameDto.LastName;
            _userDal.Update(updatedUser);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult VerifyResetToken(VerifyResetTokenDto verifyResetTokenDto)
        {
            var user = _userDal.Get(u => u.SecurityStamp == verifyResetTokenDto.ResetToken);
            if (user is null)
                return new ErrorResult(Messages.UserNotFound);
            else
            {
                string resetToken = GenerateResetToken();
                user.SecurityStamp = resetToken; _userDal.Update(user);
                return new SuccessResult();

            }
        }
        public async Task<IResult> ForgotPassword(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if (user is null)
                return new ErrorResult(Messages.UserNotFound);
            else
            {
                string resetToken = GenerateResetToken();
                await _mailService.SendForgotPasswordAsync(email, email, resetToken);
                user.SecurityStamp = resetToken;
                _userDal.Update(user);
                return new SuccessResult("Mail Gönderildi");
            }
        }

        private string GenerateResetToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return WebEncoders.Base64UrlEncode(randomNumber);
            }
        }
    }
}
