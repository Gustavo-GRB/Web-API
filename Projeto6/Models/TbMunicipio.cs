using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto6.Models
{
    public class TbMunicipio
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]//O usuário irá digitar a chave primária
        [Column("CODIGO_MUNICIPIO")]
        public int CodigoMunicipio { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "O máximo de caracteres permitido são 100")]
        [Column("NOME")]
        public string Nome { get; set; }

        [Required]
        [Column("STATUS")]
        public int Status { get; set; }

        //Configurando o relacionamento 1:N
        [ForeignKey("TbUf")]
        [Column("CODIGO_UF")]
        public int CodigoUf { get; set; }
        public TbUf TbUf { get; set; }

        public ICollection<TbBairro> TbBairros { get; set; }

    }
}
