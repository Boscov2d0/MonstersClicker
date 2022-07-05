using System;

namespace MonstersGame
{
    public class ListUpdateObjects : TestInteractiveObjectsList<IUpdate>
    {
        public IUpdate[] updateObjects;

        private int _length;
        public new int Length { get => _length; set => _length = value; }

        public ListUpdateObjects() 
        {
            updateObjects = new IUpdate[0];
            _length = updateObjects.Length;
        }

        public IUpdate this[int current]
        {
            get => updateObjects[current];
            private set => updateObjects[current] = value;
        }
        public void AddUpdateObjects(IUpdate update)
        {
            if (updateObjects == null)
            {
                updateObjects = new[] { update };
                return;
            }
            Array.Resize(ref updateObjects, ++_length);
            updateObjects[_length - 1] = update;
        }
    }
}
