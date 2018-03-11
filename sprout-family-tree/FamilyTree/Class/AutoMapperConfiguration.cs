using System.Globalization;
using AutoMapper;
using FamilyTree.Class.Converter;
using FamilyTree.Domain.Model;
using FamilyTree.ViewModel;

namespace FamilyTree.Class
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            ConfigurePersonMapping();
        }

        private static void ConfigurePersonMapping()
        {
            var sexConv = new SexConverter();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PersonModel, PersonViewModel>()
                    .ForMember(d => d.Sex,
                        opt => opt
                            .MapFrom(src => sexConv.Convert(src.Sex, null, null, CultureInfo.CurrentCulture)))
                    .ForMember(
                        d => d.Appearance,
                        opt => opt
                            .MapFrom(src => src.Appearance));
            });
        }

    }
}
