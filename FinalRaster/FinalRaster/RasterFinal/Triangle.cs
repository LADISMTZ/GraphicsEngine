using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFinal
{
    public class Triangle: ICloneable
    {
        public List<Vertex> puntos3Ds;
        public List<Vertex> faceOfFigure;
        public List<Vertex> translatedPoints;
        List<Vertex> escaledPoints;
        Color color;


        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            puntos3Ds = new List<Vertex>();
            faceOfFigure = new List<Vertex>();
            translatedPoints = new List<Vertex>();
            escaledPoints = new List<Vertex>();
            color = new Color();
            agregarPunto(v1);
            agregarPunto(v2);
            agregarPunto(v3);
        }
        public void agregarPunto(Vertex punto)
        {
            puntos3Ds.Add(punto);
            faceOfFigure.Add(punto);
            translatedPoints.Add(punto);
            escaledPoints.Add(punto);
        }

        public void renderPoint(Render render, Vertex punto, float z, Color c)
        {
            //g.FillEllipse(Brushes.Yellow, punto.X, punto.Y, 1,1);
            render.DrawPoint(punto, z, c);
        }
        private void activateLine(Render render, Vertex punto, Vertex punto2)
        {

            //g.DrawLine(Pens.Turquoise, punto, punto2);
            render.DrawLine(punto, punto2, Color.Green);
        }
        public void renderTriangle(Render render, Light light, Canvas canvas)
        {


            for (int i = 0; i < puntos3Ds.Count; i++)
            {
                renderPoint(render, translatedPoints[i], translatedPoints[i][2], Color.Green);
                render.DrawTriangleWithLighting(translatedPoints[0], translatedPoints[1], translatedPoints[2], light);
            }

        }


        /*
        public void activateLines(Canvas canvas)
        {    

            for (int i = 0; i < puntos3Ds.Count - 1; i++)
            {
                activateLine(canvas, new PointF(translatedPoints[i][0], translatedPoints[i][1]), new PointF(translatedPoints[i + 1][0], translatedPoints[i + 1][1]));
            }
            activateLine(canvas, new PointF(translatedPoints[puntos3Ds.Count - 1][0], translatedPoints[puntos3Ds.Count - 1][1]), new PointF(translatedPoints[0][0], translatedPoints[0][1]));

        }
        */

        public void activateLines(Render render)
        {

            for (int i = 0; i < puntos3Ds.Count - 1; i++)
            {
                activateLine(render, translatedPoints[i], translatedPoints[i + 1]);
            }
            activateLine(render, translatedPoints[puntos3Ds.Count - 1], translatedPoints[0]);

        }

        public Vertex eliminatePointZ(Vertex v)
        {
            Mtx Mat;
            float[,] axis = new float[,]
                {
                { 1,0,0},
                { 0,1,0},
                { 0,0,0}
                };
            Mat = new Mtx(axis);
            return Mat.Mul(v);
        }

        public Vertex getPerspectivePoint(Vertex v, float distance)
        {
            Mtx Mat;
            float z = -1 / (distance - v[2]);
            float[,] axis = new float[,]
                {
                { z,0,0},
                { 0,z,0},
                { 0,0,1}
                };
            Mat = new Mtx(axis);
            return Mat.Mul(v);
        }

        public void getOnlyFace()
        {
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                faceOfFigure[i] = (eliminatePointZ(puntos3Ds[i]));
            }
        }

        public void getPerspective(float distance)
        {
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                faceOfFigure[i] = (getPerspectivePoint(puntos3Ds[i], distance));
            }
        }

        public void scale(int sm)
        {

            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                escaledPoints[i] = new Vertex(new float[] { (faceOfFigure[i][0]) * sm, faceOfFigure[i][1] * sm, faceOfFigure[i][2] * sm });
                translatedPoints[i] = escaledPoints[i];
            }
        }

        public Vertex traslacionPunto(Vertex punto, Size size, Vertex b)
        {
            float[] v = { b[0] + punto[0] + size.Width / 2, b[1] + punto[1] + size.Height / 2, b[2] + punto[2] };
            return new Vertex(v);
        }

        public void traslacionTriangulo(Size size, Vertex b)
        {
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                translatedPoints[i] = traslacionPunto(escaledPoints[i], size, b);
                //escaledPoints[i] = translatedPoints[i];
            }
        }

        private Vertex Translate(Vertex a, Vertex b)
        {
            float[] array1 = new float[] { a[0], a[1], a[2] + b[2] };
           

            return (new Vertex(array1));
        }

        public void traslacionZ(Vertex b)
        {
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                translatedPoints[i] = Translate(translatedPoints[i], b);
                //escaledPoints[i] = faceOfFigure[i];
            }

        }


        public void rotateX(float rx)
        {
            Rotacion rot = new Rotacion();
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                faceOfFigure[i] = rot.RotarX(rx, faceOfFigure[i]);
            }
        }

        public void rotateY(float ry)
        {
            Rotacion rot = new Rotacion();
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                faceOfFigure[i] = rot.RotarY(ry, faceOfFigure[i]);
            }
        }

        public void rotateZ(float rz)
        {
            Rotacion rot = new Rotacion();
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                faceOfFigure[i] = rot.RotarZ(rz, faceOfFigure[i]);
            }
        }

        public void interpolateTriangle( float alpha, Triangle triangleA, Triangle triangleB)
        {
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                translatedPoints[i] = interpolatePoint(alpha, triangleA.translatedPoints[i], triangleB.translatedPoints[i]);
            }
        }

        public Vertex interpolatePoint(float alpha, Vertex A, Vertex B)
        {
            float x = (A.X * (1 - alpha)) + B.X * alpha;
            float y = (A.Y * (1 - alpha)) + B.Y * alpha;
            float z = (A.Z * (1 - alpha)) + B.Z * alpha;

            return new Vertex([x, y, z]);
        }

        public object Clone()
        {

            // Clonar cada uno de los vértices del triángulo
            Vertex v1Clone = (Vertex)puntos3Ds[0].Clone();
            Vertex v2Clone = (Vertex)puntos3Ds[1].Clone();
            Vertex v3Clone = (Vertex)puntos3Ds[2].Clone();

            // Clonar las listas de vértices
            List<Vertex> puntos3DsClone = new List<Vertex>();
            foreach (Vertex vertex in puntos3Ds)
            {
                puntos3DsClone.Add((Vertex)vertex.Clone());
            }

            List<Vertex> faceOfFigureClone = new List<Vertex>();
            foreach (Vertex vertex in faceOfFigure)
            {
                faceOfFigureClone.Add((Vertex)vertex.Clone());
            }

            List<Vertex> translatedPointsClone = new List<Vertex>();
            foreach (Vertex vertex in translatedPoints)
            {
                translatedPointsClone.Add((Vertex)vertex.Clone());
            }

            List<Vertex> escaledPointsClone = new List<Vertex>();
            foreach (Vertex vertex in escaledPoints)
            {
                escaledPointsClone.Add((Vertex)vertex.Clone());
            }

            // Crear un nuevo triángulo con los vértices y listas clonadas
            Triangle clonedTriangle = new Triangle(v1Clone, v2Clone, v3Clone)
            {
                puntos3Ds = puntos3DsClone,
                faceOfFigure = faceOfFigureClone,
                translatedPoints = translatedPointsClone,
                escaledPoints = escaledPointsClone
            };

            return clonedTriangle;
        }

    }
}
