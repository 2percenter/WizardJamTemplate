using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.States;
using Assets.Scripts.Interfaces;

public class ExampleWithStates : MonoBehaviour
{

    private StateManager manager;
    private bool bouncing; //Silly boolean for a silly example.

    // Use this for initialization
    void Start ()
    {
        manager = GameObject.FindObjectOfType<StateManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (manager.currentState == "GameState") //Can do this this way, or call particular methods within here from GameState.StatUpdate as well. Up to you.
        {
            if (!bouncing)
            {
                bouncing = true;
                StartCoroutine(WizardBounce());
            }
        }

    }


    IEnumerator WizardBounce() //This is just a dumb thing to use as an example.
    {
        float bounceHeight;
        Vector3 target;
        float startingHeight;
        float bounceSpeed = 2.0f;
        bool atPeak = false;
        bool atBottom = true;
        Vector3 bottom;

        startingHeight = gameObject.transform.position.y;
        bottom = gameObject.transform.position;
        bounceHeight = Random.Range(0.5f, 2.0f);
        target = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + bounceHeight, gameObject.transform.position.z);

        while (!atPeak)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, bounceSpeed*Time.deltaTime);
            if (gameObject.transform.position.y >= bounceHeight) //reached peak
            {
                atPeak = true;
            }
            yield return 0;
        }
        atBottom = false;

        while (!atBottom)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, bottom, bounceSpeed * Time.deltaTime);
            if (gameObject.transform.position.y <= startingHeight) //reached bottom
            {
                gameObject.transform.position = bottom; //Just to ensure we always go back to the real starting point.
                atBottom = true;
            }
            yield return 0;
        }


        bouncing = false;
        yield return 0;
    }

}
