using System.ComponentModel;

namespace GUL.Shared.Configuration;

public enum DbProvider
{
    [Description("MsSql")] MsSql = 0,

    [Description("MySql")] MySql = 1,

    [Description("PostgreSql")] PostgreSql = 2,

    [Description("SqLlite")] SqLlite = 3,

    [Description("InMemory")] InMemory = 4,
}
