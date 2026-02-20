using System;

namespace Kryz.RPG.Items.UI
{
	[Serializable]
	public class EquipableItemSaveData : ItemSaveData
	{
		public EquipableItemSaveData(string definitionId) : base(definitionId)
		{
		}
	}
}