using SiphoinUnityHelpers.Attributes;
using System;
using System.Numerics;
using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.PlayerPrefsSystem
{
    public class GetPlayerPrefsNode : BaseNode
    {
        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private string _key;

        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private FieldType _type;

        [Space(10)]
        [Output(ShowBackingValue.Never), SerializeField] private UnityEngine.Object _output;

        public override object GetValue(NodePort port)
        {
            if (!Application.isPlaying)
            {
                return base.GetValue(port);
            }

            if (!PlayerPrefs.HasKey(_key))
            {
                Debug.LogError($"key {_key} not found on PlayerPrefs");

                return base.GetValue(port);
            }
            switch (_type)
            {
                case FieldType.Int:
                    return PlayerPrefs.GetInt(_key);
                case FieldType.UInt:
                    return PlayerPrefs.GetInt(_key);
                case FieldType.String:
                    return PlayerPrefs.GetString(_key);
                case FieldType.Float:
                    return PlayerPrefs.GetFloat(_key);
                case FieldType.Double:
                    return PlayerPrefs.GetFloat(_key);
                case FieldType.Long:
                    return Convert.ToInt64(PlayerPrefs.GetString(_key));
                case FieldType.ULong:
                    return Convert.ToInt64(PlayerPrefs.GetString(_key));
                case FieldType.Bool:
                    return Convert.ToBoolean(PlayerPrefs.GetInt(_key));
                case FieldType.BigInt:
                    return BigInteger.Parse(PlayerPrefs.GetString(_key));
                case FieldType.DateTime:
                    return DateTime.Parse(PlayerPrefs.GetString(_key));
                default:
                    break;
            }

            return base.GetValue(port);
        }


    }
}
