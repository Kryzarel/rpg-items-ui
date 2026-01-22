using System;

namespace Kryz.RPG.Items.UI
{
	[Serializable]
	public class EquipableItemSaveData : ItemSaveDataBase
	{
		public EquipableItemSaveData(string definitionId) : base(definitionId)
		{
		}
	}
}