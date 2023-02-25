using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer.Utilities;

public partial class LevelManager : Node
{
    public static LevelManager Instance { get; private set; }

    public LevelManager()
    {
        Instance = this;
    }

    public void SetActiveScene(string scene)
    {
        var sceneResource = ResourceLoader.Load<PackedScene>(scene);
        SetActiveScene(sceneResource);
    }

    public void SetActiveScene(PackedScene scene)
    {
        SetActiveScene(scene.Instantiate());
    }

    public void SetActiveScene(Node newScene)
    {
        var root = GetTree().Root;
        if (root.HasNode("Level"))
        {
            var existingLevel = GetTree().Root.GetNode<Node>("Level");
            GetTree().Root.RemoveChild(existingLevel);
        }
        newScene.Name = "Level";
        GetTree().Root.AddChild(newScene);
    }


}

