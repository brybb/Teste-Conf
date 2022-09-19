﻿using Confitec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Interfaces
{
    public interface IEscolaridadeRepositorio
    {
        Task<IList<Escolaridade>> Listar();
    }
}
