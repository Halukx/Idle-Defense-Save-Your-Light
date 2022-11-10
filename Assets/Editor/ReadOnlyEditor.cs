using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ReadOnlyVariable))] // �zel de�er �izdi�ini ve bu �zel de�erin t�r�n�n SadeceOkunabilirDeger oldu�unu belirtiyoruz.
public class SadeceOkunabilirEditor : PropertyDrawer // S�n�f�m�z� PropertyDrawer s�n�f�ndan t�retiyoruz
{
    public override void OnGUI(Rect konum, SerializedProperty ozellik, GUIContent cizgi) // GUI ye a��r� y�kleme yap�yor ve de�erleri al�yoruz
    {
        GUI.enabled = false; // GUI yi kapat�yoruz
        EditorGUI.PropertyField(konum, ozellik, cizgi, true); // �stedi�imiz �zellikleri veriyoruz
        GUI.enabled = true; // GUI yi aktif hale getiriyoruz
    }
}