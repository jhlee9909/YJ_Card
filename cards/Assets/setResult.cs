using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class setResult : MonoBehaviour {
	public GameObject ONum,PNum;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetOScore(int onum){

		ONum.GetComponent<Text> ().text = onum.ToString ();

	}
	public void SetPScore(int pnum){


		PNum.GetComponent<Text> ().text = pnum.ToString ();

	}
}
