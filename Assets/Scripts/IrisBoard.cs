using UnityEngine;
using System.Collections;

public class IrisBoard : MonoBehaviour {
	public float delta_iris = 0.02f;
	public float delta_move = 0.02f;
	public float boundary_move = 5.5f;
	public Sprite change_sprite;

	[System.NonSerialized] public bool m_flag_transition;
	bool m_flag_transition_move;

	Transform parent;

	// Use this for initialization
	void Start () {
		m_flag_transition = false;
		m_flag_transition_move = false;
		parent = transform.parent;
	}

	void transitionIris(){
		Vector2 scale = transform.localScale;
		scale -= new Vector2(delta_iris, delta_iris);
		if (scale.x <= 0.2f) {
			GetComponent<SpriteRenderer> ().sprite = change_sprite;
			scale = new Vector2 (1.0f, 1.0f);
			m_flag_transition = false;
			m_flag_transition_move = true;
			parent.parent.gameObject.GetComponent<CameraUtility> ().m_flag_game = true;
		}
		transform.localScale = scale;
	}

	void transitionMove(){
		parent.Translate (new Vector2(delta_move, 0));
		if (parent.localPosition.x > boundary_move) {
			m_flag_transition_move = false;
			parent.gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (m_flag_transition) {
			transitionIris ();		
		}

		if (m_flag_transition_move) {
			transitionMove ();
		}
	}
}
