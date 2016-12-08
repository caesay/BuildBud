using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BuildBud.Core
{
    public class InternalTask : Microsoft.Build.Utilities.AppDomainIsolatedTask
    {
        public string AssemblyPath { get; set; }

        public override bool Execute()
        {
            if (!File.Exists(AssemblyPath))
            {
                Log.LogWarning($"BuildBud: could not find assembly at \"{AssemblyPath}\".");
                return true;
            }

            // potentially not nessesary anymore to create an appdomain here as this runs within the new AppDomainIsolatedTask
            AppDomain domain = AppDomain.CreateDomain(Guid.NewGuid().ToString());
            TaskRunner proxy = (TaskRunner)domain.CreateInstanceAndUnwrap("BuildBud", "BuildBud.Core.TaskRunner");

            proxy.SetLog(new TaskLoggerWrapper(Log));
            bool result = proxy.RunTasks(AssemblyPath);

            AppDomain.Unload(domain);
            return result;
        }
    }
}
