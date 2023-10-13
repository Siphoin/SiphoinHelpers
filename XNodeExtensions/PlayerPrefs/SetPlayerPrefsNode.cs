using SiphoinUnityHelpers.Attributes;
using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions.PlayerPrefsSystem
{
    public class SetPlayerPrefsNode : BaseNodeInteraction
    {
        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private string _key = Guid.NewGuid().ToString();

        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private string _value = "0";

        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private FieldType _type;

        public object GetValue ()
        {
            switch (_type)
            {
                case FieldType.Int:
                    return Convert.ToInt32(_value);
                    case FieldType.Float:
                    return Convert.ToSingle(_value);
                    case FieldType.String:
                    return _value;
                    case FieldType.Double:
                    return Convert.ToDouble(_value);
                    case FieldType.Long: 
                    return Convert.ToInt64(_value);
                    case FieldType.UInt:
                    return Convert.ToUInt32(_value);
                    case FieldType.ULong: 
                    return Convert.ToUInt64(_value);
                    case FieldType.Bool: 
                    return Convert.ToBoolean(_value);
                    case FieldType.BigInt:
                    return BigInteger.Parse(_value);
                    case FieldType.DateTime: 
                    return DateTime.Parse(_value);
                    default:
                    return new InvalidCastException($"invalid field type {_type} on node {GUID}");

            }
        }

        public override void Execute()
        {
            if (string.IsNullOrEmpty(_key))
            {
                throw new InvalidOperationException($"key invalid on node {GUID}");
            }

            if (string.IsNullOrEmpty(_value))
            {
                throw new InvalidOperationException($"value invalid on node {GUID}");
            }

            if (_type == FieldType.Int || _type == FieldType.UInt)
            {
                PlayerPrefs.SetInt(_key, (int)GetValue());
            }

            else if (_type == FieldType.Long || _type == FieldType.ULong)
            {
                PlayerPrefs.SetInt(_key, Convert.ToInt32(_value));
            }
            else if (_type == FieldType.Float)
            {
                PlayerPrefs.SetFloat(_key, (float)GetValue());
            }

            else if (_type == FieldType.Double)
            {
                PlayerPrefs.SetFloat(_key, (float)GetValue());
            }

            else if (_type == FieldType.String)
            {
                PlayerPrefs.SetString(_key, _value);
            }


            else if (_type == FieldType.BigInt)
            {
                PlayerPrefs.SetString(_key, _value);
            }

            else if (_type == FieldType.DateTime)
            {
                PlayerPrefs.SetString(_key, _value);
            }

            else if (_type == FieldType.Bool)
            {
                bool value = (bool)GetValue();

                PlayerPrefs.SetInt(_key, Convert.ToInt32(value));
            }


            PlayerPrefs.Save();
        }

        private void OnValidate()
        {
            if (_type != FieldType.String)
            {
                _value = _value.Trim();
            }
        }
    }
}
