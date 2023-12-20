using System.ComponentModel;

namespace SmileKitty.Domain.Shared.Enums;

public enum CatSalvageTypeChannel
{
    [Description("公共账户")]
    PublicAccount,
    [Description("猫咪私有账户购买")]
    PrivateAccount,
    [Description("捐助")]
    Donate
}