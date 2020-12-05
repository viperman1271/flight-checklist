using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace FlightChecklist.ObjectModel
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Checklist
    {
        #region Constructor

        public Checklist()
        {
            Categories = new List<Category>();
        }

        #endregion

        #region Properties

        public List<Category> Categories { get; set; }
        public string Aircraft { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }

        [JsonIgnore, Browsable(false)]
        public string Filename { get; set; }

        #endregion

        #region Methods

        public static Checklist Load(string filename)
        {
            string json;
            using (StreamReader reader = new StreamReader(File.OpenRead(filename)))
            {
                json = reader.ReadToEnd();
            }

            return LoadJson(json);
        }

        public static Checklist LoadJson(string json)
        {
            return JsonConvert.DeserializeObject<Checklist>(json);
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

    [JsonObject(MemberSerialization.OptOut)]
    public class Category
    {
        #region Constructor

        public Category()
        {
            Categories = new List<Category>();
            Items = new List<Item>();
        }

        #endregion

        #region Properties

        [Browsable(false)]
        public uint? ParentCategory { get; set; }

        public string Name { get; set; }

        public string Identifier { get; set; }

        public List<Category> Categories { get; set; }

        public List<Item> Items { get; }

        #endregion
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class Item
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Action { get; set; }
    }
}
