using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarraController : MonoBehaviour
{
    public float health = 20;
    public float healthMax = 100;

    public Image healthBar;

    private void Start()
    {
        healthBar.fillAmount = healthMax;
    }

    private void Update()
    {
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        healthBar.fillAmount = health / healthMax;
    }
}
