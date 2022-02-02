using AutoMapper;
using Fantastic3D.AppModels;
using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fantastic3D.GUI
{
    public class ApiDataManager<TModel, TDto> : IDataManager<TModel, TDto>
            where TModel : class, IManageable, new()
            where TDto : class, IManageable, new()

    {
        HttpClient client = new HttpClient();

        private string url = "https://localhost:7164/api/" + typeof(TModel).Name;
        private IMapper _mapper = ((App)Application.Current).Mapper;

        public ApiDataManager()
        {
            client.BaseAddress = new Uri("https://localhost:7164/");
        }
        //    // Le chat a dit : 000000000111111111111111111111111111111

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            try
            {
                var request = await client.GetFromJsonAsync<IEnumerable<TDto>>(url);

                if (request == null)
                {
                    throw new Exception($"Requete null");
                }
                else
                {
                    var mappedValues = _mapper.Map<IEnumerable<TModel>>(request);
                    return mappedValues;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task AddAsync(TModel userInfoDto)
        {
            
            var response = await client.PostAsJsonAsync("api/employee", userInfoDto);
            //return response;

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var url = "/api/User/" + id;

                HttpResponseMessage response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)

                {
                    MessageBox.Show("User Deleted");
                    //return;
                }

                else

                {
                    MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);

                }
            }
            catch
                (Exception ex)
            {
                throw new Exception($"L'API n'a pas répondu {ex.Message}", ex);
            }
        }


        public Task<TModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, TModel transferedObject)
        {
            throw new NotImplementedException();
        }
    }

}

