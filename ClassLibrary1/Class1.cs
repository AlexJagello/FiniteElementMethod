using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        #region initParameters
        private double[] k;
        private double[,] MatrixK;
        public double[] Deform;
        public double[] Stress;

        private double E;
        private double v;

        private double height;
        private double width;

        private double[] a;

        private double[] A;

        private bool position = false;

        private double[] Force;
       

        private double R;

        private int elements;

        FileStream fstream;
        public Class1()
        {
                string readPath = @"TextFileForCalculate.txt";
                fstream = new FileStream(readPath, FileMode.Open);
            CultureInfo.CurrentCulture = new CultureInfo("en-EN", false);
            byte[] array = new byte[fstream.Length];
            fstream.Read(array, 0, array.Length);
            string textFromFile = System.Text.Encoding.Default.GetString(array);
            string[] mass = textFromFile.Split('\n');

            elements = Convert.ToInt32(mass[5].Trim().Trim('\n')) + 1;
           height = Convert.ToDouble(mass[6].Split(',')[0].Trim());
           width = Convert.ToDouble(mass[6].Split(',')[1].Trim());

            E = Convert.ToDouble(mass[0].Split(',')[0].Trim());
            v = Convert.ToDouble(mass[0].Split(',')[1].Trim());

            a = new double[elements];
            A = new double[elements];

            a[0] = height * (Convert.ToInt32(mass[1].Split(',')[0].Trim()) + 1);
            a[1] = height *(Convert.ToInt32(mass[1].Split(',')[1].Trim()) + 1);
            a[2] = height *(Convert.ToInt32(mass[1].Split(',')[2].Trim()) + 1);

            A[0] = width * (Convert.ToDouble(mass[2].Split(',')[0].Trim()) + 1);
            A[1] = width * (Convert.ToDouble(mass[2].Split(',')[1].Trim()) + 1);
            A[2] = width * (Convert.ToDouble(mass[2].Split(',')[2].Trim()) + 1);
            A[3] = A[2];

            if (Convert.ToInt32(mass[3].Trim().Trim('\n')) == 1)
                position = true;

            Force = new double[elements]; 

            Force[0] = Convert.ToInt32(mass[4].Split(',')[0].Trim());
            Force[1] = Convert.ToInt32(mass[4].Split(',')[1].Trim());
            Force[2] = Convert.ToInt32(mass[4].Split(',')[2].Trim());
            Force[3] = Convert.ToInt32(mass[4].Split(',')[3].Trim());

            R = (-1) * (Force[0] + Force[1] + Force[2] + Force[3]);

            if (elements == 4)
            {
                if (position == false)
                    Force[0] = Force[0] + R;
                else
                    Force[elements - 1] = Force[elements - 1] + R;
            }
            fstream.Close();
        }
        #endregion

        #region PublicMethods
        public string StrData()
        {
            string str = "Information\n";

            str += "Lenght of elements\n";
            for (int i = 0; i < a.Length; i++)
            {
                str += a[i] + " ";
            }
            str += "\nSqare of elements\n";
            for (int i = 0; i < A.Length; i++)
            {
                str += A[i] + " ";
            }
            str += "\nForce\n";
            for (int i = 0; i < Force.Length; i++)
            {
                str += Force[i] + " ";
            }
            str += "\nCoeff K\n";
            for (int i = 0; i < k.Length; i++)
            {
                str += k[i] + " ";
            }

            str += "\nMatrix K\n";
            for (int i = 0; i < elements; i++)
            {
                str += "\n";
                for (int j = 0; j < elements; j ++)
                str += MatrixK[i,j] + " ";
            }
            str += "\n";
            str += "\nDeform\n";
            for (int i = 0; i < Deform.Length; i++)
            {
                str += "U"+ (i+1) +":  " + Deform[i] + "\n";
            }

            str += "\nStress\n";
            for (int i = 0; i < Stress.Length; i++)
            {
                str += "S" + (i + 1) + ":  " + Stress[i] + "\n";
            }

          /*  str += "\ndet"+Determinant(MatrixK,elements) + "\n";

            str += "\nReversMatrix K\n";
            for (int i = 0; i < elements; i++)
            {
                str += "\n";
                for (int j = 0; j < elements; j++)
                    str += ReversMatrix[i, j] + " ";
            }*/
            return str;
        }

        public string StrDeform()
        {
            string str = "";
            str += "\nDeform\n";
            for (int i = 0; i < Deform.Length; i++)
            {
                str += "U" + (i + 1) + ":  " + Deform[i] + "\n";
            }
            return str;
        }

        public string StrStress()
        {
            string str = "";
            str += "\nStress\n";
            for (int i = 0; i < Stress.Length; i++)
            {
                str += "S" + (i + 1) + ":  " + Stress[i] + "\n";
            }
            return str;
        }

        double[,] ReversMatrix;
        public double[] CalculteDeform()
        {
            MatrixK = new double[elements, elements];

            for (int j = 0; j < elements; j++)
                for (int i = 0; i < elements; i++)
                    MatrixK[i, j] = 0;

            CalculateK();
            CreateKMatrix();

            ReversMatrix = new double[elements, elements];
            double det = Determinant(MatrixK, elements);
            for (int i = 0; i < elements; i++)
            {
                for (int j = 0; j < elements; j++)
                {
                    int m = elements - 1;
                    ReversMatrix[i, j] = Math.Pow(-1.0, i + j + 2) * Determinant(InversMatrixElements(MatrixK, elements, i, j), m)/ det;          
                }
            }

           // ReversMatrix = TransparentMatrix(ReversMatrix);
            Deform = new double[elements];
            for (int i = 0; i < elements; i++)
            {
                Deform[i] = 0;
                for (int j = 0; j < elements; j++)
                {
                    Deform[i] += ReversMatrix[i, j] * Force[j];
                }
            }
            return Deform;
        }

        public double[] CalculateStress()
        {
           Stress = new double[elements - 1];

            for (int i = 0; i < elements - 1; i++)
            {
                Stress[i] = E * ((Deform[i + 1] - Deform[i]) / a[i]);
            }
                return Stress;
        }
        #endregion

        #region Calculate KMatrix

        private void CreateKMatrix()
        {
            double[][,] matrs2x2 = new double[elements][,];
            for (int j = 0; j < elements - 1; j++)
            {
                matrs2x2[j] = new double[elements, elements];
            }
           
            for (int j = 0; j < elements - 1; j++)
            {
                matrs2x2[j][j, j] = matrs2x2[j][j + 1, j + 1] = k[j];
                matrs2x2[j][j + 1, j] = matrs2x2[j][j, j + 1] = (-1) * k[j];             
            }

            for (int j = 0; j < elements - 1; j++)
            {
                for (int k = 0; k < elements; k++)
                {
                    for (int i = 0; i < elements; i++)
                    {
                        MatrixK[k, i] += matrs2x2[j][k, i];
                    }
                }
            }

          if (position == false)
            {
                MatrixK[0, 0] = 1;
                MatrixK[0, 1] = 1 * Math.Pow(10,-10);
            }else
            {
                MatrixK[elements-1, elements-1] = 1;
                MatrixK[elements-1, elements - 2] = 0;
            }
        }

        private void CalculateK()
        {
            k = new double[elements - 1];
            if (elements == 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    k[i] = ((A[i + 1] + A[i]) * E) / (2 * a[i]);
                }
            }
            else
            {
                double[] aa = new double[elements];
                double[] AA = new double[elements];

                double[] newForce = new double[elements];

                for (int i = 0; i < elements; i++)
                {
                    if (i % 2 != 0)
                        aa[i] = 0;
                    aa[i] = a[i/2]/ 2;
                }
                a = aa;

                AA[0] = A[0];
                AA[1] = A[0];
                AA[2] = A[1];
                AA[3] = A[1];
                AA[4] = A[2];
                AA[5] = A[2];
                AA[6] = A[2];
                A = AA;

                for (int i = 0; i < elements; i++)
                {
                    if (i % 2 != 0)
                        newForce[i] = 0;
                    else
                    newForce[i] = Force[i / 2];
                }
         
                Force = newForce;
                if (position == false)
                    Force[0] = Force[0] + R;
                else
                    Force[elements - 1] = Force[elements - 1] + R;

                for (int i = 0; i < elements - 1; i++)
                {
                    k[i] = ((AA[i + 1] + AA[i]) * E) / (2 * aa[i]);
                }
            }                    
        }

        #endregion

        #region OperationWithMatrix  

        private double[,] TransparentMatrix(double[,] Matr)
        {
            double[,] tm = new double[elements,elements];
            for (int i = 0; i < elements; i++)
                for (int j = 0; j < elements; j++)
                {
                     tm[i, j] = Matr[i, j];
                }

            for (int i = 0; i < elements; i++)
                for (int j = 0; j < elements; j++)
                    tm[j,i] = Matr[i,j];
            return tm;
        }

        private double Determinant(double[,] Matr, int n)
        {
            double[,] B = new double[n,n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                   B[i, j] = Matr[i, j];
                }

          
            for (int step = 0; step < n - 1; step++)
                for (int row = step + 1; row < n; row++)
                {
                    double coeff = -B[row,step] / B[step,step]; 
                    for (int col = step; col < n; col++)
                        B[row,col] += B[step,col] * coeff;
                }
            double Det = 1;
            for (int i = 0; i < n; i++)
                Det *= B[i,i];

            return Det;
        }

       private double[,] InversMatrixElements(double[,] Matr,int n, int indRow, int indCol)
        {
            double[,] f = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    f[i, j] = Matr[i, j];
                }

            int ki = 0;
            for (int i = 0; i < n; i++)
            {
                if (i != indRow)
                {
                    for (int j = 0, kj = 0; j < n; j++)
                    {
                        if (j != indCol)
                        {
                            f[ki,kj] = MatrixK[i,j];
                            kj++;
                        }
                    }
                    ki++;
                }
            }
            return f;
        }

        #endregion

    }
}
