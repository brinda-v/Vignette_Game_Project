using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public bool gameActive = false; 
    public DragZone[] zones; 
    
    void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        gameActive = true; 
        AssignRandomTargets();
       // UIManager.Instance.DisplayTargetFromZones();

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
