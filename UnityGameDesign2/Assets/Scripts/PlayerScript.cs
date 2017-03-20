using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour {


//	public PointsManager pm;
     GameWorld gameWorld;
	public string playerName;
	//public float playerScore = 0;
    public float movementSpeed;
    public float maxSpeed;//max speed
    float maxSpeedNegative;
    public float jumpForce;
    public string verticalControlAxis;
    public string HorizontalControlAxis;
    public int ID;

    private Rigidbody2D rb;
    bool jumpKeyDown;
	bool isOnFloor;

	public Text playerLable;

	public Transform topLablePos;
	public Transform bottomLablePos;

	// Use this for initialization
    void Start () {
        maxSpeedNegative = 0 - maxSpeed;
        rb = GetComponent<Rigidbody2D>();
        jumpKeyDown = false;
      //	pm = GameObject.FindGameObjectWithTag("PointsControll").GetComponent<PointsManager>();
        gameWorld = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameWorld>();



    }
	
	// Update is called once per frame
	void Update () {
		//should put input checking inhere 


		if (gameWorld.backwards == false)
		{
			playerLable.transform.position = topLablePos.position;
			playerLable.text = "P" + (ID+1).ToString();


		}
		else
		{
			playerLable.transform.position = bottomLablePos.position;
			int id = gameWorld.PlayerScoreObj.Length - ID;
			playerLable.text = "P" + id.ToString();
		}

        if (Input.GetButtonDown(verticalControlAxis) == true && isOnFloor == true)
        {
            jumpKeyDown = true;
        }


		//rb.velocity = Vector3.zero;
		//rb.angularVelocity = 0;

	}

    

    void FixedUpdate()
    {

        
       //    Debug.Log("ID: " + ID + " " + Input.GetAxis(HorizontalControlAxis));
            float moveHorizontal = Input.GetAxis(HorizontalControlAxis) * movementSpeed;
            
        if(gameWorld.backwards == true)
        {
            moveHorizontal  -= (moveHorizontal*2);


        }            

            if (jumpKeyDown == true && isOnFloor == true)
            {           
                if (gameWorld.backwards == false)
                     rb.velocity = new Vector2(0, jumpForce);
                else
                 {
                     float jumpForceBackwards = jumpForce - (jumpForce*2);
                     rb.velocity = new Vector2(0, jumpForceBackwards);
                 }
                isOnFloor = false;
                jumpKeyDown = false;
            }



            Vector2 movement = new Vector2(moveHorizontal, rb.velocity.y);

            rb.AddForce(movement);
            // Debug.Log(" pre Positive X movement, value: " + rb.velocity.x.ToString());

            if (rb.velocity.x > maxSpeed)
            {
                if (rb.velocity.magnitude > maxSpeed)
                {

                    //        Debug.Log("Positive X movement, value: " + rb.velocity.x.ToString());

                    rb.velocity = new Vector2(maxSpeed, rb.velocity.y);

                }

            }
            else if (rb.velocity.x < maxSpeedNegative)
            {
                //   Debug.Log("Negative X movement, value: " + rb.velocity.x.ToString());
                rb.velocity = new Vector2(maxSpeedNegative, rb.velocity.y);
            }

        
       
    }

	//this is called when player collides with another 2D trigger
	private void OnTriggerEnter2D(Collider2D collision)
	{

	//	Debug.Log("OnTriggerEnter2D called");

		if (collision.gameObject.tag == "Score")
		{
            //playerScore += 1;
            gameWorld.score[ID] += 1;
        //    Debug.Log(gameWorld.score);

			//destory point
			Destroy(collision.gameObject);

            gameWorld.Switch();

            //pm.spawn();
		//collision.gameObject.transform.position.Set(30,30, collision.gameObject.transform.position.z);
		
		
		
		//call switch function which will reverse gameplay
		}

		
	}


	private void OnCollisionEnter2D(Collision2D collision)//called when two object collide
	{
	//	Debug.Log("Entered collision with object");
		//replace with raycasting later?

		//checks if object is tagged floor if so sets isOnFloor to true
		if (collision.gameObject.tag == "Floor")
		{
		//	Debug.Log("Collided object is tagged with Floor");

			isOnFloor = true;
		}

	}
}
