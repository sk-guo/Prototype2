using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Make sure to include this for coroutines

public class DamageButton : MonoBehaviour
{
    public Button button;
    public Enemy enemy;
    public Player player; // Reference to the player script

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
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
        player.ModifyHealth(-enemy.playerHealthDecrease);
    }
}