using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class pickUp : MonoBehaviour
{//abstact means i cant use this class on its own. this is a template and i have to have a subclass/ child class in order to use it
    public PlayerController player;
    public float duration;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            Activate();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Invoke(nameof(delayedDestroy), duration);
        }
    }

    public virtual void Activate()
    {
        //    ><)))*>
    }

    public void delayedDestroy()
    {
        Destroy(gameObject);
    }
}
