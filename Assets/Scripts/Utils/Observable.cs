using System;

namespace Utils
{
    [Serializable]
    public class Observable<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (!Equals(_value, value))
                {
                    _value = value;
                    OnValueChanged?.Invoke(_value);
                }
            }
        }

        public event Action<T> OnValueChanged;


        public Observable(T initialValue)
        {
            _value = initialValue;
        }
    }
}
