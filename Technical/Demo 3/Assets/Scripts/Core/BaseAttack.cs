using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Director;

public class BaseAttack : MonoBehaviour {

    protected Animator anim;

    private float timeCountDown;

    protected BaseBody player;

    private bool onAttackEvent;

    public virtual void Init()
    {
        timeCountDown = 0;
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

    public virtual void CountDownTime()
    {
        Debug.Log(timeCountDown);
        if (timeCountDown > 0)
            timeCountDown -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            Debug.Log("enemyyyyyyyyyyyy");
            if (timeCountDown <= 0)
            {
                anim.Play(0);
                timeCountDown = 3.0f;
            }
        }
    }

    void OnTriggerStay2D(Collider2D target)
    {
        if (onAttackEvent && target.tag == "Enemy")
            Debug.Log("Danh trung");
    }

    public void UpdateAttackEvent(int e)
    {
        onAttackEvent = (e == 1) ? true : false;
    }
}
