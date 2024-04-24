﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }

        public required string nome { get; set; }

        public Decimal valor { get; set; }
    }
}
