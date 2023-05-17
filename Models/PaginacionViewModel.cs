namespace ManejadorDePresupuestos.Models
{
    public class PaginacionViewModel
    {
        public int Pagina { get; set; } = 1;
        private int recordsPorPagina { get; set; } = 10;
        private readonly int cantidadMaximaRecordPorPagina = 50;

        public int RecordsPorPagina
        {
            get
            {
                return recordsPorPagina;
            }
            set
            {
                recordsPorPagina = (value > cantidadMaximaRecordPorPagina ? cantidadMaximaRecordPorPagina : value);
            }
        }

        public int RecordsASaltar => recordsPorPagina * (Pagina - 1);
    }
}