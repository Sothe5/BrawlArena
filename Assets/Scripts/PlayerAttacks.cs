using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour {

	public GameObject RightWarning;

	public GameObject neutral;

	private bool isAttacking = false;
	
	void FixedUpdate () {
		
		if(Input.GetKeyDown(KeyCode.J) && isAttacking == false){
			StartCoroutine (NeutralAttack());
		}

	}

	public IEnumerator NeutralAttack (){
		isAttacking = true;
		
		RightWarning.SetActive(true);

		yield return new WaitForSecondsRealtime(0.1f); // startup frame
		RightWarning.SetActive(false);
		GameObject aux = Instantiate(neutral, new Vector3(transform.position.x +1,transform.position.y,transform.position.z),Quaternion.identity);

		yield return new WaitForSecondsRealtime(0.08f); // duracion de los frames de hitbox del golpe
		Destroy(aux);

		yield return new WaitForSecondsRealtime(0.5f); // tiempo para que te castiguen porq no puedes atacar

		isAttacking = false;
	}
}
