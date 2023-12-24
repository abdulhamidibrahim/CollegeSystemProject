namespace CollegeSystem.DAL.Models;

public class PostUser
{
        public long PostUserId { get; set; }
        public long? PostId { get; set; }
        public long? StudentId { get; set; }
        public long? StaffId { get; set; }
        public virtual Post? Post { get; set; }
        public virtual Student? Student { get; set; }

        public virtual Staff? Staff { get; set; }
        
}