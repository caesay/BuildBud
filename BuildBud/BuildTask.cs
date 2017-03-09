using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildBud
{
    public abstract class BuildTask
    {
        public ITaskLogger Log { get; internal set; }
        public string ProjectDir { get; internal set; }
        public string SolutionDir { get; internal set; }

        public abstract bool Execute();
    }
}
