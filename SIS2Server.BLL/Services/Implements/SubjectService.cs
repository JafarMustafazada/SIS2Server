﻿using SIS2Server.BLL.DTO.SubjectDTO;
using SIS2Server.BLL.Repositories.Interfaces;
using SIS2Server.BLL.Services.Interfaces;
using SIS2Server.Core.Entities.SubjectRelated;

namespace SIS2Server.BLL.Services.Implements;

public class SubjectService : GenericCUDService<Subject, ISubjectRepo, SubjectCreateDto>, ISubjectService
{
    ISubjectRepo _repo { get; }

    public SubjectService(ISubjectRepo repo) : base(repo)
    {
        this._repo = repo;
    }

    // //
    public IEnumerable<SubjectDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public SubjectDto GetById(int id)
    {
        throw new NotImplementedException();
    }
}
