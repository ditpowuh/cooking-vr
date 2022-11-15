using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {

		public float mouseSensitivity = 1f;

		float rotationX = 0f;

		Vector2 mouseInput;
		GameObject player;

		Camera playerCamera;
		Animator animator;

    void Start() {
			Cursor.lockState = CursorLockMode.Locked;
			player = transform.parent.gameObject;

			playerCamera = GetComponent<Camera>();
			animator = GetComponent<Animator>();
    }

    void Update() {
			mouseInput.x = Input.GetAxis("Mouse X") * mouseSensitivity * 100f * Time.deltaTime;
			mouseInput.y = Input.GetAxis("Mouse Y") * mouseSensitivity * 100f * Time.deltaTime;

			rotationX = rotationX - mouseInput.y;
			rotationX = Mathf.Clamp(rotationX, -90f, 90f);
			transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
			player.transform.Rotate(Vector3.up * mouseInput.x);

			animator.SetBool("Crouching", Input.GetKey(KeyCode.LeftControl));
    }

		public void SetFOV(float fov) {
			playerCamera.fieldOfView = fov;
		}
}
