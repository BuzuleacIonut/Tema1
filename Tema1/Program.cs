using System;
using System.Collections.Generic;
using System.Drawing;
using Tema1;


static void Main(string[] args) {
    Point p1 = new Point(20, 39);
    Point p2 = new Point(24, 12);
    Point p3 = new Point(90, 45);
    Point p4 = new Point(66,77);
    Point p5 = new Point(81,100);


    Poligon triunghi = new Triunghi(p1,p2,p3);// polimorfism 
    Poligon patrulater=new Patrulater(p2,p3,p4,p5);
    //triunghi.Nume=String"nume1";
    double AriaTriunghi = triunghi.Arie();
    double AriaPatrulaterului=patrulater.Arie();
    Console.WriteLine(AriaTriunghi.ToString());
    Console.WriteLine(AriaPatrulaterului.ToString()); // abstractizare
    //triunghi.Nume().set



}
namespace Tema1
{
    abstract class Poligon
    {
        //public  List<Point> puncte = new List<Point>();
        //public string Nume { get; set; }
        private string nume;

        // Proprietate publică pentru a accesa și a modifica marca mașinii
        public string Nume
        {
            get { return nume; } // Getter 
            set { nume = value; } // Setter 
        }

        

        public abstract double Arie();  // arie e metoda abstracta
    }

    class Triunghi : Poligon { // mostenire


         public Point P1 { get; set; }
        public Point P2 { get; set; }

        public Point P3 { get; set; }
        private Triunghi(int ax, int ay, int bx, int by, int cx, int cy)
        {
            Point p1 = new Point(ax, ay);
            P1 = p1;
            Point p2 = new Point(bx, by);
            P2 = p2;
            Point p3 = new Point(cx, cy);
            P3 = p3;
           
        } // incapsulare: unele metode sunt disponibile doar in clasa in care au fost declarate

        public Triunghi(Point p1, Point p2, Point p3, string nume)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            Nume = nume;

        }

        public Triunghi(Point p1, Point p2, Point p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;

        } // constructori diferiti 


        public override double Arie() {            //Definim aria triunghiului si a patrulaterului in mod diferit
            double l1 = Math.Sqrt(Math.Pow(P1.X - P2.X, 2) + Math.Pow(P1.Y - P2.Y, 2));
            double l2 = Math.Sqrt(Math.Pow(P2.X - P3.X, 2) + Math.Pow(P2.Y - P3.Y, 2));
            double l3 = Math.Sqrt(Math.Pow(P3.X - P1.X, 2) + Math.Pow(P3.Y - P1.Y, 2));
            double p = (l1 + l2 + l3) / 2;

            return Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3));


        }
       
        


        }


    

class Patrulater : Poligon { // mostenire

        
        public Point P1 { get; set; }
        public Point P2 { get; set; }

        public Point P3 { get; set; }

        public Point P4 { get; set; }
        public Patrulater(Point p1, Point p2, Point p3, Point p4,string nume)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
            Nume = nume;

        }

         public Patrulater(Point p1, Point p2, Point p3, Point p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
           

        } // constructori diferiti 
        private Patrulater(int ax,int ay,int bx, int by,int cx, int cy, int dx,int dy) {
            Point p1= new Point(ax, ay);
            P1 = p1;
            Point p2= new Point(bx, by);
            P2 = p2;
            Point p3= new Point(cx, cy);    
            P3 = p3;
            Point p4 = new Point(dx, dy);
            P4 = p4;
        }

        public override double Arie()   //aria patrulatrului e aria triunghiului obtinut din luarea a 3 puncte oarecare din patrulater, proces repetat de 2 ori
    {

            double l1 = Math.Sqrt(Math.Pow(P1.X - P2.X, 2) + Math.Pow(P1.Y - P2.Y, 2));
            double l2 = Math.Sqrt(Math.Pow(P2.X - P3.X, 2) + Math.Pow(P2.Y - P3.Y, 2));
            double l3 = Math.Sqrt(Math.Pow(P3.X - P4.X, 2) + Math.Pow(P3.Y - P4.Y, 2));
            double l4 = Math.Sqrt(Math.Pow(P4.X - P1.X, 2) + Math.Pow(P4.Y - P1.Y, 2));

            double p1 = (l1 + l2 + l3) / 2;
            double p2 = (l2 + l3 + l4) / 2;

            double arie1 = Math.Sqrt(p1 * (p1 - l1) * (p1 - l2) * (p1 - l3));
            double arie2 = Math.Sqrt(p2 * (p2 - l2) * (p2 - l3) * (p2 - l4));
            return arie1 + arie2;

    }
}
    // polimorfismul = folosim Arie() pentru 2 tipuri de obiecte diferite  si nu ne interesaza tipul obiectului
    // abstractizarea inseamna crearea crearea unei functii ce se poate detalia in functie de obiectul cu care lucram
    // mostenirea are loc prin faptul ca patrulater si triungi mostenesc aceeasi clasa de baza Poligon

    
}
