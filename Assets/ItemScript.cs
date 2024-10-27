using UnityEngine;

public class ItemScript : MonoBehaviour
{

    bool[] appleMap;


    int[] playerItemArr = new int[4];
    int[] enemyItemArr = new int[4];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        appleMap = gameObject.GetComponent<WheelScript>().appleMap;

        getItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int selectItem()
    {
        return Random.Range(1, 5);
    }

    public void getItem()
    {
        bool playerGot = false;
        bool enemyGot = false;
        for (int i = 0; i < 4 || (!playerGot && !enemyGot); i++)
        {
            if (playerItemArr[i] == 0 && !playerGot)
            {
                playerItemArr[i] = selectItem();
                playerGot = true;
            }
            if (enemyItemArr[i] == 0 && !enemyGot)
            {
                enemyItemArr[i] = selectItem();
                enemyGot = true;
            }
        }

    }




     public void useItem(int slot)
    {
        switch (playerItemArr[slot]){
            case 1:
                Debug.Log("Use: Change your odds!");
                for(int i = 0; i< appleMap.Length; i++)
                {
                    if (!appleMap[i])
                    {
                        appleMap[i] = true;
                    }
                }
                break;
            case 2:
                Debug.Log("Use: Spin Twice!");
                break;
            case 3:
                Debug.Log("Use: Double Damage");

                break;
            case 4:
                Debug.Log("Use: Health UP!");

                break;
        }
    }
}
