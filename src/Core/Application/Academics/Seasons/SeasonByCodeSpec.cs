namespace FutRammerApi.Application.Academics.Seasons;

public class SeasonByCodeSpec : Specification<Season>, ISingleResultSpecification
{
    public SeasonByCodeSpec(string seasonCode) =>
        Query.Where(s => s.SeasonCode == seasonCode);
}
