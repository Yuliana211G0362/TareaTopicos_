﻿
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TareaTopicos_
{
    public  class Juego : INotifyPropertyChanged
    {
        private ushort numeroAAdivinar;
        private byte oportunidades;

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool JuegoIniciado { get; set; } = false;
        public string? Resultado { get; set; }
        public byte Oportunidades
        {
            get { return oportunidades; }
        }
        public ushort final { get; set; }
        public void Iniciar()
        {
            Random r = new Random();
            numeroAAdivinar = (ushort)r.Next(1, 5001);
            oportunidades = 20;
            Resultado = "Pista";
            JuegoIniciado = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Jugar()
        {
            if (final == numeroAAdivinar)
            {
                JuegoIniciado = false;
                Resultado = "Ganaste :D";
                final = 0;
            }
            else
            {
                oportunidades--;
                if (oportunidades == 0)
                {
                    JuegoIniciado = false;
                    Resultado = "Perdiste :(";
                    final = 0;
                }
                else
                {
                    if (numeroAAdivinar > final)
                    {
                        Resultado = "El numero es mayor";
                    }
                    if (numeroAAdivinar < final)
                    {
                        Resultado = "El numero es menor";
                    }
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public ICommand IniciarComando { get; set; }
        public ICommand JugarComando { get; set; }

        public Juego()
        {
            IniciarComando = new RelayCommand(Iniciar);
            JugarComando = new RelayCommand(Jugar);
        }

    }
}
