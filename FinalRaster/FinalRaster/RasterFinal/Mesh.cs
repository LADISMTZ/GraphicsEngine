using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFinal
{
    public class Mesh: ICloneable
    {

        public List<Triangle> Triangles;

        public Mesh(List<Triangle> triangulosInput)
        {
            Triangles = triangulosInput;

        }
        public Mesh()
        {



        }//end Mesh

        public void AddQuads(Vertex v1, Vertex v2, Vertex v3, Vertex v4)
        {
            Triangles.Add(new Triangle(v1, v2, v3));
            Triangles.Add(new Triangle(v1, v3, v4));
        }


        public void AddTriangle(Vertex v1, Vertex v2, Vertex v3)
        {
            Triangles.Add(new Triangle(v1, v2, v3));
        }



        public void renderFigure(Render render, Light light, Canvas canvas)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].renderTriangle(render, light, canvas);
            }
        }

        public void activateLines(Render render)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].activateLines(render);

            }
        }

        public void putOrthogonal()
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].getOnlyFace();
            }
        }

        public void putPerspective(float distance)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].getPerspective(distance);
            }
        }

        public void traslacionFig(Size size,Vertex b)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].traslacionTriangulo(size,b);
            }
        }



        public void scaleFig(int sm)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].scale(sm);
            }
        }

        public void translateZ(float tz)
        {

            float[] values = new float[] {0f,0f,tz};
            Vertex vertex1 = new Vertex(values);


            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].traslacionZ(vertex1);
            }
        }
        public void rotateX(float rx)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].rotateX(rx);
            }
        }

        public void rotateY(float ry)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].rotateY(ry);
            }
        }

        public void rotateZ(float rz)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].rotateZ(rz);
            }
        }

        public void interpolateFig(float alpha, Model modelA, Model modelB)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].interpolateTriangle( alpha, modelA.mesh.Triangles[i], modelB.mesh.Triangles[i]);
            }
        }

        public object Clone()
        {
            List<Triangle> clonedTriangles = new List<Triangle>();
            foreach (Triangle triangle in Triangles)
            {
                clonedTriangles.Add((Triangle)triangle.Clone());
            }
            return new Mesh(clonedTriangles);
        }
    }
}
