﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application
{
    public class DependencyInjectionConfig
    {
        public static void Inject(IserviceCollection services)
        {
            services.AddTransient<IPessoaService, Pessoaservice>();
        }
    }
}
