using System;

namespace SiphoinUnityHelpers.XNodeExtensions.Math
{
    public static class ComputeTypeExtensions
    {
        public static string ConvertToLanguageOperator (this ComputeType type)
        {
            switch (type)
            {
                case ComputeType.Equals:
                    return "==";
                case ComputeType.More:
                    return ">";
                case ComputeType.Lesser:
                    return "<";
                case ComputeType.LesserOrEquals:
                    return "<=";
                case ComputeType.MoreOrEquals:
                    return ">=";
                case ComputeType.NotEquals:
                    return "!=";
                default:
                    throw new InvalidCastException($"invalid type of compute type. Type: {type}");
            }
        }
    }
}
