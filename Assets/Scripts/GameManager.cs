using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public bool gameActive = false; 
    public DragZone[] zones; 
    public GameObject[] clothing;
    public float spawnXMin = -10f; 
    public float spawnXMax = 10f;
    public float spawnYMin = -7f;
    public float spawnYMax = -3f;
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        gameActive = true; 
        AssignRandomTargets();
        SpawnItems();
       // UIManager.Instance.DisplayTargetFromZones();

    }

    void SpawnItems()
    {
        foreach (GameObject clothes in clothing)
        {
            Vector2 pos = new Vector2(Random.Range(spawnXMin, spawnXMax), Random.Range(spawnYMin, spawnYMax));
            Instantiate(clothes, pos, Quaternion.identity);
        }
    }

    void AssignRandomTargets()
    {
        foreach (DragZone zone in zones)
        {
            zone.solved = false; 

            switch(zone.zoneType)
            {
               case ClothingType.Top:
                    zone.correctItemID = Random.value > 0.5f ? "RedTop" : "BlueTop";
                    break;

                case ClothingType.Bottom:
                    zone.correctItemID = Random.value > 0.5f ? "Jeans" : "Shorts";
                    break;

                case ClothingType.Shoes:
                    zone.correctItemID = Random.value > 0.5f ? "Sneakers" : "Boots";
                    break;
            }
        }
    }

public void CheckAllZones()
    {
        foreach (DragZone zone in zones)
        {
            if (!zone.solved)
                return; 
        }

        WinGame();
    }

void WinGame()
    {
        gameActive = false; 
        //UIManager.Instance.ShowWin();
    }

public void TimeUp()
    {
        gameActive = false; 
        //UIManager.Instance.ShowLose();
    }



}
