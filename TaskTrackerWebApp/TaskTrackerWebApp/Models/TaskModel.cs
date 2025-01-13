namespace TaskTrackerWebApp.Models
{
    public class TaskModel
    {
        public const string ToDo = "To do";
        public const string InProgress = "In progress";
        public const string Completed = "Completed";

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string AssignedTo { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public TaskModel()
        {
            Id = Guid.NewGuid();
            Status = ToDo;
        }
    }
}
