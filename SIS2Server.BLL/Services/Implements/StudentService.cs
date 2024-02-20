using SIS2Server.BLL.DTO.StudentDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.Services.Implements;

public class StudentService : GenericCUDService<Student, IStudentRepo, StudentCreateDto>, IStudentService
{
    IStudentRepo _repo { get; }

    public StudentService(IStudentRepo studentRepo) : base(studentRepo)
    {
        this._repo = studentRepo;
    }

    // //
    public IEnumerable<StudentGeneralDto> GetAll(string groupName = "-")
    {
        if (groupName == "-")
        {
            return StudentGeneralDto.SetEntities(this._repo.GetAll());
        }
        else
        {
            return StudentGeneralDto.SetEntities(this._repo.GetAll().Where(x => x.Group.Name == groupName));
        }
    }

    public StudentDto GetById(int id)
    {
        return StudentDto.SetEntities(this._repo.CheckId(id)).First();
    }

    public async Task UpdateAsync(int id, StudentCreateDto dto)
    {
        Student entity = this._repo.CheckId(id, true).First();
        if (entity.GroupId != dto.GroupId)
        {
            await this._repo.CreateFormerGroupLog(entity);
        }
        entity = dto.GetEntity(entity);

        await this._repo.SaveAsync();
    }
}
