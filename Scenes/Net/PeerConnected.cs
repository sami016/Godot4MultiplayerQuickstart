using Godot;
using Multiplayer.Scenes.Game.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer.Scenes.Net;

public class PeerConnected
{
    private static PackedScene _playerPackedScene = ResourceLoader.Load<PackedScene>("res://Scenes/Game/Player/player.tscn");
    private readonly Node _world;

    public PeerConnected(Node world)
    {
        _world = world;
    }

    public void Handle(long id)
    {
        CreatePlayer(id);
    }

    private void CreatePlayer(long id)
    {
        var player = _playerPackedScene.Instantiate<Player>();
        player.Name = id.ToString();
        _world.AddChild(player);
        player.SetMultiplayerAuthority((int)id);
    }

}
