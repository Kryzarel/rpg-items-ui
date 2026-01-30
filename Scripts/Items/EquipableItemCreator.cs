namespace Kryz.RPG.Items.UI
{
	public sealed class EquipableItemCreator : ItemCreatorBase<EquipableItemDefinition, EquipableItem, EquipableItemSaveData>
	{
		public override EquipableItem Create(EquipableItemDefinition definition)
		{
			return new EquipableItem(definition);
		}

		public override EquipableItem Create(EquipableItemDefinition definition, EquipableItemSaveData saveData)
		{
			return new EquipableItem(definition, saveData);
		}

		public override EquipableItemSaveData ToSaveData(EquipableItem item)
		{
			return new EquipableItemSaveData(item.Definition.Id);
		}
	}
}