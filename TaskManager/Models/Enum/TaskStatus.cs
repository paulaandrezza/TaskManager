using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models.Users;

namespace TaskManager.Models.Enum
{
    internal enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed,
        Abandoned,
        HasIssues,
        NeedsApproval
    }

    internal static class TaskStatusExtensions
    {
        public static string GetStatusInPortuguese(this TaskStatus status)
        {
            switch (status)
            {
                case TaskStatus.NotStarted:
                    return "Não Iniciada";
                case TaskStatus.InProgress:
                    return "Em Progresso";
                case TaskStatus.Completed:
                    return "Concluída";
                case TaskStatus.Abandoned:
                    return "Abandonada";
                case TaskStatus.HasIssues:
                    return "Com Impedimento";
                case TaskStatus.NeedsApproval:
                    return "Aguardando Aprovação";
                default:
                    return status.ToString();
            }
        }
    }
 }
