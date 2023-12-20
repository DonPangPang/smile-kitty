using SmileKitty.Domain.Shared.Enums;
using SmileKitty.Domain.Shared.Events.Cats.CatRescuedApplys;
using SmileKitty.Domain.Shared.Events.Cats.Cats;
using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;
using System.ComponentModel.DataAnnotations;

namespace SmileKitty.Domain.Cats;

public class CatRescuedApply : AggregateRoot, IEntity, ICreationTime, IModificationTime, ISafeDelete
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public string? Description { get; set; }

    public required string Address { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }
    public bool IsDeleted { get; set; }

    public FlowResult Result { get; set; }

    [Timestamp]
    public byte[]? RowVersion { get; set; }

    public void HandleFlow(FlowResult result, User handleUser)
    {
        Result = result;
        if (Result == FlowResult.Accept)
        {
            AddLocalEvent(new CatRescuedApplyAddRescuedRecordEvent()
            {
                CatId = CatId,
                UserId = UserId,
                HandlerId = handleUser.Id,
                Description = Description,
                RescuedAddress = Address
            });

            AddLocalEvent(new CatStatusChangeEvent()
            {
                CatId = CatId,
                Status = CatStatus.Rescued
            });
        }

        if (Result == FlowResult.Finish)
        {
            AddLocalEvent(new CatStatusChangeEvent()
            {
                CatId = CatId,
                Status = CatStatus.Salvage
            });
        }
    }
}