
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] GameData gameData;

    [SerializeField] GameObject[] spawnSpots;

    [SerializeField] CityManagement[] cities;

    public Vector3 currentCheckPoint { get; set; }

    public int currentLives = 3;

    int coins;

    void Awake()
    {
        if (spawnSpots.Length > 0)
        {

            currentCheckPoint = spawnSpots[0].transform.position;
        }
        else
        {
            print("WARNING: No spawn spots present");
        }
    }

    void Start()
    {
        for (int i = 0; i < cities.Length; i++)
        {
            cities[i].SetLevel(i);
        }
        // Nascondi il cursore del mouse
        UnityEngine.Cursor.visible = false;

        // Blocca il cursore al centro dello schermo
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    public void AddCoin(int amount = 1)
    {
        coins += amount;
        UiManager.Instance.SetCoins(coins);
    }

}
