using System.Collections.Generic;

namespace Dev.Scripts.Inventory
{
    public class TetrisInventory
    {
        private Item[,] _items;
        private int _sizeX = 0;
        private int _sizeY = 0;

        public TetrisInventory(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _items = new Item[sizeX, sizeY];
        }

        public bool AddItem(Item item)
        {
            int sizeX = item.GetWidth();
            int sizeY = item.GetHeight();
            if (!FindEmptySlot(sizeX, sizeY, out var px, out var py)) return false;
            return AddItem(item, px, py);
        }
        
        public bool AddItem(Item item, int px, int py)
        {
            int width = item.GetWidth();
            int height = item.GetHeight();
            if (!CanPlace(width, height, px, py)) return false;

            int sizeX = px + width;
            int sizeY = py + height;
            for (int y = py; y < sizeY; y++)
            {
                for (int x = px; x < sizeX; x++)
                {
                    _items[y, x] = item;
                }   
            }
            
            return true;
        }
        
        public bool HasItemAt(int x, int y)
        {
            if (x >= _sizeX) return false;
            if (y >= _sizeY) return false;

            return _items[y, x] != null;
        }

        private bool FindEmptySlot(int width, int height, out int px, out int py)
        {
            int xPointMax = _sizeX - width;
            int yPointMax = _sizeY - height;
            
            for (int y = 0; y < yPointMax; y++)
            {
                for (int x = 0; x < xPointMax; x++)
                {
                    if (CanPlace(width, height, x, y))
                    {
                        px = x;
                        py = y;
                        return true;
                    }
                }   
            }
            
            px = -1;
            py = -1;
            return false;
        }

        private bool CanPlace(int width, int height, int px, int py)
        {
            int xPointMax = px + width;
            int yPointMax = py + height;
            
            if (_sizeX <= xPointMax) return false;
            if (_sizeY <= yPointMax) return false;

            for (int y = py; y < yPointMax; y++)
            {
                for (int x = px; x < xPointMax; x++)
                {
                    if (_items[y, x] != null) return false;
                }   
            }
            
            return true;
        }
    }
}