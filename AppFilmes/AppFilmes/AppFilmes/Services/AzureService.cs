using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using AppFilmes.Models;

namespace AppFilmes.Services
{
    public class AzureService<T>
    {
        IMobileServiceClient Client;
        IMobileServiceTable<Filme> Table;
        public AzureService()
        {
            string MyAppServiceURL = "http://apifilmes.azurewebsites.net";
            Client = new MobileServiceClient(MyAppServiceURL);
            Table = Client.GetTable<Filme>();
        }

        public Task<IEnumerable<Filme>> GetTable()
        {
            return Table.ToEnumerableAsync();
        }

        public async Task AddFilme(Filme filme)
        {
            await Table.InsertAsync(filme);
        }
    }
}
