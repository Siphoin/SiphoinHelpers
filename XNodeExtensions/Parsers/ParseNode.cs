using SiphoinUnityHelpers.XNodeExtensions;
using UnityEngine;

namespace SiphoinUnityHelpers.Parsers
{
    public abstract class ParseNode<TOutput> : BaseNode
    {
        [Input(ShowBackingValue.Never, ConnectionType.Override), SerializeField] private Object _object;

        [Output(ShowBackingValue.Never), SerializeField] private TOutput _output;

        protected object GetInputObject ()
        {

            return GetInputValue<object>(nameof(_object));
        }
    }
}
