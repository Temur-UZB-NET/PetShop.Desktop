using System;
using System.IO;

namespace PetShop.Desktop.Helpers;

public class ContentNameMaker
{
    public static string GetImageName(string filepath)
    {
        FileInfo fileInfo = new FileInfo(filepath);
        return "IMG_"+Guid.NewGuid().ToString()+fileInfo.Extension;
    }
}
