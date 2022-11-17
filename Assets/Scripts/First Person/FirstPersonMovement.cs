using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour {

		public float speed = 5f;
		public float sprintMultiplier = 1.25f;

		public float maxSpeed = 20f;

		Vector2 movementInput;
		Rigidbody rb;

		FirstPersonCamera fpc;

		[Space]
		public bool abilityToSprint = true;
		bool sprinting = false;

    void Awake() {
      rb = GetComponent<Rigidbody>();
    }

		void Start() {
			fpc = GetComponentInChildren<FirstPersonCamera>();
		}

    void Update() {
			movementInput.x = Input.GetAxisRaw("Horizontal");
			movementInput.y = Input.GetAxisRaw("Vertical");
			if (abilityToSprint == true) {
				sprinting = Input.GetKey(KeyCode.LeftShift);
				if (sprinting && rb.velocity.magnitude > 5f) {
					fpc.SetFOV(62.5f);
				}
				else {
					fpc.SetFOV(60f);
				}
			}
			if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.Space)) {
				Application.Quit();
			}
    }

		void FixedUpdate() {
			Vector3 movement = transform.right * movementInput.x + transform.forward * movementInput.y;
			if (sprinting) {
				rb.AddForce(movement.normalized * speed * 10f * sprintMultiplier, ForceMode.Force);
				rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed * sprintMultiplier);
			}
			else {
				rb.AddForce(movement.normalized * speed * 10f, ForceMode.Force);
				rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
			}

		}
}
