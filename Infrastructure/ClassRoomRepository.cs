using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Infrastructure
{
    public class ClassRoomRepository : ICRUDRepository<ClassRoom, string> 
    {
        SchoolManagementDbContext _db;
        public ClassRoomRepository(SchoolManagementDbContext db)
        {
            _db = db;
        }

        public void Create(ClassRoom item)
        {
             _db.Classroom.Add(item);
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Delete(string standard)
        {
            var obj=_db.Classroom.FirstOrDefault(c=>c.Standard==standard);
            if(obj==null)
                return;
            _db.Classroom.Remove(obj);
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<ClassRoom> GetAll()
        {
            return _db.Classroom.ToList();
        }
        public ClassRoom GetDetails(string standard)
        {
            return _db.Classroom.FirstOrDefault(c=>c.Standard==standard);
        }

        public void Update(ClassRoom item)
        {
            var obj=_db.Classroom.FirstOrDefault(c=>c.Standard==item.Standard);
            if(obj==null)
                return;
                obj.Section=item.Section;
                _db.Entry(obj).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}