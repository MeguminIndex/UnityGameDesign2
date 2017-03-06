using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour {

    // Use this for initialization
   public bool Collision;

	void Start () {
        Collision = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Collision = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Collision = false;
    }

}
