using UnityEngine;
using UnityEditor;

public class PersonDataCreator : MonoBehaviour
{
    [MenuItem("Tools/Create 10 Random Persons")]
    public static void CreateRandomPersons()
    {
        string path = "Assets/PersonData";

        if (!AssetDatabase.IsValidFolder(path))
            AssetDatabase.CreateFolder("Assets", "PersonData");

        string[] names = new string[]
        {
            "Alex Johnson", "Mia Thompson", "Liam Carter", "Zoe Williams",
            "Ethan Brown", "Ava Smith", "Noah Davis", "Lily Wilson",
            "Lucas Martin", "Emma Lewis"
        };

        string[] descriptions = new string[]
        {
            "Loves hiking and coffee.",
            "Enjoys painting and cats.",
            "Gamer and music enthusiast.",
            "Bookworm and baker.",
            "Soccer player, loves travel.",
            "Tech geek, loves robotics.",
            "Plays guitar, likes camping.",
            "Photographer and runner.",
            "Chess master, coffee lover.",
            "Yoga fan, nature lover."
        };

        for (int i = 0; i < 10; i++)
        {
            PersonData person = ScriptableObject.CreateInstance<PersonData>();
            person.personName = names[i];
            person.description = descriptions[i];
            person.sprite = null; // assign later, or add a placeholder sprite

            string assetPath = path + "/Person" + (i + 1) + ".asset";
            AssetDatabase.CreateAsset(person, assetPath);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("10 PersonData assets created in Assets/PersonData/");
    }
}
