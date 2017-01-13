using UnityEngine;

/// <summary>
/// Given a boolean from <see cref="FieldName"/> in the base class
/// of the bound field, shows or not shows the bound field.
/// </summary>
/// <seealso cref="UnityEngine.PropertyAttribute" />
public class ShowIfAttribute : PropertyAttribute
{
    public delegate bool ConditionFunction();
    /// <summary>
    /// Gets the name of boolean field in the bound property's base class
    /// </summary>
    /// <value>
    /// The name of the field.
    /// </value>
    public string FieldName { get; private set; }

    public ShowIfAttribute(string fieldName)
    {
        FieldName = fieldName;
    }
}