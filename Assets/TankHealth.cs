using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public float startingHealth = 100;
    public Slider healthSlider;
    [SerializeField] private GameObject gameOverScreen;
    /*public Image filledImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;*/
    //  public GameObject explosionPrefab;

    private float currentHealth;
    private bool isDead;

    private void Awake()
    {
    }
    private void Start()
    {
        EventService.Instance.OnSetMaxHealthBar += SetMaxHealth;
        EventService.Instance.OnSetPlayerHealthBar += SetPlayerHealth;
        EventService.Instance.OnGameOver += StartGameOver;
    }
    public void SetMaxHealth(int _maxHealth)
    {
        healthSlider.maxValue = _maxHealth;

    }
    public void StartGameOver()
    {
        gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void SetPlayerHealth(int health)
    {
        healthSlider.value = health;
    }
    
    public void OnEnable()
    {
       /* currentHealth = startingHealth;
        isDead = false;
        SetHealthUI();*/
    }
    /* void SetHealthUI()
     {
         healthSlider.value = currentHealth;
         filledImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth/startingHealth);
     }*/
    private void OnDisable()
    {
        EventService.Instance.OnSetMaxHealthBar -= SetMaxHealth;
        EventService.Instance.OnSetPlayerHealthBar -= SetPlayerHealth;
        EventService.Instance.OnGameOver -= StartGameOver;
    }
    /*private void OnDeath()
    {
        isDead = true;
        gameObject.SetActive(false);
    }*/
}
