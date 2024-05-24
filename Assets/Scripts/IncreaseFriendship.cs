using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class IncreaseFriendship : MonoBehaviour
{
    public Button TakeDamageButton;
    public Button IncreaseFriendshipButton;
    public Enemy enemy;
    public Player player; // Reference to the player script
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private void Start()
    {
        IncreaseFriendshipButton.onClick.AddListener(OnClick);
        // Initially, all hearts are hidden
        heart1.SetActive(false);
        heart2.SetActive(false);
        heart3.SetActive(false);
    }

    private void OnClick()
    {
        TakeDamageButton.interactable = false;
        IncreaseFriendshipButton.interactable = false;
        // Start the coroutine to show and hide hearts then increase friendship
        StartCoroutine(HeartSequence());
    }

    IEnumerator HeartSequence()
    {
        // Show heart1 and wait for 1 second
        heart1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        // Hide heart1 and show heart2
        heart1.SetActive(false);
        heart2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        // Hide heart2 and show heart3
        heart2.SetActive(false);
        heart3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        // Hide heart3
        heart3.SetActive(false);

        // Now increase the enemy's friendship
        enemy.IncreaseFriendship(enemy.friendshipIncrease);

        // Assuming increasing friendship makes the player gain health
        player.ModifyHealth(enemy.playerHealthIncrease);
    }
}