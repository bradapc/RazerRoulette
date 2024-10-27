using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemScript : MonoBehaviour
{

    private PlayerScript playerScript;
    private WheelScript wheelScript;
    public ButtonScript buttonScript;
    bool[] appleMap;

    public RawImage itemOneImage;
    public RawImage itemTwoImage;
    public RawImage itemThreeImage;
    public TextMeshProUGUI itemOneText;
    public TextMeshProUGUI itemTwoText;
    public TextMeshProUGUI itemThreeText;

    public Texture newTextureOne;
    public Texture newTextureTwo;
    public Texture newTextureThree;
    public Texture newTextureFour;

    int[] itemArr = new int[3];

    public string whosNext = "player";

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        appleMap = gameObject.GetComponent<WheelScript>().appleMap;
        makeItem(itemOneImage, itemOneText, randomItem(), 1);
        makeItem(itemTwoImage, itemTwoText, randomItem(), 2);
        makeItem(itemThreeImage, itemThreeText, randomItem(), 3);
        whosNext = "player";
        playerScript = GetComponent<PlayerScript>();
        wheelScript = GetComponent<WheelScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int randomItem(){

        return Random.Range(1, 5);
    }

    public void makeItem(RawImage image, TextMeshProUGUI text, int selector, int arrIndex)
    {
        switch (selector){
            case 1:
                image.texture = newTextureOne;
                text.text = "Worsen The Odds";
                break;
            case 2:
                image.texture = newTextureTwo;
                text.text = "One Turn 2x Damage";
                break;
            case 3:
                image.texture = newTextureThree;
                text.text = "Heal One Damage";

                break;
            case 4:
                image.texture = newTextureFour;
                text.text = "Free Spin";

                break;
        }
        itemArr[arrIndex-1] = selector;
    }

    public void itemSwitchVis(){
        itemOneImage.gameObject.SetActive(!itemOneImage.gameObject.activeSelf);
        itemTwoImage.gameObject.SetActive(!itemTwoImage.gameObject.activeSelf);
        itemThreeImage.gameObject.SetActive(!itemThreeImage.gameObject.activeSelf);
    }

    public void selectItem(string nextInTurn)
    {
        makeItem(itemOneImage, itemOneText, randomItem(), 1);
        makeItem(itemTwoImage, itemTwoText, randomItem(), 2);
        makeItem(itemThreeImage, itemThreeText, randomItem(), 3);
        whosNext = nextInTurn;
        itemSwitchVis();

    }

    public void itemChosen(int slot){
        itemSwitchVis();
        Debug.Log(slot);
        Debug.Log(itemArr[slot-1]);
        switch (itemArr[slot-1]){
            case 1:
                for(int i = 0; i< appleMap.Length; i++)
                {
                    if (!appleMap[i])
                    {
                        appleMap[i] = true;
                        wheelScript.updateOdds(i+1);
                    }
                }
                break;
            case 2:
                buttonScript.damageValue = 2;
                break;
            case 3:
                playerScript.updateLifeHeal();

                break;
            case 4:
                buttonScript.doubleSpin = true;

                break;
        }
        buttonScript.turn = whosNext;
    }


}
