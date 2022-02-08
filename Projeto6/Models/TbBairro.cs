using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto6.Models
{
    public class TbBairro
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CODIGO_BAIRRO")]
        public int CodigoBairro { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "O máximo de caracteres permitido são 50")]
        [Column("NOME")]
        public string Nome { get; set; }

        [Required]
        [Column("STATUS")]
        public int Status { get; set; }

        [ForeignKey("TbMunicipio")]
        [Column("CODIGO_MUNICIPIO")]
        public int CodigoMunicipio { get; set; }
        public TbMunicipio TbMunicipio { get; set; }

        //Relacionamento bairro e Endereco
        public ICollection<TbEndereco> TbEndereco { get; set; }
    }
}
