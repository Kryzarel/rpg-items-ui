namespace Kryz.RPG.Items.UI
{
	public class CurrencyItemCreator : ItemCreatorSingleton<CurrencyItemDefinition>
	{
		public override IItem Create(CurrencyItemDefinition definition)
		{
			return new CurrencyItem(definition);
		}
	}
}