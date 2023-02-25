using Godot;
using System;


namespace Multiplayer.Scenes.Game;

public partial class Play : Node3D
{
	[Export] public LaunchMode LaunchMode { get; set; }

	public override void _Ready()
    {
        switch (LaunchMode)
        {
            case LaunchMode.Client:
                AddChild(new ClientMode());

                break;
            case LaunchMode.Host:
                AddChild(new ServerMode());

                break;
            case LaunchMode.Dedicated:
                AddChild(new DedicatedServerMode());
                break;
        }
    }
}
