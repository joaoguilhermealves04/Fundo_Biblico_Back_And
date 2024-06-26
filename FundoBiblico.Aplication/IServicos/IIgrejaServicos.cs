﻿using FundoBiblico.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundoBiblico.Aplication.IServicos
{
    public interface IIgrejaServicos
    {
        Task CadastroIgreja(IgrejaAddEditarModel igreja);
        Task Atualizar(IgrejaAddEditarModel igreja);
        Task<IEnumerable<IgrejaModel>> ObterIgrejas();
        Task<IgrejaModel> ObterIgreja(Guid? id);
        Task Remover(Guid id);
        Task<IgrejaModel> ObterIgrejaPorNome(string nome);
    }
}
