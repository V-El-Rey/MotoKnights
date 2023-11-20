using System;
using UnityEngine;

public class PlayerView : BaseView
{
    public MotorcycleView motorcycle;
    public Action<string> onPlayerCollision;

    public void OnTriggerEnter(Collider collision)
    {
        onPlayerCollision?.Invoke(collision.tag);
    }
}
