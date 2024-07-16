using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float startingHealth = 100;
    public Slider healthSlider;
    public Image filledImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;
  //  public GameObject explosionPrefab;

    private float currentHealth;
    private bool isDead;

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        currentHealth = startingHealth;
        isDead = false;
        SetHealthUI();
    }
    void SetHealthUI()
    {
        healthSlider.value = currentHealth;
        filledImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth/startingHealth);
    }
    private void OnDeath()
    {
        isDead = true;
        gameObject.SetActive(false);
    }
}
