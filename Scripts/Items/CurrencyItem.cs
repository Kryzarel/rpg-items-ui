namespace Kryz.RPG.Items.UI
{
	public class CurrencyItem : BaseItem
	{
		public new readonly CurrencyItemDefinition Definition;
		public override int MaxStacks => Definition.MaxStacks;

		public CurrencyItem(CurrencyItemDefinition definition) : base(definition)
		{
			Definition = definition;
		}

		public override IItemSaveData ToSaveData() => new ItemSaveDataSingleton(Definition.Id);
	}
}