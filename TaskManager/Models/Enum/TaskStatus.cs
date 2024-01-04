using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models.Enum
{
    internal enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        Abandoned,
        HasIssues,
        NeedsAproval
    }
}
