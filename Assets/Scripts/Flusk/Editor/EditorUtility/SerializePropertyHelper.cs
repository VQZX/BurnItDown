using UnityEditor;

namespace Flusk.Editor.EditorUtility
{
    public class SerializePropertyHelper<T>
    {
        public SerializedObject SerializedObject { get; private set; }
        public SerializedProperty SerializedProperty { get; private set; }
        public string PropertyName { get; private set; }

        public SerializePropertyHelper(SerializedObject serializedObject, string name)
        {
            SerializedProperty = serializedObject.FindProperty(name);
        }
    }
}