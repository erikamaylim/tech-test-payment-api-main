using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api_main.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public string ItemVenda { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusVenda Status { get; set; }
        public int IdVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public string CpfVendedor { get; set; }
        public string TelefoneVendedor { get; set; }
        public string EmailVendedor { get; set; }
        
        
    }
}