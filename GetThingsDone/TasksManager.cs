using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GetThingsDone
{
    public  class TasksManager : IEnumerable<Task>
    {
        private IEnumerable<Task> _tasks;

        public TasksManager(IEnumerable<Task> tasks)
        {
            _tasks = tasks;
        }

        public IEnumerable<Task> GetTasks()
        {
            return _tasks;
        }

        public bool Add(string title)
        {
            var tasksNames = _tasks.Select(t => t.Title);
            if (tasksNames.Contains(title))
                return false;

            _tasks = _tasks.Append(new Task() {Title = title});
            return true;
        }

        public bool Remove(string title)
        {
            var temp = _tasks;
            _tasks = _tasks.Where(t => t.Title != title);
            return temp.Equals(_tasks);
        }

        public IEnumerator<Task> GetEnumerator()
        {
            return _tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
