using UnityEngine;

public class Detection : MonoBehaviour {

    public float TimeToSpawn;

    public BasePlayerWeapon projectile;

    private BaseBody player;

    private float delayTime;

	// Use this for initialization
	void Start () {
        player = transform.parent.GetComponent<BaseBody>();
        delayTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            if (delayTime <= 0)
            {
                BasePlayerWeapon proj = Instantiate(projectile.gameObject,
                  player.gameObject.transform.position,
                  Quaternion.identity).GetComponent<BasePlayerWeapon>();

                proj.SetTargetPosition(target.transform.position);

                delayTime = TimeToSpawn;
            }
            else
                delayTime -= Time.deltaTime;
        }
    }
}
