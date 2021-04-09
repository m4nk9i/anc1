using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace anc1
{

    class Czastka
    {
        public enum typ_czastki
        {
            nieznany,
            fe_pozarcie,
            fe_donory,
            jedzenie
        }
        public Vector2 poz;
        public bool wolne=true;
        public typ_czastki typ;
        public int starosc;
        public Czastka()
        {
            starosc = 10;
        }

        public Czastka(Vector2 ppoz)
        {
            starosc = 10;
            poz = ppoz;
        }

        public Czastka(Vector2 ppoz, int psta)
        {
            poz = ppoz;
            starosc = psta;
        }

        public void rysuj (Graphics gr)
        {
            if (wolne == true)
            {
                Brush br = Brushes.Black;
                switch (typ)
                {
                    case typ_czastki.fe_pozarcie: br = Brushes.Blue; break;
                    case typ_czastki.fe_donory: br = Brushes.Pink; break;
                    case typ_czastki.jedzenie: br = Brushes.Green; break;
                }

                gr.FillEllipse(br, poz.X - 5, poz.Y - 5, 10, 10);
            }
        }

        public void rusz()
        {
            if ((typ == typ_czastki.fe_donory) || (typ == typ_czastki.fe_pozarcie))
                starosc--;

        }
    }


    class Mrowka
    {
        public Vector2 poz;
        public Czastka zar;
        public float kierunek;
        public float wielkosc;
        public bool szukazarcia;

        
        public Mrowka()
        {
            szukazarcia = true;
            zar = null;
            wielkosc = 10;
        }

        public void rusz(float odl, Random pran,List<Czastka> pplcz)
        {
            List<Czastka> tlcz;
            Vector2 tvec = new Vector2(odl * (float) Math.Cos(kierunek), odl * (float)Math.Sin(kierunek));
            //      kierunek =kierunek+ pran.Next(20)/10.0f-1.0f;
            kierunek =kierunek+ pran.Next(20)/20.0f-0.50f;
            poz = poz + tvec;
            tlcz = znajdz(pplcz);
            foreach (Czastka tcz in tlcz)
            {
                if ((tcz.typ==Czastka.typ_czastki.jedzenie)
                    && (szukazarcia==true) && (tcz.wolne==true))
                {
                    if (Vector2.Distance(poz, tcz.poz) < 20)
                    {
                        zar = tcz;
                        tcz.wolne = false;
                        szukazarcia = false;
                        //pplcz.Remove(tcz);
                        //break;
                    } else
                    {
                        kierunek = kat(tcz.poz - poz);
                    }
                }

            }

        }

        public override string ToString()
        {
            string tstr = ""+poz.ToString()+" (kierunek "+kierunek.ToString()+" )\r\n";
            tstr += szukazarcia.ToString();

            return tstr;
        }

        public void rusz(Random pran, List<Czastka> pplcz)
        {
            rusz(10,pran,pplcz);

        }

        public void rysuj(Graphics gr)
        {
            Vector2 tvec=new Vector2(wielkosc* (float)Math.Cos(kierunek), wielkosc * (float)Math.Sin(kierunek));
            gr.DrawLine(Pens.Black, poz.X, poz.Y, poz.X + tvec.X, poz.Y + tvec.Y);
        }

        public void dodajslad(List<Czastka> plcz)
        {
            Czastka tcz = new Czastka(poz,20);
            if (szukazarcia == true)
            {
                tcz.typ = Czastka.typ_czastki.fe_pozarcie;
            }else
            {
                tcz.typ = Czastka.typ_czastki.fe_donory;
            }
            
            plcz.Add(tcz);
        }

        public float kat(Vector2 twek)
        {
            return (float)Math.Atan2(twek.Y, twek.X);
        }

        public List<Czastka> znajdz(List<Czastka> plcz)
        {
            float katt;
            List<Czastka> tlcz =new List<Czastka>();
            
            foreach(Czastka tcz in plcz)
            {
                
                if (Vector2.Distance(tcz.poz,poz)<900)
                {
                    katt = kat(poz - tcz.poz);
                    if (( kierunek -katt< 0.5) && (kierunek- katt > -0.5))
                    {
                        tlcz.Add(tcz);
                    }
                }
            }
            return tlcz;
        }
    }
}
