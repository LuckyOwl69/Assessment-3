using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    float newscale = 2.5f;

    public Texture2D defaultCursor;
    public CursorMode cursor = CursorMode.Auto;
    public Vector2 target = Vector2.zero;

    public static Vector2 cursorPosition;
    public static Vector2 gamePosition;
    public static Vector2 previousgamePosition;

    public KeyCode shootMissileOne;
    public KeyCode shootMissileTwo;
    public KeyCode shootMissileThree;

    public Transform missileSprite;

    public Transform missileTarget;

    public Transform alienObject;

    public static int missileCountBattery1 = 10;
    public static int missileCountBattery2 = 10;
    public static int missileCountBattery3 = 10;

    public Transform missileCountObject1;
    //public Transform missileCountObject2;
    //public Transform missileCountObject3;

    public float alienSpawnTimer;

    public int spawnlocations;

    public static int playerScore = 0;

    public Transform playerScoreObject;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(defaultCursor, target, cursor);
    }

    // Update is called once per frame
    void Update()
    {
        alienSpawnLocations();

        missileCountObject1.GetComponent<TextMesh> ().text = missileCountBattery1.ToString();
        //missileCountObject2.GetComponent<TextMesh> ().text = missileCountBattery2.ToString();
        //missileCountObject3.GetComponent<TextMesh> ().text = missileCountBattery3.ToString();


        cursorPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        gamePosition = Camera.main.ScreenToWorldPoint(cursorPosition);

        playerScoreObject.GetComponent<TextMesh>().text = "Score: " + playerScore;

        if ((Input.GetKeyDown(shootMissileOne)) && (missileCountBattery1>0))
        {
            Instantiate(missileSprite, new Vector2(-10, -3), missileSprite.rotation);
            Instantiate(missileTarget, gamePosition, missileTarget.rotation);
            missileTarget.transform.localScale = new Vector2(newscale, newscale);
            missileCountBattery1 -= 1;
        }

        if (Input.GetKeyDown(shootMissileTwo))
        {
            Instantiate(missileSprite, new Vector2(0, -3), missileSprite.rotation);
            Instantiate(missileTarget, gamePosition, missileTarget.rotation);
            missileTarget.transform.localScale = new Vector2(newscale, newscale);
            missileCountBattery2 -= 1;

        }

        if (Input.GetKeyDown(shootMissileThree))
        {
            Instantiate(missileSprite, new Vector2(10, -3), missileSprite.rotation);
            Instantiate(missileTarget, gamePosition, missileTarget.rotation);
            missileTarget.transform.localScale = new Vector2(newscale, newscale);
            missileCountBattery3 -= 1;

        }
    }

    void alienSpawnLocations()
    {
        alienSpawnTimer += Time.deltaTime;
        if (alienSpawnTimer>2)
        {
            spawnlocations = Random.Range(-7, 7);
            alienSpawnTimer = 0;
            Instantiate(alienObject, new Vector2(spawnlocations, 6), alienObject.rotation);
        }


    }
}
