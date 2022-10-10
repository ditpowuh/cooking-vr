using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Recipe")]
public class Recipe : ScriptableObject {

    public string recipeName;
    public List<Ingredient> ingredients;

}

[System.Serializable]
public class Ingredient {

    public string ingredientName;
    public int amount;
    public IngredientState state;

    [Space]
    public List<string> additionalAttributes;

}
