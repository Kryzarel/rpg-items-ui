using System;
using Kryz.RPG.Items.Views;
using UnityEngine;

namespace Kryz.RPG.Items.UI
{
	public class Initializer : MonoBehaviour
	{
		private readonly ItemFactory itemFactory = new(new ItemDefinitionDatabaseResources());
		private readonly Inventory inventory = new(12);
		private readonly Inventory cursorInventory = new(1);

		[SerializeField]
		private ItemContainerView? inventoryView;
		[SerializeField]
		private ItemContainerView? cursorInventoryView;
		[SerializeField]
		private BaseItemDefinition[] itemDefinitions = Array.Empty<BaseItemDefinition>();
		[SerializeField]
		private int[] itemCounts = Array.Empty<int>();
		[SerializeField]
		private ItemContainerSaveData inventorySaveData = new();
		[SerializeField]
		private string saveDataJson = string.Empty;

		private void OnValidate()
		{
			Array.Resize(ref itemCounts, itemDefinitions.Length);
			for (int i = 0; i < itemCounts.Length; i++)
			{
				ref int count = ref itemCounts[i];
				if (count <= 0) count = 1;
			}
		}

		private void Awake()
		{
			itemFactory.Register(new CurrencyItemCreator());
			itemFactory.Register(new EquipableItemCreator());
		}

		private void Start()
		{
			inventoryView!.SetItemContainer(inventory);
			cursorInventoryView!.SetItemContainer(cursorInventory);

			if (string.IsNullOrEmpty(saveDataJson))
			{
				using ItemTransaction transaction = new(inventory);
				for (int i = 0; i < itemDefinitions.Length; i++)
				{
					inventory.SetSlot(transaction, i, new ItemStack(itemFactory.Create(itemDefinitions[i]), itemCounts[i]));
				}
				transaction.Commit();
			}
			else
			{
				JsonUtility.FromJsonOverwrite(saveDataJson, inventorySaveData);
				inventorySaveData.ToItemContainer(itemFactory, inventory);
			}
		}

		private void OnDisable()
		{
			inventorySaveData.FromItems(itemFactory, inventory.Slots);
			Debug.Log(JsonUtility.ToJson(inventorySaveData));
		}
	}
}