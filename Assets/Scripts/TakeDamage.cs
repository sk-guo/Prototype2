using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Make sure to include this for coroutines

public class DamageButton : MonoBehaviour
{
    public Button TakeDamageButton;
    public Button IncreaseFriendshipButton;
    public Enemy enemy;
    public Player player; // Reference to the player script
    public Slider healthBar; //enemy health

    private void Start()
    {
        TakeDamageButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        TakeDamageButton.interactable = false;
        IncreaseFriendshipButton.interactable = false;
        // Call the Enemy's TakeDamage method
        enemy.TakeDamage(enemy.healthDecrease);

        // Start a coroutine to delay the Player's health modification
        StartCoroutine(DelayPlayerHealthModification());
    }

    IEnumerator DelayPlayerHealthModification()
    {
        // Wait for the attack animation to complete (adjust the time as needed)
        yield return new WaitForSeconds(2.5f);

        // Modify the player's health after the delay
        if (healthBar.value > 0)
        {
            player.ModifyHealth(-enemy.playerHealthDecrease);
        }        
    }
}