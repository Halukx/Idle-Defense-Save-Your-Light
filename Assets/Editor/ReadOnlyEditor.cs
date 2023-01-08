using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ReadOnlyVariable))] // Özel deðer çizdiðini ve bu özel deðerin türünün SadeceOkunabilirDeger olduðunu belirtiyoruz.
public class SadeceOkunabilirEditor : PropertyDrawer // Sýnýfýmýzý PropertyDrawer sýnýfýndan türetiyoruz
{
    public override void OnGUI(Rect konum, SerializedProperty ozellik, GUIContent cizgi) // GUI ye aþýrý yükleme yapýyor ve deðerleri alýyoruz
    {
        GUI.enabled = false; // GUI yi kapatýyoruz
        EditorGUI.PropertyField(konum, ozellik, cizgi, true); // Ýstediðimiz özellikleri veriyoruz
        GUI.enabled = true; // GUI yi aktif hale getiriyoruz
    }
}