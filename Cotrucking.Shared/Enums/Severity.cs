using System.ComponentModel;

namespace Cotrucking.Shared.Enums;
public enum Severity
{
    [Description("normal")]
    Normal,
    [Description("info")]
    Info,
    [Description("success")]
    Success,
    [Description("warning")]
    Warning,
    [Description("error")]
    Error
}
