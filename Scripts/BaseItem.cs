using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	public abstract class BaseItem : IItem
	{
		public IItemDefinition Definition { get; private set; }
		public Sprite Icon { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public int MaxStacks { get; private set; }

		public BaseItem(BaseItemDefinition definition)
		{
			Definition = definition;
			Icon = definition.Icon!;
			Name = definition.Name;
			Description = definition.Description;
			MaxStacks = definition.MaxStacks;
		}

		public virtual int CompareTo(IItem other) => Name.CompareTo(other.Name);
	}
}