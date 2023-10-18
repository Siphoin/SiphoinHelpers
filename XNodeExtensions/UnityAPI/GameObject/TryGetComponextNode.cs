using System;
using System.Diagnostics;
using System.Reflection;
using UnityEngine;
using XNode;
using Debug = UnityEngine.Debug;

namespace SiphoinUnityHelpers.XNodeExtensions.UnityAPI.GameObjects
{
    [NodeWidth(260)]
    public class TryGetComponextNode : BaseNode
    {

        [Input(ShowBackingValue.Never, ConnectionType.Override), SerializeField] private GameObject _gameObject;

        [Space(5)]

        [Input(connectionType = ConnectionType.Override), SerializeField] private string _type = "TypeName";

        [Space(5)]

        [Output(connectionType = ConnectionType.Override), SerializeField] private Component _outputComponent;

        public override object GetValue(NodePort port)
        {
            if (!Application.isPlaying)
            {
                return base.GetValue(port);
            }

            if (_outputComponent != null)
            {
                return _outputComponent;
            }

            var gameObject = GetDataFromPort<GameObject>(nameof(_gameObject));

            string typeString = _type;

            if (GetInputPort(nameof(_type)).Connection != null)
            {
                typeString = GetInputValue<string>(nameof(_type));
            }

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            Type type = null;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            foreach (Assembly assembly in assemblies)
            {
                Type[] types = assembly.GetTypes();

                foreach (Type item in types)
                {
                    if (item.Name == typeString)
                    {
                        type = item;

                        break;
                    }
                }

            }

            stopwatch.Stop();

            if (type is null)
            {

                throw new NullReferenceException($"type {typeString} not found");

            }

            if (!gameObject.TryGetComponent(type, out _outputComponent))
            {
                throw new InvalidOperationException($"component with type {type.Name} not found on GameObject {gameObject.name}");
            }

            else
            {
                TimeSpan timeSpan = stopwatch.Elapsed;

                Debug.Log($"elapsed milliseconds finding type {timeSpan.Milliseconds} ms");

                return _outputComponent;
            }



        }
    }

}
