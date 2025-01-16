﻿using System;
using System.Collections.Generic;

namespace Projekt_Zaliczeniowy.Models.SuperHeroes;

public partial class HeroAttribute
{
    public int? HeroId { get; set; }

    public int? AttributeId { get; set; }

    public int? AttributeValue { get; set; }

    public virtual Attribute? Attribute { get; set; }

    public virtual Superhero? Hero { get; set; }
}
