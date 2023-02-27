using UnityEngine;

namespace Dev.Scripts.Inventory
{
    public class InventoryDebugger : MonoBehaviour
    {
        [SerializeField] private Vector2Int inventorySize;
        private TetrisInventory _inventory;

        private void Awake()
        {
            _inventory = new TetrisInventory(inventorySize.x, inventorySize.y);

            _inventory.AddItem(new Item(3, 2));
        }

        private void OnDrawGizmos()
        {
            if (_inventory == null) return;


            for (int y = 0; y < inventorySize.y; y++)
            {
                for (int x = 0; x < inventorySize.x; x++)
                {
                    Gizmos.color = Color.white;
                    Gizmos.DrawLine(new Vector3(x - 1, y - 1), new Vector3(x, y - 1));
                    Gizmos.DrawLine(new Vector3(x, y - 1), new Vector3(x, y));
                    Gizmos.DrawLine(new Vector3(x, y), new Vector3(x - 1, y));
                    Gizmos.DrawLine(new Vector3(x - 1, y), new Vector3(x - 1, y - 1));

                    if (_inventory.HasItemAt(x, y))
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(new Vector3(x - 1, y - 1), new Vector3(x, y));
                    }
                }
            }
        }
    }
}