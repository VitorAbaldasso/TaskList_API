using MyFirstAPI.Models;

namespace MyFirstAPI.Services
{
    public interface IUserServices
    {
        List<Models.TaskModel> GetAllTasks();

        void addTaskToList(string name, string descrition, string finishDate, string status, int priority);

        void removeTaskOfList(int id);

    }
}
