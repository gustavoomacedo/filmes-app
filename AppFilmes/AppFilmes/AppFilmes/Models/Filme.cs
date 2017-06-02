using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace AppFilmes.Models
{
    [DataTable("Filme")]
    public class Filme
    {
        [Version]
        public string AzureVersion { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "diretor")]
        public string Diretor { get; set; }
        [JsonProperty(PropertyName = "nome")]
        public string Nome { get; set; }
        [JsonProperty(PropertyName = "estrelas")]
        public int Estrelas { get; set; }
    }
}
