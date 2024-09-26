using Godot;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using GameDevIncEditor.Godot;

namespace GameDevIncEditor;

public enum EDataType
{
    DT_Module = 0,
    DT_Company = 1,
    DT_Game = 2,
    DT_Names = 3,
    DT_Awards = 4,
}

public partial class Loader : Node2D
{

    // Reference to everything loaded
    public List<PropertyData> Data = new List<PropertyData>();
    // Global singleton
    public static Loader Instance;

    public override void _Ready()
    {
        base._Ready();
        Instance = this;
    }

    /// <summary>
    /// Read the data file and obtains the data in class
    /// </summary>
    public void ReadData()
    {
        Data.Clear();
        if(FileAccess.FileExists(MainController.Instance.DataPath))
        {
            var file = FileAccess.Open(MainController.Instance.DataPath, FileAccess.ModeFlags.Read);
            if(file != null && file.IsOpen())
            {
                var lines = file.GetAsText();
                var tokens = JArray.Parse(lines);
                foreach (var token in tokens)
                {
                    var category = JsonConvert.DeserializeObject<PropertyData>(token.ToString());
                    switch((EDataType)category.Id)
                    {
                        case EDataType.DT_Module:
                            var module = JsonConvert.DeserializeObject<BaseModule>(token.ToString());
                            if (module != null && !Data.Contains(module))
                                Data.Add(module);
                            break;
                        default:
                            GD.PushWarning("Loader -> Failed to identify property type");
                            break;
                    }
                }

                file.Close();
            }
        }
    }

    /// <summary>
    /// Gets a module with the specified name
    /// </summary>
    /// <typeparam name="T">Class type of the module</typeparam>
    /// <param name="moduleName">Name of the module</param>
    /// <returns>Module Reference</returns>
    public T GetModule<T>(string moduleName) where T : BaseModule
    {
        foreach(var d in Data)
        {
            if(d is T module)
            {
                if (module.ModuleName == moduleName)
                    return module;
            }
        }

        return null;
    }

}

public class PropertyData
{
    [JsonProperty] public int Id;
}

    
