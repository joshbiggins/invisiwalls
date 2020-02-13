using UnityEngine;
using System.Collections;

public class TransparencyWallController : MonoBehaviour {
	public float outTransTime = 0.5f;
    public float inTransTime = 0.5f;

	private MeshRenderer mr;
    private bool isTransparent;
    private float newAlpha;
    private float currentOutTransTime;
    private float currentInTransTime;
    
	void Start () {
		mr = gameObject.GetComponent<MeshRenderer> ();
        newAlpha = 1.0f;
	}

	void FixedUpdate () {
        //If fading out, reduce fadeout time
		if (currentOutTransTime > 0 && isTransparent) {
            currentOutTransTime -= Time.deltaTime;
            newAlpha = 0.7f + (0.3f * (currentOutTransTime / outTransTime));
            mr.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, newAlpha));
        }
        else if(currentOutTransTime <= 0 && isTransparent)
        {
            isTransparent = false;
            currentInTransTime = inTransTime;
        }

        //If fading out, reduce fadeout time
        if (currentInTransTime > 0 && !isTransparent)
        {
            currentInTransTime -= Time.deltaTime;
            newAlpha = 1.0f - (0.3f * (currentInTransTime / inTransTime));
            mr.material.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, newAlpha));
        }
    }

    //Start transparency fadeout
    public void StartTransparencyFadeOut()
    {
        if(currentOutTransTime <= 0 && newAlpha >= 1.0f)
        {
            currentOutTransTime = outTransTime;
        }
        isTransparent = true;
    }
}
