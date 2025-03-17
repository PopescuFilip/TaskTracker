namespace TaskAPI.Models
{
    public enum Status
    {
        ToDo,
        InProgress,
        Completed
    }
    public class TaskModel : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; }

    }
}
