using System;

public class ReactValue<T>
{
    public Action onValueChanged;
    public T val
    {
        get { return _val; }
        set
        {
            if (_val.Equals(value) == false)
            {
                _val = value;
                onValueChanged?.Invoke();
            }
        }
    }

    private T _val;
}
