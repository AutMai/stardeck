using Mapster;
using NavigationDTOs.Read;
using NavigationModel.Entities;

namespace NavigationAPI.Mapper;

public class MappingRegistration : IRegister {
    void IRegister.Register(TypeAdapterConfig config) {
        config.NewConfig<Galaxy, GalaxyDto>().BeforeMapping(e => Console.WriteLine("beforeMap"))
            .PreserveReference(true);
    }
}