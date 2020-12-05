using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace FlightChecklist.ObjectModel
{
    public class IdentifierPackage
    {
        #region Constructor
        
        public IdentifierPackage()
        {
            Identifiers = new List<Identifier>();
        }

        #endregion

        #region Properties

        public List<Identifier> Identifiers { get; set; }

        #endregion

        #region Methods

        public static IdentifierPackage Load(string filename)
        {
            string json;
            using (StreamReader reader = new StreamReader(File.OpenRead(filename)))
            {
                json = reader.ReadToEnd();
            }

            return LoadJson(json);
        }

        public static IdentifierPackage LoadJson(string json)
        {
            return JsonConvert.DeserializeObject<IdentifierPackage>(json);
        }

        public void Save(string filename)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string serializedData = JsonConvert.SerializeObject(this, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(File.OpenWrite(filename)))
            {
                writer.Write(serializedData);
            }
        }

        #endregion
    }

    public class Identifier
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
