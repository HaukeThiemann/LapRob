using System;
using Mathematics;
using SparseCollections;

public class Calibration
{
    private double[][][] RobotData;
    private double[][][] TrackerData;
    private Sparse2DMatrix<int,int,double> A;
    private SparseArray<int, double> w;
    private SparseArray<int, double> b;
    private SparseArray<int,double>[] calbirationValues;
    private int samplesize;
    private int curr;
    private int currItem {
        get {
            return curr;
        }
        set {
            if (value >= samplesize)
            {
                curr = 0;
            }
            else {
                curr = value;
            }
        }
    } 


	public Calibration(int samplesize)
	{
        this.samplesize = samplesize;
        RobotData = new double[samplesize][][];
        TrackerData = new double[samplesize][][];
        w = new SparseArray<int, double>();
        A = new Sparse2DMatrix<int, int, double>();
        b = new SparseArray<int, double>();
        calbirationValues = new SparseArray<int, double>[Factorial(samplesize-1)];
    }

    public void AddRobotData(double[][] data) {
        currItem++;
        this.RobotData[currItem] = data; 
    }
    public void AddTrackerData(double[][] data) {
        currItem++;
        this.TrackerData[currItem] = data;
    }
    private void calcEquationValues(int firstSet,int secondSet) {
        double[][] Z = UnityMatrix(12);
        double[][] E = ZeroMatrix(3, 3);
        int i = 0;
        for (; i < 12; i++)
        {
           
            int j = 0;
            for (; j < 9; j++) {

                A[i, j] = RobotData[firstSet][i%4][j%3] * TrackerData[firstSet][i / 3][j / 3];
            }
            for (; j < 12; j++) {
                A[i, j] = Z[i][j - 9];
            }
            for (; j < 24; j++)
            {
                A[i, j] = E[i][j - 12];
            }
        }
        for (; i < 24; i++)
        {
            int j = 0;
            for (; j < 9; j++)
            {
                A[i, j] = RobotData[secondSet][(i-12) % 4][j % 3] * TrackerData[secondSet][(i - 12) / 3][j / 3];
            }
            for (; j < 12; j++)
            {
                A[i, j] = Z[(i - 12)][j - 9];
            }
            for (; j < 24; j++)
            {
                A[i, j] = E[(i-12)][j - 12];
            }
        }
        i = 0;
        Z = ZeroMatrix(1, 9);
        for (; i < 9; i++) {
            b[i] = Z[0][i];
        }
        for (; i < 12; i++)
        {
            b[i] = RobotData[firstSet][3][i-9];
        }
        for (; i < 21; i++)
        {
            b[i] = Z[0][i-12];
        }
        for (; i < 24; i++)
        {
            b[i] = RobotData[secondSet][3][i - 12];
        }
    } 

    public SparseArray<int, double> Calibrate() {
        for (int i = 0; i < samplesize; i++){
            for (int j = i + 1; j < samplesize; j++) {
                calcEquationValues(i,j);
                LinearEquationSolver.Solve(24, A, b, w);
                calbirationValues[i*samplesize+j-1] = w;
            }
            
        }
        SparseArray<int, double> avg = new SparseArray<int, double>() ;
        for(int i=0;i<calbirationValues.Length;i++)
        {
            for (int j = 0; j < 24; j++) {
                avg[j] += calbirationValues[i][j];
            }
           
        }
        for (int j = 0; j < 24; j++)
        {
            avg[j] /= calbirationValues.Length;
        }
        return avg;
    }
    public void nextItem() {
        currItem++;
    }
    int Factorial(int i)
    {
        if (i <= 1)
            return 1;
        return i * Factorial(i - 1);
    }

    private double[][] UnityMatrix(int size) {
        double[][] E = new double[size][];
        for (int i = 0; i < size; i++) {
            E[i] = new double[size];
            for (int j = 0; j< size; j++) {
                if (j == i)
                {
                    E[i][j] = -1;
                }
                else {
                    E[i][j] = 0;
                }
            }
        }
        return E;
    }
    private double[][] ZeroMatrix(int m, int n) {
        double[][] Z = new double[m][];
        for (int i = 0; i < m; i++)
        {
            Z[i] = new double[n];
        }
        return Z;
    }
}
