namespace Kryz.RPG.Items.UI
{
	public class CurrencyItemCreator : SingletonItemCreator<CurrencyItemDefinition>
	{
		protected override IItem Create(CurrencyItemDefinition definition)
		{
			return new CurrencyItem(definition);
		}
	}
}