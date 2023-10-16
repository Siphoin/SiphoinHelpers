using SiphoinUnityHelpers.Parsers;
using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Parsers
{
    public class ToStringNode : ParseNode<string>
    {
        public override object GetValue(NodePort port)
        {
            if (!Application.isPlaying)
            {
                return base.GetValue(port);
            }
          return GetInputObject().ToString();
        }
    }
}
