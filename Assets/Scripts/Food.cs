using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

		public string itemName;
		public IngredientState state;

		[Space]
		public float temperature = 20f;
		public int value = 0;

    public List<string> additionalAttributes;

    void Start() {

    }

    void Update() {

    }
}
