using System.ComponentModel;

namespace SmileKitty.Domain.Shared.Enums;

public enum CatStatus
{
    [Description("流浪")]
    Stray,
    [Description("解救中")]
    Rescued,
    [Description("救助")]
    Salvage,
    [Description("送养")]
    Adopt,
    [Description("遣返")]
    Repatriation
}