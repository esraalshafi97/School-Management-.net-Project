
using Microsoft.EntityFrameworkCore;
using schoolManagmentAPI.Data.Entities;

namespace school.Services
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<Subject>> GetSubjectsAsync();
        Task<Subject?> GetSubjectAsync(int id,bool includeTeacher);
        Task<IEnumerable<Teacher>> GetTeachersForSubjectAsync(int subjectId);
        Task<IEnumerable<Teacher>> GetTeachersAsync();
        Task<Teacher> GetTeacher(int teacherId);
        Task<Teacher?> GetTeacherForSubjectAsync(int subjectId,int id);
        Task<bool> SubjectExistsAsync(int id);
        Task<bool> TeacherExistsAsync(int id);
        Task AddTeacherForSubjectAsync(int subjectId, Teacher teacher);
        void AddTeacher( Teacher teacher);
        void AddSubject( Subject subject);
        public Task<Subject> GetSubject(int subjectId);
        void DeleteTeacher(Teacher teacher);
        void DeleteSubject(Subject subject);


        Task<bool> IsUserValid(String userName, String password);

        public  Task<bool> SaveChangesAsync();

    }
}
