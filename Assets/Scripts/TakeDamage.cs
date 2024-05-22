using UnityEngine;
using UnityEngine.UI;

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
        enemy.TakeDamage(enemy.healthDecrease);

        // Assuming damaging the enemy results in the player losing health
        player.ModifyHealth(-enemy.playerHealthDecrease);
    }
}