using UnityEngine;
using System.Collections;

public class GetAKey : MonoBehaviour {
	public float speed;
	private Rigidbody body;
	private Vector3 horizVector;
	private Vector3 vertVector;

	// Use this for initialization
	void Start () {
		speed = 10 / speed;
		body = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		//MOVE LOGIC

		float horiz = Input.GetAxis("Move Horizontal");
		if(horiz > 0)
		{
			horizVector.Set(1 / speed, 0, 0);
			move (horizVector);
		}
		else if(horiz < 0)
		{
			horizVector.Set(-1 / speed, 0, 0);
			move (horizVector);
		}
		else
		{
			horizVector = Vector3.zero;
		}

		float vert = Input.GetAxis("Move Vertical");
		if(vert > 0)
		{
			vertVector.Set(0, 0, 1 / speed);
			move (vertVector);
		}
		else if(vert < 0)
		{
			vertVector.Set(0, 0, -1 / speed);
			move (vertVector);
		}
		else
		{
			vertVector = Vector3.zero;
		}
	}

	private void move(Vector3 dir)
	{
        body.MovePosition(body.position + dir);
	}
}
