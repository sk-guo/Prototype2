using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Enemy : MonoBehaviour
{

    public int health;
    public int maxFriendship;
    public int healthDecrease;
    public int friendshipIncrease;
    public int friendship = 0;

    public int playerHealthDecrease; // NEW: Amount of health the player loses when attacking
    public int playerHealthIncrease; // NEW: Amount of health the player gains when befriending

    public Slider healthBar;
    public Slider friendshipBar;
    public TextMeshProUGUI healthBarText;
    public TextMeshProUGUI friendshipBarText;

    public GameObject endLevelPanel; // Reference to the endLevelPanel
    public TextMeshProUGUI endLevelText; // Reference to the text endLevelText

    public Button damageButton; // Button to damage the enemy
    public Button friendshipButton; // Button to increase friendship
    public Button nextLevelButton; // Button to proceed to the next level

    public Animator animator;

    // Start is called before the first frame update
    private void Start()
    {

        // Initialize the health and friendship bars
        healthBar.maxValue = health;
        healthBar.value = health;

        friendshipBar.maxValue = maxFriendship;
        friendshipBar.value = friendship;

        // Update the UI text for both bars.
        UpdateHealthBarText();
        UpdateFriendshipBarText();
    }


    public void TakeDamage(int damage)
    {
        animator.SetTrigger("wasAttacked");
        // Ensure health doesn't drop below zero
        if (health - damage < 0)
        {
            health = 0;
        }
        else
        {
            animator.SetTrigger("attack");
            health -= damage;
        }
        StartCoroutine(DelayEnemyHealthModification());
        

        if (health <= 0)
        {
            Debug.Log("Enemy is dead.");
            StartCoroutine(ShowDefeatPanelAfterDelay(2f)); // Call coroutine with a 2-second delay
        }

    }

    IEnumerator DelayEnemyHealthModification()
    {
        // Wait for the attack animation to complete (adjust the time as needed)
        yield return new WaitForSeconds(1.5f);

        // Modify the enemy's health after the delay
        healthBar.value = health;
        UpdateHealthBarText(); // Update the health bar text.
    }

    IEnumerator ShowDefeatPanelAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Show the panel with a defeat message
        endLevelText.text = "Enemy is defeated!";
        endLevelPanel.SetActive(true);
        nextLevelButton.interactable = true; // Enable Next Level button
    }


    public void IncreaseFriendship(int amount)
    {
        // Ensure friendship doesn't exceed its maximum value
        if (friendship + amount > maxFriendship)
        {
            friendship = maxFriendship;
        }
        else
        {
            friendship += amount;
        }
        friendshipBar.value = friendship;
        UpdateFriendshipBarText(); // Update the friendship bar text.

        if (friendship >= maxFriendship)
        {
            Debug.Log("Enemy is now a friend.");
            // Show the panel with a victory message
            endLevelText.text = "Enemy has become a friend!";
            endLevelPanel.SetActive(true);
            damageButton.interactable = false; // Disable damage button
            friendshipButton.interactable = false; // Disable friendship button
            nextLevelButton.interactable = true; // Enable Next Level button
        }
    }

    private void UpdateHealthBarText()
    {
        if (healthBarText != null)
            healthBarText.text = "Health: " + health;
    }

    private void UpdateFriendshipBarText()
    {
        if (friendshipBarText != null)
            friendshipBarText.text = "Friendship: " + friendship;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
