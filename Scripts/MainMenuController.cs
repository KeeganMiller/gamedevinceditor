using System;
using System.Collections.Generic;
using Godot;

namespace GameDevIncEditor.Godot;

public partial class MainMenuController : Control
{
    private Button _modulesBtn;
    private Button _companyBtn;
    private Button _namesBtn;
    private Button _saveBtn;
    private Button _exitBtn;

    public override void _Ready()
    {
        base._Ready();

        // Get reference to the buttons
        _modulesBtn = GetNode<Button>("ModulesBtn");
        _companyBtn = GetNode<Button>("Companies");
        _namesBtn = GetNode<Button>("NamesBtn");
        _saveBtn = GetNode<Button>("SaveBtn");
        _exitBtn = GetNode<Button>("ExitBtn");

        // Setup the pressed connection
        if (_modulesBtn != null)
            _modulesBtn.Connect("pressed", new Callable(this, "OpenModules"));
        if (_companyBtn != null)
            _companyBtn.Connect("pressed", new Callable(this, "OpenCompanies"));
        if (_namesBtn != null)
            _namesBtn.Connect("pressed", new Callable(this, "OpenNames"));
        if (_saveBtn != null)
            _saveBtn.Connect("pressed", new Callable(this, "CreateSave"));
        if (_exitBtn != null)
            _exitBtn.Connect("pressed", new Callable(this, "Exit"));
    }

    private void OpenModules()
        => new NotImplementedException();
    private void OpenCompanies()
        => new NotImplementedException();
    private void OpenNames()
        => new NotImplementedException();
    private void CreateSave()
        => Writer.Instance.WriteToFile();
    private void Exit()
        => GetTree().Quit();
}