using Kryz.RPG.Items.UGUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Kryz.RPG.Items.UI
{
	public sealed class PickUpItemSlotController : ItemSlotController
	{
		[SerializeField] InputActionReference pickUpAction;
		[SerializeField] InputActionReference cancelPickUpAction;

		private void Start()
		{
			if (cancelPickUpAction != null)
			{
				cancelPickUpAction.action.performed += ctx => EndDrag();
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (pickUpAction != null) pickUpAction.action.Enable();
			if (cancelPickUpAction != null) cancelPickUpAction.action.Disable();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (pickUpAction != null) pickUpAction.action.Disable();
			if (cancelPickUpAction != null) cancelPickUpAction.action.Disable();
		}

		protected override bool StartDrag(IItemSlotView slotView, int count)
		{
			if (base.StartDrag(slotView, count))
			{
				if (pickUpAction != null) pickUpAction.action.Enable();
				if (cancelPickUpAction != null) cancelPickUpAction.action.Enable();
				return true;
			}
			return false;
		}

		protected override void EndDrag()
		{
			base.EndDrag();
			if (pickUpAction != null) pickUpAction.action.Enable();
			if (cancelPickUpAction != null) cancelPickUpAction.action.Disable();
		}

		public override bool OnPointerClick(IItemSlotView itemSlotView, PointerEventData eventData)
		{
			if (HandleItemPickup(itemSlotView))
			{
				return true;
			}
			else if (splitStackAction != null && splitStackAction.action.WasPerformedThisFrame())
			{
				return StartDrag(itemSlotView, itemSlotView.VisualItemStack.Count / 2);
			}

			return base.OnPointerClick(itemSlotView, eventData);
		}

		private bool HandleItemPickup(IItemSlotView itemSlotView)
		{
			if (dragController == null || pickUpAction == null || !pickUpAction.action.WasPerformedThisFrame())
			{
				return false;
			}

			if (itemSlotView == dragController.SourceSlot)
			{
				EndDrag();
				return true;
			}

			ItemStack dragBefore = dragController.SourceSlot?.RealItemStack ?? default;
			ItemStack dropBefore = itemSlotView.RealItemStack;

			if (TryDrop(itemSlotView))
			{
				ItemStack dragAfter = dragController.SourceSlot?.RealItemStack ?? default;
				ItemStack dropAfter = itemSlotView.RealItemStack;
				bool empty = dragBefore == default || dragAfter == default;
				bool swapped = dragBefore == dropAfter && dropBefore == dragAfter;

				EndDrag();

				if (swapped && !empty)
				{
					StartDrag(itemSlotView, itemSlotView.VisualItemStack.Count);
				}
				return true;
			}

			return StartDrag(itemSlotView, itemSlotView.VisualItemStack.Count);
		}
	}
}