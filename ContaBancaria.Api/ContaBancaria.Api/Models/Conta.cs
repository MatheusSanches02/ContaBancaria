using System.ComponentModel.DataAnnotations;

namespace ContaBancaria.Api.Models
{
    public class Conta
    {
        [Key]
        public int Numero { get; set; }
        public decimal Saldo { get; set; }
        public string? Titular { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAbertura { get; set; }
    }
}
