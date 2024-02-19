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
}
