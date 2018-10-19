using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBehaviour : MonoBehaviour {
	public Vector2 velocity=Vector2.zero;
	public int lootType;
	public string lootName;
	public float lootValue;
	public float lootBirthTime;
	
	private Rigidbody2D body2D;
	
	void Awake(){
      body2D=GetComponent<Rigidbody2D>();
	}
	void FixedUpdate(){
		body2D.velocity = velocity;
	}
	void reverse(){
		velocity = velocity*-1;
	}
}
