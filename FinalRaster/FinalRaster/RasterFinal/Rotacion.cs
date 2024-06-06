using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterFinal
{
    public class Rotacion
    {

        public Vertex RotarZ(float angle, Vertex p)
        {
            Mtx Mat;
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            float[,] axis = new float[,]
                {
                { cos,-sin,0},
                { sin,cos,0},
                { 0,0,1}
                };
            Mat = new Mtx(axis);
            return Mat.Mul(p);
        }

        public Vertex RotarY(float angle, Vertex p)
        {
            Mtx Mat;
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            float[,] axis = new float[,]
                {
                { cos,0,sin},
                { 0,1,0},
                { -sin,0,cos}
                };
            Mat = new Mtx(axis);
            return Mat.Mul(p);
        }

        public Vertex RotarX(float angle, Vertex p)
        {
            Mtx Mat;
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            float[,] axis = new float[,]
                {
                { 1,0,0},
                { 0,cos,-sin},
                { 0,sin,cos}
                };
            Mat = new Mtx(axis);
            return Mat.Mul(p);
        }


    }
}
