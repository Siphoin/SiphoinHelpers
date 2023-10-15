using SiphoinUnityHelpers.XNodeExtensions;
using SiphoinUnityHelpers.XNodeExtensions.Attributes;
using System.Text;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

[CustomPropertyDrawer(typeof(NodeControlExecuteFieldAttribute))]
public class NodeControlExecuteFieldPropertyDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        var node = property.serializedObject.targetObject as BaseNodeInteraction;



         if (node.Enter.Connection != null)
         {
            var connectedNode = node.Enter.Connection.node;

            if (connectedNode is NodeControlExecute)
            {
                var executeControlNode = connectedNode as NodeControlExecute;
                GUIStyle style = new GUIStyle(EditorStyles.boldLabel);

                style.fontSize = 10;

                EditorGUILayout.LabelField(label.text, $"Control by {NodeEditorUtilities.NodeDefaultName(connectedNode.GetType())}", style);

                Rect positionGuid = position;

                positionGuid.y += 20;

                style.fontSize = 9;

                node.SetEnable(false);

                EditorGUILayout.LabelField(string.Empty, executeControlNode.GUID, style);

                return;
            }
        }
        EditorGUI.PropertyField(position, property, label);
    }

   
}
