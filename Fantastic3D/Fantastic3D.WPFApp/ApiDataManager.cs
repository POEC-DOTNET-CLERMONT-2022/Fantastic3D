using AutoMapper;
using Fantastic3D.AppModels;
using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        //    // Le chat a dit : 000000000111111111111111111111111111111

        public IEnumerable<TModel> GetAll()
        {
            try
            { 
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadFromJsonAsync<IEnumerable<TDto>>().Result;

                    var mappedValues = _mapper.Map<IEnumerable<TModel>>(result);
                    return mappedValues;

                }
                else
                {
                    return Enumerable.Empty<TModel>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"L'API n'a pas répondu {ex.Message}", ex);
            }
        }

        public void Add(TModel transferedObject)
        {
                throw new NotImplementedException();
        }

        public void Delete(int id)
        {
                throw new NotImplementedException();
        }

        public TModel Get(int id)
        {
                throw new NotImplementedException();
        }


        public void Update(int id, TModel transferedObject)
        {
                throw new NotImplementedException();
        }
        }

    }

