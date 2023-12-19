﻿using SmileKitty.Domain.Resources;
using SmileKitty.Domain.Users;
using SmileKitty.Infrastructure.Entity;

namespace SmileKitty.Domain.Cats;

public class CatPost : AggregateRoot, IEntity, ICreation, IModification
{
    public Guid CatId { get; set; }
    public Cat? Cat { get; set; }

    public required string Content { get; set; }

    public ICollection<ImageResource> Images = new List<ImageResource>();

    public DateTime CreateTime { get; set; }
    public DateTime? ModifyTime { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }
}