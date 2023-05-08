using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerData : MonoBehaviour
{
    public float jumpMaxValue = 600f;
    [SerializeField]
    private Slider jumpSlider;
    public GameObject aoeHeal;
    public GameObject healShotSpread;
    public float currentHealth;
    public float aoeValue;

    private void Update()
    {
        jumpSlider.value = GetComponent<PlayerController>().jumpHeight;

    }
}
