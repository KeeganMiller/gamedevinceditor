using GameDevIncEditor;
using Newtonsoft.Json;

namespace GameDevIncEditor;

public class BaseModule : PropertyData
{
    [JsonProperty]
    public string ModuleName;
    [JsonProperty]
    public int ModuleJobType;
    [JsonProperty]
    public string IconPath;
    [JsonProperty]
    public int MinAAA;
    [JsonProperty]
    public int MaxAAA;
    [JsonProperty]
    public int MinIII;
    [JsonProperty]
    public int MaxIII;
    [JsonProperty]
    public int MinIndie;
    [JsonProperty]
    public int MaxIndie;
}