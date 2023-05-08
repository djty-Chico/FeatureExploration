using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftAOE : MonoBehaviour
{
    private float aoeHealValue = 100f;
    private Rigidbody rb;
    [SerializeField]
    private GameObject aoe;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerData>().currentHealth += aoeHealValue;
            destroyAoeHeal();
        }
    }
    public IEnumerator destroyAoeHeal()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
