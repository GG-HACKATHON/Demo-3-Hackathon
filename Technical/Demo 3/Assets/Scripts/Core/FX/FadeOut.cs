using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : BaseEffect
{
    public float sizeMax;

    private Vector3 scaleOriginal;

    private Color fadeIndex;
    private SpriteRenderer render;
    protected override void Start()
    {
        base.Start();

        render = target.GetComponent<SpriteRenderer>();
        if(render == null)
        {
            Debug.LogError("FadeOut doesn't have SpriteRenderer!");
            Destroy(this.gameObject);
            return;
        }
        render = (SpriteRenderer)Helper.CopyComponent(render, this.gameObject);

        scaleOriginal = target.transform.localScale;

        fadeIndex = Color.white;
        fadeIndex.a = 1;
    }
    protected override void Update()
    {
        render.color = fadeIndex;
        fadeIndex.a = (timer / timeLife);

        // công thức này chưa đúng!
        this.transform.localScale = scaleOriginal * Mathf.Lerp(1f, sizeMax, 1f);

        base.Update();
    }

    protected override void End()
    {
        fadeIndex.a = 0;
        render.color = fadeIndex;
        base.End();
    }
}
