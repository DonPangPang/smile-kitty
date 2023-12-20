using System.ComponentModel;

namespace SmileKitty.Domain.Shared.Enums;

public enum FlowResult
{
    [Description("拒绝")]
    Refuse,
    [Description("等待")]
    Pending,
    [Description("同意")]
    Accept,
    [Description("完成")]
    Finish,
    [Description("结束")]
    End,
    [Description("取消")]
    Cancel
}