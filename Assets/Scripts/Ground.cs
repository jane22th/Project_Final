using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	GroundManager m_parent;

	// Use this for initialization
	void Start () {
		m_parent = transform.parent.gameObject.GetComponent<GroundManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2(-m_parent.speed, 0));
		if (transform.localPosition.x < -m_parent.boundary) {
			Vector3 update_position = transform.localPosition + new Vector3 (2*m_parent.boundary, 0, 0);
			transform.localPosition = update_position;
		}
	}
}
