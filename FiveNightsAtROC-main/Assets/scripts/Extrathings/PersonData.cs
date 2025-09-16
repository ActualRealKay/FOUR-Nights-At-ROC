using UnityEngine;

[CreateAssetMenu(fileName = "NewPerson", menuName = "Person")]
public class PersonData : ScriptableObject
{
    public Sprite sprite;
    public string personName;
    [TextArea] public string description;
}
