using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskManager
{
    public class TaskViewModel
    {
        private ObservableCollection<TaskItem> _taskCollections;

        public TaskViewModel()
        {
            _taskCollections = new ObservableCollection<TaskItem>();
        }

        public ObservableCollection<TaskItem> TaskCollections 
        {
            get { return _taskCollections; }
            set { _taskCollections= value; }
        }

        public TaskItem SelectedTask
        {
            get; set;
        }

        public ICommand AddTaskCommand
        {
            get { return new DelegateCommand(AddTask); }
        }

        public ICommand RemoveTaskCommand
        {
            get { return new DelegateCommand(RemoveTask); }
        }

        private void AddTask()
        {
            _taskCollections.Add(new TaskItem { TaskName = "newTask" });
        }

        private void RemoveTask()
        {
            
            var obj = SelectedTask;
        }
    }

    public class DelegateCommand : ICommand
    {
        private readonly Action execute;

        private readonly Func<bool> canExecute;

        public DelegateCommand(Action execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if (canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
