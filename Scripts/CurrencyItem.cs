namespace Kryz.RPG.Items.UI
{
	public class CurrencyItem : BaseItem, IStackable
	{
		public new CurrencyItemDefinition Definition { get; private set; }
		public int MaxStacks => Definition.MaxStacks;

		public CurrencyItem(CurrencyItemDefinition definition) : base(definition)
		{
			Definition = definition;
		}
	}
}