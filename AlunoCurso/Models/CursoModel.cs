using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlunoCurso.Models
{
    public class CursoModel
    {
        [Key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe nome do curso:")]
        [Display(Name = "Nome do Curso:")]
        public string Curso { get; set; }
        
        [Required(ErrorMessage = "Informe carga horária:")]
        [Display(Name = "Carga Horária")]
        public string CH { get; set; }

        public virtual ICollection<AlunoModel> Alunos { get; set; }
    }
}