namespace PetShop.Desktop.Entitys;

public class Animal :Auditble
{
    public long TypeId { get; set; }

    public string Name { get; set; }

    public long Age { get; set; }

    public string Gender  { get; set; }

    public string Breed { get; set; }

    public string ImagePath { get; set; }


}
