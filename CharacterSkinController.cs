using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSkinController : MonoBehaviour
{
    [SerializeField] private List<GameObject> heads = new List<GameObject>();
    [SerializeField] private List<GameObject> bodies = new List<GameObject>();
    [SerializeField] private List<GameObject> legs = new List<GameObject>();
    [SerializeField] private List<GameObject> foots = new List<GameObject>();
    [SerializeField] private List<GameObject> items = new List<GameObject>();

    [SerializeField] private int headSkinIndex;
    [SerializeField] private int bodySkinIndex;
    [SerializeField] private int legSkinIndex;
    [SerializeField] private int footSkinIndex;
    [SerializeField] private int itemSkinIndex;

    private void Start()
    {
        GetSkin();
    }
    public void SetSkinIndex(SKINTYPE type,int direction)
    { 
        switch (type)
        {
            case SKINTYPE.HEAD:
                headSkinIndex = (heads.Count+headSkinIndex + direction)% heads.Count;
                break;
            case SKINTYPE.BODY:
                bodySkinIndex = (bodies.Count + bodySkinIndex + direction) % bodies.Count;
                break;
            case SKINTYPE.LEG:
                legSkinIndex = (legs.Count + legSkinIndex + direction) % legs.Count;
                break;
            case SKINTYPE.FOOT:
                footSkinIndex = (foots.Count + footSkinIndex + direction) % foots.Count;
                break;
            case SKINTYPE.ITEM:
                itemSkinIndex = (items.Count + itemSkinIndex + direction) % items.Count;
                break;
            default:
                break;
        }
        UpdateChar();
    } 
    private void UpdateChar()
    {
        heads.ForEach(head => head.SetActive(false));
        bodies.ForEach(body => body.SetActive(false));
        legs.ForEach(leg => leg.SetActive(false));
        foots.ForEach(foot => foot.SetActive(false));
        items.ForEach(item => item.SetActive(false));

        heads[headSkinIndex].SetActive(true);
        bodies[bodySkinIndex].SetActive(true);
        legs[legSkinIndex].SetActive(true);
        foots[footSkinIndex].SetActive(true);
        items[itemSkinIndex].SetActive(true);

    }
    public void SaveSkin()
    {
        PlayerPrefs.SetInt("HEAD", headSkinIndex);
        PlayerPrefs.SetInt("BODY", bodySkinIndex);
        PlayerPrefs.SetInt("LEG", legSkinIndex);
        PlayerPrefs.SetInt("FOOT", footSkinIndex);
        PlayerPrefs.SetInt("ITEM", itemSkinIndex);
    }


    private void GetSkin()
    {
        headSkinIndex = PlayerPrefs.GetInt("HEAD");
        bodySkinIndex = PlayerPrefs.GetInt("BODY");
        legSkinIndex = PlayerPrefs.GetInt("LEG");
        footSkinIndex = PlayerPrefs.GetInt("FOOT");
        itemSkinIndex = PlayerPrefs.GetInt("ITEM");
        UpdateChar();
    }
}
