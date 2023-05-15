using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonlightSword : SwungWeapon
{
    public GameObject Projectile;
    public GameObject Player;
    public GameObject SpawnPoint;

    public override void Start()
    {
        base.Start();
        Player = GameObject.Find("Player");
        SpawnPoint = GameObject.Find("SpawnPoint");
    }
    public override IEnumerator Swing()
    {
         float degress = 0;
        while (degress < swingDegrees * 2)
        {
            transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            degress += swingSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        DisableWeapon();
        Instantiate(Projectile, SpawnPoint.transform.position, Player.transform.rotation);
    }
}
