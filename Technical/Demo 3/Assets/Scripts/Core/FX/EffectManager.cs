using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TYPE_FX
{
    None = 0,
    Vibrating = 1,
    Explosion = 2,
    ExplosionLarge = 3,
    HitGreen = 4,
    HitBlue = 5,
    Collision = 6
}

public class EffectManager : MonoSingleton<EffectManager>
{
    public GameObject[] prefabs;

    private GameObject temp;

    public void Spawn(TYPE_FX type, Vector3 location)
    {
        temp = Instantiate(prefabs[(int)type]) as GameObject;
        temp.transform.position = location;
    }

    // dùng spawn mấy cái fx ko cần location
    public void Spawn(TYPE_FX type)
    {
        Instantiate(prefabs[(int)type]);
    }

    public TYPE_FX typeTest;
    public Vector3 locationTest;
    
    public void SpawnTest()
    {
        Spawn(typeTest, locationTest);
    }

#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnTest();
        }
    }
#endif
}