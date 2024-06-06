using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace RasterFinal
{
    public class Render
    {

        public Scene kf1, kf2, interpolatedScene;
        public Canvas canvas;
        public Size size;
        static public float[,] zbuffer;
        static public Color[,] colorbuffer;
        public bool lines, body;
        


        public Render(PictureBox size)
        {
            canvas = new Canvas(size);
            this.size = size.Size;
            zbuffer = new float[size.Width, size.Height];
            colorbuffer = new Color[size.Width, size.Height];
            lines = body = true;
            
        }

        public List<float> Interpolate(float i0, float d0, float i1, float d1)
        {
            List<float> values = new List<float>();
            if (i0 == i1)
            {
                values.Add(d0);
                return values;
            }

            float a = (float)(d1 - d0) / (float)(i1 - i0);
            float d = d0;
            for (float i = i0; i < i1; i++)
            {
                values.Add(d);
                d += a;
            }
            return values;
        }

        public void DrawPoint(Vertex point, float z, Color c)
        {
            if (point.X <= 0 || point.X >= canvas.Width || point.Y <= 0 || point.Y >= canvas.Height)
            {
                return;
            }
            if (z > zbuffer[(int)point.X, (int)point.Y]) return;
            canvas.DrawPixel((int)point.X, (int)point.Y, c);
            zbuffer[(int)point.X, (int)point.Y] = z;
            colorbuffer[(int)point.X, (int)point.Y] = c;
        }
        public void DrawLine(Vertex p0, Vertex p1, Color c)
        {
            if (p0.X <= 0 || p0.X >= canvas.Width || p0.Y <= 0 || p0.Y >= canvas.Height || p1.X <= 0 || p1.X >= canvas.Width || p1.Y <= 0 || p1.Y >= canvas.Height)
            {
                return;
            }
            if (Math.Abs(p1.X - p0.X) > Math.Abs(p1.Y - p0.Y))
            {
                if (p0.X > p1.X)
                {
                    DrawLine(p1, p0, c);
                }

                List<float> ys = Interpolate(p0.X, p0.Y, p1.X, p1.Y);
                List<float> zs = Interpolate(p0.X, p0.Z, p1.X, p1.Z);

                for (var x = (int)p0.X; x < p1.X; x++)
                {

                    var index = (int)x - (int)p0.X;



                    if (index < 0 || index >= ys.Count || index > zs.Count || index < 0) continue;

                    if (index >= zs.Count)
                    {
                        Console.Write("AHHH");
                    }
                    int y = (int)ys[index];
                    float z = zs[(int)x - (int)p0.X];


                    if (x >= 0 && x < canvas.Width && y >= 0 && y < canvas.Height)
                    {
                        if (z < zbuffer[(int)x, y])
                        {
                            zbuffer[(int)x, y] = z;
                            colorbuffer[(int)x, y] = c;
                            canvas.DrawPixel(x, y, c);
                        }
                    }

                    //DrawPixel((int)Math.Round(x), (int)Math.Round(ys[(int)Math.Round(x - p0.X)]), c);

                }
            }
            else
            {
                if (p0.Y > p1.Y)
                {
                    DrawLine(p1, p0, c);
                }
                List<float> xs = Interpolate(p0.Y, p0.X, p1.Y, p1.X);
                List<float> zs = Interpolate(p0.Y, p0.Z, p1.Y, p1.Z);
                for (var y = (int)p0.Y; y < p1.Y; y++)
                {

                    var index = (int)y - (int)p0.Y;



                    if (index < 0 || index >= xs.Count || index>zs.Count || index<0) continue;
                    int x = (int)xs[index];

                    if (index >= zs.Count)
                    {
                        Console.Write("AHHH");
                    }
                    float z = zs[(int)y - (int)p0.Y];

                    if (x >= 0 && x < canvas.Width && y >= 0 && y < canvas.Height)
                    {
                        if (z < zbuffer[(int)x, y])
                        {
                            zbuffer[(int)x, y] = z;
                            colorbuffer[(int)x, y] = c;
                            canvas.DrawPixel(x, y, c);
                        }
                    }

                }
            }
        }

        public void DrawFilledTriangle(Vertex P0, Vertex P1, Vertex P2, Color color)
        {
            if (P0.X <= 0 || P0.X >= canvas.Width || P0.Y <= 0 || P0.Y >= canvas.Height ||
                P1.X <= 0 || P1.X >= canvas.Width || P1.Y <= 0 || P1.Y >= canvas.Height ||
                P2.X <= 0 || P2.X >= canvas.Width || P2.Y <= 0 || P2.Y >= canvas.Height)
            {
                return;
            }
            List<float> x01;
            List<float> x12;
            List<float> x02;

            List<float> z01;
            List<float> z12;
            List<float> z02;

            List<float> h01;
            List<float> h12;
            List<float> h02;



            SortBy(ref P0, ref P1, ref P2);

            x01 = Interpolate(P0.Y, P0.X, P1.Y, P1.X);
            x12 = Interpolate(P1.Y, P1.X, P2.Y, P2.X);
            x02 = Interpolate(P0.Y, P0.X, P2.Y, P2.X);

            z01 = Interpolate(P0.Y, 1 / P0.Z, P1.Y, 1 / P1.Z);
            z12 = Interpolate(P1.Y, 1 / P1.Z, P2.Y, P2.Z);
            z02 = Interpolate(P0.Y, 1 / P0.Z, P2.Y, 1 / P2.Z);

            h01 = Interpolate(P0.Y, P0.intensity, P1.Y, P1.intensity);
            h12 = Interpolate(P1.Y, P1.intensity, P2.Y, P2.intensity);
            h02 = Interpolate(P0.Y, P0.intensity, P2.Y, P2.intensity);

            x01.Remove(x01.Count - 1);
            x01.AddRange(x12);

            z01.Remove(z01.Count - 1);
            z01.AddRange(z12);

            h01.Remove(h01.Count - 1);
            h01.AddRange(h12);

            if (x01.Count == 0 || x02.Count == 0)
            {
                return;
            }

            int m = (int)Math.Floor(x02.Count / 2.0); // Calcula el índice medio

            List<float> x_left;
            List<float> x_right;

            List<float> h_left;
            List<float> h_right;

            List<float> z_left;
            List<float> z_right;

            if (x02[m] < x01[m])
            {
                x_left = x02;
                h_left = h02;
                z_left = z02;

                x_right = x01;
                h_right = h01;
                z_right = z01;

            }
            else
            {
                x_left = x01;
                h_left = h01;
                z_left = z01;

                x_right = x02;
                h_right = h02;
                z_right = z02;

            }

            for (int y = (int)P0.Y; y < P2.Y; y++)
            {
                List<float> h_segment;
                List<float> z_segment;
                var index = y - (int)P0.Y;

                if (index < 0 || index >= x_left.Count || index >= x_right.Count || index >= h_left.Count || index >= h_right.Count || index >= z_left.Count || index >= z_right.Count) continue;
                int x_l = (int)x_left[index];
                int x_r = (int)x_right[index];

                h_segment = Interpolate(x_l, h_left[index], x_r, h_right[index]);
                z_segment = Interpolate(x_l, 1 / z_left[index], x_r, 1 / z_right[index]);

                for (float x = x_l; x < x_r; x++)
                {
                    Color shaded_color = color;

                    shaded_color = Color.FromArgb(
                    shaded_color.A,
                    (int)(shaded_color.R * h_segment[(int)x - x_l]),
                    (int)(shaded_color.G * h_segment[(int)x - x_l]),
                    (int)(shaded_color.B * h_segment[(int)x - x_l])
    );

                    float z = z_segment[(int)x - x_l];

                    if (z < zbuffer[(int)x, y])
                    {

                        Vertex point = new Vertex();
                        point.X = x;
                        point.Y = y;

                        DrawPoint(point, z, shaded_color);

                        zbuffer[(int)x, y] = z;
                        colorbuffer[(int)x, y] = shaded_color;
                    }


                }
            }


        }

        public void DrawTriangleWithLighting(Vertex P0, Vertex P1, Vertex P2, Light light)
        {
            // Calcular la distancia de la luz a cada vértice
            float distanceP0 = P0.CalculateDistance(light);
            float distanceP1 = P1.CalculateDistance(light);
            float distanceP2 = P2.CalculateDistance(light);

            // Normalizar las distancias
            float totalDistance = 1000;
            float intensityP0 = 1 - (distanceP0 / totalDistance);
            float intensityP1 = 1 - (distanceP1 / totalDistance);
            float intensityP2 = 1 - (distanceP2 / totalDistance);



            intensityP0 = intensityP0 < 0f ? 0f : intensityP0 > 1f ? 1f : intensityP0;
            intensityP1 = intensityP1 < 0f ? 0f : intensityP1 > 1f ? 1f : intensityP1;
            intensityP2 = intensityP2 < 0f ? 0f : intensityP2 > 1f ? 1f : intensityP2;



            // Usar las intensidades para ajustar la intensidad de luz de cada vértice
            P0.intensity = intensityP0 * intensityP0;
            P1.intensity = intensityP1 * intensityP1;
            P2.intensity = intensityP2 * intensityP2;

            // Dibujar el triángulo con la intensidad de luz ajustada
            DrawFilledTriangle(P0, P1, P2, Color.Green);
        }


        public void SortBy(ref Vertex P0, ref Vertex P1, ref Vertex P2)
        {
            if (P1.Y < P0.Y) { swap(ref P1, ref P0); }
            if (P2.Y < P0.Y) { swap(ref P2, ref P0); }
            if (P2.Y < P1.Y) { swap(ref P2, ref P1); }
        }

        public void swap(ref Vertex P0, ref Vertex P1)
        {
            Vertex temp = P0;
            P0 = P1;
            P1 = temp;
        }

        public void render(Size size, Mesh figure, Light light, float[,] zbuffer)
        {

            /*canvas.FastClear();
            canvas.g.Clear(Color.Black);*/
            if (lines)
                figure.activateLines(this);
            if (body)
                figure.renderFigure(this, light, canvas);
            canvas.applyConvolusionalFilter(zbuffer,colorbuffer);

        }
        public void RenderScene(Scene scene, Light light)
        {

            ClearZBuffer();
            canvas.FastClear();//-------------------CLEAR SCENE
            Model model;
            for (int s = 0; s < scene.Models.Count; s++)
            {


                model = scene.Models[s];
                //----- ALL TRANSFORMATIONS --------------------------------------
                //model.mesh.rotateX(25f);
                //model.mesh.rotateY(25f);
                //model.mesh.rotateZ(25f);
                model.mesh.scaleFig(50 + (int)model.scale);
                model.mesh.traslacionFig(size, model.traslation);
                //model.mesh.translateZ(-10f);
                //if (s == 0) { model.mesh.translateZ(-0.01f); }
                render(size, model.mesh, light, zbuffer);
                /*model.mesh.activateLines(canvas.g);
                model.mesh.renderFigure(canvas.g);*/


            }
        }


        public void updateRotationX(Scene scene, int s)
        {
            Model model;
            model = scene.Models[s];
            model.mesh.rotateX(model.rotationX);
        }

        public void updateRotationY(Scene scene, int s)
        {
            Model model;
            model = scene.Models[s];
            model.mesh.rotateY(model.rotationY);
        }
        public void updateRotationZ(Scene scene, int s)
        {
            Model model;
            model = scene.Models[s];
            model.mesh.rotateZ(model.rotationZ);
        }

        private void ClearZBuffer()
        {
            // Inicializar todos los valores del Z-buffer a infinito (o a una distancia muy grande)
            for (int y = 0; y < size.Height; y++)
            {
                for (int x = 0; x < size.Width; x++)
                {
                    //zbuffer[x, y] = float.PositiveInfinity;
                    zbuffer[x, y] = float.MaxValue;
                    colorbuffer[x, y] = Color.FromArgb(0, 0, 0);
                }
            }
        }

        public void showAnimation(float alpha, Light light)
        {
            if (alpha == 0)
            {
                interpolatedScene =  (Scene)kf1.Clone();
            }
            ClearZBuffer();
            canvas.FastClear();
            Model model, model2, model3;
            for (int s = 0; s < interpolatedScene.Models.Count; s++)
            { 
                model = interpolatedScene.Models[s];
                model2 = kf1.Models[s];
                model3 = kf2.Models[s]; 
                model.mesh.interpolateFig( alpha, model2,model3);
                render(size, model.mesh, light, zbuffer);
            }
            //RenderScene(interpolatedScene,light);
        }

        

    }
}
