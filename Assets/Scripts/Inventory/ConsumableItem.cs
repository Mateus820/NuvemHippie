using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "Inventory/ConsumableItem", order = 0)]
public class ConsumableItem : ScriptableObject {
	public string name;
	public int id;
	public Sprite sprite;
	public string description;
}