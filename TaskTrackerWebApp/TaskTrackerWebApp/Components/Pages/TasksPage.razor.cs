using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
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

        private RadzenDataGrid<TaskModel> taskGrid;
        private List<string> statusValues;
        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskService.GetAll();
            statusValues = [TaskModel.ToDo, TaskModel.InProgress, TaskModel.Completed];
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

        async Task EditRow(TaskModel task)
        {
            await taskGrid.EditRow(task);
        }

        void OnUpdateRow(TaskModel task)
        {
        }

        async Task SaveRow(TaskModel task)
        {
            await TaskService.Update(task.Id, task);
            await taskGrid.UpdateRow(task);
        }

        void CancelEdit(TaskModel task)
        {
            taskGrid.CancelEditRow(task);
        }

        private async Task DeleteRow(TaskModel task)
        {
            if (Tasks.Contains(task))
            {
                await TaskService.Delete(task.Id);
                Tasks.Remove(task);
            }
            else
                taskGrid.CancelEditRow(new TaskModel());

            await taskGrid.Reload();
        }

        private void OnCreateRow(TaskModel task)
        {
            //Tasks.Add(task);
        }
    }
}