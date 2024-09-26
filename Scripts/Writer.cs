using System.Collections.Generic;
using GameDevIncEditor;
using Godot;
using Newtonsoft.Json;
using System.IO;
using System;

namespace GameDevIncEditor.Godot;

public enum EWriteToFileResult
{
    Success,
    FileNotFound,
    UnknownError
}

public partial class Writer : Node
{
    public static Writer Instance { get; private set; }
    public event Action WriteFileEvent;
    public override void _Ready()
    {
        base._Ready();
        Instance = this;
    }
    public EWriteToFileResult WriteToFile()
    {
        var data = Loader.Instance.Data;
        string updatedData = "[";
        foreach(var item in data)
        {
            var jsonData = JsonConvert.SerializeObject(item);
            updatedData += jsonData + ",";
        }

        updatedData += "]";

        if(File.Exists(MainController.Instance.DataPath))
        {
            File.WriteAllText(MainController.Instance.DataPath, updatedData);
            WriteFileEvent?.Invoke();
            return EWriteToFileResult.Success;
        } else
        {
            GD.PushWarning("Path to file not found");
            return EWriteToFileResult.FileNotFound;
        }
    }
}