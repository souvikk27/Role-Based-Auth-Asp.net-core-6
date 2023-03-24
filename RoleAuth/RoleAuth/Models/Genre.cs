﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RoleAuth.Models
{
    public enum Genre
    {
        Drama,
        Comedy,
        Romance,
        [Display(Name = "Romantic Comedy")]
        RomCom,
        Crime,
        Mystery,
        Horror
    }
}
