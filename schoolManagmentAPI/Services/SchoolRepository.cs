
using Microsoft.EntityFrameworkCore;
using schoolManagmentAPI.Data;
using schoolManagmentAPI.Data.Entities;

namespace school.Services
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolContext _schoolContext;
        public SchoolRepository(SchoolContext context) {
            _schoolContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddTeacherForSubjectAsync(int subjectId, Teacher teacher)
        {
            var value = await GetSubjectAsync(subjectId, false);
            if (value != null)
            {
                value.Teachers.Add(teacher);
            }
        }
        public void AddTeacher(Teacher teacher)
        {

            _schoolContext.Teachers.Add(teacher);
            
        }
        public void DeleteTeacher(Teacher teacher)
        {

            _schoolContext.Teachers.Remove(teacher);
            
        }
        public void DeleteSubject(Subject subject)
        {

            _schoolContext.Subjects.Remove(subject);
            
        }

        public async Task<Subject?> GetSubjectAsync(int id, bool includeTeacher)
        {
            if (includeTeacher)
            {
                return await _schoolContext.Subjects.Include(c => c.Teachers).Where(c => c.SubjectId == id).FirstOrDefaultAsync();
            }
            return await _schoolContext.Subjects.Where(e => e.SubjectId == id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Subject>> GetSubjectsAsync()
        {
            return await _schoolContext.Subjects.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Teacher?> GetTeacherForSubjectAsync(int SubjectId, int TeacherId)
        {
            return await _schoolContext.Teachers.Where(c => c.SubjectId == TeacherId && c.SubjectId == SubjectId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeachersForSubjectAsync(int subjectId)
        {
            return await _schoolContext.Teachers.Include(c=>c.Subject).Where(c => c.SubjectId == subjectId).ToListAsync();
        }

        public async Task<bool> SubjectExistsAsync(int id)
        {
            return await _schoolContext.Subjects.AnyAsync(c => c.SubjectId == id);
        }


        public async Task<bool> TeacherExistsAsync(int id)
        {
            return await _schoolContext.Teachers.AnyAsync(c => c.SubjectId == id);

        }


        public async Task<Teacher> GetTeacher(int teacherId)
        {
            return await _schoolContext.Teachers.FirstOrDefaultAsync(c => c.SubjectId == teacherId);
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            return await _schoolContext.Teachers.ToListAsync();

        }

        public async Task<bool> IsUserValid(string userName, string password)
        {
            return await _schoolContext.Users.AnyAsync(e => e.UserName == userName && e.Password == password);
        }

        public void AddSubject(Subject subject)
        {
            _schoolContext.Subjects.Add(subject);
        }

        public async Task<Subject> GetSubject(int subjectId)
        {
            return await _schoolContext.Subjects.FirstOrDefaultAsync(c => c.SubjectId == subjectId);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _schoolContext.SaveChangesAsync() >= 0);
        }

    }
}
