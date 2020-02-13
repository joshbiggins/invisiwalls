using UnityEngine;
using System.Collections;

public class TransparencyController : MonoBehaviour {
	private RaycastHit wallHit;
	private RaycastHit playerHit;
	private Ray ray;
	private Camera cam;
	private Transform player;
	private int transparentMask;
	private int playerMask;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		player = (Transform)GameObject.Find ("Player").GetComponent<Transform>();
		int maskname = LayerMask.NameToLayer ("Transparent");
		transparentMask = 1 << 8;
		playerMask = 1 << 9;
	}
	
	// Update is called once per frame
	void Update () {
        //Cast ray from camera to player position
		ray = new Ray (cam.transform.position, (player.position - cam.transform.position));
        //Test if ray hits object on the transparency layer
		if (Physics.Raycast (ray, out wallHit, 10000, transparentMask)) {
            //Test if ray hits the player object
			if(Physics.Raycast(ray, out playerHit, 10000, playerMask)) {
                //If object is between camera and player, set transparency of object's first material
				if(wallHit.distance < playerHit.distance) {
                    wallHit.collider.GetComponent<TransparencyWallController>().StartTransparencyFadeOut();
				}
			}
		}
	}
}
