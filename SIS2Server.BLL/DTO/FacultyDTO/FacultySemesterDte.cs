namespace SIS2Server.BLL.DTO.FacultyDTO;

public class FacultySemesterDte
{
    public int Semester { get; set; }
    public IEnumerable<FacultySubjectDte> FacultySubjects { get; set; }
}
