using Abigo.Communication.Requests;
using Abigo.Communication.Responses.Accountable;
using Abigo.Communication.Responses.AvailableLocales;
using Abigo.Domain.Entities;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Abigo.Application.AutoMapper
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            RequestToEntity();
            EntityToResposne();
        }
        private void RequestToEntity()
        {
            CreateMap<AvailableLocalesRequestJson, AvailableLocalesEntity>();
            CreateMap<AccountableRequestJson, AccountableEntity>();
        }
        private void EntityToResposne()
        {
            CreateMap<AccountableEntity, AccountableDetailedResponse>();
            CreateMap<AccountableEntity, AccountableShortResponseJson>();
            CreateMap<AvailableLocalesEntity, AvailableLocalesDetailedResponseJson>();
            CreateMap<AvailableLocalesEntity, AvailableLocalesShortResponseJson>();
          
        }
    }
}