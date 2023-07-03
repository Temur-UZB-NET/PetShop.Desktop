using PetShop.Desktop.Helpers;
using System;

namespace PetShop.Desktop.Entitys;

public class Auditble :BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Auditble()
    {
        CreatedAt = TimeHelper.GetDateTime();
        UpdatedAt = TimeHelper.GetDateTime();
    }
}
