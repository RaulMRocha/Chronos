using System.Collections.Generic;

namespace Chronos.Data.Shared.Model
{
    class Models
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public List<ModelSettings> ModelSettingsConfig { get; set; }
        public bool Active { get; set; }
    }

    public class ModelSettings
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public string Comments { get; set; }
    }
}
