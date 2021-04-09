using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace anc1
{
    class Swiat
    {
        public Graphics gr;
        public List<Mrowka> mrowki;
        public List<Czastka> czastki;
        //public List<Ferom> feromony;
        public Random rnd;
        public Swiat()
            

        {

        }

        /*
        public void initferomonow()
        {
            feromony = new List<Ferom>();
        }
        */

        public void initmrowek()
        {
            mrowki = new List<Mrowka>();
            for (int i=0;i<3;i++)
            {
                Mrowka tmr = new Mrowka();
                tmr.poz.X = 100;
                tmr.poz.Y = 100+i*50;
                tmr.kierunek = 0;
                mrowki.Add(tmr);
            }
            for (int i = 0; i < 3; i++)
            {
                Mrowka tmr = new Mrowka();
                tmr.poz.X = 500;
                tmr.poz.Y = 100 + i * 50;
                tmr.kierunek = 3.15f;
                mrowki.Add(tmr);
            }
            for (int i = 0; i < 3; i++)
            {
                Mrowka tmr = new Mrowka();
                tmr.poz.X = 200+i*50;
                tmr.poz.Y = 300;
                tmr.kierunek = 4.72f;
                mrowki.Add(tmr);
            }
            for (int i = 0; i < 3; i++)
            {
                Mrowka tmr = new Mrowka();
                tmr.poz.X = 200 + i * 50;
                tmr.poz.Y = 10;
                tmr.kierunek = 1.57f;
                mrowki.Add(tmr);
            }
        }

        public void initzarcia()
        {
            czastki = new List<Czastka>();

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    Czastka tcz = new Czastka();
                    tcz.poz.X = 200 + i * 10;
                    tcz.poz.Y = 100 + j * 10;
                    tcz.typ = Czastka.typ_czastki.jedzenie;
                    czastki.Add(tcz);
                }
        }
        public void init()
        {
            rnd = new Random();
            initmrowek();
            initzarcia();
        }

        public void ruszmrowki()
        {
            foreach(Mrowka mr in mrowki)
            {
                mr.rusz(rnd,czastki);
                mr.dodajslad(czastki);

            }
        }
        /*
        public void ruszferomony()
        {
            foreach(Ferom fer in feromony)
            {
                fer.rusz();
            }
        }
        */

            public void ruszczastki()
        {
            foreach(Czastka tcz in czastki)
            {
                tcz.rusz();
            }
            czastki.RemoveAll(item => item.starosc == 0);
        }

        public void rusz()
        {
            ruszczastki();
            ruszmrowki();
        }

        public void rysujmrowki()
        {
            foreach(Mrowka mr in mrowki)
            {
                mr.rysuj(gr);
            }
        }

        public void rysujczastki()
        {
            foreach(Czastka tcz in czastki)
            {
                tcz.rysuj(gr);
            }
        }
        /*
        public void rysujferomony()
        {
            foreach(Ferom fer in feromony)
            {
                fer.rysuj(gr);
            }
        }
        */

        public void rysuj()
        {
            //rysujzarcia();
            rysujczastki();
            rysujmrowki();

        }
    }

}
