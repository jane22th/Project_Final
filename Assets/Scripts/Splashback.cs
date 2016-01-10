using UnityEngine;
using System.Collections;

public class Splashback : MonoBehaviour {
	GameObject linked_board;

	// Use this for initialization
	void Start () {
		linked_board = transform.Find ("Iris Board").gameObject;
	}

	void OnMouseDown(){
		linked_board.GetComponent<IrisBoard> ().m_flag_transition = true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
