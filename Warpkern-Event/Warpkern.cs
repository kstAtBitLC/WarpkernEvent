using System;
using System.Collections.Generic;
using System.Text;

namespace WarpkernEvent
{
    class Warpkern {
        // Zufallszahlgenerator
        private readonly Random zzG = new Random();  // ohne readonly erscheint eine Warnung im Errorfernster, die man ignorieren kann- aber nicht muß

        // unsere zwei Events: TemperaturÄnderungEventArgs erbt von EventArgs und ist unser Parameter: siehe unten
        public event EventHandler<TemperaturÄnderungEventArgs> TemperaturÄnderungEvent;
        public event EventHandler<TemperaturÄnderungEventArgs> TemperaturAlarmEvent;

        // Property
        private int WarpkernTemperatur { get; set; }  // aktuelle Temperatur


        // Methode
        public void ÄndereTemperatur() {
            int temperatur = zzG.Next(120, 777);  // zufällig generiere NEUE Temperatur
            System.Threading.Thread.Sleep(500);  // warte eine halbe Sekunde
            TemperaturÄnderungEventArgs täEventArgs;

            if (temperatur != this.WarpkernTemperatur) {
                täEventArgs = new TemperaturÄnderungEventArgs()
                {
                    AlteTemperatur = WarpkernTemperatur,
                    NeueTemperatur = temperatur
                };

                this.WarpkernTemperatur = temperatur; // setzte die Warbkerntemperatur auf die NEUE TEmperatur

                if (temperatur > 500) {
                    //OnTemperaturAlarm(this, täEventArgs); // alternetive Schreibweise mit 2 Parametern
                    OnTemperaturAlarm( täEventArgs);
                }
                //OnTemperaturÄnderung(this, täEventArgs);     // alternetive Schreibweise mit 2 Parametern          
                OnTemperaturÄnderung ( täEventArgs);               
            }

        }

        //private void OnTemperaturAlarm(Warpkern warpkern, TemperaturÄnderungEventArgs e) {
        //    if (TemperaturAlarmEvent != null) {                        // herkömmliche Schreibweise bis C# 6
        //        TemperaturAlarmEvent(this, e);
        //    }
        //}

        private void OnTemperaturAlarm ( TemperaturÄnderungEventArgs e ) {
            TemperaturAlarmEvent.Invoke ( this, e ); // verkürztes Schreibweise ab C# 6 - so kann die if-Anweisung entfallen
        }

        //public virtual void OnTemperaturÄnderung(Warpkern warpkern , TemperaturÄnderungEventArgs e) {
        //    if (TemperaturÄnderungEvent != null) {                      // herkömmliche Schreibweise bis C# 6
        //        TemperaturÄnderungEvent(this, e);
        //    }
        //}

        public virtual void OnTemperaturÄnderung ( TemperaturÄnderungEventArgs e ) {
                TemperaturÄnderungEvent.Invoke ( this, e ); // verkürztes Schreibweise ab C# 6 - so kann die if-Anweisung entfallen
        }
    }

    // Klasse für den Parameter unseres Delegates
    class TemperaturÄnderungEventArgs: EventArgs {
        public int AlteTemperatur { get; set; }
        public int NeueTemperatur { get; set; }
        public DateTime DatumZeit { get; set; }

        public TemperaturÄnderungEventArgs() {
           // AlteTemperatur = 
            DatumZeit = DateTime.Now;
        }
    }

}
