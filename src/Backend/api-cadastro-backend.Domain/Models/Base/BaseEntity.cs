﻿namespace api_cadastro_backend.Domain.Models.Base;

public class BaseEntity
{
    public long? Id { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}