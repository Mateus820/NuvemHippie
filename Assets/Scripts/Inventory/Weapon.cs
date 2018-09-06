using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Weapon", order = 0)]
public class Weapon : ScriptableObject {

	public string name;
	public int id;
	public Sprite sprite;
	public string description;
}
