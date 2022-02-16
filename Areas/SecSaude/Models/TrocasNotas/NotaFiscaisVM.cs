using Microsoft.AspNetCore.Http;
using SecSaudeAH.Models.BDSECSAUDE.Context;
using SecSaudeAH.Models.BDSECSAUDE.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Areas.SecSaude.Models.TrocasNotas
{
    public class NotaFiscaisVM
    {
        public int Id { get; set; }
        public int IdNota { get; set; }
        public int IdCidadao { get; set; }

        [Required(ErrorMessage = Global.Required)]
        [MinLength(18, ErrorMessage = "CNPJ inválido.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = Global.Required)]
        [MinLength(9, ErrorMessage = "Número da nota contém 9 digitos.")]
        public string NumNota { get; set; }

        [Required(ErrorMessage = Global.Required)]
        public string ValorS { get; set; }
        public decimal Valor { get; set; }
        public int ProfissionalId { get; set; }

        [Required(ErrorMessage = Global.Required)]
        public IFormFile Foto { get; set; }
        public string NomeArquivo { get; set; }

        public bool IsAtivo { get; set; }
        public string Nome { get;  set; }
        public string Telefone { get;  set; }
        public string DataNasc { get;  set; }
        public string Endereco { get;  set; }
        public string FotoEndereco { get; set; }

        

        public NotasFiscais Insert(int id) => new NotasFiscais() { ProfissionalId = id, CNPJ = CNPJ, Numero = NumNota, Valor = decimal.Parse(ValorS.Replace(".", "").Replace(",", ".")), NomeArquivo = NomeArquivo };

        //public NotaFiscaisVM Update(DBSaudeAHContext _context, int id)
        //{
        //    var paciente = _context.Pacientes.First(c => c.Id == id);
        //    paciente.Nome = this.Nome;
        //    paciente.Endereco = this.Endereco;
        //    paciente.DataNasc = this.DataNasc;
        //    paciente.CPF = this.CPF;
        //    paciente.Telefone = this.Telefone;
        //    return paciente;
        //}


    }

    public class TrocaIngresso 
    {
        public int IdTroca { get; set; }
        public string DataTroca { get; set; }
    }

    public class Ingresso
    {
        public List<TrocaIngresso> Trocas { get; set; }
        public List<NotaFiscaisVM> Notas { get; set; }
    }
}
