using System;
using system.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conicas: MonoBehaviour
{
    public Text txtConicas;
    private int conicaSeleccionada = 0; // 0- Sin seleccion, 1- Recta, 2- Circuferencia, 3- Elipse, 4- Elipse, 5- Hiperbola
    
    public Slider sl_a;
    private float a = 5;

    public Slider sl_b;
    private float b = 3;

    public Slider sl_h;
    private float h = 1;

    public Slider sl_k;
    private float k = 1;
    public Slider sl_t;
    private float t = 45;

    private int resolucion = 1000;

    public Text lbl_a, lbl_b, lbl_h, lbl_k, lbl_t;
    public Material matRecta, matCircuferencia, matElipse, matParabola, matHiperbola;
    private Vector3[] posPuntos;


    public void Awake(){
            sl_a.gameObject.SetActive(false);
            sl_b.gameObject.SetActive(false);
            sl_h.gameObject.SetActive(false);
            sl_k.gameObject.SetActive(false);
            sl_t.gameObject.SetActive(false);
            lbl_a.gameObject.SetActive(false);
            lbl_b.gameObject.SetActive(false);
            lbl_h.gameObject.SetActive(false);
            lbl_k.gameObject.SetActive(false);
            lbl_t.gameObject.SetActive(false);
    }

    public void DibujaConicas(){

        if (conicaSeleccionada !=0 ){

            LineRenderer lr = GetComponent<LineRenderer>();
            lr.SetVertexCount (resolucion + 1);

            a = sl_a.value;
            b = sl_b.value;
            h = sl_h.value;
            k = sl_k.value;
            t = sl_t.value;


          switch(conicaSeleccionada){
            case 1: //recta
                txtConicas.text = "Recta";
                lr.material = matRecta;
                ResetSlidersEtiquetas();
                lbl_a.text = "ax";
                lbl_b.text = "ay";
                lbl_h.text = "bx";
                lbl_k.text = "by";
                lbl.t.gameObject.SetActive(false);
                sl_t.gameObject.SetActive(false);
                posPuntos = CreaRecta (a, b , h, k, resolucion);
                break;

                case 2: //circuferencia
                txtConicas.text = "Circuferencia";
                lr.material = matCircuferencia;
                ResetSlidersEtiquetas();
                lbl_a.gameObject.SetActive(false);
                sl_a.gameObject.SetActive(false);
                lbl_b.text = "r";
                lbl.t.gameObject.SetActive(false);
                sl_t.gameObject.SetActive(false);
                posPuntos = CreaCircuferencia(b, h, k, resolucion);
                break;

                case 3: //Elipse
                txtConicas.text = "Elipse";
                lr.material = matElipse;
                ResetSlidersEtiquetas();
                posPuntos = CreaElipse(a, b, h, k, t, resolucion);
                break;

                case 4: //Parabola
                txtConicas.text = "Parábola";
                lr.material = matParabola;
                ResetSlidersEtiquetas();
                posPuntos = CreaParabola(b, h, k, t, resolucion);
                lbl_a.gameObject.SetActive(false);
                sl_a.gameObject.SetActive(false);
                lbl_b.text = "p";
                break;

                case 5: //Hipérbola
                txtConicas.text = "Hipérbola";
                lr.material = matHiperbola;
                ResetSlidersEtiquetas();
                posPuntos = CreaHiperbola(a, b, h, k, t, resolucion);
                break;
            }

            for (int i = 0; i <= resolucion; i ++){
                lr.setPosition(i, posPuntos[i]);

            }

        } 

    }

    public void ResetSlidersEtiquetas(){
        sl_a.gameObject.SetActive(true);
        sl_b.gameObject.SetActive(true);
        sl_h.gameObject.SetActive(true);
        sl_k.gameObject.SetActive(true);
        sl_t.gameObject.SetActive(true);

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
        DibujaConicas();
    }

    private Vector3[] CreaRecta(float ax, float ay, float bx, float by, int resolucion){
        posPuntos = new Vector3[resolucion+1];
        float dx = bx - ax;
        float dy = by - ay;

        for (int i =0; i<= resolucion; i++){
            posPuntos[i] = new Vector3(ax + dx * i / resolucion, ay + dy * i / resolucion);
        }
        return posPuntos;
    } 

    public void BtnCircunferencia(){
        conicaSeleccionada = 2;
        DibujaConicas();
    }

    private Vector3[] CreaCircunferencia(float r, float h, float k, int resolucion){
        posPuntos = new Vector3[resolucion+1];
        Vector3 centro = new Vector3(h, k, 0);
        for (int i = 0; i<= resolucion; i++){
            float angulo = ((float)i / (float)resolucion) * 2 * Mathf.PI;
            posPuntos[i] = new Vector3(r * Mathf.Cos(angulo), r * MathF.Sin(angulo), 0);
            posPuntos[i] = posPuntos[i] + centro;
        }
        return posPuntos;
    }

    public void BtnElipse(){
        conicaSeleccionada = 3;
        DibujaConicas();
    }

    private Vector3[] CreaElipse(float a, float b, float h, float k, float theta, int resolucion){
        posPuntos = new Vector3[resolucion+1];
        Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);

        Vector3 centro = new Vector3(h, k, 0);

        for (int i = 0; i<= resolucion; i++){
            float angulo = ((float)i / (float)resolucion) * 2 * Mathf.PI;
            posPuntos[i] = new Vector3(a * Mathf.Cos(angulo), b * MathF.Sin(angulo), 0);
            posPuntos[i] = q * posPuntos[i] + centro;
        }
        return posPuntos;
    }

    public void BtnParabola(){
        conicaSeleccionada = 4;
        DibujaConicas();
    }

    private Vector3[] CreaParabola(float p, float h, float k, float theta, int resolucion){
        posPuntos = new Vector3[resolucion+1];
        Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);

        Vector3 vertice = new Vector3(h, k, 0);

        for (int i = 0; i<= resolucion; i++){
            float angulo = ((float)i / (float)resolucion) * 2 * Mathf.PI;
            posPuntos[i] = new Vector3(i-(resolucion/2), (1/(4*p)) * Mathf.Pow(i-(resolucion/2), 2), 0);
            posPuntos[i] = q * posPuntos[i] + vertice;
        }
        return posPuntos;
    }

    public void BtnHiperbola(){
        conicaSeleccionada = 5;
        DibujaConicas();
    }

    private Vector3[] CreaHiperbola(float a, float b, float h, float k, float theta, int resolucion){
    posPuntos = new Vector3[resolucion + 1];
    Quaternion q = Quaternion.AngleAxis(theta, Vector3.forward);

    Vector3 centro = new Vector3(h, k, 0);

    for (int i = 0; i <= resolucion / 2; i++){
        float t = ((float)i / (resolucion / 2)) * 2 - 1; // Valores en el rango [-1, 1]
        float x = a * (1 / Mathf.Cos(t));
        float y = b * Mathf.Tan(t);

        posPuntos[i] = q * new Vector3(x, y, 0) + centro;
        posPuntos[resolucion - i] = q * new Vector3(-x, -y, 0) + centro; // Segunda rama
    }

    return posPuntos;
}

}