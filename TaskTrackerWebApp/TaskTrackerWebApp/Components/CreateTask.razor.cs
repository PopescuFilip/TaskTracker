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
        public bool showErrorMessage;

        private TaskModel TaskBeingCreated { get; set; } = new TaskModel();

        private async Task HandleSubmit()
        {
            var result = await TaskService.Post(TaskBeingCreated);
            if (!result)
                showErrorMessage = true;
            else
                showErrorMessage = false;
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