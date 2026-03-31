using UnityEngine;

 public enum ClothingType
    {
        Top = 0,
        Bottom = 1,
        Shoes = 2
    }
public class Clothing : MonoBehaviour
{
   
    public ClothingType type; 
    public string itemID; 
    public Sprite icon; 
   
}
