using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conicas : MonoBehaviour
{
    public Text txtConicas;
    private int conicaSeleccionada = 0;
    /* 0.- sin selección
    1.- recta
    2.- circunferencia
    3.- elipse
    4.- parabola
    5.- hiperbola  */ 

    public Slider sld_a;
    private float a = 5;

    public Slider sld_b;
    private float b = 3;

    public Slider sld_h;
    private float h = 1;

    public Slider sld_k;
    private float k = 1;

    public Slider sld_t;
    private float t = 45;

    public int resolucion = 1000;
    public Text lbl_a, lbl_b, lbl_h, lbl_k, lbl_t;
    public Material matRecta, matCircunferencia, matElipse, matParabola, matHiperbola;

    private Vector3[] posPuntos;

    public void DibujarConicas(){
        if (conicaSeleccionada != 0){

        LineRenderer lr = GetComponent<LineRenderer>();
        lr.SetVertexCount(resolucion + 1);

        a = sld_a.value;
        b = sld_b.value;
        h = sld_h.value;
        k = sld_k.value;
        t = sld_t.value;

            switch(conicaSeleccionada){
            case 1: //recta
                txtConicas.text = "Recta";
                lr.material = matRecta;
                ResetSlidersEtiquetas();
                lbl_a.text = "ax";
                lbl_b.text = "ay";
                lbl_h.text = "bx";
                lbl_k.text = "by";
                lbl_t.gameObject.SetActive(false);
                sld_t.gameObject.SetActive(false);
                posPuntos = CrearRecta(a, b, h, k, resolucion);
                break;
            case 2: // circunferencia
                txtConicas.text = "Circunferencia";
                lr.material = matCircunferencia;
                ResetSlidersEtiquetas();
                break;
            case 3: //elipse
                txtConicas.text = "Elipse";
                lr.material = matElipse;
                ResetSlidersEtiquetas();
                break;
            case 4: // parabola
                txtConicas.text = "Parábola";
                lr.material = matParabola;
                ResetSlidersEtiquetas();
                break;
            case 5: //hiperbola
                txtConicas.text = "Hipérbola";
                lr.material = matHiperbola;
                ResetSlidersEtiquetas();
                break;
        }
        for(int i= 0; i <= resolucion; i++){
            lr.SetPosition(i, posPuntos[i]);
        }
        }
    }

    public void ResetSlidersEtiquetas(){
        sld_a.gameObject.SetActive(true);
        sld_b.gameObject.SetActive(true);
        sld_h.gameObject.SetActive(true);
        sld_k.gameObject.SetActive(true);
        sld_t.gameObject.SetActive(true);

        lbl_a.gameObject.SetActive(true);
        lbl_b.gameObject.SetActive(true);
        lbl_h.gameObject.SetActive(true);
        lbl_k.gameObject.SetActive(true);
        lbl_t.gameObject.SetActive(true);

        lbl_a.text = "a";
        lbl_b.text = "b";
        lbl_h.text = "h";
        lbl_k.text = "k";
        lbl_t.text = "t";
    }

    public void BtnRecta(){
        conicaSeleccionada = 1;
        DibujarConicas();
    }

    private Vector3[] CrearRecta(float ax, float ay, float bx, float by, int resolucion){
        posPuntos = new Vector3[resolucion + 1];
        float dx = bx - ax;
        float dy = by - ay;
        for (int i = 0; i <= resolucion; i++){
            posPuntos[i] = new Vector3(ax + dx * i / resolucion, ay + dy * i / resolucion);
        }
        return posPuntos;
    }

    public void BtnCircunferencia(){
        conicaSeleccionada = 2;
        DibujarConicas();
    }

    public void BtnElipse(){
        conicaSeleccionada = 3;
        DibujarConicas();
    }

    public void BtnParabola(){
        conicaSeleccionada = 4;
        DibujarConicas();
    }

    public void BtnHiperbola(){
        conicaSeleccionada = 5;
        DibujarConicas();
    }
}