using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE_ITEM
{
    None = 0,
    Coin = 1
}

public class ItemManager : MonoSingleton<ItemManager>
{
    public GameObject[] prefabs;
    private GameObject temp;

    // Spawn ra tại location đó
    public void Spawn(TYPE_ITEM type, Vector3 location)
    {
        temp = Instantiate(prefabs[(int)type]) as GameObject;
        temp.transform.position = location;
    }



#if UNITY_EDITOR//--------------------------------------------
    public TYPE_ITEM typeTest;
    public Vector3 locationTest;

    public void SpawnTest()
    {
        Spawn(typeTest, locationTest);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            SpawnTest();
        }
    }
#endif// --------------------------------------------


}
