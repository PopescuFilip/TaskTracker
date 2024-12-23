namespace TaskTrackerWebApp.Models
{
    public class TaskModel
    {
        private const string ToDo = "To do";
        private const string InProgress = "In progress";
        private const string Completed = "Completed";

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; }

        public TaskModel()
        {
            Id = Guid.NewGuid();
            Status = ToDo;
        }
    }
}
