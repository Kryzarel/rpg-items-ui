namespace Kryz.RPG.Items.UI
{
	public class EquipableItem : BaseItem
	{
		public new readonly EquipableItemDefinition Definition;

		public EquipableItem(EquipableItemDefinition definition) : base(definition)
		{
			Definition = definition;
		}
	}
}