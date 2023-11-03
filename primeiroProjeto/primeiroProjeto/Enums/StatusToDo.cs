using System.ComponentModel;

namespace primeiroProjeto.Enums
{
    public enum StatusToDo
    {
        [Description( "To Do")]
        toDo = 1,
        [Description("In progress")]
        inProgress = 2,
        [Description("Finshed")]
        finshed = 3
    }
}
