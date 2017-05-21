using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour {

    protected Animator anim;

    protected float timeAttackDelay;

    protected BaseBody player;

    private float tempTime;

    public virtual void Init(float timeAttackDelay)
    {
        tempTime = 0;
        this.timeAttackDelay = timeAttackDelay;
        anim = GetComponent<Animator>();
        
    }

	// Use this for initialization
    protected virtual void Start()
    {
        player = transform.parent.gameObject.GetComponent<BaseBody>();
        if (player == null || !player.leader)
        {
            gameObject.SetActive(false);
        }
	}
	

    void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log("hitttttttttt");
    }

    public virtual void DoAttack()
    {
        if (tempTime <= 0)
        {
            anim.Play(0);
            tempTime = timeAttackDelay;
        }
        else
            tempTime -= Time.deltaTime;

    }
}
