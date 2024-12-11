namespace TaskTrackerWebApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}
