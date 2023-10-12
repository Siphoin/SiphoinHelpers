using System.Data;
using UnityEngine;
using XNode;

namespace SiphoinUnityHelpers.XNodeExtensions.Math
{
    public class ComputeNode : BaseNode
    {
        [SerializeField, Input(ShowBackingValue.Never)] private Object _a;

        [SerializeField, Input(ShowBackingValue.Never)] private Object _b;

        [SerializeField] private ComputeType _type;

        [SerializeField, Output(ShowBackingValue.Never)] private bool _result;

        public override object GetValue(NodePort port)
        {
            var a = GetDataFromPort<object>(nameof(_a));

            var b = GetDataFromPort<object>(nameof(_b));
            string operatorString = _type.ConvertToLanguageOperator();

            string condition = $"{a} {operatorString} {b}";

            Debug.Log(condition);

            var dataTable = new DataTable();

            return (bool)dataTable.Compute(condition, string.Empty);

        }
    }
}
