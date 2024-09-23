
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] GameData gameData;

    [SerializeField] GameObject[] spawnSpots;

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

    public void AddCoin(int amount = 1)
    {
        coins += amount;
    }




}
