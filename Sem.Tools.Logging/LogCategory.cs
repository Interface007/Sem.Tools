using System;

namespace Sem.Tools.Logging
{
    [Flags]
    public enum LogCategory
    {
        None = 0,
        Technical = 1,
        Business = 2,
    }
}