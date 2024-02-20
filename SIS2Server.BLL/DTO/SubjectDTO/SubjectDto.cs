using SIS2Server.BLL.DTO.Common;
using SIS2Server.Core.Entities.SubjectRelated;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.DTO.SubjectDTO;

public class SubjectDto : IBaseDto<Subject>
{
    public int Id { get; set; }
    public string Name { get; set; }

    // //
    public Subject GetEntity(Subject entity = null)
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<SubjectDto> SetEntities(IQueryable<Subject> querry)
    {
        return querry.Select(x => new SubjectDto
        {
            Id = x.Id,
            Name = x.Name,
        });
    }

    public static IEnumerable<SubjectDto> SetEntities(IEnumerable<Subject> entities)
    {
        return entities.Select(x => new SubjectDto
        {
            Id = x.Id,
            Name = x.Name,
        });
    }
}
