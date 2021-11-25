using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller;

	public float runSpeed = 40f;

	//[SerializeField] UnityEvent OnChunkThresholdPassedEvent;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	//private Chunk activeChunk;

   void Start()
    {
		transform.position = new Vector3(20, 25, 0);
	}

    // Update is called once per frame
    void Update()
	{
		//if (transform.position.x >= activeChunk.XSpawnThreshold && !activeChunk.HasNeighbour)
		//{
		//	print("Should Spawn");
		//	OnChunkThresholdPassedEvent?.Invoke();
		//}
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		//if (Input.GetButtonDown("Crouch"))
		//{
		//	crouch = true;
		//}
		//else if (Input.GetButtonUp("Crouch"))
		//{
		//	crouch = false;
		//}

		
		
	}

	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}

	//public void SetActiveChunk(Chunk chunk)
    //{
	//	activeChunk = chunk;
    //}
}
