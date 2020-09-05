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
    public partial class DfpPage2 : ContentPage
    {
       

        public DfpPage2()
        {
            InitializeComponent();
           
        }


        async private void SolveButton_Clicked(object sender, EventArgs e)
        {

            /*
            //Variabales used for Model

            double fx;
            double[,] X1 = new double[,]
            {
                  {-2},
                  {4}
            };


            double a = double.Parse(EntryA.Text);
            double b = double.Parse(EntryB.Text);
            double c = double.Parse(EntryC.Text);
            double d = double.Parse(EntryD.Text);
            double ee = double.Parse(EntryE.Text);
            double f = double.Parse(EntryF.Text);

            //MODEL
            fx = (a * Math.Pow(X1[0, 0], 2)) + (b * Math.Pow(X1[1, 0], 2)) + (c * X1[0, 0] * X1[1, 0]) + (d * X1[0, 0]) + (ee * Math.Pow(X1[1, 0], 2)) + f;
            Fx.Text = fx.ToString();

            //Partial Diff wrt x1
            double dfx1 = (2 * a * X1[0, 0]) + (c * X1[1, 0]) + d;
            //Fx.Text = dfx1.ToString();

            //Partial Diff wrt x2
            double dfx2 = (2 * b * X1[1, 0]) + (c * X1[0, 0]) + (2 * ee * X1[1, 0]);

           // Console.WriteLine("DAVIDON FLECTHER POWELL STAGE 2 : PARTIAL DIFFERENTIATION OF GIVEN FUNCTION TO EVALAUTE gi AND MATRIX MULTIPLICATION TO EVALUATE Si=Hi*gi. Hi = I IS ALREADY EMBEDED");

            //Multiplication of 2D arrays
            double[,] H1 = new double[,]
            {
                    {1,0},
                    {0,1}
            };

            //Inputing the values of g1x1 and g1x2 in the matrix g1
            double[,] g1 = new double[,]
            {
                    {dfx1},
                    {dfx2}
            };


            //The dimensions of the Matrices being multiplied determines the nature of the dimension of the resultant matrix array holding the answer of the matrix multplication.
            //NOTE:If Column of first matrix = Row of Second matrix then they can be multiplied/
            // 2x2 * 2x1

            double[,] S1 = MatrixMultiplication(H1, g1);
            S1 = ScalarMatrixMultiplication(S1, -1);

            double s1x1 = S1[0, 0];
            double s1x2 = S1[1, 0];


            double l1 = 0.2941;
            double[,] L1S1 = ScalarMatrixMultiplication(S1, l1);

            X1[0, 0] = X1[0, 0] + L1S1[0, 0];
            X1[1, 0] = X1[1, 0] + L1S1[1, 0];

            double x2x1 = X1[0, 0];
            double x2x2 = X1[1, 0];
            */



            await Navigation.PushAsync(new DfpPage3()); //dfx1, dfx2,s1x1,s1x2,x2x1,x2x2)
        }

        

        async private void BackButtonInputCoefPage_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new DfpPage());
        }


        

       


    }
}