﻿using FundoBiblico.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.Models
{
    public class ClienteAddEditarModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int NumeroFilaEspera { get; set; }
    }
}
