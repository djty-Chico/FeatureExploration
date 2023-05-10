using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealShotAOE : MonoBehaviour
{
    private IEnumerator destroyTimer()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
    private void Start()
    {
        StartCoroutine(destroyTimer());
    }
}
