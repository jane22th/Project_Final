using UnityEngine;
using UnityEditor;
using System.Collections;

public sealed class ViewportEditor : Editor {
	public static int m_current_camera_number = 1;
	public static int m_split_vertical = 1;
	public static int m_split_horizental = 1;

	//Camera tag를 모두 삭제
	[MenuItem("ViewportTools/Reset")]
	static void resetViewport(){
		GameObject[] camera_list = GameObject.FindGameObjectsWithTag ("Camera");

		for (int i = 0; i < camera_list.Length; i++)
			DestroyImmediate (camera_list [i]);

		m_current_camera_number = 1;
		m_split_vertical = 1;
		m_split_horizental = 1;

		addCamera ().GetComponent<Camera>().backgroundColor = new Color(0, 0, 0);

		Debug.Log ("reset viewport");
	}

	//camera를 vertical 갯수 만큼 추가하고 모든 camera를 동등하게 
	[MenuItem("ViewportTools/Split/Horizental")]
	static void splitHorizental(){
		GameObject[] camera_list = GameObject.FindGameObjectsWithTag ("Camera");

		m_split_horizental++;
		float height = 1.0f / m_split_horizental;
		float width = 1.0f / m_split_vertical;
		float y = 0.0f;
		float x = -width;

		for (int i = 0; i < camera_list.Length; i++) {
			if (i % (m_split_horizental - 1) == 0) {
				y = 0;
				x += width; 
			}
			Camera cur_Camera = camera_list [i].GetComponent<Camera> ();
			cur_Camera.rect = new Rect (x, y, width, height);
			y += height;
		}
		x = 0;
		//새로운 카메라 처리
		for (int i = 0; i < m_split_vertical; i++) {
			m_current_camera_number++;
			Camera cur_Camera = addCamera().GetComponent<Camera>();
			cur_Camera.rect = new Rect (x, y, width, height);
			x += width;
		}
			
		Debug.Log ("split horizental");
	}

	//camera를 horizental 갯수 만큼 추가하고 모든 camera를 동등하게
	[MenuItem("ViewportTools/Split/Vertical")]
	static void splitVertical(){
		GameObject[] camera_list = GameObject.FindGameObjectsWithTag ("Camera");

		m_split_vertical++;
		float width = 1.0f / m_split_vertical;
		float height = 1.0f / m_split_horizental;
		float x = 0;
		float y = -height;

		for (int i = 0; i < camera_list.Length; i++) {
			if (i%(m_split_vertical-1) == 0) {
				x = 0;
				y += height;
			}
			Camera cur_Camera = camera_list [i].GetComponent<Camera> ();
			cur_Camera.rect = new Rect (x, y, width, height);
			x += width;
		}

		y = 0;
		for (int i = 0; i < m_split_horizental; i++) {
			m_current_camera_number++;
			Camera cur_Camera = addCamera ().GetComponent<Camera> ();
			cur_Camera.rect = new Rect (x, y, width, height);
			y += height;
		}

		Debug.Log ("split vertical");
	}

	//pop-up창을 만들어 합칠2개 camera number 넘겨받아서 합침
	[MenuItem("ViewportTools/Merge")]
	static void mergeTwoViewport(){
		Debug.Log ("merge");
	}

	static GameObject addCamera(){
		GameObject camera = new GameObject ();
		camera.name = "Camera_" + m_current_camera_number.ToString();
		camera.tag = "Camera";
		camera.transform.position = Vector3.zero;

		Camera camera_Camera = camera.AddComponent<Camera> ();
		camera_Camera.orthographic = false;

		camera_Camera.backgroundColor = new Color ((float)Random.Range(0,1.0f), (float)Random.Range(0,1.0f), (float)Random.Range(0,1.0f));

		return camera;
	}
}