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

        private string url = "https://localhost:7164/api/" + typeof(TModel).Name ;
        private IMapper _mapper = ((App)Application.Current).Mapper;

        public ApiDataManager()
        {
            //client.BaseAddress = new Uri("https://localhost:7164/");
        }
        

        //Getall
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


        // Add- Post
        public async Task AddAsync(TModel value)
        {
            var mappedValue = _mapper.Map<TDto>(value);
            var response = await client.PostAsJsonAsync(url, mappedValue);
            //return response;

        }

        // Delete
        public async Task DeleteAsync(int id)
        {
            try
            {
                string urlAppend = "/" + id;

                HttpResponseMessage response = await client.DeleteAsync(url + urlAppend);
                // TODO : Gérer autrement le statut du Delete (APIDataManager doit être découplée de WPF)
                // if (response.IsSuccessStatusCode)
                // {
                //     MessageBox.Show("User Deleted");
                //     //return;
                //  }
                // else
                // {
                //     MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
                // }
            }
            catch
                (Exception ex)
            {
                throw new Exception($"L'API n'a pas répondu {ex.Message}", ex);
            }
        }

        // GetById
        public async Task<TModel> GetAsync(int id)
        {
            try
            {
                var urltotal = url +"/"+ id;
                var request = await client.GetFromJsonAsync<TDto>(urltotal);

                if (request == null)
                {
                    throw new Exception($"Requete null");
                }
                else
                {
                    var mappedValues = _mapper.Map<TModel>(request);
                    return mappedValues;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }


        // Update
        public async Task UpdateAsync(int id, TModel transferedObject)
        {
            string urlAppend = "/" + id;

            var mappedValues = _mapper.Map<TDto>(transferedObject);
            
            var response  = await client.PutAsJsonAsync(url + urlAppend, mappedValues);

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
    }

}

