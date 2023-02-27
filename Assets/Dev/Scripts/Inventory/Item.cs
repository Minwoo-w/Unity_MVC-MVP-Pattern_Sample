namespace Dev.Scripts.Inventory
{
    public class Item
    {
        private int _width;
        private int _height;

        public Item(int width, int height)
        {
            _width = width;
            _height = height;
        }
        
        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }
    }   
}