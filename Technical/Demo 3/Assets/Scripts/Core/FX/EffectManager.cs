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
    Smoke = 6,
    Blink = 7,
    FadeIn = 8,
    ComboExplosionSmall = 9,
    ComboExplosionLarge = 10,
    FadeOut = 11
}

public class EffectManager : MonoSingleton<EffectManager>
{
    public GameObject[] prefabs;

    private GameObject temp;

    // Spawn ra tại location đó
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

    // tạo FX chớp chớp, mờ,... lên 1 đối tượng nào đó
    public void ApplyEffect(TYPE_FX type, GameObject target)
    {
        temp = Instantiate(prefabs[(int)type]) as GameObject;

        // !!! lưu ý không gọi cartoon FX
        temp.GetComponent<BaseEffect>().Init(target);
    }

    public void ApplyEffect(TYPE_FX type, GameObject target, float _TimeLife)
    {
        temp = Instantiate(prefabs[(int)type]) as GameObject;

        // !!! lưu ý không gọi cartoon FX
        temp.GetComponent<BaseEffect>().Init(target);
        temp.GetComponent<BaseEffect>().timeLife = _TimeLife;
    }

#if UNITY_EDITOR//--------------------------------------------
    public TYPE_FX typeTest;
    public Vector3 locationTest;
    
    public void SpawnTest()
    {
        Spawn(typeTest, locationTest);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnTest();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ApplyEffect(TYPE_FX.Blink, GameObject.FindGameObjectWithTag("Player"));
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            ApplyEffect(TYPE_FX.FadeIn, GameObject.FindGameObjectWithTag("Player"));
        }
    }
#endif// --------------------------------------------
}