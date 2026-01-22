namespace Kryz.RPG.Items.UI
{
	public sealed class EquipableItemCreator : ItemCreatorBase<EquipableItemDefinition, EquipableItemSaveData>
	{
		public override IItem Create(EquipableItemDefinition definition)
		{
			return new EquipableItem(definition);
		}

		public override IItem Create(EquipableItemDefinition definition, EquipableItemSaveData saveData)
		{
			return new EquipableItem(definition, saveData);
		}
	}
}