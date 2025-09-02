using MyFirstAPI.Models;

namespace MyFirstAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly List<Models.TaskModel> _users = new List<Models.TaskModel>();
        private static int count = 0;


        public List<Models.TaskModel> GetAllTasks()
        {
            return _users;
        }

        public void addTaskToList(string name, string descrition, string finishDate, string status,int priority)
        {
            Models.TaskModel response = new Models.TaskModel();
            response.Name = name;
            response.Descrition = descrition;
            response.Id = count++;
            response.FinishDate = finishDate;
            response.status = status;
            response.priority = priority;
            _users.Add(response);
        }

        public void removeTaskOfList(int Id)
        {
            foreach (Models.TaskModel response in _users)
            {
                if(response.Id == Id)
                {
                    _users.Remove(response);
                }
            }
        }
    }
}
