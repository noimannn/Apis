﻿using App.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Application
{
    public interface ITokenService
    {
        string GenerateToken(PessoaDTO pessoa);

    }
}
