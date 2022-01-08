using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Dommel;

namespace Gerenciamento.Models
{
    [Table("AspNetUsers")]
    public class Usuario
    {
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsEnabled { get; set; }

        [Ignore]
        public string Senha { get; set; }

        [Ignore]
        public string ConfirmacaoSenha { get; set; }

        [Ignore]
        public double ExpiresIn { get; set; }

        [Ignore]
        public string AccessToken { get; set; }

    }
}
