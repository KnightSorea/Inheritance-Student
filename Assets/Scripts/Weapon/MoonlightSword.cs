using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonlightSword : SwungWeapon
{
    public GameObject Projectile;
    public GameObject Player;
    public GameObject SpawnPoint;
    public float spread;

    public Vector3 right;
    public Vector3 left;

    //public Transform RIGHT;
   //public Transform LEFT;
    public override void Start()
    {
        Player = GameObject.Find("Player");
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnPoint = GameObject.Find("SpawnPoint");

     //   RIGHT.rotation = SpawnPoint.transform.rotation + new Vector3(0, 0, -spread);
        Debug.Log("found stuff");
        base.Start();
        Debug.Log("does this get run??");
    }

    public void Update()
    {
        right = SpawnPoint.transform.localEulerAngles + new Vector3(0, 0, spread);
        left = SpawnPoint.transform.localEulerAngles + new Vector3(0, 0, -spread);
    }
    public override IEnumerator Swing()
    {
         float degress = 0;
        while (degress < swingDegrees * 2)
        {
            Debug.Log("swing");
            playerScript.weaponSlot.transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            degress += swingSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        DisableWeapon();
        SpawnPoint.transform.rotation = Player.transform.rotation;
        Instantiate(Projectile, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        if (playerScript.hasMultiShot)
        {
            SpawnPoint.transform.localEulerAngles += right;
            Instantiate(Projectile, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            SpawnPoint.transform.localEulerAngles += right * 2;
            Instantiate(Projectile, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        }
    }
}
