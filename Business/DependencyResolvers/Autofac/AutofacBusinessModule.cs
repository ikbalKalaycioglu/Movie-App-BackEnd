using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContentManager>().As<IContentService>().SingleInstance();
            builder.RegisterType<EfContentDal>().As<IContentDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<DirectorManager>().As<IDirectorService>().SingleInstance();
            builder.RegisterType<EfDirectorDal>().As<IDirectorDal>().SingleInstance();

            builder.RegisterType<DirectorImageManager>().As<IDirectorImageService>().SingleInstance();
            builder.RegisterType<EfDirectorImageDal>().As<IDirectorImageDal>().SingleInstance();

            builder.RegisterType<PosterManager>().As<IPosterService>().SingleInstance();
            builder.RegisterType<EfPosterDal>().As<IPosterDal>().SingleInstance();

            builder.RegisterType<WatchListManager>().As<IWatchListService>().SingleInstance();
            builder.RegisterType<EfWatchListDal>().As<IWatchListDal>().SingleInstance();

            builder.RegisterType<StarManager>().As<IStarService>().SingleInstance();
            builder.RegisterType<EfStarDal>().As<IStarDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<StarImageManager>().As<IStarImageService>().SingleInstance();
            builder.RegisterType<EfStarImageDal>().As<IStarImageDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
