using Fantastic3D.Models;
using System.Runtime.Serialization;

namespace Fantastic3D.Persistence
{
    public class XMLDataHandler : IDataHandler
    {

        private readonly string _appDataPath = Environment.CurrentDirectory;
        //private readonly string _appDataPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private readonly DataContractSerializer _tagListSerializer = new DataContractSerializer(typeof(List<Tag>));

        public object LoadData(string dataIdentifier)
        {
            switch(dataIdentifier)
            { 
                case "tags":
                    List<Tag> output = new List<Tag>();
                    if (File.Exists(_appDataPath))
                    {
                        FileStream file = File.Open(_appDataPath, FileMode.Open);
                        var readValue = _tagListSerializer.ReadObject(file);
                        if (readValue != null)
                        {
                            output = (List<Tag>)readValue;
                        }
                        file.Close();
                    }
                    return output;
                default:
                    throw new DataTypeNotSupportedException($"Loading of this type of data is not supported : {dataIdentifier}");
                    return null;
            }
        }

        public void SaveData(string dataIdentifier, object obj)
        {
            FileStream file = File.Create($"{_appDataPath}/{dataIdentifier}.xml");
            switch (dataIdentifier)
            {
                case "tags":
                    if (file != null)
                    {
                        _tagListSerializer.WriteObject(file, obj as List<Tag>);
                        file.Close();
                    }
                    break;
                default:
                    throw new DataTypeNotSupportedException($"Saving for this type of data is not supported : {dataIdentifier}");
            }
        }

    }
}