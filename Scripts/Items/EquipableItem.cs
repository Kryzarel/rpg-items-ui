namespace Kryz.RPG.Items.UI
{
	public class EquipableItem : BaseItem
	{
		public new readonly EquipableItemDefinition Definition;

		public EquipableItem(EquipableItemDefinition definition) : base(definition)
		{
			Definition = definition;
		}

		public EquipableItem(EquipableItemDefinition definition, EquipableItemSaveData saveData) : this(definition)
		{
		}

		public override IItemSaveData ToSaveData() => new EquipableItemSaveData(Definition.Id);
	}
}