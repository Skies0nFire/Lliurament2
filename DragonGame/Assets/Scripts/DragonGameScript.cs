using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DragonGameScript : MonoBehaviour
{
    UIDocument DragonGameUXML;
    
    private VisualElement Arriba;
    private VisualElement Abajo;
    private VisualElement Abajo_Dragones;
    private Button botonDragones;
    private Button botonVolver;
    private Button botonSalir;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        Arriba = root.Q<VisualElement>("Arriba");
        Abajo = root.Q<VisualElement>("Abajo");
        Abajo_Dragones = root.Q<VisualElement>("Abajo_Dragones");

        botonDragones = root.Q<Button>("Dragones");
        botonVolver = root.Q<Button>("Volver");
        botonSalir = root.Q<Button>("Salir");

        Arriba.style.display = DisplayStyle.Flex;
        Abajo.style.display = DisplayStyle.Flex;
        Abajo_Dragones.style.display = DisplayStyle.None;

        if (botonDragones != null)
        {
            botonDragones.clicked += MostrarPantallaDragones;
        }
        if (botonVolver != null)
        {
            botonVolver.clicked += VolverAlMenuPrincipal;
        }
        if (botonSalir != null)
        {
            botonSalir.clicked += SalirDelJuego;
        }
    }

    void OnDisable()
    {
        if (botonDragones != null)
        {
            botonDragones.clicked -= MostrarPantallaDragones;
        }
        if (botonVolver != null)
        {
            botonVolver.clicked -= VolverAlMenuPrincipal;
        }
        if (botonSalir != null)
        {
            botonSalir.clicked -= SalirDelJuego;
        }

    }

    private void MostrarPantallaDragones()
    {
        Arriba.style.display = DisplayStyle.None;
        Abajo.style.display = DisplayStyle.None;

        Abajo_Dragones.style.display = DisplayStyle.Flex;
    }

    private void VolverAlMenuPrincipal()
    {
        Arriba.style.display = DisplayStyle.Flex;
        Abajo.style.display = DisplayStyle.Flex;
        Abajo_Dragones.style.display = DisplayStyle.None;
    }

    private void SalirDelJuego()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


}