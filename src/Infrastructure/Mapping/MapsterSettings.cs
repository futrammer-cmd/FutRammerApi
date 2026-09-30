using Mapster;
using FutRammerApi.Application.Academics.Lessons;
using FutRammerApi.Domain.Academics;

namespace FutRammerApi.Infrastructure.Mapping;

public class MapsterSettings
{
    public static void Configure()
    {
        // here we will define the type conversion / Custom-mapping
        // More details at https://github.com/MapsterMapper/Mapster/wiki/Custom-mapping

        // This one is actually not necessary as it's mapped by convention
        // TypeAdapterConfig<Product, ProductDto>.NewConfig().Map(dest => dest.BrandName, src => src.Brand.Name);

        // Season's own properties are already prefixed with "Season" (SeasonNameAra/SeasonNameEng),
        // so Mapster's default flattening convention (Season.NameAra -> SeasonNameAra) does not apply here.
        // Map explicitly so LessonDto.SeasonNameAra/SeasonNameEng are populated from the included Season navigation.
        TypeAdapterConfig<Lesson, LessonDto>.NewConfig()
            .Map(dest => dest.SeasonNameAra, src => src.Season != null ? src.Season.SeasonNameAra : null)
            .Map(dest => dest.SeasonNameEng, src => src.Season != null ? src.Season.SeasonNameEng : null);
    }
}