using UnityEngine;

public class CameraController : MonoBehaviour {
	public float panSpeed = 30f;
	public float scrollSpeed = 30f;
	public float minimumHeight, maximumHeight, maximumLeft, maximumRight, maximumForward, maximumBackword;
	public float panBorderThickness = 10f;

	private bool canMove = true;
	void Start () {
		
	}
	void Update () {
		if(GameManager.IsGamOver) {
			this.enabled = true;
		}
		Vector3 position;
		if (Input.GetKeyDown(KeyCode.F)){
			canMove = !canMove;
		}
		if(!canMove) {
			return;
		}
		if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness) {
			position = transform.position;
			position.z += panSpeed * Time.deltaTime;
			position.z = Mathf.Clamp(position.z, maximumBackword, maximumForward);
			transform.position = position;
		}
		if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness) {
			position = transform.position;
			position.z -= panSpeed * Time.deltaTime;
			position.z = Mathf.Clamp(position.z, maximumBackword, maximumForward);
			transform.position = position;
		}
		if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness) {
			position = transform.position;
			position.x += panSpeed * Time.deltaTime;
			position.x = Mathf.Clamp(position.x, maximumLeft, maximumRight);
			transform.position = position;
		}
		if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness) {
			position = transform.position;
			position.x -= panSpeed * Time.deltaTime;
			position.x = Mathf.Clamp(position.x, maximumLeft, maximumRight);
			transform.position = position;
		}
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		position = transform.position;
		position.y -= scroll * scrollSpeed * Time.deltaTime * 100;
		position.y = Mathf.Clamp(position.y, minimumHeight, maximumHeight);
		transform.position = position;
	}
}
