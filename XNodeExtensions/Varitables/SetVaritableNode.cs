using UnityEngine;

namespace SiphoinUnityHelpers.XNodeExtensions.Varitables.Set
{
    public abstract class SetVaritableNode<T> : BaseNodeInteraction
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override), SerializeField] private T _varitable;

        [Input, SerializeField] private T _value;

        public override void Execute()
        {
            var outputVaritable = GetInputPort(nameof(_varitable));

            var inputValue = GetInputPort(nameof(_value));

            var connectedVaritable = outputVaritable.Connection.node;

            var connectedValue = inputValue.Connection;

            var value = _value;

            if (connectedValue != null)
            {
                var valueFromInput = connectedValue.GetOutputValue();

                value = (T)valueFromInput;
            }

            if (connectedVaritable is VaritableNode<T>)
            {
                var varitableNode = connectedVaritable as VaritableNode<T>;

                varitableNode.SetValue(value);
            }
        }



    }
}
