using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer.Scenes.Game.Player;

public partial class Player : CharacterBody3D
{
    public override void _Ready()
    {
        if (int.TryParse(Name, out var peerId))
        {
            SetMultiplayerAuthority(peerId);
        }

        var camera = GetNode<Camera3D>("./camera");
        camera.Current = IsMultiplayerAuthority();
        GD.Print($"{GetMultiplayerAuthority()} {IsMultiplayerAuthority()} {Multiplayer.MultiplayerPeer.GetUniqueId()}");
    }
}
