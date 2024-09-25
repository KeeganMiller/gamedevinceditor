using System.Collections.Generic;
using Godot;
using GameDevIncEditor;

namespace GameDevIncEditor.Godot;

public partial class MainController : Node2D
{
    public string ModulesPath { get; private set; } = "res://Data/Data.json";                  // Path to location of the modules file

    public static MainController Instance { get; private set; }

    public override void _Ready()
    {
        base._Ready();
        Instance = this; 
    }
}