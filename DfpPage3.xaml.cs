using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PoastSuite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DfpPage3 : ContentPage
    {

        public DfpPage3()
        {
            InitializeComponent();
            //g1x1.Text = dfx1.ToString();
            // double l1 = double.Parse(Lambda1.Text);
        }

        async private void NextIterationButton_Clicked(object sender, EventArgs e)
        {
            // DECLARATION OF VARIABLES AND ARRAYS USED for DPF PROJECT
            double[] Coef = new double[] { };
            

            double a;
            double b;
            double c;
            double d;
            double ee;
            double f;
            double fx;

            double[,] X1 = new double[,] { };
            double[,] X2 = new double[,] { };
            double[,] X3 = new double[,] { };

            double[,] H1 = new double[,] { };
            double[,] H2 = new double[,] { };

            double[,] g1 = new double[,] { };
            double[,] g2 = new double[,] { };
            double[,] g3 = new double[,] { };

            double[,] S1 = new double[,] { };
            double[,] S2 = new double[,] { };

            double g1x1;
            double g1x2;
            double g2x1;
            double g2x2;
            double g3x1;
            double g3x2;

            double x2x1 = 0;
            double x2x2 = 0; 

            double L1;
            double L2;

            double[,] L1S1 = new double[,] { };
            double[,] L2S2 = new double[,] { };

            double[,] q = new double[,] { };

            double[,] Si_SiT = new double[,] { };
            double[,] SiT_qi = new double[,] { };
            double invSiT_qi;

            double[,] A1 = new double[,] { };
            double[,] Hq = new double[,] { };
            double[,] Hq_HqT = new double[,] { };

            double[,] qiT_Hi_qi = new double[,] { };
            double inv_qiT_Hi_qi;
            double[,] B1 = new double[,] { };
            double tolerance = 0.0001;                 //                    <<<<Tolerance

            double[] GradeData = new double[] { };



            //NOTE: gi (Gradient Vector), Xi (Starting Point) and Si (Search Direction) are all column vectors 

            //Step a : Select Initial point [X1] and n x n positive definite symmetric Hi. Usually Hi = I (Unit Matrix)
            X1 = new double[,]
            {
                   {-2},
                   {4}
            };
           

            //n x n Positive definite symmetric matrix Hi 
            H1 = new double[,]
            {
                     {1,0},
                     {0,1}
            };

            // COEFFICIENTS OF f(x) in Array(Coef) but passed to variables a, b, c, d e, f
            Coef = new double[] { 1.5, 0.5, -1, -2, 0, 0 };

            a = Coef[0];
            b = Coef[1];
            c = Coef[2];
            d = Coef[3];
            ee = Coef[4];
            f = Coef[5];

            //MODEL (fx Equation)
            fx = (a * Math.Pow(X1[0, 0], 2)) + (b * Math.Pow(X1[1, 0], 2)) + (c * X1[0, 0] * X1[1, 0]) + (d * X1[0, 0]) + (ee * Math.Pow(X1[1, 0], 2)) + f;

            //Step b:

            //Partial Diff wrt x1
            g1x1 = (2 * a * X1[0, 0]) + (c * X1[1, 0]) + d;
            //Partial Diff wrt x2
            g1x2 = (2 * b * X1[1, 0]) + (c * X1[0, 0]) + (2 * ee * X1[1, 0]);

            //Passing the values of g1x1 and g1x2 to matrix g1 (gradient vector)
            g1 = new double[,]
            {
                  {g1x1},
                  {g1x2}
            };

            //The dimensions of the Matrices being multiplied determines the nature of the dimension of the resultant matrix array holding the answer of the matrix multplication.
            //NOTE:If Column of first matrix = Row of Second matrix then they can be multiplied/
            // 2x2 * 2x1

            S1 = MatrixMultiplication(H1, g1);
            S1 = ScalarMatrixMultiplication(S1, -1);

            double s1x1 = S1[0, 0];
            double s1x2 = S1[1, 0];

            S1 = new double[,]
            {
                  {s1x1},
                  {s1x2}
            };


            //x2x2 = (double)Math.Round(Convert.ToDecimal(X2[1, 0]), 4);
            //Step c: 
            L1 = -((-48 * a) + (-48 * b) + (48 * c) + (12 * c) + (12 * d)) / ((288 * a) + (72 * b) - (144 * c));
            L1 = Math.Round(Convert.ToDouble(L1), 4);


            // L2 = -((-0.9490 * a) + (-3.237 * b) + (1.1074 * c) + (0.6935 * c) + (0.7241 * d)) / ((0.1925 * a) + (1.0486 * b) - (0.4492 * c));


            // Also solve for L2 in this nature

            for (int i = 1; Math.Abs(g1x1) >= tolerance && Math.Abs(g1x2) >= tolerance; i++)
            {
                //Algorithm d: Test the new point for convergence.If xi+1 is optimal, terminate the iteration process, otherwise proceed to Algorithm e
                if (i == 1)
                {

                    L1S1 = ScalarMatrixMultiplication(S1, L1);

                   // Initialization of X2
                    X2 = new double[,]
                    {
                       {0},
                       {0}
                    };

                    X2[0, 0] = X1[0, 0] + L1S1[0, 0];
                    X2[1, 0] = X1[1, 0] + L1S1[1, 0];

                    //Console.WriteLine("Hence X3 =[{0},{1}] is the required minimum point and X3 is Optimal", Math.Round(Convert.ToDecimal(X3[0, 0]), 0), Math.Round(Convert.ToDecimal(X3[1, 0]), 0));
                    
                    x2x1 = Math.Round(Convert.ToDouble(X2[0, 0]), 4);
                    x2x2 = Math.Round(Convert.ToDouble(X2[1, 0]), 3);

                    X2 = new double[,]
                    {
                       {x2x1},
                       {x2x2}
                    };

                    //Partial Diff wrt x1
                    g2x1 = (2 * a * X2[0, 0]) + (c * X2[1, 0]) + d;
                    //Partial Diff wrt x2
                    g2x2 = (2 * b * X2[1, 0]) + (c * X2[0, 0]) + (2 * ee * X2[1, 0]);

                    g2 = new double[,]
                    {
                       {g2x1},
                       {g2x2}
                    };

                    //Console.WriteLine("============Iteration [{0}]============", i);
                    //Console.WriteLine("X2 (Search Point X2):");
                    //PrintMatrix1(X2);
                    //Console.WriteLine();
                    //Console.WriteLine("The Values of X2 are x1 = {0} and x2 = {1}", Math.Round(Convert.ToDecimal(X2[0, 0]), 3), Math.Round(Convert.ToDecimal(X2[1, 0]), 3));

                    //Console.WriteLine("The gradient vector g2 are  df(x)/dx1 = {0}, where as df(x)/dx2 = {1},", Math.Round(Convert.ToDecimal(g2x1), 3), Math.Round(Convert.ToDecimal(g2x2), 3));

                    g1x1 = g2x1;
                    g1x2 = g2x2;
                }
                else if (i == 2)
                {
                    //Algorithm e : Update H matrix as follows: Hi+1 = Hi + Ai + Bi
                    L2 = 1.7058;

                    q = new double[,]
                    {
                      {0},
                      {0}
                    };

                    q[0, 0] = g2[0, 0] - g1[0, 0];
                    q[1, 0] = g2[1, 0] - g1[1, 0];

                    //Evaluation to obtain A1
                    Si_SiT = MatrixMultiplication(S1, TransposeMatrix(S1));   //Si*Si'
                    SiT_qi = MatrixMultiplication(TransposeMatrix(S1), q);    //Si'*qi
                    invSiT_qi = 1 / SiT_qi[0, 0];
                    A1 = ScalarMatrixMultiplication(Si_SiT, invSiT_qi);
                    //double[,] Aa = ScalarMatrixMultiplication(A, L2);   //ASK PROF

                    //Evaluation to obtain B1
                    Hq = MatrixMultiplication(H1, q);
                    TransposeMatrix(Hq);
                    Hq_HqT = MatrixMultiplication(Hq, TransposeMatrix(Hq)); // (Hq)*(Hq)'
                    TransposeMatrix(q);
                    qiT_Hi_qi = MatrixMultiplication(TransposeMatrix(q), Hq);  //q'*(Hq)
                    inv_qiT_Hi_qi = -1 / qiT_Hi_qi[0, 0];
                    B1 = ScalarMatrixMultiplication(Hq_HqT, inv_qiT_Hi_qi);

                    //Initialization of H2
                    H2 = new double[,]
                    {
                       {0,0},
                       {0,0}
                    };

                    // Addition of Matrix H1, A1 and B1 using indexing to obtain H2 ==> H1 + A1 + B1
                    H2[0, 0] = H1[0, 0] + A1[0, 0] + B1[0, 0];
                    H2[0, 1] = H1[0, 1] + A1[0, 1] + B1[0, 1];
                    H2[1, 0] = H1[1, 0] + A1[1, 0] + B1[1, 0];
                    H2[1, 1] = H1[1, 1] + A1[1, 1] + B1[1, 1];


                    S2 = new double[,] { };
                    S2 = MatrixMultiplication(H2, g2);
                    S2 = ScalarMatrixMultiplication(S2, -1);

                    L2S2 = ScalarMatrixMultiplication(S2, L2);

                    //Initialization of X3
                    X3 = new double[,]
                    {
                       {0},
                       {0}
                    };

                    X3[0, 0] = X2[0, 0] + L2S2[0, 0];
                    X3[1, 0] = X2[1, 0] + L2S2[1, 0];

                    //Partial Diff wrt x1
                    g3x1 = (2 * a * X3[0, 0]) + (c * X3[1, 0]) + d;
                    //Partial Diff wrt x2
                    g3x2 = (2 * b * X3[1, 0]) + (c * X3[0, 0]) + (2 * ee * X3[1, 0]);

                    g3 = new double[,]
                    {
                       {g3x1},
                       {g3x2}
                    };

                    //Console.WriteLine();
                    //Console.WriteLine("============Iteration [{0}]============", i);
                    //Console.WriteLine("X3 (Search Point 3):");
                    //PrintMatrix1(X3);
                    //Console.WriteLine();
                    //Console.WriteLine("The Values of X3 are x1 = {0} and x2 = {1}", Math.Round(Convert.ToDecimal(X3[0, 0]), 3), Math.Round(Convert.ToDecimal(X3[1, 0]), 3));

                    //Console.WriteLine("The gradient vector g3 are  df(x)/dx1 = {0}, where as df(x)/dx2 = {1},", Math.Round(Convert.ToDecimal(g3x1), 3), Math.Round(Convert.ToDecimal(g3x2), 3));
                    //Console.WriteLine();
                    //Console.WriteLine("Hence X3 =[{0},{1}] is the required minimum point and X3 is Optimal", Math.Round(Convert.ToDecimal(X3[0, 0]), 0), Math.Round(Convert.ToDecimal(X3[1, 0]), 0));
                    //Console.WriteLine();
                    
                    g1x1 = g3x1;
                    g1x2 = g3x2;
                }

                else
                { }
            }


            //g1x1.Text = dfx1.ToString();
            //UserL1.Text = g3[0,0].ToString();
            //UserX2x1.Text = S1[0, 0].ToString();


            //===================================CODE TO GRADE THE USER======================================

            

            GradeData = new double[] { g1[0,0],g1[1,0],s1x1,s1x2,L1,X2[0,0],X2[1,0]};

            double mark1;
            bool isEntryEmptyMark1 = string.IsNullOrEmpty(Userg1x1.Text);
            if (isEntryEmptyMark1)
            {
                mark1 = 0;
            }
            else if (double.Parse(Userg1x1.Text) == GradeData[0])
            {
                mark1 = 1;
            }
            else
            {
                mark1 = 0;
            }



            double mark2;
            bool isEntryEmptyMark2 = string.IsNullOrEmpty(Userg1x2.Text);
            if (isEntryEmptyMark2)
            {
                mark2 = 0;
            }
            else if (double.Parse(Userg1x2.Text) == GradeData[1])
            {
                mark2 = 1;
            }
            else
            {
                mark2 = 0;
            }

            
            double mark3;
            bool isEntryEmptyMark3 = string.IsNullOrEmpty(Users1x1.Text);
            if (isEntryEmptyMark3)
            {
                mark3 = 0;
            }
            else if (double.Parse(Users1x1.Text) == GradeData[2])
            {
                mark3 = 1;
            }
            else
            {
                mark3 = 0;
            }



            double mark4;
            bool isEntryEmptyMark4 = string.IsNullOrEmpty(Users1x2.Text);
            if (isEntryEmptyMark4)
            {
                mark4 = 0;
            }
            else if (double.Parse(Users1x2.Text) == s1x2)
            {
                mark4 = 1;
            }
            else
            {
                mark4 = 0;
            }


            double mark5;
            bool isEntryEmptyMark5 = string.IsNullOrEmpty(UserL1.Text);
            if (isEntryEmptyMark5)
            {
                mark5 = 0;
            }
            else if (double.Parse(UserL1.Text) == L1)
            {
                mark5 = 1;
            }
            else
            {
                mark5 = 0;
            }


            double mark6;
            bool isEntryEmptyMark6 = string.IsNullOrEmpty(UserX2x1.Text);
            if (isEntryEmptyMark6)
            {
                mark6 = 0;
            }
            else if (double.Parse(UserX2x1.Text) == x2x1)
            {
                mark6 = 1;
            }
            else
            {
                mark6 = 0;
            }


            double mark7;
            bool isEntryEmptyMark7 = string.IsNullOrEmpty(UserX2x2.Text);
            if (isEntryEmptyMark7)
            {
                mark7 = 0;
            }
            else if (double.Parse(UserX2x2.Text) == x2x2)
            {
                mark7 = 1;
            }
            else
            {
                mark7 = 0;
            }

            double mark_iteration1 = mark1 + mark2 + mark3 + mark4 + mark5 + mark6 + mark7;
            double markscore = mark_iteration1 / 7;

            double score = Math.Round( markscore*100 );

            //g1x1.Text = dfx1.ToString();
            UserGrade.Text = score.ToString();

            await Navigation.PushAsync(new DfpPage4());
        }

        async private void BackButtonIterationOnePage_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new DfpPage2());
        }

        //PrintMatrix1,void method to print a matrix of this nature[,]
        static void PrintMatrix1(double[,] matrix)
        {
            if (matrix == null)
                return;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0}", matrix[i, j].ToString().PadLeft(5, ' ')));
                }
                Console.WriteLine();
            }
        }

        // Method to multiply two Matrix A and Matric B - SAMPLE 1
        static int[,] Multiply(int[,] matrix_H1, int[,] matrix_g1)
        {
            //The line below explains thats if  number of column in matrixH1 is not equal to number of row in matrix g1 write illegal matrix dimension to console else solve it. Getlength(1) = Column, Getlength(0) = Row.
            if (matrix_H1.GetLength(1) != matrix_g1.GetLength(0))
            {
                Console.WriteLine("Illegal matrix dimension");
                return null;
            }
            int[,] result = new int[matrix_H1.GetLength(0), matrix_g1.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < matrix_H1.GetLength(0); j++)
                {
                    for (int k = 0; k < matrix_H1.GetLength(1); k++)
                    {
                        result[i, j] += matrix_H1[i, k] * matrix_g1[k, j];
                    }
                }
            }
            return result;
        }

        // Method to multiply two Matrix A and Matric B - SAMPLE 2
        static double[,] MatrixMultiplication(double[,] A, double[,] B)
        {
            int n1 = A.GetLength(1);
            int n2 = B.GetLength(0);
            if (n1 != n2)
            {
                Console.WriteLine("The column count of the first array must equal the row count of the second array");
                return null;
            }

            double[,] C = new double[A.GetLength(0), B.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int z = 0; z < n1; z++)
                    {
                        C[i, j] += A[i, z] * B[z, j];
                    }
                }
            }
            return C;
        }

        // Method to Multiply a Scalar with a Matrix
        static double[,] ScalarMatrixMultiplication(double[,] matrix, double m)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i, j] * m;
                }
            }

            return matrix;
        }

        // Method to Transpose a Matrix
        static double[,] TransposeMatrix(double[,] matrix)
        {
            double[,] sT = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sT[j, i] = matrix[i, j];
                }
            }
            return sT;
        }

        // Method to Add two Matrices
        static double[][] Addition_Matrix(double[][] matrixA, double[][] matrixB)
        {
            double[][] c = new double[matrixA.Length][];
            for (int i = 0; i < matrixA.Length && i < matrixB.Length; i++)
            {
                c[i] = new double[matrixA[i].Length];
                for (int j = 0; j < matrixA[i].Length && j < matrixB[i].Length; j++)
                {
                    c[i][j] = matrixA[i][j] + matrixB[i][j];
                }
            }
            return c;
        }

        // PrintMatrix2,void method to print a matrix of this nature [][]
        static void PrintMatrix2(double[][] matrix)
        {
            if (matrix == null) return;
            foreach (double[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}