namespace FutRammerApi.Application.Academics.Lessons;

public class LessonByCodeSpec : Specification<Lesson>, ISingleResultSpecification
{
    public LessonByCodeSpec(string lessonCode) =>
        Query.Where(l => l.LessonCode == lessonCode);
}
