using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

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
        #region Variables

        [JsonIgnore]
        private string _Identifier;

        #endregion

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

        public string Identifier
        {
            get { return _Identifier ?? Name; }
            set { _Identifier = value; }
        }

        public List<Category> Categories { get; set; }

        public List<Item> Items { get; }

        #endregion
    }

    [JsonObject(MemberSerialization.OptOut)]
    public class Item : INotifyPropertyChanged
    {
        [JsonIgnore]
        private bool _IsChecked;

        [JsonIgnore]
        private string _Identifier;

        public string Name { get; set; }

        public string Identifier
        {
            get { return _Identifier ?? Name; }
            set { _Identifier = value; }
        }

        public string Action { get; set; }

        [JsonIgnore]
        public bool IsChecked
        {
            get { return _IsChecked; }
            set
            {
                if (_IsChecked != value)
                {
                    _IsChecked = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
