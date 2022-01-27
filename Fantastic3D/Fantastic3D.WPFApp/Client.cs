using Fantastic3D.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.GUI
{
    public class Client
    {
        HttpClient client = new HttpClient();
        private string url = "https://localhost:7164/api/User";

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var content1 = await client.GetFromJsonAsync<IEnumerable<UserDto>>(url);
            return content1;
        }
    }
}
