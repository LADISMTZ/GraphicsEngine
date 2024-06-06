using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterFinal
{
    public partial class MyForm : Form
    {
        Scene scene;
        Mesh mesh;
        public List<Model> Models;
        int index;
        Render render;
        List<Vertex> vertexes;
        List<Triangle> triangles;
        Canvas canvas;
        Light light;
        bool playX, playY, playZ;
        bool tx, ty, tz;
        int traslationConstant;
        bool play;
        bool kf1, kf2;
        int counter;
        float alpha;
        public MyForm()
        {


            InitializeComponent();

            //mesh se asigna a model
            mesh = new Mesh(triangles);
            Models = new List<Model>();
            float[] values1 = new float[] { 0, 0, 0 };
            //Models.Add(new Model(mesh, new Vertex(values1)));
            index = 0;

            //deben de haber 2 mesh por lo tanto 2 modelos
            //los dos modelos se asignan a la escena
            scene = new Scene(Models);
            light = new Light(0, 0);
            playX = playY = playZ = false;
            tx = ty = tz = false;
            traslationConstant = 10;
            play = kf1 = kf2 = false;
            counter = 0;
            alpha = 0;
            listBox2.Items.Add("No filter");
            listBox2.Items.Add("Gray scale");
            listBox2.Items.Add("Inverted");
            listBox2.Items.Add("Sepia");
            listBox2.SelectedIndex = 0;

            listBox3.Items.Add("No filter");
            listBox3.Items.Add("Brightness");
            listBox3.Items.Add("Contrast");
            listBox3.SelectedIndex = 0;

            listBox4.Items.Add("No filter");
            listBox4.Items.Add("Softening");
            listBox4.SelectedIndex = 0;
        }

        private void LoadModelFromObj(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            vertexes = new List<Vertex>();
            triangles = new List<Triangle>();
            String line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(' ');

                // Procesar vértices
                if (parts[0] == "v")
                {
                    float x = float.Parse(parts[1]);
                    float y = float.Parse(parts[2]);
                    float z = float.Parse(parts[3]);
                    //guardar puntos en lista de vertex
                    float[] values = new float[] { x, y, z };
                    vertexes.Add(new Vertex(values));
                }
                // Procesar caras
                else if (parts[0] == "f")
                {
                    List<int> vertexIndices = new List<int>();
                    for (int i = 1; i < parts.Length; i++)
                    {
                        string[] indices = parts[i].Split('/');
                        int vertexIndex = int.Parse(indices[0]) - 1; // -1 because OBJ indices start from 1
                        vertexIndices.Add(vertexIndex);
                    }
                    //generar triangulos con respecto al archivo
                    //la lista de triangulos generada se asigna a mesh
                    triangles.Add(new Triangle(
                        vertexes[vertexIndices[0]],
                        vertexes[vertexIndices[1]],
                        vertexes[vertexIndices[2]]
                    ));


                }


            }

            //mesh se asigna a model
            mesh = new Mesh(triangles);
            //Models = new List<Model>();
            float[] values1 = new float[] { 0, 0, 0 };
            Models.Add(new Model(mesh, new Vertex(values1)));
            //index = 0;
            //render = new Render(PCT_CANVAS);
            //deben de haber 2 mesh por lo tanto 2 modelos
            //los dos modelos se asignan a la escena

            //light = new Light(0, 0);
            listBox1.Items.Add("Shape " + scene.Models.Count());
            listBox1.SelectedIndex = scene.Models.Count - 1;
        }
        private void AddObj_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "OBJ files (*.obj)|*.obj|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            // Get the path of specified file
            var filePath = openFileDialog.FileName;

            // Load the model from the selected OBJ file
            LoadModelFromObj(filePath);

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void TIMER_Tick(object sender, EventArgs e)
        {
            if (!play)
            {
                Render();
            }
            else
            {
                animate();
            }

        }

        private void updateCanvasValues()
        {
            render.canvas.filter = listBox2.SelectedIndex;
            render.canvas.filter2 = listBox3.SelectedIndex;
            render.canvas.conv = listBox4.SelectedIndex;
            try
            {
                if (brightAndContrast.Text == "" || brightAndContrast.Text == "-")
                {
                    render.canvas.br = 0;
                }
                else
                {
                    render.canvas.br = int.Parse(brightAndContrast.Text);
                }
                if (textBoxAlpha.Text == "")
                {
                    render.canvas.alpha = 0;
                }
                else
                {
                    render.canvas.alpha = float.Parse(textBoxAlpha.Text);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show("Enter a valid format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Render()
        {
            if (listBox1.SelectedIndex != -1)
            {
                activateRotationX(); activateRotationY(); activateRotationZ();
                trX(); trY(); trZ();
                updateCanvasValues();



            }
            render.RenderScene(scene, light);
            PCT_CANVAS.Invalidate();
        }

        public void animate()
        {
            if (counter <= 30)
            {

                updateCanvasValues();
                render.showAnimation(alpha, light);
                counter++;
                alpha = alpha + 1.0f / 30.0f;
                PCT_CANVAS.Invalidate();
                //mandar a llamar a que se anime
            }
            else
            {
                alpha = 0;
                counter = 0;
                buttonPlay.BackColor = Color.White;
                play = false;
            }

        }

        private void PCT_CANVAS_MouseMove(object sender, MouseEventArgs e)
        {

            light.x = e.X;
            light.y = e.Y;
            label1.Text = "Posición de la luz: " + e.Location.ToString();

        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            render = new Render(PCT_CANVAS);
            TIMER.Enabled = true;
        }

        private void addScaleButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (scene.Models.Count > 0 && listBox1.SelectedIndex >= 0 && scaleTextBox.Text != "")
                    scene.Models[listBox1.SelectedIndex].scale += int.Parse(scaleTextBox.Text);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Enter a valid format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void subtractScaleButton_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex >= 0)
            {
                if (scene.Models.Count > 0)
                    scene.Models[listBox1.SelectedIndex].scale -= int.Parse(scaleTextBox.Text);
            }
        }


        private void buttonPlayX_Click(object sender, EventArgs e)
        {
            playX = !playX;
        }

        private void activateRotationX()
        {
            if (playX)
            {
                if (scene.Models.Count > 0)
                {
                    buttonPlayX.BackColor = Color.Red;
                    render.updateRotationX(scene, listBox1.SelectedIndex);
                }
            }
            else
            {
                buttonPlayX.BackColor = Color.White;
            }
        }


        private void buttonPlayY_Click(object sender, EventArgs e)
        {
            playY = !playY;
        }

        private void activateRotationY()
        {
            if (playY)
            {
                if (scene.Models.Count > 0)
                {
                    buttonPlayY.BackColor = Color.Red;
                    render.updateRotationY(scene, listBox1.SelectedIndex);
                }
            }
            else
            {
                buttonPlayY.BackColor = Color.White;
            }
        }

        private void buttonPlayZ_Click(object sender, EventArgs e)
        {
            playZ = !playZ;

        }

        private void activateRotationZ()
        {
            if (playZ)
            {
                if (scene.Models.Count > 0)
                {
                    buttonPlayZ.BackColor = Color.Red;
                    render.updateRotationZ(scene, listBox1.SelectedIndex);
                }
            }
            else
            {
                buttonPlayZ.BackColor = Color.White;
            }
        }

        private void buttonTX_Click(object sender, EventArgs e)
        {
            tx = !tx;
        }

        private void buttonTY_Click(object sender, EventArgs e)
        {
            ty = !ty;
        }

        private void buttonTZ_Click(object sender, EventArgs e)
        {
            tz = !tz;
        }
        private void trX()
        {
            if (tx)
            {
                if (scene.Models.Count > 0)
                {
                    buttonTX.BackColor = Color.Red;
                    scene.Models[listBox1.SelectedIndex].traslation[0] += traslationConstant;
                }
            }
            else
            {
                buttonTX.BackColor = Color.White;
            }
        }
        private void trY()
        {

            if (ty)
            {
                if (scene.Models.Count > 0)
                {
                    buttonTY.BackColor = Color.Red;
                    scene.Models[listBox1.SelectedIndex].traslation[1] += traslationConstant;
                }
            }
            else
            {
                buttonTY.BackColor = Color.White;
            }
        }
        private void trZ()
        {
            if (tz)
            {
                if (scene.Models.Count > 0)
                {
                    buttonTZ.BackColor = Color.Red;
                    scene.Models[listBox1.SelectedIndex].traslation[2] += traslationConstant;
                }
            }
            else
            {
                buttonTZ.BackColor = Color.White;
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            neg.BackColor = Color.Red;
            pos.BackColor = Color.White;
            traslationConstant = -10;
        }

        private void posTZ_Click(object sender, EventArgs e)
        {
            neg.BackColor = Color.White;
            pos.BackColor = Color.Red;
            traslationConstant = 10;
        }

        private void PCT_CANVAS_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            render = new Render(PCT_CANVAS);
            TIMER.Enabled = true;
        }

        private void buttonLines_Click(object sender, EventArgs e)
        {
            render.lines = !render.lines;
            if (render.lines)
            {
                buttonLines.BackColor = Color.Red;
            }
            else
            {
                buttonLines.BackColor = Color.White;
            }
        }

        private void buttonBodies_Click(object sender, EventArgs e)
        {
            render.body = !render.body;
            if (render.body)
            {
                buttonBodies.BackColor = Color.Red;
            }
            else
            {
                buttonBodies.BackColor = Color.White;
            }
        }

        private void buttonKF1_Click(object sender, EventArgs e)
        {
            render.kf1 = (Scene)scene.Clone();
            kf1 = true;
            buttonKF1.BackColor = Color.Red;
        }

        private void buttonKF2_Click(object sender, EventArgs e)
        {
            render.kf2 = (Scene)scene.Clone();
            kf2 = true;
            buttonKF2.BackColor = Color.Red;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (kf1 && kf2)
            {
                buttonPlay.BackColor = Color.Red;
                play = true;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (scene.Models.Count > 0)
            {
                scene.Models.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }
    }
}
