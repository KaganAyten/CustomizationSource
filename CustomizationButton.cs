using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SKINTYPE
{
    HEAD,BODY,LEG,FOOT,ITEM
}
public class CustomizationButton : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private SKINTYPE skin;
    [SerializeField] private int direction;
     
    private CharacterSkinController character;
     
    private void Start()
    {
        character = GameObject.FindObjectOfType<CharacterSkinController>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        character.SetSkinIndex(skin,direction);
    }

    
}
