using Microsoft.AspNetCore.Components;
using TaskTrackerWebApp.BusinessLogic;
using TaskTrackerWebApp.Models;

namespace TaskTrackerWebApp.Components
{
    public partial class CreateTask
    {
        [Inject]
        ITaskService TaskService { get; set; }

        [Parameter]
        public EventCallback OnTaskCreated { get; set; }
        
        [Parameter]
        public EventCallback<bool> OnVisibilityChanged { get; set; }

        [Parameter]
        public bool CreateTaskModalIsVisible { get; set; }

        private TaskModel TaskBeingCreated { get; set; } = new TaskModel();

        private async Task HandleSubmit()
        {
            await TaskService.Post(TaskBeingCreated);
            TaskBeingCreated = new TaskModel();
            OnTaskCreated.InvokeAsync();
        }

        private void CloseCreateTaskModal()
        {
            CreateTaskModalIsVisible = false;
            OnVisibilityChanged.InvokeAsync(false);
        }
    }
}