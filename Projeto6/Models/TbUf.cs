using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto6.Models
{
    public class TbUf
    {
        [Key] //Definindo a chave primária
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CODIGO_UF")]
        public int CodigoUf { get; set; }
        
        [Required] //Definindo como notnull
        [StringLength(50, ErrorMessage = "O máximo de caracteres permitido são 50")]
        [Column("NOME")]
        public string Nome { get; set; }

        
        [Required]
        [StringLength(2, ErrorMessage = "O máximo de caracteres permitido são 2")]
        [Column("SIGLA")]
        public string Sigla { get; set; }

        [Required]
        [Column("STATUS")]
        public int Status { get; set; }


        //Configurando o relacionamento
        public ICollection<TbMunicipio> TbMunicipio { get; set; } //public ICollection<TbMunicipio> TbMunicipios { get; set; }


    }
}
