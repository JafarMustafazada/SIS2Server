using SIS2Server.BLL.DTO.StudentDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.Services.Implements;

public class StudentService : IStudentService
{
    IStudentRepo _repo { get; }

    public StudentService(IStudentRepo studentRepo)
    {
        this._repo = studentRepo;
    }

    // //
    public async Task CreateAsync(StudentCreateDto dto)
    {
        await this._repo.CreateAsync(dto.GetEntity());
        await this._repo.SaveAsync();
    }

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

    public async Task RemoveAsync(int id, bool soft = true)
    {
        Student entity = this._repo.CheckId(id, true).First();
        this._repo.Remove(entity, soft);

        await this._repo.SaveAsync();
    }

    public async Task UpdateAsync(int id, StudentCreateDto dto)
    {
        Student entity = this._repo.CheckId(id, true).First();
        entity = dto.GetEntity(entity);

        await this._repo.SaveAsync();
    }
}
