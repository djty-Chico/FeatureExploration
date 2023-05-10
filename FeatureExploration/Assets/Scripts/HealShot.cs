using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealShot : MonoBehaviour
{
    private float healValue = 50f;
    private float velocityForward = 1000f;
    private Rigidbody rb;
    [SerializeField]
    private GameObject healRadius;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * velocityForward, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        Instantiate(healRadius, transform.position, transform.rotation);
    }
}
