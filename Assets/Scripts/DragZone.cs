using UnityEngine;

public class DragZone : MonoBehaviour
{
    public ClothingType zoneType;
    public string correctItemID; 
    public bool solved = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void OnTriggerEnter2D(Collider2D other)
    {
        if(!GameManager.Instance.gameActive) return; 

        Clothing clothing = other.GetComponent<Clothing>();
        if (clothing == null) return; 
        
        // if (clothing.type != zoneType)
        // {
        //     other.GetComponent<Feedback>()?.PlayWrongFeedback();
        //     return;
        // }

        other.transform.position = transform.position;
        
        solved = clothing.itemID == correctItemID;

        // if (!solved)
        // {
        //     other.GetComponent<Feedback>()?.PlayWrongFeedback();
        // }

        GameManager.Instance.CheckAllZones();

    }
}
