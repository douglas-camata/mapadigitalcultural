using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
     [Table("Regioes")]
    public class Regiao
    {
        [Key]
        public int IdRegiao { get; set; }
        public string Nome { get; set; }
        public string? ImagemDanca { get; set; }
        public string? Danca { get; set; }
        public string? ImagemCulinaria { get; set; }
        public string? Culinaria { get; set; }
        public string? ImagemMusica { get; set; }
        public string? Musica { get; set; }
        public string? ImagemFestas { get; set; }
        public string? Festas { get; set; }
        public string? ImagemFolclore { get; set; }
        public string? Folclore { get; set; }
        public string? ImagemArtesanato { get; set; }
        public string? Artesanato { get; set; }
        public string? ImagemVestimenta { get; set; }
        public string? Vestimenta { get; set; }
        public string? ImagemLiteratura { get; set; }
        public string? Literatura { get; set; }
        public string? ImagemTurismo { get; set; }
        public string? Turismo { get; set; }
        

    }
}
