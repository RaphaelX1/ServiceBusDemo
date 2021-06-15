using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceBus.Models
{
    public record Usuario
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
