using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
