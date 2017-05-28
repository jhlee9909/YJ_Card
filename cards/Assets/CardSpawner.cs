using UnityEngine;
using System.Collections;

public class CardSpawner : MonoBehaviour {
	public GameObject[] DiaCardSet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Spawn(int temp){
		
		GameObject card = (GameObject)Instantiate (DiaCardSet[temp-1], gameObject.transform.position ,DiaCardSet[temp-1].transform.rotation);

			//card.transform.SetParent (gameObject.transform.GetChild (0));
		card.transform.SetParent(gameObject.transform);

	}

	public void Turn(){
		
		//gameObject.transform.Translate (400, 0, 0); 
		gameObject.transform.rotation = Quaternion.Euler( new Vector3 (180, 0, 0) );
	}
}
