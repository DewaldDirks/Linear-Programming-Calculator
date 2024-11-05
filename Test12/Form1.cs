using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Test12
{
    public partial class Form1 : Form //Graph lines 
    {
        Pen p = new Pen(Color.Black, 2);             
        Pen p1 = new Pen(Color.Green, 2);
        Pen p2 = new Pen(Color.Red, 2);
        Pen p3 = new Pen(Color.Blue, 2);
        SolidBrush greenBrush = new SolidBrush(Color.FromArgb(64, 0, 150, 0));
        SolidBrush redBrush = new SolidBrush(Color.FromArgb(64, 255, 0, 0));
        Label[] AllDynamicLabels = new Label[50];
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)//X and Y axes
        {
            Graphics g = this.CreateGraphics();
            
            g.DrawLine(p, 335, 10, 335, 660);
            g.DrawLine(p, 10, 335, 660, 335);        
            
            string[] lines = redtInput.Lines;
            int a = lines.Length;
            List<Double> coords = new List<double>();
            List<string> signs = new List<string>();
            double MaxVar = 0;
            for (int i = 1; lines.Length - 2 >= i; i++)//string manipulation
            {
                string controlString = lines[i];
                int test = controlString.IndexOf((char)32) + 1;
                double x1 = Convert.ToDouble(controlString.Substring(0, controlString.IndexOf((char)32)));
                controlString = controlString.Remove(0, controlString.IndexOf((char)32) + 1);
                double x2 = Convert.ToDouble(controlString.Substring(0, controlString.IndexOf((char)32)));  
                controlString = controlString.Remove(0, controlString.IndexOf((char)32) + 1);
                string sign = controlString.Substring(0, controlString.IndexOf((char)32));
                signs.Add(sign);
                controlString = controlString.Remove(0, controlString.IndexOf((char)32) + 1);
                double rhs = Convert.ToDouble(controlString.Substring(0));

                if (rhs/x1 > rhs/x2 && rhs/x1 > MaxVar && x1 != 0) { MaxVar = rhs /x1; } //check Constraints 
                else if ( rhs / x2 > MaxVar && x2 != 0) { MaxVar = rhs /x2; };
                if (x1 != 0)
                    coords.Add(rhs / x1);           
                else
                    coords.Add(0);
                if (x2 != 0)
                    coords.Add(rhs / x2);
                else
                    coords.Add(0);
            }
            Label[] labels = new Label[coords.Count];
            double mulitipier = 325 / MaxVar;
            for (int i = 0; i < coords.Count; i += 2)//Lines desplayed on GUI    
            {
                int x1 = Convert.ToInt32( coords[i+1] * mulitipier);
                int x2 = Convert.ToInt32(coords[i] * mulitipier);
                labels[i] = new Label();
                labels[i].Text = coords[i+1].ToString();
                labels[i].Location = new Point(300,340-x1);
                labels[i].Size = new Size(25, 20);
                labels[i].BackColor = System.Drawing.Color.Transparent;        
                labels[i].Name = "lbl" + i.ToString();
                this.Controls.Add(labels[i]);
                labels[i+1] = new Label();
                labels[i+1].Text = coords[i].ToString();
                labels[i+1].Location = new Point(335+x2,340);
                labels[i+1].Size = new Size(25, 20);
                labels[i+1].Name = "lbl" + (i+1).ToString();
                labels[i+1].BackColor = System.Drawing.Color.Transparent;
                this.Controls.Add(labels[i+1]);
                Pen tempPen = new Pen(Color.Yellow);
                if (signs[i / 2] == ">=")//picking Pen colors
                {
                    tempPen = p1;
                }
                else if (signs[i / 2] == "<=")
                {
                    tempPen = p2;                    
                }
                else if (signs[i / 2] == "=")
                {
                    tempPen = p3;
                }
                if (x1 == 0)
                {
                    g.DrawLine(tempPen, 335 + x2, 10, 335+ x2, 335);  //Feasible area
                    if (signs[i / 2] == "<=")
                    {
                        Point point1 = new Point(335 + x2, 10);
                        Point point2 = new Point(335, 10);
                        Point point3 = new Point(335, 335);
                        Point point4 = new Point(335 + x2, 335);
                        Point[] poligon = { point1, point2, point3,point4 };
                        g.FillPolygon(redBrush, poligon);

                    }
                    else if (signs[i / 2] == ">=")
                    {
                        Point point1 = new Point(335 + x2, 10);
                        Point point2 = new Point(660, 10);
                        Point point3 = new Point(660, 335);
                        Point point4 = new Point(335 + x2, 335);
                        Point[] poligon = { point1, point2, point3, point4 };
                        g.FillPolygon(greenBrush, poligon);
                    }
                }
                else if (x2 == 0)
                {
                    g.DrawLine(tempPen, 335, 335 - x1, 660, 335 - x1);
                    if (signs[i / 2] == "<=")
                    {
                        Point point1 = new Point(335, 335 - x1);
                        Point point2 = new Point(335, 335);
                        Point point3 = new Point(660, 335);
                        Point point4 = new Point(660, 335 - x1);
                        Point[] poligon = { point1, point2, point3, point4 };
                        g.FillPolygon(redBrush, poligon);

                    }
                    else if (signs[i / 2] == ">=")
                    {
                        Point point1 = new Point(335, 335 - x1);
                        Point point2 = new Point(335, 10);
                        Point point3 = new Point(660, 10);
                        Point point4 = new Point(660, 335 - x1);
                        Point[] poligon = { point1, point2, point3, point4 };
                        g.FillPolygon(greenBrush, poligon);
                    }
                }
                else
                {
                    g.DrawLine(tempPen, 335, 335 - x1, x2 + 335, 335);
                    if(signs[i / 2] == "<=") { 
                        Point point1 = new Point(335, 335 - x1);
                        Point point2 = new Point(x2 + 335, 335);
                        Point point3 = new Point(335, 335);
                        Point[] poligon = { point1, point2, point3 };
                        g.FillPolygon(redBrush, poligon);

                    }else if (signs[i / 2] == ">=")
                    {
                        Point point1 = new Point(335, 335 - x1);
                        Point point2 = new Point(x2 + 335, 335);
                        Point point3 = new Point(660,10);
                        Point point4 = new Point(335, 10);
                        Point[] poligon = { point1, point2, point3,point4 };
                        g.FillPolygon(greenBrush, poligon);
                    }
                }
            }
            AllDynamicLabels = labels;
        }

        private void button2_Click(object sender, EventArgs e)  //Button function 
        {
            this.Invalidate();
            for (int i = 0; i < AllDynamicLabels.Length; i++)
            {
             this.Controls.Remove(this.Controls["lbl" + i.ToString()]);
            }
        }

        private void btnTextfile_Click(object sender, EventArgs e) //Button Textfile 
        {
            redtInput.Clear();
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Textfiles (*.txt*)|*.txt*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
            try
            {
                using (StreamReader sr = new StreamReader(sFileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (redtInput.Text != "")
                            redtInput.AppendText(Environment.NewLine + line);
                        else
                            redtInput.AppendText(line);

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The file could not be read:");
            }
            }
        }
    }
}
