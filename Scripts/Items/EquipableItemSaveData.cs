using System;
using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	[Serializable]
	public class EquipableItemSaveData : BaseItemSaveData
	{
		[SerializeField]
		public float[] Floats = Array.Empty<float>();

		public EquipableItemSaveData(string definitionId) : base(definitionId)
		{
		}
	}
}