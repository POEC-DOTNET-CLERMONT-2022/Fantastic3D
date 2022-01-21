using Fantastic3D.DataManager;
using System.Runtime.Serialization;

namespace Fantastic3D.Persistence
{
    public class XmlDataHandler<T> : IDataHandler<T> where T: IManageable
    {
        private readonly string _xmlDataPath = Environment.CurrentDirectory + $"/{typeof(T).Name}.xml";
        private readonly DataContractSerializer _dataSerializer = new DataContractSerializer(typeof(List<T>));

        public void LoadData(List<T> loadedList)
        {
            if (File.Exists(_xmlDataPath))
            {
                FileStream file = File.Open(_xmlDataPath, FileMode.Open);
                var readValue = _dataSerializer.ReadObject(file);
                if (readValue != null)
                {
                    loadedList.AddRange((List<T>)readValue);
                }
                file.Close();
            }
        }

        public void SaveData(List<T> listToSave)
        {
            FileStream file = File.Create(_xmlDataPath);
            if (file != null)
            {
                _dataSerializer.WriteObject(file, listToSave);
                file.Close();
            }
        }
    }
}