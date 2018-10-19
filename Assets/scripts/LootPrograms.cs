using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootPrograms : MonoBehaviour {
	
	public string[] lootTypes = new string[] {"mine","oxygent","coins","diamond"};
	public GameObject[] LootDemo;

	private GameObject[] loots;
	private GameObject newLoot;
	private GameObject thisLoot;
	private int lootCount = 0; 
	//private Rigidbody2D diverBody2D;

	void Start(){
		InvokeRepeating("CreateLoot", 2.0f, 0.5f);
	}
	//void Awake(){
	//	diverBody2D = GetComponent<Rigidbody2D>();
	//}
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag =="Loot")
		{
			thisLoot = col.gameObject;
			Destroy(thisLoot);
			switch(col.gameObject.GetComponent<LootBehaviour>().lootType){
				case 0:
					FindObjectOfType<GameManager>().gameOver();
					break;
				case 1:
					var oxygen = FindObjectOfType<OxygenCountTracker>().oxygen+400; 
					FindObjectOfType<OxygenCountTracker>().oxygen=oxygen>1000?1000:oxygen;
					break;
				default:
					break;
			}
		}
	}
	void CreateLoot(){
		if(Random.Range(0,5) !=  0) return;/* Changing problability */
		
		int newLootType = Random.Range(0,LootDemo.Length-1);
		newLoot = Instantiate(LootDemo[newLootType]);
		LootBehaviour newBehaviour = newLoot.GetComponent<LootBehaviour>();
		newBehaviour.velocity = new Vector2(0,300 + (100* Random.Range(0.0f,1.0f)));
		Vector3 newPosition = LootDemo[newLootType].transform.position;
		newPosition[0] = Screen.width/2*Random.Range (-0.9f, 0.9f);
		newLoot.transform.position = newPosition;

		// loots[lootCount++] = newLoot;
	}

}
