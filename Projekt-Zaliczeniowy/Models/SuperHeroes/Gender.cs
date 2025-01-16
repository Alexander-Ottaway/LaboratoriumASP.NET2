﻿using System;
using System.Collections.Generic;

namespace Projekt_Zaliczeniowy.Models.SuperHeroes;

public partial class Gender
{
    public int Id { get; set; }

    public string? Gender1 { get; set; }

    public virtual ICollection<Superhero> Superheroes { get; set; } = new List<Superhero>();
}
