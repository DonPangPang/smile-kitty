using System.ComponentModel;

namespace SmileKitty.Domain.Shared.Enums;

public enum DonationType
{
    [Description("全部")]
    Global,
    [Description("猫咪小金库")]
    Cat,
}