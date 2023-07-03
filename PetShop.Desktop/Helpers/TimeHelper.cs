using PetShop.Desktop.Constants;
using System;

namespace PetShop.Desktop.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var dtTime = DateTime.UtcNow;
        dtTime.AddHours(TimeConstants.UTC);
        return dtTime;
    } 
}
