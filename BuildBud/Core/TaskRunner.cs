using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuildBud.Core
{
    internal class TaskRunner : MarshalByRefObject
    {
        private ITaskLogger _log = null;
        public void SetLog(ITaskLogger log)
        {
            _log = log;
        }

        public bool RunTasks(string assemblyPath)
        {
            _log?.LogMessage($"BuildBud: loading assembly \"{assemblyPath}\".");

            var assy = Assembly.LoadFrom(assemblyPath);
            var tasks = assy.GetTypes().Where(t => typeof(BuildTask).IsAssignableFrom(t)).ToArray();

            _log?.LogMessage($"BuildBud: Loaded. Found \"{tasks.Length}\" tasks.");

            foreach (var taskType in tasks)
            {
                _log?.LogMessage($"BuildBud: Running task \"{taskType.FullName}\".");
                var task = (BuildTask)Activator.CreateInstance(taskType);

                task.Log = _log;

                if (!task.Execute())
                {
                    _log?.LogError($"BuildBud: Task returned failure status code \"{taskType.FullName}\". Halting execution.");
                    return false;
                }
            }

            return true;
        }
    }
}
