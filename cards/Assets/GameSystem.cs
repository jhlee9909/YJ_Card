using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;//For Use List
public class GameSystem : MonoBehaviour {
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

		for(int i = 0 ; i < CardListA.Count ; i ++){
			Debug.Log (CardIndexA [i]);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void DrawCard(){
		
		int ran1 = UnityEngine.Random.Range (0, CardListA.Count-1);

		int temp = CardListA[ran1];

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
