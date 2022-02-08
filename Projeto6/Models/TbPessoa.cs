using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto6.Models
{
    public class TbPessoa
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)] //O usuário irá digitar a chave primária
        [Column("CODIGO_PESSOA")]
        public int CodigoPessoa { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O máximo de caracteres permitido são 50")]
        [Column("NOME")]
        public string Nome { get; set; }

        [Required]
        [StringLength (50, ErrorMessage = "O máximo de caracteres permitido são 50")]
        [Column("SOBRENOME")]
        public string Sobrenome { get; set; }

        [Required]
        [StringLength (100, ErrorMessage = "O máximo de caracteres permitido são 100")]
        [Column("SENHA")]
        public string Senha { get; set; }

        [Required]
        [StringLength (100)]
        [Column("LOGIN")]
        public string Login { get; set; }

        [Required]
        [Column("IDADE")]
        public int Idade { get; set; }

        [Required]
        [Column("STATUS")]
        public int Status { get; set; }


        public ICollection<TbEndereco> TbEndereco { get; set; }
    }
}
