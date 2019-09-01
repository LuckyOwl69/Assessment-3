using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missilemanager : MonoBehaviour
{
    public float timer = 0;
    public float distance = .01f;

    public Transform explosion;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager.gamePosition = gamemanager.previousgamePosition;
        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 45);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > .04)
        {
            distance += .01f;
            timer = 0;
        }

        transform.position = Vector2.Lerp(transform.position, gamemanager.gamePosition, distance);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "cursor(Clone)") 
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, explosion.rotation);
        }
    }
}
