using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    public GameObject bottomWall;

    public int threshold = 10;

    private void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        float x = Random.Range((int) leftWall.transform.position.x+threshold, (int)rightWall.transform.position.x-threshold);
        float y = Random.Range((int)bottomWall.transform.position.y+threshold, (int)topWall.transform.position.y-threshold);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with tag: " + other.tag);

        if (other.tag != "Player") return;

        RandomizePosition();
    }
}

