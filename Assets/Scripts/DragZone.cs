using UnityEngine;

public class DragZone : MonoBehaviour
{
    public ClothingType zoneType;
    public string correctItemID; 
    public bool solved = false;
   
   private void OnTriggerEnter2D(Collider2D other)
    {
        if(!GameManager.Instance.gameActive) return; 

        Clothing clothing = other.GetComponent<Clothing>();
        if (clothing == null) return; 

        //snapping
        other.transform.position = transform.position;
        //checking if correct
        solved = clothing.itemID == correctItemID;

        GameManager.Instance.CheckAllZones();

    }
}
