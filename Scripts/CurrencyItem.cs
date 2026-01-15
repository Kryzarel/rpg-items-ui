namespace Kryz.RPG.Items.UI
{
	public class CurrencyItem : BaseItem
	{
		public new CurrencyItemDefinition Definition { get; private set; }
		public override int MaxStacks => Definition.MaxStacks;

		public CurrencyItem(CurrencyItemDefinition definition) : base(definition)
		{
			Definition = definition;
		}
	}
}