using Microsoft.AspNetCore.Components;
using TaskTrackerWebApp.BusinessLogic;
using TaskTrackerWebApp.Models;

namespace TaskTrackerWebApp.Components.Pages
{
    public partial class TasksPage
    {
        [Inject]
        ITaskService TaskService { get; set; }

        private bool IsCreateTaskModalVisible { get; set; }

        private List<TaskModel>? Tasks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskService.GetAll();
        }

        private async void HandleTaskCreated()
        {
            Tasks = await TaskService.GetAll();
            CloseCreateTaskModal();
        }

        private void HandleCreateModelVisibility(bool isVisible)
        {
            IsCreateTaskModalVisible = isVisible;
            StateHasChanged();
        }

        private void CloseCreateTaskModal()
		{
            IsCreateTaskModalVisible = false;
		}

		private void ShowCreateTaskModal()
		{
			IsCreateTaskModalVisible = true;
		}

        private void OnRowSelect()
        {

        }
    }
}