using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect : MonoBehaviour
{
    public float timeLife;

    private float timer;

    protected virtual void Start()
    {
        timer = timeLife;
    }

    protected virtual void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            End();
        }
    }

    protected virtual void End()
    {
        Destroy(this.gameObject);
    }

}
