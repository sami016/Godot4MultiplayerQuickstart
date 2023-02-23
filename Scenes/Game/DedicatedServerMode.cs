using Godot;
using Multiplayer.Scenes.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer.Scenes.Game;

public partial class DedicatedServerMode : Node
{
    public override void _Ready()
    {
        var world = GetNode("../world");
        var peerConnected = new PeerConnected(world);
        var peerDisconnected = new PeerDisconnected(world);
        AddChild(new Server(peerConnected, peerDisconnected));
    }
}
