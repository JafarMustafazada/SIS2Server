﻿using SIS2Server.BLL.DTO.StudentDTO;
namespace SIS2Server.BLL.Services.Interfaces;

public interface IStudentService
{
    public IEnumerable<StudentGeneralDto> GetAll(string groupName = "-");
    public IEnumerable<StudentScoreDto> GetAllScore(int id);
    public IEnumerable<StudentAttendanceDto> GetAllAttendance(int id);
    public StudentDto GetById(int id);
    public Task CreateAsync(StudentCreateDto dto);
    public Task RemoveAsync(int id, bool soft = true);
    public Task UpdateAsync(int id, StudentCreateDto dto);
}
