using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeapon : Weapon
{
    // swing variables

    public float swingSpeed;
    public float swingDegrees;

  //  public Transform weaponHandle;

    public PlayerController playerScript;

    public override void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        base.Start();
        Debug.Log("and this? does it run?");       
    }

    public override void Attack()
    {
        if (canAttack)
        {
            //base.Attack();
            //rotate to start position
            playerScript.weaponSlot.transform.localEulerAngles = new Vector3(0, 0, -swingDegrees);
            //activate weapon
            EnableWeapon();
            //swing and deactivate weapon
            StartCoroutine(Swing());
            Invoke("AttackReset", 60f / attackRate);
        }
    }

    //swinging routine
    public virtual IEnumerator Swing()
    {
        float degress = 0;
        while (degress < swingDegrees * 2)
        {
            playerScript.weaponSlot.transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            degress += swingSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        DisableWeapon();
    }
}
