using Godot;
using System;

using Multiplayer.Scenes.Game;
using System.Linq;

public partial class GameBootstrap : Node3D
{
	public override void _Ready()
	{
		Init();
	}

	private void Init()
	{
		if (IsDedicatedServerMode())
		{
			AddChild(new DedicatedServerMode());
		}
		else if (IsServerMode())
		{
			AddChild(new ServerMode());
		}
		else
		{
			AddChild(new ClientMode());
		}
	}

	public bool IsServerMode()
	{
		var options = System.Environment.GetCommandLineArgs();
		return options.Contains("-s");
	}

	public bool IsDedicatedServerMode()
	{
		return false;
	}
}
