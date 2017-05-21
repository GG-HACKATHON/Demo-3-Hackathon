using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimator : MonoBehaviour {

    private Animator anim;

    private BaseBody baseBody;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        baseBody = GetComponent<BaseBody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
