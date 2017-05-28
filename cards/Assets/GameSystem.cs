using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;//For Use List

using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour {

	int count=0;
	int Ocount=0;
	public GameObject CardSpawner;
	public GameObject OppoCardSpawner;
	public bool isGameEnd;

	public GameObject ScorePanel;

	public int PNum,ONum;

	public enum CardSetA{
		one = 1,
		two,
		three,
		four,
		five,
		six,
		seven,
		eight,
		nine,
		ten,
		jack,
		queen,
		king
	}

	List<int> CardIndexA = new List<int>();
	List<int> CardListA = new List<int>();

	void Awake(){

		foreach(CardSetA csa in Enum.GetValues(typeof(CardSetA))){
			CardListA.Add ((int)csa);
		}
		foreach(CardSetA csa in Enum.GetValues(typeof(CardSetA))){
			CardIndexA.Add ((int)csa-1);
		}

	}
	// Use this for initialization
	void Start () {
		
//		for(int i = 0 ; i < CardListA.Count ; i ++){
//			Debug.Log (CardIndexA [i]);
//		}
		Debug.Log (CardListA [0]);
		Debug.Log (CardListA[CardListA.Count-1]);

		GameInit();
		DrawCard ();
		DrawCard ();
		SingleOppoDraw ();
		SingleOppoDraw ();


	}
	
	// Update is called once per frame
	void Update () {
		SetScore ();
	}
	public void ReGame(){
		SceneManager.LoadScene ("BasicScene");
	}
	public void GameInit(){
		PNum = 0;
		ONum = 0;
		count = 0;
		Ocount = 0;
	}
	public void SetScore(){
		if (!isGameEnd) {
			ScorePanel.SetActive (false);
			return;
		}
		if (isGameEnd) {
			ScorePanel.SetActive (true);
			ScorePanel.SendMessage ("SetOScore", ONum);
			ScorePanel.SendMessage ("SetPScore", PNum);
		}

	}
	public void EndTurn(){

		for (int i = 0; i < GameObject.FindGameObjectsWithTag ("OCard").Length; i++) {
			//Debug.Log (GameObject.FindGameObjectsWithTag ("OCard") [i].GetComponentInChildren<Animator> ());
		//	GameObject.FindGameObjectsWithTag ("OCard") [i].GetComponentInChildren<Animator> ().SetTrigger ("CardOpen");
			GameObject.FindGameObjectsWithTag ("OCard") [i].BroadcastMessage("Turn");
		}
		isGameEnd = true;

	}
	public void DrawCard(){
		if (count >= 3) {
			return;
		}
		if (isGameEnd) {
			return;
		}
		count++;

		if (count > 2 && ONum < 21) {
			SingleOppoDraw ();
		}

		if (GameObject.FindGameObjectsWithTag ("CardSet").Length>0) {
		
			if (count <= 2) {
				for (int i = 0; i < GameObject.FindGameObjectsWithTag ("CardSet").Length; i++) {
					GameObject.FindGameObjectsWithTag ("CardSet") [i].transform.Translate (-200, 0, 0);
				}
			}


		}
		int ran1 = (int)UnityEngine.Random.Range (0, CardListA.Count);

		int temp = CardListA[ran1];
		Debug.Log ("Draw : " + temp);
		PNum += temp;
			
		GameObject card = (GameObject)Instantiate (CardSpawner, new Vector3(0,0,0), CardSpawner.transform.rotation);
		if (count > 2) {
			card.transform.Translate (200, 0, 0);
		}
		card.transform.SetParent(GameObject.Find("CardPanel").transform);



		card.BroadcastMessage("Spawn", temp, SendMessageOptions.DontRequireReceiver);





		CardListA.RemoveAt( ran1 );


	}

	public void SingleOppoDraw(){
		if (Ocount >= 3) {
			return;
		}
		if (isGameEnd) {
			return;
		}
		Ocount++;
		if (Ocount <= 2) {
			for (int i = 0; i < GameObject.FindGameObjectsWithTag ("OCard").Length; i++) {
				GameObject.FindGameObjectsWithTag ("OCard") [i].transform.Translate (-200, 0, 0);
			}
		}
		GameObject card = (GameObject)Instantiate (OppoCardSpawner, new Vector3(0,0,0), OppoCardSpawner.transform.rotation);

		if (Ocount > 2) {
			card.transform.Translate (200, 0, 0);
		}

		card.transform.SetParent(GameObject.Find("OCardPanel").transform);



		int ran1 =  (int)UnityEngine.Random.Range (0, CardListA.Count);

		int temp = CardListA[ran1];
		ONum += temp;
		Debug.Log ("Draw : " + temp);
		card.BroadcastMessage("Spawn", temp, SendMessageOptions.DontRequireReceiver);
		CardListA.RemoveAt( ran1 );

	}
































	//Not Working//

//	public void StartDraw(){
//		
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//		CheckAndDraw (CardIndexA);
//
//
//	}
//	public void CheckAndDraw(List<int> CardList){
//		Debug.Log (CardIndexA.Count + "장 남음");
//
//		int Ran1 = (int)Random.Range (0, CardList.Count);
//
//		if (!DidNumber.Contains (CardIndexA[Ran1])) {
//			DidNumber.Add (CardIndexA[Ran1]);
//			Debug.Log (CardIndexA [Ran1] + "뽑았으므로 추가");
//		}
//
////		for (; DidNumber.Contains (CardIndexA[Ran1]);) {
////			Ran1 = (int)Random.Range (1, CardList.Count);
////		}
//
//			
//		while (DidNumber.Contains (CardIndexA [Ran1])) {
//			Ran1 = (int)Random.Range (0, CardList.Count);
//		}
//
//
//
//
//
//		switch ( CardIndexA[Ran1] ) {
//
//		case (int)CardSetA.one:
//			Debug.Log ("1 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.two:
//			Debug.Log ("2 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.three:
//			Debug.Log ("3 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.four:
//			Debug.Log ("4 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.five:
//			Debug.Log ("5 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.six:
//			Debug.Log ("6 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.seven:
//			Debug.Log ("7 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.eight:
//			Debug.Log ("8 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.nine:
//			Debug.Log ("9 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.ten:
//			Debug.Log ("10 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.jack:
//			Debug.Log ("11 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.queen:
//			Debug.Log ("12 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		case (int)CardSetA.king:
//			Debug.Log ("13 DRAW");
//			if(CardIndexA.BinarySearch(Ran1)>=0 && CardIndexA.BinarySearch(Ran1)<=CardIndexA.Count)
//			CardIndexA.RemoveAt(CardIndexA.BinarySearch(Ran1));
//			break;
//		}
//
////		int temp1 = CardList.BinarySearch(Ran1);
////
////		int tempValue = CardList [temp1];
////		CardList.RemoveAt (temp1);
////
////
////		Debug.Log ("드로우 : " + tempValue +"("+Ran1+")번째");
////		Debug.Log(CardList.Count +"(남은 카드 수)");
////		Debug.Log(CardIndexA.Count +"(남은 카드 수/A)");
//	}
}
