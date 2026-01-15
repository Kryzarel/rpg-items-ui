using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	public abstract class BaseItem : IItem
	{
		public BaseItemDefinition Definition { get; private set; }
		public Sprite Icon { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }

		public virtual int MaxStacks => 1;

		IItemDefinition IItem.Definition => Definition;

		public BaseItem(BaseItemDefinition definition)
		{
			Definition = definition;
			Icon = definition.Icon!;
			Name = definition.Name;
			Description = definition.Description;
		}

		public virtual int CompareTo(IItem other) => Name.CompareTo(other.Name);
	}
}