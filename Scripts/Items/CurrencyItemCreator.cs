namespace Kryz.RPG.Items.UI
{
	public class CurrencyItemCreator : ItemCreatorSingleton<CurrencyItemDefinition, CurrencyItem, ItemSaveDataSingleton>
	{
		public override CurrencyItem Create(CurrencyItemDefinition definition)
		{
			return new CurrencyItem(definition);
		}

		public override ItemSaveDataSingleton ToSaveData(CurrencyItem item)
		{
			return new ItemSaveDataSingleton(item.Definition.Id);
		}
	}
}