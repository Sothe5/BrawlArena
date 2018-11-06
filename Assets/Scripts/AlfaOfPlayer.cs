using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlfaOfPlayer : MonoBehaviour {

private SpriteRenderer mySpriteRenderer;

	void Start(){
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void turnAlfaUp (){
		Color color = mySpriteRenderer.color;
		color.a = 1;
		mySpriteRenderer.color = color;

	}


	public void turnAlfaDown (){
		Color color = mySpriteRenderer.color;
		color.a = 0.7f;
		mySpriteRenderer.color = color;
		
	}
}
