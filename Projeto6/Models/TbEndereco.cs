using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto6.Models
{
    public class TbEndereco
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("CODIGO_ENDERECO")]
        public int CodigoEndereco { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O máximo de caracteres permitido são 50")]
        [Column("RUA")]
        public string Rua { get; set; }
        
        [Required]
        [Column("NUMERO")] //(50)
        public int Numero { get; set; }

        [Required]
        [StringLength(256, ErrorMessage = "O máximo de caracteres permitido são 256")]
        [Column("COMPLEMENTO")]
        public string Complemento { get; set; }

        [Required]
        [Column("CEP")]
        public int Cep { get; set; }



        [ForeignKey("TbBairro")]
        [Column("CODIGO_BAIRRO")]
        public int CodigoBairro { get; set; }
        public TbBairro TbBairro { get; set; }


 
        public ICollection<TbPessoa> TbPessoa { get; set; }
    }
}
