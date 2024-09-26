using System.Collections.Generic;
using Godot;
using GameDevIncEditor;

namespace GameDevIncEditor.Godot;

public partial class ModuleButton : Button
{
    public BaseModule ModuleRef;

    public override void _Ready()
    {
        base._Ready();
        Connect("pressed", new Callable(this, "SelectModule"));
    }

    private void SelectModule()
    {
        // TODO: Open Module
        // TODO: Open Module Pop Up
        // TODO: Setup the module details
    }
}