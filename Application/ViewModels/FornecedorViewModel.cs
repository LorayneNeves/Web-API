﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class FornecedorViewModel
    {
        public int Codigo { get;  set; }
        public string RazaoSocial { get;  set; }
        public string Cnpj { get;  set; }
        public bool Ativo { get;  set; }
        public DateTime Data { get;  set; }
        public string Email { get;  set; }
    }
}
