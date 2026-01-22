using System;
using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	[Serializable]
	public class EquipableItemSaveData : ItemSaveDataBase
	{
		[SerializeField]
		public float[] Floats = Array.Empty<float>();

		public EquipableItemSaveData(string definitionId) : base(definitionId)
		{
		}
	}
}