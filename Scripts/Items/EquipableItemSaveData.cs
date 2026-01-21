using System;
using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	[Serializable]
	public class EquipableItemSaveData : IItemSaveData
	{
		[field: SerializeField]
		public string DefinitionId { get; set; } = string.Empty;

		[SerializeField]
		public float[] Floats = Array.Empty<float>();
	}
}