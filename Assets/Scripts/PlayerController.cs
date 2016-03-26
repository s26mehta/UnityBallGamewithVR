using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int count;

	private Rigidbody rb;

	public Text countText;
	public Text winText;

	void Start() {
		rb = GetComponent<Rigidbody> ();

		count = 0;
		countText.text = "Count: " + count.ToString ();
		winText.text = "";
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other) {
		//Destroy(other.gameObject);
		if (other.gameObject.CompareTag("Pickup"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			countText.text = "Count: " + count.ToString ();
			SetCountText ();
		}
	}

	void SetCountText() {
		if (count >= 11) {
			winText.text = "You Win!";
		}
	}
}
