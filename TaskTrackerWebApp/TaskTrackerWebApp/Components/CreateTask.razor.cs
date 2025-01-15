using Microsoft.AspNetCore.Components;
using TaskTrackerWebApp.BusinessLogic;
using TaskTrackerWebApp.Models;

namespace TaskTrackerWebApp.Components
{
    public partial class CreateTask
    {
        [Inject]
        ITaskService TaskService { get; set; }

        [Inject]
        IUserService UserService { get; set; }

        [Parameter]
        public EventCallback OnTaskCreated { get; set; }

        [Parameter]
        public EventCallback<bool> OnVisibilityChanged { get; set; }

        [Parameter]
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                if (value)
                    SetUsers();
                _isVisible = value;
            }
        }

        private bool _isVisible;
        private bool showErrorMessage;
        private List<string> users;

        private TaskModel TaskBeingCreated { get; set; } = new TaskModel();

        protected override async Task OnInitializedAsync()
        {
            await SetUsers();
        }

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
            IsVisible = false;
            OnVisibilityChanged.InvokeAsync(false);
        }

        private async Task SetUsers()
        {
            users = (await UserService.GetAll()).Select(u => u.Name).ToList();
            StateHasChanged();
        }
    }
}