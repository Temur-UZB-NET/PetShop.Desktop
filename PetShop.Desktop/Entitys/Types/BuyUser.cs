using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Desktop.Entitys.Types;

public class BuyUser :Auditble
{
    public string Name { get; set; }

    public string Address { get; set; }

    public string Phone_number { get; set; }

    public string Price { get; set; }
}
