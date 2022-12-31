namespace corotosapi.Models.Dto
{
    public class DtoSubCategoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int IdCategoria { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
    }
}
