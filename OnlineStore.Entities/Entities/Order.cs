﻿using OnlineStore.Entities.Entities.Enums;

namespace OnlineStore.Entities.Entities;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public OrderState OrderState { get; set; }
    public DateTime EntryDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
}