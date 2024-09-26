using System.Collections.Generic;
using Godot;
using GameDevIncEditor;
using Newtonsoft.Json;

namespace GameDevIncEditor.Godot;

public partial class MainController : Node2D
{
    // TODO: Change path to wherever the game is stored
    public string DataPath { get; private set; } = "C:/Users/KAMil/Documents/gamedevinceditor/Data/Data.json";                  // Path to location of the modules file

    public static MainController Instance { get; private set; }

    public override void _Ready()
    {
        base._Ready();
        Instance = this;
        Loader.Instance.ReadData();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if(Input.IsActionJustPressed("TestKey"))
        {
            var module = new BaseModule
            {
                Id = 0,
                ModuleName = "Hello, World",
                ModuleJobType = 0,
                IconPath = "",
                MinAAA = 82,
                MaxAAA = 94,
                MinIII = 13,
                MaxIII = 45,
                MinIndie = 13,
                MaxIndie = 20
            };

            Loader.Instance.Data.Add(module);
            switch(Writer.Instance.WriteToFile())
            {
                case EWriteToFileResult.Success:
                    GD.Print("Successfully added module");
                    break;
                case EWriteToFileResult.FileNotFound:
                    GD.Print("Could not find location to file");
                    break;

            }
        }
    }
}