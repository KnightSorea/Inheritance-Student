using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotPickUp : pickUp
{
    public override void Activate()
    {
        player.hasMultiShot = true;
        Invoke(nameof(EndOfTimer), 7f);
    }

    public void EndOfTimer()
    {
        player.hasMultiShot = false;
    }
}
