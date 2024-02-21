using Microsoft.EntityFrameworkCore;
using SIS2Server.BLL.DTO.SubjectDTO;
using SIS2Server.BLL.DTO.TeacherDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.StudentRelated;
using SIS2Server.Core.Entities.UserRelated;

namespace SIS2Server.BLL.Services.Implements;

public class TeacherService : GenericCUDService<Teacher, ITeacherRepo, TeacherCreateDto>, ITeacherService
{
    ITeacherRepo _repo { get; }
    ISubjectRepo _subjectRepo { get; }
    IStudentSubjectScoreRepo _scoreRepo { get; }
    IStudentSubjectAttendanceRepo _attendanceRepo { get; }

    public TeacherService(ITeacherRepo repo,
        ISubjectRepo subjectRepo,
        IStudentSubjectScoreRepo studentSubjectScoreRepo,
        IStudentSubjectAttendanceRepo studentAttendanceRepo) : base(repo)
    {
        this._repo = repo;
        this._subjectRepo = subjectRepo;
        this._scoreRepo = studentSubjectScoreRepo;
        this._attendanceRepo = studentAttendanceRepo;
    }

    // //
    public async Task AddSubjectAsync(int techerId, int subjectId, bool remove = false)
    {
        this._subjectRepo.CheckId(subjectId);

        if (remove)
        {
            await this._repo.RemoveSubject(techerId, subjectId);
        }
        else
        {
            await this._repo.AddSubject(techerId, subjectId);
        }
    }

    public IEnumerable<TeacherGeneralDto> GetAll()
    {
        return TeacherGeneralDto.SetEntities(this._repo.GetAll());
    }

    public TeacherDto GetById(int id)
    {
        return TeacherDto.SetEntities(this._repo.CheckId(id)).First();
    }

    public bool ConfirmTeacher(string username, int subjectId, int studentId)
    {
        return (this._repo.Table
            .Where(t => t.UserTeachers.Any(ut => ut.AppUser.UserName == username))
            .Where(t => t.TeacherSubjects.Any(ts => ts.SubjectId == subjectId))
            .Where(t => t.TeacherGroups.Any(tg => tg.Group.Students.Any(s => s.Id == studentId)))
            .Select(t => t).Count() > 0);
    }

    public async Task ModifyScore(SubjectScoreDto dto)
    {
        StudentSubjectScore entity = await this._scoreRepo.GetAll(false)
            .Where(e => e.SubjectId ==  dto.SubjectId && e.StudentId == dto.StudentId)
            .SingleOrDefaultAsync();

        if (entity == null)
        {
            await this._scoreRepo.CreateAsync(dto.GetEntity());
        }
        else
        {
            entity = dto.GetEntity(entity);
        }

        await this._scoreRepo.SaveAsync();
    }

    public async Task ModifyAttendanc(SubjectAttendanceDto dto)
    {
        StudentSubjectAttendance entity = await this._attendanceRepo.GetAll(false)
            .Where(e => e.SubjectId == dto.SubjectId && e.StudentId == dto.StudentId)
            .SingleOrDefaultAsync();

        if (entity == null)
        {
            await this._attendanceRepo.CreateAsync(dto.GetEntity());
        }
        else
        {
            entity = dto.GetEntity(entity);
        }

        await this._attendanceRepo.SaveAsync();
    }
}
