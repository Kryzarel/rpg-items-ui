namespace Kryz.RPG.Items.UI
{
	public class EquipableItemCreator : IItemCreator<EquipableItemDefinition>
	{
		public IItem GetOrCreate(EquipableItemDefinition definition)
		{
			return new EquipableItem(definition);
		}
	}
}