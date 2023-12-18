using Microsoft.Extensions.Options;

namespace SmileKitty.EventBus.Consts;

public class SmileKittyEventBusOptions : IOptions<SmileKittyEventBusOptions>
{
    public SmileKittyEventBusOptions Value => this;
}