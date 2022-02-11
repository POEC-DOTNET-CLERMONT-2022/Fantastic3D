using AutoMapper;
using Fantastic3D.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Fantastic3D.GUI
{
    public class ApiDataManager<TModel, TDto> : IDataManager<TModel, TDto>
            where TModel : class, IManageable, new()
            where TDto : class, IManageable, new()
    {
        HttpClient client = new HttpClient();
        private IMapper _mapper;

        public ApiDataManager(string apiBaseUrl, IMapper mapper)
        {
            _mapper = mapper;
            client.BaseAddress = new Uri(apiBaseUrl + typeof(TModel).Name);
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            try
            {
                var retrievedObjects = await client.GetFromJsonAsync<IEnumerable<TDto>>("");

                if (retrievedObjects == null)
                {
                    throw new DataRetrieveException("Aucune donnée n'a été récupérée lors d'une opération de récupération générale.");
                }
                else
                {
                    var mappedObjects = _mapper.Map<IEnumerable<TModel>>(retrievedObjects);
                    return mappedObjects;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }
        }

        public async Task<TModel> GetAsync(int id)
        {
            try
            {
                var retrievedObject = await client.GetFromJsonAsync<TDto>(id.ToString());

                if (retrievedObject == null)
                {
                    throw new DataRetrieveException($"Aucune donnée n'a été récupérée lors d'une récupération d'objet individuel. Id : {id}");
                }
                else
                {
                    var mappedObjects = _mapper.Map<TModel>(retrievedObject);
                    return mappedObjects;
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"{ex.Message}", ex);
            }
        }

        public async Task AddAsync(TModel addedObject)
        {
            var mappedObject = _mapper.Map<TDto>(addedObject);
            var httpResponse = await client.PostAsJsonAsync("", mappedObject);
            if (httpResponse == null)
            {
                throw new DataRecordException($"Aucune réponse de l'API lors de l'ajout d'un nouvel objet. Objet : {addedObject}");
            }
        }

        public async Task UpdateAsync(int id, TModel transferedObject)
        {
            var mappedValues = _mapper.Map<TDto>(transferedObject);
            var httpResponse = await client.PutAsJsonAsync(id.ToString(), mappedValues);
            if (httpResponse == null)
            {
                throw new DataRecordException($"Aucune réponse de l'API lors de la mise à jour des données. Objet {transferedObject}, mis à jour à l'id {id}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(id.ToString());
            }
            catch (Exception ex)
            {
                throw new DataRecordException($"Erreur lors de la suppression de l'objet {id}. Message complet : {ex.Message}", ex);
            }
        }
    }
}