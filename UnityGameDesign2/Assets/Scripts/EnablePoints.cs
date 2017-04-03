using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePoints : MonoBehaviour {
    GameWorld gameWorld;
	// Use this for initialization
	void Start () {
        gameWorld = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameWorld>();

    }

    public bool disableCondition;

    // Update is called once per frame
    void Update () {

       
            if(gameWorld.backwards == disableCondition)
            {

            GetComponent<Renderer>().enabled = true;

            }
            else
            {
            GetComponent<Renderer>().enabled = false;
            }
       

		
	}
}
