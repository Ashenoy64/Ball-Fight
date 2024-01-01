using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyrb;
    private PlayerController psc;

    public float lowerBound = -10.0f;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        psc = player.GetComponent<PlayerController>();
        enemyrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(psc.isAlive)
        {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyrb.AddForce( lookDirection * speed);
        }

        if (transform.position.y < lowerBound)
            Destroy(gameObject);
    }
}
