using System;
using System.ComponentModel;
using UnityEngine;

public class WeaponModel
{
    public WeaponName WeaponName;
    public Desc Desc;
    public WeaponSprite WeaponSprite;
    public Damage Damage;
}

public class WeaponName : INotifyPropertyChanged
{
    public event Callback WeaponNameChangedCallback;
    public event PropertyChangedEventHandler PropertyChanged;

    public string Name;

    private string m_value="";

    public string Value
    {
        get
        {
            return m_value;
        }
        set
        {
            if (!AreEqual(m_value, value))
            {
                m_value = value;
                OnPropertyChanged(Name);
            }
        }
    }

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(name)
               );
    }

    private bool AreEqual(string firstValue, string secondValue)
    {
        return firstValue.Equals(secondValue);
    }
}

public class Desc : INotifyPropertyChanged
{
    public event Callback DescChangedCallback;
    public event PropertyChangedEventHandler PropertyChanged;

    public string Name;

    private string m_value = "";

    public string Value
    {
        get
        {
            return m_value;
        }
        set
        {
            if (!AreEqual(m_value, value))
            {
                m_value = value;
                OnPropertyChanged(Name);
            }
        }
    }

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(name)
               );
    }

    private bool AreEqual(string firstValue, string secondValue)
    {
        return firstValue.Equals(secondValue);
    }
}

public class WeaponSprite : INotifyPropertyChanged
{
    public event Callback SpriteChangedCallback;
    public event PropertyChangedEventHandler PropertyChanged;

    public string Name;

    private Sprite m_value = Resources.Load<Sprite>("Sprites/DefaultSprite");

    public Sprite Value
    {
        get
        {
            return m_value;
        }
        set
        {
            if (!AreEqual(m_value, value))
            {
                m_value = value;
                OnPropertyChanged(Name);
            }
        }
    }

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(name)
               );
    }

    private bool AreEqual(Sprite firstValue, Sprite secondValue)
    {
        return firstValue.Equals(secondValue);
    }
}

public class Damage : INotifyPropertyChanged
{
    public event Callback DamageChangedCallback;
    public event PropertyChangedEventHandler PropertyChanged;

    public string Name;

    private float m_value;

    public float Value
    {
        get
        {
            return m_value;
        }
        set
        {
            if (!AreEqual(m_value, value))
            {
                m_value = value;
                OnPropertyChanged(Name);
            }
        }
    }

    private void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(name)
               );
    }

    private bool AreEqual(float firstValue, float secondValue)
    {
        return Math.Abs(firstValue - secondValue) < Mathf.Epsilon;
    }
}