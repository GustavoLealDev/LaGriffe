﻿using LaGrife.Models.Entities;
using NuGet.Protocol.Plugins;
using System.Collections.Generic;

namespace LaGrife.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Loja> Lojas { get; set; }
    }
}