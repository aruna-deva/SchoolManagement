using SchoolManagementSystem.Models;
using SchoolManagementSystem.Infrastructure;
namespace SchoolManagementSystem.Infrastructure
{
    public class TimeTableRepository : ICRUDRepository<TimeTable,string>
    {
        SchoolManagementDbContext _db;
        public TimeTableRepository(SchoolManagementDbContext db)      
        {
            _db = db;
        }

        public void Create(TimeTable item)
        {
             _db.Timetable.Add(item);
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            var obj=_db.Timetable.FirstOrDefault(c=>c.ClassId==id);
            if(obj==null)
                return;
            _db.Timetable.Remove(obj);
            _db.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<TimeTable> GetAll()
        {
            return _db.Timetable.ToList();
        }
        public TimeTable GetDetails(string id)
        {
            return _db.Timetable.FirstOrDefault(c=>c.ClassId==id);
        }

        public void Update(TimeTable item)
        {
            var obj=_db.Timetable.FirstOrDefault(c=>c.ClassId==item.ClassId);
            if(obj==null)
                return;
                obj.TimeTableId=item.TimeTableId;
                obj.TeacherId=item.TeacherId;
                obj.SessionNumber=item.SessionNumber;
                obj.Timings=item.Timings;
                
                _db.Entry(obj).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
