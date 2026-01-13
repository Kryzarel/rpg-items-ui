namespace Kryz.RPG.Items.UI
{
	public class EquipableItem : BaseItem
	{
		public new EquipableItemDefinition Definition { get; private set; }

		public EquipableItem(EquipableItemDefinition definition) : base(definition)
		{
			Definition = definition;
		}
	}
}