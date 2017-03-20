using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameWorld : MonoBehaviour {

     PointsManager pm;
  
    public int NumberOfPlayers;
     public bool backwards;
    public GameObject[] PlayerScoreObj;//stores the game objects which contain the score text
    public GameObject[] PlayerObjects;//stores the player objects used to easily refrence there colliders
    Text[] playerScoreText;//the score texts for all players
    public float[] score;

    Text switchSplash;
    public bool splash = false;
    public float splashTxtTime;

    int size;
    VortexEdited vortextScript;

    // Use this for initialization
    void Start () {
        backwards = false;
        size = PlayerScoreObj.Length;

        score = new float[size];
        playerScoreText = new Text[size];
        for (int i=0; i<size; i++)
        {
            playerScoreText[i] = PlayerScoreObj[i].GetComponent<Text>();
            score[i] = 0;
        }

        vortextScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<VortexEdited>();
        
        switchSplash = GameObject.FindGameObjectWithTag("SwitchSplashTxt").GetComponent<Text>();
        //make sure when game starts its disablede
        switchSplash.enabled = false;


        //emsures that on the launching of the game that all players can collide with each other
        for (int i = 0; i < PlayerObjects.Length; i++)
        {
            for(int e = i + 1; e< PlayerObjects.Length; e++)
            {
                Physics2D.IgnoreCollision(PlayerObjects[i].GetComponent<Collider2D>(), PlayerObjects[e].GetComponent<Collider2D>(), false);

            }
        }


        pm = GameObject.FindGameObjectWithTag("PointsControll").GetComponent<PointsManager>();
        pm.spawn(backwards);
    }
	
	// Update is called once per frame
	void Update () {

        if(backwards == false)
        {
            for (int i = 0; i < size; i++)
            {

                int id = i + 1;
                playerScoreText[i].text = "Player "+id +": " + score[i];
            }
        }
        else
        {
          

                for (int i = 0; i < size; i++)
            {
                int id = PlayerScoreObj.Length - i;
                float tempRevScore = 0 - score[i];
                playerScoreText[i].text = "Player " + id + ": " + tempRevScore;
            }
        }

    

        if(Input.GetKeyDown(KeyCode.F1))
        {
            Switch();

        }
    }


    public void Switch()
    {

        StartCoroutine(SwitchSplash("Switch",splashTxtTime));
        Debug.Log("Switch Called");
        int size = PlayerObjects.Length;
        if (backwards == false)
        {
            backwards = true;
            //sets gravity causing players to go upwards rather than fall
            Physics2D.gravity = new Vector2(0,9.81f);

            //sets all players to not collide with eachother
            for (int i = 0; i < size; i++)
            {
                for (int e = i + 1; e < size; e++)
                {
                    Physics2D.IgnoreCollision(PlayerObjects[i].GetComponent<Collider2D>(), PlayerObjects[e].GetComponent<Collider2D>());

                }
            }
        }
        else
        {
            backwards = false;
            Physics2D.gravity = new Vector2(0,-9.81f);

            //sets it so all players can collide with each other
            for (int i = 0; i < size; i++)
            {
                for (int e = i + 1; e < size; e++)
                {
                    Physics2D.IgnoreCollision(PlayerObjects[i].GetComponent<Collider2D>(), PlayerObjects[e].GetComponent<Collider2D>(), false);

                }
            }

        }

        pm.spawn(backwards);
    }


    private IEnumerator SwitchSplash(string msg, float delay)
    {


        vortextScript.radius = new Vector2(vortextScript.radius.x - 0.1f, vortextScript.radius.y - 0.1f);
        Debug.Log(vortextScript.radius.x);

        switchSplash.text = msg;
        switchSplash.enabled = true;
        splash = true;
        yield return new WaitForSeconds(delay);
        switchSplash.enabled = false;
        splash = false;

    }


}
