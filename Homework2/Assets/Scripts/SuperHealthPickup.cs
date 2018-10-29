using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperHealthPickup : MonoBehaviour {

	[SerializeField] private int _heal = 60;
	
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "mutant" || other.gameObject.tag == "mutant2" || other.gameObject.tag == "byStander"){
			return;
		}
		PlayerController player = other.GetComponent<PlayerController>();
		if(player != null){
			player.HealthPickup(_heal);
		}
		Destroy(this.gameObject);
	}
}