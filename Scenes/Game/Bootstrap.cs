using Godot;
using System;

using Multiplayer.Scenes.Game;
using System.Linq;
using Multiplayer.Utilities;

public partial class Bootstrap : Node3D
{
	private static PackedScene _playPackedScene = ResourceLoader.Load<PackedScene>("res://Scenes/Game/play.tscn");

	public override void _Ready()
	{
		CallDeferred(nameof(Init));
	}

	private void Init()
	{
		var play = _playPackedScene.Instantiate<Play>();
		play.LaunchMode = GetLaunchMode();
		LevelManager.Instance.SetActiveScene(play);
	}

	private LaunchMode GetLaunchMode()
	{
		if (IsDedicatedServerMode())
		{
			return LaunchMode.Dedicated;
		}
		else if (IsHostMode())
		{
			return LaunchMode.Host;
		}
		else
		{
			return LaunchMode.Client;
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
