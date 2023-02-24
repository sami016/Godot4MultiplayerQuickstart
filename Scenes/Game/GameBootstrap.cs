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
		else if (IsHostMode())
		{
			AddChild(new ServerMode());
		}
		else
		{
			AddChild(new ClientMode());
		}
	}

	public bool IsHostMode()
	{
		var options = System.Environment.GetCommandLineArgs();
		return options.Contains("--host");
	}

	public bool IsDedicatedServerMode()
	{
		var options = System.Environment.GetCommandLineArgs();
		return options.Contains("--dedicated");
	}
}
