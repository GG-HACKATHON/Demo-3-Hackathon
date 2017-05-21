using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZZZ : MonoBehaviour
{

	public void Up()
    {
        transform.position += Vector3.up * 0.5f;
    }

    public void Down()
    {
        transform.position += Vector3.down * 0.5f;
    }

    public void Left()
    {
        transform.position += Vector3.left * 0.5f;
    }

    public void Right()
    {
        transform.position += Vector3.right * 0.5f;
    }
}
