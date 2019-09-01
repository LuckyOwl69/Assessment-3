using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienmissilemanager : MonoBehaviour
{

    public int alienDirection;
    // Start is called before the first frame update
    void Start()
    {
        alienDirection = Random.Range(1, 3);

        if(alienDirection ==1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, -2);

        }

        if (alienDirection >1)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2, -2);

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "explosion(Clone)")
        {
            gamemanager.playerScore += 100;
            Destroy(gameObject);

        }


    }
}
