using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;

namespace BuildBud.Core
{
    public class InternalTask : Microsoft.Build.Utilities.AppDomainIsolatedTask
    {
        public string AssemblyPath { get; set; }
        public string ProjectDir { get; set; }
        public string SolutionDir { get; set; }

        public InternalTask()
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
        }

        private Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name == Assembly.GetExecutingAssembly().FullName)
                return Assembly.GetExecutingAssembly();

            return Assembly.Load(args.Name);
        }

        public override bool Execute()
        {
            Log.HelpKeywordPrefix = "BuildBud";
            if (!File.Exists(AssemblyPath))
            {
                Log.LogWarning($"BuildBud: could not find assembly at \"{AssemblyPath}\".");
                return true;
            }

            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ApplicationBase = Path.GetDirectoryName(AssemblyPath);
            Evidence evidence = AppDomain.CurrentDomain.Evidence;

            Log.LogMessage($"BuildBud: Creating AppDomain in \"{domaininfo.ApplicationBase}\".");
            AppDomain domain = AppDomain.CreateDomain(Guid.NewGuid().ToString(), evidence, domaininfo);
            TaskRunner proxy = (TaskRunner)domain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, "BuildBud.Core.TaskRunner");

            proxy.SetLog(new TaskLoggerWrapper(Log));
            proxy.SetDirs(ProjectDir, SolutionDir);

            bool result = proxy.RunTasks(AssemblyPath);

            AppDomain.Unload(domain);
            return result;
        }
    }
}
