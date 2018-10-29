using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour {

	CharacterController  characterC;

	void  Start() {
		characterC = gameObject.GetComponent<CharacterController>();
	}

	void Update() {
		if(Input.GetKey(KeyCode.C)){
			characterC.height = 1.0f;
		}
		else{
			characterC.height = 1.8f;
		}
	}
}
