using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour {

	
	float rotationAngle = 80;
	float smoothTime = 1.0f;
	public bool goingUp=false;
	
	public void goUp(){    
      goingUp=true;
	FindObjectOfType<LootBehaviour>().reverse();
	}


	void Update(){
	  if(goingUp){
			Quaternion desiredRotation = Quaternion.Euler (0,0,rotationAngle);
			transform.rotation = Quaternion.Lerp (transform.rotation, desiredRotation, smoothTime);
	  }
  }
}
