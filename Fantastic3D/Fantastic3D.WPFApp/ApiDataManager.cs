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
        HttpClient _client;
        string _endpointUrl = typeof(TModel).Name + "/";
        private IMapper _mapper;

        public ApiDataManager(HttpClient client, IMapper mapper)
        {
            _mapper = mapper;
            _client = client;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            try
            {
                var retrievedObjects = await _client.GetFromJsonAsync<IEnumerable<TDto>>(_endpointUrl);

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
                var retrievedObject = await _client.GetFromJsonAsync<TDto>(_endpointUrl + id);

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

        public async Task AddAsync(TModel objectToAdd)
        {
            var mappedObject = _mapper.Map<TDto>(objectToAdd);
            var httpResponse = await _client.PostAsJsonAsync(_endpointUrl, mappedObject);
            if (httpResponse == null)
            {
                throw new DataRecordException($"Aucune réponse de l'API lors de l'ajout d'un nouvel objet. Objet : {objectToAdd}");
            }
        }

        public async Task UpdateAsync(int id, TModel objectToUpdate)
        {
            var mappedObject = _mapper.Map<TDto>(objectToUpdate);
            var httpResponse = await _client.PutAsJsonAsync(_endpointUrl + id, mappedObject);
            if (httpResponse == null)
            {
                throw new DataRecordException($"Aucune réponse de l'API lors de la mise à jour des données. Objet {objectToUpdate}, mis à jour à l'id {id}");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(_endpointUrl + id);
            }
            catch (Exception ex)
            {
                throw new DataRecordException($"Erreur lors de la suppression de l'objet {id}. Message complet : {ex.Message}", ex);
            }
        }
    }
}