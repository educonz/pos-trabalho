using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace TrabalhoPos.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Logradouro { get; set; }

        public string Cidade { get; set; }
    }
}