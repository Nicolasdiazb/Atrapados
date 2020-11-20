using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{

    public float speed;

    public Transform[] moveSpots;
    private int randomSpots;
    private float waitTime;
    public float startWaitTime;
    // Start is called before the first frame update
    void Start()
    {
        randomSpots = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpots].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpots].position)<0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpots = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }

    }
}
