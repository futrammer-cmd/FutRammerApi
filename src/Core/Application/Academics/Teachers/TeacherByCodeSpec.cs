namespace FutRammerApi.Application.Academics.Teachers;

public class TeacherByCodeSpec : Specification<Teacher>, ISingleResultSpecification
{
    public TeacherByCodeSpec(string teacherCode) =>
        Query.Where(t => t.TeacherCode == teacherCode);
}
