using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.DTO.FacultyDTO;

public class FacultyDto : IBaseDto<Faculty>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<FacultySemesterDte> FacultySemesters { get; set; }

    // //
    public Faculty GetEntity(Faculty entity = null)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<FacultyDto> SetEntities(IQueryable<Faculty> querry)
    {
        return querry.Include(e => e.Groups)
            .Include(e => e.FacultySubjects).ThenInclude(e3 => e3.Subject)
            .Select(e => new FacultyDto
            {
                Id = e.Id,
                Name = e.Name,

                FacultySemesters = e.FacultySubjects.Select(e3 => e3.Semester).Distinct()
                .Select(x => new FacultySemesterDte
                {
                    Semester = x,
                    FacultySubjects = e.FacultySubjects.Where(e3 => e3.Semester == x)
                    .Select(e3 => new FacultySubjectDte
                    {
                        Id = e3.SubjectId,
                        Name = e3.Subject.Name
                    }),
                }),
            });
    }
}
