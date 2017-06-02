using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFilmes.Models
{
    public class Repository
    {
        public async Task<List<Filme>> GetFilmes()
        {
            var Service = new Services.AzureService<Filme>();
            var Items = await Service.GetTable();
            return Items.ToList();
        }

        public async Task SalvarFilme(Filme filme)
        {
            var Service = new Services.AzureService<Filme>();
            var Items = Service.AddFilme(filme);
        }
    }
}
