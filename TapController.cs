using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TapController : MonoBehaviour {

	public Rigidbody rigidBody;
	public Vector2 jumpForce = new Vector2(0, 4f);

	void Update () {
		if (this.UserDidTapOnPhone () && !this.UserTappedOnMenu() || this.UserDidEditorTap()) {
			this.AddForceToGameObject ();
		}
	}

	private void AddForceToGameObject() {
		this.rigidBody.velocity = Vector2.zero;
		this.rigidBody.AddForce(this.jumpForce, ForceMode.Impulse);
	}

	private bool UserDidTapOnPhone() {
		var didTap = false;
		foreach(Touch touch in Input.touches) {
			if(touch.phase == TouchPhase.Began) {
				didTap = true;
			}
		}
		return didTap;
	}

	private bool UserTappedOnMenu() {
		bool didTapMenu = false;
		if(Input.touchCount > 0) {
			int pointerID = Input.touches[0].fingerId;
			if (EventSystem.current.IsPointerOverGameObject(pointerID))
			{
				didTapMenu = true;
			}
		}
		return didTapMenu;
	}
		
	private bool UserDidEditorTap() {
		var didEditorTap = false;
		if(Application.isEditor && Input.GetKeyUp(KeyCode.Space)) {
			didEditorTap = true;
		}
		return didEditorTap;
	}
}