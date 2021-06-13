using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.DTOS
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        private int recordPorPagina = 10;
        private readonly int cantidadMaximaRecordPorPagina = 50;
        public int RecordsPorPagina
        {
            get
            {
                return recordPorPagina;
            }
            set
            {
                recordPorPagina = (value > cantidadMaximaRecordPorPagina) ? cantidadMaximaRecordPorPagina : value;
            }
        }
    }
}
