using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Example inventory list, replace with your own inventory system
    public System.Collections.Generic.List<string> playerInventory = new System.Collections.Generic.List<string>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }

    // Example method to add an item to the inventory
    public void AddItem(string item)
    {
        if (!playerInventory.Contains(item))
        {
            playerInventory.Add(item);
        }
    }
}