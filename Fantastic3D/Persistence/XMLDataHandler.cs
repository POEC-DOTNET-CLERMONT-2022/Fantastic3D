using Fantastic3D.DataManager;
using System.Runtime.Serialization;

namespace Fantastic3D.Persistence
{
    public class XmlDataHandler<T> : IDataHandler<T> where T: IManageable
    {
        private readonly string _xmlDataPath;
        private readonly DataContractSerializer _dataSerializer = new DataContractSerializer(typeof(List<T>));

        public string GetPath => _xmlDataPath;

        public XmlDataHandler(string? contextPath)
        {
            contextPath = contextPath ?? Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _xmlDataPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, contextPath, $"XmlFiles\\{typeof(T).Name}.xml"));
        }

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