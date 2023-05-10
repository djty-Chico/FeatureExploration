using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allyScript : MonoBehaviour
{
    public float myHealth;

    private void Start()
    {
        myHealth = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HealShot")
        {
            myHealth += 20;
        }
        if (other.tag == "HealShotExplosion")
        {
            myHealth += 50;
        }
        if (other.tag == "AOEHeal")
        {
            myHealth += 100;
        }
    }
}
