using Core.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ContentAdded = "Content Eklendi !";
        internal static string ContentDeleted = "Content Silindi";
        internal static string ContentUpdated = "Content Güncellendi";
        internal static string CategoryAdded = "Category Eklendi";
        internal static string CategoryDeleted = "Category Silindi";
        internal static string CategoryUpdated = "Category Güncellendi";
        internal static string DirectorAdded = "Director Eklendi";
        internal static string DirectorDeleted = "Director Silindi";
        internal static string DirectorUpdated = "Director Güncellendi";
        internal static string StarUpdated = "Star Güncellendi";
        internal static string StarDeleted = "Star Silindi";
        internal static string StarAdded = "Star Eklendi";
        internal static string PosterAdded = "Poster Eklendi";
        internal static string PosterAny = "Poster yok";
        internal static string PosterDeleted = "Poster Silindi";
        internal static string StarImageDeleted = "Star Resmi Silindi";
        internal static string UserRegistered = "Kullanıcı kayıt oldu";
        internal static string UserNotFound = "Kullanıcı Bulunamadı";
        internal static string PasswordError = "Şifre Hatalı";
        internal static string SuccessfulLogin = "Giriş Başarılı";
        internal static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        internal static string AccessTokenCreated = "Token oluştu";
        internal static string AuthorizationDenied = "Giriş Yapılmadı!";
        internal static string UserAdded = "Kullanıcı Eklendi";
        internal static string DirectorImageAdded;
        internal static string DirectorImageDeleted;
        internal static string DirectorImageUpdated;
        internal static string DirectorImageAny;
        internal static string UserDeleted;
        internal static string UserUpdated;
        internal static string UserPasswordUpdated;
        internal static string watchListAdded = "Added to Watch List !";
        internal static string watchListDeleted = "Deleted to Watch List !";
        internal static string watchListAlreadyExist = "Watchlist Already Exist !";
        internal static string watchListUpdated;
        internal static string CommentAdded;
        internal static string CommentDeleted;
    }
}
