using UnityEngine;
using UnityEngine.UI;
using TMPro; // Make sure to include this namespace if you're using TextMeshPro

public class Player : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Slider healthBar; // Reference to the player's health bar UI
    public GameObject endLevelPanel;
    public TextMeshProUGUI healthText; // Reference to the text component that displays the health value
    public GameObject deathPanel; // Reference to the death panel GameObject
    public Button damageButton; // Reference to the attack button
    public Button friendshipButton; // Reference to the jump button

    // Start is called before the first frame update
    void Start()
    {
        InitializeHealthBar();
    }

    // Initialize the health bar's maxValue and current value
    private void InitializeHealthBar()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        UpdateHealthText(); // Update the health text
    }

    // ModifyHealth is called to change the player's health
    public void ModifyHealth(int amount)
    {
        health += amount;
        // Ensure the health value stays within the desired range
        health = Mathf.Clamp(health, 0, (int)healthBar.maxValue);

        // Update the health bar UI and text to reflect the new health
        UpdateHealthBarUI();
        if (health <= 0)
        {
            deathPanel.SetActive(true); // Show the death panel
        }
        else if (endLevelPanel.activeSelf==true)
        {
            damageButton.interactable = false;
            friendshipButton.interactable = false;
        }
        else
        {
            damageButton.interactable = true;
            friendshipButton.interactable = true;
        }
    }

    // Updates the health bar UI
    private void UpdateHealthBarUI()
    {
        healthBar.value = health;
        UpdateHealthText(); // Update the health text
    }

    // Updates the health text UI
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;// Set the text to the current health value
        }
    }
}