using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCollection : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		print("es");
		if(col.gameObject.tag =="Oxygen")
		{Destroy(col.gameObject);
		  FindObjectOfType<OxygenCountTracker>().oxygen+=500;
		}

	}


}
