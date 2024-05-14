
using Microsoft.EntityFrameworkCore;
using schoolManagmentAPI.Data.Entities;

namespace school.Services
{
    public interface ISchoolRepository
    {
        Task<IEnumerable<Subject>> GetSubjectsAsync();
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Subject?> GetSubjectAsync(int id,bool includeTeacher);
        Task<IEnumerable<Teacher>> GetTeachersForSubjectAsync(int subjectId);
        Task<IEnumerable<Teacher>> GetTeachersAsync();
        Task<Teacher> GetTeacher(int teacherId);
        Task<Student> GetStudent(int student);
        Task<Teacher?> GetTeacherForSubjectAsync(int subjectId,int id);
        Task<bool> SubjectExistsAsync(int id);
        Task<bool> TeacherExistsAsync(int id);
        Task AddTeacherForSubjectAsync(int subjectId, Teacher teacher);
        void AddTeacher( Teacher teacher);
        void AddSubject( Subject subject);
        void AddStudent( Student student);
        public Task<Subject> GetSubject(int subjectId);
        void DeleteTeacher(Teacher teacher);
        void DeleteStudent(Student student);
        void DeleteSubject(Subject subject);


        Task<bool> IsUserValid(String userName, String password);

        public  Task<bool> SaveChangesAsync();

    }
}
