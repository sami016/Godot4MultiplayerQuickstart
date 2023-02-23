using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplayer.Scenes.Net;

public class PeerDisconnected
{
    private readonly Node _world;

    public PeerDisconnected(Node world)
    {
        _world = world;
    }

    public void Handle(long id)
    {
        if (_world.HasNode($"{id}"))
        {
            var node = _world.GetNode($"{id}");
            node.QueueFree();
        }
    }
}
