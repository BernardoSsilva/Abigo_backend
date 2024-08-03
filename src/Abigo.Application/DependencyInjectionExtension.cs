using Abigo.Application.AutoMapper;
using Abigo.Application.UseCases.Accountables.Delete;
using Abigo.Application.UseCases.Accountables.Delete.interfaces;
using Abigo.Application.UseCases.Accountables.Get;
using Abigo.Application.UseCases.Accountables.Get.interfaces;
using Abigo.Application.UseCases.Accountables.Post;
using Abigo.Application.UseCases.Accountables.Post.Interfaces;
using Abigo.Application.UseCases.Accountables.Put;
using Abigo.Application.UseCases.Accountables.Put.Interfaces;
using Abigo.Application.UseCases.AvailableLocales.Delete;
using Abigo.Application.UseCases.AvailableLocales.Delete.Interfaces;
using Abigo.Application.UseCases.AvailableLocales.get;
using Abigo.Application.UseCases.AvailableLocales.get.Interfaces;
using Abigo.Application.UseCases.AvailableLocales.Post;
using Abigo.Application.UseCases.AvailableLocales.Post.Interfaces;
using Abigo.Application.UseCases.AvailableLocales.Put;
using Abigo.Application.UseCases.AvailableLocales.Put.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Abigo.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {

            AddAutoMapper(service);
            AddUseCases(service);
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection service)
        {
            service.AddScoped<IUpdateAccountableUseCase, UpdateAccoutableUseCase>();
            service.AddScoped<IAuthenticateAccountUseCase, AuthenticateAccountUseCase>();
            service.AddScoped<IRegisterNewAccountUseCase, RegisterNewAccountUseCase>();
            service.AddScoped<IFindAccoutableByNameUseCase, FindAccoutableByNameUseCase>();
            service.AddScoped<IListAllAccountablesUseCase, ListAllAccoutablesUseCase>();
            service.AddScoped<ISearchAccountableByIdUseCase, SearchAccountableByIdUseCase>();
            service.AddScoped<IDeleteAccountableUseCase, DeleteAccountableUseCase>();
            service.AddScoped<IUpdateAvailableLocaleUseCase, UpdateAvailableLocaleUseCase>();
            service.AddScoped<IRegisterNewAvailableLocale, RegisterNewAvailableLocale>();
            service.AddScoped<IFindLocaleByIdUseCase, FindLocaleByIdUseCase>();
            service.AddScoped<IFIndAllAvailableLocalesUseCase, FindAllAvailablesLocalesUseCase>();
            service.AddScoped<IFindAllLocalesByCategoryUseCase, FIndAllLocalesByCategoryUseCase>();
            service.AddScoped<IFindAllLocalesInACityUseCase, FindAllLocalesInACityUseCase>();
           
            service.AddScoped<IFindLocaleByNameUseCase, FindLocaleByNameUseCase>();
            service.AddScoped<IFindAllLocalesByNeighborhoodUseCase, FindAllLocalesByNeighborhoodUseCase>();
            service.AddScoped<IFindLocalesByAccountUseCase, FindLocalesByAccountUseCase>();
            service.AddScoped<IDeleteAvailableLocaleUseCase, DeleteAvailableLocaleUseCase>();
        }
    }
}
