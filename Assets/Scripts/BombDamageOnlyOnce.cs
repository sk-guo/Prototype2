using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Make sure to include this for coroutines

public class BombButtonClassOnlyOnce : MonoBehaviour
{
    public Button BombButton;
    public Button DamageButton;
    public Button IncreaseFriendshipButton;
    public EnemyWithBomb enemy;
    public PlayerWithBomb player; // Reference to the player script
    public Slider healthBar; //enemy health
    public GameObject ProvokeFunction;

    private void Start()
    {
        BombButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        BombButton.interactable = false;
        DamageButton.interactable = false;
        IncreaseFriendshipButton.interactable = false;
        // Call the Enemy's TakeDamage method
        enemy.TakeDamage(enemy.bombEnemyHealthDecrease);
        enemy.ResetFriendship();

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
            player.ModifyHealth(-enemy.bombPlayerHealthDecrease);
        }
        ProvokeFunction.SetActive(false);
    }
}