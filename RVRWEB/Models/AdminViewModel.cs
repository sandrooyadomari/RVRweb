using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RVRWEB.Models
{
    public class AdminViewModel
    {
        public IEnumerable<Tarefa> TarefaObject { get; set; }
        public IEnumerable<Financeiro> FinanceiroObject { get; set; }
    }
}