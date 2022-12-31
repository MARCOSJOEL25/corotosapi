namespace corotosapi.Models.Dto
{
    public class DtoCategoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<SubCategorium> SubCategoria { get; set; }
    }
}
