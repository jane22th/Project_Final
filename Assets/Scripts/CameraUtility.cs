using UnityEngine;
using System.Collections;

public class CameraUtility : MonoBehaviour {
	public float view_before_game = 115.0f;
	public float view_after_game = 70.0f;

	Camera m_cam;
	[System.NonSerialized] public bool m_flag_game = false;
		
	// Use this for initialization
	void Start () {
		m_cam = GetComponent<Camera> ();
		m_cam.fieldOfView = view_before_game;
	}

	public void changeView(){
		m_cam.fieldOfView = view_after_game;
	}

	// Update is called once per frame
	void Update () {
		if(m_flag_game)
			changeView ();
	}
}
