﻿using System.Collections.Generic;

namespace SistemaAuxiliarPesquisaZika.Domain.Helpers
{
    public class Constants
    {
        
        private static ICollection<ReagenteNaoReagente> listaReagenteNaoReagente = new List<ReagenteNaoReagente>();

        public static ICollection<ReagenteNaoReagente> ListaReagenteNaoReagente
        {
            get
            {               
                return ListaReagenteNãoReagente();
            }
        }

        public static ICollection<ReagenteNaoReagente> ListaReagenteNãoReagente()
        {
            ReagenteNaoReagente OReagenteNaoReagente = new ReagenteNaoReagente();
            if (listaReagenteNaoReagente == null)
            {
                listaReagenteNaoReagente.Add(new ReagenteNaoReagente()
                {
                    Id = 1,
                    Value = "Reagente"
                });
                listaReagenteNaoReagente.Add(new ReagenteNaoReagente()
                {
                    Id = 2,
                    Value = "Não Reagente / Imune"
                });
            }
            return listaReagenteNaoReagente;
        }

        private static List<string> positivoNegativo;

        public static List<string> PositivoNegativo
        {
            get
            {
                positivoNegativo.Add("");
                positivoNegativo.Add("Positivo");
                positivoNegativo.Add("Negativo");
                return positivoNegativo;
            }
        }

        public Constants()
        {
            //listaReagenteNaoReagente = new List<ReagenteNaoReagente>();
            ListaReagenteNãoReagente();
        }

    }
}
